using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmOutstandingReport : DBUtility
{
    DataSet dsObj = new DataSet();
    string query1, query2, query6, query3, Disquery, strQry;
    bool st, st2, st3 = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();

            //Fill Standards
            query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
            st = sBindDropDownListAll(DropDownL1, query1, "Standard_name", "intStandard_id");
            DropDownL1.SelectedItem.Value = "0";
        }
        checksession();
    }

    private void fillgrid(bool search=false,string intStandard_id = "0", string intDivision_id = "0", string intstudent_id="0")
    {
        try
        {
            string strQry = "exec [usp_FeecollectionReports] @intStandard_id='" + intStandard_id + "',@intDivision_id='" + intDivision_id + "',@intstudent_id='" + intstudent_id + "',@intschool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["outstandingReportTable"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                if (search)
                {
                    grvDetail.DataSource = dsObj;
                    grvDetail.DataBind();
                }
                else
                {
                    GridView1.DataSource = dsObj;
                    GridView1.DataBind();
                }
                //Print Total at Footer

                int total = 0; ;
                GridView grd = search == true ? grvDetail : GridView1;
                grd.FooterRow.Cells[4].Text = "Total";
                grd.FooterRow.Cells[4].Font.Bold = true;
                grd.FooterRow.Cells[5].Font.Bold = true;
                grd.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                for (int k = 5; k < dsObj.Tables[0].Columns.Count; k++)
                {
                    total = dsObj.Tables[0].AsEnumerable().Sum(row => row.Field<Int32>(dsObj.Tables[0].Columns[k].ToString()));
                    grd.FooterRow.Cells[k].Text = total.ToString();
                    grd.FooterRow.Cells[k].Font.Bold = true;
                    grd.FooterRow.BackColor = System.Drawing.Color.Beige;
                } 
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            string std = DropDownL1.SelectedItem.Value;

            if (std == "A")
            {
                //For All Standarads
                fillgrid(true);
            }
            else
            {

                query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + std + "' ";
                st2 = sBindDropDownListAll(DropDownL2, query2, "vchDivisionName", "intDivision_id");
            }
            
        }
        catch
        {

        }

    }
    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string std = DropDownL1.SelectedItem.Value;
            string div = DropDownL2.SelectedItem.Value;

            if (div == "A")
            {
                fillgrid(true,std);
            }
            else
            {
                query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + std + "',@intDivision_id='" + div + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                st3 = sBindDropDownListAll(Droptypeuser, query3, "Name", "intStudent_id");
            }

        }
        catch
        {

        }
    }
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
             string stat1 = Convert.ToString(DropDownL1.SelectedItem.Value);
            string Div1 = Convert.ToString(DropDownL2.SelectedItem.Value);
            string st = Droptypeuser.SelectedItem.Value;

            if (st == "A")
            {
                fillgrid(true,stat1, Div1);
            }
            else
            {
                fillgrid(true,stat1, Div1,st);
            }
        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmExcel.aspx", true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmExcel.aspx", true);
    }

}