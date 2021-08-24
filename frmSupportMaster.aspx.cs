using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmSupportMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checksession();
            fGrid();
        }
    }

    protected void fGrid()
    {
        strQry = "usp_Support @command='selectAllRecords',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvDetail.DataSource = dsObj;
        grvDetail.DataBind();
        Clear();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSubmit.Text == "Submit")
            {
                strQry = "usp_Support @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count == 0)
                {
                    DateTime v1 = Convert.ToDateTime(TextBox3.Text);
                    string Periodfrom = v1.ToString("HH:mm");
                    DateTime v2 = Convert.ToDateTime(TextBox1.Text);
                    string PeriodTo = v2.ToString("HH:mm");

                    strQry = "exec usp_Support @command='insert',@Phone_Number='" + Convert.ToString(txtphoneno.Text.Trim()) + "',@EmailID='" + Convert.ToString(txtEmailID.Text) + "',@FromTime='" + Periodfrom + "',@ToTime='" + PeriodTo + "',@ContactPersonName='" + Convert.ToString(txtperson.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    if (sExecuteQuery(strQry) > 0)
                    {
                        fGrid();
                        MessageBox("Record inserted Successfully!");
                        TabContainer1.ActiveTabIndex = 0;
                        btnSubmit.Text = "Submit";
                        Clear();
                    }

                }
                else
                {
                    MessageBox("Only one record is allow");
                }
            }
            else
            {

                DateTime v1 = Convert.ToDateTime(TextBox3.Text);
                string Periodfrom = v1.ToString("HH:mm");
                DateTime v2 = Convert.ToDateTime(TextBox1.Text);
                string PeriodTo = v2.ToString("HH:mm");

                strQry = "exec usp_Support @command='Update',@Phone_Number='" + Convert.ToString(txtphoneno.Text.Trim()) + "',@EmailID='" + Convert.ToString(txtEmailID.Text) + "',@FromTime='" + Periodfrom + "',@ToTime='" + PeriodTo + "',@ContactPersonName='" + Convert.ToString(txtperson.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@int_id='" + ViewState["id"] + "'";
                if (sExecuteQuery(strQry) > 0)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                    Clear();
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    public void Clear()
    {
        txtphoneno.Text = "";
        txtEmailID.Text = "";
        TextBox3.Text = "";
        TextBox1.Text = "";
        txtperson.Text = "";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {

       int  id = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
        ViewState["id"] = grvDetail.DataKeys[e.NewEditIndex].Value;


            strQry = "usp_Support @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtphoneno.Text = dsObj.Tables[0].Rows[0]["Phone_Number"].ToString();
                txtEmailID.Text = dsObj.Tables[0].Rows[0]["EmailID"].ToString();

                //TextBox3.Text = dsObj.Tables[0].Rows[0]["FromTime"].ToString();
                //TextBox1.Text = dsObj.Tables[0].Rows[0]["ToTime"].ToString();

                DateTime var1 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromTime"]);
                TextBox3.Text = var1.ToString("hh:mm tt");


                DateTime var2 = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToTime"]);
                TextBox1.Text = var2.ToString("hh:mm tt");

                txtperson.Text = dsObj.Tables[0].Rows[0]["ContactPersonName"].ToString();
                btnSubmit.Text = "Update";
                TabContainer1.ActiveTabIndex = 1;

            }
    }
}