using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmDueMonth : DBUtility
{
    string strDate = string.Empty;
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string StudentId = Convert.ToString(Request.QueryString["StudentId"]);


        
        //strQry = "usp_GenderWiseAttendance  @command='selectName',@fromDate='" + strDate.Trim() + "'";
        dsObj = (DataSet)Session["rptStudentdetail"];
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdDet.DataSource = dsObj;
            grdDet.DataBind();
        }

    }
}