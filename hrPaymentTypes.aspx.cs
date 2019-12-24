using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class hrPaymentTypes : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                   // FillBuilding();
                    FillGrid();
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\frmlogin.aspx", false);
            }
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec Sp_hrPayableTypeName @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec Sp_hrPayableTypeName  @type='CheckSaveExist',@VchPayableTypeName='" + Convert.ToString(txtPayableName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec Sp_hrPayableTypeName  @type='Insert',@VchPayableTypeName='" + Convert.ToString(txtPayableName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");

                    txtPayableName.Text = "";
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
               
                strQry = "exec Sp_hrPayableTypeName  @type='Update',@IntPayableId='" + Session["PayableId"] + "',@VchPayableTypeName='" + Convert.ToString(txtPayableName.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");

                    txtPayableName.Text = "";
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
            }
        }
        catch
        {

        }







    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["WingId"] = id;



            strQry = "exec Sp_hrPayableTypeName  @type='Delete',@intDelete_by='" + Session["User_id"] + "',@DeleteIP='" + GetSystemIP() + "', @deleteid='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";

            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
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
            Session["PayableId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            //int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            //ViewState["WingId"] = id;
            strQry = "exec Sp_hrPayableTypeName  @type='Edit',@PayId='" + Convert.ToString(Session["PayableId"]) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                txtPayableName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchPayableTypeName"]);

                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
            FillGrid();
        }
        catch
        {

        }
    }
}