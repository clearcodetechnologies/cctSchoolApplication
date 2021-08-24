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
                string reportPath = Server.MapPath("rptresult1to5.rpt");
                crystalReport.Load(reportPath);

                //{Code Ny me
                TextObject Heading = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
                Heading.Text = "ACHIEVEMENT RECORD ACADEMIC YEAR (" + Session["AcademicYearName"] + ")";
                //Student Profile
                TextObject AdmnNo = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text4"];
                TextObject Studentnm = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text8"];
                TextObject Mothernm = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text12"];
                TextObject Fathernm = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text16"];
                TextObject Address = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text18"];
                TextObject DOB = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text6"];
                TextObject ContactNo = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text10"];
                TextObject AadharNo = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text14"];
                TextObject Std = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text20"];
                TextObject Div = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text22"];

                //Academic Performance
                TextObject SubEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text80"];
                TextObject SubMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text81"];
                TextObject SubHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text82"];
                TextObject SubEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text83"];
                TextObject SubComp  = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text84"];
                TextObject SubGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text85"];
                TextObject SubDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text86"];

                //Per Test Marks - I
                TextObject PerTestEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text87"];
                TextObject PerTestMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text94"];
                TextObject PerTestHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text100"];
                TextObject PerTestEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text106"];
                TextObject PerTestComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text112"];
                TextObject PerTestGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text118"];

                //NoteBook Mark - I
                TextObject NBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text88"];
                TextObject NBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text95"];
                TextObject NBHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text101"];
                TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text107"];
                TextObject NBComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text113"];
                TextObject NBGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text119"];

                //Sub Enrichment - I
                TextObject SEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text89"];
                TextObject SEMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text96"];
                TextObject SEHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text102"];
                TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text108"];
                TextObject SEComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text114"];
                TextObject SEGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text120"];

                //Half Yearly -  I
                TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text90"];
                TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text97"];
                TextObject HYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text103"];
                TextObject HYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text109"];
                TextObject HYComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text115"];
                TextObject HYGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text121"];

                //Marks Obtained Half Yearly
                TextObject MOHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text91"];
                TextObject MOHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text98"];
                TextObject MOHYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text104"];
                TextObject MOHYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text110"];
                TextObject MOHYComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text116"];
                TextObject MOHYGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text122"];

                //Grade Half Yearly
                TextObject GradeEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text92"];
                TextObject GradeMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text99"];
                TextObject GradeHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text105"];
                TextObject GradeEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text111"];
                TextObject GradeComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text117"];
                TextObject GradeGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text123"];
                TextObject GradeDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text124"];

                //Grand Total Half Yearly
                TextObject HYTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text125"];
                TextObject HYPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text126"];

                //Per Test Marks - II
                TextObject PerTestIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text93"];
                TextObject PerTestIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text132"];
                TextObject PerTestIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text138"];
                TextObject PerTestIIEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text144"];
                TextObject PerTestIIComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text150"];
                TextObject PerTestIIGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text156"];

                //NoteBook Mark - II
                TextObject NBIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text127"];
                TextObject NBIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text133"];
                TextObject NBIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text139"];
                TextObject NBIIEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text145"];
                TextObject NBIIComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text151"];
                TextObject NBIIGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text157"];

                //Sub Enrichment - II
                TextObject SEIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text128"];
                TextObject SEIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text134"];
                TextObject SEIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text140"];
                TextObject SEIIEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text146"];
                TextObject SEIIComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text152"];
                TextObject SEIIGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text158"];

                //Annual Exam
                TextObject ANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text129"];
                TextObject ANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text135"];
                TextObject ANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text141"];
                TextObject ANEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text147"];
                TextObject ANComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text153"];
                TextObject ANGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text159"];

                //Marks Obtained Annual Exam
                TextObject MOANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text130"];
                TextObject MOANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text136"];
                TextObject MOANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text142"];
                TextObject MOANEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text148"];
                TextObject MOANComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text154"];
                TextObject MOANGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text160"];

                //Grade Annual Exam
                TextObject GradeANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text131"];
                TextObject GradeANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text137"];
                TextObject GradeANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text143"];
                TextObject GradeANEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text149"];
                TextObject GradeANComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text155"];
                TextObject GradeANGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text161"];
                TextObject GradeANDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text162"];

                //Grand Total Annual
                TextObject ANTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text163"];
                TextObject ANPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text164"];

                //Term I + II
                //Marks Obtained
                TextObject FinalEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text165"];
                TextObject FinalMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text166"];
                TextObject FinalHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text167"];
                TextObject FinalEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text168"];
                TextObject FinalComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text169"];
                TextObject FinalGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text170"];

                //Final Grade
                TextObject FinalGradeEng = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text171"];
                TextObject FinalGradeMath = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text172"];
                TextObject FinalGradeHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text173"];
                TextObject FinalGradeEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text174"];
                TextObject FinalGradeComp = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text175"];
                TextObject FinalGradeGK = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text176"];
                
                // Final Total And Percentage
                TextObject FinalTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text193"];
                TextObject FinalPer = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text194"];

                //Co- Scholastic Areas Term- I
                //Subjects
                TextObject CSASub1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                TextObject CSASub2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text210"];
                TextObject CSASub3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                TextObject CSASub4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text212"];

                //Grade
                TextObject CSAGrade1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                TextObject CSAGrade2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text214"];
                TextObject CSAGrade3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                TextObject CSAGrade4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text216"];

             //Co-Scholastic Areas Term- II
                //Subjects
                TextObject CSAANSub1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                TextObject CSAANSub2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                TextObject CSAANSub3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text219"];
                TextObject CSAANSub4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];
              
                //Grade
                TextObject CSAANGrade1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text221"];
                TextObject CSAANGrade2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                TextObject CSAANGrade3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text223"];
                TextObject CSAANGrade4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];


                //}

               //Term II Grand Total and percentage
                int TotalEng = 0, TotalMath = 0, TotalHindi = 0, TotalEVS = 0, TotalComputer = 0, TotalGK = 0;
                


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
                }
                //Half Yearly variables for total and percentage
                int HYMarksEng = 0;
                int HYMarksMath = 0;
                int HYMarksHindi = 0;
                int HYMarksEVS=0;
                int HYMarksComp=0;
                int HYMarksGK=0;

                strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "',@intSubcat_id=1";
                dsObj = sGetDataset(strQry);
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
                        SubEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
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
                        PerTestEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Per. Test"]);
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
                        NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
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
                        SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
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
                        HYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
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
                        MOHYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);

                         HYMarksEVS = Convert.ToInt32(MOHYEVS.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);

                         HYMarksComp = Convert.ToInt32(MOHYComp.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);

                         HYMarksGK = Convert.ToInt32(MOHYGK.Text); 
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
                        GradeEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                    }
                    catch
                    {

                    }
                         

                }
                //Half Yearly Grand Total and Percentage
                int HYGrandTotal = HYMarksEng + HYMarksMath + HYMarksHindi + HYMarksComp + HYMarksEVS + HYMarksGK;
                float HYPer = (float)HYGrandTotal / 6;
                HYPer = (float)System.Math.Round(HYPer, 2); 
                HYTotal.Text = Convert.ToString(HYGrandTotal);
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
                        string test = Convert.ToString(Session["Exam_id"]);
                        if (Convert.ToString(Session["Exam_id"]) == "Term 2")
                        {
                            strQry = "exec usp_ExamMarks @type='ExamMarksAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "',@intSubcat_id=1";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {

                                try
                                {

                                    PerTestIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Per. Test-II"]);
                                }
                                catch
                                {

                                }

                                try
                                {




                                    NBIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book	-II"]);
                                }
                                catch
                                {

                                }

                                try
                                {



                                    SEIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }

                                try
                                {
                                    ANEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                                    
                                }
                                catch
                                {

                                }

                                try
                                {



                                    MOANEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalAnnual"]);
                                    TotalEng = Convert.ToInt32(MOANEng.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["TotalAnnual"]);
                                    TotalMath = Convert.ToInt32(MOANMath.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["TotalAnnual"]);
                                    TotalHindi = Convert.ToInt32(MOANHindi.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["TotalAnnual"]);
                                    TotalEVS = Convert.ToInt32(MOANEVS.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["TotalAnnual"]);
                                    TotalComputer = Convert.ToInt32(MOANComp.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["TotalAnnual"]);
                                    TotalGK = Convert.ToInt32(MOANGK.Text);
                                }
                                catch
                                {

                                }

                                try
                                {


                                    GradeANEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANComp.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANGK.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GradeAnnual"]);
                                }
                                catch
                                {

                                }

                            }

                            if (Convert.ToString(Session["Exam_id"]) == "Term 2")
                            {
                                //Annual Total Marks

                                int GrandTotal = TotalEng + TotalMath + TotalHindi + TotalEVS + TotalComputer + TotalGK;
                                ANTotal.Text = Convert.ToString(GrandTotal);
                                float finalper = (float)GrandTotal / 6;
                                finalper = (float)System.Math.Round(finalper,2);
                                ANPercentage.Text = Convert.ToString(finalper);

                                //Term I + II Total Marks and Grade
                                int FinalMarksEng = 0, FinalMarksMath = 0, FinalMarksHindi = 0, FinalMarksEVS = 0, FinalMarksComputer = 0, FinalMarksGk = 0;
                                FinalMarksEng = HYMarksEng + TotalEng;
                                FinalEng.Text = Convert.ToString(FinalMarksEng);

                                FinalMarksMath = HYMarksMath + TotalMath;
                                FinalMath.Text = Convert.ToString(FinalMarksMath);

                                FinalMarksHindi = HYMarksHindi + TotalHindi;
                                FinalHindi.Text = Convert.ToString(FinalMarksHindi);

                                FinalMarksEVS = HYMarksEVS  + TotalEVS ;
                                FinalEVS.Text = Convert.ToString(FinalMarksEVS);

                                FinalMarksComputer = HYMarksComp + TotalComputer;
                                FinalComp.Text = Convert.ToString(FinalMarksComputer);

                                FinalMarksGk = HYMarksGK + TotalGK;
                                FinalGK.Text = Convert.ToString(FinalMarksGk);

                                int Grandtotal = FinalMarksEng + FinalMarksMath + FinalMarksHindi + FinalMarksEVS + FinalMarksComputer + FinalMarksGk;
                                float Grandper1 = (float)Grandtotal / 12;
                                Grandper1 = (float)System.Math.Round(Grandper1, 2);
                                FinalTotal.Text = Convert.ToString(Grandtotal);
                                FinalPer.Text = Convert.ToString(Grandper1);

                               float englishgrade =(float)FinalMarksEng/2;
                               // Grade For English
                               if (FinalMarksEng / 2 >= 91 && FinalMarksEng / 2 <= 100)
                                    {
                                        FinalGradeEng.Text = "A1";
                                    }
                               else if (FinalMarksEng / 2 >= 81 && FinalMarksEng / 2 <= 90)
                                    {
                                        FinalGradeEng.Text = "A2";
                                    }
                               else if (FinalMarksEng / 2 >= 71 && FinalMarksEng / 2 <= 80)
                                    {
                                        FinalGradeEng.Text = "B1";
                                    }
                                    else if (FinalMarksEng/2 >= 61 && FinalMarksEng/2 <= 70)
                                    {
                                        FinalGradeEng.Text = "B2";
                                    }
                                    else if (FinalMarksEng/2 >= 51 && FinalMarksEng/2 <= 60)
                                    {
                                        FinalGradeEng.Text = "C1";
                                    }
                                    else if (FinalMarksEng/2 >= 41 && FinalMarksEng/2 <= 50)
                                    {
                                        FinalGradeEng.Text = "C2";
                                    }
                                    else if (FinalMarksEng/2 > 33 && FinalMarksEng/2 < 41)
                                    {
                                        FinalGradeEng.Text = "D";
                                    }
                                    else if (FinalMarksEng/2 >= 0 && FinalMarksEng/2 <= 32)
                                    {
                                        FinalGradeEng.Text = "E";
                                    }

                                //    //Grade for Maths
                                    if (FinalMarksMath/2 >= 91 && FinalMarksMath/2 <= 100)
                                    {
                                        FinalGradeMath.Text = "A1";
                                    }
                                    else if (FinalMarksMath/2 >= 81 && FinalMarksMath/2 <= 90)
                                    {
                                        FinalGradeMath.Text = "A2";
                                    }
                                    else if (FinalMarksMath/2 >= 71 && FinalMarksMath/2 <= 80)
                                    {
                                        FinalGradeMath.Text = "B1";
                                    }
                                    else if (FinalMarksMath/2 >= 61 && FinalMarksMath/2 <= 70)
                                    {
                                        FinalGradeMath.Text = "B2";
                                    }
                                    else if (FinalMarksMath/2 >= 51 && FinalMarksMath/2 <= 60)
                                    {
                                        FinalGradeMath.Text = "C1";
                                    }
                                    else if (FinalMarksMath/2 >= 41 && FinalMarksMath/2 <= 50)
                                    {
                                        FinalGradeMath.Text = "C2";
                                    }
                                    else if (FinalMarksMath/2 >= 33 && FinalMarksMath/2 <= 40)
                                    {
                                        FinalGradeMath.Text = "D";
                                    }
                                    else if (FinalMarksMath/2 >= 0 && FinalMarksMath/2 <= 32)
                                    {
                                        FinalGradeMath.Text = "E";
                                    }

                                //    // Grade for Hindi
                                    if (FinalMarksHindi/2 >= 91 && FinalMarksHindi/2 <= 100)
                                    {
                                        FinalGradeHindi.Text = "A1";
                                    }
                                    else if (FinalMarksHindi/2 >= 81 && FinalMarksHindi/2 <= 90)
                                    {
                                        FinalGradeHindi.Text = "A2";
                                    }
                                    else if (FinalMarksHindi/2 >= 71 && FinalMarksHindi/2 <= 80)
                                    {
                                        FinalGradeHindi.Text = "B1";
                                    }
                                    else if (FinalMarksHindi/2 >= 61 && FinalMarksHindi/2 <= 70)
                                    {
                                        FinalGradeHindi.Text = "B2";
                                    }
                                    else if (FinalMarksHindi/2 >= 51 && FinalMarksHindi/2 <= 60)
                                    {
                                        FinalGradeHindi.Text = "C1";
                                    }
                                    else if (FinalMarksHindi/2 >= 41 && FinalMarksHindi/2 <= 50)
                                    {
                                        FinalGradeHindi.Text = "C2";
                                    }
                                    else if (FinalMarksHindi/2 >= 33 && FinalMarksHindi/2 <= 40)
                                    {
                                        FinalGradeHindi.Text = "D";
                                    }
                                    else if (FinalMarksHindi/2 >= 0 && FinalMarksHindi/2 <= 32)
                                    {
                                        FinalGradeHindi.Text = "E";
                                    }

                                //    //Grade For Social Science
                                    if (FinalMarksEVS/2 >= 91 && FinalMarksEVS/2 <= 100)
                                    {
                                        FinalGradeEVS.Text = "A1";
                                    }
                                    else if (FinalMarksEVS/2 >= 81 && FinalMarksEVS/2 <= 90)
                                    {
                                        FinalGradeEVS.Text = "A2";
                                    }
                                    else if (FinalMarksEVS/2 >= 71 && FinalMarksEVS/2 <= 80)
                                    {
                                        FinalGradeEVS.Text = "B1";
                                    }
                                    else if (FinalMarksEVS/2 >= 61 && FinalMarksEVS/2 <= 70)
                                    {
                                        FinalGradeEVS.Text = "B2";
                                    }
                                    else if (FinalMarksEVS/2 >= 51 && FinalMarksEVS/2 <= 60)
                                    {
                                        FinalGradeEVS.Text = "C1";
                                    }
                                    else if (FinalMarksEVS/2 >= 41 && FinalMarksEVS/2 <= 50)
                                    {
                                        FinalGradeEVS.Text = "C2";
                                    }
                                    else if (FinalMarksEVS/2 >= 33 && FinalMarksEVS/2 <= 40)
                                    {
                                        FinalGradeEVS.Text = "D";
                                    }
                                    else if (FinalMarksEVS/2 >= 0 && FinalMarksEVS/2 <= 32)
                                    {
                                        FinalGradeEVS.Text = "E";
                                    }

                                //    // Grade for Science
                                    if (FinalMarksComputer/2 >= 91 && FinalMarksComputer/2 <= 100)
                                    {
                                        FinalGradeComp.Text = "A1";
                                    }
                                    else if (FinalMarksComputer/2 >= 81 && FinalMarksComputer/2 <= 91)
                                    {
                                        FinalGradeComp.Text = "A2";
                                    }
                                    else if (FinalMarksComputer/2 >= 71 && FinalMarksComputer/2 <= 80)
                                    {
                                        FinalGradeComp.Text = "B1";
                                    }
                                    else if (FinalMarksComputer/2 >= 61 && FinalMarksComputer/2 <= 70)
                                    {
                                        FinalGradeComp.Text = "B2";
                                    }
                                    else if (FinalMarksComputer/2 >= 51 && FinalMarksComputer/2 <= 60)
                                    {
                                        FinalGradeComp.Text = "C1";
                                    }
                                    else if (FinalMarksComputer/2 >= 41 && FinalMarksComputer/2 <= 50)
                                    {
                                        FinalGradeComp.Text = "C2";
                                    }
                                    else if (FinalMarksComputer/2 >= 33 && FinalMarksComputer/2 <= 40)
                                    {
                                        FinalGradeComp.Text = "D";
                                    }
                                    else if (FinalMarksComputer/2 >= 0 && FinalMarksComputer/2 <= 32)
                                    {
                                        FinalGradeComp.Text = "E";
                                    }

                                //    // Grade For Sanskrit
                                    if (FinalMarksGk/2 >= 91 && FinalMarksGk/2 <= 100)
                                    {
                                        FinalGradeGK.Text = "A1";
                                    }
                                    else if (FinalMarksGk/2 >= 81 && FinalMarksGk/2 <= 90)
                                    {
                                        FinalGradeGK.Text = "A2";
                                    }
                                    else if (FinalMarksGk/2 >= 71 && FinalMarksGk/2 <= 80)
                                    {
                                        FinalGradeGK.Text = "B1";
                                    }
                                    else if (FinalMarksGk/2 >= 61 && FinalMarksGk/2 <= 70)
                                    {
                                        FinalGradeGK.Text = "B2";
                                    }
                                    else if (FinalMarksGk/2 >= 51 && FinalMarksGk/2 <= 60)
                                    {
                                        FinalGradeGK.Text = "C1";
                                    }
                                    else if (FinalMarksGk/2 >= 41 && FinalMarksGk/2 <= 50)
                                    {
                                        FinalGradeGK.Text = "C2";
                                    }
                                    else if (FinalMarksGk/2 >= 33 && FinalMarksGk/2 <= 40)
                                    {
                                        FinalGradeGK.Text = "D";
                                    }
                                    else if (FinalMarksGk/2 >= 0 && FinalMarksGk/2 <= 32)
                                    {
                                        FinalGradeGK.Text = "E";
                                    }

                             
                            }
                        

                            strQry = "exec usp_ExamMarks @type='ExamMarksAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intSubcat_id=2";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                try
                                {
                                    CSAANSub1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAANSub2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    CSAANSub3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    CSAANSub4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                                }
                                catch
                                {

                                }

                                try
                                {
                                    CSAANGrade1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAANGrade2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAANGrade3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    CSAANGrade4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                                }
                                catch
                                {
                                }

                            }
                        }
                

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

                crystalReport.Load(Server.MapPath(string.Format("rptresult1to5.rpt", i)));


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