using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmOutstandingTotal : DBUtility
{
     DataSet dsObj = new DataSet();
    DataSet dsObj1 = new DataSet();
    string query1, query2, query6, query3, Disquery, strQry;
    bool st, st2, st3 = true;
    int Div1, stat1, Leavegrid = 0;
    string DeleteIP, strQry11;
    DataSet dsdetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                fillgrid();

                checksession();
                geturl();
                

               
                query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                st = sBindDropDownListAll(DropDownL1, query1, "Standard_name", "intStandard_id");
                DropDownL1.SelectedItem.Value = "0";
                

                }
                else
                {

                    
                }

            }
        
        catch (Exception ex)
        {

        }
    }

    protected void fillgrid()
    {
        try
        {

            strQry = "exec [usp_Mob_SchoolFeeCollectionNew_SP] @type='AllStandardOutstandingFee',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            //Session["AllstudentoutstandingTable"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dsObj;
                GridView1.DataBind();

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
            //stat = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            string std = DropDownL1.SelectedItem.Value;

            if (std == "A")
            {
                try
                {

                    strQry = "exec [usp_Mob_SchoolFeeCollectionNew_SP] @type='AllStandardOutstandingFee',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    dsdetails = sGetDataset(strQry);

                    Session["outstandingTable"] = dsObj;
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = dsObj.Tables[0];

                        GridView1.DataSource = dsObj;
                        GridView1.DataBind();

                        int total = 0; ;
                        GridView1.FooterRow.Cells[4].Text = "Total";
                        GridView1.FooterRow.Cells[4].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        for (int k = 5; k < dt1.Columns.Count; k++)
                        {
                            total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                            GridView1.FooterRow.Cells[k].Text = total.ToString();
                            GridView1.FooterRow.Cells[k].Font.Bold = true;
                            GridView1.FooterRow.BackColor = System.Drawing.Color.Beige;
                        }

                    }
                }
                catch (Exception ex)
                {

                }

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

            // stat1 = Convert.ToInt32(DropDownL1.SelectedItem.Value);
            // Div1 = Convert.ToInt32(DropDownL2.SelectedItem.Value);

            string std = DropDownL1.SelectedItem.Value;
            string div = DropDownL2.SelectedItem.Value;

            if (div == "A")
            {
                try
                {

                    strQry = "exec [usp_Mob_SchoolFeeCollectionNew_SP] @type='StandardWiseOutstandingFee',@intStandard_id='" + DropDownL1.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    dsdetails = sGetDataset(strQry);

                    Session["outstandingTable"] = dsObj;
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = dsObj.Tables[0];

                        GridView1.DataSource = dsObj;
                        GridView1.DataBind();

                        int total = 0; ;
                        GridView1.FooterRow.Cells[4].Text = "Total";
                        GridView1.FooterRow.Cells[4].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        for (int k = 5; k < dt1.Columns.Count; k++)
                        {
                            total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                            GridView1.FooterRow.Cells[k].Text = total.ToString();
                            GridView1.FooterRow.Cells[k].Font.Bold = true;
                            GridView1.FooterRow.BackColor = System.Drawing.Color.Beige;
                        }

                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                try
                {

                    strQry = "exec [usp_Mob_SchoolFeeCollectionNew_SP] @type='DivisionWiseOutstandingFee',@intDivision_id='" + div + "',@intStandard_id='" + DropDownL1.SelectedValue + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

                    //strQry = "usp_StandardMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                    dsdetails = sGetDataset(strQry);

                    Session["outstandingTable"] = dsObj;
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = dsObj.Tables[0];

                        GridView1.DataSource = dsObj;
                        GridView1.DataBind();

                        int total = 0; ;
                        GridView1.FooterRow.Cells[4].Text = "Total";
                        GridView1.FooterRow.Cells[4].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].Font.Bold = true;
                        GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                        for (int k = 5; k < dt1.Columns.Count; k++)
                        {
                            total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                            GridView1.FooterRow.Cells[k].Text = total.ToString();
                            GridView1.FooterRow.Cells[k].Font.Bold = true;
                            GridView1.FooterRow.BackColor = System.Drawing.Color.Beige;
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        catch
        {

        }
    }
}