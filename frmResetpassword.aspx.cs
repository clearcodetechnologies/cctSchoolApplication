using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Data;

public partial class frmResetpassword : DBUtility
{
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    CreateRandomString(6);
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
    protected void ddlusertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            switch (ddlusertype.SelectedValue)
            {
                case "1": FillSTD();
                    break;
                case "3": FillDept();
                    break;
                case "4": FillDept();
                    break;
                case "5": FillDept();
                    break;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlSTD1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlusertype.SelectedValue == "1")
            {
                FillDIV();
                lblDIV1.Visible = true;
                ddlDIV1.Visible = true;
            }
            else
            {
                FillTeacherStaffAdmin();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlDiv1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudent();
        }
        catch (Exception ex)
        {
        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSTD1, strQry, "vchStandard_name", "intstandard_id");
            lblSTD1.Text = "Standard";
        }
        catch (Exception ex)
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV1, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV1.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@StdId='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            sBindDropDownList(ddusers, strQry, "Name", "intStudent_id");
        }
        catch
        {

        }
    }
    public void FillDept()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intUserType='" + Convert.ToString(ddlusertype.SelectedValue) + "'";
            sBindDropDownList(ddlSTD1, strQry, "vchDepartment_name", "intDepartment");
            lblDIV1.Visible = false;
            ddlDIV1.Visible = false;
            lblSTD1.Text = "Department";
        }
        catch (Exception)
        {
            MessageBox("Problem Found");
        }
    }
    public void FillTeacherStaffAdmin()
    {
        try
        {
            if (ddlusertype.SelectedValue == "3")
            {
                strQry = "exec usp_FillDropDown @type='GetTeacher',@intDepartment='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intUserType='" + Convert.ToString(ddlusertype.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddusers, strQry, "Name", "intTeacher_id");
            }
            else if (ddlusertype.SelectedValue == "4")
            {
                strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intUserType='" + Convert.ToString(ddlusertype.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddusers, strQry, "Name", "intStaff_id");
            }
            else
            {
                strQry = "exec usp_FillDropDown @type='GetAdmin',@intDept_id='" + Convert.ToString(ddlSTD1.SelectedValue) + "',@intUserType='" + Convert.ToString(ddlusertype.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sBindDropDownList(ddusers, strQry, "Name", "intAdmin_id");
            }


        }
        catch
        {
            MessageBox("Problem Found");

        }
    }
    //--- Method to check whether entered captcha is correct or not.
    protected bool ValidateForm()
    {

        bool IsValid = true;
        if (txtImg.Text != Session["RandomImgText"].ToString())
        {
            IsValid = false;
        }
        return IsValid;

    }

    protected void change_pass(object sender, EventArgs e)
    {
        try
        {
            bool status = ValidateForm();
            if (status == true)
            {
                string oldpass = Convert.ToString(txtpassword.Text);
                string confpass = Convert.ToString(TextBox4.Text);

                if (oldpass == confpass)
                {

                    if (Convert.ToString(ddlusertype.SelectedValue) != "0")
                    {
                        strQry = "Execute usp_forgetpassword @command='ResetPassword',@intUserType_id='" + ddlusertype.SelectedValue + "',@intUser_id='" + Convert.ToString(ddusers.SelectedValue) + "',@vchPassword='" + confpass + "'";
                        if (sExecuteQuery(strQry) > 0)
                        {
                            string tbl = string.Empty;
                            string intID = string.Empty;
                            switch (ddlusertype.SelectedValue)
                            {
                                case "1" : 
                                    tbl="Student_master";
                                    intID = "intStudent_id";
                                    break;
                                case "3":
                                    tbl = "tblTeacher_Master";
                                    intID = "intTeacher_id";
                                    break;
                                case "4":
                                    tbl = "tblstaff_Master";
                                    intID = "intStaff_id";
                                    break;
                                case "5":
                                    tbl = "tblAdmin_Master";
                                    intID = "intAdmin_id";
                                    break;
                            }

                            if (string.IsNullOrEmpty(tbl) || string.IsNullOrEmpty(intID))
                            {
                                MessageBox("Password Changed Successfully But Not Logged Out From All Devices ");
                            }
                            else
                            {
                                strQry = "select vchFCMToken as vchFCMToken from " + tbl + " where  intActive_flg=1 and " + intID + "='" + ddusers.SelectedValue + "'";
                                DataSet dsObj = sGetDataset(strQry);
                                string FCMToken = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFCMToken"]);
                                PushNotification(FCMToken);
                                MessageBox("Password Changed Successfully And Logged Out From All Devices ");
                            }
                            Clear();
                        }
                    }
                }
            }
            else
            {
                lblCaptchaResult.Text = "Entered Text is incorrect";
            }
            CreateRandomString(6);
        }
        catch
        {

        }
    }

    public void Clear()
    {
        try
        {
            ddlusertype.ClearSelection();
            ddlSTD1.ClearSelection();
            ddlDIV1.ClearSelection();
            ddusers.ClearSelection();
            txtpassword.Text = "";
            TextBox4.Text = "";
            txtImg.Text = "";
        }
        catch (Exception ex)
        {
        }
    }

    public void CreateRandomString(int length)
    {

        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", string.Empty);
        guidResult = guidResult.Substring(0, length);

        imgCaptcha.ImageUrl = "~/CaptchaHandler.ashx?txt=" + guidResult;
        Session["RandomImgText"] = guidResult;

    }
    private void PushNotification(string FCMToken)
    {
        try
        {
            string regId = FCMToken;
            var applicationID = "AAAAsZmGccI:APA91bGY0FQ8sl-575lKQjVf_GXQu2be7wJWLtg-2xm1388njpynAEGGSXWg_5qCA9ZrhWSUROEulyC7qP3ekWFVI5mytNtuMY0RywCXWuowP3spI91XjaGZ5gM6VPsXkBOafMVWOdJ4"; // PbojmyrmspdqkZ0pINni7DyqvhY2

            string title = "Password";
            string message = "The password is changed successfully....";
            var SENDER_ID = "762784936386";
            var value = message.Trim();
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
            Console.WriteLine(postData);
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;
            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse tResponse = tRequest.GetResponse();
            dataStream = tResponse.GetResponseStream();
            StreamReader tReader = new StreamReader(dataStream);
            String sResponseFromServer = tReader.ReadToEnd();
            //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
            //txtStream.Text = postData.ToString().Trim();
            tReader.Close();
            dataStream.Close();
            tResponse.Close();
        }
        catch (Exception ex)
        {
        }
    }
}