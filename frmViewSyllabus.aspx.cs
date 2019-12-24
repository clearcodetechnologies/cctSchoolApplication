using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class frmViewSyllabus : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillExam();
            fillSubject();
            FillSTD();
        }
    }
    public void FillSTD()
    {
        try
        {

            strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
           
            sBindDropDownList(ddlSTD4, strQry, "vchStandard_name", "intstandard_id");
            //FillDIV();
          

            ddlSTD4.Items.Insert(0, new ListItem("All", "-1"));
            ddlSTD4.SelectedValue = "-1";
        }
        catch
        {

        }
    }
    protected void fillExam()
    {
        strQry = "exec usp_Syllabus_Master @type='ExamDet',@intSchool_id='" + Session["School_id"] + "'";
        bool flg = sBindDropDownList(drpExam, strQry, "vchExamination_name", "intExam_id");

    }
    protected void fillSubject()
    {
        strQry = "exec [usp_Syllabus_Master] @type='FillSubjectAll',@intStandard_id='" + Session["Standard_id"] + "'";
        bool flg = sBindDropDownList(drpSubject, strQry, "vchSubjectName", "intSubject_id");
    }

    protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        //strQry = "exec [usp_Syllabus_Master] @type='FillGridSyllabus',@intExam_id='" + drpExam.SelectedValue.Trim() + "',@intSubject_id='" + drpSubject.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'  ";
        //dsObj = sGetDataset(strQry);
        strQry = "exec usp_Syllabus_Master @type='FillSyallbusGrid',@intSchool_id='" + Session["School_id"] + "'";  //change by kranti
        if (ddlSTD4.SelectedValue == "-1")
        {
            // ddlDIV4.SelectedValue = "-1";
            drpSubject.SelectedValue = "-1";
        }
        //else if (ddlDIV4.SelectedValue == "-1")
        //{
        //    ddlSub4.SelectedValue = "-1";
        //    strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "'";
        //}
        else if (drpSubject.SelectedValue == "-1")
        {
            strQry = "exec usp_Syllabus_Master @type='FillSyallbusGridAll'";
            //strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "'";//,@intDiv_id='" + Convert.ToString(ddlDIV4.SelectedValue) + "'";
            strQry = strQry + ",@intStandard_id='" + ddlSTD4.SelectedValue + "'"; //change by kranti
        }
        else
        {
            //strQry = strQry + ",@intSTD_id='" + ddlSTD4.SelectedValue + "',@intSubject_id='" + Convert.ToString(ddlSub4.SelectedValue) + "'";
            strQry = strQry + ",@intStandard_id='" + ddlSTD4.SelectedValue + "',@intSubject_id='" + Convert.ToString(drpSubject.SelectedValue) + "'"; //change by kranti

        }
        dsObj = new DataSet();
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = dsObj;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
        else
        {
            GridView1.DataSource = dsObj;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Session["id"]=GridView1.SelectedRow.Cells[1].Text;
            //Response.Redirect("frmsyllabus.aspx", true);

            //int id = int.Parse((sender as LinkButton).CommandArgument);
            int id = int.Parse(GridView1.SelectedRow.Cells[1].Text);
            string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"1000px\" height=\"600px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            ltEmbed.Text = string.Format(embed, ResolveUrl("~/FileCS.ashx?Id="), id);

        }
        catch (Exception ex)
        {

        }
        //try
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["esmsSKP"].ConnectionString;
        //    SqlConnection con = new SqlConnection(constr);
        //    con.Open();
        //    SqlCommand com = new SqlCommand("select * from tblexport where id=@id", con);
        //    com.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[1].Text);
        //    SqlDataReader dr = com.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.ContentType = dr["ContentType"].ToString();
        //        Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString()); // to open file prompt Box open or Save file  
        //        Response.Charset = "";
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.BinaryWrite((byte[])dr["data"]);
        //        HttpContext.Current.ApplicationInstance.CompleteRequest();

        //    }
        //}
        //catch (Exception ex)
        //{

        //}
    } 

    protected void grvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                ImageButton View = (ImageButton)e.CommandSource;
                string id = Convert.ToString(Convert.ToString(e.CommandArgument.ToString()));
                Session["path"] = null;
                Session["path"] = Convert.ToString(id);

                //string path = "~//Documents/Holiday//";
                ////    //  string a =e.Row.c
                ////    View.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=" + path + "&DocName=" + Session["id"].ToString() + ",'_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                ////    View.Attributes.Add("onclick", "window.open('frmTrainingDetail.aspx?TrainingId=12','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                string FilePath = string.Empty;
                if (Convert.ToString(Session["path"]) != "")
                {
                    FilePath = Server.MapPath(Session["Path"].ToString());
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(FilePath);
                    FileInfo file = new FileInfo(FilePath);
                    System.Diagnostics.Process.Start(file.ToString());
                    //Response.Redirect("frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~","") + "");
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~", "") + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                    //View.Attributes.Add("onclick", "window.open('frmviewSyllabusDoc.aspx?Path=" + Convert.ToString(Session["path"]).Replace("~", "") + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
                }
                else
                {
                    MessageBox("No Document found");
                }
            }
        }
        catch(Exception ex)
        {

        }
    }
}