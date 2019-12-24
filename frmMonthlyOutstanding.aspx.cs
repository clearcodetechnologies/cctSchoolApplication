﻿using System;
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

public partial class frmMonthlyOutstanding : DBUtility
{
    DataSet dsObj = new DataSet();
    DataSet dsObj1 = new DataSet();
    string query1, query2, query6, query3, Disquery, strQry;
    bool st, st2, st3 = true;
    int Div1, stat1, Leavegrid = 0;
    string DeleteIP, strQry11;

    int intforumid, intforumid1, intfor3, stat, id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {

                lbltext.Text = "Monthly Outstanding Report from 01-04-2019 to " + DateTime.Now.ToString("dd/MM/yyyy");

                checksession();
                geturl();
                listparengrid.Visible = false;

                Droptypeuser.ClearSelection();
                query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                st = sBindDropDownList(DropDownL1, query1, "Standard_name", "intStandard_id");
                DropDownL1.SelectedItem.Value = "0";
                query2 = "Execute dbo.usp_Profile @command='RemarkDivision1',@intSchool_id='" + Session["School_id"] + "' ";
                st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");


                if (Convert.ToString(Session["UserType_id"]) == "3")
                {

                    teachhide.Visible = true;
                    teachhide1.Visible = true;
                    DropDownL1.Enabled = true;
                    DropDownL2.Enabled = true;


                    query6 = "Execute dbo.usp_Profile @command='teachStadiv',@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
                    dsObj1 = sGetDataset(query6);
                    if (dsObj1.Tables[0].Rows.Count > 0)
                    {
                        DropDownL1.SelectedValue = Convert.ToString(dsObj1.Tables[0].Rows[0]["intStandard_id"]);
                        DropDownL2.SelectedValue = Convert.ToString(dsObj1.Tables[0].Rows[0]["intDivision_id"]);

                        query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(dsObj1.Tables[0].Rows[0]["intStandard_id"]) + "',@intDivision_id='" + Convert.ToString(dsObj1.Tables[0].Rows[0]["intDivision_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";


                        st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
                        //Droptypeuser.SelectedValue = "A";
                        Disquery = "Execute dbo.usp_Profile @command='liststudAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(dsObj1.Tables[0].Rows[0]["intStandard_id"]) + "',@intDivision_id='" + Convert.ToString(dsObj1.Tables[0].Rows[0]["intDivision_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                        Leavegrid = sBindGrid(GridViewliststud, Disquery);
                        //GridViewliststud.Columns[1].Visible = false;
                        //GridViewliststud.Columns[3].Visible = false;
                        //GridViewliststud.Columns[4].Visible = false;
                        //GridViewliststud.Columns[5].Visible = false;
                        //GridViewliststud.Columns[12].Visible = false;
                        //GridViewliststud.Columns[13].Visible = false;

                    }
                    else
                    {
                        filldata();
                    }


                }
                else
                {

                    Droptypeuser.SelectedValue = "A";
                }

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Clear()
    {

        DropDownL1.SelectedItem.Value = "0";

    }

    protected void filldata()
    {
        try
        {
            stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);

            //query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";
            query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Session["Standard_id"] + "',@intDivision_id='" + Session["Division_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";


            st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
            //Droptypeuser.SelectedValue = "A";
            Disquery = "Execute dbo.usp_Profile @command='liststudAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            Leavegrid = sBindGrid(GridViewliststud, Disquery);


            //GridViewliststud.Columns[1].Visible = false;
            //GridViewliststud.Columns[3].Visible = false;
            //GridViewliststud.Columns[4].Visible = false;
            //GridViewliststud.Columns[5].Visible = false;
            //GridViewliststud.Columns[12].Visible = false;
            //GridViewliststud.Columns[13].Visible = false;

        }
        catch
        {
        }
    }

    protected void GridViewliststud_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void GridViewliststud_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViewliststud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                intforumid = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
                Image img = (Image)e.Row.FindControl("btnDetails");
                img.Attributes.Add("onclick", "window.open('frmLiStudentProfile.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=1000,top=100,left=200');return false");

                intforumid1 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
                Image img1 = (Image)e.Row.FindControl("btnpareDetails");
                img1.Attributes.Add("onclick", "window.open('frmAdmPareProDetai1.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

                intfor3 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
                Image img3 = (Image)e.Row.FindControl("ImgEdit");
                img3.Attributes.Add("onclick", "window.open('frmAdmLiStudentProfile.aspx?successMessage3=" + intfor3 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

            }
        }
        catch
        {
        }

    }

    protected void DropDownList37_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList38_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            stat = Convert.ToInt32(DropDownL1.SelectedItem.Value);

            query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");

        }
        catch
        {

        }

    }

    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {



            stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);

            query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";


            st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
        }
        catch
        {

        }
    }
    protected void GridViewliststud_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            id = Convert.ToInt32(GridViewliststud.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridViewliststud.DataKeys[e.RowIndex].Value;
            DeleteIP = GetSystemIP();
            strQry11 = "Execute dbo.usp_Profile @command='DeleteStudPro',@intStudent_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@vchDeleted_IP='" + DeleteIP + "',@intDeleted_id='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                //filldata();
            }

        }
        catch
        {


        }

    }
    
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
           LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row

           // string userid = grdTrans.DataKeys[gvrow.RowIndex].Value.ToString();
            string StudentId = Convert.ToString(grvDetail.DataKeys[gvrow.RowIndex].Values[0]);

            DataSet dsObj = new DataSet();
            strQry = "";
            strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='DueMonthstudent',@intstudent_id='" + StudentId + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptStudentdetail"] = dsObj;
            Session["StudentID"] = StudentId;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //string url = "frmDueMonth.aspx";
                //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
                //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                Response.Redirect("frmDueMonth.aspx", true);
            }
            else
            {
                MessageBox("No data found");
            }


                //lnkMale.Attributes.Add("onclick", "window.open('frmDueMonth.aspx?StudentId=" + lblStudentID.Text + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            
        }
        catch
        { 
        
        }
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {



            int stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);




            string st = Droptypeuser.SelectedItem.Value;

            string Disquery;

            if (st == "A")
            {
                try
                {

                    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='MonthlyOutstanding',@intDivision_id='" + DropDownL2.SelectedValue + "',@intStandard_id='" + DropDownL1.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        grvDetail.DataSource = dsObj;
                        grvDetail.DataBind();

                    }
                }
                catch (Exception ex)
                {

                }

                //Disquery = "Execute dbo.usp_Profile @command='liststudAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                //int Leavegrid = sBindGrid(GridViewliststud, Disquery);
                //// GridViewliststud.Columns[2].Visible = false;
                //if (Convert.ToString(Session["UserType_id"]) == "3")
                //{
                //    GridViewliststud.Columns[1].Visible = false;
                //    GridViewliststud.Columns[3].Visible = false;
                //    GridViewliststud.Columns[4].Visible = false;
                //    GridViewliststud.Columns[5].Visible = false;
                //    GridViewliststud.Columns[12].Visible = false;
                //    GridViewliststud.Columns[13].Visible = false;
                //}

            }

            else if (st == "0")
            {
                GridViewliststud.Visible = false;
            }
            else
            {
                try
                {

                    strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='MonthlyOutstandingstudent',@intstudent_id='" + st + "',@intStandard_id='" + DropDownL1.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDivision_id='" + DropDownL2.SelectedValue + "'";

                    //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        grvDetail.DataSource = dsObj;
                        grvDetail.DataBind();

                    }
                }
                catch (Exception ex)
                {

                }


            }
            //GridViewliststud.Columns[1].Visible = false;
            // GridViewliststud.Columns[3].Visible = false;
            //GridViewliststud.Columns[4].Visible = false;
            //GridViewliststud.Columns[5].Visible = false;
        }
        catch
        {

        }
    }
    protected void GridViewliststud_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewliststud.PageIndex = e.NewPageIndex;
        filldata();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {


        if (DropDownL1.SelectedValue == "0")
        {
            DropDownL1.Focus();
            MessageBox("Please Select Standard!");
            return;
        }
        if (DropDownL2.SelectedValue == "0")
        {
            DropDownL2.Focus();
            MessageBox("Please Select Division!");
            return;
        }
        if (Droptypeuser.SelectedValue == "0")
        {
            Droptypeuser.Focus();
            MessageBox("Please Select Student!");
            return;
        }
        try
        {
            DataSet dsObj = new DataSet();
            int stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);
            string st = Droptypeuser.SelectedItem.Value;
            string Disquery;
            if (st == "A")
            {
                Disquery = "Execute dbo.usp_Profile @command='liststudAll',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                dsObj = sGetDataset(Disquery);
                Session["rptStudentDetails"] = dsObj;
                Response.Redirect("frmStudentRpt.aspx", true);
            }
            else
            {

                Disquery = "Execute dbo.usp_Profile @command='liststud1',@intschool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "',@intStudent_id='" + st + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                dsObj = sGetDataset(Disquery);
                Session["rptStudentDetails"] = dsObj;
                Response.Redirect("frmStudentRpt.aspx", true);
            }
        }
        catch
        {

        }
    }
}