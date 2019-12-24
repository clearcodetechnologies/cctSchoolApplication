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

public partial class frmTCEdit : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      
     if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
        {
            if (!IsPostBack)
            {
                if (Session["rptStudentdetail"] != null)
                {
                    dsObj = (DataSet)Session["rptStudentdetail"];

                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        btnUpdate.Visible = true;

                        txtsrno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SRNo"]);
                        txtAdmission.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AdmissionNo"]);
                        txtBoardRegi.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["BoardRegiNo"]);
                        txtnameofpupil.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudent_name"]);
                        txtfathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                        txtNationality.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationalty"]);
                        ddlscst.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSCST"]);
                        txtDOA.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtAdmission"]).ToString("dd/MM/yyyy");
                        txtDOBfig.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MMMM/yyyy");
                        //vchDOBword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDOBword"]); 
                        txtlastclassfig.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchlastclassfig"]);
                        txtlastclassword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchlastclassword"]);

                        txtannualexamlast.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchanuualexamlast"]);
                        txtsameclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsameclass"]);
                        subjectStudied1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied1"]);
                        subjectStudied2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied2"]);
                        subjectStudied3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied3"]);
                        subjectStudied4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied4"]);
                        subjectStudied5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied5"]);
                        subjectStudied6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied6"]);
                        txtpromo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclass"]);
                        txtHigherclassFig.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclassFig"]);

                        txtHigherclassWord.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclassWord"]);
                        txtduepaid.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchschoolduepaid"]);
                        txtAny.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfeeconcession"]);
                        txttotalday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNumberworkingday"]);
                        txtWorkingDays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNumberPresentday"]);
                        txtNCC.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNCC"]);
                        txtCurricular.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchExtracurriculam"]);
                        txtGeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGeneralconduct"]);
                        txtDOAC.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtApplication"]).ToString("dd/MM/yyyy");
                        txtDOIC.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtcertificateissue"]).ToString("dd/MM/yyyy");

                        txtReasons.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchreasonlevaning"]);
                        txtRemarks.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchotherremark"]);

                    }

                }
                else
                {
                    btnSubmit.Visible = true;
                    FillSTD();
                    GetAutoSRNO();
                    txtsrno.Text = Convert.ToString(ViewState["sesSRNo"]);
                }
            }
        }

    }

    public void FillSTD()
    {
        try
        {
            try
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                //sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");
               // FillDIV();
                //FillExaminationType();
            }
            catch (Exception)
            {

                throw;
            }

        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            //ddlGender.ClearSelection();
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
            //FillExam();
            //FillSubject();
        }
        catch
        {

        }
    }

    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");

            if (ddlStudent.Items.Count > 1)
                ddlStudent.Items.Add(new ListItem("All", "-1"));
            else
                ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();

    }

    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }

    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetAutoSRNO();

        txtsrno.Text = Convert.ToString(ViewState["sesSRNo"]); 

        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + ddlStudent.SelectedValue + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue + "'";
        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtnameofpupil.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
            txtfathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            //txtfathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            txtNationality.Text = "Indian";
            txtDOBfig.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MMMM/yyyy");
            //Convert.ToDateTime(txtDOBfig.Text).ToString("dd/MMMM/yyyy");
        }

        strQry = "exec usp_getAttendance @type='tctotalpresentday',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtWorkingDays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present_Status"]);

        }
        strQry = "exec usp_getAttendance @type='tctotalwrkingday',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txttotalday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present_Status"]);

        }

        //strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/05' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + ddlStudent.SelectedValue + "' group by a.intStudent_id";
        //string subcount = sExecuteReader(strQry);
        //txtWorkingDays.Text = subcount;

        //txttotalday.Text = "74";
        
    }

    protected void show_Click(object sender, EventArgs e)
    {
        Response.Redirect("rpttccertificate.aspx", true);
        
    }

    public void GetAutoSRNO()
    {
        strQry = "exec usp_TCcertificate @command='GetAutoSRNO',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["sesSRNo"] = Convert.ToString(dsObj.Tables[0].Rows[0]["SRNo"]).ToString().Trim();
        }
        else
        {
            ViewState["sesSRNo"] = "";
        }
    }
    protected void view_Click(object sender, EventArgs e)
    {
        string SRNo = Convert.ToString(txtsrno.Text);
        string AdmissionNo = Convert.ToString(txtAdmission.Text);
        string BoardRegiNo = Convert.ToString(txtBoardRegi.Text);
        string vchStudent_name = Convert.ToString(txtnameofpupil.Text);
        string vchFatherName = Convert.ToString(txtfathername.Text);
        string vchNationalty = Convert.ToString(txtNationality.Text);
        string vchSCST = Convert.ToString(ddlscst.SelectedItem.Text);
        string dtAdmission="";
        string dtDOB="";
        try
        {
             dtAdmission = Convert.ToDateTime(txtDOA.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOA.Text);
        }
        catch
        { 
        
        }
        try{
         dtDOB = Convert.ToDateTime(txtDOBfig.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
        }
        catch
        {

        }
        string vchDOBword = Convert.ToString(txtDOBword.Text);
        string vchlastclassfig = Convert.ToString(txtlastclassfig.Text);
        string vchlastclassword = Convert.ToString(txtlastclassword.Text);

        string vchanuualexamlast = Convert.ToString(txtannualexamlast.Text);
        string vchsameclass = Convert.ToString(txtsameclass.Text);
        string vchsubjectStudied1 = Convert.ToString(subjectStudied1.Text);
        string vchsubjectStudied2 = Convert.ToString(subjectStudied2.Text);
        string vchsubjectStudied3 = Convert.ToString(subjectStudied3.Text);
        string vchsubjectStudied4 = Convert.ToString(subjectStudied4.Text);
        string vchsubjectStudied5 = Convert.ToString(subjectStudied5.Text);
        string vchsubjectStudied6 = Convert.ToString(subjectStudied6.Text);
        string vchpromotionHigherclass = Convert.ToString(txtpromo.Text);
        string vchpromotionHigherclassFig = Convert.ToString(txtHigherclassFig.Text);

        string vchpromotionHigherclassWord = Convert.ToString(txtHigherclassWord.Text);
        string vchschoolduepaid = Convert.ToString(txtduepaid.Text);
        string vchfeeconcession = Convert.ToString(txtAny.Text);
        string vchNumberworkingday = Convert.ToString(txttotalday.Text);
        string vchNumberPresentday = Convert.ToString(txtWorkingDays.Text);
        string vchNCC = Convert.ToString(txtNCC.Text);
        string vchExtracurriculam = Convert.ToString(txtCurricular.Text);
        string vchGeneralconduct = Convert.ToString(txtGeneral.Text);
        string dtApplication="";
        string dtcertificateissue="";
        try
        {
         dtApplication = Convert.ToDateTime(txtDOAC.Text).ToString("MM/dd/yyyy");  //Convert.ToString(txtDOAC.Text);
        }
        catch
        {

        }
        try
        {
         dtcertificateissue = Convert.ToDateTime(txtDOIC.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOIC.Text);
        }
        catch
        {

        }

        string vchreasonlevaning = Convert.ToString(txtReasons.Text);
        string vchotherremark = Convert.ToString(txtRemarks.Text);


        string reportPath = Server.MapPath("rptTCcertificate.rpt");
        crystalReport.Load(reportPath);

        TextObject CRSRNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
        TextObject CRAdmissionNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text42"];
        TextObject CRvchStudent_name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
        TextObject CRvchFatherName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
        TextObject CRvchNationalty = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
        TextObject CRvchSCST = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
        TextObject CRdtAdmission = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
        TextObject CRdtDOB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
        //TextObject CRvchDOBword = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
        TextObject CRvchlastclassfig = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
        TextObject CRvchlastclassword = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];

        TextObject CRvchanuualexamlast = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text53"];
        TextObject CRvchsameclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
        TextObject CRvchsubjectStudied1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
        TextObject CRvchsubjectStudied2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];
        TextObject CRvchsubjectStudied3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
        TextObject CRvchsubjectStudied4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
        TextObject CRvchsubjectStudied5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
        TextObject CRvchsubjectStudied6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
        TextObject CRvchpromotionHigherclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
        TextObject CRvchpromotionHigherclassFig = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];

        TextObject CRvchpromotionHigherclassWord = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
        TextObject CRvchschoolduepaid = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
        TextObject CRvchfeeconcession = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
        TextObject CRvchNumberworkingday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
        TextObject CRvchNumberPresentday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
        TextObject CRvchNCC = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
        TextObject CRvchExtracurriculam = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
        TextObject CRvchGeneralconduct = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
        TextObject CRdtApplication = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
        TextObject CRdtcertificateissue = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];

        TextObject CRvchreasonlevaning = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
        TextObject CRvchotherremark = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];

       // CRSRNo.Text = SRNo;
        CRSRNo.Text = AdmissionNo;
        CRAdmissionNo.Text = BoardRegiNo; 
        CRvchStudent_name.Text = vchStudent_name;
        CRvchFatherName.Text = vchFatherName;
        CRvchNationalty.Text = vchNationalty;
        CRvchSCST.Text = vchSCST;
        CRdtAdmission.Text = dtAdmission;
        CRdtDOB.Text = dtDOB;
        //CRvchDOBword.Text = vchDOBword;
        CRvchlastclassfig.Text = vchlastclassfig;
        CRvchlastclassword.Text = vchlastclassword;

        CRvchanuualexamlast.Text = vchanuualexamlast;
        CRvchsameclass.Text = vchsameclass;
        CRvchsubjectStudied1.Text = vchsubjectStudied1;
        CRvchsubjectStudied2.Text = vchsubjectStudied2;
        CRvchsubjectStudied3.Text = vchsubjectStudied3;
        CRvchsubjectStudied4.Text = vchsubjectStudied4;
        CRvchsubjectStudied5.Text = vchsubjectStudied5;
        CRvchsubjectStudied6.Text = vchsubjectStudied6;
        CRvchpromotionHigherclass.Text = vchpromotionHigherclass;
        CRvchpromotionHigherclassFig.Text = vchpromotionHigherclassFig;

        CRvchpromotionHigherclassWord.Text = vchpromotionHigherclassWord;
        CRvchschoolduepaid.Text = vchschoolduepaid;
        CRvchfeeconcession.Text = vchfeeconcession;
        CRvchNumberworkingday.Text = vchNumberworkingday;
        CRvchNumberPresentday.Text = vchNumberPresentday;
        CRvchNCC.Text = vchNCC;
        CRvchExtracurriculam.Text = vchExtracurriculam;
        CRvchGeneralconduct.Text = vchGeneralconduct;
        CRdtApplication.Text = dtApplication;
        CRdtcertificateissue.Text = dtcertificateissue;

        CRvchreasonlevaning.Text = vchreasonlevaning;
        CRvchotherremark.Text = vchotherremark;

        crystalReport.Load(Server.MapPath(string.Format("rptTCcertificate.rpt")));
        AdmissionReport.ReportSource = crystalReport;


        //AdmissionReport.ReportSource = crystalReport;
    }
    protected void Update_Click(object sender, EventArgs e)
    {

        try
        {
            string SRNo = Convert.ToString(txtsrno.Text);
            string AdmissionNo = Convert.ToString(txtAdmission.Text);
            string BoardRegiNo = Convert.ToString(txtBoardRegi.Text);
            string vchStudent_name = Convert.ToString(txtnameofpupil.Text);
            string vchFatherName = Convert.ToString(txtfathername.Text);
            string vchNationalty = Convert.ToString(txtNationality.Text);
            string vchSCST = Convert.ToString(ddlscst.SelectedItem.Text);
            string dtAdmission = Convert.ToDateTime(txtDOA.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOA.Text);
            string dtDOB = Convert.ToDateTime(txtDOBfig.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
            string vchDOBword = Convert.ToString(txtDOBword.Text);
            string vchlastclassfig = Convert.ToString(txtlastclassfig.Text);
            string vchlastclassword = Convert.ToString(txtlastclassword.Text);

            string vchanuualexamlast = Convert.ToString(txtannualexamlast.Text);
            string vchsameclass = Convert.ToString(txtsameclass.Text);
            string vchsubjectStudied1 = Convert.ToString(subjectStudied1.Text);
            string vchsubjectStudied2 = Convert.ToString(subjectStudied2.Text);
            string vchsubjectStudied3 = Convert.ToString(subjectStudied3.Text);
            string vchsubjectStudied4 = Convert.ToString(subjectStudied4.Text);
            string vchsubjectStudied5 = Convert.ToString(subjectStudied5.Text);
            string vchsubjectStudied6 = Convert.ToString(subjectStudied6.Text);
            string vchpromotionHigherclass = Convert.ToString(txtpromo.Text);
            string vchpromotionHigherclassFig = Convert.ToString(txtHigherclassFig.Text);

            string vchpromotionHigherclassWord = Convert.ToString(txtHigherclassWord.Text);
            string vchschoolduepaid = Convert.ToString(txtduepaid.Text);
            string vchfeeconcession = Convert.ToString(txtAny.Text);
            string vchNumberworkingday = Convert.ToString(txttotalday.Text);
            string vchNumberPresentday = Convert.ToString(txtWorkingDays.Text);
            string vchNCC = Convert.ToString(txtNCC.Text);
            string vchExtracurriculam = Convert.ToString(txtCurricular.Text);
            string vchGeneralconduct = Convert.ToString(txtGeneral.Text);
            string dtApplication = Convert.ToDateTime(txtDOAC.Text).ToString("MM/dd/yyyy");  //Convert.ToString(txtDOAC.Text);
            string dtcertificateissue = Convert.ToDateTime(txtDOIC.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOIC.Text);
            string intstudentId = Convert.ToString(Session["StudentID"]);
            string vchreasonlevaning = Convert.ToString(txtReasons.Text);
            string vchotherremark = Convert.ToString(txtRemarks.Text);

            string instrquery1 = "Execute dbo.usp_TCcertificate @command='UpdateTccertificate',@SRNo='" + SRNo + "',@AdmissionNo='" + AdmissionNo + "',@intStudent_id='" + intstudentId + "',@vchStudent_name='" + vchStudent_name + "',@vchFatherName='" + vchFatherName + "',@vchNationalty='" + vchNationalty + "',@vchSCST='" + vchSCST + "',@dtAdmission='" + dtAdmission + "'," +
                                  "@dtDOB='" + dtDOB + "',@vchDOBword='" + vchDOBword + "',@vchlastclassfig='" + vchlastclassfig + "',@vchlastclassword='" + vchlastclassword + "',@vchanuualexamlast='" + vchanuualexamlast + "',@vchsameclass='" + vchsameclass + "',@vchsubjectStudied1='" + vchsubjectStudied1 + "',@vchsubjectStudied2='" + vchsubjectStudied2 + "',@vchsubjectStudied3='" + vchsubjectStudied3 + "',@vchsubjectStudied4='" + vchsubjectStudied4 + "',@vchsubjectStudied5='" + vchsubjectStudied5 + "',@vchsubjectStudied6='" + vchsubjectStudied6 + "'," +
                                  "@vchpromotionHigherclass='" + vchpromotionHigherclass + "',@vchpromotionHigherclassFig='" + vchpromotionHigherclassFig + "',@vchschoolduepaid='" + vchschoolduepaid + "',@vchfeeconcession='" + vchfeeconcession + "',@vchNumberworkingday='" + vchNumberworkingday + "',@vchNumberPresentday='" + vchNumberPresentday + "',@vchNCC='" + vchNCC + "',@vchExtracurriculam='" + vchExtracurriculam + "'," +
                                  "@vchGeneralconduct='" + vchGeneralconduct + "',@dtApplication='" + dtApplication + "',@dtcertificateissue='" + dtcertificateissue + "',@vchreasonlevaning='" + vchreasonlevaning + "',@vchotherremark='" + vchotherremark + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "',@BoardRegiNo='" + BoardRegiNo + "'";



            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                //Code by Nikhil
                strQry = "exec usp_TCcertificate @command='Selectstudent',@intstudent_id='" + intstudentId + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["rptUpdatedStudentdetail"] = dsObj;


                string display = "Updated Successfuly!";
                MessageBox(display);
                btnSubmit.Text = "Submit";
                //ButN6.Visible = false;
                // Clear();
                //fGrid();

                Response.Redirect("rpttccertificate.aspx", true);

            }
            else
            {
                MessageBox("ooopppsss!TC certificate updation Failed");

            }


        }
        catch
        {
            MessageBox("ooopppsss!TC certificate submission Failed");
        }
        //}

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        //DataSet dsObj = new DataSet();
        //string strQry = "";
        //strQry = "exec usp_FillDropDown @type='GetStudentsresult',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        ////strQry = "exec usp_ExamMarks @type='ExamMark_Halfall',@intStudent_id='" + ddlStudent.SelectedValue.ToString() + "',@intExam_id='" + ddlExam.SelectedValue.ToString() + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
        ////        dsObjgrade = sGetDataset(strQry);
        //dsObj = sGetDataset(strQry);
        //Session["rptAllStudentMark"] = dsObj;
        //if (btnSubmit.Text == "Submit")
        //{

            try
            {
                string SRNo = Convert.ToString(txtsrno.Text);
                string AdmissionNo = Convert.ToString(txtAdmission.Text);
                string BoardRegiNo = Convert.ToString(txtBoardRegi.Text);
                string vchStudent_name = Convert.ToString(txtnameofpupil.Text);
                string vchFatherName = Convert.ToString(txtfathername.Text);
                string vchNationalty = Convert.ToString(txtNationality.Text);
                string vchSCST = Convert.ToString(ddlscst.SelectedItem.Text);
                string dtAdmission = Convert.ToDateTime(txtDOA.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOA.Text);
                string dtDOB = Convert.ToDateTime(txtDOBfig.Text).ToString("dd/MMMM/yyyy"); //Convert.ToString(txtDOBword.Text);
                string vchDOBword = Convert.ToString(txtDOBword.Text);
                string vchlastclassfig = Convert.ToString(txtlastclassfig.Text);
                string vchlastclassword = Convert.ToString(txtlastclassword.Text);

                string vchanuualexamlast = Convert.ToString(txtannualexamlast.Text);
                string vchsameclass = Convert.ToString(txtsameclass.Text);
                string vchsubjectStudied1 = Convert.ToString(subjectStudied1.Text);
                string vchsubjectStudied2 = Convert.ToString(subjectStudied2.Text);
                string vchsubjectStudied3 = Convert.ToString(subjectStudied3.Text);
                string vchsubjectStudied4 = Convert.ToString(subjectStudied4.Text);
                string vchsubjectStudied5 = Convert.ToString(subjectStudied5.Text);
                string vchsubjectStudied6 = Convert.ToString(subjectStudied6.Text);
                string vchpromotionHigherclass = Convert.ToString(txtpromo.Text);
                string vchpromotionHigherclassFig = Convert.ToString(txtHigherclassFig.Text);

                string vchpromotionHigherclassWord = Convert.ToString(txtHigherclassWord.Text);
                string vchschoolduepaid = Convert.ToString(txtduepaid.Text);
                string vchfeeconcession = Convert.ToString(txtAny.Text);
                string vchNumberworkingday = Convert.ToString(txttotalday.Text);
                string vchNumberPresentday = Convert.ToString(txtWorkingDays.Text);
                string vchNCC = Convert.ToString(txtNCC.Text);
                string vchExtracurriculam = Convert.ToString(txtCurricular.Text);
                string vchGeneralconduct = Convert.ToString(txtGeneral.Text);
                string dtApplication = Convert.ToDateTime(txtDOAC.Text).ToString("MM/dd/yyyy");  //Convert.ToString(txtDOAC.Text);
                string dtcertificateissue = Convert.ToDateTime(txtDOIC.Text).ToString("MM/dd/yyyy");// Convert.ToString(txtDOIC.Text);

                string vchreasonlevaning = Convert.ToString(txtReasons.Text);
                string vchotherremark = Convert.ToString(txtRemarks.Text);

                string instrquery1 = "Execute dbo.usp_TCcertificate @command='InsertTccertificate',@SRNo='" + SRNo + "',@AdmissionNo='" + AdmissionNo + "',@intStudent_id='" + ddlStudent.SelectedValue + "',@vchStudent_name='" + vchStudent_name + "',@vchFatherName='" + vchFatherName + "',@vchNationalty='" + vchNationalty + "',@vchSCST='" + vchSCST + "',@dtAdmission='" + dtAdmission + "'," +
                                      "@dtDOB='" + dtDOB + "',@vchDOBword='" + vchDOBword + "',@vchlastclassfig='" + vchlastclassfig + "',@vchlastclassword='" + vchlastclassword + "',@vchanuualexamlast='" + vchanuualexamlast + "',@vchsameclass='" + vchsameclass + "',@vchsubjectStudied1='" + vchsubjectStudied1 + "',@vchsubjectStudied2='" + vchsubjectStudied2 + "',@vchsubjectStudied3='" + vchsubjectStudied3 + "',@vchsubjectStudied4='" + vchsubjectStudied4 + "',@vchsubjectStudied5='" + vchsubjectStudied5 + "',@vchsubjectStudied6='" + vchsubjectStudied6 + "'," +
                                      "@vchpromotionHigherclass='" + vchpromotionHigherclass + "',@vchpromotionHigherclassFig='" + vchpromotionHigherclassFig + "',@vchschoolduepaid='" + vchschoolduepaid + "',@vchfeeconcession='" + vchfeeconcession + "',@vchNumberworkingday='" + vchNumberworkingday + "',@vchNumberPresentday='" + vchNumberPresentday + "',@vchNCC='" + vchNCC + "',@vchExtracurriculam='" + vchExtracurriculam + "'," +
                                      "@vchGeneralconduct='" + vchGeneralconduct + "',@dtApplication='" + dtApplication + "',@dtcertificateissue='" + dtcertificateissue + "',@vchreasonlevaning='" + vchreasonlevaning + "',@vchotherremark='" + vchotherremark + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "',@BoardRegiNo='" + BoardRegiNo + "'";



                int str = sExecuteQuery(instrquery1);

                if (str != -1)
                {
                    string display = "Submit Successfuly!";
                    MessageBox(display);
                    btnSubmit.Text = "Submit";
                    //ButN6.Visible = false;
                    // Clear();
                    //fGrid();

                    Response.Redirect("rpttccertificate.aspx", true);

                }
                else
                {
                    MessageBox("ooopppsss!TC certificate submission Failed");

                }
                

            }
            catch
            {
                MessageBox("ooopppsss!TC certificate submission Failed");
            }
        //}














        

        //try
        //{
        //    //int i = 0;
        //    string reportPath = Server.MapPath("rptTCcertificate.rpt");
        //    crystalReport.Load(reportPath);
        //}

        //catch
        //{ 
        
        //}

    }
}