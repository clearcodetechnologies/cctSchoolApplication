using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmAnnualmaster : DBUtility
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
                    fillAcademicYear();
                  
                    
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
            int sum = 0;
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillAnnualMstGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();


            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                //String test = grvDetail.Rows[i].Cells[3].Text;

                sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text));

                //sum += int.Parse(grvDetail.Rows[i].Cells[4].Text);

            }
            lblTotal.Text = sum.ToString();

            
        }
        catch
        {

        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='fillAcademicYear'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            
        }
        catch
        {

        }
    }

    protected void drpAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();

       
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
                strQry = "";


                strQry = "exec [usp_FeesAssignSTD] @type='checkAnnualmstFeeExists',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@vchFeeDesc='" + txtperticular + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    FillGrid();
                    MessageBox("Record Exist Already");
                    return;
                }
                else
                {
                    strQry = "exec usp_FeesAssignSTD @type='InsertAnnualMast',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@vchFeeDesc='" + txtperticular.Text + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIP='" + GetSystemIP() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        MessageBox("Record Saved Successfully!");
                        FillGrid();
                        Clear();
                    }
                    else
                    {


                    }
                }

            }
            else
            {

                strQry = "exec [usp_FeesAssignSTD] @type='checkAnnualmstFeeExists',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@vchFeeDesc='" + txtperticular + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    FillGrid();
                    MessageBox("Record Exist Already");
                    return;
                }
               
                strQry = "exec usp_FeesAssignSTD @type='UpdateAnnualmst',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@vchFeeDesc='" + txtperticular.Text + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                //strQry = "exec usp_FeesAssignSTD @type='Update',@intFeeDetId='" + Convert.ToString(ViewState["Id"]) + "',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@vchFeeDesc='" + Convert.ToString(txtDesc.Text) + "',@dtEffFromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtEffToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    FillGrid();
                    Clear();
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
            ddlAcademiYear.ClearSelection();
           
            txtAmt.Text = "";
            txtDesc.Text = "";
            txtFrmDt.Text = "";
            txtToDt.Text = "";
            txtperticular.Text = "";
           
     
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



    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["Id"] = id;
            strQry = "exec usp_FeesAssignSTD @type='EditAnnualmstFill',@intFeeId='" + ViewState["Id"] + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtperticular.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]);
                ddlAcademiYear.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]);
                txtFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FrmDt"]);
                txtToDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Todt"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";

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
            strQry = "exec usp_FeesAssignSTD @type='DeleteAnnualmst',@intFeeId='" + id + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIP='" + GetSystemIP() + "'";
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
   
}