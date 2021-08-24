using System;
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
            if ((Convert.ToString(Session["strUserType"]) == "1") || (Convert.ToString(Session["strUserType"]) == "2"))
            {
                self.Visible = false;
                Teacher.Visible = false;
                Staff.Visible = false;
                Student.Visible = false;
                Dashboard.HRef = "studentDB.aspx";

                if (Convert.ToString(Session["strUserType"]) == "2")
                {
                    //profileview.HRef = "frmNewStudentProfile.aspx";
                    //StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";
                }
                else
                {
                    //profileview.HRef = "frmNewStudentProfile.aspx";
                    //StudentLeaveLink.HRef = "frmStudentLeaveMenu.aspx";

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
                Bus.Visible = true;
                NoticeBoard.Visible = true;
                MyDiary.Visible = true;
                Master.Visible = false;
                Reports.Visible = true;
                Admission.Visible = false;
                MarkAttendance.Visible = false;
                //SyllabusMst.HRef = "frmViewSyllabus.aspx";
                StaffAttendance.Visible = false;
                TeacherAttendance.Visible = false;
                //Result.HRef = "Result.aspx";
                Result.Visible = false;
                Feecollection.Visible = false;
                frmMessaging.Visible = false;
            }
            
            else if (Convert.ToString(Session["strUserType"]) == "4")
            {
                Dashboard.HRef = "StaffDB.aspx";
                //profileview.HRef = "FrmTeacherProfile.aspx?successMessage=1";
                //StudentLeaveLink.HRef = "FrmPareLeavAppro.aspx";               
                //LoginReport.Visible = false;
                Report1.Visible = false;
                Report2.Visible = false;
                Report3.Visible = false;
                Report4.Visible = false;
                self.Visible = true;
                Master.Visible = false;
                Teacher.Visible = false;
                Student.Visible = true;                
                StudentMonthly.Visible = false;
                TeacherMonthly.Visible = true;               
                MyDiarylink.HRef = "frmMyDiary.aspx";
                Leave.HRef = "#";
                TeacherLeave.Visible = true;
                TeacherApproval.Visible = true;
                StudentLeave.Visible = false;
                PlanLeave.Visible = false;
                TimeTable.HRef = "frmTeacherTimeTable.aspx";
                profile.Visible = true;
                Payments.Visible = false;
                Bus.Visible = false;
                NoticeBoard.Visible = true;
                MyDiary.Visible = true;
                Reports.Visible = true;
                Admission.Visible = false;
                MarkAttendance.Visible = true;
                StaffAttendance.Visible = false;
                TeacherAttendance.Visible = false;
                //Result.HRef = "frmMarksEntry.aspx";
                AdminPro.Visible = false;
                TeacherPro.Visible = false;
                Feecollection.Visible = false;
                frmMessaging.Visible = false;
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
                //profileview.HRef = "FrmTeacherProfile.aspx?successMessage=1";
                MyDiarylink.HRef = "frmMyDiary.aspx";
                Leave.HRef = "#";
                TeacherLeave.Visible = true;
                TeacherApproval.Visible = true;
                StudentLeave.Visible = false;
                PlanLeave.Visible = false;
                TimeTable.HRef = "frmTeacherTimeTable.aspx";
                profile.Visible = true;
                Payments.Visible = false;
                Bus.Visible = false;
                NoticeBoard.Visible = true;
                MyDiary.Visible = true;

                Reports.Visible = true;
                Admission.Visible = false;
                MarkAttendance.Visible = true;
                StaffAttendance.Visible = false;
                TeacherAttendance.Visible = false;
                //Result.HRef = "frmMarksEntry.aspx";
                AdminPro.Visible = false;
                TeacherPro.Visible = false;
                Feecollection.Visible = false;
                frmMessaging.Visible = false;
            }
            else if ((Convert.ToString(Session["strUserType"]) == "5"))
            {
                frmMessaging.Visible = true; 
                AdminMarkAttendance.Visible = true;
                Leave.Visible = true;
                StuduMod.Visible = true;
                Calendar.Visible = true;
                //AssignModulDetails.Visible = true;
                Setting.Visible = true;
                //AssignModu.Visible = true;
                //FeeMaster.Visible = true;
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
                TimeTable.HRef = "frmTeacherTimeTable.aspx";
                profile.Visible = true;
                //profileview.HRef = "FrmAdminProfile.aspx?successMessage=1";
                Payments.Visible = false;                
                Bus.Visible = false;
                NoticeBoard.Visible = true;
                MyDiary.Visible = false;
                PromotionsAll.Visible = true;
                Reports.Visible = true;
                Admission.Visible = true;
                MarkAttendance.Visible = true;
                self.Visible = false;
                //SyllabusMst.HRef = "frmSyllabusMst.aspx";
                StaffAttendance.Visible = true;
                TeacherAttendance.Visible = true;
                //Result.HRef = "frmMarksEntry.aspx";
                TeacherselfPro.Visible = false;
                StaffPro.Visible = true;  
                Feecollection.Visible = false;
                // Result.Visible = false;   ///////////m//////////////
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
                //lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                ////lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                //ImgProfile.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //imgProfileImage.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //ImgPro.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                //lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='P_Detail_DB',@intParent_id='" + Convert.ToString(Session["User_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                //lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Personal"]);
                //ImgProfile.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //imgProfileImage.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //ImgPro.ImageUrl = "~\\images\\Profile\\Father\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);
                //lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
            }
            else if (Convert.ToString(Session["UserType_id"]) == "3")
            {
                strQry = "exec [usp_TeacherDashboard] @type='TitleBar',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intuserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //ImgProfile.ImageUrl = "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //ImgPro.ImageUrl = "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //imgProfileImage.ImageUrl = "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                    ////ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////ImgPro.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Teachers\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    //lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    //lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "4")
            {
                strQry = "exec [usp_StaffDashboard] @type='StaffTitleBarNew',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //ImgProfile.ImageUrl = "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //ImgPro.ImageUrl = "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //imgProfileImage.ImageUrl = "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                    ////ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////ImgPro.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Staffs\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    //lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    //lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "5")
            {
                strQry = "exec [usp_NewAdminDashboard] @type='AdminTitleBarNew',@UserId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    //ImgProfile.ImageUrl = "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //ImgPro.ImageUrl = "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    //imgProfileImage.ImageUrl = "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                    ////ImgProfile.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////ImgPro.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    ////imgProfileImage.Attributes.Add("src", "~\\images\\Profile\\Admins\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    //lblWelCome.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblWelComenew.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblFullnameNext.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                    //lblSchoolName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SchoolName"]);
                    //lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
                    //lblDesignation1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDesignation"]);
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
