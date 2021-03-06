using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmTrashBookCategory : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "[usp_TrashLibrary] @command='SelectCategory',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();           
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["CategoryID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_TrashLibrary] @command='EnableCategory',@intCategory_id='" + Convert.ToString(Session["CategoryID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Category Enable Successfully!");
            }
        }
        catch
        {

        }
    }
}