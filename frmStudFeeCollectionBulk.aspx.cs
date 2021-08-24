using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

public partial class frmStudFeeCollection : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    List<CheckBox> lstChckBox;
    List<CheckBox> lstChckBox_Months;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
               

                if (!IsPostBack)
                {
                    FillSTD();
                    Clear();
                }

            }
            else
            {
                Response.Redirect("~\\login.aspx", false);
            }
        }
        catch (Exception)
        {

        }
    }


    public void FillSTD()
    {
        try
        {
            strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            ddlSTD.Items.Insert(1, "All");
        }
        catch (Exception)
        {

        }
    }

    public void FillDiv()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDiv, strQry, "vchDivisionName", "intDivision_id");
            ddlDiv.Items.Insert(1,"All");
        }
        catch (Exception)
        {

        }
    }

    public void fillStudent()
    {
        try
        {
            strQry = "exec usp_Addfee @command='GetStudentsDivisionWise',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindGrid(grdstudent, strQry);           
        }
        catch (Exception)
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSTD.SelectedValue == "All")
        {
            ddlDiv.SelectedValue = "All";
            ddlDiv.Enabled = false;
            PaidFeesFromMobile();
        }
        else
        {
            ddlDiv.Enabled = true;
            FillDiv();
        }
    }
    
    protected void ddlDiv_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  fillStudent();
        PaidFeesFromMobile();
    
    }

    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {

      ////  PaidFeesFromMobile();

      //  grdstudent.Visible = true;

      //  strQry = "exec usp_Addfee @command='GetStudentsDivisionWise',@intDivision_id='" + Convert.ToString(ddlDiv.SelectedValue) + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSchool_id='" + Session["School_id"] + "'";
      //  DataSet ds = sGetDataset(strQry);
        
      //  string AcademicID = Convert.ToString(Session["AcademicID"]);

      //  string SchoolID=Convert.ToString(Session["School_id"]);

      //  DataColumnCollection col = ds.Tables[0].Columns;
      //  if (!col.Contains("NetAmount"))
      //      ds.Tables[0].Columns.Add("NetAmount");


      //  DataTable dt = new DataTable();

      //  foreach (DataRow row in ds.Tables[0].Rows)
      //  {
      //      try
      //      {
      //          string output = APICallGET(row["intStudentID_Number"].ToString(), ddlSTD.SelectedValue, row["intStudent_id"].ToString(), AcademicID, SchoolID, Convert.ToString(ddlMonth.SelectedItem));
      //         dt= JsonStringToDataTable(output);

      //         int NetAmt = 0;
      //         if (dt.Rows.Count > 1)
      //         {
      //             foreach (DataRow ro in dt.Rows)
      //             {
      //                 NetAmt += Convert.ToInt32(ro["NetAmt"]);
      //             }
      //         }
      //         else
      //         {
      //              DataColumnCollection col1 = dt.Columns;
      //              if (!col1.Contains("NetAmt"))
      //                  NetAmt = 0;
      //              else
      //                  NetAmt += Convert.ToInt32(dt.Rows[0]["NetAmt"]);
      //         }
      //         row["NetAmount"] = NetAmt;
                    
      //      }
      //      catch (Exception ex)
      //      {
      //      }
      //   }

      //  grdstudent.DataSource = ds.Tables[0];
      //  grdstudent.DataBind();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
             string AcademicID = Convert.ToString(Session["AcademicID"]);

              string SchoolID=Convert.ToString(Session["School_id"]);

              //DataTable dt = new DataTable();

              //DataTable dataset = new DataTable();
              //dataset.Columns.Add("StudentName");
              //dataset.Columns.Add("Status");
              int i = 0;
              foreach (GridViewRow row in grdstudent.Rows)
              {
                  try
                  {
                      if (row.RowType == DataControlRowType.DataRow)
                      {
                          CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                          if (chkRow.Checked == true)
                          {
                              int rowIndex = row.RowIndex;
                              int val = (int)grdstudent.DataKeys[rowIndex]["intStudFee_id"];

                              strQry = "exec usp_Addfee @command='UpdateStatus',@intStudFee_id='" + val  + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intDivision_id='" + ddlDiv.SelectedValue + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSchool_id='" + Session["School_id"] + "'";
                              i = sExecuteQuery(strQry);
                              //string output = APICallPOST(row.Cells[3].Text, ddlSTD.SelectedValue, row.Cells[2].Text, AcademicID, SchoolID, Convert.ToString(ddlMonth.SelectedItem), ddlDiv.SelectedValue, row.Cells[1].Text);

                              //if (output == "\"Record Inserted Successfully\"")
                              //{
                              //    dataset.Rows[i]["StudentName"] = row.Cells[4].Text;
                              //    dataset.Rows[i]["Status"] = "Paid";
                              //    i++;
                              //}
                          }
                      }

                  }
                  catch (Exception ex)
                  {
                  }
              }

              if (i > 0)
              {
                  MessageBox("Record Submitted Successfully");
                  Clear();
              }
        }
        catch (Exception ex)
        {
        }
       
    }
   
    protected void drpPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    public void Clear()
    {
        try
        {
            grdstudent.Visible = false;
            ddlMonth.ClearSelection();
            ddlSTD.ClearSelection();
            ddlDiv.ClearSelection();
        }
        catch (Exception)
        {

        }
    }

   
  
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    public string APICallGET(string intStudentID_Number, string intstandard_id, string intStudentID, string intAcademic_id, string intSchool_id,string Month)
    {
        try
        {
            //string strurltest = String.Format("http://VClassrooms.com/vclassroomsSchoolDemoAPI/api/SchoolFeeDetails?command=MonthWiseTotalFee&intStudentID_Number=" + intStudentID_Number + "&intstandard_id=" + intstandard_id + "&intStudentID=" + intStudentID + "&intAcademic_id=" + intAcademic_id + "&intSchool_id=" + intSchool_id + "");
            string strurltest = String.Format("http://VClassrooms.com/vclassroomsSchoolDemoAPI/api/SchoolFeeDetails?command=MonthFeeDetails&intStudentID_Number=" + intStudentID_Number + "&intstandard_id=" + intstandard_id + "&intStudentID=" + intStudentID + "&intAcademic_id=" + intAcademic_id + "&intSchool_id=" + intSchool_id + "&month=" + Month + "");
            WebRequest requestObjGet = WebRequest.Create(strurltest);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string strresulttest = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }
            return strresulttest;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string APICallPOST(string intStudentID_Number, string intstandard_id, string intStudentID, string intAcademic_id, string intSchool_id, string month, string intDivision_id, string intRoll_no)
    {
        //string strurltest = String.Format("http://VClassrooms.co.in/ReactDemoAPI/api/Message/Getmy/");
        string strurltest = String.Format("http://VClassrooms.com/vclassroomsSchoolDemoAPI/api/SchoolFeeDetails?command=PayFeeMonthWise&intStudentID_Number=" + intStudentID_Number + "&intstandard_id=" + intstandard_id + "&intStudentID=" + intStudentID + "&intAcademic_id=" + intAcademic_id + "&intSchool_id=" + intSchool_id + "&month=" + month + "&intDivision_id=" + intDivision_id + "&intRoll_no=" + intRoll_no  + "");
        WebRequest requestObjPOST = WebRequest.Create(strurltest);
        requestObjPOST.Method = "POST";
        requestObjPOST.ContentType = "application/json";

        //string postData = "{\"intSchool_id\":\"1\",\"intAcademic_id\":\"2\",\"intUserType_id\":\"1\",\"intUser_id\":\"0\",\"intStandard_id\":\"3,4\",\"intDivision_id\":\"0\",\"Mobile_number\":\"0\",\"messagetitle\":\"Msg from Web\",\"message\":\"Test for 3,4 Standards\",\"messagecount\":\"1\",\"insertedby\":\"1\",\"IP\":\"192.168.1.150\",\"command\":\"ListOfStudentsStandardWise\",\"MessageLanguage\':\"0\",\"Status\":\"Send\"}";

        //using (var streamWritter = new StreamWriter(requestObjPOST.GetRequestStream()))
        //{
        //    streamWritter.Write(postData);
        //    streamWritter.Flush();
        //    streamWritter.Close();

        //    var httpResponse = (HttpWebResponse)requestObjPOST.GetResponse();

        //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //    {
        //        var result2 = streamReader.ReadToEnd();
        //    }
        //}

        string result2;
        using (Stream stream = requestObjPOST.GetRequestStream())
        {
            var httpResponse = (HttpWebResponse)requestObjPOST.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result2 = streamReader.ReadToEnd();
            }
        }
        return result2;
    }


    public DataTable JsonStringToDataTable(string jsonString)
    {
        DataTable dt = new DataTable();
        string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
        List<string> ColumnsName = new List<string>();
        foreach (string jSA in jsonStringArray)
        {
            string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            foreach (string ColumnsNameData in jsonStringData)
            {
                try
                {
                    int idx = ColumnsNameData.IndexOf(":");
                    string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                    if (!ColumnsName.Contains(ColumnsNameString))
                    {
                        ColumnsName.Add(ColumnsNameString);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                }
            }
            break;
        }
        foreach (string AddColumnName in ColumnsName)
        {
            dt.Columns.Add(AddColumnName);
        }
        foreach (string jSA in jsonStringArray)
        {
            string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            DataRow nr = dt.NewRow();
            foreach (string rowData in RowData)
            {
                try
                {
                    int idx = rowData.IndexOf(":");
                    string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                    string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                    nr[RowColumns] = RowDataString;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            dt.Rows.Add(nr);
        }
        return dt;
    }


    //Paid fees from mobile 
    private void PaidFeesFromMobile()
    {
        try
        {
            string std = ddlSTD.SelectedValue == "All" ? "0" : ddlSTD.SelectedValue;
            string div = ddlDiv.SelectedValue == "All" ? "0" : ddlDiv.SelectedValue;

            strQry = "exec usp_Addfee @command='GetMonthWiseSumPaidByMobile',@intStandard_id='" + std + "',@intDivision_id='" + div + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSchool_id='" + Session["School_id"] + "'";
            DataSet ds = sGetDataset(strQry);
            grdstudent.DataSource = ds.Tables[0];
            grdstudent.DataBind();

            grdstudent.Visible = true;

        }
        catch (Exception ex)
        {
        }
    }

}