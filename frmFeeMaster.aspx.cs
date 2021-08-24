using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmFeeMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillFeeType();
            FillStandard();
            FillStandardSearch();
            fGrid();
        }
    }
    public void FillFeeType()
    {

        try
        {
            strQry = "";
            strQry = "exec usp_Fee_master @command='GetFeetYPE',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlFeeType, strQry, "Fee_Name", "intFeetype_id");
            ddlFeeType.SelectedValue = "1";

        }
        catch(Exception ex)
        {
            

        }
    }
    public void FillStandardSearch()
    {

        try
        {
            strQry = "";
            strQry = "exec [usp_Feetype_master] @command='selectStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandardSearch, strQry, "vchStandard_name", "intstandard_id");
            ddlStandardSearch.SelectedValue = "1";

        }
        catch
        {

        }
    }

    public void FillStandard()
    {

        try
        {
            strQry = "";
            
               strQry = "exec [usp_Feetype_master] @command='selectStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, strQry, "vchStandard_name", "intstandard_id");
            ddlStandard.SelectedValue = "1";

        }
        catch
        {

        }
    }

   
    //protected void fGrid()
    //{
    //    strQry = "usp_Fee_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //    dsObj = sGetDataset(strQry);
    //    if (dsObj != null)
    //    {
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            grvDetail.DataSource = dsObj;
    //            grvDetail.DataBind();
    //            Clear();

    //        }
    //    }
    //}
    protected void fGrid()
    {

        if (ddlStandardSearch.SelectedValue == "0")
        {
            strQry = "usp_Fee_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id=0";

        }
        else
        {
            strQry = "usp_Fee_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(ddlStandardSearch.SelectedValue) + "'";

        }
        dsObj = sGetDataset(strQry);
        if (dsObj != null)
        {
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                Clear();

            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                MessageBox("No Data Found!");
            }
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            MessageBox("No Data Found!");
        }
    }

    public void Clear()
    {
        txtName.Text = "";
        txtDueDate.Text = "";
        txtDueTilldate.Text = "";
        ddlStandard.SelectedValue = "0";
        ddlFeeType.SelectedValue = "0";
        txtFee.Text = "";
    }
    protected void rbYES_CheckedChanged(object sender, System.EventArgs e)
    {
        rbNo.Checked = false;
        rbYES.Checked = true;
    }
    protected void rbNo_CheckedChanged(object sender, System.EventArgs e)
    {
        rbYES.Checked = false;
        rbNo.Checked = true;
    }
    protected void ddlStandardSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGrid();
    }
    public bool Validation()
    {
        bool Isvalid = true;
        if (txtName.Text == "")
        {
            MessageBox("Please Enter Fee Name!");
            txtName.Focus();
            Isvalid = false;
            return Isvalid;
        }
        if (ddlFeeType.SelectedValue == "0")
        {
            MessageBox("Select FeeType!");
            ddlFeeType.Focus();
            Isvalid = false;
            return Isvalid;
        }
        if (txtDueDate.Text=="")
        {
            MessageBox("Please Enter Due Date!");
            txtDueDate.Focus();
            Isvalid = false;
            return Isvalid;
        }
        if (txtDueTilldate.Text == "")
        {
            MessageBox("Please Enter Till Due Date!");
            txtDueTilldate.Focus();
            Isvalid = false;
            return Isvalid;
        }
        if (ddlStandard.SelectedValue == "0")
        {
            MessageBox("Select Standard!");
            ddlStandard.Focus();
            Isvalid = false;
            return Isvalid;
        }
        if (txtFee.Text == "")
        {
            MessageBox("Please Enter Fee Amount!");
            txtFee.Focus();
            Isvalid = false;
            return Isvalid;
        }
        return Isvalid;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (txtName.Text == "")
        //{
        //    MessageBox("Please Insert Concession Name!");
        //    txtName.Focus();
        //    return;
        //}
        //if (txtNamePer.Text == "")
        //{
        //    MessageBox("Please Insert Concession Per!");
        //    txtNamePer.Focus();
        //    return;
        //}
        //if (txtNameAmt.Text == "")
        //{
        //    MessageBox("Please Insert Concession Amt!");
        //    txtNameAmt.Focus();
        //    return;
        //}

        if(Validation()==false)
        {
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            //strQry = "usp_Fee_master @command='checkExist',@intFeetype_id='" + Convert.ToString(ddlFeeType.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    string strval = dsObj.Tables[0].Rows[0]["Column1"].ToString();
            //    if (strval == "No")
            //    {

            strQry = "usp_Fee_master @command='checkExist',@Fee_Name='" + txtName.Text + "',@intFeetype_id='" + Convert.ToString(ddlFeeType.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count == 0)
            {
                    int rbValue = 0;
                    if (rbYES.Checked)
                    {
                        rbValue = 1;

                    }
                    else
                    {
                        rbValue = 0;


                    }
                    strQry = "exec [usp_Fee_master] @command='insert',@Fee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@intFeetype_id='" + Convert.ToString(ddlFeeType.SelectedValue) + "',@dtstart_date='" + Convert.ToDateTime(txtDueDate.Text).ToString("MM/dd/yyyy") + "',@dtduetill_date='" + Convert.ToDateTime(txtDueTilldate.Text).ToString("MM/dd/yyyy") + "',@vchconssion='" + Convert.ToString(rbValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@vchfee='" + Convert.ToString(txtFee.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        fGrid();
                        MessageBox("Fee Master Inserted Successfully!");
                        Clear();
                    }

            }
            else
            {
                MessageBox("Concession Already Exists");
                return;
            }

            //    }
            //    else
            //    {
            //        MessageBox("Concession Already Exists");
            //        return;
            //    }
            //}
            //else
            //{
            //    int rbValue = 0;
            //    if(rbYES.Checked)
            //    {
            //        rbValue = 1;

            //    }
            //    else
            //    {
            //        rbValue = 0;


            //    }
            //    strQry = "exec [usp_Fee_master] @command='insert',@Fee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@intFeetype_id='" + Convert.ToString(ddlFeeType.SelectedValue) + "',@dtstart_date='" + Convert.ToDateTime(txtDueDate.Text).ToString("MM/dd/yyyy") + "',@dtduetill_date='" + Convert.ToDateTime(txtDueTilldate.Text).ToString("MM/dd/yyyy") + "',@vchconssion='" + Convert.ToString(rbValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@vchfee='" + Convert.ToString(txtFee.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "'";
            //    if (sExecuteQuery(strQry) != -1)
            //    {
            //        fGrid();
            //        MessageBox("Fee Master Inserted Successfully!");
            //        Clear();
            //    }
            //}
        }
        else
        {
            //strQry = "usp_concession_master @command='checkExist',@vchConcession_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Concession Already Exists");
            //    return;
            //}
            //else
            //{

            int rbValue = 0;
            if (rbYES.Checked)
            {
                rbValue = 1;

            }
            else
            {
                rbValue = 0;


            }
            strQry = "exec [usp_Fee_master] @command='update',@Fee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@intFeetype_id='" + Convert.ToString(ddlFeeType.SelectedValue) + "',@dtstart_date='" + Convert.ToDateTime(txtDueDate.Text).ToString("MM/dd/yyyy") + "',@dtduetill_date='" + Convert.ToDateTime(txtDueTilldate.Text).ToString("MM/dd/yyyy") + "',@vchconssion='" + Convert.ToString(rbValue) + "',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@vchfee='" + Convert.ToString(txtFee.Text) + "',@intFeemaster_id ='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Fee Master Updated Successfully!");
                Clear();
                TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            //}
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intCat_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_Fee_master @command='edit',@intFeemaster_id='" + Convert.ToString(Session["intCat_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fee_Name"]);
                ddlFeeType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intFeetype_id"]);
                txtDueDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtstart_date"]);
                txtDueTilldate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtduetill_date"]);
                int rbValue= Convert.ToInt32(dsObj.Tables[0].Rows[0]["vchconssion"]);
                if (rbValue == 1)
                {
                    rbYES.Checked = true;
                    rbNo.Checked = false;
                }
                else
                {
                    rbNo.Checked = true;
                    rbYES.Checked = false;
                }
                ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                txtFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfee"]);


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
            Session["intCat_Id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_Fee_master] @command='delete',@intFeemaster_id='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Concession Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
}