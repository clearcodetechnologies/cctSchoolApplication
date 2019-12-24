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

public partial class frmEventMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
           fStandard();
           fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "exec [usp_Mob_Event] @command='Select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        strQry = "exec [usp_Mob_Event] @command='insert',@vchStandard_id='" + Convert.ToString(ddlstd.SelectedValue) + "',@intUser_id='" + Session["User_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intUserType_id='" + Session["UserType_id"] + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@dtRegistrartionStartDate='" + txtregistrationstart.Text + "',@dtRegistrationEndDate='" + txtregEnddate.Text + "',@dtEventStartDate='" + txteventstartdate.Text + "',@dtEventEndDate='" + txteventenddate.Text + "',@vchEventName='" + txtEventname.Text + "',@vchEventFees='" + txtEventfees.Text + "',@vchEventDescription='" + txteventdescription.Text + "'";
        if (sExecuteQuery(strQry) != -1)
        {
            fGrid();
            MessageBox("Event Inserted Successfully!");
            TabContainer1.ActiveTabIndex = 0;
            txtregEnddate.Text = "";
            txtregistrationstart.Text = "";
            ddlstd.ClearSelection();
            txteventstartdate.Text = "";
            txteventenddate.Text = "";
            txtEventname.Text = "";
            txtEventfees.Text = "";
            txteventdescription.Text = "";
        }
    }
           
    protected void fStandard()
    {
        strQry = "usp_DivisionMaster @command='standard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ddlstd.DataTextField = "vchStandard_name";
            ddlstd.DataValueField = "intstandard_id";
            ddlstd.DataSource = dsObj;
            ddlstd.DataBind();
        }
    }
    protected void ddlstd_SelectedIndexChanged(object sender, EventArgs e)
    {
     //strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            
     //     sBindDropDownList(ddlstd, strQry, "vchStandard_name", "intstandard_id");
        
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtregEnddate.Text = "";
        txtregistrationstart.Text = "";
        ddlstd.ClearSelection();
        txteventstartdate.Text = "";
        txteventenddate.Text = "";
        txtEventname.Text = "";
        txtEventfees.Text = "";
        txteventdescription.Text = "";
    }
     
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intEvent_id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_Mob_Event] @command='delete',@intEvent_id='" + Convert.ToString(Session["intEvent_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Standard Deleted Successfully!");
                TabContainer1.ActiveTabIndex = 0;
            } 
        }
        catch
        {

        }
    }


    protected void grvDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGrid();
    }
}
