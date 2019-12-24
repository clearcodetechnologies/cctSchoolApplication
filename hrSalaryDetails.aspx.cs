using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class hrSalaryDetails : DBUtility
{
    char ch = Convert.ToChar(130);

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

                    FillRole();
                    FillddlDesignation();
                    ddlBindPayheadMaste();
                    ddlBindName();

                    geturl();
                    Clear();

                    Label5.Visible = false;
                    ddlPayheadMaster.Visible = false;
                    Label2.Visible = false;
                    txtUnit.Visible = false;
                    Label3.Visible = false;
                    Label3.Visible = false;
                    ddlType.Visible = false;


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






    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec Sp_HrSalaryDetails @type='FillRole',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

            sBindDropDownList(drpRole, strQry, "vchRole", "intRole_Id");


        }
        catch
        {

        }
    }


    public void FillddlDesignation()
    {
        try
        {
            strQry = "exec Sp_HrSalaryDetails @type='BindDesignation',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");

        }
        catch
        {

        }
    }


    public void ddlBindPayheadMaste()
    {
        try
        {
            strQry = "exec Sp_HrSalaryDetails @type='BindPayheadMaste',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlPayheadMaster, strQry, "vchPayHeadName", "PayHead_Id");

        }
        catch
        {

        }
    }



    public void ddlBindName()
    {
        try
        {
            string ddlDesignationid = ddlDesignation.SelectedValue.ToString();
            strQry = "exec Sp_HrSalaryDetails @type='BindEmployeeName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDesignation_Id='" + ddlDesignationid + "'";
            sBindDropDownList(ddlEmployee, strQry, "NAME", "ID");

        }
        catch
        {

        }
    }



    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBindName();


        string ddlDesignationSelect = ddlDesignation.SelectedValue.ToString();

        strQry = "exec Sp_HrSalaryDetails  @type='UserTypeIdShow',@intDesignation_Id='" + Convert.ToString(ddlDesignationSelect) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {


            Session["UserIdComan"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);



        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {




        try
        {
            if (btnSubmit.Text == "Submit")
            {

                foreach (GridViewRow Vrow in grvDetailAmout.Rows)
                {
                    CheckBox CheckBox1 = (CheckBox)Vrow.FindControl("CheckBox1");


                    if (CheckBox1.Checked == true)
                    {


                        Label payhedid = (Label)Vrow.FindControl("lblPayHead_Id");
                        TextBox Unitamount = (TextBox)Vrow.FindControl("txtvchUnit");
                        DropDownList Type = (DropDownList)Vrow.FindControl("ddltypeAddition");






                        string InsertedDate = DateTime.Now.ToString("MM/dd/yyyy");


                        strQry = "exec Sp_HrSalaryDetails  @type='Insert',@UserType_id='" + Session["UserIdComan"] + "',@intDesignation_Id='" + ddlDesignation.SelectedValue.ToString() + "',@intEmployee='" + Convert.ToString(ddlEmployee.SelectedValue.ToString()) + "',@intPayhead='" + payhedid.Text.ToString() + "',@vchUnit='" + Unitamount.Text.ToString() + "',@intType='" + Type.SelectedValue.ToString() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@Inserted_date='" + InsertedDate + "',@InseretIP='" + GetSystemIP() + "'";
                        if (sExecuteQuery(strQry) != -1)
                        {
                            MessageBox("Record Saved Successfully!");


                        }
                    }


                }
            }



            else
            {


                Label5.Visible = true;
                ddlPayheadMaster.Visible = true;
                Label2.Visible = true;
                txtUnit.Visible = true;
                Label3.Visible = true;
                Label3.Visible = true;
                ddlType.Visible = true;
                grvDetailAmout.Visible = false;


                strQry = "";
                strQry = "exec Sp_HrSalaryDetails  @type='Update',@IntSalaryId='" + Session["IntSalaryId"] + "',@UserType_id='" + Session["UserIdComan"] + "',@intDesignation_Id='" + Convert.ToString(ddlEmployee.SelectedValue.ToString()) + "',@intEmployee='" + Convert.ToString(ddlEmployee.SelectedValue.ToString()) + "',@intPayhead='" + ddlPayheadMaster.SelectedValue.ToString() + "',@vchUnit='" + txtUnit.Text.ToString() + "',@intType='" + ddlType.SelectedValue.ToString() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");

                    btnSubmit.Text = "Submit";



                }
            }
        }



        catch
        {
        }


    }
    protected void Clear()
    {
        ddlDesignation.SelectedValue = "";
        ddlEmployee.SelectedValue = "";
        ddlPayheadMaster.SelectedValue = "";
        ddlType.SelectedValue = "";
        // txtUnit.Text = "";


    }

    protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
    {

        string roleselect = drpRole.SelectedValue.ToString();
        strQry = "Sp_HrSalaryDetails @type='GridShow',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@UserType_id='" + roleselect + "'";
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




        string roleselect1 = drpRole.SelectedValue.ToString();
        strQry = "Sp_HrSalaryDetails @type='GridShowAmount',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@UserType_id='" + roleselect1 + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetailAmout.DataSource = dsObj;
            grvDetailAmout.DataBind();

        }
        else
        {
            grvDetailAmout.DataSource = dsObj;
            grvDetailAmout.DataBind();

        }

    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {

        Label5.Visible = true;
        ddlPayheadMaster.Visible = true;
        Label2.Visible = true;
        txtUnit.Visible = true;
        Label3.Visible = true;
        Label3.Visible = true;
        ddlType.Visible = true;
        grvDetailAmout.Visible = false;


        strQry = "";
        Session["IntSalaryId"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);

        strQry = "exec Sp_HrSalaryDetails  @type='Edit',@IntSalaryId='" + Convert.ToString(Session["IntSalaryId"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            FillddlDesignation();
            ddlDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDesignation"]);
            ddlBindName();
            ddlEmployee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmployee"]);

            ddlPayheadMaster.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intPayhead"]);

            txtUnit.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchUnit"]);
            ddlType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intType"]);

            Session["IntSalaryId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intType"]);
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
            strQry = "Sp_HrSalaryDetails @type='GridShow',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@UserType_id='" + roleselect + "'";
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
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["id"] = id;
            //intDelete_by,DeleteIP
            //PayHead_Id= @PayHead_Id and intInserted_by=@intInserted_by 
            strQry = "exec  Sp_HrSalaryDetails  @type='Delete',@intDelete_by='" + Convert.ToString(Session["User_id"]) + "',@DeleteIP='" + GetSystemIP() + "',@IntSalaryId='" + Convert.ToString(id) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");

            }
        }
        catch
        {

        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {



            strQry = "Sp_HrSalaryDetails @type='GridShowAmount',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetailAmout.DataSource = dsObj;
                grvDetailAmout.DataBind();

            }
            else
            {
                grvDetailAmout.DataSource = dsObj;
                grvDetailAmout.DataBind();

            }

        }
        catch
        {

        }
    }
}



