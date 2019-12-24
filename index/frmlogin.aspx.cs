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

public partial class frmlogin : DBUtility
{
    string strUserType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["usertype"] != null)
            {
                Session["strUserType"] = Convert.ToString(Request.QueryString["usertype"].ToString());

                if (Convert.ToString(Session["strUserType"]) == "student")
                {
                    strUserType = "1";
                    HttpContext.Current.Session["strUserType"] = "1";
                }
                else if (Convert.ToString(Session["strUserType"]) == "parents")
                {
                    strUserType = "2";
                    HttpContext.Current.Session["strUserType"] = "2";
                }
                else if (Convert.ToString(Session["strUserType"]) == "teacher")
                {
                    strUserType = "3";
                    HttpContext.Current.Session["strUserType"] = "3";
                }
                else if (Convert.ToString(Session["strUserType"]) == "admin")
                {
                    strUserType = "5";
                    HttpContext.Current.Session["strUserType"] = "5";
                }
            }
            
        }
    }
    [System.Web.Services.WebMethod]
    public static string UserNamePassword(string name, string password)
    {
        
        string strQry = "";
        DataSet dsObj = new DataSet();
        string strname = name;
        string strpassword = password;

        strQry = "exec [usp_usermaster] @command='select',@username='" + Convert.ToString(name) + "',@password='" + Convert.ToString(password) + "' , @intSchool_id='1',@usertype='" + Convert.ToString(HttpContext.Current.Session["strUserType"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Session["School_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intSchool_id"]);
            HttpContext.Current.Session["UserType_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            HttpContext.Current.Session["User_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
            HttpContext.Current.Session["Student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
            HttpContext.Current.Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
            HttpContext.Current.Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            HttpContext.Current.Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);

            return "false";

        }
        else
        {
            return "true";
        }
        //HttpContext.Current.Response.Redirect("../frmstudentTravelDet.aspx", false);
        
        
    }
}
