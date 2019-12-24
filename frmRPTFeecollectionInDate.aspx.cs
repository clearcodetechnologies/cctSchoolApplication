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

public partial class frmRPTFeecollectionInDate : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strFromDate = string.Empty;
    string query1, query2, query6, query3, Disquery;
    string strToDate = string.Empty;
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
                query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                //st = sBindDropDownList(DropDownL1, query1, "Standard_name", "intStandard_id");
                st = sBindDropDownListAll(DropDownL1, query1, "Standard_name", "intStandard_id");
                DropDownL1.SelectedItem.Value = "0";
                //query2 = "Execute dbo.usp_Profile @command='RemarkDivision1',@intSchool_id='" + Session["School_id"] + "' ";
                //st2 = sBindDropDownListAll(DropDownL2, query2, "vchDivisionName", "intDivision_id");
            }
        }
        catch
        { }


    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            stat = Convert.ToInt32(DropDownL1.SelectedItem.Value);

            query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            // st2 = sBindDropDownList(DropDownL2, query2, "vchDivisionName", "intDivision_id");
            st2 = sBindDropDownListAll(DropDownL2, query2, "vchDivisionName", "intDivision_id");

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
    protected void Droptypeuser_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmExcel.aspx", true);

        //System.Threading.Thread.Sleep(2000);

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string st = Droptypeuser.SelectedItem.Value;
            string std = DropDownL1.SelectedItem.Value;
            string div = DropDownL2.SelectedItem.Value;

            if (txtFromDate.Text == "")
            {
                MessageBox("Please Select From Date!");
                txtFromDate.Focus();
                return;
            }
            if (txtToDate.Text == "")
            {
                MessageBox("Please Select To Date!");
                txtToDate.Focus();
                return;
            }

            strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            strToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            if (st == "A")
            {
                strQry = "usp_getAllFeePaidDetailsBetweenDates @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intstanderd_id='" + DropDownL1.SelectedValue + "',@intDivision_id='" + DropDownL2.SelectedValue + "'";
                dsObj = sGetDataset(strQry);
                Session["DatewiseTable"] = dsObj;
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = dsObj.Tables[0];

                    int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }


                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[8].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[0].Text = "";
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[1].Text = "";
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[3].Text = "";
                }
                else
                {
                    DataTable dt1 = dsObj.Tables[0];

                    // int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }


                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[6].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                }
            }
            else if (std == "A")
            {
                strQry = "usp_getAllFeePaidDetailsBetweenDates @command='Allstanderd',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "'";
                dsObj = sGetDataset(strQry);
                Session["DatewiseTable"] = dsObj;
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = dsObj.Tables[0];

                    //int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }

                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[8].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                }
            }
            else if (div == "A")
            {
                strQry = "usp_getAllFeePaidDetailsBetweenDates @command='AllDivision',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intstanderd_id='" + DropDownL1.SelectedValue + "'";
                dsObj = sGetDataset(strQry);
                Session["DatewiseTable"] = dsObj;
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = dsObj.Tables[0];

                    // int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }


                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[8].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                }
            }

            else
            {
                strQry = "usp_getAllFeePaidDetailsBetweenDates @command='selectstudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intstanderd_id='" + DropDownL1.SelectedValue + "',@intDivision_id='" + DropDownL2.SelectedValue + "',@intStudent_id='" + Droptypeuser.SelectedValue + "'";
                dsObj = sGetDataset(strQry);
                Session["DatewiseTable"] = dsObj;
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = dsObj.Tables[0];

                    //int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }

                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[8].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[0].Text = "";
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[1].Text = "";
                    //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[3].Text = "";
                }
                else
                {

                    DataTable dt1 = dsObj.Tables[0];

                    // int sum = 0;
                    grdFeeM.DataSource = dsObj;
                    grdFeeM.DataBind();

                    int total = 0; ;
                    grdFeeM.FooterRow.Cells[7].Text = "Total";
                    grdFeeM.FooterRow.Cells[7].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].Font.Bold = true;
                    grdFeeM.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                    for (int k = 8; k < dt1.Columns.Count; k++)
                    {
                        total = dt1.AsEnumerable().Sum(row => row.Field<Int32>(dt1.Columns[k].ToString()));
                        grdFeeM.FooterRow.Cells[k].Text = total.ToString();
                        grdFeeM.FooterRow.Cells[k].Font.Bold = true;
                        grdFeeM.FooterRow.BackColor = System.Drawing.Color.Beige;
                    }

                    //for (int i = 0; i < grdFeeM.Rows.Count; i++)
                    //{
                    //    sum += int.Parse(grdFeeM.Rows[i].Cells[6].Text);
                    //}
                    //lblTotal.Text = sum.ToString();
                }

                

            }
        }
        catch
        {
            MessageBox("Data Not Found.......");
        }
            //
        }
       
}
