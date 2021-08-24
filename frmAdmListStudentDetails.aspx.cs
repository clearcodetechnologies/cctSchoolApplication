using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmAdmListStudentDetails : DBUtility
{
    DataSet dsObj1 = new DataSet();
    DataSet dsObj = new DataSet();
    DataTable dtConcession = new DataTable();
    int ID = 0;
    string serverpath = "http://VClassrooms.com/vclassroomsSchoolDemoAPI/image/";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string pwd = txtPassword.Text;
            txtPassword.Attributes.Add("value", pwd);

            //DateTime dat= DateTime.Now;
            //date1.Text = dat.AddYears(-1).ToString();
            date1.Text = (DateTime.Now).AddYears(-2).ToShortDateString();    

            
            if (!IsPostBack)
            {
				btnSubmit.Visible = false;
                checksession();
                geturl();
                getCountry();
                //     DropDownList2.SelectedValue = "0";
                string query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownList(DropDownList2, query2, "Standard_name", "intStandard_id");
                sBindDropDownList(ddlStandrd, query2, "Standard_name", "intStandard_id");
                
                //fGrid();
                FillCategory();
                string st3 = Request.QueryString["successMessage3"];
                if (st3 != null)
                {
                    query();
                }
                else
                {
                    TabContainer1.ActiveTabIndex = 0;
                    Update.Visible = false;

                    TabPanel1.Visible = true;
                    TabPanel1.Enabled = true;
                   
                }
            }
            if (txt7.Text != "")
            {
                ViewState["Dob"] = txt7.Text;
            }
            if (FileUpload1.HasFile)
            {
                ViewState["Filename"] = FileUpload1.PostedFile.FileName;
            }
        }
        catch
        {

        }
    }
    protected void FillCategory()
    {
        string strQry = "usp_Profile @command='selectCategory',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(txt9, strQry, "vchCategory", "intCat_Id");

         //strQry = "exec [usp_Feetype_master]  @command='select',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
         //stcardp = sBindDropDownList(drpconcession, strQry, "Fee_Name", "intFeetype_id");

        //strQry = "exec [usp_concession_master]  @command='select',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        //stcardp = sBindDropDownList(drpconcession, strQry, "vchConcession_name", "intConcession_id");

        //strQry = "exec usp_FeesAssignSTD @type='FillArea',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        //sBindDropDownList(drptransport, strQry, "vchArea_Name", "intArea_Id");


    }
    protected void getCountry()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetCountry',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCountryName, str1, "vchCountry", "intCountry_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getState()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetState',@intCountry_id='" + DdlCountryName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlStateName, str1, "vchState", "intState_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getCity()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetCity',@intCountry_id='" + DdlCountryName.SelectedValue.Trim() + "',@intState_id='" + DdlStateName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCityName, str1, "vchCity", "intCity_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void fGrid()
    {
       string strQry = "usp_Profile @command='selectStudents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        txtGRNo.Text = "";
        DropDownList2.ClearSelection();       
        DropDownList3.ClearSelection();
        TextBox1.Text = "";
        txt1.Text = "";
        txt2.Text = "";
        txt3.Text = "";
        txt4.Text = "";
        txt5.Text = "";
        txt6.Text = "";
        txt7.Text = "";
       // txt9.ClearSelection();
        txt10.Text = "";
        txt11.ClearSelection();
        txt13.Text = "";
        txt14.Text = "";
        txt34.Text = "";
        txt35.Text = "";
        txt44.Text = "";
        DropDownList1.ClearSelection();
        txt45.Text = "";
        txtStudentID.Text = "";
        txtPlaceOfBirth.Text = "";
        txtSMSMobile.Text = "";
        txtAdmissionDate.Text = "";
        txtMothertounge.Text = "";
        txtReligion.Text = "";
        txtFirstLanguage.Text = "";
        txtSecondLanguage.Text = "";
        txtThirdLanguage.Text = "";
        txtstdaadhar.Text = "";
        txtmotheraadhar.Text = "";
        txtfatheraadhar.Text = "";
        txtFatherOccupation.Text = "";
        txtMotherOccupation.Text = "";
        txtFatherDesignation.Text = "";
        txtMotherDesignation.Text = "";
        txtFatherIncome.Text = "";
        txtMotherIncome.Text = "";
        txtNationality.Text = "";
        txtLandmark.Text = "";
        txtPincode.Text = "";
        txtGuardianName.Text = "";
        txtGuardianNumber.Text = "";
    }
    protected void query()
    {
        string st3 = Request.QueryString["successMessage3"];
        idv1.Text = st3;
        TabContainer1.ActiveTabIndex = 0;
        string query1 = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + st3 + "',@intSchool_id='" + Session["School_id"] + "'";

        dsObj = sGetDataset(query1);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            Session["Table"] = dsObj;

            if (((DataSet)Session["Table"] != null))
            {

                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    string standcv1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                    DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);

                    string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + standcv1 + "' ";
                    bool st2 = sBindDropDownList(DropDownList3, que2, "vchDivisionName", "intDivision_id");
                    DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                    txt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                    txt2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                    txt3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                    txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    txt5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                    txt6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                    txt7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                    txt9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                    txt10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                    txt11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                    txt13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherMobile"]);
                    txt14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                    string src11 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    String savePath = "~/images/";

                    imgViewFile.ImageUrl = savePath + src11;
                    txt34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                    txt35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPermanent"]);
                    txt44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                    DropDownList1.SelectedItem.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                    txt45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);
                    
                    Update.Visible = true;
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Submit")
        {

            try
            {
                if (txt1.Text == "")
                {
                    MessageBox("Please Insert First Name!");
                    txt1.Focus();
                    return;
                }
                if (txtStudentID.Text == "")
                {
                    MessageBox("Please Enter Card No.!");
                    txtStudentID.Focus();
                    return;
                }
                if (Convert.ToInt32(txt11.SelectedIndex) == 0)
                {
                    MessageBox("Please Select Gender");
                    txt11.Focus();
                    return;
                }
                if (StudentIDNumberExits())
                {
                    MessageBox("Student Id Number already exits");
                }
                else
                {
                    // ButN6.Enabled = false;
                    string GRNo = Convert.ToString(txtGRNo.Text);
                    string StandId = DropDownList2.SelectedItem.Value;
                    string DiviId = DropDownList3.SelectedItem.Value;
                    string rollno = Convert.ToString(TextBox1.Text);
                    string Fname = Convert.ToString(txt1.Text);
                    string Mname = Convert.ToString(txt2.Text);
                    string lname = Convert.ToString(txt3.Text);
                    string Fathername = Convert.ToString(txt4.Text);
                    string Mothername = Convert.ToString(txt5.Text);
                    string Emailid = Convert.ToString(txt6.Text);
                    string Dobnm = null;
                    if (!String.IsNullOrEmpty(txt7.Text))
                        Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");
                    string cast = Convert.ToString(txt9.SelectedValue);
                    string subcast = Convert.ToString(txt10.Text);
                    string gender = Convert.ToString(txt11.SelectedItem.Value);
                    string filnmn = null;

                    if (ViewState["Filename1"] != null)
                    {
                        filnmn = ViewState["Filename1"].ToString();
                    }


                    //if (txt13.Text != "")
                    //{
                    string fathno = Convert.ToString(txt13.Text);
                    //}
                    //if (txt14.Text != "")
                    //{
                    string mothno = Convert.ToString(txt14.Text);
                    //}

                    string Preadd = Convert.ToString(txt34.Text);
                    string paradd = Convert.ToString(txt35.Text);
                    string Bloodgp = Convert.ToString(txt44.Text);
                    string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
                    string Descip = Convert.ToString(txt45.Text);
                    string insertby = Convert.ToString(Session["User_id"]);
                    //long insertby = Convert.ToInt64(Session["User_id"]);
                    string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
                    string ipval = GetSystemIP();

                    string StuID_Number = Convert.ToString(txtStudentID.Text);
                    string BirthPlace = Convert.ToString(txtPlaceOfBirth.Text);
                    string BusAlert = Convert.ToString(txtSMSMobile.Text);
                    //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                    string dtAdm = null;
                    if (!String.IsNullOrEmpty(txtAdmissionDate.Text))

                        dtAdm = Convert.ToDateTime(txtAdmissionDate.Text).ToString("MM/dd/yyyy");
                    string Mothertongue = Convert.ToString(txtMothertounge.Text);
                    string Religion = Convert.ToString(txtReligion.Text);
                    string FirstLang = Convert.ToString(txtFirstLanguage.Text);
                    string SecondLang = Convert.ToString(txtSecondLanguage.Text);
                    string ThirdLang = Convert.ToString(txtThirdLanguage.Text);

                    string Studentaadhar = Convert.ToString(txtstdaadhar.Text);
                    string Fatheraadhar = Convert.ToString(txtfatheraadhar.Text);
                    string Motheraadhar = Convert.ToString(txtmotheraadhar.Text);

                    string FatherOccu = Convert.ToString(txtFatherOccupation.Text);
                    string MotherOccu = Convert.ToString(txtMotherOccupation.Text);
                    string FatherDesign = Convert.ToString(txtFatherDesignation.Text);
                    string MotherDesign = Convert.ToString(txtMotherDesignation.Text);
                    string FatherIncome = Convert.ToString(txtFatherIncome.Text);
                    string MotherIncome = Convert.ToString(txtMotherIncome.Text);
                    string UserName = Convert.ToString(txtUserName.Text);
                    string Password = Convert.ToString(txtPassword.Text);
                    string Nationality = Convert.ToString(txtNationality.Text);
                    string LandMark = Convert.ToString(txtLandmark.Text);
                    string Pincode = Convert.ToString(txtPincode.Text);
                   // getCountry();
                    string CountryID = DdlCountryName.SelectedItem.Value;
                    //getState();
                    string StateID = DdlStateName.SelectedItem.Value;
                    //getCity();
                    string CityID = DdlCityName.SelectedItem.Value;
                    string ReceiptNo = Convert.ToString(txtreceiptno.Text);
                    string GuardianNm = Convert.ToString(txtGuardianName.Text);
                    string GuardianNumber = Convert.ToString(txtGuardianNumber.Text);

                    string dtstartdate = "";
                    if (!String.IsNullOrEmpty(txtstartdate.Text))
                        dtstartdate = Convert.ToDateTime(txtstartdate.Text).ToString("MM/dd/yyyy");

                    string dtenddate = "";
                    if (!String.IsNullOrEmpty(txtenddate.Text))
                        dtenddate = Convert.ToDateTime(txtenddate.Text).ToString("MM/dd/yyyy");

                    string instrquery1 = "Execute dbo.usp_Profile @command='InsertStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                          "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                          "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                          "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                          "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +
                                          "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + serverpath + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "',@vchUser_name='" + UserName + "',@vchPassword='" + Password + "',@Receipt_no='" + ReceiptNo + "',@vchGuardianName='" + txtGuardianName.Text + "',@intGuardianNumber='" + txtGuardianNumber.Text + "',@dtstart_date='" + dtstartdate + "',@dtend_date='" + dtenddate + "'";



                    // int str = sExecuteQuery(instrquery1);

                    string str = sExecuteScalar(instrquery1);

                    // if (str != -1)
                    if (str != "" || str != null)
                    {
                        ViewState["StudentIDConcession"] = str;
                        string display = "Student Profile Submit!";
                        MessageBox(display);
                        btnSubmit.Text = "Submit";
                        //ButN6.Visible = false;
                        // Clear();
                        fGrid();

                    }
                    else
                    {
                        MessageBox("ooopppsss!Student Profile submission Failed");

                    }



                    TabPanel1.Visible = true;
                    TabPanel1.Enabled = true;


                }
            }

            catch (Exception Ex)
            {
            }
        }
        else
        {
            try
            {
                if (GetStudentIDNumber(Convert.ToInt32(ViewState["StudentID"])) != Convert.ToString(txtStudentID.Text))
                {
                    if (StudentIDNumberExits(Convert.ToInt32(ViewState["StudentID"])))
                        MessageBox("Student Id Number already exits");
                    else
                        updatestudent();
                }
                else
                {
                    string GRNo = Convert.ToString(txtGRNo.Text);
                    string StandId = DropDownList2.SelectedItem.Value;
                    string DiviId = DropDownList3.SelectedItem.Value;
                    string rollno = Convert.ToString(TextBox1.Text);
                    string Fname = Convert.ToString(txt1.Text);
                    string Mname = Convert.ToString(txt2.Text);
                    string lname = Convert.ToString(txt3.Text);
                    string Fathername = Convert.ToString(txt4.Text);
                    string Mothername = Convert.ToString(txt5.Text);
                    string Emailid = Convert.ToString(txt6.Text);
                    string Dobnm = null;
                    if (!String.IsNullOrEmpty(txt7.Text))

                        Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

                    string cast = Convert.ToString(txt9.SelectedValue);
                    string subcast = Convert.ToString(txt10.Text);
                    string gender = Convert.ToString(txt11.SelectedItem.Value);
                    string filnmn = null;
                    if (ViewState["Filename1"] != null)
                    {
                        filnmn = ViewState["Filename1"].ToString();
                    }

                    //if (txt14.Text != "")
                    //{
                    string mothno = Convert.ToString(txt14.Text);
                    //}
                    //if (txt13.Text != "")
                    //{
                    string fathno = Convert.ToString(txt13.Text);
                    //}



                    string Preadd = Convert.ToString(txt34.Text);
                    string paradd = Convert.ToString(txt35.Text);

                    string Bloodgp = Convert.ToString(txt44.Text);
                    string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
                    string Descip = Convert.ToString(txt45.Text);
                    string Updateby = Convert.ToString(Session["User_id"]);

                    string vchUpdated_IP = GetSystemIP();
                    string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                    string Studentaadhar = Convert.ToString(txtstdaadhar.Text);
                    string Fatheraadhar = Convert.ToString(txtfatheraadhar.Text);
                    string Motheraadhar = Convert.ToString(txtmotheraadhar.Text);
                    string StuID_Number = Convert.ToString(txtStudentID.Text);
                    string BirthPlace = Convert.ToString(txtPlaceOfBirth.Text);
                    string BusAlert = Convert.ToString(txtSMSMobile.Text);
                    //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                    string dtAdm = null;
                    if (!String.IsNullOrEmpty(txtAdmissionDate.Text))

                        dtAdm = Convert.ToDateTime(txtAdmissionDate.Text).ToString("MM/dd/yyyy");
                    string Mothertongue = Convert.ToString(txtMothertounge.Text);
                    string Religion = Convert.ToString(txtReligion.Text);
                    string FirstLang = Convert.ToString(txtFirstLanguage.Text);
                    string SecondLang = Convert.ToString(txtSecondLanguage.Text);
                    string ThirdLang = Convert.ToString(txtThirdLanguage.Text);
                    string FatherOccu = Convert.ToString(txtFatherOccupation.Text);
                    string MotherOccu = Convert.ToString(txtMotherOccupation.Text);
                    string FatherDesign = Convert.ToString(txtFatherDesignation.Text);
                    string MotherDesign = Convert.ToString(txtMotherDesignation.Text);
                    string FatherIncome = Convert.ToString(txtFatherIncome.Text);
                    string MotherIncome = Convert.ToString(txtMotherIncome.Text);
                    string Nationality = Convert.ToString(txtNationality.Text);
                    string LandMark = Convert.ToString(txtLandmark.Text);
                    string usrrname = Convert.ToString(txtUserName.Text);
                    string passsword = Convert.ToString(txtPassword.Text);
                    string Pincode = Convert.ToString(txtPincode.Text);
                    //getCountry();
                    string CountryID = DdlCountryName.SelectedItem.Value;
                    //getState();
                    string StateID = DdlStateName.SelectedItem.Value;
                    //getCity();
                    string CityID = DdlCityName.SelectedItem.Value;
                    string ReceiptNo = Convert.ToString(txtreceiptno.Text);
                    string GuardianNm = Convert.ToString(txtGuardianName.Text);
                    string GuardianNumber = Convert.ToString(txtGuardianNumber.Text);

                    string dtstartdate = "";
                    if (!String.IsNullOrEmpty(txtstartdate.Text))
                        dtstartdate = Convert.ToDateTime(txtstartdate.Text).ToString("MM/dd/yyyy");

                    string dtenddate = "";
                    if (!String.IsNullOrEmpty(txtenddate.Text))
                        dtenddate = Convert.ToDateTime(txtenddate.Text).ToString("MM/dd/yyyy");


                    string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                          "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                          "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                          "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                          "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +
                                          "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + serverpath + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + Updateby + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + Session["intStudent_id"] + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "',@vchUser_name='" + usrrname.Trim() + "',@vchPassword='" + Session["txtpassword"] + "',@Receipt_no='" + ReceiptNo + "',@vchGuardianName='" + txtGuardianName.Text + "',@intGuardianNumber='" + GuardianNumber + "',@dtstart_date='" + dtstartdate + "',@dtend_date='" + dtenddate + "'";

                    int str = sExecuteQuery(instrquery1);

                    if (str != -1)
                    {
                        fGrid();
                        btnSubmit.Text = "Submit";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Student Profile Updated!');window.location ='frmAdmListStudentDetails.aspx';", true);
                        //string display = "Student Profile Updated!";
                        //MessageBox(display);
                        // Button1.Enabled = false;
                        // Clear();

                    }
                    else
                    {
                        MessageBox("ooopppsss!Student Profile updation Failed");

                    }
                }
            }
            catch
            {


            }
        }
    }
    private void updatestudent()
    {
        try
        {
             string GRNo = Convert.ToString(txtGRNo.Text);
                    string StandId = DropDownList2.SelectedItem.Value;
                    string DiviId = DropDownList3.SelectedItem.Value;
                    string rollno = Convert.ToString(TextBox1.Text);
                    string Fname = Convert.ToString(txt1.Text);
                    string Mname = Convert.ToString(txt2.Text);
                    string lname = Convert.ToString(txt3.Text);
                    string Fathername = Convert.ToString(txt4.Text);
                    string Mothername = Convert.ToString(txt5.Text);
                    string Emailid = Convert.ToString(txt6.Text);
                    string Dobnm = null;
                    if (!String.IsNullOrEmpty(txt7.Text))

                        Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

                    string cast = Convert.ToString(txt9.SelectedValue);
                    string subcast = Convert.ToString(txt10.Text);
                    string gender = Convert.ToString(txt11.SelectedItem.Value);
                    string filnmn = null;
                    if (ViewState["Filename1"] != null)
                    {
                        filnmn = ViewState["Filename1"].ToString();
                    }

                    //if (txt14.Text != "")
                    //{
                    string mothno = Convert.ToString(txt14.Text);
                    //}
                    //if (txt13.Text != "")
                    //{
                    string fathno = Convert.ToString(txt13.Text);
                    //}



                    string Preadd = Convert.ToString(txt34.Text);
                    string paradd = Convert.ToString(txt35.Text);

                    string Bloodgp = Convert.ToString(txt44.Text);
                    string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
                    string Descip = Convert.ToString(txt45.Text);
                    string Updateby = Convert.ToString(Session["User_id"]);

                    string vchUpdated_IP = GetSystemIP();
                    string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                    string Studentaadhar = Convert.ToString(txtstdaadhar.Text);
                    string Fatheraadhar = Convert.ToString(txtfatheraadhar.Text);
                    string Motheraadhar = Convert.ToString(txtmotheraadhar.Text);
                    string StuID_Number = Convert.ToString(txtStudentID.Text);
                    string BirthPlace = Convert.ToString(txtPlaceOfBirth.Text);
                    string BusAlert = Convert.ToString(txtSMSMobile.Text);
                    //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                    string dtAdm = null;
                    if (!String.IsNullOrEmpty(txtAdmissionDate.Text))

                        dtAdm = Convert.ToDateTime(txtAdmissionDate.Text).ToString("MM/dd/yyyy");
                    string Mothertongue = Convert.ToString(txtMothertounge.Text);
                    string Religion = Convert.ToString(txtReligion.Text);
                    string FirstLang = Convert.ToString(txtFirstLanguage.Text);
                    string SecondLang = Convert.ToString(txtSecondLanguage.Text);
                    string ThirdLang = Convert.ToString(txtThirdLanguage.Text);
                    string FatherOccu = Convert.ToString(txtFatherOccupation.Text);
                    string MotherOccu = Convert.ToString(txtMotherOccupation.Text);
                    string FatherDesign = Convert.ToString(txtFatherDesignation.Text);
                    string MotherDesign = Convert.ToString(txtMotherDesignation.Text);
                    string FatherIncome = Convert.ToString(txtFatherIncome.Text);
                    string MotherIncome = Convert.ToString(txtMotherIncome.Text);
                    string Nationality = Convert.ToString(txtNationality.Text);
                    string LandMark = Convert.ToString(txtLandmark.Text);
                    string usrrname = Convert.ToString(txtUserName.Text);
                    string passsword = Convert.ToString(txtPassword.Text);
                    string Pincode = Convert.ToString(txtPincode.Text);
                    getCountry();
                    string CountryID = DdlCountryName.SelectedItem.Value;
                    getState();
                    string StateID = DdlStateName.SelectedItem.Value;
                    getCity();
                    string CityID = DdlCityName.SelectedItem.Value;
                    string ReceiptNo = Convert.ToString(txtreceiptno.Text);
                    string GuardianNm = Convert.ToString(txtGuardianName.Text);
                    string GuardianNumber = Convert.ToString(txtGuardianNumber.Text);

                    string dtstartdate = "";
                    if (!String.IsNullOrEmpty(txtstartdate.Text))
                        dtstartdate = Convert.ToDateTime(txtstartdate.Text).ToString("MM/dd/yyyy");

                    string dtenddate = "";
                    if (!String.IsNullOrEmpty(txtenddate.Text))
                        dtenddate = Convert.ToDateTime(txtenddate.Text).ToString("MM/dd/yyyy");


                    string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                          "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                          "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                          "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                          "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +
                                          "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + serverpath + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + Updateby + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + Session["intStudent_id"] + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "',@vchUser_name='" + usrrname.Trim() + "',@vchPassword='" + Session["txtpassword"] + "',@Receipt_no='" + ReceiptNo + "',@vchGuardianName='" + txtGuardianName.Text + "',@intGuardianNumber='" + GuardianNumber + "',@dtstart_date='" + dtstartdate + "',@dtend_date='" + dtenddate + "'";

                    int str = sExecuteQuery(instrquery1);

                    if (str != -1)
                    {
                        fGrid();
                        btnSubmit.Text = "Submit";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Student Profile Updated!');window.location ='frmAdmListStudentDetails.aspx';", true);
                        //string display = "Student Profile Updated!";
                        //MessageBox(display);
                        // Button1.Enabled = false;
                        // Clear();

                    }
                    else
                    {
                        MessageBox("ooopppsss!Student Profile updation Failed");

                    }
        }
        catch (Exception ex)
        {
        }
    }
    public void Clear()
    {
        TextBox[] textBoxArray = new TextBox[51];
        int i;
        for (i = 0; i < 52; i++)
        {

            textBoxArray[i].Text = "";

        }
    }
    public void getDivision()
    {
        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownList(DropDownList3, query2, "vchDivisionName", "intDivision_id");

        }
        catch
        {

        }
    }
    public void getCast()
    {
        try
        {
            int cast = Convert.ToInt32(txt9.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='getCast'";
            bool st2 = sBindDropDownList(txt9, query2, "vchCategory", "vchCast");
        }
        catch
        {

        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDivision();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int statv1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);
        }
        catch
        {

        }
    }
    protected void checkroll(object sender, EventArgs e)
    {

        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Divi = Convert.ToInt32(DropDownList3.SelectedItem.Value);

            string query3 = "Execute dbo.usp_Profile @command='checkExiRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "',@intDivision_id='" + Divi + "',@introllno='" + TextBox1.Text + "'  ";
            string qucount = sExecuteScalar(query3);
            if (qucount == "1")
            {
                Label4.Text = "Student Record Already Exist";
                TextBox1.Text = string.Empty;
            }
            else
            {
                Label4.Text = "";
            }
        }
        catch
        {


        }
    }
    protected void Update1(object sender, EventArgs e)
    {
        try
        {
            string GRNo = Convert.ToString(txtGRNo.Text);
            string StandId = DropDownList2.SelectedItem.Value;
            string DiviId = DropDownList3.SelectedItem.Value;
            string rollno = Convert.ToString(TextBox1.Text);
            string Fname = Convert.ToString(txt1.Text);
            string Mname = Convert.ToString(txt2.Text);
            string lname = Convert.ToString(txt3.Text);
            string Fathername = Convert.ToString(txt4.Text);
            string Mothername = Convert.ToString(txt5.Text);
            string Emailid = Convert.ToString(txt6.Text);
            string Dobnm = null;
            if (!String.IsNullOrEmpty(txt7.Text))

                Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

            
            string cast = Convert.ToString(txt9.SelectedValue);
            string subcast = Convert.ToString(txt10.Text);
            string gender = Convert.ToString(txt11.SelectedItem.Value);
            string filnmn = null;
            if (ViewState["Filename"] != null)
            {
                filnmn = ViewState["Filename"].ToString();
            }
            
            //if (txt14.Text != "")
            //{
            string mothno = Convert.ToString(txt14.Text);
            //}
            //if (txt13.Text != "")
            //{
            string fathno = Convert.ToString(txt13.Text);
            //}
          
            string Preadd = Convert.ToString(txt34.Text);
            string paradd = Convert.ToString(txt35.Text);
           
            string Bloodgp = Convert.ToString(txt44.Text);
            string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
            string Descip = Convert.ToString(txt45.Text);
            string Updateby = Convert.ToString(Session["User_id"]);
            //long intUpdate_id = Convert.ToInt64(Session["User_id"]);
            string vchUpdated_IP = GetSystemIP();
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                  "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchUser_name='" + Fname + "',@vchPassword='" + Fname + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                   "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + serverpath + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + Updateby + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + idv1.Text + "'";

            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Student Profile Updated!";
                MessageBox(display);
                // Button1.Enabled = false;
                //Clear();
            }
            else
            {
                MessageBox("ooopppsss!Student Profile updation Failed");

            }
        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            //String savePath = "C:/inetpub/wwwroot/Rajasthan/TraffordSchool/TraffordSchool/image/";
           // String savePath = "E:/Application UAT live/wwwroot/Mumbai/vclassrooms Demo/Demo API/SKSchoolApi/SKSchoolApi/image/";
            String savePath = "D:/Application Live/Mumbai/Android Demo/SKSchoolApi/SKSchoolApi/image/";

            if (FileUpload1.HasFile)
            {
                int fileSize = FileUpload1.PostedFile.ContentLength;
                if (fileSize > 50000)
                {
                    MessageBox ( "File exceed 50kb");
                }
                else
                {

                    //FileUpload1.SaveAs("C:/inetpub/wwwroot/Rajasthan/TraffordSchool/TraffordSchool/image/" + FileUpload1.FileName);
                    FileUpload1.SaveAs("D:/Application Live/Mumbai/Android Demo/SKSchoolApi/SKSchoolApi/image/" + FileUpload1.FileName);
                    string file = FileUpload1.PostedFile.FileName;

                    //imgViewFile.ImageUrl = "http://eserveshiksha.co.in/TraffordSchoolApi/image/" + file;
                    //http://122.170.4.112:81/api/
                    imgViewFile.ImageUrl = "http://VClassrooms.com/vclassroomsSchoolDemoAPI/image/" + file;
                    Button1.Text = "Change Image";

                    //Button8.Visible = true;

                    ViewState["Filename1"] = file;

                }
            }

        }
        catch
        {

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "No")
        {
            txt45.Enabled = false;
        }
        else
        {
            txt45.Enabled = true;
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intStudent_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            ViewState["StudentID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            ViewState["StudentIDConcession"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
           string strQry = "";
           strQry = "exec usp_Profile @command='editStudent',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@intschool_id='" + Session["school_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                string file = Convert.ToString(dsObj.Tables[0].Rows[0]["vchprofile"]);
                imgViewFile.ImageUrl = "http://VClassrooms.com/vclassroomsSchoolDemoAPI/image/" + file;
                txtGRNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intGRNo"]);
                DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                getDivision();
                DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                txt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                txt2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                txt3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                txt5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                txt6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                txt7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                getCast();
                txt9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                txt10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                txt11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                txt13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                txt14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo2"]);
                txt34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                txt35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpermanentAddress"]);
                txt44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                try
                {
                    DropDownList1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                    if (DropDownList1.Text == "2")
                    {
                        txt45.ReadOnly = true ;
                        
                    }
                }
                catch
                {
                }
                txt45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);

                txtStudentID.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
                txtPlaceOfBirth.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchplaceofBirth"]);
                txtSMSMobile.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
                txtAdmissionDate.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["dtAdmission"]);
                txtMothertounge.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMothertongue"]);
                txtReligion.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchReligion"]);
                txtFirstLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirstLanguage"]);
                txtSecondLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchSecondLanguage"]);
                txtThirdLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchThirdLanguage"]);

                txtstdaadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchaadhar_no"]);
                txtfatheraadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson1"]);
                txtmotheraadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat1"]);

                txtFatherOccupation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);
                txtMotherOccupation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);
                txtFatherDesignation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherDesignation"]);
                txtMotherDesignation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherDesignation"]);
                txtFatherIncome.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherIncome"]);
                txtMotherIncome.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherIncome"]);
                txtNationality.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationality"]);
                txtUserName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchUser_name"]);
                txtPassword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPassword"]);
                Session["txtpassword"] = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPassword"]);
                txtreceiptno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Receipt_no"]);
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtLandmark.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchLandMark"]);
                txtPincode.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchPincode"]);
                DdlCountryName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);
                getState();
                DdlStateName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
                getCity();
                DdlCityName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCity_id"]);

                txtstartdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtstart_date"]);
                txtenddate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtend_date"]);


                String savePath = Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);

                imgViewFile.ImageUrl = savePath + Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);

                //fillConcessionGrid();
                //fillTransportGrid();
                //GridView1.Visible = true;
                //GridView2.Visible = true;

                TabContainer1.ActiveTabIndex = 1;
				btnSubmit.Visible = true;
                btnSubmit.Text = "Update";
                string script = "funcswitchtab()";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
        catch
        {

        }
    }
   
    protected void btnClear_Click(object sender, EventArgs e)
    {
        fGrid();
        btnSubmit.Text = "Submit";
    }
    protected void ddlStandrd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQry = "usp_Profile @command='selectStudents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "' ";
        bool st2 = sBindDropDownList(ddlDivision, que2, "vchDivisionName", "intDivision_id");
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQry = "usp_Profile @command='selectStudentsDivWise',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(ddlDivision.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void DdlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getState();
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCity();
    }
    //protected void grvDetail_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //          TextBox thisTextBox = (TextBox)sender;
    //        GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
    //        int rowindex = 0;
    //        rowindex = currentRow.RowIndex;

    //// following line will get the label value in current row

    //        Label time = (Label)currentRow.FindControl("lblstudentsid");  
      
         
    //        //string strQry1 = "";
    //        //strQry1 = "exec [usp_Profile] @command='deleteStudent',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
    //        //if (sExecuteQuery(strQry1) != -1)
    //        //{
    //        //    fGrid();
    //        //    MessageBox("Record Deleted Successfully!");
    //        //}
    //    }
    //    catch
    //    {

    //    }
    //}



    protected void text_changed(object sender, EventArgs e)
    {



        try
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            // following line will get the label value in current row
            TextBox timeid = (TextBox)currentRow.FindControl("txtName");
            Label time = (Label)currentRow.FindControl("lblstudentsid");


            string strQry1 = "";
            strQry1 = "exec [usp_Profile] @command='StudentRollNoUpdate',@intStudent_id='" + Convert.ToString(time.Text) + "',@intRollNo='" + Convert.ToString(timeid.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                //fGrid();
                //MessageBox("Record Updated Successfully!");
            }
        }
        catch
        {
        }

      
    }
    protected void checkReceiptNo(object sender, EventArgs e)
    {

        try
        {
            string query3 = "Execute dbo.usp_Profile @command='checkExiReceiptNo',@intSchool_id='" + Session["School_id"] + "',@receipt_no='" + txtreceiptno.Text + "',@intAcademic_id='" + Session["AcademicID"] + "'  ";
            string qucount = sExecuteScalar(query3);
            if (Convert.ToInt32(qucount) >= 1)
            {
                Label40.Text = "Receipt Number Already Exist";
                txtreceiptno.Text = string.Empty;
                Label40.Visible = true;
            }
            else
            {
                Label40.Text = "";
            }
        }
        catch
        {


        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string strQry = "usp_Profile @command='Searchstudent_id',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@intStudentID_Number='" + TextBox2.Text + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            string strQry1 = "usp_Profile @command='SearchStudentnm',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@Searchbyvalue='" + TextBox2.Text + "'";
            dsObj1 = sGetDataset(strQry1);
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj1;
                grvDetail.DataBind();
            }
        }
        catch
        {
            string strQry = "usp_Profile @command='SearchStudentnm',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@Searchbyvalue='" + TextBox2.Text + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }

        }
    }

    //protected void ddlexamstdsub_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlexamstdsub.SelectedValue == "1")
    //    {
    //        Transport.Visible = false;
    //        Concession.Visible = true;
    //        fillConcessionGrid();
    //    }
    //    else if (ddlexamstdsub.SelectedValue == "2")
    //    {
    //        Concession.Visible = false;
    //        Transport.Visible = true;
    //        fillTransportGrid();
    //    }
    //}

    //protected void btnSaveConcession_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string concessionId = drpconcession.SelectedValue;
    //        string dtStartDate = Convert.ToDateTime(TextBox3.Text).ToString("MM/dd/yyyy");
    //        string dtEndDate = Convert.ToDateTime(TextBox4.Text).ToString("MM/dd/yyyy");
    //        string studentID = Convert.ToString(ViewState["StudentIDConcession"]);
    //        if (studentID != "")
    //        {
    //            if (btnSaveConcession.Text == "Save")
    //            {
    //                string query = "usp_ConcessionTransportDetails @command='CheckConcessionExits',@intStudent_id='" + studentID + "',@Date='" + dtStartDate + "'";
    //                dsObj = sGetDataset(query);
    //                if (dsObj.Tables[0].Rows.Count > 0)
    //                {
    //                    MessageBox("Record already exits between this date....");
    //                }
    //                else
    //                {
    //                    string strQry = "usp_ConcessionTransportDetails @command='insertConcession',@intStudent_id='" + studentID + "',@intconcession_id='" + concessionId + "',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'" +
    //                        ",@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Session["School_id"] + "'";


    //                    int str = sExecuteQuery(strQry);

    //                    if (str > 0)
    //                    {
    //                        fillConcessionGrid();
    //                        MessageBox("Concession Added Successfully...");
    //                    }

    //                }
    //            }
    //            else
    //            {
    //                //string query = "usp_ConcessionTransportDetails @command='CheckConcessionExitsorNot',@intStudent_id='" + studentID + "',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'";
    //                //dsObj = sGetDataset(query);
    //                //if (dsObj.Tables[0].Rows.Count > 0)
    //                //{
    //                //    MessageBox("Record already exits between this date....");
    //                //}
    //                {
    //                    string strQry = "usp_ConcessionTransportDetails @command='UpdateTransport',@int_ID='" + ViewState["int_ID"] + "',@intFeetype_id='0',@intFee_id='0',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'" +
    //                            ",@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Session["School_id"] + "'";


    //                    int str = sExecuteQuery(strQry);

    //                    if (str > 0)
    //                    {
    //                        MessageBox("Concession Updated Successfully...");
    //                        btntransport.Text = "Save";
    //                        fillConcessionGrid();
    //                    }

    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox("Please Select Student....");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void btntransport_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string transportid = drptransport.SelectedValue;
    //        string dtStartDate = Convert.ToDateTime(TextBox5.Text).ToString("MM/dd/yyyy");
    //        string dtEndDate = Convert.ToDateTime(TextBox6.Text).ToString("MM/dd/yyyy");
    //        string studentID = Convert.ToString(ViewState["StudentIDConcession"]);
    //        if (studentID != "")
    //        {
    //            if (btntransport.Text == "Save")
    //            {
    //                string query = "usp_ConcessionTransportDetails @command='CheckTransportExits',@intStudent_id='" + studentID + "',@Date='" + dtStartDate + "',@intRoute_id='" + transportid + "'";
    //                dsObj = sGetDataset(query);
    //                if (dsObj.Tables[0].Rows.Count > 0)
    //                {
    //                    MessageBox("Record already exits between this date....");
    //                }
    //                else
    //                {
    //                    string strQry = "usp_ConcessionTransportDetails @command='InsertTransport',@intStudent_id='" + studentID + "',@intFeetype_id='0',@intFee_id='0',@intRoute_id='" + transportid + "',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'" +
    //                        ",@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Session["School_id"] + "'";


    //                    int str = sExecuteQuery(strQry);

    //                    if (str > 0)
    //                    {
    //                        fillTransportGrid();
    //                        MessageBox("Transport Area Added Successfully...");
    //                    }

    //                }
    //            }
    //            else
    //            {
    //                //string query = "usp_ConcessionTransportDetails @command='CheckTransportRecordExitsOrNot',@intStudent_id='" + studentID + "',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'";
    //                //dsObj = sGetDataset(query);
    //                //if (dsObj.Tables[0].Rows.Count > 0)
    //                //{
    //                //    MessageBox("Record already exits between this date....");
    //                //}
    //                {
    //                    string strQry = "usp_ConcessionTransportDetails @command='UpdateTransport',@int_ID='" + ViewState["int_ID"] + "',@intFeetype_id='0',@intFee_id='0',@intRoute_id='" + transportid + "',@dtfrom_date='" + dtStartDate + "',@dtto_date='" + dtEndDate + "'" +
    //                            ",@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSchool_id='" + Session["School_id"] + "'";


    //                    int str = sExecuteQuery(strQry);

    //                    if (str > 0)
    //                    {
    //                        MessageBox("Transport Area Updated Successfully...");
    //                        btntransport.Text = "Save";
    //                        fillTransportGrid();
    //                    }

    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox("Please Select Student....");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    //protected void fillConcessionGrid()
    //{
    //    string strQry = "usp_ConcessionTransportDetails @command='selectconcessiondetails',@intStudent_id='" + Convert.ToString(ViewState["StudentIDConcession"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
    //    dsObj = sGetDataset(strQry);
    //    if (dsObj.Tables[0].Rows.Count > 0)
    //    {
    //        GridView1.DataSource = dsObj;
    //        GridView1.DataBind();
    //    }
    //}

    //protected void fillTransportGrid()
    //{
    //    string strQry = "usp_ConcessionTransportDetails @command='selectTransportdetails',@intStudent_id='" + Convert.ToString(ViewState["StudentIDConcession"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
    //    dsObj = sGetDataset(strQry);
    //    if (dsObj.Tables[0].Rows.Count > 0)
    //    {
    //        GridView2.DataSource = dsObj;
    //        GridView2.DataBind();
    //    }
    //}


    ////protected void btnConcessionAdd_Click(object sender, EventArgs e)
    ////{
    ////    try
    ////    {
    ////        ID +=1;
    ////        CreatedDataTable();

    ////        int DrpConcession=Convert.ToInt32(drpconcession.SelectedValue);
    ////        string concessionName = Convert.ToString(drpconcession.SelectedItem);
    ////        //DateTime FromDt=Convert.ToDateTime(txtconcessionstartdt.Text);
    ////        //DateTime toDate= Convert.ToDateTime(txtConcessionToDate.Text);

    ////        bool Record = AddRecord(ID, DrpConcession, concessionName, FromDt, toDate);
    ////        if (Record == true)
    ////        {
    ////            _bindData();
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////    }
           
    ////}

    ////protected bool CreatedDataTable()
    ////{
    ////    bool result = false;
    ////    try
    ////    {
    ////        bool CheckResult=false;
    ////        CheckResult = ContainColumn("ConcessionType", dtConcession);
    ////        if (CheckResult == false)
    ////        {
    ////            dtConcession.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"), new DataColumn("ConcessionType"),
    ////       new DataColumn("ConcessionName"), new DataColumn("dtStartDate"),new DataColumn("dtToDate") });
    ////            result = true;
    ////        }
    ////        return result;
    ////    }
    ////    catch (Exception)
    ////    {
    ////        return result;
    ////    }
    ////}

    ////private bool ContainColumn(string columnName, DataTable table)
    ////{
    ////    bool ColumnExit = false;
    ////    DataColumnCollection columns = table.Columns;        
    ////    if (columns.Contains(columnName))
    ////    {
    ////        ColumnExit = true;
    ////    }

    ////    return ColumnExit;
    ////}

    ////protected bool AddRecord(int id, int ConcessionType, string ConcessionName, DateTime dtStartDate, DateTime dtToDate)
    ////{
    ////    bool isRecordAdded = false;
    ////    try
    ////    {
    ////        dtConcession.Rows.Add(id, ConcessionType,ConcessionName, dtStartDate, dtToDate);
    ////        isRecordAdded = true;
    ////        ViewState["dtConcession"] = dtConcession;
    ////         return isRecordAdded;
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        return isRecordAdded;
    ////    }
    ////}
    ////protected void _bindData()
    ////{
    ////    try
    ////    {
    ////        GridView1.DataSource = ViewState["dtConcession"] as DataTable;
    ////        GridView1.DataBind();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////    }
    ////}


    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        ViewState["int_ID"] = Convert.ToString(GridView2.DataKeys[e.RowIndex].Value);
    //        string strQry1 = "";
    //        strQry1 = "exec usp_ConcessionTransportDetails @command='DeleteTransport',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@int_ID='" + Convert.ToString(ViewState["int_ID"]) + "',@intDeletedBy='" + Session["User_id"] + "',@deletedIP='" + GetSystemIP() + "'";
    //        if (sExecuteQuery(strQry1) != -1)
    //        {
    //            MessageBox("Record Deleted Successfully!");
    //            fillTransportGrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {
    //        ViewState["int_ID"] = Convert.ToString(GridView2.DataKeys[e.NewEditIndex].Value);
    //        string strQry = "";
    //        strQry = "exec usp_ConcessionTransportDetails @command='EditTransport',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@int_ID='" + Convert.ToString(ViewState["int_ID"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            drptransport.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intArea_Id"]);
    //            drptransport.Enabled = false;
    //            TextBox5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtfrom_date"]);
    //            TextBox6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtto_date"]);
    //            btntransport.Text = "Update";
    //            fillTransportGrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        ViewState["int_ID"] = Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
    //        string strQry1 = "";
    //        strQry1 = "exec usp_ConcessionTransportDetails @command='DeleteTransport',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@int_ID='" + Convert.ToString(ViewState["int_ID"]) + "',@intDeletedBy='" + Session["User_id"] + "',@deletedIP='" + GetSystemIP() + "'";
    //        if (sExecuteQuery(strQry1) != -1)
    //        {
    //            MessageBox("Record Deleted Successfully!");
    //            fillConcessionGrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {

    //        ViewState["int_ID"] = Convert.ToString(GridView1.DataKeys[e.NewEditIndex].Value);
    //        string strQry = "";
    //        strQry = "exec usp_ConcessionTransportDetails @command='EditConcession',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@int_ID='" + Convert.ToString(ViewState["int_ID"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            drpconcession.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intConcession_id"]);
    //            drpconcession.Enabled = false;
    //            TextBox3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtfrom_date"]);
    //            TextBox4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtto_date"]);
    //            btnSaveConcession.Text = "Update";
    //            fillConcessionGrid();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    protected bool StudentIDNumberExits(int intStudentID=0)
    {
        bool Result = true;
        try
        {
            string StudentIDNumber = txtStudentID.Text;
            string strQry = "Execute dbo.usp_Profile @command='CheckStudentIDNumber',@intSchool_id='" + Session["School_id"] + "',@intStudentID_Number='" + StudentIDNumber.Trim() + "'";
            DataSet ds = new DataSet();
            ds= sGetDataset(strQry);
            //int NoOfRecords = 0;
            //NoOfRecords = sExecuteQuery(strQry);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        catch (Exception ex)
        {
            return true;
        }
    }

    private string GetStudentIDNumber(int StudentId)
    {
        string StudentIDNumber = txtStudentID.Text;
        string strQry = "Execute dbo.usp_Profile @command='GetStudentIDNumber',@intSchool_id='" + Session["School_id"] + "',@intStudentID_Number='" + StudentIDNumber.Trim() + "',@intStudent_id='" + StudentId + "'";
        string studentIdnumber = sExecuteScalar(strQry);
        return studentIdnumber;
    }

    protected void txtStudentID_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["StudentID"]) != "")
        {
            if (StudentIDNumberExits(Convert.ToInt32(ViewState["StudentID"])))
                MessageBox("Student Id Number already exits");
        }
        else
        {
            if (StudentIDNumberExits(Convert.ToInt32(ViewState["StudentID"])))
            MessageBox("Student Id Number already exits");
        }
    }
}