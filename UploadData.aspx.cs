using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

public partial class UploadData : System.Web.UI.Page
{
    int result = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile != null)
        {
            try
            {
                //D:\Application Live\NPST\Uttarakhand\AttendanceUpload\AttendanceUpload\UploadFile
                //  string path = string.Concat(Server.MapPath("~/wwwroot/NPST/Uttarakhand/SKP/SqlBulkUploadAttendance/SqlBulkUploadAttendance/UploadFile/" + FileUpload1.FileName));
              //  string path = "D:/Application Live/NPST/Uttarakhand/AttendanceUpload/AttendanceUpload/UploadFile/" + FileUpload1.FileName;
                string path ="D:/Application Live/Mumbai/Android Demo/vclassrooms Demo/e-SMS12/UploadFile/" +FileUpload1.FileName;
                //string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                FileUpload1.SaveAs(path);

                string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                using (OleDbConnection con = new OleDbConnection(excelCS))
                {
                    con.Open();
                    List<string> listSheet = new List<string>();
                    listSheet = getExcelSheetName(con);
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    if (listSheet.Count > 0)
                    {

                        for (int i = 0; i < listSheet.Count; i++)
                        {
                            string sheetname = listSheet.ElementAt(i);
                            OleDbCommand cmd1 = new OleDbCommand("select * from " + "[" + sheetname + "]", con);
                            var adapter = new OleDbDataAdapter(cmd1);
                            adapter.Fill(dt2);
                            dt1.Merge(dt2);
                            dt1.AcceptChanges();


                        }
                    }

                    OleDbCommand cmd = new OleDbCommand("select * from " + "[" + listSheet.ElementAt(0) + "]", con);



                    DbDataReader dr = cmd.ExecuteReader();

                    string CS = ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;

                    DataTable dt = new DataTable();
                    var sheets = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    using (cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT TOP 1 * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";
                        var adapter = new OleDbDataAdapter(cmd);
                        adapter.Fill(dt);
                    }


                    string name = String.Empty;
                    foreach (DataColumn column in dt1.Columns)
                    {
                        name += "[" + column.ColumnName + "]" + " NVARCHAR(50)" + ", ";
                    }

                    bool status = Droptable("tblKGA", CS);
                    if (status)
                    {
                        CreateTableFromDataTable(dt1, "tblKGA", name, CS);
                    }


                    SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                    bulkInsert.DestinationTableName = "tblKGA";


                    bulkInsert.WriteToServer(dt1);

                    InsertIntoTable(CS);

                    lblMessage.Text = "Your file uploaded successfully";
                    lblmsg.Text = "Your file uploaded successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    if (result == 0)
                    {
                        lblMessage.Text = "Your file not uploaded";
                        lblmsg.Text = "Your file not uploaded"; ;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }


                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Your file not uploaded" + ex;
                lblmsg.Text = "Your file not uploaded" + ex; ;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    private List<string> getExcelSheetName(OleDbConnection con)
    {
        List<string> listSheet = new List<string>();
        try
        {

            DataTable dtSheet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow drSheet in dtSheet.Rows)
            {
                if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                {
                    listSheet.Add(drSheet["TABLE_NAME"].ToString());
                }
            }
        }
        catch (Exception e)
        {
        }

        return listSheet;
    }

    private bool Droptable(string TableName, string strconn)
    {
        bool status = false;
        try
        {

            SqlConnection con = new SqlConnection(strconn);
            string createString = "drop TABLE " + TableName + "";
            SqlCommand create = new SqlCommand(createString, con);
            con.Open();
            create.ExecuteNonQuery();
            con.Close();
            status = true;

        }
        catch (Exception ex)
        {

        }
        return status;
    }

    private void CreateTableFromDataTable(DataTable dt, string tablename, string columns, string strconn)
    {

        try
        {
            SqlConnection con = new SqlConnection(strconn);
            string createString = "CREATE TABLE " + tablename + " (" + columns + ")"; //YOUR SQL COMMAND TO CREATE A TABLE                      
            SqlCommand create = new SqlCommand(createString, con);
            con.Open();
            create.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {

        }
    }


    private void InsertIntoTable(string strconn)
    {
        try
        {
            SqlConnection con = new SqlConnection(strconn);
            SqlCommand com1 = new SqlCommand("exec usp_bulkattendanceuploadNew", con);
            con.Open();
            result = com1.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {

        }
    }
}