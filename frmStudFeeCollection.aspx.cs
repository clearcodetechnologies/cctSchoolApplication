using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Net;
using System.Text;
using System.IO;

public partial class frmStudFeeCollection : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    string strQry = "";
    DataSet dsObj;
    DataSet dsObj1;
    List<CheckBox> lstChckBox;
    List<CheckBox> lstChckBox_Months;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                //LoadMonthsPanel();
            if (!IsPostBack)
            {
                
                FillSTD();
                FillArea();
                Clear();
                lblEnterAmt.Visible = false;
                txtEnterAmt.Visible = false;
                lblYearlyamt.Visible = false;
                txtYearlyAmt.Visible = false;
                lblOneTimeAmt.Visible = false;
                txtOneTimeAmt.Visible = false;
                lblRemark.Visible = false;
                txtRemark.Visible = false;

                if (Session["sesStudent"] != null)
                {
                    ddlSTD.SelectedValue = Convert.ToString(Session["sesStandard"]);
                    ddlGender.SelectedValue = Convert.ToString(Session["sesGender"]);
                    fillStudent();
                    ddlStudentName.SelectedValue = Convert.ToString(Session["sesStudent"]);
                    ddlStudentName_SelectedIndexChanged(null, null);
                }
                else
                {
                    Session["sesStandard"] = "";
                    Session["sesGender"] = "";
                    Session["sesStudent"] = "";
                }

            }
            else
            {
               
            }

            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);

        }
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
    
    void chck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox checkBox = (sender as CheckBox);
            foreach (CheckBox item in lstChckBox)
            {
                if (item.Text == checkBox.Text)
                {
                    if (item.Text == "Monthly")
                    {
                        MonthlyCheck(item);
                    }
                    else if (item.Text == "Admission")
                    {
                        AdmissionFeeCheck(item);
                    }
                    else if (item.Text == "Session")
                    {
                        SessionFeeCheck(item);
                    }
                    else if (item.Text == "Other")
                    {
                        OtherCheck(item);
                    }
                }
            }
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }

    private void OtherCheck(CheckBox chkOther)
    {

    }

    private void SessionFeeCheck(CheckBox chkSession)
    {
        if (chkSession.Checked == true)
        {
            lblInstallment.Visible = true;
            ddlInstallment.Visible = true;

            fillAnnualy();
        }
        else
        {
            lblInstallment.Visible = false;
            ddlInstallment.Visible = false;
        }
    }

    private void AdmissionFeeCheck(CheckBox chkAdmission)
    {
        if (chkAdmission.Checked == true)//one time
        {
            lblOtherAmt.Visible = false;
            txtOtherAmt.Visible = false;
            lblRemark.Visible = false;
            txtRemark.Visible = false;
            txtYearlyAmt.Text = "";
            txtEnterAmt.Text = "";
            txtTotalAmt.Text = "";
            fillHeadOneTime();
            lblOneTime.Visible = false;
            ddlOneTime.Visible = false;

            lblOneTimeAmt.Visible = false;
            txtOneTimeAmt.Visible = false;

            lblInstallment.Visible = true;
            ddlInstallment.Visible = true;
            ddlInstallment.ClearSelection();
            txtPartAmount.Text = "";

            txtLateFee.Text = "";
            drpToMonth.Visible = false;
            lblToMonth.Visible = false;
            lblMonths.Visible = false;
            ddlMonths.Visible = false;
            txtAfterDiscount.Text = "";
            txtAfterDiscount.Text = "";
            fillOneTime();
        }
        else
        {
            gvOneTime.DataSource = null;
            gvOneTime.DataBind();
            lblOneTime.Visible = false;
            ddlOneTime.Visible = false;

            lblOneTimeAmt.Visible = false;
            txtOneTimeAmt.Visible = false;

            txtOneTimeAmt.Text = "";
            if (txtEnterAmt.Text == "")
            {
                txtEnterAmt.Text = "0";
            }
            if (txtYearlyAmt.Text == "")
            {
                txtYearlyAmt.Text = "0";
            }
            if (txtOneTimeAmt.Text == "")
            {
                txtOneTimeAmt.Text = "0";
            }
            if (txtOtherAmt.Text == "")
            {
                txtOtherAmt.Text = "0";
            }
            decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
            txtTotalAmt.Text = (Atual).ToString();
        }
    }

    private void MonthlyCheck(CheckBox chkMonthly)
    {
        if (chkMonthly.Checked == true)
        {
            fillHeadMonthly();
            lblMonths.Visible = true;
            ddlMonths.Visible = false;
            lblInstallment.Visible = false;
            ddlInstallment.Visible = false;
            lblPartAmt.Visible = false;
            txtPartAmount.Visible = false;
            lblEnterAmt.Visible = false;
            txtEnterAmt.Visible = false;
            txtAfterDiscount.Text = "";
            txtLateFee.Text = "";
            fillMonths();
            drpToMonth.Visible = false;
            lblToMonth.Visible = false;
            monthsPanel.Visible = true;
        }
        else
        {
            gvHead.DataSource = null;
            gvHead.DataBind();
            lblMonths.Visible = false;
            ddlMonths.Visible = false;
            lblEnterAmt.Visible = false;
            txtEnterAmt.Visible = false;
            txtEnterAmt.Text = "";

            if (txtEnterAmt.Text == "")
            {
                txtEnterAmt.Text = "0";
            }
            if (txtYearlyAmt.Text == "")
            {
                txtYearlyAmt.Text = "0";
            }
            if (txtOneTimeAmt.Text == "")
            {
                txtOneTimeAmt.Text = "0";
            }
            if (txtOtherAmt.Text == "")
            {
                txtOtherAmt.Text = "0";
            }
            decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
            txtTotalAmt.Text = (Atual).ToString();

            monthsPanel.Visible = false;
        }
    }

    private void LoadMonthsPanel()
    {
        try
        {
            
            

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select intID, MonthName from tblStartMonthMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> GetSearchStudent = new List<string>();
            lstChckBox_Months = new List<CheckBox>();
            CheckBox chk;
            foreach (DataRow item in dt.Rows)
            {
                chk = new CheckBox();
                chk.ID = item["MonthName"].ToString() + "_" + item["intID"].ToString();
                chk.Text = item["MonthName"].ToString();
                chk.CheckedChanged += new EventHandler(chck_CheckedChanged);
                chk.AutoPostBack = true;
                //chk.CheckedChanged += chck_CheckedChanged;
                monthsPanel.Controls.Add(chk);
                lstChckBox_Months.Add(chk);
            }
        }
        catch
        {
        }

    }
    
    public void GetAutoReceiptID()
    {
        try
        {

            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='GetAutoReceiptID',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ViewState["sesReceiptID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["Receipt_Id"]).ToString().Trim();
            }
            else
            {
                ViewState["sesReceiptID"] = "";
            }
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }

    }

    public void FillSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(detailddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillStudent()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='getStudents',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlStudentName, strQry, "vchStudent", "intStudent_id");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillpartType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTDNew @type='GetDurType',@intTutionId='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(qry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //txtDurationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillMonths()
    {
        try
        {

            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='findMonth',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            // strQry = "exec usp_FeesAssignSTDNew @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, strQry, "MonthName", "MonthNo");

        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    public void fillMultiMonths()
    {
        try
        {
            drpToMonth.Visible = true;
            lblToMonth.Visible = true;
            strQry = "";
            //strQry = "exec usp_FeesAssignSTDNew @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='findMonth',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlMonths.DataTextField = "MonthName";
                ddlMonths.DataValueField = "MonthNo";
                ddlMonths.DataSource = dsObj;
                ddlMonths.DataBind();
            }
            if (Convert.ToString(ddlMonths.SelectedValue) != "" && Convert.ToString(ddlMonths.SelectedValue) != "0")
            {
                strQry = "";
                strQry = "exec usp_SchoolFeeCollectionNew_SP @type='findMonthBetween',@MonthNo='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    drpToMonth.DataTextField = "MonthName";
                    drpToMonth.DataValueField = "MonthNo";
                    drpToMonth.DataSource = dsObj;
                    drpToMonth.DataBind();
                    drpToMonth.Items.Insert(0, "---Select---");
                }
            }
            else
            {

            }

        }
        catch (Exception)
        {

        }
    }

    protected void detailddlgender_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetailStudent();
        detailddlStudentName.Focus();
    }
    public void filldetailStudent()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='getStudents',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(detailddlSTD.SelectedValue) + "',@vchGender='" + Convert.ToString(detailddlgender.SelectedItem.Text) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(detailddlStudentName, strQry, "vchStudent", "intStudent_id");
        }
        catch (Exception ex)
        {
            this.LogError(ex);
        }
    }

    protected void detailddlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillfeedetailGrid();
    }

    protected void fillfeedetailGrid()
    {
        try
        {

            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='FillFeeGridview',@intstudent_id='" + detailddlStudentName.SelectedValue + "',@intStandard_id='" + detailddlSTD.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();

            }
        }
        catch (Exception ex)
        {
            this.LogError(ex);

        }
    }

    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["Receipt_Id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            DataSet dsObj = new DataSet();
            string strQry = "";
            //strQry = "Execute dbo.usp_Profile @command='Admission'";// ,@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue.ToString() + "'";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='PrintFeeDetails',@Receipt_Id='" + Session["Receipt_Id"] + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptFee"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("frmFeeReport.aspx", true);
            }
            else
            {
                MessageBox("Record Not Found!");
            }
        }
        catch(Exception ex)
        {
            this.LogError(ex);
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
        }
        catch
        {
        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        ddlGender.ClearSelection();
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlGender.ClearSelection();
        ddlGender.Focus();
    }
    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
        ddlStudentName.Focus();
    }

    public void fillHeadMonthly()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillHeadAmt1',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@feeType='" + Convert.ToString(1) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtTotalAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }
            else
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtEnterAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }

        }
        catch (Exception)
        {

        }
    }

    public void fillHeadMonthlyMulti()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillHeadAmt1',@intStudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@feeType='" + Convert.ToString(5) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvMonthlyMulti.DataSource = dsObj;
                gvMonthlyMulti.DataBind();
                for (int i = 0; i < gvMonthlyMulti.Rows.Count; i++)
                {
                    sum += int.Parse(gvMonthlyMulti.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtTotalAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }

                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }
            else
            {
                gvMonthlyMulti.DataSource = dsObj;
                gvMonthlyMulti.DataBind();
                for (int i = 0; i < gvMonthlyMulti.Rows.Count; i++)
                {
                    sum += int.Parse(gvMonthlyMulti.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtEnterAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }


        }
        catch (Exception)
        {

        }
    }

    public void fillHeadYearly()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillHeadAmt1',@intStudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@feeType='" + Convert.ToString(4) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvYearly.DataSource = dsObj;
                gvYearly.DataBind();
                for (int i = 0; i < gvYearly.Rows.Count; i++)
                {
                    sum += int.Parse(gvYearly.Rows[i].Cells[2].Text);
                }
                txtYearlyAmt.Text = sum.ToString();
                txtTotalAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }
            else
            {
                gvYearly.DataSource = dsObj;
                gvYearly.DataBind();
                for (int i = 0; i < gvYearly.Rows.Count; i++)
                {
                    sum += int.Parse(gvYearly.Rows[i].Cells[2].Text);
                }
                txtYearlyAmt.Text = sum.ToString();
                txtYearlyAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }


        }
        catch (Exception)
        {

        }
    }
    public void fillHeadOneTime()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillHeadAmt1',@intStudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@feeType='" + Convert.ToString(6) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvOneTime.DataSource = dsObj;
                gvOneTime.DataBind();
                for (int i = 0; i < gvOneTime.Rows.Count; i++)
                {
                    sum += int.Parse(gvOneTime.Rows[i].Cells[2].Text);
                }
                txtOneTimeAmt.Text = sum.ToString();
                txtTotalAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }
            else
            {
                gvOneTime.DataSource = dsObj;
                gvOneTime.DataBind();
                for (int i = 0; i < gvOneTime.Rows.Count; i++)
                {
                    sum += int.Parse(gvOneTime.Rows[i].Cells[2].Text);
                }
                txtOneTimeAmt.Text = sum.ToString();
                txtOneTimeAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }


        }
        catch (Exception)
        {

        }
    }
    protected void ddlFeeHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillpartType();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       

        if (drpPayMode.SelectedValue == "0")
        {
            MessageBox("Please Select Pay Mode!");
            drpPayMode.Focus();
            return;
        }

        if (txtAfterDiscount.Text == "0" || txtAfterDiscount.Text == "")
        {
            MessageBox("Please Pay Amount Not Correct!");
            txtLateFee.Focus();
            return;
        }
        notification();
        try
        {
            GetAutoReceiptID();
            checksession();
            if (btnSubmit.Text == "Pay")
            {
                foreach (GridViewRow row in grdPayments.Rows)
                {
                    string amt = row.Cells[4].Text.ToString();
                    string conamt = row.Cells[3].Text.ToString();
                    string vchremark = row.Cells[1].Text.ToString();

                    if (row.Cells[0].Text.ToString() == "Annual Fee")
                    {
                        strQry = "select * from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "'  and intTutionID=4  ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 4 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='"+vchremark+"'";

                            sExecuteQuery(strQry);
                        }
                    }
                    //if (row.Cells[0].Text.ToString() == "Session")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 3 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                    //if (row.Cells[0].Text.ToString() == "Monthly")
                    //{
   
                    //    int monthId = 0;
                        
                    //    string month = row.Cells[1].Text.ToString();
                    //    switch (month)
                    //    {
                    //        case "Jan":
                    //            monthId = 8;
                    //            break;
                    //        case "Feb":
                    //            monthId = 9;
                    //            break;
                    //        case "Mar":
                    //            monthId = 10;
                    //            break;
                    //        case "Apr":
                    //            monthId = 11;
                    //            break;
                    //        case "May":
                    //            monthId = 12;
                    //            break;
                    //        case "Jun":
                    //            monthId = 1;
                    //            break;
                    //        case "Jul":
                    //            monthId = 2;
                    //            break;
                    //        case "Aug":
                    //            monthId = 3;
                    //            break;
                    //        case "Sep":
                    //            monthId = 4;
                    //            break;
                    //        case "Oct":
                    //            monthId = 5;
                    //            break;
                    //        case "Nov":
                    //            monthId = 6;
                    //            break;
                    //        case "Dec":
                    //            monthId = 7;
                    //            break;
                    //    }

                    //    strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intMonth='" + monthId + "' and intTutionID=2  ";
                    //   dsObj = sGetDataset(strQry);
                    //   if (dsObj.Tables[0].Rows.Count > 0)
                    //   {
                    //   }
                    //   else
                    //   {
                    //       strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee', @Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + monthId + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 2 + "',@intMonth_ID='" + month + "',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='" + month + "',@vchToMonth='" + month + "',@SumAmount='" + Convert.ToString(txtTotalAmt.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";
                    //       sExecuteQuery(strQry);
                       
                    //   }
                        
                        
                    //}
                    if (row.Cells[0].Text.ToString() == "Admission Fee")
                    {
                         strQry = "select * from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "'  and intTutionID=3  ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 3 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                            sExecuteQuery(strQry);
                        }
                    }
                    if (row.Cells[0].Text.ToString() == "Exam Fee")
                    {
                        strQry = "select (cast(isnull(sum(intPaidAmt),0)as int)+cast(isnull(sum(intconcessionamt),0)as int)) as intpaidamount from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=5 ";
                        dsObj = sGetDataset(strQry);
                        string paidamt = sExecuteReader(strQry);


                        strQry = "select (numAmount*total_amount) as totalamount from tbl_FeesAssignSTD where intFee_Id=5 and intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
                        string actualamnt = sExecuteReader(strQry);



                        if (int.Parse(paidamt) >= int.Parse(actualamnt))
                        {
                            //MessageBox("Record Already exists");
                        }
                        else
                        {
                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 5 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                            sExecuteQuery(strQry);
                        }
                    }
                    if (row.Cells[0].Text.ToString() == "Tuition Fee")
                    {
                        int monthId = 0;

                        string month = row.Cells[1].Text.ToString();
                        switch (month)
                        {
                            case "Jan":
                                monthId = 8;
                                break;
                            case "Feb":
                                monthId = 9;
                                break;
                            case "Mar":
                                monthId = 10;
                                break;
                            case "Apr":
                                monthId = 11;
                                break;
                            case "May":
                                monthId = 12;
                                break;
                            case "Jun":
                                monthId = 1;
                                break;
                            case "Jul":
                                monthId = 2;
                                break;
                            case "Aug":
                                monthId = 3;
                                break;
                            case "Sep":
                                monthId = 4;
                                break;
                            case "Oct":
                                monthId = 5;
                                break;
                            case "Nov":
                                monthId = 6;
                                break;
                            case "Dec":
                                monthId = 7;
                                break;
                        }
                        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intMonth='" + monthId + "' and intTutionID=6  ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + monthId + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 6 + "',@intMonth_ID='" + month + "',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                            sExecuteQuery(strQry);
                        }
                    }
                    if (row.Cells[0].Text.ToString() == "Misc Fee")
                    {
                        strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 7 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                        sExecuteQuery(strQry);
                    }
                    //if (row.Cells[0].Text.ToString() == "Comp Fee")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 6 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                    //if (row.Cells[0].Text.ToString() == "Science Fee")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 7 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                    //if (row.Cells[0].Text.ToString() == "Lib Fee")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 8 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                    if (row.Cells[0].Text.ToString() == "Transport Fee")
                    {
                        int monthId = 0;

                        string month = row.Cells[1].Text.ToString();
                        switch (month)
                        {
                            case "Jan":
                                monthId = 8;
                                break;
                            case "Feb":
                                monthId = 9;
                                break;
                            case "Mar":
                                monthId = 10;
                                break;
                            case "Apr":
                                monthId = 11;
                                break;
                            case "May":
                                monthId = 12;
                                break;
                            case "Jun":
                                monthId = 1;
                                break;
                            case "Jul":
                                monthId = 2;
                                break;
                            case "Aug":
                                monthId = 3;
                                break;
                            case "Sep":
                                monthId = 4;
                                break;
                            case "Oct":
                                monthId = 5;
                                break;
                            case "Nov":
                                monthId = 6;
                                break;
                            case "Dec":
                                monthId = 7;
                                break;
                        }
                        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intMonth='" + monthId + "' and intTutionID=11  ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {

                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + monthId + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 11 + "',@intMonth_ID='" + month + "',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intArea_ID='" + ddltransport.SelectedValue + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                            sExecuteQuery(strQry);
                        }
                    }
                    if (row.Cells[0].Text.ToString() == "Late")
                    {
                        strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 8 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                        sExecuteQuery(strQry);
                    }

                    if (row.Cells[0].Text.ToString() == "Photo and Insurance")
                    {
                        
                        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=12  ";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                        }
                        else
                        {
                            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 12 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "',@intconcessionamt='" + conamt + "',@vchremark='" + vchremark + "'";

                            sExecuteQuery(strQry);
                        }
                    }

                    //if (row.Cells[0].Text.ToString() == "Registration Fee")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 10 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                    //if (row.Cells[0].Text.ToString() == "Other")
                    //{
                    //    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='InsertFee',@Receipt_Id='" + Convert.ToString(ViewState["sesReceiptID"]) + "',@Month_Id='" + Convert.ToString(ddlOneTime.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + 10 + "',@intMonth_ID='',@intTotalAmt='" + amt + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intAfterDiscount='" + amt + "',@intLateAmt='" + Convert.ToString(txtLateFee.Text.Trim()) + "',@vchFromMonth='',@vchToMonth='',@SumAmount='" + amt + "',@vchChequeNo ='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@Description='" + Convert.ToString(txtRemark.Text.Trim()) + "'";

                    //    sExecuteQuery(strQry);
                    //}
                }

                grdPayments.DataSource = null;
                grdPayments.DataBind();

                FillTransGrid();
                MessageBox("Fee Accepted");
                ddlFeeHead.ClearSelection();
                txtHeadAmt.Text = "";
                txtEnterAmt.Text = "";
                drpPayMode.ClearSelection();
                txtChequeNo.Text = "";
                txtChequeDate.Text = "";
                txtBankName.Text = "";
                lblMonths.Visible = false;
                ddlMonths.Visible = false;
                drpToMonth.Visible = false;
                lblToMonth.Visible = false;
                drpToMonth.ClearSelection();
                ddlMonths.ClearSelection();
                lblc1.Visible = false;
                lblc2.Visible = false;
                lblc3.Visible = false;
                txtChequeNo.Visible = false;
                txtChequeDate.Visible = false;
                txtBankName.Visible = false;
                txtAnnualFee.Text = "";
                txtanuualremark.Text = "";
                txtAmount_Monthly.Text = "";
                txtadmremark.Text = "";
                txtadmfee.Text = "";
                Txtamount.Text = "";
                ddltransport.SelectedIndex = 0;
                txtAmount_Late.Text = "";
                txtRemark_Late.Text = "";
                txtandroidappfeeAmount.Text = "";
                txtandroidfeeremark.Text = "";
                txtAmount_Photo.Text = "";
                txtphotormk.Text = "";
                txtAfterDiscount.Text = "";
                //ddlSTD.SelectedIndex = 0;
                //ddlGender.SelectedIndex = 0;
                //ddlStudentName.SelectedIndex = 0;
                TabPanel2.TabIndex = 1;
                btnReport.Visible = true;
                //Img1.Visible = true;
                return;
            }

        }

        catch (Exception ex)
        {
            this.LogError(ex);

        }
    }

    protected void detailddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        fillStudent();
        
    }

    public void FillTransGrid()
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);

            foreach (ListItem chkBox in monthsList.Items)
            {
                chkBox.Selected = false;
                chkBox.Enabled = true;
            }
            foreach (ListItem chkBox in trasportmnth.Items)
            {
                chkBox.Selected = false;
                chkBox.Enabled = true;
            }

            foreach (DataRow item in dsObj.Tables[0].Rows)
            {
                string feeType = item["vchFee"].ToString();
                string fromMonth = item["FromMonth"].ToString();

                if (feeType == "Monthly")
                {
                    foreach (ListItem chkBox in monthsList.Items)
                    {
                        if (fromMonth == chkBox.Text)
                        {
                            chkBox.Selected = true;
                            chkBox.Enabled = false;
                        }
                    }
                }

            }

            grdTrans.DataSource = dsObj;
            grdTrans.DataBind();

            //for (int i = 0; i < grdTrans.Rows.Count; i++)
            //{
            //    sum += int.Parse(grdTrans.Rows[i].Cells[5].Text);
            //}
            //lblTotal.Text = sum.ToString();  
        }
        catch (Exception)
        {

        }
    }

    protected void ddlGvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='getTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@feeType='" + Convert.ToString(ddlGvType.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            grdTrans.DataSource = dsObj;
            grdTrans.DataBind();
        }
        catch (Exception)
        {

        }
    }

    

    protected void AddToFee_Annual_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text =="0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }
        
        if (txtAnnualFee.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAnnualFee.Focus();
            return;
        }

        strQry = "select * from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=4 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            MessageBox("Record Already exists");
        }
        else
        {

            int payAmount = 0;
            DataTable dt = new DataTable("Fees");

            foreach (var cell in grdPayments.Columns)
            {
                dt.Columns.Add(cell.ToString().Replace(" ", ""));
            }

            foreach (GridViewRow row in grdPayments.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
                payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
            }

            int totalannuamt = (Convert.ToInt32(txtAnnualFee.Text) - Convert.ToInt32(txtanucon.Text));

            dt.Rows.Add("Annual Fee", txtanuualremark.Text, Convert.ToInt32(txtAnnualFee.Text), Convert.ToInt32(txtanucon.Text), totalannuamt);

            //payAmount = payAmount + Convert.ToInt32(txtAnnualFee.Text);
            payAmount = payAmount + totalannuamt;
            txtAfterDiscount.Text = payAmount.ToString();

            grdPayments.DataSource = dt; // bind new datatable to grid
            grdPayments.DataBind();
            grdPayments.Visible = true;
        }

    }

    protected void AddToFee_Transport_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }
        if (Txtamount.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            Txtamount.Focus();
            return;
        }

        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=11 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            foreach (DataTable table in dsObj.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in trasportmnth.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = false;
                        }
                    }
                }
            }
        }


        int payAmount = 0;
        DataTable dt = new DataTable("Fees");



        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
        }

        foreach (ListItem aListItem in trasportmnth.Items)
        {
            if (aListItem.Enabled && aListItem.Selected)
            {

                int totaltranamt = (Convert.ToInt32(Txtamount.Text) - Convert.ToInt32(txttranscon.Text));

                //dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
                dt.Rows.Add("Transport Fee", aListItem.Text, Convert.ToInt32(Txtamount.Text), Convert.ToInt32(txttranscon.Text), totaltranamt);
                //payAmount = payAmount + Convert.ToInt32(Txtamount.Text);
                payAmount = payAmount + totaltranamt;

                aListItem.Enabled = false;
            }
        }

        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();

       
    }

    protected void AddToFee_Other_Click(object sender, EventArgs e)
    {
    }
    protected void AddToFee_Medical_Click(object sender, EventArgs e)
    {
    }

    protected void drpPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayMode.SelectedValue == "2")
        {
            lblc1.Visible = true;
            lblc2.Visible = true;
            lblc3.Visible = true;
            txtChequeNo.Visible = true;
            txtChequeDate.Visible = true;
            txtBankName.Visible = true;
            txtChequeNo.Focus();
        }


        else if (drpPayMode.SelectedValue == "3")
        {
            lblc1.Visible = false;
            lblc2.Visible = false;
            lblc3.Visible = true;
            txtChequeNo.Visible = false;
            txtChequeDate.Visible = false;

            txtBankName.Visible = true;
        }
        else
        {
            lblc1.Visible = false;
            lblc2.Visible = false;
            lblc3.Visible = false;
            txtChequeNo.Visible = false;
            txtChequeDate.Visible = false;
            txtBankName.Visible = false;
        }
    }
    public void Clear()
    {
        try
        {
            ddlFeeHead.ClearSelection();
            txtHeadAmt.Text = "";
            txtEnterAmt.Text = "";
            drpPayMode.ClearSelection();
            txtChequeNo.Text = "";
            txtChequeDate.Text = "";
            txtBankName.Text = "";
            trasportmnth.ClearSelection();

        }
        catch (Exception)
        {

        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
       DataSet dsObj = new DataSet();
        strQry = "";
        strQry = "exec usp_SchoolFeeCollectionNew_SP @type='CReportFeeTrans',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        Session["rptFee"] = dsObj;
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("frmFeeReport.aspx", true);
        }
        else
        {
            MessageBox("Record Not Found!");
        }
       // string reportPath = Server.MapPath("frmFeeRecpt.rpt");
       // crystalReport.Load(reportPath);

        //StudentDetails.ReportSource = crystalReport;
        //StudentDetails.DataBind();
        //StudentDetails.RefreshReport();
    }


    public void fillQuarterly()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTDNew @type='fillQuarterly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlMonths, qry, "vchMonth", "intQuartarly_id");
        }
        catch (Exception)
        {
        }
    }

    public void fillHalfYearly()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTDNew @type='fillHalfYearly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlMonths, qry, "vchMonth", "int_half_yearly_id");
        }
        catch (Exception)
        {
        }
    }
    public void fillAnnualy()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTDNew @type='fillAnnualy',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlYearly, qry, "vchMonth", "intYearly_id");
            ddlYearly.SelectedValue = "1";
        }
        catch (Exception)
        {
        }
    }
    public void fillOneTime()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTDNew @type='fillAnnualy',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlOneTime, qry, "vchMonth", "intYearly_id");
            ddlOneTime.SelectedValue = "1";
        }
        catch (Exception)
        {

        }
    }
    protected void ddlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTransGrid();
        fillRemainingFee();
        FillMonthPay();
        LoadMonthsPanel();
        fillannualFee();
        fillAdmisionfee();
        fillExamfee();
        filltuitionfee();
        fillphotofee();
        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=6 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            foreach (DataTable table in dsObj.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in chktuitionmonth.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = true;
                            item.Enabled = false;
                        }
                    }
                }
            }
        }

        strQry = "select intMonth,intMonth_ID,intArea_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=11 ";
        dsObj1 = sGetDataset(strQry);
        if (dsObj1.Tables[0].Rows.Count > 0)      
        {
            //FillArea();
            //ddltransport.SelectedValue = Convert.ToString(dsObj1.Tables[0].Rows[0]["intArea_ID"]);
            foreach (DataTable table in dsObj1.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in trasportmnth.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = true;
                            item.Enabled = false;
                        }
                    }
                }
            }
        }

        //strQry = "select intMonth,intMonth_ID,intArea_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=12 ";
        //dsObj1 = sGetDataset(strQry);
        //if (dsObj1.Tables[0].Rows.Count > 0)
        //{
        //    //FillArea();
        //    //ddltransport.SelectedValue = Convert.ToString(dsObj1.Tables[0].Rows[0]["intArea_ID"]);
        //    foreach (DataTable table in dsObj1.Tables)
        //    {

        //        foreach (DataRow dr in table.Rows)
        //        {
        //            String S = Convert.ToString(dr["intMonth"].ToString());
        //            foreach (ListItem item in mnthlistphoto.Items)
        //            {
        //                if (S == item.Value)
        //                {
        //                    item.Selected = true;
        //                    item.Enabled = false;
        //                }
        //            }
        //        }
        //    }
        //}


    }
    public void fillAdmisionfee()
    {
        try
        {
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='fillfeeheadwise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intFeeDetId='3'";
            //strQry = "  Select sum(numAmount) as Amount from tbl_AnnualFeeMaster where intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "' and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
            dsObj = sGetDataset(strQry);
            txtadmfee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtadmfee.Enabled = false;
        }
        catch
        { 
           // MessageBox("Pl")
        
        }
    
    }
    public void filltuitionfee()
    {
        try
        {
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='fillfeeheadwise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intFeeDetId='6'";
            //strQry = "  Select sum(numAmount) as Amount from tbl_AnnualFeeMaster where intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "' and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
            dsObj = sGetDataset(strQry);
            txtAmount_tuition.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtAmount_tuition.Enabled = false;
        }
        catch { }

    }

    public void fillExamfee()
    {
        try
        {
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='fillfeeheadwise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intFeeDetId='5'";
            //strQry = "  Select sum(numAmount) as Amount from tbl_AnnualFeeMaster where intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "' and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
            dsObj = sGetDataset(strQry);
            txtAmount_exam.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtAmount_exam.Enabled = false;
        }
        catch
        { }

    }
    public void fillphotofee()
    {
        try
        {
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='fillfeeheadwise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intFeeDetId='12'";
            //strQry = "  Select sum(numAmount) as Amount from tbl_AnnualFeeMaster where intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "' and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
            dsObj = sGetDataset(strQry);
            txtAmount_Photo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtAmount_Photo.Enabled = false;
        }
        catch { }

    }

    public void fillannualFee()
    {
        try
        {
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='fillfeeheadwise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intFeeDetId='4'";
            //strQry = "  Select sum(numAmount) as Amount from tbl_AnnualFeeMaster where intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "' and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
            dsObj = sGetDataset(strQry);
            txtAnnualFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtAnnualFee.Enabled = false;
        }
        catch
        { }


    }

    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drpToMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            txtEnterAmt.Text = "";
            int intMonth = Convert.ToInt32(drpToMonth.SelectedValue) - Convert.ToInt32(ddlMonths.SelectedValue);

            ViewState["intMonth"] = intMonth + 1;
            strQry = "usp_SchoolFeeCollectionNew_SP @type='getFrmToMonthly',@TotalMonth='" + Convert.ToString(intMonth + 1) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtEnterAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            }
            if (txtEnterAmt.Text == "")
            {
                txtEnterAmt.Text = "0";
            }
            if (txtYearlyAmt.Text == "")
            {
                txtYearlyAmt.Text = "0";
            }
            if (txtOneTimeAmt.Text == "")
            {
                txtOneTimeAmt.Text = "0";
            }
            if (txtOtherAmt.Text == "")
            {
                txtOtherAmt.Text = "0";
            }
            decimal Atual = (Decimal.Parse(txtEnterAmt.Text.Trim()));
            txtTotalAmt.Text = (Atual).ToString();
            txtLateFee.Focus();
            txtLateFee_TextChanged(null, null);
        }
        catch
        {
        }

    }
    public void fillHeadforMulti()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillHeadAmt1',@intStudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@feeType='1',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtEnterAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
                if (txtOtherAmt.Text == "")
                {
                    txtOtherAmt.Text = "0";
                }
                decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
                txtTotalAmt.Text = (Atual).ToString();
            }
            else
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                txtEnterAmt.Text = "";
                if (txtEnterAmt.Text == "")
                {
                    txtEnterAmt.Text = "0";
                }
                if (txtYearlyAmt.Text == "")
                {
                    txtYearlyAmt.Text = "0";
                }
                if (txtOneTimeAmt.Text == "")
                {
                    txtOneTimeAmt.Text = "0";
                }
            }
        }
        catch (Exception)
        {

        }
    }
    protected void grdTrans_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            ViewState["intID"] = this.grdTrans.DataKeys[e.RowIndex].Values[3].ToString();
            strQry = "";
            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='delete',@intID='" + Convert.ToString(ViewState["intID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                FillTransGrid();
                MessageBox("Transaction Deleted Successfully!");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void grdTrans_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["sesStandard"] = Convert.ToString(ddlSTD.SelectedValue.Trim());
            Session["sesGender"] = Convert.ToString(ddlGender.SelectedValue.Trim());
            Session["sesStudent"] = Convert.ToString(ddlStudentName.SelectedValue.Trim());
            Session["Receipt_Id"] = this.grdTrans.DataKeys[e.NewEditIndex].Values[0].ToString();
            Session["feeFate"] = this.grdTrans.DataKeys[e.NewEditIndex].Values[1].ToString();
            //Session["feeFate"] = Convert.ToString(grdTrans.DataKeys[e.NewEditIndex].Value);
            //Session["dtTime"] = Convert.ToString(grdTrans.DataKeys[e.NewEditIndex].Value);
            Session["dtTime"] = this.grdTrans.DataKeys[e.NewEditIndex].Values[2].ToString();
            DataSet dsObj = new DataSet();
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='CReportFeeTransPrint',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue.Trim()) + "',@paidDate='" + Convert.ToString(Session["feeFate"]) + "',@paidTime='" + Convert.ToString(Session["dtTime"]) + "',@Receipt_Id='" + Convert.ToString(Session["Receipt_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptStusFee"] = dsObj;
            Response.Redirect("frmStudFeeReport.aspx", true);
        }
        catch (Exception)
        {

        }
    }

    protected void txtOtherAmt_TextChanged(object sender, EventArgs e)
    {
        if (txtEnterAmt.Text == "")
        {
            txtEnterAmt.Text = "0";
        }
        if (txtYearlyAmt.Text == "")
        {
            txtYearlyAmt.Text = "0";
        }
        if (txtOneTimeAmt.Text == "")
        {
            txtOneTimeAmt.Text = "0";
        }
        if (txtOtherAmt.Text == "")
        {
            txtOtherAmt.Text = "0";
        }
        decimal Atual = ((Decimal.Parse(txtEnterAmt.Text.Trim())) + Decimal.Parse(txtYearlyAmt.Text.Trim()) + Decimal.Parse(txtOneTimeAmt.Text.Trim()) + Decimal.Parse(txtOtherAmt.Text.Trim()));
        txtTotalAmt.Text = (Atual).ToString();
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
    protected void txtLateFee_TextChanged(object sender, EventArgs e)
    {
        txtLateFee.Text = "0";
        if (ddlInstallment.SelectedValue == "2")
        {
            if (txtPartAmount.Text != "")
            {
                decimal Atual = (Decimal.Parse(txtPartAmount.Text.Trim()) + Decimal.Parse(txtLateFee.Text.Trim()));
                txtAfterDiscount.Text = (Atual).ToString();
                drpPayMode.Focus();
            }
        }
        else
        {
            if (txtPartAmount.Text != "")
            {
                decimal Atual = (Decimal.Parse(txtTotalAmt.Text.Trim()) + Decimal.Parse(txtLateFee.Text.Trim()) + Decimal.Parse(txtPartAmount.Text.Trim()));
                txtAfterDiscount.Text = (Atual).ToString();
                drpPayMode.Focus();
            }
            else
            {
                decimal Atual = (Decimal.Parse(txtTotalAmt.Text.Trim()) + Decimal.Parse(txtLateFee.Text.Trim()));
                txtAfterDiscount.Text = (Atual).ToString();
                drpPayMode.Focus();
            }

        }
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearchStudent(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select intStudent_id from student_master where intactive_flg=1 and intAcademic_id=1 and intStudent_id like '%'+@Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> GetSearchStudent = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            GetSearchStudent.Add(dt.Rows[i][0].ToString());
        }
        return GetSearchStudent;
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        strQry = "exec usp_SchoolFeeCollectionNew_SP @type='StudentData',@intStudentID_Number='" + Convert.ToString(txtSearch.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            ddlGender.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
            fillStudent();
            ddlStudentName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
            //txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeTotal"]);            
            FillTransGrid();
            fillRemainingFee();

            FillMonthPay();
        }
    }

    private void FillMonthPay()
    {
        string standardId = Convert.ToString(ddlSTD.SelectedValue.Trim());

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select top 1 numAmount from tbl_FeesAssignSTD where intSTD_Id=@intStandard_id and intFee_Id=2 order by 1 desc", con);
        cmd.Parameters.AddWithValue("@intStandard_id", standardId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        if(dt.Rows.Count > 0){
            txtAmount_Monthly.Text = dt.Rows[0][0].ToString();
        }
    }

    public void FillArea()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillArea',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddltransport, strQry, "vchArea_Name", "intArea_Id");
            
        }
        catch
        {

        }
    }

    protected void ddltransport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "exec usp_FeesAssignSTD @type='FillTransportfeeGridAreawise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intArea_Id ='" + Convert.ToString(ddltransport.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Txtamount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                Txtamount.Enabled = false;
            }
        }
        catch 
        { 
        
        }

        //txtPartPayment_Admission.Text = "";
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    lblPartPayment_Admission.Visible = true;
        //    txtPartPayment_Admission.Visible = true;
        //    lblPartPayment_Admission.Enabled = true;
        //    txtPartPayment_Admission.Enabled = true;
        //    AddToFee_Admission.Enabled = true;
        //}
        //else if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    lblPartPayment_Admission.Visible = true;
        //    txtPartPayment_Admission.Visible = true;
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //    lblPartPayment_Admission.Enabled = false;
        //    txtPartPayment_Admission.Enabled = false;
        //    AddToFee_Admission.Enabled = true;
        //}
        //else
        //{
        //    //lblPartPayment_Session.Visible = false;
        //    //txtPartPayment_Session.Visible = false;
        //    AddToFee_Admission.Enabled = false;
        //}
    }

    //protected void ddlPaymentType_Session_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtPartPayment_Session.Text = "";
    //    if (ddlPaymentType_Session.SelectedValue == "2")
    //    {
    //        lblPartPayment_Session.Visible = true;
    //        txtPartPayment_Session.Visible = true;
    //        lblPartPayment_Session.Enabled = true;
    //        txtPartPayment_Session.Enabled = true;
    //        AddToFee_Session.Enabled = true;
    //    }
    //    else if (ddlPaymentType_Session.SelectedValue == "1")
    //    {
    //        lblPartPayment_Session.Visible = true;
    //        txtPartPayment_Session.Visible = true;
    //        txtPartPayment_Session.Text = gvfeePaid.Rows[0].Cells[0].Text;
    //        lblPartPayment_Session.Enabled = false;
    //        txtPartPayment_Session.Enabled = false;
    //        AddToFee_Session.Enabled = true;
    //    }
    //    else
    //    {
    //        lblPartPayment_Session.Visible = false;
    //        txtPartPayment_Session.Visible = false;
    //        AddToFee_Session.Enabled = false;
    //    }
    //}

    protected void ddlInstallment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstallment.SelectedValue == "2")
        {
            lblPartAmt.Visible = true;
            txtPartAmount.Visible = true;
        }
        else
        {
            lblPartAmt.Visible = false;
            txtPartAmount.Visible = false;
        }
        txtLateFee_TextChanged(null, null);
    }

    public void fillRemainingFee()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillRemainingFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intStudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + Convert.ToString(3) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvfeePaid.DataSource = dsObj;
                gvfeePaid.DataBind();
            }
        }
        catch (Exception)
        {

        }
    }

    protected void txtPartAmount_TextChanged(object sender, EventArgs e)
    {
        txtLateFee_TextChanged(null, null);
    }

    protected void AddToFee_Admission_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }
        if (txtadmfee.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtadmfee.Focus();
            return;
        }

        if (Convert.ToInt32(txtadmfee.Text) <= 0)
        {
            MessageBox("Please enter amount greater than 0.");
            txtadmfee.Focus();
            return;
        }
        strQry = "select * from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=3 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            MessageBox("Record Already exists");
        }
        else
        {

            int payAmount = 0;

            DataTable dt = new DataTable("Fees");

            foreach (var cell in grdPayments.Columns)
            {
                dt.Columns.Add(cell.ToString().Replace(" ", ""));
            }

            foreach (GridViewRow row in grdPayments.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
                payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
            }

            //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

            //if (ddlPaymentType_Admission.SelectedValue == "1")
            //{
            //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
            //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
            //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
            //}
            //if (ddlPaymentType_Admission.SelectedValue == "2")
            //{
            //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
            //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
            //    txtPartPayment_Admission.Text = "0";
            //}

            int totalamt = (Convert.ToInt32(txtadmfee.Text) - Convert.ToInt32(txtadmcon.Text));

            dt.Rows.Add("Admission Fee", txtadmremark.Text, Convert.ToInt32(txtadmfee.Text), Convert.ToInt32(txtadmcon.Text), totalamt);

           // payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);
            payAmount = payAmount + totalamt;
            txtAfterDiscount.Text = payAmount.ToString();

            grdPayments.DataSource = dt; // bind new datatable to grid
            grdPayments.DataBind();
            grdPayments.Visible = true;
        }
    }

    protected void AddToFee_Tution_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }
        //if (txttutionamt.Text.Length <= 0)
        //{
        //    MessageBox("Please Enter Amount.");
        //    txttutionamt.Focus();
        //    return;
        //}

        //if (Convert.ToInt32(txttutionamt.Text) <= 0)
        //{
        //    MessageBox("Please enter amount greater than 0.");
        //    txttutionamt.Focus();
        //    return;
        //}

        

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}


        //dt.Rows.Add("Tution Fee", txttutionremk.Text, Convert.ToInt32(txttutionamt.Text));

        //payAmount = payAmount + Convert.ToInt32(txttutionamt.Text);
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }

    protected void AddToFee_Comp_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        //if (txtcomamount.Text.Length <= 0)
        //{
        //    MessageBox("Please Enter Amount.");
        //    txtcomamount.Focus();
        //    return;
        //}

        //if (Convert.ToInt32(txtcomamount.Text) <= 0)
        //{
        //    MessageBox("Please enter amount greater than 0.");
        //    txtcomamount.Focus();
        //    return;
        //}

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}


        //dt.Rows.Add("Comp Fee", txtcmpremk.Text, Convert.ToInt32(txtcomamount.Text));

        //payAmount = payAmount + Convert.ToInt32(txtcomamount.Text);
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }

    protected void AddToFee_Sci_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        //if (txtsciamt.Text.Length <= 0)
        //{
        //    MessageBox("Please Enter Amount.");
        //    txtsciamt.Focus();
        //    return;
        //}

        //if (Convert.ToInt32(txtsciamt.Text) <= 0)
        //{
        //    MessageBox("Please enter amount greater than 0.");
        //    txtsciamt.Focus();
        //    return;
        //}

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}


        //dt.Rows.Add("Science Fee", txtsciremk.Text, Convert.ToInt32(txtsciamt.Text));

        //payAmount = payAmount + Convert.ToInt32(txtsciamt.Text);
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }


    //protected void AddToFee_Registration_Click(object sender, EventArgs e)
    //{
    //    if (ddlStudentName.Text == "0")
    //    {
    //        MessageBox("Please Select StudentName.");
    //        ddlStudentName.Focus();
    //        return;
    //    }
    //    if (txtregfeeAmount.Text.Length <= 0)
    //    {
    //        MessageBox("Please Enter Amount.");
    //        txtregfeeAmount.Focus();
    //        return;
    //    }

    //    if (Convert.ToInt32(txtregfeeAmount.Text) <= 0)
    //    {
    //        MessageBox("Please enter amount greater than 0.");
    //        txtregfeeAmount.Focus();
    //        return;
    //    }

    //    int payAmount = 0;

    //    DataTable dt = new DataTable("Fees");

    //    foreach (var cell in grdPayments.Columns)
    //    {
    //        dt.Columns.Add(cell.ToString().Replace(" ", ""));
    //    }

    //    foreach (GridViewRow row in grdPayments.Rows)
    //    {
    //        dt.Rows.Add();
    //        for (int i = 0; i < row.Cells.Count; i++)
    //        {
    //            dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
    //        }
    //        payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
    //    }

    //    //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

    //    //if (ddlPaymentType_Admission.SelectedValue == "1")
    //    //{
    //    //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
    //    //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
    //    //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
    //    //}
    //    //if (ddlPaymentType_Admission.SelectedValue == "2")
    //    //{
    //    //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
    //    //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
    //    //    txtPartPayment_Admission.Text = "0";
    //    //}


    //    dt.Rows.Add("Registration Fee", txtregfeeremark.Text, Convert.ToInt32(txtregfeeAmount.Text));

    //    payAmount = payAmount + Convert.ToInt32(txtregfeeAmount.Text);
    //    txtAfterDiscount.Text = payAmount.ToString();

    //    grdPayments.DataSource = dt; // bind new datatable to grid
    //    grdPayments.DataBind();
    //    grdPayments.Visible = true;
    //}
    protected void AddToFee_Exam_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        if (txtAmount_exam.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_exam.Focus();
            return;
        }

        if (Convert.ToInt32(txtAmount_exam.Text) <= 0)
        {
            MessageBox("Please enter amount greater than 0.");
            txtAmount_exam.Focus();
            return;
        }

        strQry = "select (cast(isnull(sum(intPaidAmt),0)as int)+cast(isnull(sum(intconcessionamt),0)as int)) as intpaidamount from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=5 ";
        dsObj = sGetDataset(strQry);
        string paidamt = sExecuteReader(strQry);

        strQry = "select (numAmount*total_amount) as totalamount from tbl_FeesAssignSTD where intFee_Id=5 and intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
        //strQry = "select case when ('2019-04-01' <= GETDATE() and '2019-09-30' >= GETDATE()) then ((select top 1 numAmount from tbl_FeesAssignSTD where intSTD_Id='"+ddlSTD.SelectedValue+"' and intFee_Id=5 order by 1 desc)*1) else ((select top 1 numAmount from tbl_FeesAssignSTD where intSTD_Id='"+ddlSTD.SelectedValue+"' and intFee_Id=5 order by 1 desc)*2) end as intamount ";
        string actualamnt = sExecuteReader(strQry);


        if (int.Parse(paidamt) >= int.Parse(actualamnt))
        {
            MessageBox("Record Already exists");
        }
        else
        {

            int payAmount = 0;

            DataTable dt = new DataTable("Fees");

            foreach (var cell in grdPayments.Columns)
            {
                dt.Columns.Add(cell.ToString().Replace(" ", ""));
            }

            foreach (GridViewRow row in grdPayments.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
                payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
            }

            //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

            //if (ddlPaymentType_Admission.SelectedValue == "1")
            //{
            //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
            //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
            //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
            //}
            //if (ddlPaymentType_Admission.SelectedValue == "2")
            //{
            //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
            //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
            //    txtPartPayment_Admission.Text = "0";
            //}

            int totalexamamt = (Convert.ToInt32(txtAmount_exam.Text) - Convert.ToInt32(txtexamcon.Text));

            dt.Rows.Add("Exam Fee", txtRemark_exam.Text, Convert.ToInt32(txtAmount_exam.Text), Convert.ToInt32(txtexamcon.Text), totalexamamt);

            //payAmount = payAmount + Convert.ToInt32(txtAmount_exam.Text);
            payAmount = payAmount + totalexamamt;
            txtAfterDiscount.Text = payAmount.ToString();

            grdPayments.DataSource = dt; // bind new datatable to grid
            grdPayments.DataBind();
            grdPayments.Visible = true;
        }
    }

    protected void AddToFee_tuition_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        if (txtAmount_tuition.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_tuition.Focus();
            return;
        }

        if (Convert.ToInt32(txtAmount_tuition.Text) <= 0)
        {
            MessageBox("Please enter amount greater than 0.");
            txtAmount_tuition.Focus();
            return;
        }

        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=6 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            foreach (DataTable table in dsObj.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in chktuitionmonth.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = false;
                        }
                    }
                }
            }
        }

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}

        foreach (ListItem aListItem in chktuitionmonth.Items)
        {
            if (aListItem.Enabled && aListItem.Selected)
            {

                int totaltuiamt = (Convert.ToInt32(txtAmount_tuition.Text) - Convert.ToInt32(txttuicon.Text));
                //dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
                dt.Rows.Add("Tuition Fee", aListItem.Text, Convert.ToInt32(txtAmount_tuition.Text), Convert.ToInt32(txttuicon.Text), totaltuiamt);
                //payAmount = payAmount + Convert.ToInt32(txtAmount_tuition.Text);
                payAmount = payAmount + totaltuiamt;

                aListItem.Enabled = false;
            }
        }


        //dt.Rows.Add("Tuition Fee", txtremark_tuition.Text, Convert.ToInt32(txtAmount_tuition.Text));

        //payAmount = payAmount + Convert.ToInt32(txtAmount_tuition.Text);
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }
    protected void AddToFee_Misc_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        if (txtAmount_misc.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_misc.Focus();
            return;
        }

        if (Convert.ToInt32(txtAmount_misc.Text) <= 0)
        {
            MessageBox("Please enter amount greater than 0.");
            txtAmount_misc.Focus();
            return;
        }

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}

        int totalmiscamt = (Convert.ToInt32(txtAmount_misc.Text) - Convert.ToInt32(txtmiscon.Text));

        dt.Rows.Add("Misc Fee", txtRemark_misc.Text, Convert.ToInt32(txtAmount_misc.Text), Convert.ToInt32(txtmiscon.Text), totalmiscamt);

        //payAmount = payAmount + Convert.ToInt32(txtAmount_misc.Text);
        payAmount = payAmount + totalmiscamt;
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }

    protected void AddToFee_Game_Click(object sender, EventArgs e)
    {
    }

    protected void AddToFee_Maintain_Click(object sender, EventArgs e)
    {


    }

    protected void AddToFee_Android_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        if (txtandroidappfeeAmount.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtandroidappfeeAmount.Focus();
            return;
        }

        if (Convert.ToInt32(txtandroidappfeeAmount.Text) <= 0)
        {
            MessageBox("Please enter amount greater than 0.");
            txtandroidappfeeAmount.Focus();
            return;
        }

        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=9 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            foreach (DataTable table in dsObj.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in chkAppmonth.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = false;
                        }
                    }
                }
            }
        }

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}

        foreach (ListItem aListItem in chkAppmonth.Items)
        {
            if (aListItem.Enabled && aListItem.Selected)
            {


                //dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
                dt.Rows.Add("AndroidApp Fee", aListItem.Text, Convert.ToInt32(txtandroidappfeeAmount.Text));
                payAmount = payAmount + Convert.ToInt32(txtandroidappfeeAmount.Text);

                aListItem.Enabled = false;
            }
        }


        //dt.Rows.Add("AndroidApp Fee", txtandroidfeeremark.Text, Convert.ToInt32(txtandroidappfeeAmount.Text));

        //payAmount = payAmount + Convert.ToInt32(txtandroidappfeeAmount.Text);
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }

    protected void AddToFee_Lib_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
            return;
        }
        //if (txtlibamt.Text.Length <= 0)
        //{
        //    MessageBox("Please Enter Amount.");
        //    txtlibamt.Focus();
        //    return;
        //}

        //if (Convert.ToInt32(txtlibamt.Text) <= 0)
        //{
        //    MessageBox("Please enter amount greater than 0.");
        //    txtlibamt.Focus();
        //    return;
        //}

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        //payAmount = payAmount + Convert.ToInt32(txtadmfee.Text);

        //if (ddlPaymentType_Admission.SelectedValue == "1")
        //{
        //    dt.Rows.Add("Admission", "Full Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //}
        //if (ddlPaymentType_Admission.SelectedValue == "2")
        //{
        //    dt.Rows.Add("Admission", "Part Payment", Convert.ToInt32(txtPartPayment_Admission.Text));
        //    gvfeePaid.Rows[0].Cells[1].Text = (Convert.ToInt32(txtPartPayment_Admission.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[1].Text)).ToString();
        //    txtPartPayment_Admission.Text = "0";
        //}


        //dt.Rows.Add("Lib Fee", txtlibremk.Text, Convert.ToInt32(txtlibamt.Text));

        //payAmount = payAmount + Convert.ToInt32(txtlibamt.Text);
        //txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();
        grdPayments.Visible = true;
    }

    //protected void AddToFee_Session_Click(object sender, EventArgs e)
    //{
    //    //if (txtPartPayment_Session.Text.Length <= 0)
    //    //{
    //    //    MessageBox("Please Enter Amount.");
    //    //    txtPartPayment_Session.Focus();
    //    //    return;
    //    //}

    //    //if (Convert.ToInt32(txtPartPayment_Session.Text) <= 0)
    //    //{
    //    //    MessageBox("Please enter amount greater than 0.");
    //    //    txtPartPayment_Session.Focus();
    //    //    return;
    //    //}

    //    int payAmount = 0;

    //    DataTable dt = new DataTable("Fees");

    //    foreach (var cell in grdPayments.Columns)
    //    {
    //        dt.Columns.Add(cell.ToString().Replace(" ", ""));
    //    }

    //    foreach (GridViewRow row in grdPayments.Rows)
    //    {
    //        dt.Rows.Add();
    //        for (int i = 0; i < row.Cells.Count; i++)
    //        {
    //            dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
    //        }
    //        payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
    //    }

    //    //payAmount = payAmount + Convert.ToInt32(txtPartPayment_Session.Text);

    //    //if (ddlPaymentType_Session.SelectedValue == "1")
    //    //{
    //    //    dt.Rows.Add("Session", "Full Payment", Convert.ToInt32(txtPartPayment_Session.Text));
    //    //    gvfeePaid.Rows[0].Cells[0].Text = (Convert.ToInt32(txtPartPayment_Session.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[0].Text)).ToString();
    //    //    txtPartPayment_Session.Text = gvfeePaid.Rows[0].Cells[0].Text;
    //    //}
    //    //if (ddlPaymentType_Session.SelectedValue == "2")
    //    //{
    //    //    dt.Rows.Add("Session", "Part Payment", Convert.ToInt32(txtPartPayment_Session.Text));
    //    //    gvfeePaid.Rows[0].Cells[0].Text = (Convert.ToInt32(txtPartPayment_Session.Text) - Convert.ToInt32(gvfeePaid.Rows[0].Cells[0].Text)).ToString();
    //    //    txtPartPayment_Session.Text = "0";
    //    //}

    //    txtAfterDiscount.Text = payAmount.ToString();

    //    grdPayments.DataSource = dt; // bind new datatable to grid
    //    grdPayments.DataBind();
    //}

    protected void AddToFee_Monthly_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }

        if (txtAmount_Monthly.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_Monthly.Focus();
            return;
        }

        strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=2 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            foreach (DataTable table in dsObj.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    String S = Convert.ToString(dr["intMonth"].ToString());
                    foreach (ListItem item in monthsList.Items)
                    {
                        if (S == item.Value)
                        {
                            item.Selected = false;
                        }
                    }
                }
            }
        }

        int payAmount = 0;

        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
        }

        foreach (ListItem aListItem in monthsList.Items)
        {
            if (aListItem.Enabled && aListItem.Selected)
            {
              
                
                //dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
                dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
                payAmount = payAmount + Convert.ToInt32(txtAmount_Monthly.Text);

                aListItem.Enabled = false;
            }
        }

        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();

    }
 

    protected void AddToFee_photo_Click(object sender, EventArgs e)
    {
        //if (txtRemark_Other.Text.Length <= 0)
        //{
        //    MessageBox("Please Enter Remark.");
        //    txtRemark_Other.Focus();
        //    return;
        //}

        if (txtAmount_Photo.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_Photo.Focus();
            return;
        }

        strQry = "select * from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=12 ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            MessageBox("Record Already exists");
        }
        else
        {

            int payAmount = 0;
            DataTable dt = new DataTable("Fees");

            foreach (var cell in grdPayments.Columns)
            {
                dt.Columns.Add(cell.ToString().Replace(" ", ""));
            }

            foreach (GridViewRow row in grdPayments.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
                payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
            }

            int totalphotocamt = (Convert.ToInt32(txtAmount_Photo.Text) - Convert.ToInt32(txtphotocon.Text));

            dt.Rows.Add("Photo and Insurance", txtphotormk.Text, Convert.ToInt32(txtAmount_Photo.Text), Convert.ToInt32(txtphotocon.Text), totalphotocamt);

            payAmount = payAmount + totalphotocamt;
            //payAmount = payAmount + Convert.ToInt32(txtAmount_Photo.Text);

            //strQry = "select intMonth,intMonth_ID from tblfeecollection where intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "' and intTutionID=2 ";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataTable table in dsObj.Tables)
            //    {

            //        foreach (DataRow dr in table.Rows)
            //        {
            //            String S = Convert.ToString(dr["intMonth"].ToString());
            //            foreach (ListItem item in mnthlistphoto.Items)
            //            {
            //                if (S == item.Value)
            //                {
            //                    item.Selected = false;
            //                }
            //            }
            //        }
            //    }
            //}

            //int payAmount = 0;

            //DataTable dt = new DataTable("Fees");

            //foreach (var cell in grdPayments.Columns)
            //{
            //    dt.Columns.Add(cell.ToString().Replace(" ", ""));
            //}

            //foreach (GridViewRow row in grdPayments.Rows)
            //{
            //    dt.Rows.Add();
            //    for (int i = 0; i < row.Cells.Count; i++)
            //    {
            //        dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            //    }
            //    payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["Amount"].ToString());
            //}

            //foreach (ListItem aListItem in mnthlistphoto.Items)
            //{
            //    if (aListItem.Enabled && aListItem.Selected)
            //    {


            //        //dt.Rows.Add("Monthly", aListItem.Text, Convert.ToInt32(txtAmount_Monthly.Text));
            //        dt.Rows.Add("Photo and Insurance", aListItem.Text, Convert.ToInt32(txtAmount_Photo.Text));
            //        payAmount = payAmount + Convert.ToInt32(txtAmount_Photo.Text);

            //        aListItem.Enabled = false;
            //    }
            //}

            txtAfterDiscount.Text = payAmount.ToString();

            grdPayments.DataSource = dt; // bind new datatable to grid
            grdPayments.DataBind();
        }

    }

    protected void monthsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loop through checkBoxList to select selected items
        //foreach (ListItem aListItem in monthsList.Items)
        //{
        //    if (aListItem.Enabled && aListItem.Selected)
        //    {

        //    }
        //}

    }

    protected void txtSearchVal_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strQry = "usp_Profile @command='SearchBySerial_number',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@Searchbyvalue='" + txtSearchVal.Text + "'";
            dsObj = sGetDataset(strQry);

            string intStandard_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            string intstudent_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);

            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='FillFeeGridview',@intstudent_id='" + intstudent_id + "',@intStandard_id='" + intStandard_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();

            }
        }
        catch( Exception  ex)
        {
        }

    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strQry = "usp_Profile @command='SearchBySerial_number',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@Searchbyvalue='" + TextBox1.Text + "'";
            dsObj = sGetDataset(strQry);

            string intStandard_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            ddlSTD.SelectedValue = intStandard_id;
            string Gender = Convert.ToString(dsObj.Tables[0].Rows[0]["vchgender"]);
            ddlGender.SelectedValue = Gender;
            fillStudent();
            string intstudent_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);
            ddlStudentName.SelectedValue = intstudent_id;
          
        }
        catch (Exception ex)
        {
        }
    }

    protected void trasportmnth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loop through checkBoxList to select selected items
        //foreach (ListItem aListItem in monthsList.Items)
        //{
        //    if (aListItem.Enabled && aListItem.Selected)
        //    {

        //    }
        //}

    }

    protected void grdPayments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            //grdPayments.DeleteRow(index);

            DataTable dt = new DataTable("DeleteFee");

            foreach (var cell in grdPayments.Columns)
            {
                dt.Columns.Add(cell.ToString().Replace(" ", ""));
            }

            foreach (GridViewRow row in grdPayments.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
            }

            if (dt.Rows[index]["FeeType"].ToString() == "Monthly")
            {
                foreach (ListItem aListItem in monthsList.Items)
                {
                    if (dt.Rows[index]["Remark"].ToString() == aListItem.Text)
                    {
                        aListItem.Selected = false;
                        aListItem.Enabled = true;
                    }
                }
            }

            if (dt.Rows[index]["FeeType"].ToString() == "Transport Fee")
            {
                foreach (ListItem aListItem in trasportmnth.Items)
                {
                    if (dt.Rows[index]["Remark"].ToString() == aListItem.Text)
                    {
                        aListItem.Selected = false;
                        aListItem.Enabled = true;
                    }
                }
            }

            txtAfterDiscount.Text = (Convert.ToInt32(txtAfterDiscount.Text.ToString()) - Convert.ToInt32(dt.Rows[index]["TotalAmount"].ToString())).ToString();

            dt.Rows.Remove(dt.Rows[index]);

            grdPayments.DataSource = dt;
            grdPayments.DataBind();

        }
    }

    protected void grdPayments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void txtPartPayment_Session_Click(object sender, EventArgs e)
    {
        TextBox amt = new TextBox();
        amt.Text = gvfeePaid.Rows[0].Cells[0].Text;
        //if (Convert.ToInt32(amt.Text) < Convert.ToInt32(txtPartPayment_Session.Text))
        //{
        //    MessageBox("Please Check Part Amount!");
        //}
    }
    protected void txtPartPayment_Admission_Click(object sender, EventArgs e)
    {
        TextBox amt = new TextBox();
        amt.Text = gvfeePaid.Rows[0].Cells[1].Text;
        //if (Convert.ToInt32(amt.Text) < Convert.ToInt32(txtPartPayment_Admission.Text))
        //{
        //    MessageBox("Please Check Admission Amount!");
        //}
    }
    protected void AddToFee_Late_Click(object sender, EventArgs e)
    {
        if (ddlStudentName.Text == "0")
        {
            MessageBox("Please Select StudentName.");
            ddlStudentName.Focus();
        }

        if (txtRemark_Late.Text.Length <= 0)
        {
            MessageBox("Please Enter Remark.");
            txtRemark_Late.Focus();
            return;
        }

        if(txtAmount_Late.Text.Length <= 0)
        {
            MessageBox("Please Enter Amount.");
            txtAmount_Late.Focus();
            return;
        }

        int payAmount = 0;
        DataTable dt = new DataTable("Fees");

        foreach (var cell in grdPayments.Columns)
        {
            dt.Columns.Add(cell.ToString().Replace(" ", ""));
        }

        foreach (GridViewRow row in grdPayments.Rows)
        {
            dt.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
            }
            payAmount = payAmount + Convert.ToInt32(dt.Rows[row.RowIndex]["TotalAmount"].ToString());
        }

        int totallateamt = (Convert.ToInt32(txtAmount_Late.Text) - Convert.ToInt32(txtlatecon.Text));

        dt.Rows.Add("Late", txtRemark_Late.Text, Convert.ToInt32(txtAmount_Late.Text), Convert.ToInt32(txtlatecon.Text), totallateamt);

        //payAmount = payAmount + Convert.ToInt32(txtAmount_Late.Text);
        payAmount = payAmount + totallateamt;
        txtAfterDiscount.Text = payAmount.ToString();

        grdPayments.DataSource = dt; // bind new datatable to grid
        grdPayments.DataBind();

    }
    public void notification()
    {
        //code for notification
        string strFcmTokan = "";
        var applicationID = "AIzaSyCHfQSjFsEybdNRibLORHTMVVp6CKoI5TQ"; // PbojmyrmspdqkZ0pINni7DyqvhY2

        string message = "A new Notice For you";
        string title = "NoticeBoard";
        var SENDER_ID = "574926706382";
        // 73064704159
        var value = message.Trim();
        WebRequest tRequest;
        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        tRequest.Method = "post";
        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + strFcmTokan + "&data.title=" + title + "";

        Console.WriteLine(postData);
        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        tRequest.ContentLength = byteArray.Length;

        Stream dataStream = tRequest.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        WebResponse tResponse = tRequest.GetResponse();

        dataStream = tResponse.GetResponseStream();

        StreamReader tReader = new StreamReader(dataStream);

        String sResponseFromServer = tReader.ReadToEnd();

    }
}