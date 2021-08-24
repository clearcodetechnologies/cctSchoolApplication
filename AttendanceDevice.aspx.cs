using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Transactions;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.Services;
using WEPIAT_CommonUtility;
using System.Net;
using System.Text;

namespace AttendanceDevice
{
    public partial class AttendanceDevice : System.Web.UI.Page
    {

        string str = "Data Source=103.255.188.128;Initial Catalog=DBESERVESHIKSHA;User Id=sa;Password=SA@Admin;Max Pool Size=5000;";
        
        private string DispString;
        private string tagString;
        int length = 0;
        string message;
        string usertypeId;
        string StudentName;
        string TeacherName;
        string GrnNo;
        string vchDesignation;
        string vchFCMToken;
        string regId1;
        string vchMobileNo;

        //#region ConnectionString
        //public string ConnectionString()
        //{
        //    return System.Configuration.ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
        //}
        //#endregion ConnectionString

        protected void Page_Load(object sender, EventArgs e)
        {
            string sRFID = Request.QueryString["param"];
            if (sRFID != null)
            {
                Response.Write(Attendance_Device(sRFID));
            }
        }

        private string Attendance_Device(string sRF_MachineValue)
        {
            string sDatetime = sRF_MachineValue.Substring(0, 14);
            string sYearDay = sDatetime.Substring(0, 4);
            string sMonthDay = sDatetime.Substring(4, 2);
            string sDateDay = sDatetime.Substring(6, 2);
            string sCurrentDate = sYearDay + "/" + sMonthDay + "/" + sDateDay;

            //SqlConnection con = new SqlConnection(ConnectionString());
            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "usp_Attendance_DeviceMaster";

            try
            {
                string dScanTime = sRF_MachineValue.Substring(0, 14);
                string iDeviceID = sRF_MachineValue.Substring(14, 4);
                string sRF_ID = sRF_MachineValue.Substring(18);
                insertData(sRF_ID);
                //string sYear = dScanTime.Substring(0, 4);
                //string sMonth = dScanTime.Substring(4, 2);
                //string sDate = dScanTime.Substring(6, 2);
                //string sHour = dScanTime.Substring(8, 2);
                //string sMin = dScanTime.Substring(10, 2);
                //string sSec = dScanTime.Substring(12, 2);

                //sqlcmd.Parameters.AddWithValue("@ID", "0");
                //sqlcmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                //sqlcmd.Parameters.AddWithValue("@DeviceID", Convert.ToInt32(iDeviceID));
                //sqlcmd.Parameters.AddWithValue("@Scan_Time", Convert.ToDateTime(sYear + "/" + sMonth + "/" + sDate + " " + sHour + ":" + sMin + ":" + sSec + ".000"));

                //SqlParameter countparameter = new SqlParameter("@OutputId", 0);
                //countparameter.Direction = ParameterDirection.Output;
                //sqlcmd.Parameters.Add(countparameter);

                //con.Open();
                //sqlcmd.Connection = con;
                //sqlcmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //sqlcmd.Dispose();
                //con.Close();
            }
            return "Successfull";
        }

        private void POST(string url, string data)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            req.Method = "POST";
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");

            req.Timeout = req.ReadWriteTimeout = 15000;

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] dataBytes = encoding.GetBytes(data);
            req.ContentLength = dataBytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(dataBytes, 0, dataBytes.Length);
            stream.Close();

            req.GetResponse();
        }

        private void insertData( string sRF_ID)
        {
             
            
            SqlConnection con = new SqlConnection(str);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Smartoffice where DeviceId='" + sRF_ID + "'and LogDatetime >= dateadd(minute, 15, LogDatetime)order BY LogDatetime DESC", con);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
               
                con.Close();
            }
            else
            {
                rd.Close();
                string title = "Message Center";
                var SENDER_ID = "592037958016";
                TimeSpan start1 = new TimeSpan(8, 0, 0); //7 o'clock
                TimeSpan start2 = new TimeSpan(9, 40, 0); //9 o'clock
                TimeSpan late1 = new TimeSpan(9, 40, 0); //7 o'clock
                TimeSpan late2 = new TimeSpan(11, 10, 0); //9 o'clock 10
                TimeSpan lunchout1 = new TimeSpan(11, 30, 0); //7 o'clock 35
                TimeSpan lunchout2 = new TimeSpan(12, 40, 0); //9 o'clock
                TimeSpan lunchin1 = new TimeSpan(12, 40, 0); //7 o'clock
                TimeSpan lunchin2 = new TimeSpan(13, 10, 0); //9 o'clock
                TimeSpan end1 = new TimeSpan(14, 30, 0); //1 o'clock
                TimeSpan end2 = new TimeSpan(16, 30, 0); //3 o'clock 16
                TimeSpan now = DateTime.Now.TimeOfDay;

                cmd = new SqlCommand("usp_getusertype", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "select");
                cmd.Parameters.AddWithValue("@tag", sRF_ID);
                //usertypeId = Convert.ToString(cmd.ExecuteScalar());
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    usertypeId = rdr["intUserType_id"].ToString();
                    StudentName = rdr["vchStudentFirst_name"].ToString();
                    TeacherName = rdr["vchFirst_name"].ToString();
                    GrnNo = rdr["intGRNo"].ToString();
                }
                rdr.Close();
                if (usertypeId == "1")
                {
                    if ((now > start1) && (now < start2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "in");
                            cmd.Parameters.AddWithValue("@intUsertype_id", "1");
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from student_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudentId_Number='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "Dear Parents, your Child" + GrnNo + " " + StudentName + " has Reached to the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();
                            con.Close();
                           
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if ((now > late1) && (now < late2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "late");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '1');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from student_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudentId_Number='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "Dear Parents, your Child " + GrnNo + " " + StudentName + " has Reached late to the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();
                            con.Close();
                           // txttag.Text = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if ((now > lunchout1) && (now < lunchout2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchout");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '1');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from student_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudentId_Number='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "Dear Parents, your Child " + GrnNo + " " + StudentName + " has left the school for lunch";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();
                            con.Close();
                           // txttag.Text = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if ((now > lunchin1) && (now < lunchin2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchin");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '1');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken, intHomephoneNo1 as vchMobileNo from student_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudentId_Number='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            string vchMobileNo = dt.Rows[0]["vchMobileNo"].ToString();

                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "Dear Parents, your Child " + GrnNo + " " + StudentName + " has reached to the school after lunch break";
                            POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();
                            con.Close();
                           // txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > end1) && (now < end2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "out");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '1');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from student_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudentId_Number is not null and intStudentId_Number <> '' and intStudentId_Number='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "Dear Parents, your Child " + GrnNo + " " + StudentName + " has left from the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();
                            con.Close();
                           // txttag.Text = string.Empty;
                        }
                        catch
                        {
                          //  //txttag.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //txttag.Text = string.Empty;
                    }
                }
                else if (usertypeId == "3")
                {
                    if ((now > start1) && (now < start2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "in");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '3');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblTeacher_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked present today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();


                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked present today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > late1) && (now < late2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "late");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '3');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblTeacher_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked late today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();


                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked late today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                           // txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchout1) && (now < lunchout2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchout");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '3');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblTeacher_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked left for lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked out for lunch";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();


                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked out for lunch";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                           // txttag.Text = string.Empty;
                        }
                        catch
                        {
                           // txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchin1) && (now < lunchin2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchin");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '3');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblTeacher_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked in after lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked in after lunch break";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();


                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked in after lunch break";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > end1) && (now < end2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "out");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '3');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblTeacher_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You left from the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is left from the school";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();

                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is left from the school";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //txttag.Text = string.Empty;
                    }
                }
                else if (usertypeId == "4")
                {
                    if ((now > start1) && (now < start2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "in");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '4');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblStaff_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked present today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked present today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > late1) && (now < late2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "late");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '4');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblStaff_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked late today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked late today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchout1) && (now < lunchout2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchout");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '4');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblStaff_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked out for lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked out for lunch break";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked out for lunch break";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchin1) && (now < lunchin2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchin");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '4');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblStaff_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked in after lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked in after lunch break";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked in after lunch break";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > end1) && (now < end2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "out");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '4');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblStaff_master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are left from the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is left from the school";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();

                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is left from the school";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //txttag.Text = string.Empty;
                    }
                }
                else if (usertypeId == "6")
                {
                    if ((now > start1) && (now < start2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "in");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '6');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblDrivermaster where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked present today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked present today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > late1) && (now < late2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "late");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '6');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblDrivermaster where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked present today";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked late today";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked late today";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchout1) && (now < lunchout2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchout");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '6');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblDrivermaster where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked out for lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked out for lunch";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked out for lunch";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > lunchin1) && (now < lunchin2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "lunchin");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '6');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblDrivermaster where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are marked in after lunch break";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is marked in after lunch Break";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();
                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is marked in after lunch Break";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else if ((now > end1) && (now < end2))
                    {
                        try
                        {
                            cmd = new SqlCommand("insert into Smartoffice(Employeecode,LogDatetime,RFID,DeviceId,SchoolId,MsgFlag,YearId,inout,intUsertype_id) values (@Employeecode,@LogDatetime,@RF_ID,@DeviceID,@SchoolId,@MsgFlag,@YearId,@inout,@intUsertype_id)", con);

                            cmd.Parameters.AddWithValue("@Employeecode", sRF_ID);
                            cmd.Parameters.AddWithValue("@LogDatetime", DateTime.Now);
                            cmd.Parameters.AddWithValue("@RF_ID", sRF_ID);
                            cmd.Parameters.AddWithValue("@DeviceId", sRF_ID);
                            cmd.Parameters.AddWithValue("@SchoolId", '5');
                            cmd.Parameters.AddWithValue("@MsgFlag", '1');
                            cmd.Parameters.AddWithValue("@YearId", '1');
                            cmd.Parameters.AddWithValue("@inout", "out");
                            cmd.Parameters.AddWithValue("@intUsertype_id", '6');
                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Student added");
                            Console.WriteLine(sRF_ID);
                            SqlConnection conn = new SqlConnection();
                            conn = new SqlConnection(str);
                            string SqlString = "";
                            SqlString = "select isnull(vchFCMToken,0) as vchFCMToken from tblDrivermaster where vchFCMToken IS NOT NULL and vchFCMToken<>'' and vchActiveStatus is not null and vchActiveStatus <> '' and vchActiveStatus='" + sRF_ID + "' ";
                            SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            string regId = dt.Rows[0]["vchFCMToken"].ToString();
                            var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                            message = "You are left from the school";
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
                            tReader.Close();
                            dataStream.Close();
                            tResponse.Close();

                            //////
                            cmd = new SqlCommand("select isnull(vchFCMToken, 0) as vchFCMToken, intDesignation_id, intMobileNo from tbladmin_master where vchFCMToken IS NOT NULL and vchFCMToken <> ''  and intschool_id=5 and intActive_flg = 1", con);
                            SqlDataReader rdr1 = cmd.ExecuteReader();

                            while (rdr1.Read())
                            {
                                vchFCMToken = rdr1["vchFCMToken"].ToString();
                                regId1 = rdr1["vchFCMToken"].ToString();
                                vchDesignation = rdr1["intDesignation_id"].ToString();
                                vchMobileNo = rdr1["intMobileNo"].ToString();
                                var applicationID1 = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                                message = "" + TeacherName + " is left from the school";
                                var value1 = message.Trim();
                                WebRequest tRequest1;
                                tRequest1 = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest1.Method = "post";
                                tRequest1.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                                tRequest1.Headers.Add(string.Format("Authorization: key={0}", applicationID1));
                                tRequest1.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                                string postData1 = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                    + value1 + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId1 + "&data.title=" + title + "";
                                Console.WriteLine(postData1);
                                Byte[] byteArray1 = Encoding.UTF8.GetBytes(postData1);
                                tRequest1.ContentLength = byteArray1.Length;
                                Stream dataStream1 = tRequest1.GetRequestStream();
                                dataStream1.Write(byteArray1, 0, byteArray1.Length);
                                dataStream1.Close();
                                WebResponse tResponse1 = tRequest1.GetResponse();
                                dataStream1 = tResponse1.GetResponseStream();
                                StreamReader tReader1 = new StreamReader(dataStream1);
                                String sResponseFromServer1 = tReader1.ReadToEnd();
                                tReader1.Close();
                                dataStream1.Close();
                                tResponse1.Close();

                            }
                            if (vchDesignation == "13")
                            {
                                message = "" + TeacherName + " is left from the school";
                                //POST("http://VClassroomsociety.com/submitsms.jsp?user=Efficas&key=1d9796cef6XX&mobile=" + to + "&message=" + message + "&senderid=AROHAN&accusage=1", "");
                                POST("http://alerts.justnsms.com/api/web2sms.php?workingkey=A1f82622e8e28d6c8e63ebc1543439e25&sender=AROHAN&to=" + vchMobileNo.Trim() + "&message=" + message.Trim() + "&format=json&custom=1,2&flash=0&unicode=1", "");
                            }
                            con.Close();
                            //txttag.Text = string.Empty;
                        }
                        catch
                        {
                            //txttag.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //txttag.Text = string.Empty;
                    }
                }
                else
                {
                    //txttag.Text = string.Empty;
                }
               // timer1.Stop();
            }
        
    }

        
    }
}