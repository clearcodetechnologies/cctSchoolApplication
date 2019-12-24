using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

using System.Web.UI.WebControls;


public partial class hr_EmployeeSalarySlip : DBUtility
{
    

    string strQry = "";
    DataSet dsObj;
    string sConStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel50.Visible = false;
        if (!IsPostBack)
        {

            FillddlDesignation();
            ddlBindName();
            //fGrid();

        }
    }

    public void FillddlDesignation()
    {
        try
        {
            strQry = "exec Sp_HrEmployeeSalarySlip @type='BindDesignation',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "'";
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
            strQry = "exec Sp_HrEmployeeSalarySlip @type='BindEmployeeName',@intInserted_by='" + Session["User_id"] + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDesignation='" + ddlDesignationid + "'";
            sBindDropDownList(ddlEmployee, strQry, "NAME", "ID");

        }
        catch
        {

        }
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string ddlDesignationid = ddlDesignation.SelectedValue.ToString();
            strQry = "exec Sp_HrEmployeeSalarySlip @type='BindEmployeeName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDesignation_Id='" + ddlDesignationid + "'";
            sBindDropDownList(ddlEmployee, strQry, "NAME", "ID");


            strQry = "exec Sp_HrEmployeeSalarySlip  @type='UserTypeIdShow',@intDesignation_Id='" + Convert.ToString(ddlDesignationid) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {


                Session["UserIdComan"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);



            }

        }
        catch
        {

        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["MonthSelect"] = ddlmonth.SelectedValue.ToString();
        Session["MonthSelectMonth"] = ddlmonth.SelectedItem.ToString();
        using (SqlConnection con = new SqlConnection(sConStr))
        {
            Panel50.Visible = true;
            strQry = "Sp_HrEmployeeSalarySlip @type='GridShow',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@VchMonth='" + Convert.ToString(Session["MonthSelect"]) + "',@intUserType='" + Convert.ToString(Session["UserIdComan"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblemployename.Text = Convert.ToString(dsObj.Tables[0].Rows[0][3].ToString());
                lbldepartment.Text = Convert.ToString(dsObj.Tables[0].Rows[0][2].ToString());
                lblDesignation.Text = Convert.ToString(dsObj.Tables[0].Rows[0][7].ToString());

                lblbasicamount.Text = Convert.ToString(dsObj.Tables[0].Rows[0][6].ToString());
                lblhraamount.Text = Convert.ToString(dsObj.Tables[0].Rows[1][6].ToString());
                lblCONVEYANCEAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[2][6].ToString());
                lblEsiAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[3][6].ToString());
                lblloanAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[4][6].ToString());
                lblPtaxAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[5][6].ToString());
                lblTsdAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[6][6].ToString());
                lblmonth.Text = Session["MonthSelectMonth"].ToString();
                
               lblearningamount.Text = Convert.ToString(Convert.ToInt32(lblbasicamount.Text) + Convert.ToInt32(lblhraamount.Text) + Convert.ToInt32(lblCONVEYANCEAmount.Text));
               lbltotalAmountdeduction.Text = Convert.ToString(Convert.ToInt32(lblEsiAmount.Text) + Convert.ToInt32(lblloanAmount.Text) + Convert.ToInt32(lblPtaxAmount.Text) + Convert.ToInt32(lblTsdAmount.Text));
                
               lblNetPayAmount.Text=Convert.ToString(Convert.ToInt32(lblearningamount.Text)-Convert.ToInt32(lbltotalAmountdeduction.Text));
                
                
              // amount in word code//////
              lblamountinwordnotshow.Text = Convert.ToString(Convert.ToInt32(lblearningamount.Text) - Convert.ToInt32(lbltotalAmountdeduction.Text));

              lblamountinwordnotshow.Visible = false;

              string Inserted_datee = DateTime.Now.ToString("MM/dd/yyyy");
              lbldate.Text = Inserted_datee.ToString();


              Panel50.Visible = true;
              lblwordamount.Text=  changeToWords(lblamountinwordnotshow.Text);


            }
            else
            {

               
            }
        }
    }

    //protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //     try
    //    {
    //        grvDetail.PageIndex = e.NewPageIndex;
    //        strQry = "Sp_HrEmployeeSalarySlip @type='GridShow',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@VchMonth='" + Convert.ToString(Session["MonthSelect"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            grvDetail.DataSource = dsObj;
    //            grvDetail.DataBind();

    //        }
    //        else
    //        {
    //            grvDetail.DataSource = dsObj;
    //            grvDetail.DataBind();

    //        }
    //    }
    //    catch
    //    {

    //    }

    //}


    public String changeToWords(String numb)
    {
        String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
        //String endStr = ("");
        try
        {
            int decimalPlace = numb.IndexOf(".");
            if (decimalPlace > 0)
            {
                wholeNo = numb.Substring(0, decimalPlace);
                points = numb.Substring(decimalPlace + 1);
                if (Convert.ToInt32(points) > 0)
                {
                    andStr = ("and ");// just to separate whole numbers from points/Rupees
                    pointStr = ("Paisa");

                }
            }
            val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, translateWholeNumber(points).Trim(), pointStr);
        }
        catch
        {
            ;
        }
        return val;
    }

    private String translateWholeNumber(String number)
    {
        string word = "";
        try
        {
            bool beginsZero = false;//tests for 0XX
            bool isDone = false;//test if already translated
            double dblAmt = (Convert.ToDouble(number));
            //if ((dblAmt > 0) && number.StartsWith("0"))

            if (dblAmt > 0)
            {//test for zero or digit zero in a nuemric
                beginsZero = number.StartsWith("0");
                int numDigits = number.Length;
                int pos = 0;//store digit grouping
                String place = "";//digit grouping name:hundres,thousand,etc...
                switch (numDigits)
                {
                    case 1://ones' range
                        word = ones(number);
                        isDone = true;
                        break;
                    case 2://tens' range
                        word = tens(number);
                        isDone = true;
                        break;
                    case 3://hundreds' range
                        pos = (numDigits % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4://thousands' range
                    case 5:
                    case 6:
                        pos = (numDigits % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7://millions' range
                    case 8:
                    case 9:
                        pos = (numDigits % 7) + 1;
                        place = " Million ";
                        break;
                    case 10://Billions's range
                        pos = (numDigits % 10) + 1;
                        place = " Billion ";
                        break;
                    //add extra case options for anything above Billion...
                    default:
                        isDone = true;
                        break;
                }
                if (!isDone)
                {//if transalation is not done, continue...(Recursion comes in now!!)
                    word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                    //check for trailing zeros
                    if (beginsZero) word = " and " + word.Trim();
                }
                //ignore digit grouping names
                if (word.Trim().Equals(place.Trim())) word = "";
            }
        }
        catch
        {
            ;
        }
        return word.Trim();
    }

    private String tens(String digit)
    {
        int digt = Convert.ToInt32(digit);
        String name = null;
        switch (digt)
        {
            case 10:
                name = "Ten";
                break;
            case 11:
                name = "Eleven";
                break;
            case 12:
                name = "Twelve";
                break;
            case 13:
                name = "Thirteen";
                break;
            case 14:
                name = "Fourteen";
                break;
            case 15:
                name = "Fifteen";
                break;
            case 16:
                name = "Sixteen";
                break;
            case 17:
                name = "Seventeen";
                break;
            case 18:
                name = "Eighteen";
                break;
            case 19:
                name = "Nineteen";
                break;
            case 20:
                name = "Twenty";
                break;
            case 30:
                name = "Thirty";
                break;
            case 40:
                name = "Fourty";
                break;
            case 50:
                name = "Fifty";
                break;
            case 60:
                name = "Sixty";
                break;
            case 70:
                name = "Seventy";
                break;
            case 80:
                name = "Eighty";
                break;
            case 90:
                name = "Ninety";
                break;
            default:
                if (digt > 0)
                {
                    name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                }
                break;
        }
        return name;
    }

    private String ones(String digit)
    {
        int digt = Convert.ToInt32(digit);
        String name = "";
        switch (digt)
        {
            case 1:
                name = "One";
                break;
            case 2:
                name = "Two";
                break;
            case 3:
                name = "Three";
                break;
            case 4:
                name = "Four";
                break;
            case 5:
                name = "Five";
                break;
            case 6:
                name = "Six";
                break;
            case 7:
                name = "Seven";
                break;
            case 8:
                name = "Eight";
                break;
            case 9:
                name = "Nine";
                break;
        }
        return name;
    }
}