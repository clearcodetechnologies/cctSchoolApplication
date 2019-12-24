using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class hrPayHeadType : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string st = Request.QueryString["successMessage"];
            string st1 = Request.QueryString["successMessage1"];
            fGrid();

        }
    }

    protected void fGrid()
    {

        strQry = "SpHrPayHead @command='select'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            //txtName.Text = "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            string tPayHead = Convert.ToString(txtPayHead.Text);
            string tDescription = Convert.ToString(txtDescription.Text);
            string dlAddition = Convert.ToString(ddlAddition.SelectedValue.ToString());
            string Inserted_datee = DateTime.Now.ToString("MM/dd/yyyy");
            long? insertby = null;
            if (btnSubmit.Text == "Submit")
            {
                if (insertby.HasValue)
                {
                    insertby = Convert.ToInt64(Session["User_id"]);
                }

                string ipval = GetSystemIP();

                string instrquery1 = "Execute dbo.SpHrPayHead @command='insertPayHead',@intUserTypeId='" + Session["UserType_id"]+ "', @vchPayHeadName='" + tPayHead + "',@vchDescription='" + tDescription + "',@intAddition='" + dlAddition + "',@Inserted_date='" + Inserted_datee + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + ipval + "',@intSchool_id='" + Session["School_Id"] + "'";
                int str = sExecuteQuery(instrquery1);


                if (str != -1)
                {
                    string display = "Pay Head  Saved!!";
                    MessageBox(display);
                    Clear();
                    //fGrid();
                }
            }
            else
            {

                //@vchPayHeadName,@vchDescription,@intAddition,@intUpdate_id,@IntUpdate_IP,@PayHead_Id, @intInserted_by
                strQry = "exec SpHrPayHead  @command='Update',@vchPayHeadName='" + tPayHead + "',@vchDescription='" + tDescription + "',@intAddition='" + dlAddition + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "',@PayHead_Id='" + Convert.ToString(Session["PayHead_Id"]) + "',@intInserted_by='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    Clear();
                    btnSubmit.Text = "Submit";
                    fGrid();
                }


                // MessageBox("ooopppsss!Pay Head  Saved failed");



            }
        }

        catch (Exception ex)
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
    protected void Clear()
    {
        txtPayHead.Text = "";
        txtDescription.Text = "";
        ddlAddition.SelectedValue = "";

    }



    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
            fGrid();
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
            ViewState["PayHead_Id"] = id;
            //intDelete_by,DeleteIP
            //PayHead_Id= @PayHead_Id and intInserted_by=@intInserted_by 
            strQry = "exec SpHrPayHead  @command='Delete',@intDelete_by='" + Convert.ToString(Session["School_id"]) + "',@DeleteIP='" + GetSystemIP() + "',@PayHead_Id='" + Convert.ToString(id) + "',@intInserted_by='" + Session["User_id"] + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                fGrid();
            }
        }
        catch
        {

        } 



    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {


        try
        {

            strQry = "";
            Session["PayHead_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
           
            strQry = "exec SpHrPayHead  @command='FillGrid',@PayHead_Id='" + Convert.ToString(Session["PayHead_Id"]) + "',@intInserted_by='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                txtPayHead.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPayHeadName"]);
                txtDescription.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);
                ddlAddition.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intAddition"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";


             
            }
        }
        catch
        {

        }

    }
}