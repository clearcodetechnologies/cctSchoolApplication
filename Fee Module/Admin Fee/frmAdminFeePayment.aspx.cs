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

public partial class frmAdminFeePayment : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet tempds = new DataSet();
    DataSet dsTransport = new DataSet();
    int loopcount = 0;
    int loop = 0;
    decimal a = 0, b = 0, c = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FillStudent();
            fGrid();
            //FillFeeTypeNew();
            EnabDisb(false);
        }
    }

    public void EnabDisb(bool value)
    {
        lblcheque.Visible = value;
        txtChequeNo.Visible = value;
        lblbank.Visible = value;
        txtBankName.Visible = value;
    }
    //public void FillFeeTypeNew()
    //{

    //    try
    //    {
    //        strQry = "";
    //        strQry = "exec usp_Fee_master @command='GetFeetYPE',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //        sBindDropDownList(ddlFeeType, strQry, "Fee_Name", "intFeetype_id");
    //        ddlFeeType.SelectedValue = "1";

    //    }
    //    catch (Exception ex)
    //    {


    //    }
    //}


    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["DataTable"] = null;
            GridView1.DataSource = ViewState["DataTable"];
            GridView1.DataBind();

            DateTime dtfromdate = Convert.ToDateTime(txtFromDate.Text);
            int fromdate = dtfromdate.Day;

            DateTime dttodate =Convert.ToDateTime(txtToDate.Text);
            int toMonth = dttodate.Month;
            int toYear = dttodate.Year;

            DateTime dtnewdate = new DateTime(toYear, toMonth, fromdate);
            string todate = Convert.ToDateTime(dtnewdate).ToString("dd/MM/yyyy");
            txtToDate.Text = todate.Replace("-", "/");



            strQry = "usp_Addfee @command='selectConcessionDetails',@intStudent_id='" + txtStudentId.Text + "',@dtdate='" + Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") + "'";

            ds = sGetDataset(strQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["vchConcession_per"] = ds.Tables[0].Rows[0]["vchConcession_per"];
                ViewState["vchConcession_amt"] = ds.Tables[0].Rows[0]["vchConcession_amt"];
            }

            


            strQry = "usp_Addfee @command='GetAllFeesStandardWise',@intstandard_id='" + txtStanderd.Text + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@dtfrom_date='" + Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") + "',@dtto_date='" + Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + "'";
            ds1 = sGetDataset(strQry);
            for(int i=0; ds1.Tables[0].Rows.Count >i ; i++)
            {
                if (Convert.ToString(ds1.Tables[0].Rows[i]["frequency"]) == "12")
                {      
                    BindItem(txtStanderd.Text, Convert.ToString(ds1.Tables[0].Rows[i]["intFeemaster_id"]), Convert.ToString(Session["School_id"]));                        
                }
                else
                {
                    strQry = "usp_Addfee @command='CheckRecordsExits',@intStudent_id='" + txtStudentId.Text + "',@intFeemaster_id='" + ds1.Tables[0].Rows[i]["intFeemaster_id"] + "'";
                    ds = sGetDataset(strQry);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        BindItem(txtStanderd.Text, Convert.ToString(ds1.Tables[0].Rows[i]["intFeemaster_id"]), Convert.ToString(Session["School_id"]));
                    }
                }
                
            }

            //Check Transport Fee
            strQry = "usp_Addfee @command='CheckTransportFee',@intStudent_id='" + txtStudentId.Text + "'";
            ds = sGetDataset(strQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int fromMonth = dtfromdate.Month;
                int month = 0;

                int monthdiff = GetMonthDifference(Convert.ToDateTime(dtfromdate), Convert.ToDateTime(dttodate));
                string[] GetMonths = GetMonthsBetweenDates(Convert.ToDateTime(dtfromdate), monthdiff + 1);

                int year = dtfromdate.Year;
                for (int i = 0; monthdiff >= i; i++)
                {
                    month = (fromMonth + i);
                    if (month > 12)
                    {
                        year = dtfromdate.Year + 1;
                        month = (fromMonth + i) - 12;
                    }
                    DateTime dtdate = new DateTime(year, month, fromdate);
                    string dtdate1 = Convert.ToDateTime(dtdate).ToString("MM/dd/yyyy");

                    strQry = "usp_Addfee @command='CheckTransportFee',@intStudent_id='" + txtStudentId.Text + "',@dtdate='" + dtdate1 + "'";
                    ds = sGetDataset(strQry);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strQry = "usp_Addfee @command='SelectTransportRecords',@intStudent_id='" + txtStudentId.Text + "',@dtdate='" + dtdate1 + "'";
                        dsTransport = sGetDataset(strQry);
                        //Check this record is already inserted or not in the fee table  
                        strQry = "usp_Addfee @command='CheckRecordMonthWise',@intStudent_id='" + ViewState["intStudent_id"] + "',@intFeemaster_id='0',@intMonth_id='" + GetMonths[i] + "'";
                        ds1 = sGetDataset(strQry);
                        if(ds1.Tables[0].Rows.Count == 0)                       
                        AddData(dsTransport);
                    }

                }

            }

            for (int j = 0; j < (GridView1.Rows.Count); j++)
            {
                TextBox myTextBox = (TextBox)(GridView1.Rows[j].Cells[8].FindControl("txtAmount"));
                a = Convert.ToDecimal(myTextBox.Text);
                //a = Convert.ToDecimal(GridView1.Rows[j].Cells[6].Text.ToString());
                c = c + a; //storing total qty into variable 
            }
            txtTotalAmt.Text = Convert.ToString(c);

            FinalCalculation();

        }
        catch (Exception ex)
        {
        }
    }

   protected void txtConssion_TextChanged(object sender, EventArgs e)
    {

        foreach (GridViewRow row in GridView1.Rows)
        {

          
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                String cellText = row.Cells[6].Text;
                if (cellText =="No")
                {

                }
                else
                {
                   TextBox txtConssion = (TextBox)GridView1.Rows[i].FindControl("txtConssion");
                    TextBox txtAmount = (TextBox)GridView1.Rows[i].FindControl("txtAmount");
                    if (txtConssion.Text != "")
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(txtConssion.Text, "[^0-9]"))
                        {
     
                            txtConssion.Text = txtConssion.Text.Remove(txtConssion.Text.Length - 1);
                            txtConssion.Text = "";
                            return;
                        }
                        int value = Convert.ToInt32(txtAmount.Text) - Convert.ToInt32(txtConssion.Text);
                        txtAmount.Text = Convert.ToString(value);
                    }
                }
            }

        }
      
    }

   protected void txtlatecharges_TextChanged(object sender, EventArgs e)
   {

       foreach (GridViewRow row in GridView1.Rows)
       {
           //for (int i = 0; i < GridView1.Rows.Count; i++)
           //{
               String cellText = row.Cells[4].Text;
               if (cellText == "No")
               {

               }
               else
               {
                   TextBox txtlatecharges = (TextBox)GridView1.Rows[loopcount].FindControl("txtlatecharges");
                   TextBox txtAmount = (TextBox)GridView1.Rows[loopcount].FindControl("txtAmount");
                   if (txtlatecharges.Text != "")
                   {
                       if (System.Text.RegularExpressions.Regex.IsMatch(txtlatecharges.Text, "[^0-9]"))
                       {

                           txtlatecharges.Text = txtlatecharges.Text.Remove(txtlatecharges.Text.Length - 1);
                           txtlatecharges.Text = "";
                           return;
                       }
                       int value = Convert.ToInt32(txtAmount.Text) + Convert.ToInt32(txtlatecharges.Text);
                       txtAmount.Text = Convert.ToString(value);
                   }
               }
           //}
               loopcount++;
       }

   }

   protected void txtDiscount_TextChanged(object sender, EventArgs e)
   {
       try
       {
           FinalCalculation();
       }
       catch (Exception ex)
       {
       }
   }

   private void FinalCalculation()
   {
       try
       {
           int totalamt = Convert.ToInt32(txtTotalAmt.Text);
           int Discount = Convert.ToInt32(txtDiscount.Text);
           int netamt = 0;

           if (Discount > totalamt)
           {
               MessageBox("Discount is Greater than Total Amount");
           }
           else
           {
               netamt = totalamt - Discount;
               txtnetamt.Text = Convert.ToString(netamt);
           }

       }
       catch (Exception ex)
       {
       }
   }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string strHeader = e.Row.Cells[0].Text;
            string strmnth = e.Row.Cells[2].Text;
            string strAmt = e.Row.Cells[3].Text;
            string strLate = e.Row.Cells[4].Text;
            string strCons = e.Row.Cells[6].Text;

            int conAmt = 0;

            if (strLate == "No")
            {
                TextBox txtnetCons = (e.Row.FindControl("txtlatecharges") as TextBox);
                txtnetCons.Enabled = false;
            }
            else
            {
                TextBox txtnetCons = (e.Row.FindControl("txtlatecharges") as TextBox);
                txtnetCons.Enabled = true;

            }


            if (strCons == "No")
            {
                TextBox txtnetCons = (e.Row.FindControl("txtConssion") as TextBox);
                txtnetCons.Enabled = false;
            }
            else
            {
                TextBox txtnetCons = (e.Row.FindControl("txtConssion") as TextBox);
                txtnetCons.Enabled = true;

                if (Convert.ToString(ViewState["vchConcession_per"]) != "")
                {
                    conAmt = Convert.ToInt32(strAmt) * Convert.ToInt32(ViewState["vchConcession_per"]) / 100;
                    txtnetCons.Text = Convert.ToString(conAmt);
                    txtnetCons.Enabled = false;
                }
                else if (Convert.ToString(ViewState["vchConcession_amt"]) != "")
                {
                    conAmt = Convert.ToInt32(ViewState["vchConcession_amt"]);
                    txtnetCons.Text = Convert.ToString(conAmt);
                    txtnetCons.Enabled = false;
                }

            }

            TextBox txtnetAmt = (e.Row.FindControl("txtAmount") as TextBox);
            //int val = (Convert.ToInt32(strmnth) * Convert.ToInt32(strAmt));
            txtnetAmt.Text = Convert.ToString(strAmt);

            int value = Convert.ToInt32(txtnetAmt.Text) - Convert.ToInt32(conAmt);
            txtnetAmt.Text = Convert.ToString(value);

            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[6].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }

    //protected void SetProcessDropdownList(GridViewRowEventArgs e, DataTable dt, string id)
    //{
       
    //    DropDownList ddlFeeType = (e.Row.FindControl(id.ToString()) as DropDownList);
    //    ddlFeeType.DataSource = dt; //your datasource
    //    ddlFeeType.DataTextField = dt.Columns["Fee_Name"].ToString();
    //    ddlFeeType.DataValueField = dt.Columns["intFeetype_id"].ToString();
    //    ddlFeeType.DataBind();
    //    ddlFeeType.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
    public DataSet FillFeeType()
    {

        try
        {
            strQry = "";
            strQry = "exec usp_Fee_master @command='GetFeetYPE',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                return dsObj;
            }
            return dsObj;
        }
        catch (Exception ex)
        {
            return null;

        }
    }

    public void FillStudent()
    {
       
        //strQry = "";
        ////strQry = "Execute dbo.usp_Profile @command='FillStudent',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Session["Standard_id"] + "',@intDivision_id='" + Session["Division_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        ////strQry = "Execute dbo.usp_Profile @command='FillStudent',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Session["Standard_id"] + "'";
        //strQry = "Execute dbo.usp_Profile @command='FillStudent',@intSchool_id='" + Session["School_id"] + "'";
        //sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");
        //ddlStudent.SelectedValue = "1";
    }
    protected void fGrid()
    {
        strQry = "usp_Addfee @command='GetPaidFeeRecords',@intStudFee_id='',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
    }
    
    protected void txtStudentId_TextChanged(object sender, EventArgs e)
{

        string strSQL = "select ROW_NUMBER() over (order by Student_Master.intRollNo ) as SrNo,(intStudent_id) as  intStudent_id, intStudentID_Number,vchEmergencyConPerson1," +
           "intEmergencyContat1,vchaadhar_no,Student_master.intAcademic_id,intUserType_id,intGRNo,tblstandard_master.vchStandard_name as intstanderdName,tblstandard_master.intstandard_id as intstandard_id,    " +
           "tblDivision_master.vchDivisionName,Student_master.intDivision_id,intRollNo,(vchStudentFirst_name) as vchStudentName,    " +
           "(vchFatherName) as vchFatherName,vchMotherName,vchGender,convert(varchar, dtDOB, 103) as dtDOB,vchCast,vchsubcast,vchEmail,vchpresentAddress, " +
           " vchpermanentAddress,vchImageURL,intHomePhoneNo1,intHomePhoneNo2,chrBloodGrp,vchHandicapedStatus,vchDescription, intBusAlert1" +
           " from Student_master" +
           " left outer join tblstandard_master on tblstandard_master.intStandard_id = Student_master.intstanderd_id" +
           " left outer join tblDivision_master  on tblDivision_master.intDivision_id = Student_master.intDivision_id" +
           " where Student_master.intActive_flg = 1 and" +
           " Student_master.intschool_id = '" + Convert.ToString(Session["School_id"]) + "'" +
           " and Student_master.intAcademic_id = '" + Convert.ToString(Session["AcademicID"]) + "'" +
           " and Student_Master.intStudentID_Number = '" + txtStudentId.Text + "'" +
           " order by intRollNo asc   ";
        //string strQry = "usp_Profile @command='Searchstudent_id',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intStudentID_Number='" + txtStudentId.Text + "'";
        dsObj = sGetDataset(strSQL);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["intstandard_id"] = dsObj.Tables[0].Rows[0]["intstandard_id"].ToString();
            ViewState["intDivision_id"] = dsObj.Tables[0].Rows[0]["intDivision_id"].ToString();
            ViewState["intStudent_id"] = dsObj.Tables[0].Rows[0]["intStudent_id"].ToString();
            txtName.Text = dsObj.Tables[0].Rows[0]["vchStudentName"].ToString();
            txtIdNo.Text= dsObj.Tables[0].Rows[0]["intStudentID_Number"].ToString();
            txtDiv.Text = dsObj.Tables[0].Rows[0]["vchDivisionName"].ToString();
            txtRollNo.Text = dsObj.Tables[0].Rows[0]["intRollNo"].ToString();
            txtStanderd.Text= dsObj.Tables[0].Rows[0]["intstandard_id"].ToString();
        }
    }


    public void BindItem(string intstandard_id, string intFeemaster_id, string intschool_id)
    {
        
        string strFromDate = "";
        string strToDate = "";
        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
            strToDate = Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
        }

        string sSQL = "exec usp_Addfee @command='GetDataFeeMasterWise',@intstandard_id='" + intstandard_id + "',@intFeemaster_id='" + intFeemaster_id + "',@intschool_id='" + intschool_id + "',@dtdate='" + Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") + "'";
        
        dsObj = sGetDataset(sSQL);

        if ((Convert.ToString(dsObj.Tables[0].Rows[0]["frequency"])) == "12")
        {

            int monthdiff = GetMonthDifference(Convert.ToDateTime(strFromDate), Convert.ToDateTime(strToDate));

           string[] GetMonths= GetMonthsBetweenDates(Convert.ToDateTime(strFromDate), monthdiff + 1);

           string firstmonthindex = null;

            for (int i = 0; monthdiff >= i; i++)
            {
                strQry = "usp_Addfee @command='CheckRecordMonthWise',@intStudent_id='" + ViewState["intStudent_id"] + "',@intFeemaster_id='" + intFeemaster_id + "',@intMonth_id='" + GetMonths[i] + "'";
                ds1 = sGetDataset(strQry);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    if (firstmonthindex == null )
                    {
                        ViewState["FirstMonth"] = GetMonths[i];
                        firstmonthindex = GetMonths[i];
                        loop += 1;
                    }
                    dsObj.Tables[0].Rows[0]["month"] = GetMonths[i];
                    AddData(dsObj);
                }
            }
        }
        else
        {
            AddData(dsObj);
        }
    }

    private void AddData(DataSet dsObj)
    {
        tempds=dsObj;
        DataTable dt = new DataTable();
        DataRow NewRow = null;

        if (tempds.Tables[0].Rows.Count > 0)
        {
            DataTable MyDT = new DataTable();
            MyDT.Clear();
            MyDT = tempds.Tables[0];
            DataTable olddt = new DataTable();
            DataTable newdt = new DataTable();
            //ShoppingCart(MyDT);

            if (ViewState["DataTable"] == null)
            {
                ViewState["DataTable"] = MyDT;
                GridView1.DataSource = MyDT;
                GridView1.DataBind();
                olddt = ((DataTable)ViewState["DataTable"]).Copy();
            }
            else
            {

                olddt =( (DataTable)ViewState["DataTable"]).Copy();
                if (loop != 0)
                {
                    olddt.Rows[loopcount]["month"] = ViewState["FirstMonth"];
                    loop += 1;
                }
                newdt = tempds.Tables[0]; //(DataTable)ViewState["DataTable"];
                olddt.Merge(newdt);


                ViewState["DataTable"] = olddt;
                GridView1.DataSource = olddt;
                GridView1.DataBind();

            }

        }
    }

    public static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }

    private string[] GetMonthsBetweenDates(DateTime deltaDate, int TotalMonths)
    {
        var monthsBetweenDates = Enumerable.Range(0, TotalMonths)
                                           .Select(i => deltaDate.AddMonths(i))
                                           .OrderBy(e => e)
                                           .AsEnumerable();

        return monthsBetweenDates.Select(e => e.ToString("MMM")).ToArray();
    }

    private void ShoppingCart(DataTable MyDT)
    {
        DataTable dt = MyDT;
        DataRow dtRow=null;
        if (ViewState["DataTable"] == null) //New table, create table and save it with the new record in Session variable
        {

            dtRow = MyDT.NewRow();
            

            dtRow[0] = MyDT.Rows[0]["intFeemaster_id"].ToString();
            dtRow[1] = MyDT.Rows[0]["Fee_Name"].ToString();
            dtRow[2] = MyDT.Rows[0]["frequency"].ToString();
            dtRow[3] = MyDT.Rows[0]["vchfee"].ToString();
            dtRow[4] = MyDT.Rows[0]["vchconssion"].ToString();
            
            //MyDT.Rows.Add(dtRow);
            ViewState["DataTable"] = MyDT;

        }
        else
        {
            //MyDT = (DataTable)Session["DataTable"]; //Read Session variable
            for (int i = 0; i <= MyDT.Rows.Count-1; i++)
            {
                dtRow = MyDT.NewRow();
                dtRow[0] = dt.Rows[0]["intFeemaster_id"].ToString();
                dtRow[1] = dt.Rows[0]["Fee_Name"].ToString();
                dtRow[2] = dt.Rows[0]["frequency"].ToString();
                dtRow[3] = dt.Rows[0]["vchfee"].ToString();
                dtRow[4] = dt.Rows[0]["vchconssion"].ToString();
                //dt.Rows.Add(dtRow);
                MyDT.Rows.Add(dtRow);
            }
            ViewState["DataTable"] = MyDT;   //Write Session variable after record added     
        }
        GridView1.DataSource = MyDT;
        GridView1.DataBind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["DataTable"] != null)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["DataTable"] as DataTable;
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["DataTable"] = dt;
            //BindItem();

            GridView1.DataSource = dt;
            GridView1.DataBind();
            MessageBox("Record Deleted Successfully!");

            for (int j = 0; j < (GridView1.Rows.Count); j++)
            {
                TextBox myTextBox = (TextBox)(GridView1.Rows[j].Cells[8].FindControl("txtAmount"));
                a = Convert.ToDecimal(myTextBox.Text);
                //a = Convert.ToDecimal(GridView1.Rows[j].Cells[6].Text.ToString());
                c = c + a; //storing total qty into variable 
            }
            txtTotalAmt.Text = Convert.ToString(c);

            FinalCalculation();

        }
        else
        {
            

            int index=Convert.ToInt32( this.GridView1.DataKeys[e.RowIndex].Value.ToString());
            //int index = Convert.ToInt32(e.RowIndex);

            Session["intAdminFeeChild_id"] = index;//Convert.ToString(GridView1.DataKeys[e.RowIndex].Value);
            //strQry = "exec [usp_tblAdminFee_Master] @command='deleteChild',@intAdminFeeChild_id='" + Convert.ToString(Session["intAdminFeeChild_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "'";
            strQry = "exec [usp_tblAdminFee_Master] @command='deleteChild',@intAdminFeeChild_id='" + Convert.ToString(Session["intAdminFeeChild_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                string strQryN = "usp_tblAdminFee_Master @command='selectChild',@intAdminFee_id='" + Session["intAdminFee_id"] + "'";
                DataSet dsObjid = sGetDataset(strQryN);


                if (dsObjid.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dsObjid;
                    GridView1.DataBind();
                }
                MessageBox("Category Deleted Successfully!");
            }
        }
    }

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    //BindItem();
    //}

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
        
    //    if (btnSubmit.Text == "Submit")
    //    {
    //        strQry = "usp_CategoryMaster @command='checkExist',@vchCategory='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            var discount = "Yes";
    //            var vchNet_amt = "6000";
    //            var vchRemark = "HI";
    //            strQry = "exec [usp_tblAdminFee_Master] @command='insert',@intStandard_id='" + Convert.ToString(txtStanderd.Text.Trim()) + "',@vchDivision_id='" + Convert.ToString(txtDiv.Text) + "',@intRoll_no='" + txtRollNo.Text + "',@vchDiscount='" + discount + "',@vchNet_amt='" + vchNet_amt + "',@vchRemark='" + vchRemark + "',@intModeOfPayment='" + ddlPayment.SelectedValue + "',@vchCheque_no='" + txtChequeNo.Text + "',@vchBank_Name='" + txtBankName.Text + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInsertedBy='" + Session["User_id"] + "'";
    //            if (sExecuteQuery(strQry) != -1)
    //            {
    //                fGrid();
    //                MessageBox("Category Inserted Successfully!");
    //            }

    //        }
    //        else
    //        {
    //            bool isTrue = false;
    //            for (int i = 0; i < GridView1.Rows.Count; i++)
    //            {
    //                var discount = GridView1.Rows[i].Cells[6].Text;// g1.Cells[4].Text;
    //                TextBox txtxAmount = (TextBox)GridView1.Rows[i].FindControl("txtAmount");
    //                TextBox txtxConssionAmt = (TextBox)GridView1.Rows[i].FindControl("txtConssion");
    //                var Late = GridView1.Rows[i].Cells[4].Text;// g1.Cells[4].Text;
    //                TextBox txtxlatecharges = (TextBox)GridView1.Rows[i].FindControl("txtlatecharges");
    //                var vchConssionAmt = "";
    //                var vchlatecharges = "";
    //                if (discount == "No")
    //                {

    //                    vchConssionAmt = txtxConssionAmt.Text;
    //                }
    //                else
    //                {
    //                    vchConssionAmt = txtxConssionAmt.Text;
    //                    if (vchConssionAmt == "")
    //                    {
    //                        isTrue = false;
    //                        MessageBox("Please Enter Concession Amount!");
    //                        return;
    //                    }
    //                }

    //                if (Late == "No")
    //                {

    //                    vchlatecharges = txtxlatecharges.Text;
    //                }
    //                else
    //                {
    //                    vchlatecharges = txtxlatecharges.Text;
    //                    if (vchlatecharges == "")
    //                    {
    //                        isTrue = false;
    //                        MessageBox("Please Enter Late charges!");
    //                        return;
    //                    }
    //                }
    //            }
    //            string strQryIdExit = "select intAdminFee_id from tblAdminFee_Master where intStandard_id='" + Convert.ToString(txtStanderd.Text.Trim()) + "' and vchStudentNo='" + Convert.ToString(txtStudentId.Text) + "' and intRoll_no='" + txtRollNo.Text + "' and intActive_flg=1";
    //            DataSet dsObjidexit = sGetDataset(strQryIdExit);
    //            if (dsObjidexit.Tables[0].Rows.Count > 0)
    //            {
    //                MessageBox("Already data Exits!");
    //                return;
    //            }

    //            strQry = "exec [usp_tblAdminFee_Master] @command='insert',@intFeemaster_id='" + "" + "',@vchName='" + Convert.ToString(txtName.Text) + "',@vchStudentNo='" + Convert.ToString(txtStudentId.Text) + "',@intStandard_id='" + Convert.ToString(txtStanderd.Text.Trim()) + "',@vchDivision_id='" + Convert.ToString(txtDiv.Text) + "',@intRoll_no='" + txtRollNo.Text + "',@vchDiscount='" + "" + "',@vchNet_amt='" + "" + "',@vchRemark='" + txtRemarks.Text + "',@intModeOfPayment='" + ddlPayment.SelectedValue + "',@vchCheque_no='" + txtChequeNo.Text + "',@vchBank_Name='" + txtBankName.Text + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInsertedBy='" + Session["User_id"] + "'";
    //            if (sExecuteQuery(strQry) != -1)
    //            {
    //                isTrue = true;
    //            }
                
    //                for (int i = 0; i < GridView1.Rows.Count; i++)
    //                {

                   
    //                    string strQryId = "select intAdminFee_id from tblAdminFee_Master where intStandard_id='" + Convert.ToString(txtStanderd.Text.Trim()) + "' and vchStudentNo='" + Convert.ToString(txtStudentId.Text) + "' and intRoll_no='" + txtRollNo.Text + "' and intActive_flg=1";
    //               DataSet   dsObjid = sGetDataset(strQryId);
                   
    //                string intAdminFee_id="";
    //                if (dsObjid.Tables[0].Rows.Count > 0)
    //                {
    //                    intAdminFee_id = dsObjid.Tables[0].Rows[0]["intAdminFee_id"].ToString();
    //                }

    //                TextBox txtxAmount = (TextBox)GridView1.Rows[i].FindControl("txtAmount");
    //                TextBox txtxConssionAmt = (TextBox)GridView1.Rows[i].FindControl("txtConssion");

                        
    //                var intFeemaster_id = GridView1.Rows[i].Cells[0].Text;//g1.Cells[0].Text;
    //                var frequency= GridView1.Rows[i].Cells[2].Text;// g1.Cells[2].Text;
    //                var discount = GridView1.Rows[i].Cells[4].Text;// g1.Cells[4].Text;
    //                var vchNet_amt = GridView1.Rows[i].Cells[3].Text;// g1.Cells[3].Text;
    //                var vchConssionAmt = "";
    //                if (discount== "No")
    //                {

    //                     vchConssionAmt = txtxConssionAmt.Text;
    //                }
    //                else
    //                {
    //                    vchConssionAmt = txtxConssionAmt.Text;
    //                    if(vchConssionAmt=="")
    //                    {
    //                        isTrue = false;
    //                        MessageBox("Please Enter Concession Amount!");
    //                        return;
    //                    }
    //                }
                   
    //                var vchAmount = txtxAmount.Text;
    //                var vchRemark = txtRemarks.Text;
    //              //  strQry = "exec [usp_tblAdminFee_Master] @command='insert',@intFeemaster_id='" + Convert.ToString(intFeemaster_id) + "',@vchName='" + Convert.ToString(txtName.Text) + "',@vchStudentNo='" + Convert.ToString(txtStudentId.Text) + "',@intStandard_id='" + Convert.ToString(txtStanderd.Text.Trim()) + "',@vchDivision_id='" + Convert.ToString(txtDiv.Text) + "',@intRoll_no='" + txtRollNo.Text + "',@vchDiscount='" + discount + "',@vchNet_amt='" + vchNet_amt + "',@vchRemark='" + vchRemark + "',@intModeOfPayment='" + ddlPayment.SelectedValue + "',@vchCheque_no='" + txtChequeNo.Text + "',@vchBank_Name='" + txtBankName.Text + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInsertedBy='" + Session["User_id"] + "'";
    //                strQry = "exec [usp_tblAdminFee_Master] @command='insertChild',@intAdminFee_id='" + intAdminFee_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchDiscount='" + discount + "',@vchNet_amt='" + vchNet_amt + "',@intFeemaster_id='" + intFeemaster_id + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInsertedBy='" + Session["User_id"] + "',@frequency='" + frequency + "',@vchConssionAmt='" + vchConssionAmt + "',@vchAmount='" + vchAmount + "'";

    //                if (sExecuteQuery(strQry) != -1)
    //                {
    //                    isTrue = true;
    //                }
    //                }
                
            
    //            if (isTrue==true)
    //            {
    //                fGrid();
    //                MessageBox("Category Inserted Successfully!");
    //                Clear();
    //            }
    //        }

        

    //        //strQry = "insert into tblAdminFee_Master(intStandard_id,intDivision_id,intRoll_no,vchDiscount,vchNet_amt,vchRemark,intModeOfPayment,vchCheque_no,intBank_id,intSchool_id,intAcademic_id,intActive_flg,intInsertedBy) " +
    //        //    "values('"+txtStanderd.Text+ "','" + txtDiv.Text + "','" + txtRollNo.Text + "','" + discount + "','" + vchNet_amt + "','" + vchRemark + "','" + ddlPayment.SelectedValue + "','" + txtChequeNo.Text + "','" + txtBankName.Text + "','" + Convert.ToString(Session["School_id"]) + "','" + Convert.ToString(Session["AcademicID"]) + "','1','" + Session["User_id"] + "')";

    //    }
    //    else
    //    {
    //        strQry = "usp_CategoryMaster @command='checkExist',@vchCategory='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            MessageBox("Category Already Exists");
    //            return;
    //        }
    //        else
    //        {
    //            strQry = "exec [usp_tblAdminFee_Master] @command='Update',@vchRemark='" + txtRemarks.Text + "',@intModeOfPayment='" + ddlPayment.SelectedValue + "',@vchCheque_no='" + txtChequeNo.Text + "',@vchBank_Name='" + txtBankName.Text + "',@intUpdatedBy='" + Session["User_id"] + "',@intAdminFee_id='" + Convert.ToString(Session["intAdminFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
    //            if (sExecuteQuery(strQry) != -1)
    //            {
    //                fGrid();
    //                MessageBox("Category Updated Successfully!");
    //                TabContainer1.ActiveTabIndex = 0;
    //                btnSubmit.Text = "Submit";
    //            }
    //        }
    //    }
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDiscount.Text == "")
                txtDiscount.Text = "0";
            strQry = "usp_Addfee @command='AddFeeinMaster',@intStudent_id='" + ViewState["intStudent_id"] + "',@intStandard_id='" +  ViewState["intstandard_id"] +"',@intDivision_id='" + ViewState["intDivision_id"] +"',@intRoll_no='" + txtRollNo.Text + "'"+
                ",@vchDiscount='" + txtDiscount.Text + "',@vchNet_amt='" + txtnetamt.Text + "',@vchRemark='" + txtRemarks.Text + "',@ModeOfPayment='" + ddlPayment.SelectedItem + "',@vchCheque_no='" + txtChequeNo.Text + "',@vchBank_name='" + txtBankName.Text + "',@intSchool_id='" + Session["School_id"] + "'" +
                    ",@intAcademic_id='" + Session["AcademicID"] + "',@intInserted_by='" + Session["User_id"] + "',@vchInserted_ip='" + GetSystemIP() + "'";
            string Result = sExecuteScalar(strQry);

            //DataSet dsRecords=new DataSet();
            DataTable dt = ViewState["DataTable"] as DataTable;
           // dsRecords = (DataSet)ViewState["DataTable"];

            int ExeQuery = 0;
            for (int i = 0; i < (GridView1.Rows.Count); i++)
            {
                TextBox myLatecharges = (TextBox)(GridView1.Rows[i].Cells[5].FindControl("txtlatecharges"));
                decimal myLateCharge = Convert.ToDecimal(myLatecharges.Text);

                 TextBox myConcession = (TextBox)(GridView1.Rows[i].Cells[7].FindControl("txtConssion"));
                 decimal mycons = Convert.ToDecimal(myConcession.Text);

                   TextBox myAmt = (TextBox)(GridView1.Rows[i].Cells[8].FindControl("txtAmount"));
                 decimal myAmount = Convert.ToDecimal(myAmt.Text);

                 strQry = "usp_Addfee @command='InsertFeeDetails',@intStudFee_id='" + Result + "',@intFeemaster_id='" + dt.Rows[i]["intFeemaster_id"] + "',@intNoOf_month=''" +
                    ",@intMonth_id='" + dt.Rows[i]["month"] + "',@vchAmount='" + dt.Rows[i]["vchfee"] + "',@vchLate_charges='" + myLateCharge + "'" +
                    ",@intConcession_amt='" + mycons + "',@vchNetDetail_amt='" + myAmount + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                ExeQuery = sExecuteQuery(strQry);
            }
            if (ExeQuery > 0)
            {
                MessageBox("Fee Paid Successfully....");
                Clear();
            }

        }
        catch (Exception ex)
        {
        }
    }

    private void Clear()
    {
        txtName.Text = "";
        txtStanderd.Text ="";
        txtDiv.Text = "";
        txtRollNo.Text = "";
        txtIdNo.Text = "";
        txtDiscount.Text = "0";
        txtTotalAmt.Text = "0";
        txtnetamt.Text = "0";

        ddlPayment.SelectedValue = "0";
        txtChequeNo.Text = "";
        txtBankName.Text = "";
        txtRemarks.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtStudentId.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
    //protected void ddlFeeType_Change(object sender, EventArgs e)
    //{
    //    string sSQL = "select intFeemaster_id,Fee_Name from tblFee_master  where intFeetype_id='" + ddlFeeType.SelectedValue + "' and intstandard_id = '" + txtStanderd.Text + "' and intActive_flg='1'";
    //    sBindDropDownList(ddlFeeMaster, sSQL, "Fee_Name", "intFeemaster_id");
    //    //ddlFeeMaster.SelectedValue = "1";
    //}

    protected void ddlPayment_Change(object sender, EventArgs e)
    {
       if(ddlPayment.SelectedValue=="2")
        {
            EnabDisb(true);
        }
       else if (ddlPayment.SelectedValue == "0")
        {
            EnabDisb(true);
        }
       else
        {
            EnabDisb(false);
        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intStudFee_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_Addfee @command='FeeDetails',@intStudFee_id='" + Convert.ToString(Session["intStudFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "OpenModal()", true);
                GridView3.DataSource = dsObj;

                //Code By Nikhil
                int Amt = 0;
                int Latecharges = 0;
                int concession = 0;
                int netamt = 0;
                foreach (DataRow dr in dsObj.Tables[0].Rows)
                {
                    Amt += Convert.ToInt32(dr["vchAmount"]);
                    Latecharges += Convert.ToInt32(dr["vchLate_charges"]);
                    concession += Convert.ToInt32(dr["intConcession_amt"]);
                    netamt += Convert.ToInt32(dr["vchNetDetail_amt"]);
                }

                GridView3.Columns[2].FooterText = "Total";
                GridView3.Columns[3].FooterText = Amt.ToString();
                GridView3.Columns[4].FooterText = Latecharges.ToString();
                GridView3.Columns[5].FooterText = concession.ToString();
                GridView3.Columns[6].FooterText = netamt.ToString();
                GridView3.FooterStyle.Font.Bold=true;
                GridView3.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    //protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {
    //        Session["intAdminFee_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
    //        strQry = "";
    //        strQry = "exec usp_tblAdminFee_Master @command='edit',@intAdminFee_id='" + Convert.ToString(Session["intAdminFee_id"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchName"]);
    //            txtStanderd.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
    //            txtDiv.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivision_id"]);
    //            txtRollNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRoll_no"]);
    //            txtIdNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentNo"]);
                
                
    //            ddlPayment.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intModeOfPayment"]);
    //            txtChequeNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCheque_no"]);
    //            txtBankName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBank_Name"]);
    //            txtRemarks.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchRemark"]);
    //            if(ddlPayment.SelectedValue=="2")
    //            {
    //                EnabDisb(true);
    //            }
    //            else
    //            {
    //                EnabDisb(false);

    //            }

    //            //string strQryId = "select vchDiscount,vchNet_amt,intFeemaster_id from tblAdminFeechild_Master where intAdminFee_id='"+ Session["intAdminFee_id"] + "'";
    //            //DataSet dsObjid = sGetDataset(strQryId);

    //            string strQryN = "usp_tblAdminFee_Master @command='selectChild',@intAdminFee_id='" + Session["intAdminFee_id"] + "'";
    //            DataSet dsObjid = sGetDataset(strQryN);
    //            ViewState["VchConssionEdit"] = "edit";

    //           if (dsObjid.Tables[0].Rows.Count > 0)
    //            {


    //                ViewState["VchConssion"] = dsObjid.Tables[0].Rows[0]["vchconssion"].ToString();


    //                GridView2.DataSource = dsObjid;


    //                //For footer section in grid
    //                int totalConcession = 0;
    //                int totalNet = 0;
    //                int totalfemale = 0;
    //                foreach (DataRow dr in dsObjid.Tables[0].Rows)
    //                {
    //                    string strconAmt = Convert.ToString(dr["vchConssionAmt"]);
    //                    if(strconAmt!="")
    //                    {
    //                        totalConcession += Convert.ToInt32(dr["vchConssionAmt"]);

    //                    }
    //                    else
    //                    {
    //                        totalConcession += Convert.ToInt32(0);
    //                    }
                       
    //                    totalNet += Convert.ToInt32(dr["vchAmount"]);
                        
    //                }

    //                GridView2.Columns[0].FooterText = "Total";
    //                GridView2.Columns[5].FooterText = totalConcession.ToString();
    //                GridView2.Columns[6].FooterText = totalNet.ToString();
    //                //For footer section in grid

    //                GridView2.DataBind();


    //            }

    //            TabContainer1.ActiveTabIndex = 2;
    //            btnSubmit.Text = "Update";
    //        }
    //    }
    //    catch(Exception ex)
    //    {
            
    //    }
    //}

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strAdminFeeChild_id = e.Row.Cells[0].Text;
            string strmnth = e.Row.Cells[2].Text;
            string strAmt = e.Row.Cells[3].Text;
            string strCons = e.Row.Cells[4].Text;
            if (strCons == "No")
            {
                TextBox txtnetCons = (e.Row.FindControl("txtConssion") as TextBox);
                txtnetCons.Enabled = false;

                TextBox txtnetAmt = (e.Row.FindControl("txtAmount") as TextBox);
                int val = (Convert.ToInt32(strmnth) * Convert.ToInt32(strAmt));
                txtnetAmt.Text = Convert.ToString(val);
            }
            else
            {
                TextBox txtnetCons = (e.Row.FindControl("txtConssion") as TextBox);
                txtnetCons.Enabled = true;
                string sSQL = "select vchDiscount,vchAmount ,vchConssionAmt from tblAdminFeechild_Master where intAdminFeeChild_id='" + strAdminFeeChild_id + "' and vchDiscount='Yes' and intActive_flg=1";
                dsObj = sGetDataset(sSQL);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtnetCons.Text = dsObj.Tables[0].Rows[0]["vchConssionAmt"].ToString();

                    TextBox txtnetAmt = (e.Row.FindControl("txtAmount") as TextBox);
                    int val = (Convert.ToInt32(strmnth) * Convert.ToInt32(strAmt));
                    txtnetAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAmount"].ToString());
                }
            }

           
        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intAdminFee_id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblAdminFee_Master] @command='delete',@intAdminFee_id='" + Convert.ToString(Session["intAdminFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "'";
            if (sExecuteQuery(strQry) == 1)
            {
                //fGrid();
                MessageBox("Please delete from Child data first!");
            }
            else
            {
                fGrid();
                MessageBox("Category Deleted Successfully!");
            }

        
        }
        catch
        {

        }
    }
    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
}