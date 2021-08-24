using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class FrmBankMaster : DBUtility
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
        strQry = "usp_bankDetails @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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
                strQry = "usp_bankDetails @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count == 0)
                {


                    strQry = "exec usp_bankDetails @command='insertbankDetails',@vchBank_name='" + Convert.ToString(txtbanknm.Text.Trim()) + "',@vchIFSC='" + Convert.ToString(txtIfsc.Text) + "',@vchBankAc_no='" + txtAcNo.Text + "',@intinserted_by='" + Session["User_id"] + "',@vchinserted_ip='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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

                strQry = "exec usp_bankDetails @command='updatebankDetails',@vchBank_name='" + Convert.ToString(txtbanknm.Text.Trim()) + "',@vchIFSC='" + Convert.ToString(txtIfsc.Text) + "',@vchBankAc_no='" + txtAcNo.Text + "',@intupdated_by='" + Session["User_id"] + "',@vchupdated_ip='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@int_ID='" + ViewState["id"] + "'";
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
        txtbanknm.Text = "";
        txtIfsc.Text = "";
        txtAcNo.Text = "";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {

        int id = Convert.ToInt32(grvDetail.DataKeys[e.NewEditIndex].Value);
        ViewState["id"] = grvDetail.DataKeys[e.NewEditIndex].Value;


        strQry = "usp_bankDetails @command='GetBankDetailsWithID',@int_ID='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtbanknm.Text = dsObj.Tables[0].Rows[0]["vchBank_name"].ToString();
            txtIfsc.Text = dsObj.Tables[0].Rows[0]["vchIFSC"].ToString();
            txtAcNo.Text = dsObj.Tables[0].Rows[0]["vchBankAc_no"].ToString();
            btnSubmit.Text = "Update";
            TabContainer1.ActiveTabIndex = 1;

        }
    }
}