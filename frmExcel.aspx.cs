using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FrmExcel : System.Web.UI.Page
{
    DataSet dsdetails;
    DataSet dsdetails1;
    DataSet dsdetailsdatewise;
    DataSet dsotherreport;
    DataSet dsstudentdeatails;
    DataSet dsteacherdetails;
    DataSet dsregistrationform;
    DataSet dsOnlinepaymentReport;
    DataSet dsOutstandingReport;

    DataSet ds = null;
    DataSet ds2 = null;
    DataSet ds3 = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dsOutstandingReport = (DataSet)Session["outstandingReportTable"];
        dsdetails = (DataSet)Session["outstandingTable"];
        dsotherreport = (DataSet)Session["otherreport"];
        dsdetails1 = (DataSet)Session["Excel"];
        dsdetailsdatewise = (DataSet)Session["DatewiseTable"];
        //allstuddsdetails = (DataSet)Session["AllstudentoutstandingTable"];
        dsstudentdeatails = (DataSet)Session["StudentDetails"];
        dsteacherdetails = (DataSet)Session["TeacherExcel"];
        dsregistrationform = (DataSet)Session["Excel"];

        dsOnlinepaymentReport = (DataSet)Session["OnlinepaymentReport"];

        ds = (DataSet)Session["BookDetailsTable"];
        ds2 = (DataSet)Session["BookHistoryDetailsTable"];
        ds3 = (DataSet)Session["BookDetailsReportTable"];

        ExportToExcel();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public void ExportToExcel()
    {
        try
        {
            if (dsdetails1 != null)
            {
                grvDetail.Visible = true;

                grvDetail.DataSource = dsdetails1;
                grvDetail.DataBind();


                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();

                string FileName = "Student" + DateTime.Now + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter strwritter;
                strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // GridView.GridLines = GridLines.Both;
                // GridView.HeaderStyle.Font.Bold = true;
                grvDetail.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Output.Write(strwritter.ToString());
                HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
                dsdetails1.Clear();

            }

            if (dsotherreport != null)
            {
                GridView2.Visible = true;

                GridView2.DataSource = dsotherreport;
                GridView2.DataBind();


                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();

                string FileName = "Student" + DateTime.Now + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter strwritter;
                strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // GridView.GridLines = GridLines.Both;
                // GridView.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Output.Write(strwritter.ToString());
                HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
                dsotherreport.Clear();

            }


            if (dsstudentdeatails != null)
            {
                try
                {
                    GridViewliststud.Visible = true;

                    GridViewliststud.DataSource = dsstudentdeatails;
                    GridViewliststud.DataBind();


                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "Student" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    GridViewliststud.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();
                    dsstudentdeatails.Clear();
                }
                catch
                {
                    HttpContext.Current.RewritePath("frmAdmListStudentDetails.aspx");
                }
            }

            

            if (dsdetails != null)
            {
                GridView1.Visible = true;
                //get datatable from view state   
                GridView1.DataSource = dsdetails;
                GridView1.DataBind();


                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();

                string FileName = "Student" + DateTime.Now + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter strwritter;
                strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // GridView.GridLines = GridLines.Both;
                // GridView.HeaderStyle.Font.Bold = true;
                GridView1.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Output.Write(strwritter.ToString());
                HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
            }

            if (dsdetailsdatewise != null)
            {
                grdFeeM.Visible = true;

                grdFeeM.DataSource = dsdetailsdatewise;
                grdFeeM.DataBind();


                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();

                string FileName = "Student" + DateTime.Now + ".xls";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter strwritter;
                strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // GridView.GridLines = GridLines.Both;
                // GridView.HeaderStyle.Font.Bold = true;
                grdFeeM.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                //Response.Output.Write(strwritter.ToString());
                HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
                // HttpContext.Current.ApplicationInstance.CompleteRequest();
                dsdetailsdatewise.Clear();
            }

            if (dsteacherdetails != null)
            {
                try
                {
                    GridView3.Visible = true;

                    GridView3.DataSource = dsteacherdetails;
                    GridView3.DataBind();


                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "Student" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    GridView3.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();
                    dsteacherdetails.Clear();
                }
                catch(Exception e)
                {
                    HttpContext.Current.RewritePath("FrmAdmTeacherProfile.aspx");
                }
            }
            if (dsregistrationform != null)
            {
                try
                {
                    grvDetail.Visible = true;

                    grvDetail.DataSource = dsregistrationform;
                    grvDetail.DataBind();


                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "Student" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    grvDetail.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();
                    dsregistrationform.Clear();
                }
                catch (Exception e)
                {
                    HttpContext.Current.RewritePath("FrmAdmTeacherProfile.aspx");
                }
            }

            if (ds2 != null)
            {
                try
                {
                    Session["BookHistoryDetailsTableDummy"] = Session["BookHistoryDetailsTable"];
                    Session["BookHistoryDetailsTable"] = null;
                    grdBookHistory.DataSource = ds2;
                    grdBookHistory.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "BookHistory" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    grdBookHistory.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();    
                }
                catch (Exception ex)
                {
                    //LogException(ex);
                    HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
                }
            }
            if (ds3 != null)
            {
                try
                {
                    Session["BookDetailsReportTableDummy"] = Session["BookDetailsReportTable"];
                    Session["BookDetailsReportTable"] = null;
                    grdBookDetailsReport.DataSource = ds3;
                    grdBookDetailsReport.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "BookDetailsReport" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    grdBookDetailsReport.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();    
                }
                catch (Exception ex)
                {
                    //LogException(ex);
                    HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
                }
            }

            if (ds != null)
            {
                try
                {
                    Session["BookDetailsTableDummy"] = Session["BookDetailsTable"];
                    Session["BookDetailsTable"] = null;
                    GridView4.DataSource = ds;
                    GridView4.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "BookDetails" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    GridView4.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();    
                }
                catch (Exception ex)
                {
                    //LogException(ex);
                    HttpContext.Current.RewritePath("frmBookDetails.aspx");
                }
            }
            if (dsOnlinepaymentReport != null)
            {
                try
                {
                    GridView5.DataSource = dsOnlinepaymentReport;
                    GridView5.DataBind();

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.ClearHeaders();

                    string FileName = "OnlinePaymentReport" + DateTime.Now + ".xls";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter strwritter;
                    strwritter = new StringWriter();
                    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    // GridView.GridLines = GridLines.Both;
                    // GridView.HeaderStyle.Font.Bold = true;
                    GridView5.RenderControl(htmltextwrtter);
                    Response.Write(strwritter.ToString());
                    //Response.Output.Write(strwritter.ToString());
                    HttpContext.Current.Response.Flush();
                    System.Web.HttpContext.Current.Response.End();
                    // HttpContext.Current.ApplicationInstance.CompleteRequest();    
                }
                catch (Exception ex)
                {
                    //LogException(ex);
                    HttpContext.Current.RewritePath("frmOnlinePaymentReport.aspx");
                }
            }
            

                if (dsOutstandingReport != null)
                {
                    try
                    {
                        GridView6.DataSource = dsOutstandingReport;
                        GridView6.DataBind();

                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearContent();
                        Response.ClearHeaders();

                        string FileName = "OutstandingReport" + DateTime.Now + ".xls";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        StringWriter strwritter;
                        strwritter = new StringWriter();
                        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

                        // GridView.GridLines = GridLines.Both;
                        // GridView.HeaderStyle.Font.Bold = true;
                        GridView6.RenderControl(htmltextwrtter);
                        Response.Write(strwritter.ToString());
                        //Response.Output.Write(strwritter.ToString());
                        HttpContext.Current.Response.Flush();
                        System.Web.HttpContext.Current.Response.End();
                        // HttpContext.Current.ApplicationInstance.CompleteRequest();    
                    }
                    catch (Exception ex)
                    {
                        //LogException(ex);
                        HttpContext.Current.RewritePath("frmOutstandingReport.aspx");
                    }
                }
          
        }
        catch  
        {
            //HttpContext.Current.RewritePath("frmAdmListStudentDetails.aspx");

        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void grvDetail_DataBound(object sender, EventArgs e)
    {

    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        intforumid = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img = (Image)e.Row.FindControl("btnDetails");
        //        img.Attributes.Add("onclick", "window.open('frmLiStudentProfile.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=1000,top=100,left=200');return false");

        //        intforumid1 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img1 = (Image)e.Row.FindControl("btnpareDetails");
        //        img1.Attributes.Add("onclick", "window.open('frmAdmPareProDetai1.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

        //        intfor3 = Convert.ToInt32(GridViewliststud.DataKeys[e.Row.RowIndex].Value);
        //        Image img3 = (Image)e.Row.FindControl("ImgEdit");
        //        img3.Attributes.Add("onclick", "window.open('frmAdmLiStudentProfile.aspx?successMessage3=" + intfor3 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=100,left=200');return false");

        //    }
        //}
        //catch
        //{
        //}

    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    public void ExportToExcelForBookHistory()
    {
        try
        {
            Session["BookHistoryDetailsTableDummy"] = Session["BookHistoryDetailsTable"];
            Session["BookHistoryDetailsTable"] = null;
            grdBookHistory.DataSource = ds2;
            grdBookHistory.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "BookHistory" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            grdBookHistory.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }
        catch (Exception ex)
        {
            //LogException(ex);
            HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
        }
    }

    public void ExportToExcelForBookDetailsReport()
    {
        try
        {
            Session["BookDetailsReportTableDummy"] = Session["BookDetailsReportTable"];
            Session["BookDetailsReportTable"] = null;
            grdBookDetailsReport.DataSource = ds3;
            grdBookDetailsReport.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();

            string FileName = "BookDetailsReport" + DateTime.Now + ".xls";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter strwritter;
            strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // GridView.GridLines = GridLines.Both;
            // GridView.HeaderStyle.Font.Bold = true;
            grdBookDetailsReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            //Response.Output.Write(strwritter.ToString());
            HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();    
        }
        catch (Exception ex)
        {
            //LogException(ex);
            HttpContext.Current.RewritePath("frmBookHistoryReport.aspx");
        }
    }

   

}