using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Collections.Generic;
using System.Text;

public partial class frmVideoCall : DBUtility
{
    
    string strQry = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["School_id"] == null || Convert.ToInt32(Session["School_id"]) == 0)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                Clear();
                GetStandard();                             
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/index.aspx");
        }
    }
    protected void GetStandard()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSearchStandard, strQry, "vchStandard_name", "intstandard_id");
              
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSearchStandard, strQry, "vchStandard_name", "intstandard_id");
              
            }

        }
        catch
        {

        }
        
    }    
    protected void ddlSearchStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSearchDivision();
    }
    protected void GetSearchDivision()
    {
        strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSearchStandard.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
        sBindDropDownList(ddlSearchDivision, strQry, "vchDivisionName", "intDivision_id");
       
    }
   
    public void Clear()
    {
        ddlSearchStandard.ClearSelection();
        ddlSearchDivision.ClearSelection();
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
   
    protected void btnSearchRpt_Click(object sender, EventArgs e)
    {
        if (ddlSearchStandard.SelectedValue == "---Select Standard----")
        {
            MessageBox("Please Select Standard");
            ddlSearchStandard.Focus();
            return;
        }
        if (ddlSearchDivision.SelectedValue == "---Select Division----")
        {
            MessageBox("Please Select Division");
            ddlSearchDivision.Focus();
            return;
        }
        string strUrl = "https://meet.jit.si/" + "VCLASSROOMS" + ddlSearchStandard.SelectedItem.Text.ToString().Replace(" ","")+ddlSearchDivision.SelectedItem.Text.ToString();
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strUrl + "','_blank')", true);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + strUrl + "');", true);
    }   
}