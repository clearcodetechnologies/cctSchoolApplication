using System;
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

public partial class rptResult_I_V : DBUtility
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
        if (Session["rptAllStudentMark"] != null)
        {
            dsObjgrade = (DataSet)Session["rptAllStudentMark"];

            try
            {
                int i = 0;
                string reportPath = Server.MapPath("Result_09Annual.rpt");
                crystalReport.Load(reportPath);

                //{Code Ny me
                TextObject Heading = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text23"];
                Heading.Text = "ACHIEVEMENT RECORD ACADEMIC YEAR (" + Session["AcademicYearName"] + ")";

                //Student Profile
                TextObject AdmnNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text4"];
                TextObject Studentnm = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                TextObject Mothernm = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                TextObject Fathernm = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
                TextObject Address = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
                TextObject DOB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
                TextObject ContactNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
                TextObject AadharNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
                TextObject Std = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                TextObject Div = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];

                //Academic Performance
                TextObject SubEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text53"];
                TextObject SubMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                TextObject SubHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
                TextObject SubScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];
                TextObject SubSScience  = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
               
                //Per Test Marks - I
                TextObject PerTestEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
                TextObject PerTestMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                TextObject PerTestHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
                TextObject PerTestScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                TextObject PerTestSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
              
                //NoteBook Mark - I
                TextObject NBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
                TextObject NBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                TextObject NBHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
                TextObject NBScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                TextObject NBSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
               
                //Sub Enrichment - I
                TextObject SEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
                TextObject SEMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                TextObject SEHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
                TextObject SEScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                TextObject SESScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                
                //Half Yearly -  I
                TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
                TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject HYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
                TextObject HYScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                TextObject HYSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
              
                //Marks Obtained Half Yearly
                TextObject MOHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                TextObject MOHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                TextObject MOHYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                TextObject MOHYScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                TextObject MOHYSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                
                //Grade Half Yearly
                TextObject GradeEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject GradeMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
                TextObject GradeHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject GradeScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                TextObject GradeSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                
                //Grand Total Half Yearly
                TextObject HYTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject HYPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];

              
                //Co- Scholastic Areas Term- I
                //Subjects
                TextObject CSASub1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                TextObject CSASub2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                TextObject CSASub3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                TextObject CSASub4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];

                //Grade
                TextObject CSAGrade1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                TextObject CSAGrade2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject CSAGrade3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];
                TextObject CSAGrade4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

                TextObject Exam = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text33"];

                TextObject termII = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text96"];
                TextObject atttermII = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text97"];
                //}

               
               


                List<byte[]> files = new List<byte[]>();
                for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                {

                strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                    //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                }


                strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
                //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    Studentnm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                    Mothernm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                    Fathernm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    Fathernm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    DOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                    AadharNo.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["Aadhar"]);
                    //rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                    Address.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                    ContactNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                    //class1.Text = ddlSTD.SelectedItem.ToString();
                    Std.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
                    Div.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                    //StudentId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);

                    termII.Text = Convert.ToString(Session["Exam_id"]) == "Term 2" ? "Term-II" : "";
                }
                //Half Yearly variables for total and percentage
                int HYMarksEng = 0;
                int HYMarksMath = 0;
                int HYMarksHindi = 0;
                int HYMarksSScience=0;
                int HYMarksScience=0;
                int HYMarksSanskrit=0;
                int HYMarksComputer = 0;

                strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "',@intSubcat_id=1";
                dsObj = sGetDataset(strQry);
                Exam.Text = "Half Yearly Exam";
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        SubEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                 
                   
                    
                    try
                    {

                        PerTestEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Per. Test"]);
                    }
                    catch
                    {

                    }
                  
                    
                    try
                    {




                        NBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                    }
                    catch
                    {

                    }
                  
                    try
                    {



                        SEEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SESScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    
                   
                    try
                    {
                        HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                  
              
                    try
                    {



                        MOHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);

                         HYMarksEng = Convert.ToInt32(MOHYEng.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);

                         HYMarksMath = Convert.ToInt32(MOHYMath.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);

                         HYMarksHindi = Convert.ToInt32(MOHYHindi.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);

                         HYMarksSScience = Convert.ToInt32(MOHYSScience.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);

                         HYMarksScience = Convert.ToInt32(MOHYScience.Text); 
                    }
                    catch
                    {

                    }
                  
                    try
                    {


                        GradeEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                    }
                    catch
                    {

                    }
                
                

                }
                //Half Yearly Grand Total and Percentage
                int HYGrandTotal = HYMarksEng + HYMarksMath + HYMarksHindi + HYMarksScience + HYMarksSScience + HYMarksSanskrit + HYMarksComputer;
                HYTotal.Text = Convert.ToString(HYGrandTotal);
                float HYPer = HYGrandTotal / 5;
                HYPercentage.Text = Convert.ToString(HYPer);


                   
                 strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSubcat_id=2";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                CSASub1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                CSASub2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                CSASub3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                CSASub4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                            }
                            catch
                            {

                            }

                            try
                            {
                                CSAGrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                            }
                            catch 
                            {
                            }
                            try
                            {
                                CSAGrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                CSAGrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                CSAGrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                            }
                            catch
                            {
                            }
                            
                        }
                    //Annual
                     //Annual Grand Total And Percentage
                        int ANMarksEng = 0;
                        int ANMarksMath = 0;
                        int ANMarksHindi = 0;
                        int ANMarksSScience = 0;
                        int ANMarksScience = 0;
                        int ANMarksSanskrit = 0;
                        int ANMarksComputer = 0;

                        string test = Convert.ToString(Session["Exam_id"]);
                        if (Convert.ToString(Session["Exam_id"]) == "Term 2")
                        {
                            Exam.Text = "Annual Exam";

                            // Per Test
                            PerTestEng.Text = "";   PerTestScience.Text = "";
                            PerTestMath.Text = "";  PerTestSScience.Text = "";
                            PerTestHindi.Text = "";

                            //Note Book
                            NBEng.Text = ""; NBMath.Text = "";
                            NBHindi.Text = ""; NBScience.Text = "";
                            NBSScience.Text = "";

                            //Sub Enrichment
                            SEEng.Text = "";        SEMath.Text = "";       SEHindi.Text = "";
                            SEScience.Text = "";    SESScience.Text = "";
                            
                            //Half Yearly
                            HYEng.Text = ""; HYMath.Text = ""; HYHindi.Text = "";
                            HYScience.Text = ""; HYSScience.Text = "";

                            //Marks Obtained 
                            MOHYEng.Text = ""; MOHYMath.Text = ""; MOHYHindi.Text = "";
                            MOHYScience.Text = ""; MOHYSScience.Text = "";

                            //Grade 
                            GradeEng.Text = ""; GradeMath.Text = ""; GradeHindi.Text  = "";
                            GradeSScience.Text = ""; GradeScience.Text  = ""; 

                            //Grand Total and percentage
                            HYTotal.Text = "";
                            HYPercentage.Text = "";

                            //Co Scholastic Subjects & Grade
                            CSASub1.Text = ""; CSASub2.Text = ""; CSASub3.Text = ""; CSASub4.Text = "";
                            CSAGrade1.Text = ""; CSAGrade2.Text = ""; CSAGrade3.Text = ""; CSAGrade4.Text = "";

                            strQry = "exec usp_ExamMarks @type='ExamMarksAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "',@intSubcat_id=1";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {

                                try
                                {

                                    PerTestEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                

                                try
                                {




                                    NBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                
                                try
                                {



                                    SEEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SESScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                
                                try
                                {
                                    HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    HYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    HYHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    HYSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    HYScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                
                                try
                                {



                                    MOHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalAnnual"]);
                                    ANMarksEng = Convert.ToInt32(MOHYEng.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["TotalAnnual"]);
                                    ANMarksMath  = Convert.ToInt32(MOHYMath.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOHYHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["TotalAnnual"]);
                                    ANMarksHindi = Convert.ToInt32(MOHYHindi.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOHYSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["TotalAnnual"]);
                                    ANMarksSScience = Convert.ToInt32(MOHYSScience.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOHYScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["TotalAnnual"]);
                                    ANMarksScience = Convert.ToInt32(MOHYScience.Text);
                                }
                                catch
                                {

                                }
                                
                                
                                try
                                {


                                    GradeEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                               
                            }

                            //Annual Yearly Grand Total and Percentage
                           int ANGrandTotal = ANMarksEng + ANMarksMath + ANMarksHindi + ANMarksScience + ANMarksSScience + ANMarksSanskrit + ANMarksComputer;
                            HYTotal.Text = Convert.ToString(ANGrandTotal);
                            float ANPer = ANGrandTotal / 5;
                            HYPercentage.Text = Convert.ToString(ANPer);


                            strQry = "exec usp_ExamMarks @type='ExamMarksAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSubcat_id=2";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                try
                                {
                                    CSASub1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSASub2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    CSASub3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    CSASub4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                                }
                                catch
                                {

                                }

                                try
                                {
                                    CSAGrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAGrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAGrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAGrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                                }
                                catch
                                {
                                }

                            }
                        }
              

                    //Totoal I + II 
                        int TotalEng = HYMarksEng + ANMarksEng;
                        int TotalMath = HYMarksMath + ANMarksMath;
                        int TotalHindi = HYMarksHindi + ANMarksHindi;
                        int TotalSScience = HYMarksSScience + ANMarksSScience;
                        int TotalScience = HYMarksScience + ANMarksScience;
                        int TotalSanskrit = HYMarksSanskrit + ANMarksSanskrit;
                        int TotalComputer = HYMarksComputer + ANMarksComputer;

                    //    if (Convert.ToString(Session["Exam_id"]) == "Term 2")
                    //    {
                    //    FinalEng.Text = Convert.ToString(TotalEng);
                    //    FinalMath.Text = Convert.ToString(TotalMath);
                    //    FinalHindi.Text = Convert.ToString(TotalHindi);
                    //    FinalSScience.Text = Convert.ToString(TotalSScience);
                    //    FinalScience.Text = Convert.ToString(TotalScience );
                    //    FinalSanskrit.Text = Convert.ToString(TotalSanskrit);
                    //    FinalComputer.Text = Convert.ToString(TotalComputer);

                    //float FinalPerEng = TotalEng /  2;
                    //float FinalPerMath = TotalMath / 2;
                    //float FinalPerHindi = TotalHindi / 2;
                    //float FinalPerSScience = TotalSScience / 2;
                    //float FinalPerScience = TotalScience / 2;
                    //float FinalPerSanskrit = TotalSanskrit / 2;
                    //float FinalPerComputer = TotalComputer / 2;

                   
                    //    //Grade For English
                    //    if (FinalPerEng > 90 && FinalPerEng < 101)
                    //    {
                    //        FinalGradeEng.Text = "A1";
                    //    }
                    //    else if (FinalPerEng > 80 && FinalPerEng < 91)
                    //    {
                    //        FinalGradeEng.Text = "A2";
                    //    }
                    //    else if (FinalPerEng > 70 && FinalPerEng < 81)
                    //    {
                    //        FinalGradeEng.Text = "B1";
                    //    }
                    //    else if (FinalPerEng > 60 && FinalPerEng < 71)
                    //    {
                    //        FinalGradeEng.Text = "B2";
                    //    }
                    //    else if (FinalPerEng > 50 && FinalPerEng < 61)
                    //    {
                    //        FinalGradeEng.Text = "C1";
                    //    }
                    //    else if (FinalPerEng > 40 && FinalPerEng < 51)
                    //    {
                    //        FinalGradeEng.Text = "C2";
                    //    }
                    //    else if (FinalPerEng > 32 && FinalPerEng < 41)
                    //    {
                    //        FinalGradeEng.Text = "D";
                    //    }
                    //    else if (FinalPerEng > 0 && FinalPerEng < 33)
                    //    {
                    //        FinalGradeEng.Text = "E";
                    //    }

                    //    //Grade for Maths
                    //    if (FinalPerMath > 90 && FinalPerMath < 101)
                    //    {
                    //        FinalGradeMath.Text = "A1";
                    //    }
                    //    else if (FinalPerMath > 80 && FinalPerMath < 91)
                    //    {
                    //        FinalGradeMath.Text = "A2";
                    //    }
                    //    else if (FinalPerMath > 70 && FinalPerMath < 81)
                    //    {
                    //        FinalGradeMath.Text = "B1";
                    //    }
                    //    else if (FinalPerMath > 60 && FinalPerMath < 71)
                    //    {
                    //        FinalGradeMath.Text = "B2";
                    //    }
                    //    else if (FinalPerMath > 50 && FinalPerMath < 61)
                    //    {
                    //        FinalGradeMath.Text = "C1";
                    //    }
                    //    else if (FinalPerMath > 40 && FinalPerMath < 51)
                    //    {
                    //        FinalGradeMath.Text = "C2";
                    //    }
                    //    else if (FinalPerMath > 32 && FinalPerMath < 41)
                    //    {
                    //        FinalGradeMath.Text = "D";
                    //    }
                    //    else if (FinalPerMath > 0 && FinalPerMath < 33)
                    //    {
                    //        FinalGradeMath.Text = "E";
                    //    }

                    //    // Grade for Hindi
                    //    if (FinalPerHindi > 90 && FinalPerHindi < 101)
                    //    {
                    //        FinalGradeHindi.Text = "A1";
                    //    }
                    //    else if (FinalPerHindi > 80 && FinalPerHindi < 91)
                    //    {
                    //        FinalGradeHindi.Text = "A2";
                    //    }
                    //    else if (FinalPerHindi > 70 && FinalPerHindi < 81)
                    //    {
                    //        FinalGradeHindi.Text = "B1";
                    //    }
                    //    else if (FinalPerHindi > 60 && FinalPerHindi < 71)
                    //    {
                    //        FinalGradeHindi.Text = "B2";
                    //    }
                    //    else if (FinalPerHindi > 50 && FinalPerHindi < 61)
                    //    {
                    //        FinalGradeHindi.Text = "C1";
                    //    }
                    //    else if (FinalPerHindi > 40 && FinalPerHindi < 51)
                    //    {
                    //        FinalGradeHindi.Text = "C2";
                    //    }
                    //    else if (FinalPerHindi > 32 && FinalPerHindi < 41)
                    //    {
                    //        FinalGradeHindi.Text = "D";
                    //    }
                    //    else if (FinalPerHindi > 0 && FinalPerHindi < 33)
                    //    {
                    //        FinalGradeHindi.Text = "E";
                    //    }

                    //    //Grade For Social Science
                    //    if (FinalPerSScience > 90 && FinalPerSScience < 101)
                    //    {
                    //        FinalGradeScience.Text = "A1";
                    //    }
                    //    else if (FinalPerSScience > 80 && FinalPerSScience < 91)
                    //    {
                    //        FinalGradeScience.Text = "A2";
                    //    }
                    //    else if (FinalPerSScience > 70 && FinalPerSScience < 81)
                    //    {
                    //        FinalGradeScience.Text = "B1";
                    //    }
                    //    else if (FinalPerSScience > 60 && FinalPerSScience < 71)
                    //    {
                    //        FinalGradeScience.Text = "B2";
                    //    }
                    //    else if (FinalPerSScience > 50 && FinalPerSScience < 61)
                    //    {
                    //        FinalGradeScience.Text = "C1";
                    //    }
                    //    else if (FinalPerSScience > 40 && FinalPerSScience < 51)
                    //    {
                    //        FinalGradeScience.Text = "C2";
                    //    }
                    //    else if (FinalPerSScience > 32 && FinalPerSScience < 41)
                    //    {
                    //        FinalGradeScience.Text = "D";
                    //    }
                    //    else if (FinalPerSScience > 0 && FinalPerSScience < 33)
                    //    {
                    //        FinalGradeScience.Text = "E";
                    //    }

                    //    // Grade for Science
                    //    if (FinalPerScience > 90 && FinalPerScience < 101)
                    //    {
                    //        FinalGradeScience.Text = "A1";
                    //    }
                    //    else if (FinalPerScience > 80 && FinalPerScience < 91)
                    //    {
                    //        FinalGradeScience.Text = "A2";
                    //    }
                    //    else if (FinalPerScience > 70 && FinalPerScience < 81)
                    //    {
                    //        FinalGradeScience.Text = "B1";
                    //    }
                    //    else if (FinalPerScience > 60 && FinalPerScience < 71)
                    //    {
                    //        FinalGradeScience.Text = "B2";
                    //    }
                    //    else if (FinalPerScience > 50 && FinalPerScience < 61)
                    //    {
                    //        FinalGradeScience.Text = "C1";
                    //    }
                    //    else if (FinalPerScience > 40 && FinalPerScience < 51)
                    //    {
                    //        FinalGradeScience.Text = "C2";
                    //    }
                    //    else if (FinalPerScience > 32 && FinalPerScience < 41)
                    //    {
                    //        FinalGradeScience.Text = "D";
                    //    }
                    //    else if (FinalPerScience > 0 && FinalPerScience < 33)
                    //    {
                    //        FinalGradeScience.Text = "E";
                    //    }

                    //    // Grade For Sanskrit
                    //    if (FinalPerSanskrit > 90 && FinalPerSanskrit < 101)
                    //    {
                    //        FinalGradeSanskrit.Text = "A1";
                    //    }
                    //    else if (FinalPerSanskrit > 80 && FinalPerSanskrit < 91)
                    //    {
                    //        FinalGradeSanskrit.Text = "A2";
                    //    }
                    //    else if (FinalPerSanskrit > 70 && FinalPerSanskrit < 81)
                    //    {
                    //        FinalGradeSanskrit.Text = "B1";
                    //    }
                    //    else if (FinalPerSanskrit > 60 && FinalPerSanskrit < 71)
                    //    {
                    //        FinalGradeSanskrit.Text = "B2";
                    //    }
                    //    else if (FinalPerSanskrit > 50 && FinalPerSanskrit < 61)
                    //    {
                    //        FinalGradeSanskrit.Text = "C1";
                    //    }
                    //    else if (FinalPerSanskrit > 40 && FinalPerSanskrit < 51)
                    //    {
                    //        FinalGradeSanskrit.Text = "C2";
                    //    }
                    //    else if (FinalPerSanskrit > 32 && FinalPerSanskrit < 41)
                    //    {
                    //        FinalGradeSanskrit.Text = "D";
                    //    }
                    //    else if (FinalPerSanskrit > 0 && FinalPerSanskrit < 33)
                    //    {
                    //        FinalGradeSanskrit.Text = "E";
                    //    }

                    //    //Grade For Computer
                    //    if (FinalPerComputer > 90 && FinalPerComputer < 101)
                    //    {
                    //        FinalGradeComputer.Text = "A1";
                    //    }
                    //    else if (FinalPerComputer > 80 && FinalPerComputer < 91)
                    //    {
                    //        FinalGradeComputer.Text = "A2";
                    //    }
                    //    else if (FinalPerComputer > 70 && FinalPerComputer < 81)
                    //    {
                    //        FinalGradeComputer.Text = "B1";
                    //    }
                    //    else if (FinalPerComputer > 60 && FinalPerComputer < 71)
                    //    {
                    //        FinalGradeComputer.Text = "B2";
                    //    }
                    //    else if (FinalPerComputer > 50 && FinalPerComputer < 61)
                    //    {
                    //        FinalGradeComputer.Text = "C1";
                    //    }
                    //    else if (FinalPerComputer > 40 && FinalPerComputer < 51)
                    //    {
                    //        FinalGradeComputer.Text = "C2";
                    //    }
                    //    else if (FinalPerComputer > 32 && FinalPerComputer < 41)
                    //    {
                    //        FinalGradeComputer.Text = "D";
                    //    }
                    //    else if (FinalPerComputer > 0 && FinalPerComputer < 33)
                    //    {
                    //        FinalGradeComputer.Text = "E";
                    //    }
                    //}
                try
                {
                    //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                    strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=2 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
                    string remark = sExecuteReader(strQry);
                    //Suggestion.Text = remark;
                    
                    if (remark == "-2")
                    {
                        //Suggestion.Text = "NA";
                    }
                    else
                    {
                        //Suggestion.Text = remark;
                    }
                }
                catch
                {
                    //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                    //Response.End();
                }

                try
                {
                    //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                    strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=1 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
                    string area = sExecuteReader(strQry);
                   // AreaofStrength.Text = area;
                    if (area == "-2")
                    {
                        //AreaofStrength.Text = "NA";
                    }
                    else
                    {
                        //AreaofStrength.Text = area;
                    }
                }
                catch
                {
                    //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                    //Response.End();
                }

                crystalReport.Load(Server.MapPath(string.Format("Result_09Annual.rpt", i)));


                //AdmissionReport.ReportSource = crystalReport;
                //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                files.Add(PrepareBytes(stream1));

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

                
            }
            catch
            { 
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