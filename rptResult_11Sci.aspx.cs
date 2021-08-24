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
                string reportPath = Server.MapPath("rptResult_11Sci.rpt");
                crystalReport.Load(reportPath);

                //{Code By Me
                TextObject Heading = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
                Heading.Text = "ACHIEVEMENT RECORD ACADEMIC YEAR (" + Session["AcademicYearName"] + ")";

                //Student Profile
                TextObject AdmnNo = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text4"];
                TextObject Studentnm = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text8"];
                TextObject Mothernm = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text12"];
                TextObject Fathernm = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text16"];
                TextObject Address = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text18"];
                TextObject DOB = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text6"];
                TextObject ContactNo = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text10"];
                TextObject AadharNo = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text14"];
                TextObject Std = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text20"];
                TextObject Div = (TextObject)crystalReport.ReportDefinition.Sections["Section2"].ReportObjects["Text22"];

                //Academic Performance
                TextObject SubEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text32"];
                TextObject SubBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
                TextObject SubPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
                TextObject SubChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
                TextObject SubPhysicalEdu  = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
               
                //Term -I Theroy
                TextObject TH1Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
                TextObject TH1Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
                TextObject TH1Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                TextObject TH1Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                TextObject TH1PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
              
                //Term - I Practical
                TextObject PR1Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                TextObject PR1Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject PR1Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                TextObject PR1Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
                TextObject PR1PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
               
                //Term -I Total
                TextObject TotalEng1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
                TextObject TotalBio1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
                TextObject TotalPhysics1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                TextObject TotalChemistry1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                TextObject TotalPhysicalEdu1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];


                //Term -II Theroy
                TextObject TH2Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                TextObject TH2Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                TextObject TH2Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                TextObject TH2Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject TH2PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];

                //Term - II Practical
                TextObject PR2Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject PR2Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject PR2Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
                TextObject PR2Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject PR2PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];

                //Term -II Total
                TextObject TotalEng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject TotalBio2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                TextObject TotalPhysics2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject TotalChemistry2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                TextObject TotalPhysicalEdu2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];

                //Term -III Theroy
                TextObject TH3Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];
                TextObject TH3Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
                TextObject TH3Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text96"];
                TextObject TH3Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];
                TextObject TH3PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];

                //Term - III Practical
                TextObject PR3Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                TextObject PR3Bio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                TextObject PR3Physics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                TextObject PR3Chemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                TextObject PR3PhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];

                //Term -III Total
                TextObject TotalEng3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                TextObject TotalBio3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
                TextObject TotalPhysics3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                TextObject TotalChemistry3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                TextObject TotalPhysicalEdu3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];


                //Term -I + II + III Theroy
                TextObject THEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
                TextObject THBio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
                TextObject THPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
                TextObject THChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
                TextObject THPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];

                //Term - I + II + III Practical
                TextObject PREng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];
                TextObject PRBio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                TextObject PRPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                TextObject PRChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];
                TextObject PRPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];

                //Term -I + II + III Total
                TextObject TotalEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];
                TextObject TotalBio = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                TextObject TotalPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                TextObject TotalChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                TextObject TotalPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                
                //Term - I Total & percentrage
                TextObject Term1Total = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                TextObject Term1Per = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];

                //Term - II Total & percentrage
                TextObject Term2Total = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject Term2Per = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];

                //Term - III Total & percentrage
                TextObject Term3Total = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                TextObject Term3Per = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];

                //Term - I + II + III Total & percentrage
                TextObject TermTotal = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                TextObject TermPer = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];

               // TextObject Exam = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Text33"];
               // PictureObject Pic1=(PictureObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["Picture1"];
                //}

               
               //Term - I Total Marks
                int THEng1 = 0, THBio1 = 0, THPhysics1 = 0, THChemistry1 = 0, THPhysicalEdu1 = 0;
                int PREng1 = 0, PRBio1 = 0, PRPhysics1 = 0, PRChemistry1 = 0, PRPhysicalEdu1 = 0;
                int TotEng1 = 0, TotBio1 = 0, TotPhysics1 = 0, TotChemistry1 = 0, TotPhysicalEdu1 = 0;

                //Term - II Total Marks
                int THEng2 = 0, THBio2 = 0, THPhysics2 = 0, THChemistry2 = 0, THPhysicalEdu2 = 0;
                int PREng2 = 0, PRBio2 = 0, PRPhysics2 = 0, PRChemistry2 = 0, PRPhysicalEdu2 = 0;
                int TotEng2 = 0, TotBio2 = 0, TotPhysics2 = 0, TotChemistry2 = 0, TotPhysicalEdu2 = 0;

                //Term - III Total Marks
                int THEng3 = 0, THBio3 = 0, THPhysics3 = 0, THChemistry3 = 0, THPhysicalEdu3 = 0;
                int PREng3 = 0, PRBio3 = 0, PRPhysics3 = 0, PRChemistry3 = 0, PRPhysicalEdu3 = 0;
                int TotEng3 = 0, TotBio3 = 0, TotPhysics3 = 0, TotChemistry3 = 0, TotPhysicalEdu3 = 0;

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
             

                strQry = "exec usp_ExamMarks @type='ExamMarks11N12',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "',@intSubcat_id=1";
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
                        SubBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                       SubChemistry.Text= Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SubPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {

                    }



                    try
                    {

                        TH1Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Theory 1"]);
                        THEng1 = Convert.ToInt32(TH1Eng.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        TH1Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Theory 1"]);
                        THBio1 = Convert.ToInt32(TH1Bio.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        TH1Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Theory 1"]);
                        THPhysics1 = Convert.ToInt32(TH1Physics.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        TH1Chemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Theory 1"]);
                        THChemistry1 = Convert.ToInt32(TH1Chemistry.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        TH1PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Theory 1"]);
                        THPhysicalEdu1 = Convert.ToInt32(TH1PhysicalEdu.Text);
                    }
                    catch
                    {

                    }


                    try
                    {




                        PR1Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Practical 1"]);
                        PREng1 = Convert.ToInt32(PR1Eng.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PR1Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Practical 1"]);
                        PRBio1 = Convert.ToInt32(PR1Bio.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PR1Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Practical 1"]);
                        PRPhysics1 = Convert.ToInt32(PR1Physics.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                         PR1Chemistry.Text  = Convert.ToString(dsObj.Tables[0].Rows[3]["Practical 1"]);
                         PRChemistry1 = Convert.ToInt32(PR1Chemistry.Text);
                    }
                    catch
                    {

                    }
                    try
                    {
                        PR1PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Practical 1"]);
                        PRPhysicalEdu1 = Convert.ToInt32(PR1PhysicalEdu.Text);
                    }
                    catch
                    {

                    }

                    try
                    {

                        TotalEng1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Term1Total"]);
                        TotEng1 = Convert.ToInt32(TotalEng1.Text);
                    }
                    catch
                    {
                    }
                    try
                    {

                        TotalBio1.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Term1Total"]);
                        TotBio1 = Convert.ToInt32(TotalBio1.Text);
                    }
                    catch
                    {
                    }
                    try
                    {

                        TotalPhysics1.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Term1Total"]);
                        TotPhysics1 = Convert.ToInt32(TotalPhysics1.Text);
                    }
                    catch
                    {

                    }
                    try
                    {

                        TotalChemistry1.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Term1Total"]);
                        TotChemistry1 = Convert.ToInt32(TotalChemistry1.Text);
                    }
                    catch
                    {

                    }
                    try
                    {

                        TotalPhysicalEdu1.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Term1Total"]);
                        TotPhysicalEdu1 = Convert.ToInt32(TotalPhysicalEdu1.Text);
                    }
                    catch
                    {

                    }

                    int TOTALTERM1 = TotEng1 + TotBio1 + TotPhysics1 + TotChemistry1 + TotPhysicalEdu1;
                    Term1Total.Text  = Convert.ToString(TOTALTERM1);
                    float ANPer = (float)TOTALTERM1 / 5;
                    ANPer = (float)System.Math.Round(ANPer, 2); ;
                    Term1Per.Text = Convert.ToString(ANPer);

                    //Term II
                    string test = Convert.ToString(Session["Exam_id"]);
                    if (Convert.ToString(Session["Exam_id"]) != "Term 1")
                    {

                        try
                        {



                            TH2Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Theory 2"]);
                            THEng2 = Convert.ToInt32(TH2Eng.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH2Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Theory 2"]);
                            THBio2 = Convert.ToInt32(TH2Bio.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH2Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Theory 2"]);
                            THPhysics2 = Convert.ToInt32(TH2Physics.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH2Chemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Theory 2"]);
                            THChemistry2 = Convert.ToInt32(TH2Chemistry.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH2PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Theory 2"]);
                            THPhysicalEdu2 = Convert.ToInt32(TH2PhysicalEdu.Text);
                        }
                        catch
                        {

                        }


                        try
                        {
                            PR2Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Practical 2"]);
                            PREng2 = Convert.ToInt32(PR2Eng.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR2Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Practical 2"]);
                            PRBio2 = Convert.ToInt32(PR2Bio.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR2Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Practical 2"]);
                            PRPhysics2 = Convert.ToInt32(PR2Physics.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                         PR2Chemistry.Text   = Convert.ToString(dsObj.Tables[0].Rows[3]["Practical 2"]);
                         PRChemistry2 = Convert.ToInt32(PR2Chemistry.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR2PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Practical 2"]);
                            PRPhysicalEdu2 = Convert.ToInt32(PR2PhysicalEdu.Text);
                        }
                        catch
                        {

                        }


                        try
                        {

                            TotalEng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Term2Total"]);
                            TotEng2 = Convert.ToInt32(TotalEng2.Text);
                        }
                        catch
                        {
                        }
                        try
                        {

                            TotalBio2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Term2Total"]);
                            TotBio2 = Convert.ToInt32(TotalBio2.Text);
                        }
                        catch
                        {
                        }
                        try
                        {

                            TotalPhysics2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Term2Total"]);
                            TotPhysics2 = Convert.ToInt32(TotalPhysics2.Text);
                        }
                        catch
                        {

                        }
                        try
                        {

                            TotalChemistry2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Term2Total"]);
                            TotChemistry2 = Convert.ToInt32(TotalChemistry2.Text);
                        }
                        catch
                        {

                        }
                        try
                        {

                            TotalPhysicalEdu2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Term2Total"]);
                            TotPhysicalEdu2 = Convert.ToInt32(TotalPhysicalEdu2.Text);
                        }
                        catch
                        {

                        }
                        int TOTALTERM2 = TotEng2 + TotBio2 + TotPhysics2 + TotChemistry2 + TotPhysicalEdu2;
                        Term2Total.Text = Convert.ToString(TOTALTERM2);
                        float term2Per = (float)TOTALTERM2 / 5;
                        term2Per = (float)System.Math.Round(term2Per, 2); ;
                        Term2Per.Text = Convert.ToString(term2Per);
                    }
                    //Term III
                    if (Convert.ToString(Session["Exam_id"]) == "Term 3")
                    {

                        try
                        {



                            TH3Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Theory 3"]);
                            THEng3 = Convert.ToInt32(TH3Eng.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH3Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Theory 3"]);
                            THBio3 = Convert.ToInt32(TH3Bio.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH3Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Theory 3"]);
                            THPhysics3 = Convert.ToInt32(TH3Physics.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                             TH3Chemistry.Text  = Convert.ToString(dsObj.Tables[0].Rows[3]["Theory 3"]);
                             THChemistry3 = Convert.ToInt32(TH3Chemistry.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            TH3PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Theory 3"]);
                            THPhysicalEdu3 = Convert.ToInt32(TH3PhysicalEdu.Text);
                        }
                        catch
                        {

                        }


                        try
                        {
                            PR3Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Practical 3"]);
                            PREng3 = Convert.ToInt32(PR3Eng.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR3Bio.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Practical 3"]);
                            PRBio3 = Convert.ToInt32(PR3Bio.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR3Physics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Practical 3"]);
                            PRPhysics3 = Convert.ToInt32(PR3Physics.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR3Chemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Practical 3"]);
                            PRChemistry3 = Convert.ToInt32(PR3Chemistry.Text);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PR3PhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Practical 3"]);
                            PRPhysicalEdu3 = Convert.ToInt32(PR3PhysicalEdu.Text);
                        }
                        catch
                        {

                        }

                        try
                        {

                            TotalEng3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Term3Total"]);
                            TotEng3  = Convert.ToInt32(TotalEng3.Text);
                        }
                        catch
                        {
                        }
                        try
                        {

                            TotalBio3.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Term3Total"]);
                            TotBio3 = Convert.ToInt32(TotalBio3.Text);
                        }
                        catch
                        {
                        }
                        try
                        {

                            TotalPhysics3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Term3Total"]);
                            TotPhysics3 = Convert.ToInt32(TotalPhysics3.Text);
                        }
                        catch
                        {

                        }
                        try
                        {

                            TotalChemistry3.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Term3Total"]);
                            TotChemistry3 = Convert.ToInt32(TotalChemistry3.Text);
                        }
                        catch
                        {

                        }
                        try
                        {

                            TotalPhysicalEdu3.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Term3Total"]);
                            TotPhysicalEdu3 = Convert.ToInt32(TotalPhysicalEdu3.Text);
                        }
                        catch
                        {

                        }
                        int TOTALTERM3 = TotEng3 + TotBio3 + TotPhysics3 +TotChemistry3 + TotPhysicalEdu3;
                        Term3Total.Text = Convert.ToString(TOTALTERM3);
                        float term3Per = (float)TOTALTERM3 / 5;
                        term3Per = (float)System.Math.Round(term3Per, 2); ;
                        Term3Per.Text = Convert.ToString(term3Per);
                    }
                }
                    
                    // Total I + II + III
                float TotalEnglish = THEng1 + THEng2 + THEng3;
                THEng.Text = Convert.ToString( TotalEnglish);
                float TotalBiology = THBio1 + THBio2 + THBio3;
                THBio.Text = Convert.ToString(TotalBiology);
                float TotalPhysicss = THPhysics1 + THPhysics2 + THPhysics3;
                THPhysics.Text = Convert.ToString(TotalPhysicss);
                float TotalChemistrey = THChemistry1 + THChemistry2 + THChemistry3;
                THChemistry.Text = Convert.ToString(TotalChemistrey);
                float TotalPhysicalEduu = THPhysicalEdu1 + THPhysicalEdu2 + THPhysicalEdu3;
                THPhysicalEdu.Text = Convert.ToString(TotalPhysicalEduu);

                

                float TotalPrEnglish = PREng1 + PREng2 + PREng3;
                PREng.Text = Convert.ToString(TotalPrEnglish);
                float TotalPrBiology = PRBio1 + PRBio2 + PRBio3;
                PRBio.Text = Convert.ToString(TotalPrBiology);
                float TotalPrPhysicss = PRPhysics1 + PRPhysics2 + PRPhysics3;
                PRPhysics.Text = Convert.ToString(TotalPrPhysicss);
                float TotalPrChemistrey = PRChemistry1 + PRChemistry2 + PRChemistry3;
                PRChemistry.Text = Convert.ToString(TotalPrChemistrey);
                float TotalPrPhysicalEduu = PRPhysicalEdu1 + PRPhysicalEdu2 + PRPhysicalEdu3;
                PRPhysicalEdu.Text = Convert.ToString(TotalPrPhysicalEduu);

                float GrandTotalEnglish = TotalEnglish + TotalPrEnglish ;
                TotalEng.Text = Convert.ToString(GrandTotalEnglish);
                float GrandTotalBiology = TotalBiology + TotalPrBiology ;
                TotalBio.Text = Convert.ToString(GrandTotalBiology);
                float GrandTotalPhysics = TotalPhysicss +TotalPrPhysicss ;
                TotalPhysics.Text = Convert.ToString(GrandTotalPhysics);
                float GrandTotalChemistry = TotalChemistrey + TotalPrChemistrey ;
                TotalChemistry.Text = Convert.ToString(GrandTotalChemistry);
                float GrandTotalPhysicalEdu = TotalPhysicalEduu + TotalPrPhysicalEduu ;
                TotalPhysicalEdu.Text = Convert.ToString(GrandTotalPhysicalEdu);

                float term1total = GrandTotalEnglish + GrandTotalBiology + GrandTotalPhysics + GrandTotalChemistry + GrandTotalPhysicalEdu;
                TermTotal.Text = Convert.ToString(term1total);
                float termPer = (float)term1total / 15;
                termPer = (float)System.Math.Round(termPer, 2); ;
                TermPer.Text = Convert.ToString(termPer);

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

                crystalReport.Load(Server.MapPath(string.Format("rptResult_11Sci.rpt", i)));


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