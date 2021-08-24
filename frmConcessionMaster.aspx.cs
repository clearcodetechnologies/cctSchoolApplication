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

public partial class frmConcessionMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            if(rbPer.Checked==true)
            {
                lblNamePer.Visible = true;
                txtNamePer.Visible = true;
            }
            

            lblNameAmt.Visible = false;
            txtNameAmt.Visible = false;
        }
    }


    protected void fGrid()
    {
        strQry = "usp_concession_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            txtNamePer.Text = "";
            txtNameAmt.Text = "";
          
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void rbPer_CheckedChanged(object sender, System.EventArgs e)
    {
        lblNamePer.Visible = true;
        txtNamePer.Visible = true;

        lblNameAmt.Visible = false;
        txtNameAmt.Visible = false;
        txtNameAmt.Text = "";

        rbPer.Checked = true;
        rbAmt.Checked = false;

    }
    protected void rbAmt_CheckedChanged(object sender, System.EventArgs e)
    {
        lblNamePer.Visible = false;
        txtNamePer.Visible = false;
        txtNamePer.Text = "";

        lblNameAmt.Visible = true;
        txtNameAmt.Visible = true;
        rbPer.Checked = false;
        rbAmt.Checked = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            MessageBox("Please Insert Concession Name!");
            txtName.Focus();
            return;
        }
        if (rbPer.Checked == true)
        {
            if (txtNamePer.Text == "")
            {
                MessageBox("Please Enter Concession Per!");
                txtNamePer.Focus();
                return;
            }
        }
        if (rbAmt.Checked == true)
        {
            if (txtNameAmt.Text == "")
            {
                MessageBox("Please Enter Concession Amt!");
                txtNameAmt.Focus();
                return;
            }
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_concession_master @command='checkExist',@vchConcession_name='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Concession Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_concession_master] @command='insert',@vchConcession_name='" + Convert.ToString(txtName.Text.Trim()) + "',@vchConcession_per='" + Convert.ToString(txtNamePer.Text.Trim()) + "',@vchConcession_amt='" + Convert.ToString(txtNameAmt.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Concession Inserted Successfully!");
                }
            }
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

        
                strQry = "exec [usp_concession_master] @command='update',@vchConcession_name='" + Convert.ToString(txtName.Text.Trim()) + "',@vchConcession_per='" + Convert.ToString(txtNamePer.Text.Trim()) + "',@vchConcession_amt='" + Convert.ToString(txtNameAmt.Text.Trim()) + "',@intConcession_id ='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Concession Updated Successfully!");
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
            strQry = "exec usp_concession_master @command='edit',@intConcession_id='" + Convert.ToString(Session["intCat_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchConcession_name"]);

              
                txtNamePer.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchConcession_per"]);
                if (txtNamePer.Text != "")
                {
                    rbPer.Checked = true;
                    rbAmt.Checked = false;
                    txtNamePer.Visible = true;
                    txtNameAmt.Visible = false;
                }
                txtNameAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchConcession_amt"]);
                if (txtNameAmt.Text != "")
                {
                    rbPer.Checked = false;
                    rbAmt.Checked = true;
                    txtNamePer.Visible = false;
                    txtNameAmt.Visible = true;
                }
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
            strQry = "exec [usp_concession_master] @command='delete',@intConcession_id='" + Convert.ToString(Session["intCat_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "'";
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