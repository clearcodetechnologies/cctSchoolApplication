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


public partial class frmSubjectCatMaster : DBUtility
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
        try
        {
            strQry = "usp_SubjectCategoryMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                txtName.Text = "";
            }
        }
        catch
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            MessageBox("Please Insert Standard Name!");
            txtName.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_SubjectCategoryMaster @command='checkExist',@vchSubcat_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Subject Category Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SubjectCategoryMaster] @command='insert',@vchSubcat_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Subject Category Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_SubjectCategoryMaster @command='checkExist',@vchSubcat_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Standard Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SubjectCategoryMaster] @command='update',@vchSubcat_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSubcat_id='" + Convert.ToString(Session["SubjectCatID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Subject Category Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["SubjectCatID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_SubjectCategoryMaster @command='edit',@intSubcat_id='" + Convert.ToString(Session["SubjectCatID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSubcat_name"]);
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
            Session["SubjectCatID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_SubjectCategoryMaster] @command='delete',@intSubcat_id='" + Convert.ToString(Session["SubjectCatID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Subject Category Deleted Successfully!");
            }
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
}