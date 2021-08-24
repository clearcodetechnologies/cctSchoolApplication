using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frmTeachLeavAppro :DBUtility
{
    int outval, appval,teachappresul;
    int resultval;
    string strQry = string.Empty;
    string appresult;
    SqlDataAdapter daObj = new SqlDataAdapter();
    DataSet dsObj = new DataSet();
    string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
            try
            {
             
                checksession();
                geturl();

                TabContainer1.ActiveTabIndex = 0;
                fillGrid();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
    protected void fillGrid()
    {
        try
        {
            filgrisapp();
         filgriTeachsapp();
        }
        catch (Exception ex)
        {
        }
    }

    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillGrid();
    
    
    }

    protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        fillGrid();


    }

    protected void GridView3_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        fillGrid();


    }
    protected void GridViewRepo_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRepo.PageIndex = e.NewPageIndex;
        fillGrid();
    
    
    }
        protected void  filgriTeachsapp()
            {
                if (Convert.ToInt32(Session["UserType_id"]) == 5)
                {
                    DropDownList1.Visible = true; 
                  
                }
                else if (Convert.ToInt32(Session["UserType_id"]) == 3)
                {
                    string query1 = "Execute dbo.usp_Leave @command='TeachLeaveReport' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
                    outval = sBindGrid(GridViewRepo, query1);
                    GridViewRepo.Visible = true;
                }
                
            }
      protected void  filgrisapp()
            {

                if (Convert.ToInt32(Session["UserType_id"]) == 5)
                {
                    DropDownList1.Visible = true;
                    drop1.Visible = true;
                    string query3="exec [usp_usermaster] @command='fillRole',@intSchool_id='" + Session["School_id"] + "'";
                    daObj = new SqlDataAdapter(query3 , strCOn);
                    daObj.Fill(dsObj);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        drop1.DataTextField = "vchRole";
                        drop1.DataValueField = "intRole_Id";

                        drop1.DataSource = dsObj;
                        drop1.DataBind();
                        drop1.Items.Insert(0, "---Select Role----");



                        DropDownList1.DataTextField = "vchRole";
                        DropDownList1.DataValueField = "intRole_Id";

                        DropDownList1.DataSource = dsObj;
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, "---Select Role----");
                    }
                    else
                    {
                        drop1.DataSource = dsObj;
                        drop1.DataBind();
                        drop1.Items.Insert(0, "---Select Role----");


                        DropDownList1.DataSource = dsObj;
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, "---Select Role----");
                    }

                    //string query2 = "Execute dbo.usp_Leave @command='TeacherLeave',@intSchool_id='" + Session["School_id"] + "' ";

                    //outval = sBindGrid(GridView2, query2);
                }

                else if (Convert.ToInt32(Session["UserType_id"]) == 3)
                {
                    Label8.Visible = false;
                    drop1.Visible = false;
                    Label9.Visible = false;
                    DropDownList1.Visible = false;
                    string query1 = "Execute dbo.usp_Leave @command='TeachLeaveApprorequest' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
                    outval = sBindGrid(GridView1, query1);
                }
            }

    protected void OnRowSelected()
    { }
    protected void Privioustval(object sender, EventArgs e)
    {
        try
        {
            TabPanel2.Visible = true;
            TabPanel1.Visible = false;
            filgrisapp();
         
        }
        catch( Exception ex)
        {
        
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      
        //TabContainer1.Focus();
        TabPanel2.Visible = false;
        TabPanel1.Visible = true;
     
        TabContainer1.ActiveTabIndex = 1;
        GridView1.Visible = false;
        GridViewRepo.Visible = true;
        //Button1.Visible = true;


        try

        {
            int Applicationid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["Applicationid"] = GridView1.DataKeys[e.NewEditIndex].Value;
            LblApplication.Text = Convert.ToString(Session["Applicationid"]);
            dsObj = new DataSet();

            strQry = "exec [usp_Leave] @command='TeachApproveapp',@intLeaveApplocation_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Label6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                leaveType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TypeOfLeave"]);
                FromLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy");
                ToLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy");
                TotalLbl.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalLeaveDays"]);
                ViewState["StudentId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                string script = "funcswitchtab()";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }
        catch (Exception Ex)
        {

            throw;
        }
      
    }



    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {

        //TabContainer1.Focus();
        TabPanel2.Visible = false;
        TabPanel1.Visible = true;

        TabContainer1.ActiveTabIndex = 1;
        GridView1.Visible = false;
        GridViewRepo.Visible = true;
        //Button1.Visible = true;


        try
        {
            int Applicationid = Convert.ToInt32(GridView2.DataKeys[e.NewEditIndex].Value);
            Session["Applicationid"] = GridView2.DataKeys[e.NewEditIndex].Value;
            LblApplication.Text = Convert.ToString(Session["Applicationid"]);
            dsObj = new DataSet();

            strQry = "exec [usp_Leave] @command='TeacherLeaveApproval',@intLeaveApplocation_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Label6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                leaveType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TypeOfLeave"]);
                FromLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy");
                ToLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy");
                TotalLbl.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalLeaveDays"]);
                // ViewState["StudentId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                string script = "funcswitchtab()";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }
        catch (Exception Ex)
        {

            throw;
        }

    }
  
    


    protected void Submitval(object sender, EventArgs e)
   
    {
        try
        {
            int appval = Convert.ToInt32(RadioApproved.SelectedItem.Value);

            if (appval == 2)
            {
                appresult = "Rejected";
                teachappresul = 2;

            }
            else if (appval == 1)
            {
                appresult = "Approved";

            }
            string Appresonval = Resontxt.Text;
            string LblAppli = Convert.ToString(LblApplication.Text);
            string ipval = GetSystemIP();
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            if (Convert.ToInt32(Session["UserType_id"]) == 5)
            {
                                         
                  string instrquery1 = "Execute dbo.usp_Leave @command='UpdateTeachapproval1',@vchAdminRemark='" + Convert.ToString(Appresonval).Trim() + "',@bitAdminApproval='" + appval + "',@dtAdminApproval='" + insertdt + "',@intLeaveApplocation_id='" + LblAppli + "',@UpdateIP='" + ipval + "',@dtUpdateDate='" + insertdt + "',@intUpdateBy='" + Session["User_id"] + "'";
                
                int str = sExecuteQuery(instrquery1);
                if (str != -1)
                {
                    //Added By Tushar On 04/02/2015
                    //strQry = "exec usp_getAttendance @type='StudentLeaveEntry',@intStudent_id='" + Convert.ToString(ViewState["StudentId"]) + "',@FrmDt='" + Convert.ToDateTime(FromLbl.Text).ToString("MM/dd/yyyy") + "',@EndDt='" + Convert.ToDateTime(ToLbl.Text).ToString("MM/dd/yyyy") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    //if (sExecuteQuery(strQry) == -1)
                    //{
                    //    MessageBox("Problem Found");
                    //}

                    //End


                    //code by Nikhil
                    // int valtest = Convert.ToInt32(value);
                    if (appresult == "Approved")
                    {
                        string query = "select intUser_id, intUserType_id ,dtFrom_date , intTotalDays  from tblLeaveRequest where bitAdminApproval=1 and intUserType_id=3 and intLeaveApplocation_id ='" + LblAppli + "' ";
                        dsObj = sGetDataset(query);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            string intUser_id, intUserType_id, dtFrom_date, intTotalDays, date;

                            intUser_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
                            intUserType_id = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                            dtFrom_date = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtFrom_date"]).ToString("dd/MM/yyyy");
                            intTotalDays = Convert.ToString(dsObj.Tables[0].Rows[0]["intTotalDays"]);
                            date = DateTime.Now.ToString("MM/dd/yyyy");
                            DateTime   date1 = Convert.ToDateTime(dtFrom_date) ;
                            string strDate = Convert.ToDateTime(FromLbl.Text).ToString("MM/dd/yyyy").Replace("-", "/");
                           // strDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
                           
                            for (int i = 1; i <= Convert.ToInt32(intTotalDays); i++)
                            {
                                 string dtdate =Convert.ToDateTime(date1).ToString("MM/dd/yyyy").Replace("-", "/");
                                 string query1 = "exec [usp_getAttendance] @type='UpdateTeacherLeaveInAttendance',@intusertype_id=3, @intUser_id= '" + intUser_id + "',@FrmDt='" + dtdate + "',@intschool_id=1,@intLeaveApplocation_id='" + LblAppli + "' ";
                                 int q = sExecuteQuery(query1);
                                date1 = date1.AddDays(1);
                               
                                
                            }

                        }
                    }

                    string display = "Leave Application " + appresult + "!";
                    MessageBox(display);
                    GridViewRepo.Visible = true;
                    btnSubmin.Visible = true;
                    btnClear.Visible = false;
                    TabContainer1.ActiveTabIndex = 0;
                    TabPanel1.Visible = false;
                    TabContainer1.ActiveTabIndex = 0;
                    TabPanel2.Visible = true;
                    tab2Entry.Visible = true;
                    GridView1.Visible = true;
                    Clear();
                    fillGrid();
                    filgrisapp();



                }
                else
                {

                    MessageBox("Leave Application Failed");
                }
            }


            else if (Convert.ToInt32(Session["UserType_id"]) == 3 )
            {
                string instrquery1 = "Execute dbo.usp_Leave @command='UpdateTeachapproval',@vchTeacherRemark='" + Convert.ToString(Appresonval).Trim() + "',@bitTeacherApproval='" + appval + "',@dtTeacherApproval='" + insertdt + "',@intLeaveApplocation_id='" + LblAppli + "',@UpdateIP='" + ipval + "',@dtUpdateDate='" + insertdt + "',@intUpdateBy='" + Session["User_id"] + "'";


                int str = sExecuteQuery(instrquery1);
                if (str != -1)
                {
                    //Added By Tushar On 04/02/2015
                    //strQry = "exec usp_getAttendance @type='StudentLeaveEntry',@intStudent_id='" + Convert.ToString(ViewState["StudentId"]) + "',@FrmDt='" + Convert.ToDateTime(FromLbl.Text).ToString("MM/dd/yyyy") + "',@EndDt='" + Convert.ToDateTime(ToLbl.Text).ToString("MM/dd/yyyy") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    //if (sExecuteQuery(strQry) == -1)
                    //{
                    //    MessageBox("Problem Found");
                    //}

                    //End


                    string display = "Leave Application " + appresult + "!";
                    MessageBox(display);
                    GridViewRepo.Visible = true;
                    btnSubmin.Visible = true;
                    btnClear.Visible = false;
                    TabContainer1.ActiveTabIndex = 0;
                    TabPanel1.Visible = false;
                    TabContainer1.ActiveTabIndex = 0;
                    TabPanel2.Visible = true;
                    tab2Entry.Visible = true;
                    GridView1.Visible = true;
                    Clear();
                    fillGrid();
                }
                else
                {

                    MessageBox("Leave Application Failed");
                }

            }
        }

        catch (Exception Ex)
        {

            throw;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch
        {
            throw;
        }
    
    }
    public void Clear()
    {
        RadioApproved.ClearSelection();
        Resontxt.Text = "";
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drop1.SelectedValue.ToString() == "3")
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            string query2 = "Execute dbo.usp_Leave @command='TeacherLeave',@intSchool_id='" + Session["School_id"] + "' ";

            outval = sBindGrid(GridView2, query2);
        }
        else if (drop1.SelectedValue.ToString() == "4")
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            string query2 = "Execute dbo.usp_Leave @command='staffLeave',@intSchool_id='" + Session["School_id"] + "' ";

            outval = sBindGrid(GridView2, query2);

        }
        else if (drop1.SelectedValue.ToString() == "1")
        {
            GridView2.Visible = false;
            GridView1.Visible = true;
            string query1 = "Execute dbo.usp_Leave @command='TeachLeaveApprorequest' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            outval = sBindGrid(GridView1, query1);
        }
        else if (drop1.SelectedValue.ToString() == "5")
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            
            string query1 = "Execute dbo.usp_Leave @command='AdminLeave' ,@intSchool_id='" + Session["School_id"] + "'";
            outval = sBindGrid(GridView2, query1);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "3")
        {
            string query1 = "Execute dbo.usp_Leave @command='TeacherLeaveReport',@intSchool_id='" + Session["School_id"] + "' ";

            outval = sBindGrid(GridView3, query1);
        }
        else if (DropDownList1.SelectedValue.ToString() == "4")
        {
            string query1 = "Execute dbo.usp_Leave @command='StaffLeaveReport',@intSchool_id='" + Session["School_id"] + "' ";

            outval = sBindGrid(GridView3, query1);
        }
        else if (DropDownList1.SelectedValue.ToString() == "1")
        {
            GridView3.Visible = false;
            string query1 = "Execute dbo.usp_Leave @command='TeachLeaveReport' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            outval = sBindGrid(GridViewRepo, query1);
            GridViewRepo.Visible = true;
        }
        else if(DropDownList1.SelectedValue.ToString()=="5")
        {

        }
    }
}