using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;
public partial class frmGallery : DBUtility
{
    SqlConnection con;
    SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    DataSet dsObj = new DataSet();
    string filepath = ConfigurationManager.AppSettings["ImageLink"];
    string fileUploadPath = ConfigurationManager.AppSettings["ImageUploadPath"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            fGrid();
            filldata();
        }
    }

    protected void fGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Files", conn))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //dt?.Rows?.Count>0
                if (dt.Rows.Count > 0)
                {
                    gvImages.DataSource = dt;
                    gvImages.DataBind();
                }

            }
        }

    }
    protected void filldata()
    {
        string query1 = "Select *From tblGallaryEventMaster where intactive_flg=1";
        bool st = sBindDropDownList(ddlCategory, query1, "EventName", "Id");


    }

    protected void Upload(object sender, EventArgs e)
    {
        try
        {

            if (ddlCategory.SelectedIndex == 0)
            {
                MessageBox("Please Select Category.");
                return;
            }
            if (FileUpload1.HasFile)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString);
                con.Open();
                da = new SqlDataAdapter("SELECT * FROM Files Where GalleryId = " + ddlCategory.SelectedValue + "", con);
                ds = new DataSet();
                da.Fill(ds);
                int GalleryCount = Convert.ToInt32(ds.Tables[0].Rows.Count);

                if (GalleryCount <= 25)
                {

                    HttpFileCollection fileCollectionUpload = Request.Files;

                    if (fileCollectionUpload.Count <= 4)
                    {
                        for (int i = 0; i < fileCollectionUpload.Count; i++)
                        {
                            string filename = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                            //FileUpload1.SaveAs("C:/inetpub/wwwroot/Rajasthan/TraffordSchool/TraffordSchool/image/" + filename);
                            //D:\Application Live\NPST\Uttarakhand\SKPSchool\SKPSchool\image
                            //FileUpload1.SaveAs("D:/Application Live/NPST/Uttarakhand/SKSchoolApi/SKSchoolApi/image/" + filename);
                            FileUpload1.SaveAs(fileUploadPath + filename);
                            HttpPostedFile uploadfile = fileCollectionUpload[i];
                            string strPage1FileName = Path.GetFileName(uploadfile.FileName).ToString();
                            string File1Ext = System.IO.Path.GetExtension(uploadfile.FileName);

                            con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString);
                            con.Open();
                            cmd = new SqlCommand("insert into Files (Name,Path,EventDescription,Uploadedfrom,Filetype,intSchool_id,btActiveFlg,intAcademic_id, GalleryId) values(@Name,@Path,@EventDescription,@Uploadedfrom,@Filetype,@intSchool_id,@btActiveFlg,@intAcademic_id, @GalleryId)", con);
                            cmd.Parameters.AddWithValue("@Name", strPage1FileName);
                            //cmd.Parameters.AddWithValue("@Path", "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + strPage1FileName);
                            //cmd.Parameters.AddWithValue("@Path", "http://eserveshiksha.co.in/SKPSchoolApi/image/" + strPage1FileName);
                            
                            //cmd.Parameters.AddWithValue("@Path", "http://VClassrooms.com/SKPAPI/IMAGE/" + strPage1FileName);

                            cmd.Parameters.AddWithValue("@Path", filepath + strPage1FileName);
                            cmd.Parameters.AddWithValue("@EventDescription", txtEvent.Text);
                            cmd.Parameters.AddWithValue("@Uploadedfrom", SqlDbType.VarChar).Value = "web";
                            cmd.Parameters.AddWithValue("@Filetype", SqlDbType.VarChar).Value = "gallery";
                            cmd.Parameters.AddWithValue("@intSchool_id", Session["School_id"].ToString());
                            cmd.Parameters.AddWithValue("@btActiveFlg", 1);
                            cmd.Parameters.AddWithValue("@intAcademic_id", Session["AcademicID"].ToString());
                            cmd.Parameters.AddWithValue("@GalleryId", ddlCategory.SelectedValue);
                            cmd.ExecuteNonQuery();
                            da = new SqlDataAdapter("select * from Files Order By id DESC", con);
                            ds = new DataSet();
                            da.Fill(ds);
                            gvImages.DataSource = ds;
                            gvImages.DataBind();

                            MessageBox("Image Uploaded Successfully..");

                        }
                    }
                    else
                    {
                        MessageBox("Upload Maximum image is 4 only.");
                        return;
                    }

                    //Notification Code

                    string strQry = "usp_NocticeBoard @command='All',@intschool_id='" + Session["School_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                        {
                            string strStandard_id = Convert.ToString(dsObj.Tables[0].Rows[i]["intstanderd_id"]);
                            string strDivision = Convert.ToString(dsObj.Tables[0].Rows[i]["intDivision_id"]);
                            string strStudent_id = Convert.ToString(dsObj.Tables[0].Rows[i]["intstudent_id"]);
                            string strFcmTokan = Convert.ToString(dsObj.Tables[0].Rows[i]["FCMToken"]);

                           // var applicationID = "AIzaSyCHfQSjFsEybdNRibLORHTMVVp6CKoI5TQ"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                            var applicationID = ConfigurationManager.AppSettings["ApplicationID"];

                            string message = "New Image added in Gallery";
                            string title = "Gallery";
                           // var SENDER_ID = "574926706382";
                            // 73064704159
                            var SENDER_ID = ConfigurationManager.AppSettings["SENDER_ID"];
                            var value = message.Trim();
                            WebRequest tRequest;
                            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            tRequest.Method = "post";
                            tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                                + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + strFcmTokan + "&data.title=" + title + "";

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
                    }

                }
                else 
                {
                    MessageBox("Gallery Limit is Only 100.");
                    return;
                
                }

            }
            else
            {
                MessageBox("Select image file.");
                return;
            }

            ddlCategory.SelectedIndex = 0;
            txtEvent.Text = "";

            //string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //FileUpload1.SaveAs("C:/inetpub/wwwroot/Rajasthan/TraffordSchool/TraffordSchool/image/" + filename);
            //con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString);
            //con.Open();
            //cmd = new SqlCommand("insert into Files (Name,Path,EventDescription,Uploadedfrom,Filetype,intSchool_id,btActiveFlg,intAcademic_id) values(@Name,@Path,@EventDescription,@Uploadedfrom,@Filetype,@intSchool_id,@btActiveFlg,@intAcademic_id)", con);
            //cmd.Parameters.AddWithValue("@Name", filename);
            //cmd.Parameters.AddWithValue("@Path", "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + filename);
            //cmd.Parameters.AddWithValue("@EventDescription", txtEvent.Text);
            //cmd.Parameters.AddWithValue("@Uploadedfrom", SqlDbType.VarChar).Value = "web";
            //cmd.Parameters.AddWithValue("@Filetype", SqlDbType.VarChar).Value = "gallery";
            //cmd.Parameters.AddWithValue("@intSchool_id", Session["School_id"].ToString());
            //cmd.Parameters.AddWithValue("@btActiveFlg", 1);
            //cmd.Parameters.AddWithValue("@intAcademic_id", Session["AcademicID"].ToString());
            //cmd.ExecuteNonQuery();
            //da = new SqlDataAdapter("select * from Files", con);
            //ds = new DataSet();
            //da.Fill(ds);
            //gvImages.DataSource = ds;
            //gvImages.DataBind();





            //if (regId == "0")
            //{

            //}
            //else
            //{
            //    var applicationID = "AIzaSyCzCbiophPs73yb-Tr7HPPiUqS8u26NKWM"; // PbojmyrmspdqkZ0pINni7DyqvhY2

            //    string message = "New Image added in Gallery";
            //    string title = "Gallery";
            //    var SENDER_ID = "592037958016";
            //    // 73064704159
            //    var value = "New Image added in Gallery";
            //    WebRequest tRequest;
            //    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            //    tRequest.Method = "post";
            //    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            //    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

            //    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            //    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
            //        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";

            //    Console.WriteLine(postData);
            //    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //    tRequest.ContentLength = byteArray.Length;

            //    Stream dataStream = tRequest.GetRequestStream();
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //    dataStream.Close();

            //    WebResponse tResponse = tRequest.GetResponse();

            //    dataStream = tResponse.GetResponseStream();

            //    StreamReader tReader = new StreamReader(dataStream);

            //    String sResponseFromServer = tReader.ReadToEnd();

            //    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
            //    //txtStream.Text = postData.ToString().Trim();
            //    tReader.Close();
            //    dataStream.Close();
            //    tResponse.Close();
            //}
        }
        
        catch (Exception ex)
        {
            //btnUpload.Text = ex.Message;
        }
    }
    

    protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //Session["id"] = Convert.ToString(gvImages.DataKeys[e.RowIndex].Value);
            Session["id"] = gvImages.DataKeys[e.RowIndex].Values[0].ToString();
            Session["Name"] = gvImages.DataKeys[e.RowIndex].Values[1].ToString();

            

            string strQry1 = "";
            strQry1 = "delete from Files where id='" + Convert.ToString(Session["id"]) + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                //var filePath = HttpContext.Current.Server.MapPath("C:/inetpub/wwwroot/Rajasthan/TraffordSchool/TraffordSchool/image/" + Convert.ToString(Session["Name"]));
                var filePath = HttpContext.Current.Server.MapPath("E:/Application UAT live/wwwroot/Mumbai/vclassrooms Demo/Demo API/SKSchoolApi/SKSchoolApi/image/" + Convert.ToString(Session["Name"]));
                //FileUpload1.SaveAs("D:/Application Live/NPST/Uttarakhand/SKPSchool/SKPSchool/image/" + filename);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {
            fGrid();
            MessageBox("Record Deleted Successfully!");

        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                MessageBox("Please Select Category.");
                return;
            }
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString);
            con.Open();
            da = new SqlDataAdapter("Select * from Files WHERE GalleryId = " + ddlCategory.SelectedValue + " Order By id DESC", con);
            ds = new DataSet();
            da.Fill(ds);
            gvImages.DataSource = ds;
            gvImages.DataBind();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}