﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class MasterPage2 : System.Web.UI.MasterPage
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    DataSet dsObj = new DataSet();
    string[] xAxis;
    int[] yAxis;
    DataTable dt = new DataTable();
    string strQry = "";
    string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
    SqlConnection sqlCon = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlCon = new SqlConnection(strCOn);
        if (!IsPostBack)
        {
            FillPersonlDetail();
            lblAcademicYear.Text = Convert.ToString(Session["YearName"]); 
            if ((Convert.ToString(Session["strUserType"]) == "1") || (Convert.ToString(Session["strUserType"]) == "2"))
            {
                self.Visible = false;
                Teacher.Visible = false;
                Staff.Visible = false;
                Student.Visible = false;
                Dashboard.HRef = "studentDB.aspx";
                StuduMod.Visible = true;
                if (Convert.ToString(Session["strUserType"]) == "2")
                {
                    profileview.HRef = "frmNewStudentProfile.aspx";
                    StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";
                }
                else
                {
                    profileview.HRef = "frmNewStudentProfile.aspx";
                    StudentLeaveLink.HRef = "frmStudentLeaveMenu.aspx";

                }


                StudentMonthly.Visible = true;
                StudentMonthly.HRef = "frmMonthlyAttendance.aspx";
                TeacherMonthly.Visible = false;

                TeacherLeave.Visible = false;
                TeacherApproval.Visible = false;
                StudentLeave.Visible = true;
                PlanLeave.Visible = false;
                TimeTable.HRef = "frmStudentTimeTable.aspx";
                MyDiarylink.HRef = "frmMyDiaryStudent.aspx";
                Payments.Visible = true;
                profile.Visible = false;
                liabrary.Visible = false;
                Bus.Visible = true;
                NoticeBoard.Visible = true;
                MyDiary.Visible = true;
                Master.Visible = false;
                Reports.Visible = false;
                Admission.Visible = false;
                MarkAttendance.Visible = false;
                Transporter.Visible = false;
                SyllabusMst.HRef = "frmViewSyllabus.aspx";
                StaffAttendance.Visible = false;
                TeacherAttendance.Visible = false;
                Result.HRef = "Result.aspx";
                Hostel.Visible = false;
                HostelMaster.Visible = false;
                Result.Visible = false;
                LinBookCardAss.Visible = false;
                LinBookAssStu.Visible = false;
                InquiryReception.Visible = false;
                AsstAssignment.Visible = false;
                Sports.Visible = false;
                SportsMaster.Visible = false;
                Trash.Visible = false;
               ComplaintSuggestion.Visible = false;
                Feecollection.Visible = false;
                frmMessaging.Visible = false;
            }

           // if (Convert.ToString(Session["strUserType"]) == "1")
           // {
           //     frmMessaging.Visible = false;
           //     Dashboard.HRef = "studentDB.aspx";
           //     profileview.HRef = "frmNewStudentProfile.aspx";
           //     StudentLeaveLink.HRef = "frmStudentLeaveMenu.aspx";
           //     strQry = "exec usp_ModuleAssignment  @command='getstudentAssModule',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
           //     dsObj = sGetDataset(strQry);


                
           // }
           //else if (Convert.ToString(Session["strUserType"]) == "2")
           // {
           //     frmMessaging.Visible = false;
           //     Dashboard.HRef = "studentDB.aspx";
           //     profileview.HRef = "frmNewStudentProfile.aspx";
           //     StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";
           //     strQry = "exec usp_ModuleAssignment  @command='getParentAssModule',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
           //     dsObj = sGetDataset(strQry);


                
           // }

            //else if (Convert.ToString(Session["strUserType"]) == "3")
            //{
            //    frmMessaging.Visible = false;
            //    Dashboard.HRef = "TeacherDB.aspx";
            //    profileview.HRef = "FrmTeacherProfile.aspx?successMessage=1";
            //    StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";
            //    strQry = "exec usp_ModuleAssignment  @command='getTeacherAssModule',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            //    dsObj = sGetDataset(strQry);
            //    Report4.Visible = false;

                
            //}
            else if (Convert.ToString(Session["strUserType"]) == "4")
            {
                if (Convert.ToString(Session["UserName"]) == "Liabrarian")
                {
                    Dashboard.HRef = "StaffDB.aspx";
                    liabrary.Visible = false;
                    SchoolMaster.Visible = false;
                    frmMessaging.Visible = false;
                    liabrary.Visible = false;
                    //trashfeesmaster.Visible = false;
                    //LibraryTrash.Visible = false;
                    HostelTrash.Visible = false;
                    TransporterTrash.Visible = false;
                    TransportMaster.Visible = false;
                    Trash.Visible = false;
                    StuduMod.Visible = true;
                    AdminMarkAttendance.Visible = false;
                    Leave.Visible = true;
                    InquiryReception.Visible = false;
                    Hostel.Visible = false;
                    StuduMod.Visible = false;
                    Calendar.Visible = true;
                    //AssignModulDetails.Visible = true;
                    Setting.Visible = false;
                    //AssignModu.Visible = true;
                    AssetMaster.Visible = false;
                    InventoryMaster.Visible = false;
                    FeeMaster.Visible = false;
                    Inventory.Visible = false;
                    self.Visible = false;
                    Master.Visible = true;
                    Teacher.Visible = false;
                    Staff.Visible = false;
                    Student.Visible = false;
                    //Dashboard.HRef = "AdminDB.aspx";
                    StudentMonthly.Visible = false;
                    TeacherMonthly.Visible = false;
                    Leave.HRef = "#";
                    TeacherLeave.Visible = false;
                    TeacherApproval.Visible = false;
                    StudentLeave.Visible = false;
                    PlanLeave.Visible = false;
                    TimeTable.Visible = true;
                    profile.Visible = false;
                    //profileview.HRef = "FrmAdminProfile.aspx?successMessage=1";
                    Payments.Visible = false;
                    Bus.Visible = false;
                    NoticeBoard.Visible = false;
                    MyDiary.Visible = false;
                    PromotionsAll.Visible = false;
                    Reports.Visible = false;
                    Admission.Visible = false;
                    MarkAttendance.Visible = false;
                    self.Visible = false;
                    Transporter.Visible = false;
                    //SyllabusMst.HRef = "frmSyllabusMst.aspx";
                    StaffAttendance.Visible = false;
                    TeacherAttendance.Visible = false;
                    //Result.HRef = "frmMarksEntry.aspx";
                    HostelMaster.Visible = false; ;
                    TeacherselfPro.Visible = false;
                    StaffPro.Visible = false;
                    LinBookself.Visible = false;
                    AsstAssignment.Visible = false;
                    Sports.Visible = false;
                    SportsMaster.Visible = false;
                    ComplaintSuggestion.Visible = false;
                    Feecollection.Visible = false;

                }
                else
                {

                    Dashboard.HRef = "StaffDB.aspx";
                    profileview.HRef = "FrmTeacherProfile.aspx?successMessage=1";
                    StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";
                    LoginReport.Visible = false;
                    Report1.Visible = false;
                    Report2.Visible = false;
                    Report3.Visible = false;
                    Report4.Visible = false;
                    self.Visible = true;
                    StuduMod.Visible = true;
                    Master.Visible = false;
                    Teacher.Visible = false;
                    Student.Visible = true;
                    StudentMonthly.Visible = false;
                    TeacherMonthly.Visible = true;
                    MyDiarylink.HRef = "frmMyDiary.aspx";
                   // Leave.HRef = "#";
                    Leave.Visible = true;
                    TeacherLeave.Visible = true;
                    TeacherApproval.Visible = true;
                    StudentLeave.Visible = false;
                    PlanLeave.Visible = false;
                    TimeTable.Visible = true;
                    profile.Visible = true;
                    Payments.Visible = false;
                    liabrary.Visible = false;
                    Bus.Visible = false;
                    NoticeBoard.Visible = true;
                    MyDiary.Visible = true;
                    Reports.Visible = false;
                    Admission.Visible = false;
                    MarkAttendance.Visible = true;
                    Transporter.Visible = false;
                    StaffAttendance.Visible = false;
                    TeacherAttendance.Visible = false;
                    Result.HRef = "frmMarksEntry.aspx";
                    Hostel.Visible = false;
                    AdminPro.Visible = false;
                    TeacherPro.Visible = false;
                    LinBookself.Visible = true;
                    AsstAssignment.Visible = false;
                    Sports.Visible = false;
                    SportsMaster.Visible = false;
                    Trash.Visible = false;
                    ComplaintSuggestion.Visible = false;
                    Feecollection.Visible = false;
                    frmMessaging.Visible = false;
                }

            }


            else if ((Convert.ToString(Session["strUserType"]) == "3"))
            {
                self.Visible = true;
                Master.Visible = false;
                Teacher.Visible = false;
                Student.Visible = true;
                Dashboard.HRef = "TeacherDB.aspx";
                StudentMonthly.Visible = false;
                TeacherMonthly.Visible = true;
                profileview.HRef = "FrmTeacherProfile.aspx?successMessage=1";
                MyDiarylink.HRef = "frmMyDiary.aspx";
                Leave.HRef = "#";
                TeacherLeave.Visible = true;
                TeacherApproval.Visible = true;
                StudentLeave.Visible = false;
                PlanLeave.Visible = false;
                TimeTable.Visible = true;
                profile.Visible = true;
                Payments.Visible = false;
                liabrary.Visible = false;
                Bus.Visible = false;
                NoticeBoard.Visible = true;
                MyDiary.Visible = true;
                StuduMod.Visible = true;
                Reports.Visible = false;
                Admission.Visible = false;
                MarkAttendance.Visible = true;
                Transporter.Visible = false;
                StaffAttendance.Visible = false;
                TeacherAttendance.Visible = false;
                Result.HRef = "frmMarksEntry.aspx";
                Hostel.Visible = false;
                AdminPro.Visible = false;
                TeacherPro.Visible = false;
                LinBookself.Visible = true;
                AsstAssignment.Visible = false;
                Sports.Visible = false;
                SportsMaster.Visible = false;
                Trash.Visible = false;
                ComplaintSuggestion.Visible = false;
                Feecollection.Visible = false;
                frmMessaging.Visible = false;
                TimeTable.Visible = false;
            }
            else if ((Convert.ToString(Session["strUserType"]) == "5"))
            {
                frmMessaging.Visible = true;             
                liabrary.Visible = false;
                //trashfeesmaster.Visible = true;
                //LibraryTrash.Visible = true;
                HostelTrash.Visible = false;
                TransporterTrash.Visible = false;
                TransportMaster.Visible = false;
                Trash.Visible = false;
                AdminMarkAttendance.Visible = true;
                Leave.Visible = true;
                InquiryReception.Visible = true;
                Hostel.Visible = false;
                StuduMod.Visible = true;
                Calendar.Visible = true;
                //AssignModulDetails.Visible = true;
                Setting.Visible = true;
                //AssignModu.Visible = true;
                AssetMaster.Visible = false;
                InventoryMaster.Visible = false;
                FeeMaster.Visible = true;
                Inventory.Visible = false;
                
                self.Visible = true;
                Master.Visible = true;
                Teacher.Visible = true;
                Staff.Visible = true;
                Student.Visible = true;
                Dashboard.HRef = "AdminDB.aspx";
                StudentMonthly.Visible = false;
                TeacherMonthly.Visible = true;
                Leave.HRef = "#";
                TeacherLeave.Visible = true;
                TeacherApproval.Visible = true;
                StudentLeave.Visible = false;
                PlanLeave.Visible = false;
                TimeTable.Visible = true;
                profile.Visible = true;
                profileview.HRef = "FrmAdminProfile.aspx?successMessage=1";
                Payments.Visible = false;                
                Bus.Visible = false;
                NoticeBoard.Visible = true;
                MyDiary.Visible = false;
                PromotionsAll.Visible = true;
                Reports.Visible = true;
                Admission.Visible = true;
                MarkAttendance.Visible = true;
                self.Visible = false;
                Transporter.Visible = false;
                SyllabusMst.HRef = "frmSyllabusMst.aspx";
                StaffAttendance.Visible = true;
                TeacherAttendance.Visible = true;
                Result.HRef = "frmMarksEntry.aspx";
                HostelMaster.Visible = false; ;
                TeacherselfPro.Visible = false;
                StaffPro.Visible = true;
                LinBookself.Visible = false;
                AsstAssignment.Visible = false;
                Sports.Visible = false;
                SportsMaster.Visible = false;               
                ComplaintSuggestion.Visible = true;
                Feecollection.Visible = true;
                A3.Visible = true;
                A4.Visible = true;
                A5.Visible = true;
                A8.Visible = true;
                Trash.Visible = true;
                //A1.Visible = true;
                //A2.Visible = true;
                //A6.Visible = true;
                //A7.Visible = true;
                // Result.Visible = false;   ///////////m//////////////

                //Manager
                if (Convert.ToString(Session["DepartmentID"]) == "9")
                {
                    FeeMaster.Visible = false;
                    Feecollection.Visible = false;
                    //STDWiseRpt.Visible = false;
                    RptFeeCollection.Visible = false;
                  //  STDWiseFeeCollection.Visible = false;
                   // HeadWiseFeeRpt.Visible = false;
                }

             //Principal
                else if (Convert.ToString(Session["DepartmentID"]) == "10")
                {
                    FeeMaster.Visible = false;
                    Feecollection.Visible = false;
                   // STDWiseRpt.Visible = false;
                    RptFeeCollection.Visible = false;
                   // STDWiseFeeCollection.Visible = false;
                   // HeadWiseFeeRpt.Visible = false;
                }
                //Accountant
                else if (Convert.ToString(Session["DepartmentID"]) == "11")
                {
                    frmMessaging.Visible = false;
                    SchoolMaster.Visible = false;
                    //Feecollection.Visible = false;
                    StudentMonthly.Visible = false;
                    TeacherMonthly.Visible = false;
                    StuduMod.Visible = false;
                    profile.Visible = false;
                    NoticeBoard.Visible = false;
                    Setting.Visible = false;
                    Calendar.Visible = false;
                    Leave.Visible = false;
                    //gallery.Visible = true;
                    InquiryReception.Visible = false;
                    LoginReport.Visible = false;
                    StudentDetails.Visible = false;
                   // SMSRpt.Visible = false;
                    StudentAttendance.Visible = false;
                    Report1.Visible = false;
                    Report4.Visible = false;
                    Report2.Visible = false;
                    Report3.Visible = false;
                    TeacherWiseTT.Visible = false;
                    StudentWiseTT.Visible = false;
                    StudPreAbCount.Visible = false;
                   // MonthlyotRpt.Visible = false;
                   // AnnualOtRpt.Visible = false;
                   // TransportOTRpt.Visible = false;
                }

            }
            if (Convert.ToString(Session["School_id"]) == "1")
            {


                //A3.Visible = true;
               // A4.Visible = true;
                //A5.Visible = true;
               // A8.Visible = true;

            }
            else if (Convert.ToString(Session["School_id"]) == "2")
            {
                //A1.Visible = true;
               // A2.Visible = true;
               // A6.Visible = true;
               // A7.Visible = true;

            }
        }
    }
    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_DetailNew',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                //ImgProfile.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //imgProfileImage.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //ImgPro.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);


                ImgProfile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                imgProfileImage.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                ImgPro.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);


                lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='P_Detail_DB',@intParent_id='" + Convert.ToString(Session["User_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //ImgProfile.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //imgProfileImage.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //ImgPro.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);

                ImgProfile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                imgProfileImage.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                ImgPro.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "3")
            {
                strQry = "exec [usp_TeacherDashboard] @type='TitleBar',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intuserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    ImgProfile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    imgProfileImage.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    ImgPro.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    //ImgProfile.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //ImgPro.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //imgProfileImage.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                    //ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //ImgPro.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "4")
            {
                strQry = "exec [usp_StaffDashboard] @type='StaffTitleBarNew',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    ImgProfile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    imgProfileImage.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    ImgPro.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);

                    //ImgProfile.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //ImgPro.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //imgProfileImage.ImageUrl = "~\\images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                    //ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //ImgPro.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "5")
            {
                strQry = "exec [usp_NewAdminDashboard] @type='AdminTitleBarNew',@UserId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ImgProfile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    ImgPro.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);
                    imgProfileImage.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);

                    //ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //ImgPro.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                }
            }
        }
        catch
        {

        }
    }
    public DataSet sGetDataset(string sQuery)
    {
        DataSet Retds = new DataSet();
        try
        {

            SqlDataAdapter da = new SqlDataAdapter(sQuery, sqlCon);
            if (da != null)
            {
                da.Fill(Retds);
            }
            else
            {
                Retds = null;
            }
        }
        catch (Exception ex)
        {
            Retds = null;
            //MessageBox.Show(ex.ToString());
        }

        return Retds;
    }
}
