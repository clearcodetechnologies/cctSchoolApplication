using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using System.IO;

public partial class frmFeeReport : DBUtility
{
    DataSet dtst = new DataSet();
    DataSet dsObj = new DataSet();
    string strQry = "";
    ReportDocument crystalReport = new ReportDocument();
    ConnectionInfo connectionInfo = new ConnectionInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["rptFee"] != null)
            {
                dtst = (DataSet)Session["rptFee"];

                string reportPath = Server.MapPath("frmFeeRecpt.rpt");
                crystalReport.Load(reportPath);

                TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                //TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
                TextObject classname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject sectionname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                // TextObject mnthfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];
                TextObject admfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
                TextObject annualfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
                TextObject examfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                TextObject tuitionfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
                TextObject photofee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                TextObject transportfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                TextObject miscfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
                TextObject latefee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                TextObject totalfee = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                TextObject totalfeeWord = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];

                TextObject nameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text37"];
                //TextObject fathernameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
                TextObject classnameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
                TextObject sectionnameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
                //TextObject mnthfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
                TextObject admfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                TextObject annualfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject examfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject tuitionfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject photofeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];
                TextObject transportfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject miscfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                TextObject latefeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                TextObject totalfeeguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];

                TextObject Srno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                TextObject Srnoguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text40"];

                TextObject printdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                TextObject printdateguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text42"];

                TextObject totalfeeWordguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];

                TextObject mnthname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                TextObject mnthnameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];

                TextObject transmnthname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                TextObject transmnthnameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];

                TextObject receiptno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                TextObject receiptnoguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];

                // TextObject transmnthname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                // TextObject transmnthnameguard = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];


                if (dtst.Tables[0].Rows.Count > 0)
                {
                    name.Text = Convert.ToString(dtst.Tables[0].Rows[0]["StuName"]);
                    nameguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["StuName"]);
                    //fathernameoff.Text = Convert.ToString(dtst.Tables[0].Rows[0]["fatherName"]);
                    // fathername.Text = Convert.ToString(dtst.Tables[0].Rows[0]["fatherName"]);
                    classname.Text = Convert.ToString(dtst.Tables[0].Rows[0]["intstandard_id"]);
                    classnameguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["intstandard_id"]);
                    sectionname.Text = Convert.ToString(dtst.Tables[0].Rows[0]["vchDivisionName"]);
                    sectionnameguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["vchDivisionName"]);
                    Srno.Text = Convert.ToString(dtst.Tables[0].Rows[0]["Receipt_Id"]);
                    Srnoguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["Receipt_Id"]);
                    printdate.Text = Convert.ToString(dtst.Tables[0].Rows[0]["feeFate"]);
                    printdateguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["feeFate"]);
                    receiptno.Text = Convert.ToString(dtst.Tables[0].Rows[0]["Receipt_no"]);
                    receiptnoguard.Text = Convert.ToString(dtst.Tables[0].Rows[0]["Receipt_no"]);


                    // mnthfee.Text = "0";
                    // mnthfeeguard.Text = "0";
                    admfee.Text = "0";
                    admfeeguard.Text = "0";
                    annualfee.Text = "0";
                    annualfeeguard.Text = "0";
                    examfee.Text = "0";
                    examfeeguard.Text = "0";
                    tuitionfee.Text = "0";
                    tuitionfeeguard.Text = "0";
                    photofee.Text = "0";
                    photofeeguard.Text = "0";
                    transportfee.Text = "0";
                    transportfeeguard.Text = "0";
                    miscfee.Text = "0";
                    miscfeeguard.Text = "0";

                    latefee.Text = "0";
                    latefeeguard.Text = "0";
                    //mnthname.Text = "";
                    //mnthnameoff.Text = "";
                    int sum = 0;
                    int transsum = 0;
                    int examsum = 0;

                    for (int i = 0; i < dtst.Tables[0].Rows.Count; i++)
                    {

                        //if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Annual Fee")
                        //{
                        //    strQry = "exec usp_FeesAssignSTD @type='FillAnnualMstGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                        //     dsObj = sGetDataset(strQry);
                        //     for (int j = 0; j < dsObj.Tables[0].Rows.Count; j++)
                        //     {

                        //         if (Convert.ToString(dsObj.Tables[0].Rows[j]["vchFeeDesc"]) == "Examination fee")
                        //         {

                        //             examfee.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);

                        //             examfeeoff.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);
                        //         }

                        //         if (Convert.ToString(dsObj.Tables[0].Rows[j]["vchFeeDesc"]) == "Computer Fee")
                        //         {

                        //             compfee.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);

                        //             compfeeoff.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);
                        //         }

                        //         if (Convert.ToString(dsObj.Tables[0].Rows[j]["vchFeeDesc"]) == "Medical Fee")
                        //         {

                        //             medifee.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);

                        //             medifeeoff.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);
                        //         }

                        //         if (Convert.ToString(dsObj.Tables[0].Rows[j]["vchFeeDesc"]) == "Maintenance Fee")
                        //         {

                        //             maintancefee.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);

                        //             maintancefeeoff.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);
                        //         }

                        //         if (Convert.ToString(dsObj.Tables[0].Rows[j]["vchFeeDesc"]) == "Development Fee")
                        //         {

                        //             devfee.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);

                        //             devfeeoff.Text = Convert.ToString(dsObj.Tables[0].Rows[j]["numAmount"]);
                        //         }
                        //     }


                        //}


                        //if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Monthly")
                        //{
                        //    mnthsum = mnthsum + Convert.ToInt16(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                        //    mnthfee.Text = Convert.ToString(mnthsum);
                        //    mnthfeeoff.Text = Convert.ToString(mnthsum);


                        //    mnthname.Text = mnthname.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]);



                        //    mnthnameoff.Text = mnthnameoff.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]);

                        //    //mnthfee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                        //    //mnthfeeoff.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        //}

                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Admission Fee")
                        {

                            admfee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            admfeeguard.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        }

                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Annual Charges")
                        {

                            annualfee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            annualfeeguard.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        }


                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Exam fee")
                        {
                            examsum = examsum + Convert.ToInt16(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            examfee.Text = Convert.ToString(examsum);

                            examfeeguard.Text = Convert.ToString(examsum);
                        }

                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Tuition Fee")
                        {
                            //string strQry1 = "select stuff((SELECT distinct ', ' + cast(intMonth_ID as varchar(10)) FROM tblfeecollection t2 where t2.Receipt_Id = t1.Receipt_Id  FOR XML PATH('')),1,1,'') as Month_Name from tblfeecollection t1 where intTutionID=6 and Receipt_Id='" + dtst.Tables[0].Rows[i]["Receipt_Id"] + "' group by Receipt_Id";
                            //dsObj = sGetDataset(strQry1);
                            //if (dsObj.Tables[0].Rows.Count > 0)
                            //{
                            //mnthname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Month_Name"]);

                            //mnthnameguard.Text = mnthname.Text;


                            //}

                            mnthname.Text = mnthname.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]);
                            mnthnameguard.Text = mnthname.Text;
                            sum = sum + Convert.ToInt16(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            tuitionfee.Text = Convert.ToString(sum);
                            tuitionfeeguard.Text = Convert.ToString(sum);

                            //transmnthname.Text = transmnthname.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]);
                            //transmnthnameoff.Text = transmnthnameoff.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]) ;
                        }

                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Misc")
                        {

                            miscfee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            miscfeeguard.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        }



                        //if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Other Fee")
                        //{

                        //    otherfee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                        //    otherfeeoff.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        //}

                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Late Fee")
                        {

                            latefee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);


                            latefeeguard.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        }
                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Photo and Insurance")
                        {

                            photofee.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);

                            photofeeguard.Text = Convert.ToString(dtst.Tables[0].Rows[i]["intPaidAmt"]);
                        }
                        if (Convert.ToString(dtst.Tables[0].Rows[i]["intTutionID"]) == "Transport Fee")
                        {
                            transmnthname.Text = transmnthname.Text + " " + Convert.ToString(dtst.Tables[0].Rows[i]["Month_Name"]);
                            transmnthnameguard.Text = transmnthname.Text;


                            transsum = transsum + Convert.ToInt16(dtst.Tables[0].Rows[i]["intPaidAmt"]);


                            transportfee.Text = Convert.ToString(transsum);

                            transportfeeguard.Text = Convert.ToString(transsum);


                        }



                    }


                    totalfee.Text = Convert.ToString(Convert.ToInt64(latefee.Text) + Convert.ToInt64(transportfee.Text) + Convert.ToInt64(tuitionfee.Text) + Convert.ToInt64(admfee.Text) + Convert.ToInt64(annualfee.Text) + Convert.ToInt64(examfee.Text) + Convert.ToInt64(photofee.Text) + Convert.ToInt64(miscfee.Text));
                    totalfeeguard.Text = totalfee.Text;
                    int number = int.Parse(totalfee.Text);

                    totalfeeWord.Text = ConvertNumbertoWords(number);
                    totalfeeWordguard.Text = ConvertNumbertoWords(number);

                    totalfeeWord.Text = totalfeeWord.Text + " Only";
                    totalfeeWordguard.Text = totalfeeWordguard.Text + " Only";


                }

                ////string reportPath = Server.MapPath("CrystalFeeReport.rpt");

                ////crystalReport.SetDataSource(dtst.Tables);

                //CrystalReportViewer1.ReportSource = crystalReport;
                //CrystalReportViewer1.DataBind();
                //CrystalReportViewer1.RefreshReport();

                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);
            }
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }

        ///
    }

    private void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    public static string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "ZERO";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "AND ";
            var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }
}