using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmOnlinePaymentReport : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        checksession();
        if (!IsPostBack)
        {
            strQry = "usp_Examination @command='standard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpstandard, strQry, "vchStandard_name", "intstandard_id");
            drpstandard.Items.Insert(1, "All");
            fGrid();
        }
    }

    protected void fGrid(int std=0,int div=0, int stud=0)
    {
        strQry = "usp_Addfee @command='GetOnlinePaymentFees',@intStudFee_id='',@intStandard_id='" + std + "',@intDivision_id='" + div + "',@intStudent_id='"+stud+"',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["OnlinepaymentReport"] = dsObj;
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
        else
        {
            grvDetail.DataSource = null;
            grvDetail.DataBind();
        }
   }
    protected void drpstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string std = drpstandard.SelectedValue == "All" ? "0" : drpstandard.SelectedValue;

        if (drpstandard.SelectedValue == "All")
        {
            fGrid();
        }
        else 
        {
            int stat = Convert.ToInt32(drpstandard.SelectedItem.Value);

           string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
           bool  st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");

            DropDownL2.Items.Insert(1, "All");
        }

        //strQry = "usp_Addfee @command='GetOnlinePaymentFees',@intStudFee_id='',@intStandard_id='" + std + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        //dsObj = sGetDataset(strQry);

        //Session["OnlinepaymentReport"] = dsObj;
        //grvDetail.DataSource = dsObj;
        //grvDetail.DataBind();
        ////txtName.Text = "";

    }
    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e) 
    {
        if (DropDownL2.SelectedValue == "All") 
        {
            //All Division
            fGrid(Convert.ToInt32(drpstandard.SelectedItem.Value));
        }
        else
        {
            int stat1 = Convert.ToInt32(drpstandard.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);

            string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            bool st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
            Droptypeuser.Items.Insert(1, "All");
        }
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e) 
    {
        if (Droptypeuser.SelectedValue == "All")
        {
            fGrid(Convert.ToInt32(drpstandard.SelectedItem.Value), Convert.ToInt32(DropDownL2.SelectedItem.Value));
        }
        else
        {
            fGrid(Convert.ToInt32(drpstandard.SelectedItem.Value), Convert.ToInt32(DropDownL2.SelectedItem.Value), Convert.ToInt32(Droptypeuser.SelectedItem.Value));  
        }
    }
    public void BtnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {  
        //    ClsExportExcel exp = new ClsExportExcel();
        //   // exp.ExportGrid(grvDetail, "OnlinePaymentReport" + DateTime.Now.ToString(), drpstandard.SelectedItem.Text + " Online Payment Report");
        //    exp.ExportGrid(grvDetail, "OnlinePaymentReport" + DateTime.Now.ToString(), 0, "",drpstandard.SelectedItem.Text, "", "", drpstandard.SelectedItem.Text + " Online Payment Report");
            Response.Redirect("frmExcel.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intStudFee_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_Addfee @command='FeeDetails',@intStudFee_id='" + Convert.ToString(Session["intStudFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModal()", true);
                GridView3.DataSource = dsObj;

                //Code By Nikhil
                int Amt = 0;
                int Latecharges = 0;
                int concession = 0;
                int netamt = 0;
                foreach (DataRow dr in dsObj.Tables[0].Rows)
                {
                    Amt += Convert.ToInt32(dr["vchAmount"]);
                    Latecharges += Convert.ToInt32(dr["vchLate_charges"]);
                    concession += Convert.ToInt32(dr["intConcession_amt"]);
                    netamt += Convert.ToInt32(dr["vchNetDetail_amt"]);
                }
                int OverAllConcession = Convert.ToInt32(dsObj.Tables[0].Rows[0]["overallDiscount"]);

                int FinalAmt = netamt - OverAllConcession;

                GridView3.Columns[2].FooterText = "Total" + "<br/>-------";
                GridView3.Columns[3].FooterText = Amt.ToString() + "<br/>----------";
                GridView3.Columns[4].FooterText = Latecharges.ToString() + "<br/>----------";
                GridView3.Columns[5].FooterText = concession.ToString() + "<br/>----------" + "<br/>Discount :";
                GridView3.Columns[6].FooterText = netamt.ToString() + "<br/>----------" + "<br/>" + OverAllConcession + "<br/>----------" + "<br/>" + FinalAmt;
                GridView3.FooterStyle.Font.Bold = true;
                GridView3.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            String id = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);

            dsObj =(DataSet)Session["OnlinepaymentReport"];

            string paymentstatus= dsObj.Tables[0].Rows[e.RowIndex]["status"].ToString();

            if (paymentstatus == "Inprogress")
            {
                MessageBox("Payment Status is Inprogress....");
            }
            else
            {
                Response.Redirect("~/frmFeeReport.aspx?intStudent_id=1808&intStudFee_id=" + id + "&intSchool_Id=" + Convert.ToString(Session["School_id"]) + "");
            }
        }
        catch (Exception ex)
        {
        }
    }


}