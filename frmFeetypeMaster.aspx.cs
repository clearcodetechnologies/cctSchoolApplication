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

public partial class frmFeetypeMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_Feetype_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            txtFrequency.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            MessageBox("Please Enter Name!");
            txtName.Focus();
            return;
        }
        if (txtFrequency.Text == "")
        {
            MessageBox("Please Enter Frequency!");
            txtName.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_Feetype_master @command='checkExist',@vchFee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Feetype Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_Feetype_master] @command='insert',@vchFee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@frequency='" + Convert.ToString(txtFrequency.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Feetype Inserted Successfully!");
                }
            }
        }
        else
        {
            //strQry = "usp_Feetype_master @command='checkExist',@vchFee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Feetype Already Exists");
            //    return;
            //}
            //else
            //{
            //    strQry = "exec [usp_Feetype_master] @command='update',@vchFee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@frequency='" + Convert.ToString(txtFrequency.Text.Trim()) + "',@intFeetype_id='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
            //    if (sExecuteQuery(strQry) != -1)
            //    {
            //        fGrid();
            //        MessageBox("Feetype Updated Successfully!");
            //        TabContainer1.ActiveTabIndex = 0;
            //        btnSubmit.Text = "Submit";
            //    }
            //}

            strQry = "exec [usp_Feetype_master] @command='update',@vchFee_Name='" + Convert.ToString(txtName.Text.Trim()) + "',@frequency='" + Convert.ToString(txtFrequency.Text.Trim()) + "',@intFeetype_id='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Feetype Updated Successfully!");
                TabContainer1.ActiveTabIndex = 0;
                btnSubmit.Text = "Submit";
            }
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intCat_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_Feetype_master @command='edit',@intFeetype_id='" + Convert.ToString(Session["intCat_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fee_Name"]);
                txtFrequency.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["frequency"]);
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
            strQry = "exec [usp_Feetype_master] @command='delete',@intFeetype_id='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Feetype Deleted Successfully!");
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