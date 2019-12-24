using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BookDetails : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillStandard();
            fBookCategory();
            //fBookEdition();
            //fBookPublication();
            //fBookAuthor();
            fGrid();
            BookSubject();
        }
    }


    protected void fGrid()
    {

        strQry = "usp_BookDetails @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
           // txtName.Text = "";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
           // txtName.Text = "";
        }
    }
    protected void fillStandard()
    {
        strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlStandard, strQry, "Standard_name", "intStandard_id");
        sBindDropDownList(ddlDetStandard, strQry, "Standard_name", "intStandard_id");
    }
    protected void BookSubject()
    {
        strQry = "[usp_BookDetails] @command='BookSubject',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
        sBindDropDownList(ddlDetSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
    }

    protected void fBookCategory()
    {
        strQry = "[usp_BookDetails] @command='BookCategory',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookCategory, strQry, "vchCategory_name", "intCategory_id");
    }
    //protected void fBookEdition()
    //{
    //    strQry = "[usp_BookDetails] @command='BookEdition',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //    sBindDropDownList(ddlBookEdition, strQry, "vchBookEdition_name", "intBookEdition_id");
    //}
    //protected void fBookPublication()
    //{
    //    strQry = "[usp_BookDetails] @command='BookPublication',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //    sBindDropDownList(ddlBookPublication, strQry, "vchBook_publication_name", "intBook_publication_id");

    //}
   
    //protected void fBookAuthor()
    //{
    //    strQry = "[usp_BookDetails] @command='BookAuthor',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //    sBindDropDownList(ddlBookAuthor, strQry, "vchBook_Author_name", "intBook_Author_id");
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedValue == "0")
        {
            MessageBox("Please select Standard");
            ddlStandard.Focus();
            return;
        }
        if (ddlBookCategory.SelectedValue == "0")
        {
            MessageBox("please Select Book Category");
            ddlBookCategory.Focus();
            return;
        }
        //if (ddlBookEdition.SelectedValue == "0")
        //{
        //    MessageBox("please Select Book Edition");
        //    ddlBookEdition.Focus();
        //    return;
        //}
        //if (ddlBookPublication.SelectedValue == "0")
        //{
        //    MessageBox("Please Select Publication");
        //    ddlBookPublication.Focus();
        //    return;
        //}
        //if (ddlBookAuthor.SelectedValue == "0")
        //{
        //    MessageBox("Please Select Author!");
        //    ddlBookPublication.Focus();
        //    return;
        //}
        if (ddlSubject.SelectedValue == "0")
        {
            MessageBox("Please Select Subject!");
           // ddlBookPublication.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            MessageBox("Please Insert Book Name!");
            txtName.Focus();
            return;
        }
        if (txtAccessionNo.Text == "")
        {
            MessageBox("Please Insert Accession No!");
            txtAccessionNo.Focus();
            return;
        }  
         strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_BookDetails @command='checkExistAccession',@vchAccessionNo='" + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Accession No. is Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_BookDetails] @command='insert',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + Convert.ToString(txtedition.Text.Trim()) + "',@intBook_publication_id='" + Convert.ToString(txtpublication.Text) + "',@intBook_Author_id='" + Convert.ToString(txtauthor.Text) + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookQuantity='" + Convert.ToString(txtBookQuantity.Text) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@vchAccessionNo='" + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
               
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                    //clear();
                }
            }
        }
        else
        {
            //strQry = "usp_BookDetails @command='checkExist',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookQuantity='" + Convert.ToString(txtBookQuantity.Text) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{

            strQry = "exec [usp_BookDetails] @command='update',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"]) + "',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + Convert.ToString(txtedition.Text.Trim()) + "',@intBook_publication_id='" + Convert.ToString(txtpublication.Text) + "',@intBook_Author_id='" + Convert.ToString(txtauthor.Text) + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookQuantity='" + Convert.ToString(txtBookQuantity.Text) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@vchAccessionNo='" + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
               
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    //clear();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
           // }
        }
    }
    public void clear()
    {
        try
        {
            ddlStandard.ClearSelection();
            ddlBookCategory.ClearSelection();
            txtedition.Text = "";
            txtpublication.Text = "";
            txtauthor.Text = "";
            ddlSubject.ClearSelection();
            txtName.Text = "";
            txtBookPrice.Text = "";
            txtBookQuantity.Text = "";
            txtAccessionNo.Text = "";
            btnSubmit.Text = "Submit";
        }
        catch
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception)
        {
            // return msg;
        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["BookDetailsID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_BookDetails] @command='delete',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["BookDetailsID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
             strQry = "";
             strQry = "exec usp_BookDetails @command='edit',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                ddlSubject.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookLanguage_id"]);
                ddlBookCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCategory_id"]);
                txtedition.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookEdition_id"]);
                txtpublication.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_publication_id"]);
                txtauthor.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_Author_id"]);
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBookDetails_bookName"]);
                txtBookQuantity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookQuantity"]);
                txtBookPrice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookPrice"]);
                txtAccessionNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAccessionNo"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void ddlDetStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGridFilterData();
    }
    protected void fGridFilterData()
    {

        strQry = "usp_BookDetails @command='fGridFilterData',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
    }
    protected void ddlDetSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_BookDetails @command='fGridFilterData',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlDetSubject.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
    }
}