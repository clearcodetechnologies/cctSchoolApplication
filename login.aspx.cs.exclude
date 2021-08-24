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

public partial class login : System.Web.UI.Page
{
    string strUserType = "";
    DataSet dsObj = new DataSet();
    DataSet dsObjSC = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    SqlDataAdapter daObja = new SqlDataAdapter();
    SqlDataAdapter daObjSC = new SqlDataAdapter();
    DataSet dsObj1 = new DataSet();
    SqlDataAdapter daObj1 = new SqlDataAdapter();
    DataSet dsObja = new DataSet();
    string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
    SqlConnection sqlcon;
    SqlCommand sqlcom = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["School_id"] = "";
            Session["UserType_id"] = "";
            Session["User_id"] = "";
            Session["Student_id"] = "";
            Session["Standard_id"] = "";
            Session["Division_id"] = "";
            Session["AcademicID"] = "";
            fillSchool();
        }
    }
    protected void drpSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpSchool.SelectedValue != "0" && drpSchool.SelectedItem.Text != "---Select School----")
        {
            string strSC = "exec [usp_usermaster] @command='selectShoolCollegeType',@intSchool_id='" + Convert.ToString(drpSchool.SelectedValue.Trim()) + "'";
            daObjSC = new SqlDataAdapter(strSC, strCOn);
            daObjSC.Fill(dsObjSC);
            if (dsObjSC.Tables[0].Rows.Count > 0)
            {
                Session["schoolCollegeType"] = Convert.ToString(dsObjSC.Tables[0].Rows[0]["intType"]);
            }
            if (Convert.ToString(Session["schoolCollegeType"]) == "School")
            {
                fillRole();
                FillAcademicYear();
            }
            else if (Convert.ToString(Session["schoolCollegeType"]) == "College")
            {
                fillRole();
                FillAcademicYear();
            }
            else if (Convert.ToString(Session["schoolCollegeType"]) == "Institute")
            {
                fillRole();
                FillAcademicYear();
            }
            else
            {
                fillRole();
                FillAcademicYear();
            } 
        }
    }
    protected void fillSchool()
    {
        try
        {

            string strQry1 = "";
            strQry1 = "exec [usp_usermaster] @command='fillSchool',@intSchool_id='1'";
            daObj1 = new SqlDataAdapter(strQry1, strCOn);
            daObj1.Fill(dsObj1);
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                drpSchool.DataTextField = "vchSchool_name";
                drpSchool.DataValueField = "intSchool_id";
                drpSchool.DataSource = dsObj1;
                drpSchool.DataBind();
                drpSchool.Items.Insert(0, "---Select School----");
            }
            else
            {
                drpSchool.DataSource = dsObj1;
                drpSchool.DataBind();
                drpSchool.Items.Insert(0, "---Select School----");
            }
        }
        catch
        {
        }

    }
    public void FillAcademicYear()
    {
        try
        {
            string strQrya = "";
            strQrya = "exec usp_usermaster @command='FillYear',@intSchool_Id='" + Convert.ToString(drpSchool.SelectedValue) + "'";
            daObja = new SqlDataAdapter(strQrya, strCOn);
            daObja.Fill(dsObja);
            if (dsObja.Tables[0].Rows.Count > 0)
            {
                ddlAcademiYr.DataTextField = "AcademicYear";
                ddlAcademiYr.DataValueField = "intAcademic_id";

                ddlAcademiYr.DataSource = dsObja;
                ddlAcademiYr.DataBind();
                ddlAcademiYr.Items.Insert(0, "---Academic Year----");
            }
            else
            {
                ddlAcademiYr.DataSource = dsObja;
                ddlAcademiYr.DataBind();
                ddlAcademiYr.Items.Insert(0, "---Academic Year----");
            }
        }
        catch
        {

        }
    }
    protected void fillRole()
    {
        string strQry = "";
        strQry = "exec [usp_usermaster] @command='fillRole',@intSchool_id='" + Convert.ToString(drpSchool.SelectedValue.Trim()) + "'";
        daObj = new SqlDataAdapter(strQry, strCOn);
        daObj.Fill(dsObj);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpUserType.DataTextField = "vchRole";
            drpUserType.DataValueField = "intRole_Id";

            drpUserType.DataSource = dsObj;
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, "---Select Role----");
        }
        else
        {
            drpUserType.DataSource = dsObj;
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, "---Select Role----");
        }
    }
       
    public static string GetSystemIP()
    {
        string retStr = "";
        try
        {
            string myHost = System.Net.Dns.GetHostName();
            retStr = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            string clientIPAddress = Convert.ToString(System.Net.Dns.GetHostAddresses(myHost).GetValue(0));
            retStr = retStr + ">>" + clientIPAddress;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retStr;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strQry = "";
        String usertyrpe_id="";
        HttpContext.Current.Session["strUserType"] = Convert.ToString(drpUserType.SelectedValue.Trim());
        Session["YearName"] = Convert.ToString(ddlAcademiYr.SelectedItem.Text.Trim());
        Session["AcademicID"] = Convert.ToString(ddlAcademiYr.SelectedValue.Trim());
        Session["Sess_User_Name"] = Convert.ToString(txtUserName.Text.Trim());
        strQry = "exec [usp_usermaster] @command='select',@username='" + Convert.ToString(txtUserName.Text.Trim()) + "',@password='" + Convert.ToString(txtPassword.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(drpSchool.SelectedValue.Trim()) + "',@usertype='" + Convert.ToString(drpUserType.SelectedValue.Trim()) + "'";
        daObj = new SqlDataAdapter(strQry, strCOn);
        daObj.Fill(dsObj);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["School_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intSchool_id"]);
            Session["UserType_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            usertyrpe_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            if (usertyrpe_id == "1" )
            {
                Session["Student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            }
            else if (usertyrpe_id == "2")
            {
                Session["Student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            }
            if (usertyrpe_id == "5")
            {
                try
                {
                    Session["DepartmentID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                }
                catch
                {
                }
            }
            else
            {
               
            }

            Session["User_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
            //Session["AcademicID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
            Session["Transporter"] = "1";
            Session["usertype"] = "1";
            Session["userid"] = "1";
            Session["UserName"] = "admin";
            Session["LastName"] = "admin";
            Session["intOrg_id"] = "1";
            Session["IP"] = GetSystemIP();
            sqlcon = new SqlConnection(strCOn);

            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.CommandText = "usp_loginlogs";
            sqlcom.Parameters.Add("@command", SqlDbType.VarChar).Value = Convert.ToString("Insert");
            sqlcom.Parameters.Add("@intUserType_id", SqlDbType.VarChar).Value = Convert.ToString(Session["UserType_id"]);
            sqlcom.Parameters.Add("@intUser_id", SqlDbType.VarChar).Value = Convert.ToString(Session["User_id"]);
            sqlcom.Parameters.Add("@intStandard_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Standard_id"]);
            sqlcom.Parameters.Add("@intDivision_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Division_id"]);
            sqlcom.Parameters.Add("@intAcademicYear_id", SqlDbType.VarChar).Value = Convert.ToString(Session["AcademicID"]);
            sqlcom.Parameters.Add("@vchIPaddress", SqlDbType.VarChar).Value = Convert.ToString(Session["IP"]);
            sqlcom.Parameters.Add("@intSchool_id", SqlDbType.VarChar).Value = Convert.ToString(Session["School_id"]);
            sqlcom.Parameters.Add("@intStudent_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Student_id"]);
            sqlcom.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlcom.Connection = sqlcon;
            try
            {
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                Session["session_id"] = sqlcom.Parameters["@id"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (Convert.ToString(Session["Student_id"]) == "374")
            {
                Response.Redirect("frmBusTracking.aspx", false);
            }
            else
            {
                if (Convert.ToString(Session["UserType_id"]) == "5")
                {

                    if (txtUserName.Text == "pulak")
                    {
                        Response.Redirect("frmRegistrationSearch.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("AdminDB.aspx", false);
                    }
                }
                else if (Convert.ToString(Session["UserType_id"]) == "3")
                {
                    Response.Redirect("TeacherDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "4")
                {
                    Response.Redirect("StaffDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
                {
                    Response.Redirect("studentDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "10")
                {
                    Response.Redirect("AdminDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "9")
                {
                    Response.Redirect("StaffDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "8")
                {
                    Response.Redirect("TeacherDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "6" || Convert.ToString(Session["UserType_id"]) == "7")
                {
                    Response.Redirect("studentDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "15")
                {
                    Response.Redirect("AdminDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "14")
                {
                    Response.Redirect("StaffDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "13")
                {
                    Response.Redirect("TeacherDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "11" || Convert.ToString(Session["UserType_id"]) == "12")
                {
                    Response.Redirect("studentDB.aspx", false);
                }
                else
                {
                    Response.Redirect("frmAttendance.aspx", false);
                }
            }

        }
        else
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            string msg = "Invalid Authentication";
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
    }

}