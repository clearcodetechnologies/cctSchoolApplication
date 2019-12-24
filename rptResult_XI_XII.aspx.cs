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

public partial class rptResult_XI_XII : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    List<byte[]> files = new List<byte[]>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rptAllStudentMark"] != null)
        {
            dsObjgrade = (DataSet)Session["rptAllStudentMark"];

            try
            {
                int i = 0;
                if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                {
                    if (Convert.ToString(Session["standard_id"]) == "XI Sc" || Convert.ToString(Session["standard_id"]) == "XI Com" || Convert.ToString(Session["standard_id"]) == "XI Arts")
                    {
                        string reportPath = Server.MapPath("Result_XI_XII_FirstTerm.rpt");
                        crystalReport.Load(reportPath);
                        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];

                        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];



                        TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                        TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                        TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                        TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                        TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                        TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                        TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                        TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                        TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];

                        TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                        TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                        TextObject HYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                        TextObject HYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                        TextObject HYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                        TextObject HYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                        TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                        TextObject HYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                        TextObject HYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];

                        TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                        //TextObject PRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                        TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                        TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                        TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                        TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                        //TextObject PRMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                        TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                        TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];

                        //TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                        TextObject HYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];

                        string HYEngstring = "";
                        string HYHindiBengalistring = "";
                        string HYPhysicsstring = "";
                        string HYChemistrystring = "";
                        string HYBiologystring = "";
                        string HYCompScistring = "";
                        string HYMathstring = "";
                        string HYPhysicalEdustring = "";
                        string HYCommercialArtstring = "";

                        string PRHYEngstring = "";
                        string PRHYPhysicsstring = "";
                        string PRHYChemistrystring = "";
                        string PRHYBiologystring = "";
                        string PRHYCompScistring = "";
                        string PRHYPhysicalEdustring = "";
                        string PRHYCommercialArtstring = "";

                        strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 ";
                        string subcount = sExecuteReader(strQry);
                        int count = Convert.ToInt32(subcount);

                        List<byte[]> files = new List<byte[]>();

                        for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                        {

                        strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                            PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }

                        session.Text = Convert.ToString(Session["YearName"]);
                        ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                        reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Session["standard_idnum"] + "'";
                        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                            mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                            rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                            //class1.Text = ddlSTD.SelectedItem.ToString();
                            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                        }



                        strQry = "exec usp_ExamMarks @type='ResultXI',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                       dsObj = sGetDataset(strQry);
                       if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                SUBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                            }
                            catch
                            {
                            }

                            try
                            {
                                HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                                if (HYEng.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYEngstring = "0";
                                }
                                else
                                {
                                    HYEngstring = HYEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                                if (HYHindiBengali.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYHindiBengalistring = "0";
                                }
                                else
                                {
                                    HYHindiBengalistring = HYHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                                if (HYPhysics.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYPhysicsstring = "0";
                                }
                                else
                                {
                                    HYPhysicsstring = HYPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                                if (HYChemistry.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYChemistrystring = "0";
                                }
                                else
                                {
                                    HYChemistrystring = HYChemistry.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                                if (HYBiology.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYBiologystring = "0";
                                }
                                else
                                {
                                    HYBiologystring = HYBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                                if (HYCompSci.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYCompScistring = "0";
                                }
                                else
                                {
                                    HYCompScistring = HYCompSci.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                                if (HYMath.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYMathstring = "0";

                                }
                                else
                                {
                                    HYMathstring = HYMath.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly"]);
                                if (HYPhysicalEdu.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYPhysicalEdustring = "0";
                                }
                                else
                                {
                                    HYPhysicalEdustring = HYPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                HYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly"]);
                                if (HYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    HYCommercialArtstring = "0";
                                }
                                else
                                {
                                    HYCommercialArtstring = HYCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                PRHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                if (PRHYEng.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYEngstring = "0";
                                }
                                else
                                {
                                    PRHYEngstring = PRHYEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HYPractical"]);
                                if (PRHYPhysics.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYPhysicsstring = "0";
                                }
                                else
                                {
                                    PRHYPhysicsstring = PRHYPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HYPractical"]);
                                if (PRHYChemistry.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYChemistrystring = "0";
                                }
                                else
                                {
                                    PRHYChemistrystring = PRHYChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HYPractical"]);
                                if (PRHYBiology.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYBiologystring = "0";
                                }
                                else
                                {
                                    PRHYBiologystring = PRHYBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HYPractical"]);
                                if (PRHYCompSci.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYCompScistring = "0";
                                }
                                else
                                {
                                    PRHYCompScistring = PRHYCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["HYPractical"]);
                                if (PRHYPhysicalEdu.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYPhysicalEdustring = "0";
                                }
                                else
                                {

                                    PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["HYPractical"]);
                                if (PRHYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYCommercialArtstring = "0";

                                }
                                else
                                {
                                    PRHYCommercialArtstring = PRHYCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                //UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEng.Text) + Convert.ToInt32(UTHindiBengali.Text) + Convert.ToInt32(UTPhysics.Text) + Convert.ToInt32(UTChemistry.Text) + Convert.ToInt32(UTBiology.Text) + Convert.ToInt32(UTCompSci.Text) + Convert.ToInt32(UTMath.Text) + Convert.ToInt32(UTPhysicalEdu.Text) + Convert.ToInt32(UTCommercialArt.Text));
                                HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEngstring) + Convert.ToInt32(HYPhysicsstring) + Convert.ToInt32(HYChemistrystring) + Convert.ToInt32(HYBiologystring) + Convert.ToInt32(HYCompScistring) + Convert.ToInt32(HYMathstring) + Convert.ToInt32(HYPhysicalEdustring) + Convert.ToInt32(HYCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(HYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));
                            }
                            catch
                            {
                            }
                        }
                        crystalReport.Load(Server.MapPath(string.Format("Result_XI_XII_FirstTerm.rpt", i)));


                        //AdmissionReport.ReportSource = crystalReport;
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                        stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                        files.Add(PrepareBytes(stream1));



                        }
                        //AdmissionReport.ReportSource = files;
                        //AdmissionReport.SeparatePages = false;


                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/pdf";

                        //// merge the all reports & show the reports            
                        Response.BinaryWrite(MergeReports(files).ToArray());
                        // AdmissionReport.ReportSource = crystalReport;
                        Response.End();
                    }
                    if (Convert.ToString(Session["standard_id"]) == "XII Sc" || Convert.ToString(Session["standard_id"]) == "XII Com" || Convert.ToString(Session["standard_id"]) == "XII Arts")
                    
                    {

                        string reportPath = Server.MapPath("Result12th.rpt");
                        crystalReport.Load(reportPath);
                        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];

                        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                        //TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];

                       

                        TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                        TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                        TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                        TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                        TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                        TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                        TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                        TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                        TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];

                        TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                        TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                        TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                        TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
                        TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
                        TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
                        TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                        TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                        TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];

                        TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                        TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                        TextObject HYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                        TextObject HYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                        TextObject HYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                        TextObject HYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                        TextObject HYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                        TextObject HYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                        TextObject HYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];

                        TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                        TextObject PRHYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
                        TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                        TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                        TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                        TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                        TextObject PRHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text36"];
                        TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                        TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];

                        TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                        TextObject HYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];

                        string HYEngstring = "";
                        string HYHindiBengalistring = "";
                        string HYPhysicsstring = "";
                        string HYChemistrystring = "";
                        string HYBiologystring = "";
                        string HYCompScistring = "";
                        string HYMathstring = "";
                        string HYPhysicalEdustring = "";
                        string HYCommercialArtstring = "";

                        string UTEngstring = "";
                        string UTHindiBengalistring = "";
                        string UTPhysicsstring = "";
                        string UTChemistrystring = "";
                        string UTBiologystring = "";
                        string UTCompScistring = "";
                        string UTMathstring = "";
                        string UTPhysicalEdustring = "";
                        string UTCommercialArtstring = "";

                        string PRHYEngstring = "";
                        string PRHYHindiBengalistring = "";
                        string PRHYPhysicsstring = "";
                        string PRHYChemistrystring = "";
                        string PRHYBiologystring = "";
                        string PRHYCompScistring = "";
                        string PRHYMathstring = "";
                        string PRHYPhysicalEdustring = "";
                        string PRHYCommercialArtstring = "";


                        //strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 ";
                        //string subcount = sExecuteReader(strQry);
                        //int count = Convert.ToInt32(subcount);

                        
                        for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                        {

                        session.Text = Convert.ToString(Session["YearName"]);
                        ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                        reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                        strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                            PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }

                        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Session["standard_idnum"] + "'";
                        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                            mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                            rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                            //class1.Text = ddlSTD.SelectedItem.ToString();
                            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                        }


                        strQry = "exec usp_ExamMarks @type='ResultXI',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                       dsObj = sGetDataset(strQry);
                       if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                SUBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                SUBCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                            }
                            catch (Exception ex) { }


                            try
                            {
                                UTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                                if (UTEng.Text == "NA" || UTEng.Text == "AB")
                                {
                                    UTEngstring = "0";

                                }
                                else
                                {
                                    UTEngstring = UTEng.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                                if (UTHindiBengali.Text == "NA" || UTHindiBengali.Text == "AB")
                                {
                                    UTHindiBengalistring = "0";

                                }
                                else
                                {
                                    UTHindiBengalistring = UTHindiBengali.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                                if (UTPhysics.Text == "NA" || UTPhysics.Text == "AB")
                                {
                                    UTPhysicsstring = "0";

                                }
                                else
                                {
                                    UTPhysicsstring = UTPhysics.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                                if (UTChemistry.Text == "NA" || UTChemistry.Text == "AB")
                                {
                                    UTChemistrystring = "0";

                                }
                                else
                                {
                                    UTChemistrystring = UTChemistry.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                                if (UTBiology.Text == "NA" || UTBiology.Text == "AB")
                                {
                                    UTBiologystring = "0";

                                }
                                else
                                {
                                    UTBiologystring = UTBiology.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                                if (UTCompSci.Text == "NA" || UTCompSci.Text == "AB")
                                {
                                    UTCompScistring = "0";

                                }
                                else
                                {
                                    UTCompScistring = UTCompSci.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                                if (UTMath.Text == "NA" || UTMath.Text == "AB")
                                {
                                    UTMathstring = "0";

                                }
                                else
                                {
                                    UTMathstring = UTMath.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                                if (UTPhysicalEdu.Text == "NA" || UTPhysicalEdu.Text == "AB")
                                {
                                    UTPhysicalEdustring = "0";

                                }
                                else
                                {
                                    UTPhysicalEdustring = UTPhysicalEdu.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                UTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                                if (UTCommercialArt.Text == "NA" || UTCommercialArt.Text == "AB")
                                {
                                    UTCommercialArtstring = "0";

                                }
                                else
                                {
                                    UTCommercialArtstring = UTCommercialArt.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {

                                HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                                if (HYEng.Text == "NA" || HYEng.Text == "AB")
                                {
                                    HYEngstring = "0";

                                }
                                else
                                {
                                    HYEngstring = HYEng.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                                if (HYHindiBengali.Text == "NA" || HYHindiBengali.Text == "AB")
                                {
                                    HYHindiBengalistring = "0";

                                }
                                else
                                {
                                    HYHindiBengalistring = HYHindiBengali.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                                if (HYPhysics.Text == "NA" || HYPhysics.Text == "AB")
                                {
                                    HYPhysicsstring = "0";

                                }
                                else
                                {
                                    HYPhysicsstring = HYPhysics.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                                if (HYChemistry.Text == "NA" || HYChemistry.Text == "AB")
                                {
                                    HYChemistrystring = "0";

                                }
                                else
                                {
                                    HYChemistrystring = HYChemistry.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                                if (HYBiology.Text == "NA" || HYBiology.Text == "AB")
                                {
                                    HYBiologystring = "0";

                                }
                                else
                                {
                                    HYBiologystring = HYBiology.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                                if (HYCompSci.Text == "NA" || HYCompSci.Text == "AB")
                                {
                                    HYCompScistring = "0";

                                }
                                else
                                {
                                    HYCompScistring = HYCompSci.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                                if (HYMath.Text == "NA" || HYMath.Text == "AB")
                                {
                                    HYMathstring = "0";

                                }
                                else
                                {
                                    HYMathstring = HYMath.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly"]);
                                if (HYPhysicalEdu.Text == "NA" || HYPhysicalEdu.Text == "AB")
                                {
                                    HYPhysicalEdustring = "0";

                                }
                                else
                                {
                                    HYPhysicalEdustring = HYPhysicalEdu.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                HYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly"]);
                                if (HYCommercialArt.Text == "NA" || HYCommercialArt.Text == "AB")
                                {
                                    HYCommercialArtstring = "0";

                                }
                                else
                                {
                                    HYCommercialArtstring = HYCommercialArt.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {

                                PRHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                if (PRHYEng.Text == "NA" || PRHYEng.Text == "AB")
                                {
                                    PRHYEngstring = "0";

                                }
                                else
                                {
                                    PRHYEngstring = PRHYEng.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {

                                PRHYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                if (PRHYHindiBengali.Text == "NA" || PRHYHindiBengali.Text == "AB")
                                {
                                    PRHYHindiBengalistring = "0";

                                }
                                else
                                {
                                    PRHYHindiBengalistring = PRHYHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }

                            try
                            {
                                PRHYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HYPractical"]);
                                if (PRHYPhysics.Text == "NA" || PRHYPhysics.Text == "AB")
                                {
                                    PRHYPhysicsstring = "0";

                                }
                                else
                                {
                                    PRHYPhysicsstring = PRHYPhysics.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                PRHYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HYPractical"]);
                                if (PRHYChemistry.Text == "NA" || PRHYChemistry.Text == "AB")
                                {
                                    PRHYChemistrystring = "0";

                                }
                                else
                                {
                                    PRHYChemistrystring = PRHYChemistry.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                PRHYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HYPractical"]);
                                if (PRHYBiology.Text == "NA" || PRHYBiology.Text == "AB")
                                {
                                    PRHYBiologystring = "0";

                                }
                                else
                                {
                                    PRHYBiologystring = PRHYBiology.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                PRHYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HYPractical"]);
                                if (PRHYCompSci.Text == "NA" || PRHYCompSci.Text == "AB")
                                {
                                    PRHYCompScistring = "0";

                                }
                                else
                                {
                                    PRHYCompScistring = PRHYCompSci.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }

                            try
                            {

                                PRHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                if (PRHYMath.Text == "NA" || PRHYMath.Text == "AB")
                                {
                                    PRHYMathstring = "0";

                                }
                                else
                                {
                                    PRHYMathstring = PRHYMath.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["HYPractical"]);
                                if (PRHYPhysicalEdu.Text == "NA" || PRHYPhysicalEdu.Text == "AB")
                                {
                                    PRHYPhysicalEdustring = "0";

                                }
                                else
                                {
                                    PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            try
                            {
                                PRHYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["HYPractical"]);
                                if (PRHYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB")
                                {
                                    PRHYCommercialArtstring = "0";

                                }
                                else
                                {
                                    PRHYCommercialArtstring = PRHYCommercialArt.Text;
                                }
                            }
                            catch(Exception ex)
                            {
                            }



                            try
                            {
                                UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEngstring) + Convert.ToInt32(UTHindiBengalistring) + Convert.ToInt32(UTPhysicsstring) + Convert.ToInt32(UTChemistrystring) + Convert.ToInt32(UTBiologystring) + Convert.ToInt32(UTCompScistring) + Convert.ToInt32(UTMathstring) + Convert.ToInt32(UTPhysicalEdustring) + Convert.ToInt32(UTCommercialArtstring));
                                HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEngstring) + Convert.ToInt32(HYPhysicsstring) + Convert.ToInt32(HYChemistrystring) + Convert.ToInt32(HYBiologystring) + Convert.ToInt32(HYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(HYMathstring) + Convert.ToInt32(HYPhysicalEdustring) + Convert.ToInt32(HYCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(HYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));
                                //HYTOT.Text = Convert.ToString(Convert.ToInt32(HYEngstring) + Convert.ToInt32(HYPhysicsstring) + Convert.ToInt32(HYChemistrystring) + Convert.ToInt32(HYBiologystring) + Convert.ToInt32(HYCompScistring) + Convert.ToInt32(HYMathstring) + Convert.ToInt32(HYPhysicalEdustring) + Convert.ToInt32(HYCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(HYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));
                            }
                            catch (Exception ex)
                            { }

                        }

                        crystalReport.Load(Server.MapPath(string.Format("Result12th.rpt", i)));


                        //AdmissionReport.ReportSource = crystalReport;
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                        stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                        files.Add(PrepareBytes(stream1));
                    }
                        //AdmissionReport.ReportSource = files;
                        //AdmissionReport.SeparatePages = false;


                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/pdf";

                        //// merge the all reports & show the reports            
                        Response.BinaryWrite(MergeReports(files).ToArray());
                        // AdmissionReport.ReportSource = crystalReport;
                        Response.End();

                    }
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";

                    //// merge the all reports & show the reports            
                    Response.BinaryWrite(MergeReports(files).ToArray());
                    // AdmissionReport.ReportSource = crystalReport;
                    Response.End();
                }



            }
            catch(Exception ex)
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