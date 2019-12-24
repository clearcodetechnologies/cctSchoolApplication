﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

public partial class rptResultPrimary : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["rptStdWiseStuFee"] != null)
        {
            dsObjgrade = (DataSet)Session["rptStdWiseStuFee"];

            try
            {
                int i = 0;
                string reportPath = Server.MapPath("NursaryResult.rpt");
                crystalReport.Load(reportPath);
                TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
                TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text53"];
                TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
                TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];

                TextObject SUBenglish = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
                TextObject SUBphysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
                TextObject SUBconversation = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
                TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                TextObject SUBhindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text9"];
                TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
                TextObject SUBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text11"];


                TextObject english = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
                TextObject physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
                TextObject conversation = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
                TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
                TextObject hindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
                TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];



                TextObject HYenglishgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                TextObject HYphysicsgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
                TextObject HYconversationgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                TextObject HYmathgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                TextObject HYhindigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text32"];
                TextObject HYscigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
                TextObject HYgeneralgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

                TextObject englishgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                TextObject physicsgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                TextObject conversationgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject mathgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                TextObject hindigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
                TextObject scigrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
                TextObject generalgrade = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];

                TextObject art1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                TextObject art2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                TextObject art3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];

                TextObject subart1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
                TextObject subart2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text35"];
                TextObject subart3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text36"];

                TextObject sochb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                TextObject sochb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject sochb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject sochb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];

                TextObject SUBsochb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text38"];
                TextObject SUBsochb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
                TextObject SUBsochb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
                TextObject SUBsochb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text40"];

                TextObject wrkhb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject wrkhb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                TextObject wrkhb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject wrkhb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                TextObject wrkhb5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject wrkhb6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];

                TextObject SUBwrkhb1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
                TextObject SUBwrkhb2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                TextObject SUBwrkhb3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                TextObject SUBwrkhb4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                TextObject SUBwrkhb5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                TextObject SUBwrkhb6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];

                TextObject pt1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                TextObject pt2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject pt3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];

                TextObject SUBpt1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                TextObject SUBpt2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                TextObject SUBpt3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];

                TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];

                TextObject Strenght = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
                TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];

                TextObject Totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                TextObject PrsenetDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];



                 session.Text = Convert.ToString(Session["YearName"]);
                 ExamName.Text = Convert.ToString(Session["Exam_id"]);
                 //reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();
                 class1.Text = Convert.ToString(Session["standard_id"]).ToUpper();

                 //strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 ";
                 //string subcount = sExecuteReader(strQry);
                 //int count = Convert.ToInt32(subcount);
                

                //strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalf',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
                //dsObjgrade = sGetDataset(strQry);

                List<byte[]> files = new List<byte[]>();

                for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                {
                    strQry = "Execute dbo.usp_Profile @command='ShowProfileall' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);

                        rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                        //class1.Text = ddlSTD.SelectedItem.ToString();
                        sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                    }

                    strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                       // Totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                        PrsenetDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                    }

                    
                    strQry = "exec usp_ExamMarks @type='EnglishActivityMarkAll',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        //GridView1.DataSource = dsObj;
                        //GridView1.DataBind();
                        art1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);//first term
                        // lblengactgrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        art2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);//first term
                        // lblengactgrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        art3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);//first term

                        subart1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);//first term 
                        subart2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);//first term            
                        subart3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);//first term
                    }

                    strQry = "exec usp_ExamMarks @type='workhabitMarkall',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        wrkhb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        wrkhb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        wrkhb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        wrkhb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        wrkhb5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                        wrkhb6.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);

                        SUBwrkhb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        SUBwrkhb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        SUBwrkhb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        SUBwrkhb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                        SUBwrkhb5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                        SUBwrkhb6.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                    }
                    strQry = "exec usp_ExamMarks @type='skillmarkgrade_firstall',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        pt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        pt2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        pt3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);

                        SUBpt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchskillName"]);
                        SUBpt2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchskillName"]);
                        SUBpt3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchskillName"]);
                    }

                    strQry = "exec usp_ExamMarks @type='personalMarkall',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        sochb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        sochb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        sochb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        sochb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);

                        SUBsochb1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        SUBsochb2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        SUBsochb3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        SUBsochb4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);

                    }

                    strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=1";
                    string Strength = sExecuteReader(strQry);
                    Strenght.Text = Strength;
                    strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=2";
                    string remark = sExecuteReader(strQry);
                    Suggestion.Text = remark;


                    strQry = "exec usp_ExamMarks @type='ExamMark_PrimaryHalf',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                    dsObj = sGetDataset(strQry);

                    if (dsObj.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        SUBenglish.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBphysics.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBconversation.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBhindi.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        SUBgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                    }
                    catch
                    {
                    }

                    try
                    {
                        english.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        physics.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        conversation.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        math.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        hindi.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        sci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        general.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                    }
                    catch
                    {
                    }

                    try
                    {
                        HYenglishgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYphysicsgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYconversationgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYmathgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYhindigrade.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYscigrade.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        HYgeneralgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                    }
                    catch
                    {
                    }

                    try
                    {
                        englishgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        physicsgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        conversationgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        mathgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        hindigrade.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        scigrade.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        generalgrade.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                    }
                    catch
                    {
                    }
                }


                 crystalReport.Load(Server.MapPath(string.Format("NursaryResult.rpt", i)));

                
                //AdmissionReport.ReportSource = crystalReport;
                //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                files.Add(PrepareBytes(stream1));

                //crystalReport = crystalReport.Subreports(); 
                    
            }
                AdmissionReport.ReportSource = files;
                AdmissionReport.SeparatePages = false;

                
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";

               //// merge the all reports & show the reports            
                Response.BinaryWrite(MergeReports(files).ToArray());
               // AdmissionReport.ReportSource = crystalReport;
                Response.End(); 


              



                

                
                //AdmissionReport.DataBind();
                //AdmissionReport.RefreshReport();

                //crystalReport.Close();
                //crystalReport.Dispose();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();

            }
        }

    }

    private MemoryStream MergeReports(List<byte[]> files)
    {
        if (files.Count > 1)
        {
            PdfReader pdfFile;
            
            Document doc;
            PdfWriter pCopy;
            MemoryStream msOutput = new MemoryStream();

            pdfFile = new PdfReader(files[0]);

            doc = new Document();
            pCopy = new PdfSmartCopy(doc, msOutput);

            doc.Open();

            for (int k = 0; k < files.Count; k++)
            {
                pdfFile = new PdfReader(files[k]);
                for (int i = 1; i < pdfFile.NumberOfPages + 1; i++)
                {
                    ((PdfSmartCopy)pCopy).AddPage(pCopy.GetImportedPage(pdfFile, i));
                }
                pCopy.FreeReader(pdfFile);
            }

            pdfFile.Close();
            pCopy.Close();
            doc.Close();

            return msOutput;
        }
        else if (files.Count == 1)
        {
            return new MemoryStream(files[0]);
        }

        return null;
    }
    private byte[] PrepareBytes(Stream stream)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            byte[] buffer = new byte[stream.Length];
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }


}