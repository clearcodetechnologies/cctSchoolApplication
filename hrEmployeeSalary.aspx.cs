using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class hrEmployeeSalary : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {

           
            FillddlDesignation();
            FillRole();
       
        }

    }
    

    public void FillddlDesignation()
    {
        try
        {
            strQry = "exec Sp_HrEmployeeSalaryDetails @type='BindDesignation',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");

            

        }
        catch
        {

        }
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBindName();

        string ddlDesignationSelect = ddlDesignation.SelectedValue.ToString();
        strQry = "exec Sp_HrEmployeeSalaryDetails  @type='UserTypeIdShow',@intDesignation='" + Convert.ToString(ddlDesignationSelect) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
           Session["IntUserCode"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);

        }
    }
    public void ddlBindName()
    {
        try
        {
            string ddlDesignationid = ddlDesignation.SelectedValue.ToString();
            strQry = "exec Sp_HrEmployeeSalaryDetails @type='BindEmployeeName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDesignation='" + ddlDesignationid + "'";
            sBindDropDownList(ddlEmployee, strQry, "NAME", "ID");

        }
        catch
        {

        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec Sp_HrEmployeeSalaryDetails @type='FillRole',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

            sBindDropDownList(drpRole, strQry, "vchRole", "intRole_Id");


        }
        catch
        {

        }
    }
    protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        ///-----@intSchool_id,@intInserted_by,@VchMonth
        string roleselect = drpRole.SelectedValue.ToString();
        strQry = "Sp_HrEmployeeSalaryDetails @type='GridShow',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intUserType_id='" + roleselect + "'";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                string InsertedDate = DateTime.Now.ToString("MM/dd/yyyy");




                strQry = "exec Sp_HrEmployeeSalaryDetails  @type='Insert',@intDesignation='" + Convert.ToString(ddlDesignation.SelectedValue.ToString()) + "',@intUserType_id='" + Session["IntUserCode"] + "',@intEmployee='" + Convert.ToString(ddlEmployee.SelectedValue.ToString()) + "',@VchMonth='" + Convert.ToString(ddlmonth.SelectedValue.ToString()) + "',@vchmVchMonthName='" + Convert.ToString(ddlmonth.SelectedItem.ToString()) + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@Inserted_date='" + InsertedDate + "',@InseretIP='" + GetSystemIP() + "'";

                int str = (sExecuteQuery(strQry));
                if (str != -1)
                {
                    string display = "Record Saved Successfully!!";
                    MessageBox(display);
                    Clear();

                }
            }
            else
            {
                strQry = "";
                                                                                                                                          ///////////////values (@intDesignation,@intUserType_id,@intEmployee,@VchMonth,@vchmVchMonthName,@intSchool_id,@intInserted_by,@Inserted_date,@InseretIP,1)                                            
                strQry = "exec Sp_HrEmployeeSalaryDetails  @type='Update',@intEmployeeSalaryId='" + Session["EmployeeSalaryId"] + "',@intUserType_id='" + Session["IntUserCode"] + "',@intDesignation='" + Convert.ToString(ddlDesignation.SelectedValue.ToString()) + "',@intEmployee='" + Convert.ToString(ddlEmployee.SelectedValue.ToString()) + "',@intSchool_id='" + Session["School_Id"] + "',@VchMonth='" + Convert.ToString(ddlmonth.SelectedValue.ToString()) + "',@vchmVchMonthName='" + Convert.ToString(ddlmonth.SelectedItem.ToString()) + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    
                    btnSubmit.Text = "Submit";
                    //fGrid();
                    Clear();
                }
            }
        }
        catch
        {
        }

    }

    protected void Clear()
    {
        ddlDesignation.ClearSelection();
        ddlEmployee.ClearSelection() ;
        ddlmonth.ClearSelection();
        
        
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["id"] = id;
            //intDelete_by,DeleteIP
            //PayHead_Id= @PayHead_Id and intInserted_by=@intInserted_by 
            strQry = "exec  Sp_HrEmployeeSalaryDetails  @type='Delete',@intDelete_by='" + Convert.ToString(Session["User_id"]) + "',@DeleteIP='" + GetSystemIP() + "',@intEmployeeSalaryId='" + Convert.ToString(id) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                string roleselect = drpRole.SelectedValue.ToString();
                strQry = "Sp_HrEmployeeSalaryDetails @type='GridShow',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intUserType_id='" + roleselect + "'";
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
        }
        catch
        {

        } 
    
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        strQry = "";
        Session["EmployeeSalaryId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);

        strQry = "exec Sp_HrEmployeeSalaryDetails  @type='Edit',@intEmployeeSalaryId='" + Convert.ToString(Session["EmployeeSalaryId"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {


            ddlDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDesignation"]);
            ddlBindName();
            ddlEmployee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmployee"]);



            Session["EmployeeSalaryId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmployeeSalaryId"]);
            TBC.ActiveTabIndex = 1;
            btnSubmit.Text = "Update";




        }
        
    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
          try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
            string roleselect = drpRole.SelectedValue.ToString();
            strQry = "Sp_HrEmployeeSalaryDetails @type='GridShow',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intUserType_id='" + roleselect + "'";
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
        catch
        {

        }
    }
}