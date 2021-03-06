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

public partial class frmAcademicYearMaster : DBUtility
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
        strQry = "usp_AcademicYearMaster @command='select'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
            //drpStatus.Text = "";
            
        }
    }
    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    if (txtName.Text == "")
    //    {
    //        MessageBox("Please Enter Academic Year!");
    //        txtName.Focus();
    //        return;
    //    }
    //    if (drpStatus.SelectedValue == "0")
    //    {
    //        MessageBox("Please Select Status!");
    //        txtName.Focus();
    //        return;
    //    }
    //    if (btnSubmit.Text == "Submit")
    //    {
    //        strQry = "usp_AcademicYearMaster @command='checkExist',@AcademicYear='" + Convert.ToString(txtName.Text.Trim()) + "',@status='" + Convert.ToString(drpStatus.Text.Trim()) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            MessageBox("Record Already Exists");
    //            return;
    //        }
    //        else
    //        {
    //            strQry = "exec [usp_AcademicYearMaster] @command='insert',@AcademicYear='" + Convert.ToString(txtName.Text.Trim()) + "',@status='" + Convert.ToString(drpStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
    //            if (sExecuteQuery(strQry) != -1)
    //            {
    //                fGrid();
    //                MessageBox("Record Inserted Successfully!");
    //            }
    //        }
    //    }
    //    else
    //    {
    //        strQry = "usp_AcademicYearMaster @command='checkExist',@AcademicYear='" + Convert.ToString(txtName.Text.Trim()) + "',@status='" + Convert.ToString(drpStatus.Text.Trim()) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            MessageBox("Record Already Exists");
    //            return;
    //        }
    //        else
    //        {
    //            strQry = "exec [usp_AcademicYearMaster] @command='update',@AcademicYear='" + Convert.ToString(txtName.Text.Trim()) + "',@status='" + Convert.ToString(drpStatus.Text.Trim()) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
    //            if (sExecuteQuery(strQry) != -1)
    //            {
    //                fGrid();
    //                MessageBox("Record Updated Successfully!");
    //                TabContainer1.ActiveTabIndex = 0;
    //                btnSubmit.Text = "Submit";
    //            }
    //        }
    //    }
    //}
    //protected void btnClear_Click(object sender, EventArgs e)
    //{
    //    txtName.Text = "";
    //    drpStatus.Text = "";
    //    btnSubmit.Text = "Submit";
    //}
    //protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {
    //        Session["AcademicID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
    //        strQry = "";
    //        strQry = "exec usp_AcademicYearMaster @command='edit',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AcademicYear"]);
    //            drpStatus.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["status"]);
    //            TabContainer1.ActiveTabIndex = 1;
    //            btnSubmit.Text = "Update";
    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
    //protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        Session["AcademicID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
    //        strQry = "";
    //        strQry = "exec [usp_AcademicYearMaster] @command='delete',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
    //        if (sExecuteQuery(strQry) != -1)
    //        {
    //            fGrid();
    //            MessageBox("Academic Year Deleted Successfully!");
    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
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