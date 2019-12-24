using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

using System.Web.UI.WebControls;


public partial class hr_From16 : DBUtility
{


    string strQry = "";
    DataSet dsObj;
    string sConStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel50.Visible = false;
        if (!IsPostBack)
        {
            Panel50.Visible = false;

            FillddlDesignation();

            ddlBindName();

            geturl();



        }
    }


    public void FillddlDesignation()
    {
        try
        {
            strQry = "exec Sp_HrEmployeeForm16 @type='BindDesignation',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");

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
            strQry = "exec Sp_HrEmployeeForm16 @type='BindEmployeeName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDesignation_Id='" + ddlDesignationid + "'";
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

        strQry = "exec Sp_HrEmployeeForm16  @type='UserTypeIdShow',@intDesignation_Id='" + Convert.ToString(ddlDesignationSelect) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {


            Session["UserIdComan"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);



        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string EMPLOYEENAMESELECT = ddlEmployee.SelectedValue.ToString();
            Panel50.Visible = true;
            strQry = "Sp_HrEmployeeForm16 @type='Form16(a)',@intSchool_id='" + Session["School_Id"] + "',@intUserType='" + Convert.ToString(Session["UserIdComan"]) + "'";
            
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblemployename.Text = Convert.ToString(dsObj.Tables[0].Rows[0][3].ToString());

                string Basic= Convert.ToString(dsObj.Tables[0].Rows[0][6].ToString());
                string Hra=  Convert.ToString(dsObj.Tables[0].Rows[1][6].ToString());
                string Conveyance=  Convert.ToString(dsObj.Tables[0].Rows[2][6].ToString());
                string Esi=  Convert.ToString(dsObj.Tables[0].Rows[3][6].ToString());
                string Loan=  Convert.ToString(dsObj.Tables[0].Rows[4][6].ToString());
                string Ptx=  Convert.ToString(dsObj.Tables[0].Rows[5][6].ToString());
                string Tsd = Convert.ToString(dsObj.Tables[0].Rows[6][6].ToString());


                ///Addtion amount////
               // int TOTALAMOUNT = Convert.ToInt32(Basic) + Convert.ToInt32(Hra) + Convert.ToInt32(Conveyance) + Convert.ToInt32(Esi) + Convert.ToInt32(Loan) + Convert.ToInt32(Ptx) + Convert.ToInt32(Tsd);
                int TOTALAMOUNT = Convert.ToInt32(Basic) + Convert.ToInt32(Hra) + Convert.ToInt32(Conveyance);



                lblsalaeryprovision.Text = (TOTALAMOUNT * 12).ToString();

                lblTotal.Text = lblsalaeryprovision.Text;
                lablBalance12.Text = lblsalaeryprovision.Text;

               //////Deduction Amount//////
              int Deduction = Convert.ToInt32(Esi) + Convert.ToInt32(Loan) + Convert.ToInt32(Ptx) + Convert.ToInt32(Tsd);

              lbltax.Text = (Deduction * 12+100).ToString();
              lblAggregate.Text = (Deduction * 12 + 100).ToString();

              int Incomechargeableasub = Convert.ToInt32(lblAggregate.Text.ToString());
              int Incomechargeableadd = Convert.ToInt32(lblsalaeryprovision.Text.ToString());

              ///////incomechargeable///////
              lblIncomechargeable.Text = Convert.ToUInt32(Incomechargeableadd-Incomechargeableasub).ToString();
           

              lblGrandTotal.Text = Convert.ToUInt32(Incomechargeableadd - Incomechargeableasub).ToString();
              lblTotalIncome.Text = Convert.ToUInt32(Incomechargeableadd - Incomechargeableasub).ToString();

            ////////Page3///////////////
           
              Label17.Text = TOTALAMOUNT.ToString();
              Label23.Text = TOTALAMOUNT.ToString();
              Label50.Text = TOTALAMOUNT.ToString();
              Label56.Text = TOTALAMOUNT.ToString();
              Label62.Text = TOTALAMOUNT.ToString();
              Label68.Text = TOTALAMOUNT.ToString();
              Label74.Text = TOTALAMOUNT.ToString();
              Label80.Text = TOTALAMOUNT.ToString();
              Label86.Text = TOTALAMOUNT.ToString();
              Label92.Text = TOTALAMOUNT.ToString();
              Label104.Text = TOTALAMOUNT.ToString();
              Label110.Text = TOTALAMOUNT.ToString();
             Label99.Text = lblsalaeryprovision.Text;
              

             Label19.Text = TOTALAMOUNT.ToString();
             Label27.Text = TOTALAMOUNT.ToString();
             Label52.Text = TOTALAMOUNT.ToString();
             Label58.Text = TOTALAMOUNT.ToString();
             Label64.Text = TOTALAMOUNT.ToString();
             Label70.Text = TOTALAMOUNT.ToString();
             Label76.Text = TOTALAMOUNT.ToString();
             Label82.Text = TOTALAMOUNT.ToString();
             Label88.Text = TOTALAMOUNT.ToString();
             Label94.Text = TOTALAMOUNT.ToString();
             Label106.Text = TOTALAMOUNT.ToString();
             Label112.Text = TOTALAMOUNT.ToString();
             Label101.Text = lblsalaeryprovision.Text;

             
             Label103.Text = (Deduction).ToString();
             Label47.Text = (Deduction+100).ToString();
             Label53.Text = (Deduction).ToString();
             Label59.Text = (Deduction).ToString();
             Label65.Text = (Deduction).ToString();
             Label71.Text = (Deduction).ToString();
             Label77.Text = (Deduction).ToString();
             Label83.Text = (Deduction).ToString();
             Label89.Text = (Deduction).ToString();
             Label95.Text = (Deduction).ToString();
             Label107.Text = (Deduction).ToString();
             Label113.Text = (Deduction).ToString();
             Label102.Text = (Deduction * 12 + 100).ToString();


                /////21,48,54,60,66,72,78,84,90,96,108,114,133

             Label60.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label66.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label72.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label78.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label84.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label90.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label108.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label114.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label96.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label21.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label54.Text = Convert.ToInt32(TOTALAMOUNT - Deduction).ToString();
             Label48.Text = Convert.ToInt32(TOTALAMOUNT - Deduction+100).ToString();
             Label133.Text = (Convert.ToInt32(Label60.Text) * 12 + 100).ToString();







             Label134.Text = lblsalaeryprovision.Text;
             Label135.Text = (Deduction * 12 + 100).ToString();
             Label136.Text = (Convert.ToInt32(Label60.Text) * 12 + 100).ToString();

            }
            
            
            
        }
    
        catch
        {

        }







    }
}

  
