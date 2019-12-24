﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTransportFee : DBUtility
{
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
                    fillAcademicYear();
                    FillArea();
             
                    FillGrid();
                    geturl();
                }
                //FillGrid();
                //FillArea(); 
            }
            else
            {
                Response.Redirect("~\\login.aspx", false);
            }
        }
        catch
        {

        }

    }

    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillTransportfeeGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intArea_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='fillAcademicYear'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
           // ddlSTD.ClearSelection();
        }
        catch
        {

        }
    }
    public void FillArea()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillArea',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchArea_Name", "intArea_Id");
            sBindDropDownList(chkSTD, strQry, "vchArea_Name", "intArea_Id");
        }
        catch
        {

        }
    }

   
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                Boolean chk = false;
                for (int i = 0; i < chkSTD.Items.Count; i++)
                {
                    if (chkSTD.Items[i].Selected == true)
                    {
                        strQry = "exec [usp_FeesAssignSTD] @type='checkTransportFeeExists',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intArea_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                        dsObj = sGetDataset(strQry);

                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            FillGrid();
                            MessageBox("Record Exist Already");
                            return;
                        }
                        strQry = "exec usp_FeesAssignSTD @type='AreaFeeInsert',@total_amount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intArea_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIP='" + GetSystemIP() + "'";
                        //strQry = "exec usp_FeesAssignSTD @type='Insert',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@vchFeeDesc='" + Convert.ToString(txtDesc.Text) + "',@dtEffFromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtEffToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIP='" + GetSystemIP() + "'";
                        //Session["DurationID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDuration_Id"]);
                        if (sExecuteQuery(strQry) != -1)
                        {
                            chk = true;
                        }
                        else
                        {
                            chk = false;
                            break;
                        }
                    }
                }
                if (chk == true)
                {
                    MessageBox("Record Saved Successfully!");
                    FillGrid();
                    Clear();
                }
            }
            else
            {

                strQry = "exec [usp_FeesAssignSTD] @type='checkTransportFeeExists',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intArea_Id='" + Convert.ToString(chkSTD.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    FillGrid();
                    MessageBox("Record Exist Already");
                    return;
                }
                //fillpartType();
                strQry = "exec usp_FeesAssignSTD @type='UpdateAreafee',@total_amount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intFeeDetId='" + Convert.ToString(ViewState["Id"]) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                //strQry = "exec usp_FeesAssignSTD @type='Update',@intFeeDetId='" + Convert.ToString(ViewState["Id"]) + "',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@vchFeeDesc='" + Convert.ToString(txtDesc.Text) + "',@dtEffFromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtEffToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    FillGrid();
                    Clear();
                }
            }
        }
        catch
        {

        }
    }
    public void Clear()
    {
        try
        {
            ddlAcademiYear.ClearSelection();
            chkSTD.ClearSelection();
            txtAmt.Text = "";
            txtDesc.Text = "";
            txtFrmDt.Text = "";
            txtToDt.Text = "";
            
            //chkSTD.Items.Clear();
            
            //chkSTD.Enabled = true;
            btnSubmit.Text = "Submit";
        }
        catch
        {

        }
    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception)
        {
            // return msg;
        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillTransportfeeGridAreawise',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intArea_Id ='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();


            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                String test = grvDetail.Rows[i].Cells[3].Text;
                if (test == "Monthly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 12);
                }
                else if (test == "Quarterly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 4);
                }
                else if (test == "Half Yearly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 2);
                }
                else
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text));
                }

                //sum += int.Parse(grvDetail.Rows[i].Cells[4].Text);

            }
           // lblTotal.Text = sum.ToString();
        }
        catch
        {

        }
    }


    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["Id"] = id;
            strQry = "exec usp_FeesAssignSTD @type='EditAreaFill',@intAcademic_id='" + Session["AcademicID"] + "',@intFeeDetId='" + ViewState["Id"] + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            chkSTD.Items.Clear();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //ddlParticular.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intFee_Id"]);
                //txtDurationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
                chkSTD.Items.Add(new ListItem(Convert.ToString(dsObj.Tables[0].Rows[0]["vchArea_Name"]), 
                    Convert.ToString(dsObj.Tables[0].Rows[0]["intArea_Id"])));
                chkSTD.Items[0].Selected = true;
                ddlAcademiYear.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                //txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]); 
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
                //ddlParticular.Enabled = false;
                chkSTD.Enabled = false;
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
            strQry = "exec usp_FeesAssignSTD @type='Deleteareafee',@intFeeDetId='" + id + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }
        }
        catch
        {

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

        }
    }
    protected void drpAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSTD.ClearSelection();
    }

}