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

using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

public partial class frmChanegePassword: DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //--- You can increase or decrease numbers 
            //--- to increase or decrease captcha strings.
            CreateRandomString(6);

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
    public void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    
    }
   
    protected void change_pass(object sender, EventArgs e)
    {
        try
        {
             bool status = ValidateForm();
             if (status == true)
             {
                 //string usernm = Convert.ToString(TextBox1.Text);
                 string oldpass = Convert.ToString(TextBox2.Text);
                 //string newpass = Convert.ToString(TextBox3.Text);
                 string confpass = Convert.ToString(TextBox4.Text);

                 //DataSet dsObj = new DataSet();

                 //string strQry = "exec usp_log @command='ChangePassCheck',@vchUser_name='" + usernm + "',@vchOldPassword='" + oldpass + "'";
                 //dsObj = sGetDataset(strQry);
                 //if (dsObj.Tables[0].Rows.Count > 0)
                 //{
                 //    string intid = Convert.ToString(dsObj.Tables[0].Rows[0]["intID"]);

                 //    string strQry1 = "Execute dbo.usp_log @command='ChangePass',@intid='" + intid + "',@vchNewPassword='" + confpass + "'";
                 //    if (sExecuteQuery(strQry1) != -1)
                 //    {
                 //        MessageBox("Password Changed Successfully ");
                 //        Clear();
                 //    }
                 //}
                 //else
                 //{
                 //    MessageBox("Username or Password does not Exit ");
                 //    Clear();
                 //}


                 if (Convert.ToString(Session["strUserType"]) == "1")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassStudent',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "2")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassParent',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "3")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassTeacher',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "4")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassStaff',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "5")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassAdmin',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     //if (sExecuteQuery(strQry) != -1)
                     //{
                     int x = sExecuteQuery(strQry);
                     if (x != 0)
                     {
                         strQry = "select vchFCMToken as vchFCMToken from tblAdmin_Master where  intActive_flg=1 and intAdmin_id='" + Convert.ToString(Session["User_id"]) + "'";
                         dsObj = sGetDataset(strQry);
                         string FCMToken = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFCMToken"]);
                         PushNotification(FCMToken);
                         MessageBox("Password Changed Successfully ");
                         Clear();
                         Response.Redirect("Login.aspx");
                     }
                     else
                     {
                         MessageBox("Please Enter Correct Password!");
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
    //protected void btnclr_Click(object sender, EventArgs e)
    //{
    //    Clear();
    //}

    protected void PushNotification(string FCMToken)
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
