using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmTansportMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    FillArea();
                    FillGrid();
                    geturl();
                }
                
            }
            else
            {
                Response.Redirect("~\\login.aspx", false);
            }
        }
        catch
        {

        }

    }

    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_transport @command='SelectTransportDetails',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intTransport_id='',@intArea_Id=''";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
   
    public void FillArea()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillArea',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchArea_Name", "intArea_Id");
            sBindDropDownList(chkSTD, strQry, "vchArea_Name", "intArea_Id");
        }
        catch
        {

        }
    }

    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           
                checksession();
                if (btnSubmit.Text == "Submit")
                {
                    string FromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy");
                    string ToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy");

                    int IsConcession = 0;

                    if (rbtnYes.Checked)
                        IsConcession = 1;
                    else
                        IsConcession = 0;

                    strQry = "exec [usp_transport] @command='CheckRecordExits',@dtStart_date='" + FromDate + "',@dtEnd_date='" + ToDate + "' ,@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Session["AcademicID"] + "',@intArea_Id='" + chkSTD.SelectedValue + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count == 0)
                    {
                        strQry = "exec [usp_transport] @command='insertTransportMaster' ,@intArea_Id='" + Convert.ToString(chkSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        string result = sExecuteScalar(strQry);
                        strQry = "exec [usp_transport] @command='insertTransportMasterDetails' ,@intTransport_id='" + result + "',@dtStart_date='" + FromDate + "',@dtEnd_date='" + ToDate + "',@IsConcession='" + IsConcession + "',@numAmout='" + txtAmt.Text + "',@Startday='" + txtStartday.Text + "',@Dueday='" + txtDueday.Text + "'";
                        int ExQuy = sExecuteQuery(strQry);
                        if (ExQuy > 0)
                        {
                            MessageBox("Record Inserted Successfully");
                            Clear();
                            FillGrid();
                        }
                    }
                    else
                    {
                        MessageBox("Record Already Exits between these date");
                    }
                }
                else
                {
                    string FromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy");
                    string ToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy");


                    int IsConcession = 0;

                    if (rbtnYes.Checked)
                        IsConcession = 1;
                    else
                        IsConcession = 0;

                     strQry = "exec [usp_transport] @command='CheckRecordExits',@dtStart_date='" + FromDate + "',@dtEnd_date='" + ToDate + "' ,@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count == 0)
                    {
                    strQry = "exec [usp_transport] @command='UpdateTransportDetails',@intID='" + ViewState["Id"] + "',@dtStart_date='" + FromDate + "',@dtEnd_date='" + ToDate + "',@IsConcession='" + IsConcession + "',@numAmout='" + txtAmt.Text + "',@Startday='" + txtStartday.Text + "',@Dueday='" + txtDueday.Text + "'";
                    int ExQuy = sExecuteQuery(strQry);
                    if (ExQuy > 0)
                    {
                        MessageBox("Record Updated Successfully");
                        Clear();
                        FillGrid();
                    }
                    }
                    else
                    {
                        MessageBox("Record Already Exits between these date");
                    }
                }
        }
        catch
        {

        }
    }
    public void Clear()
    {
        try
        {
            chkSTD.ClearSelection();
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtStartday.Text = "";
            txtDueday.Text = "";
            txtAmt.Text = "";
            rbtnYes.Checked = true;
            btnSubmit.Text = "Submit";
        }
        catch
        {

        }
    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception)
        {
            // return msg;
        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_transport @command='SelectTransportDetails',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intTransport_id='',@intArea_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }


    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["Id"] = id;
            strQry = "exec usp_transport @command='SelectTransportDetails',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intTransport_id='" + id + "',@intArea_Id='0'";
            dsObj = sGetDataset(strQry);
            chkSTD.Items.Clear();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //ddlParticular.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intFee_Id"]);
                //txtDurationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
                chkSTD.Items.Add(new ListItem(Convert.ToString(dsObj.Tables[0].Rows[0]["vchArea_Name"]),
                    Convert.ToString(dsObj.Tables[0].Rows[0]["intArea_Id"])));
                chkSTD.Items[0].Selected = true;

                string radiobutton = Convert.ToString(dsObj.Tables[0].Rows[0]["IsConcession"]);

                if (radiobutton == "Yes")
                    rbtnYes.Checked = true;
                else
                    rtbnNo.Checked = true;


                txtFromDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtStart_date"]);
                txtToDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtEnd_date"]);
                txtStartday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Startday"]);
                txtDueday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Dueday"]);

                txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmout"]);
                //txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]); 
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
                //ddlParticular.Enabled = false;
                chkSTD.Enabled = false;
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            strQry = "exec usp_transport @command='DeleteTransportDetails',@intID='" + id + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }
        }
        catch
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch
        {

        }
    }
    protected void drpAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSTD.ClearSelection();
    }

    protected void rbtnYes_CheckedChanged(object sender, System.EventArgs e)
    {
        rtbnNo.Checked = false;
        rbtnYes.Checked = true;
    }
    protected void rtbnNo_CheckedChanged(object sender, System.EventArgs e)
    {
        rbtnYes.Checked = false;
        rtbnNo.Checked = true;
    }
}