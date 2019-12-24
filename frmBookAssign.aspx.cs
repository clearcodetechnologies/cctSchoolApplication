using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmBookAssign :DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            getStandard();   
            //getBook();
            fGrid();
           
            //txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            //txtReturnDate.Text = Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            //txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            //txtReturnDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
        }
    }


    protected void fGrid()
    {
        strQry = "[usp_tblBookAssign] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
    }

    protected void getStandard()
    {
        try
        {
            string str1 = "[usp_tblBookAssign] @command='getStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, str1, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSstandard, str1, "vchStandard_name", "intstandard_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void getDivision()
    {
        string str1 = "[usp_tblBookAssign] @command='getDivision',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlDivisionId, str1, "vchDivisionName", "intDivision_id");
       
    }
    protected void getSerchDivision()
    {
        string str1 = "[usp_tblBookAssign] @command='getDivision',@intstandard_id='" + ddlSstandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlDdivision, str1, "vchDivisionName", "intDivision_id");

    }

    protected void getStudent()
    {
        string str1 = "[usp_tblBookAssign] @command='getStudent',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

        sBindDropDownList(ddlStudentId, str1, "Student_name", "intStudent_id");
    }


    //protected void getBook()
    //{
    //    string str1 = "[usp_tblBookAssign] @command='getBook',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //    sBindDropDownList(ddlBookId, str1, "bookname", "intBookDetails_id");
   
    //}



    public void clear()
    {
        try
        {
            btnSubmit.Text = "Submit";
            txtReturnDate.Text="";  
            ddlStandard.ClearSelection();
            ddlDivisionId.ClearSelection();
            ddlStudentId.ClearSelection();
            //ddlBookId.ClearSelection();
            txtAccession.Text = "";
            txtStatus.ClearSelection();
        }
        catch
        {
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Standard!");
            ddlStandard.Focus();
            return;
        }
        if (ddlDivisionId.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Book Division!");
            ddlDivisionId.Focus();
            return;
        }
        if (ddlStudentId.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Book Student!");
            ddlStudentId.Focus();
            return;
        }
        //if (ddlBookId.SelectedValue == "---Select----")
        //{
        //    MessageBox("Please select Book");
        //    ddlBookId.Focus();
        //    return;
        //}

        if (txtAccession.Text == "")
        {
            MessageBox("Please Insert Accession No!");
            txtAccession.Focus();
            return;
        }
        if (txtAssignDate.Text == "")
        {
            MessageBox("Please Assign Date!");
            txtAssignDate.Focus();
            return;
        }
        if (txtReturnDate.Text == "")
        {
            MessageBox("Please Select Return Date!");
            txtReturnDate.Focus();
            return;
        }
        if (txtStatus.SelectedValue== "0")
        {
            MessageBox("Please Select Status!");
            txtStatus.Focus();
            return;
        }

        strQry = "";
        string assdt = Convert.ToDateTime(txtAssignDate.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        string retdt = Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy");
        if (btnSubmit.Text == "Submit")
        {
            //strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + txtAccession.Text.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Book Already Exists");
                return;
            }
            else
            {
                //strQry = "exec [usp_tblBookAssign] @command='insert',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + retdt + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                strQry = "exec [usp_tblBookAssign] @command='insert',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + txtAccession.Text.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + retdt + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Book Assigned Successfully!");
                    clear();
                }
            }
        }
        else
        {
            //strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{

            strQry = "exec [usp_tblBookAssign] @command='update',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + txtAccession.Text.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + retdt + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            //}
        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDivision();
    }
    protected void ddlDivisionId_SelectedIndexChanged(object sender, EventArgs e)
    {
        getStudent();
    }

    protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["BookAssignID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblBookAssign] @command='delete',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["BookAssignID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblBookAssign @command='edit',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                ddlStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                getDivision();
                ddlDivisionId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                getStudent();
                ddlStudentId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                txtAccession.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAccessionNo"]);
                //ddlBookId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookDetails_id"]);
                txtAssignDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtAssigned_Date"]);
                txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");            
                txtReturnDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturn_date"]);
                txtReturnDate.Text = Convert.ToDateTime(txtReturnDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
                txtStatus.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStatus"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }

    protected void txtSearchAccession_TextChanged(object sender, EventArgs e)
    {
        fSearchGrid();
    }
    protected void fSearchGrid()
    {
        strQry = "[usp_tblBookAssign] @command='fSearchGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchAccessionNo='" + Convert.ToString(txtSearchAccession.Text.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearchAccession(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsSKP"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from tblBookAssign where vchAccessionNo like @Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> GetSearchAccession = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            GetSearchAccession.Add(dt.Rows[i][4].ToString());
        }
        return GetSearchAccession;
    }
    protected void ddlSstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerchDivision();
    }
    protected void ddlDdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        fSearchDivisionrid(); 
    }
    protected void fSearchDivisionrid()
    {
        strQry = "[usp_tblBookAssign] @command='fSearchDivisionrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(ddlDdivision.SelectedValue.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
    }
}