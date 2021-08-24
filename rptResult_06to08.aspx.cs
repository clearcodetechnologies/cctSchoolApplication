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
     ConnectionInfo connectionInfo = new ConnectionInfo();
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
                string reportPath = Server.MapPath("rptresult06to08.rpt");
                crystalReport.Load(reportPath);

                //{Code Ny me
                TextObject Heading = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
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
                TextObject SubEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject SubMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                TextObject SubHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject SubSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject SubScience  = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
                TextObject SubSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject SubComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                TextObject SubDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];

                //Per Test Marks - I
                TextObject PerTestEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject PerTestMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];
                TextObject PerTestHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                TextObject PerTestSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                TextObject PerTestScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
                TextObject PerTestSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];
                TextObject PerTestComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];

                //NoteBook Mark - I
                TextObject NBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                TextObject NBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
                TextObject NBHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                TextObject NBSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                TextObject NBScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
                TextObject NBSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];
                TextObject NBComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];

                //Sub Enrichment - I
                TextObject SEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject SEMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text96"];
                TextObject SEHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                TextObject SESScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
                TextObject SEScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];
                TextObject SESanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                TextObject SEComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];

                //Half Yearly -  I
                TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];
                TextObject HYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                TextObject HYSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
                TextObject HYScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                TextObject HYSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                TextObject HYComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
               // TextObject HYDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];

                //Marks Obtained Half Yearly
                TextObject MOHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                TextObject MOHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                TextObject MOHYHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                TextObject MOHYSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
                TextObject MOHYScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                TextObject MOHYSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                TextObject MOHYComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];

                //Grade Half Yearly
                TextObject GradeEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject GradeMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                TextObject GradeHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
                TextObject GradeSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
                TextObject GradeScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];
                TextObject GradeSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                TextObject GradeComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                TextObject GradeDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];

                //Grand Total Half Yearly
                TextObject HYTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                TextObject HYPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];

                //Per Test Marks - II
                TextObject PerTestIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];
                TextObject PerTestIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                TextObject PerTestIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                TextObject PerTestIISScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                TextObject PerTestIIScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                TextObject PerTestIISanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text156"];
                TextObject PerTestIIComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text201"];

                //NoteBook Mark - II
                TextObject NBIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                TextObject NBIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                TextObject NBIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                TextObject NBIISScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                TextObject NBIIScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                TextObject NBIISanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                TextObject NBIIComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];

                //Sub Enrichment - II
                TextObject SEIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];
                TextObject SEIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                TextObject SEIIHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                TextObject SEIISScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                TextObject SEIIScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
                TextObject SEIISanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                TextObject SEIIComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text203"];

                //Annual Exam
                TextObject ANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                TextObject ANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                TextObject ANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                TextObject ANSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
                TextObject ANScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                TextObject ANSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text159"];
                TextObject ANComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];

                //Marks Obtained Annual Exam
                TextObject MOANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                TextObject MOANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
                TextObject MOANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                TextObject MOANSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                TextObject MOANScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];
                TextObject MOANSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                TextObject MOANComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];

                //Grade Annual Exam
                TextObject GradeANEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                TextObject GradeANMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                TextObject GradeANHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                TextObject GradeANSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
                TextObject GradeANScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                TextObject GradeANSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text161"];
                TextObject GradeANComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                TextObject GradeANDrawing = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];

                //Grand Total Annual
                TextObject ANTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text163"];
                TextObject ANPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];

                //Term I + II
                //Marks Obtained
                TextObject FinalEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text165"];
                TextObject FinalMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                TextObject FinalHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                TextObject FinalSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text168"];
                TextObject FinalScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                TextObject FinalSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text170"];
                TextObject FinalComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text207"];

                //Final Grade
                TextObject FinalGradeEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                TextObject FinalGradeMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text172"];
                TextObject FinalGradeHindi = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                TextObject FinalGradeSScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                TextObject FinalGradeScience = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text175"];
                TextObject FinalGradeSanskrit = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                TextObject FinalGradeComputer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                
                //Final Marks and Percentage
                TextObject FinalTotalMarks = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                TextObject FinalPercentage = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];

                //Co- Scholastic Areas Term- I
                //Subjects
                TextObject CSASub1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text177"];
                TextObject CSASub2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                TextObject CSASub3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text179"];
                TextObject CSASub4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];

                //Grade
                TextObject CSAGrade1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text181"];
                TextObject CSAGrade2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                TextObject CSAGrade3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                TextObject CSAGrade4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text184"];

             //Co-Scholastic Areas Term- II
                //Subjects
                TextObject CSAANSub1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];
                TextObject CSAANSub2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text186"];
                TextObject CSAANSub3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                TextObject CSAANSub4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
              
                //Grade
                TextObject CSAANGrade1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                TextObject CSAANGrade2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                TextObject CSAANGrade3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                TextObject CSAANGrade4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];


                crystalReport.SetParameterValue("Image", @"E:\Application UAT live\wwwroot\NPST\Uttarakhand\SKP new back up\SKSchoolApi\SKSchoolApi\image\01_06_2019_10_21_23_80.jpg");

                //if (crystalReport.Section.ReportObjects["Picture1"].Kind == ReportObjectKind.PictureObject)
                {
                    //crReportDocument.Section1.ReportObjects["Picture1"];
                }


                //}

               
                //TextObject Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                //TextObject HindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                //TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                //TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                //TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                //TextObject Evs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                //TextObject LHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                //TextObject Comp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text263"];
                //TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text264"];

        
                //TextObject MOEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                //TextObject MOHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text168"];
                //TextObject MOmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                //TextObject MOsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text170"];
                //TextObject MOSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                //TextObject MOEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text172"];
                //TextObject MOLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                //TextObject MOComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text271"];
                //TextObject MOEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text272"];

                //TextObject GREng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                //TextObject GRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text175"];
                //TextObject GRmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                //TextObject GRsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text177"];
                //TextObject GRSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                //TextObject GREvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text179"];
                //TextObject GRLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                //TextObject GRComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text273"];
                //TextObject GREVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text274"];

                //TextObject SUBWEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                //TextObject SUBAEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                //TextObject SUBHPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                //TextObject SUBLSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                //TextObject SUBDHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
                //TextObject SUBMUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                //TextObject SUBPTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];

                //TextObject WEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text223"];
                //TextObject AEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                //TextObject HPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                //TextObject LSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text226"];
                //TextObject DHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                //TextObject MUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text228"];
                //TextObject PTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];

                //TextObject SUBRPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                //TextObject SUBSIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                //TextObject SUBBVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                //TextObject SUBRRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                //TextObject SUBATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                //TextObject SUBATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                //TextObject SUBASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
                //TextObject SUBATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

                //TextObject RPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text237"];
                //TextObject SIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];
                //TextObject BVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text239"];
                //TextObject RRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                //TextObject ATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                //TextObject ATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                //TextObject ASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                //TextObject ATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];

                //TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text254"];
                //TextObject AreaofStrength = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];

                //TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                //TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                //TextObject StudentId = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];



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


                //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";

                //strQry = "Execute dbo.spStudentResult @intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
                strQry = "Execute dbo.sp_StudetntAnnualResult @intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
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
                int HYMarksSScience=0;
                int HYMarksScience=0;
                int HYMarksSanskrit=0;
                int HYMarksComputer = 0;

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
                        SubSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubComp.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
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
                        PerTestSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Per. Test"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PerTestComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Per. Test"]);
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
                        NBSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        NBComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
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
                        SESanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SEComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
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
                        HYSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        HYComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly Exam"]);
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
                        MOHYSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);

                        HYMarksSanskrit = Convert.ToInt32(MOHYSanskrit.Text); 
                    }
                    catch
                    {

                    }
                    try
                    {
                        MOHYComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);

                        HYMarksComputer = Convert.ToInt32(MOHYComputer.Text);
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
                        GradeSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        GradeDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Grade"]);
                    }
                    catch
                    {

                    }
                         

                }
                //Half Yearly Grand Total and Percentage
                int HYGrandTotal = HYMarksEng + HYMarksMath + HYMarksHindi + HYMarksScience + HYMarksSScience + HYMarksSanskrit + HYMarksComputer;
                HYTotal.Text = Convert.ToString(HYGrandTotal);
                float HYPer = (float)HYGrandTotal / 7;
                HYPer = (float)System.Math.Round(HYPer, 2);
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
                                    PerTestIISScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIISanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Per. Test-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    PerTestIIComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Per. Test-II"]);
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
                                    NBIISScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIISanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book	-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    NBIIComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book	-II"]);
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
                                    SEIISScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIISanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment-II"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    SEIIComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment-II"]);
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
                                    ANSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    ANComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                                }
                                catch
                                {

                                }
                                try
                                {



                                    MOANEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalAnnual"]);
                                    ANMarksEng = Convert.ToInt32(MOANEng.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANMath.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["TotalAnnual"]);
                                    ANMarksMath  = Convert.ToInt32(MOANMath.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANHindi.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["TotalAnnual"]);
                                    ANMarksHindi = Convert.ToInt32(MOANHindi.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["TotalAnnual"]);
                                    ANMarksSScience = Convert.ToInt32(MOANSScience.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["TotalAnnual"]);
                                    ANMarksScience = Convert.ToInt32(MOANScience.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["TotalAnnual"]);
                                    ANMarksSanskrit = Convert.ToInt32(MOANSanskrit.Text);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    MOANComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["TotalAnnual"]);
                                    ANMarksComputer = Convert.ToInt32(MOANComputer.Text);
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
                                    GradeANSScience.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANScience.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANSanskrit.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANComputer.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GradeAnnual"]);
                                }
                                catch
                                {

                                }
                                try
                                {
                                    GradeANDrawing.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GradeAnnual"]);
                                }
                                catch
                                {

                                }

                            }

                            //Annual Yearly Grand Total and Percentage
                           int ANGrandTotal = ANMarksEng + ANMarksMath + ANMarksHindi + ANMarksScience + ANMarksSScience + ANMarksSanskrit + ANMarksComputer;
                            ANTotal.Text = Convert.ToString(ANGrandTotal);
                            float ANPer = (float)ANGrandTotal / 7;
                            ANPer = (float)System.Math.Round(ANPer, 2); ;
                            ANPercentage.Text = Convert.ToString(ANPer);


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
              

                    //Total I + II 
                        int TotalEng = HYMarksEng + ANMarksEng;
                        int TotalMath = HYMarksMath + ANMarksMath;
                        int TotalHindi = HYMarksHindi + ANMarksHindi;
                        int TotalSScience = HYMarksSScience + ANMarksSScience;
                        int TotalScience = HYMarksScience + ANMarksScience;
                        int TotalSanskrit = HYMarksSanskrit + ANMarksSanskrit;
                        int TotalComputer = HYMarksComputer + ANMarksComputer;

                        if (Convert.ToString(Session["Exam_id"]) == "Term 2")
                        {
                        FinalEng.Text = Convert.ToString(TotalEng);
                        FinalMath.Text = Convert.ToString(TotalMath);
                        FinalHindi.Text = Convert.ToString(TotalHindi);
                        FinalSScience.Text = Convert.ToString(TotalSScience);
                        FinalScience.Text = Convert.ToString(TotalScience );
                        FinalSanskrit.Text = Convert.ToString(TotalSanskrit);
                        FinalComputer.Text = Convert.ToString(TotalComputer);

                    float FinalPerEng = TotalEng /  2;
                    float FinalPerMath = TotalMath / 2;
                    float FinalPerHindi = TotalHindi / 2;
                    float FinalPerSScience = TotalSScience / 2;
                    float FinalPerScience = TotalScience / 2;
                    float FinalPerSanskrit = TotalSanskrit / 2;
                    float FinalPerComputer = TotalComputer / 2;

                    int FinalTotalMarkss = TotalEng + TotalMath + TotalHindi + TotalSScience + TotalScience + TotalSanskrit + TotalComputer;
                    FinalTotalMarks.Text = Convert.ToString(FinalTotalMarkss);

                    float FinalPercentagee = (float)FinalTotalMarkss / 14;
                    FinalPercentagee = (float)System.Math.Round(FinalPercentagee, 2);
                    FinalPercentage.Text = Convert.ToString(FinalPercentagee);

                   
                        //Grade For English
                        if (FinalPerEng > 90 && FinalPerEng < 101)
                        {
                            FinalGradeEng.Text = "A1";
                        }
                        else if (FinalPerEng > 80 && FinalPerEng < 91)
                        {
                            FinalGradeEng.Text = "A2";
                        }
                        else if (FinalPerEng > 70 && FinalPerEng < 81)
                        {
                            FinalGradeEng.Text = "B1";
                        }
                        else if (FinalPerEng > 60 && FinalPerEng < 71)
                        {
                            FinalGradeEng.Text = "B2";
                        }
                        else if (FinalPerEng > 50 && FinalPerEng < 61)
                        {
                            FinalGradeEng.Text = "C1";
                        }
                        else if (FinalPerEng > 40 && FinalPerEng < 51)
                        {
                            FinalGradeEng.Text = "C2";
                        }
                        else if (FinalPerEng > 32 && FinalPerEng < 41)
                        {
                            FinalGradeEng.Text = "D";
                        }
                        else if (FinalPerEng > 0 && FinalPerEng < 33)
                        {
                            FinalGradeEng.Text = "E";
                        }

                        //Grade for Maths
                        if (FinalPerMath > 90 && FinalPerMath < 101)
                        {
                            FinalGradeMath.Text = "A1";
                        }
                        else if (FinalPerMath > 80 && FinalPerMath < 91)
                        {
                            FinalGradeMath.Text = "A2";
                        }
                        else if (FinalPerMath > 70 && FinalPerMath < 81)
                        {
                            FinalGradeMath.Text = "B1";
                        }
                        else if (FinalPerMath > 60 && FinalPerMath < 71)
                        {
                            FinalGradeMath.Text = "B2";
                        }
                        else if (FinalPerMath > 50 && FinalPerMath < 61)
                        {
                            FinalGradeMath.Text = "C1";
                        }
                        else if (FinalPerMath > 40 && FinalPerMath < 51)
                        {
                            FinalGradeMath.Text = "C2";
                        }
                        else if (FinalPerMath > 32 && FinalPerMath < 41)
                        {
                            FinalGradeMath.Text = "D";
                        }
                        else if (FinalPerMath > 0 && FinalPerMath < 33)
                        {
                            FinalGradeMath.Text = "E";
                        }

                        // Grade for Hindi
                        if (FinalPerHindi > 90 && FinalPerHindi < 101)
                        {
                            FinalGradeHindi.Text = "A1";
                        }
                        else if (FinalPerHindi > 80 && FinalPerHindi < 91)
                        {
                            FinalGradeHindi.Text = "A2";
                        }
                        else if (FinalPerHindi > 70 && FinalPerHindi < 81)
                        {
                            FinalGradeHindi.Text = "B1";
                        }
                        else if (FinalPerHindi > 60 && FinalPerHindi < 71)
                        {
                            FinalGradeHindi.Text = "B2";
                        }
                        else if (FinalPerHindi > 50 && FinalPerHindi < 61)
                        {
                            FinalGradeHindi.Text = "C1";
                        }
                        else if (FinalPerHindi > 40 && FinalPerHindi < 51)
                        {
                            FinalGradeHindi.Text = "C2";
                        }
                        else if (FinalPerHindi > 32 && FinalPerHindi < 41)
                        {
                            FinalGradeHindi.Text = "D";
                        }
                        else if (FinalPerHindi > 0 && FinalPerHindi < 33)
                        {
                            FinalGradeHindi.Text = "E";
                        }

                        //Grade For Social Science
                        if (FinalPerSScience > 90 && FinalPerSScience < 101)
                        {
                            FinalGradeSScience.Text = "A1";
                        }
                        else if (FinalPerSScience > 80 && FinalPerSScience < 91)
                        {
                            FinalGradeSScience.Text = "A2";
                        }
                        else if (FinalPerSScience > 70 && FinalPerSScience < 81)
                        {
                            FinalGradeSScience.Text = "B1";
                        }
                        else if (FinalPerSScience > 60 && FinalPerSScience < 71)
                        {
                            FinalGradeSScience.Text = "B2";
                        }
                        else if (FinalPerSScience > 50 && FinalPerSScience < 61)
                        {
                            FinalGradeSScience.Text = "C1";
                        }
                        else if (FinalPerSScience > 40 && FinalPerSScience < 51)
                        {
                            FinalGradeSScience.Text = "C2";
                        }
                        else if (FinalPerSScience > 32 && FinalPerSScience < 41)
                        {
                            FinalGradeSScience.Text = "D";
                        }
                        else if (FinalPerSScience > 0 && FinalPerSScience < 33)
                        {
                            FinalGradeSScience.Text = "E";
                        }

                        // Grade for Science
                        if (FinalPerScience > 90 && FinalPerScience < 101)
                        {
                            FinalGradeScience.Text = "A1";
                        }
                        else if (FinalPerScience > 80 && FinalPerScience < 91)
                        {
                            FinalGradeScience.Text = "A2";
                        }
                        else if (FinalPerScience > 70 && FinalPerScience < 81)
                        {
                            FinalGradeScience.Text = "B1";
                        }
                        else if (FinalPerScience > 60 && FinalPerScience < 71)
                        {
                            FinalGradeScience.Text = "B2";
                        }
                        else if (FinalPerScience > 50 && FinalPerScience < 61)
                        {
                            FinalGradeScience.Text = "C1";
                        }
                        else if (FinalPerScience > 40 && FinalPerScience < 51)
                        {
                            FinalGradeScience.Text = "C2";
                        }
                        else if (FinalPerScience > 32 && FinalPerScience < 41)
                        {
                            FinalGradeScience.Text = "D";
                        }
                        else if (FinalPerScience > 0 && FinalPerScience < 33)
                        {
                            FinalGradeScience.Text = "E";
                        }

                        // Grade For Sanskrit
                        if (FinalPerSanskrit > 90 && FinalPerSanskrit < 101)
                        {
                            FinalGradeSanskrit.Text = "A1";
                        }
                        else if (FinalPerSanskrit > 80 && FinalPerSanskrit < 91)
                        {
                            FinalGradeSanskrit.Text = "A2";
                        }
                        else if (FinalPerSanskrit > 70 && FinalPerSanskrit < 81)
                        {
                            FinalGradeSanskrit.Text = "B1";
                        }
                        else if (FinalPerSanskrit > 60 && FinalPerSanskrit < 71)
                        {
                            FinalGradeSanskrit.Text = "B2";
                        }
                        else if (FinalPerSanskrit > 50 && FinalPerSanskrit < 61)
                        {
                            FinalGradeSanskrit.Text = "C1";
                        }
                        else if (FinalPerSanskrit > 40 && FinalPerSanskrit < 51)
                        {
                            FinalGradeSanskrit.Text = "C2";
                        }
                        else if (FinalPerSanskrit > 32 && FinalPerSanskrit < 41)
                        {
                            FinalGradeSanskrit.Text = "D";
                        }
                        else if (FinalPerSanskrit > 0 && FinalPerSanskrit < 33)
                        {
                            FinalGradeSanskrit.Text = "E";
                        }

                        //Grade For Computer
                        if (FinalPerComputer > 90 && FinalPerComputer < 101)
                        {
                            FinalGradeComputer.Text = "A1";
                        }
                        else if (FinalPerComputer > 80 && FinalPerComputer < 91)
                        {
                            FinalGradeComputer.Text = "A2";
                        }
                        else if (FinalPerComputer > 70 && FinalPerComputer < 81)
                        {
                            FinalGradeComputer.Text = "B1";
                        }
                        else if (FinalPerComputer > 60 && FinalPerComputer < 71)
                        {
                            FinalGradeComputer.Text = "B2";
                        }
                        else if (FinalPerComputer > 50 && FinalPerComputer < 61)
                        {
                            FinalGradeComputer.Text = "C1";
                        }
                        else if (FinalPerComputer > 40 && FinalPerComputer < 51)
                        {
                            FinalGradeComputer.Text = "C2";
                        }
                        else if (FinalPerComputer > 32 && FinalPerComputer < 41)
                        {
                            FinalGradeComputer.Text = "D";
                        }
                        else if (FinalPerComputer > 0 && FinalPerComputer < 33)
                        {
                            FinalGradeComputer.Text = "E";
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

                crystalReport.Load(Server.MapPath(string.Format("rptresult06to08.rpt", i)));


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



    protected void Export(object sender, EventArgs e)
    {
        ExportFormatType formatType = ExportFormatType.NoFormat;
        switch (rbFormat.SelectedItem.Value)
        {
            case "Word":
                formatType = ExportFormatType.WordForWindows;
                break;
            case "PDF":
                formatType = ExportFormatType.PortableDocFormat;
                break;
            case "Excel":
                formatType = ExportFormatType.Excel;
                break;
            case "CSV":
                formatType = ExportFormatType.CharacterSeparatedValues;
                break;
        }

        crystalReport.ExportToHttpResponse(formatType, Response, true, "rptresult06to08.rpt");
        Response.End();
    }


}