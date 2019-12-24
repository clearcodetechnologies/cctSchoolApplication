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

public partial class Gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
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
    }

    //   using (Image image = Image.FromFile(Path))
    //   {
    //    using (MemoryStream m = new MemoryStream())
    //    {
    //        image.Save(m, image.RawFormat);
    //        byte[] imageBytes = m.ToArray();

    //        // Convert byte[] to Base64 String
    //        string base64String = Convert.ToBase64String(imageBytes);
    //        return base64String;
    //    }
    //}
    protected void Upload(object sender, EventArgs e)
    {
        //      byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
        //string base64ImageRepresentation = Convert.ToBase64String(imageArray);


        String test = DateTime.Now.ToString("dd_MM_yyy_HH_mm_ss");
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                string myfilename = FileUpload1.PostedFile.FileName;

                //string filepath = "C:/inetpub/wwwroot/NPST/Demo/e-SMS1/NPSTDemoServices/UploadImages/" + myfilename + ".jpeg";
                string filePath = "~/UploadImages/" + myfilename;
                string FullPath = Server.MapPath(filePath);


                var bytess = Convert.FromBase64String(base64String);
                using (var imageFile = new FileStream((Server.MapPath(filePath)), FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }
                ////           var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64String)));
                //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                ////string filePath = FileUpload1.PostedFile.FileName;
                //// string  ImageName = Path.GetFileName(filePath);
                //string filePath = "~/inetpub/wwwroot/NPST/Demo/New folder/e-SMS1/NPSTDemoServices/UploadImages/" + fileName;
                //string filePath1 = AppDomain.CurrentDomain.BaseDirectory + fileName;
                //string path = Path.GetFullPath(fileName);
                //Path.GetFullPath((new Uri(FileUpload1.PostedFile.FileName)).LocalPath);
                //FileUpload1.PostedFile.SaveAs(filePath);

                string constr = ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string sql = "INSERT INTO Files([Name],[Path],[EventDescription],[Uploadedfrom],[Filetype],[image]) VALUES(@Name, @Path,@EventDescription,@Uploadedfrom,@Filetype,@image)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", myfilename);
                        cmd.Parameters.AddWithValue("@Path", FullPath);
                        cmd.Parameters.AddWithValue("@EventDescription", txtEvent.Text);
                        cmd.Parameters.Add("@Uploadedfrom", SqlDbType.VarChar).Value = "web";
                        cmd.Parameters.Add("@Filetype", SqlDbType.VarChar).Value = "gallery";
                        cmd.Parameters.Add("@image", bytess);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
    }
}


//        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

//        string filePath = "~/UploadImages/" + fileName;


//        FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath));

//        string constr = ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
//        using (SqlConnection conn = new SqlConnection(constr))
//        {
//            string sql = "INSERT INTO Files VALUES(@Name, @Path,@EventDescription)";
//            using (SqlCommand cmd = new SqlCommand(sql, conn))
//            {
//                cmd.Parameters.AddWithValue("@Name", fileName);
//                cmd.Parameters.AddWithValue("@Path", filePath);
//                cmd.Parameters.AddWithValue("@EventDescription",txtEvent.Text);
//                conn.Open();
//                cmd.ExecuteNonQuery();
//                conn.Close();
//            }
//        }

//        Response.Redirect(Request.Url.AbsoluteUri);
//    }

