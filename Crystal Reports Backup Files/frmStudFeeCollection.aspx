<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStudFeeCollection.aspx.cs" Inherits="frmStudFeeCollection" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }
        fAdmi
        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <style>
        .modalPopup {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .d-none{display:none;}
        
    </style>
    <style>
        .input-blue {
            width: 100%;
            border: 1px solid #3498db;
            margin: 8px 0px;
            /* padding: 10px 10px; */
            height: 30px;
        }

        .btns {
            float: right;
        }

        select {
            margin: 0;
        }
        .btn-sm { padding:2px 10px;
        }
        .MyTabStyle.MyTabStyle .ajax__tab_body {
        float:left;   width: 100%;
        }
        .fee-form { margin-top:20px;        width: 100%;
        }
        .fee-table {
           margin-bottom:0; }
.table.fee-table > thead > tr > th, .table.fee-table > tbody > tr > th, .table.fee-table > thead > tr > td,
 .table.fee-table > tbody > tr > td {       padding: 5px 3px;
        
        }
.chkChoice input 
{ 
    margin-left: -20px; 
}
.chkChoice td 
{ 
    padding-left: 28px; 
}
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">

        <ul class="top_nav1">
            <li><a>Fee Collection <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li class="active1"><a>Fees</a></li>
        </ul>
    </div>
    <section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>         
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
                 <section class="content pd-rl5"> 
    

  <div class="row">
    <section class="col-md-12 col-xs-12 ">
        <div class="box box-orange">
            <div class="box-body">
             <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0">                               
                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                       <HeaderTemplate> Fees Transaction </HeaderTemplate>
                         <ContentTemplate>
                         
      <div class="form-horizontal" >
         <div class="col-md-12 pd-rl5" style="margin-top: 20px;">
         <div class="form-group m-t10 ">
          <div class="col-md-1 d-none">
                <asp:Label ID="Label6" runat="server" Text="Search" CssClass="control-label"></asp:Label>                          
                </div>

            <div class="col-md-3 d-none">
                <asp:TextBox ID="txtSearch" runat="server"  CssClass="form-control" 
                         AutoPostBack="True" ontextchanged="txtSearch_TextChanged"></asp:TextBox>
                          <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearch"
                          MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="10"
                            ServiceMethod="GetSearchStudent" DelimiterCharacters="" Enabled="True" ServicePath=""></asp:AutoCompleteExtender>
                </div>
              <div class="col-md-5 pull-right">
                 <asp:GridView ID="gvfeePaid" runat="server" 
                    CssClass="mGrid" Width="100%">
                   
                </asp:GridView>
                 </div>
               
                </div>
                <div class="clearfix"></div>
            <div class="form-group">
              <div class="col-md-1"><!-- style="padding: 0px 0 0 6px;"-->
                    <asp:Label ID="Label9" runat="server" Text="Class" CssClass="control-label"></asp:Label> 
                 </div>
                 <div class="col-md-2">
                  <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="form-control"
                  onselectedindexchanged="ddlSTD_SelectedIndexChanged">
                    </asp:DropDownList>
                 </div>
                 <div class="col-md-1">
                     <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="control-label"></asp:Label> 
                 </div>
                 <div class="col-md-2">
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control"
                        AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged">
                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem  Value="Female">Female</asp:ListItem>
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                    </asp:DropDownList>
                 </div>
                 <div class="col-md-1">
                    <asp:Label ID="Label1" runat="server" Text="Name" CssClass="control-label"></asp:Label>
                 </div>
                 <div class="col-md-3">
                    <asp:DropDownList ID="ddlStudentName" runat="server" AutoPostBack="True" CssClass="form-control"
                           onselectedindexchanged="ddlStudentName_SelectedIndexChanged">
                      </asp:DropDownList>
                 </div>
                <div class="col-md-2">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Enter Serial Number"  OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </div>

            </div>
             <div class="form-group">
                <div class="col-md-1">
                    <asp:Label ID="Label2" runat="server" Text="Type" CssClass="control-label"></asp:Label>
                </div>
                 <div class="col-sm-10 col-md-10">
                                          
                    <asp:TabContainer ID="feeTypeContainer" CssClass="MyTabStyle  MyTabStyle1" runat="server" ActiveTabIndex="0">  

                    <asp:TabPanel runat="server" HeaderText="Admission Fee" ID="tabAdmissionFee">
                            <HeaderTemplate>Admission. Fee</HeaderTemplate>
                            <ContentTemplate> 
                                <div class="fee-form">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label3" runat="server" Text="Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                    <asp:TextBox ID="txtadmfee" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                                                            </div>  
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbladmcon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtadmcon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div>                                  
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblPartPayment_Admission" runat="server" Text="Remark" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtadmremark" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Admission" runat="server" CssClass="vclassrooms_send" OnClick="AddToFee_Admission_Click" />
                                    </div>
                                </div>                               
                            </ContentTemplate> 
                        </asp:TabPanel>


                     <asp:TabPanel runat="server" HeaderText="Annual Fee" ID="TabPanel2">
                            <HeaderTemplate>Annual Charges</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form">   
                                    <div class="col-md-3">
                                        <asp:Label ID="Label17" runat="server" Text="Annual Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAnnualFee" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div>
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblanucon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtanucon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&nbsp;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="Label18" runat="server" Text="Remark" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtanuualremark" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Annual" runat="server" CssClass="vclassrooms_send" OnClick="AddToFee_Annual_Click"/>
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>   
                        
                        
                         
                        <asp:TabPanel runat="server" HeaderText="Monthly Fee" ID="tabMonthlyFee" 
                         Visible="False">
                            <HeaderTemplate>Android App.Fee</HeaderTemplate>
                            <ContentTemplate> 
                                <div class="fee-form">
                                <div class="col-md-3">
                                        <asp:Label ID="Label29" runat="server" Text="Months" 
                                        CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:checkboxlist ID="chkAppmonth" runat="server" CellPadding="5" 
                                            CellSpacing="5" RepeatDirection="Horizontal" AutoPostBack="true" 
                                            RepeatColumns="12"  OnSelectedIndexChanged="trasportmnth_SelectedIndexChanged" 
                                            CssClass="chkChoice">
                                            
                                            <asp:listitem text="Apr" Value="11" />
                                            <asp:listitem text="May"  Value="12"/>
                                            <asp:listitem text="Jun"  Value="1"/>
                                            <asp:listitem text="Jul"  Value="2"/>
                                            <asp:listitem text="Aug"  Value="3"/>
                                            <asp:listitem text="Sep"  Value="4"/>
                                            <asp:listitem text="Oct"  Value="5"/>
                                            <asp:listitem text="Nov"  Value="6"/>
                                            <asp:listitem text="Dec"  Value="7"/>
                                            <asp:listitem text="Jan"  Value="8"/>
                                            <asp:listitem text="Feb"  Value="9"/>
                                            <asp:listitem text="Mar"  Value="10"/>
                                         
                                        </asp:checkboxlist> 
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label5" runat="server" Text="Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                    <asp:TextBox ID="txtandroidappfeeAmount" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                                                            </div>                                    
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label15" runat="server" Text="Remark" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtandroidfeeremark" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Android" runat="server" 
                                            CssClass="vclassrooms_send" OnClick="AddToFee_Android_Click"/>
                                    </div>
                                </div>                               
                            </ContentTemplate> 
                        </asp:TabPanel>

                         <asp:TabPanel runat="server" HeaderText="Exam Fees" ID="TabPanel12">   
                            <HeaderTemplate>Exam Fees</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form">   
                                    <div class="col-md-3">
                                        <asp:Label ID="Label27" runat="server" CssClass="control-label" 
                                            Text="Exam Amount"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_exam" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblexamcon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtexamcon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&#160;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="Label28" runat="server" CssClass="control-label" Text="Remark"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtRemark_exam" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:Button ID="AddToFee_Exam" runat="server" CssClass="vclassrooms_send" 
                                            OnClick="AddToFee_Exam_Click" text="Add To Fee" />
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>
                        
                        <asp:TabPanel runat="server" HeaderText="Tuition Fees" ID="TabPanel6">
                            <HeaderTemplate>Tuition Fees</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form"> 
                                <div class="col-md-3">
                                        <asp:Label ID="Label30" runat="server" Text="Months" 
                                        CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:CheckBoxList ID="chktuitionmonth" runat="server" AutoPostBack="true" 
                                            CellPadding="5" CellSpacing="5" CssClass="chkChoice" 
                                            OnSelectedIndexChanged="trasportmnth_SelectedIndexChanged" RepeatColumns="12" 
                                            RepeatDirection="Horizontal">
                                            
                                            <asp:ListItem text="Apr" Value="11" />
                                            <asp:ListItem text="May" Value="12" />
                                            <asp:ListItem text="Jun" Value="1" />
                                            <asp:ListItem text="Jul" Value="2" />
                                            <asp:ListItem text="Aug" Value="3" />
                                            <asp:ListItem text="Sep" Value="4" />
                                            <asp:ListItem text="Oct" Value="5" />
                                            <asp:ListItem text="Nov" Value="6" />
                                            <asp:ListItem text="Dec" Value="7" />
                                            <asp:ListItem text="Jan" Value="8" />
                                            <asp:ListItem text="Feb" Value="9" />
                                            <asp:ListItem text="Mar" Value="10" />
                                         
                                        </asp:CheckBoxList> 
                                    </div>  
                                    <div class="col-md-3">
                                        <asp:Label ID="Label25" runat="server" CssClass="control-label" 
                                            Text="Tuition Amount"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_tuition" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbltuicon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txttuicon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&#160;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="Label26" runat="server" CssClass="control-label" Text="Remark"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtremark_tuition" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:Button ID="AddToFee_Tuition" runat="server" CssClass="vclassrooms_send" 
                                            OnClick="AddToFee_tuition_Click" text="Add To Fee" />
                                    </div>
                                </div> 
                            </ContentTemplate>
                             </asp:TabPanel>
                       



                        <asp:TabPanel runat="server" HeaderText="Late Fee" ID="TabPanel5" Visible="false">
                            <HeaderTemplate>Monthly Fee</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form">                                
                                    <div class="col-md-3">
                                        <asp:Label ID="Label14" runat="server" Text="Months" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:checkboxlist ID="monthsList" runat="server" CellPadding="5" CellSpacing="5" RepeatDirection="Horizontal" AutoPostBack="true" RepeatColumns="12"  OnSelectedIndexChanged="monthsList_SelectedIndexChanged" CssClass="chkChoice">
                                            
                                            <asp:listitem text="Apr" Value="11" />
                                            <asp:listitem text="May"  Value="12"/>
                                            <asp:listitem text="Jun"  Value="1"/>
                                            <asp:listitem text="Jul"  Value="2"/>
                                            <asp:listitem text="Aug"  Value="3"/>
                                            <asp:listitem text="Sep"  Value="4"/>
                                            <asp:listitem text="Oct"  Value="5"/>
                                            <asp:listitem text="Nov"  Value="6"/>
                                            <asp:listitem text="Dec"  Value="7"/>
                                            <asp:listitem text="Jan"  Value="8"/>
                                            <asp:listitem text="Feb"  Value="9"/>
                                            <asp:listitem text="Mar"  Value="10"/>
                                         
                                        </asp:checkboxlist> 
                                    </div>
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblPayment" runat="server" Text="Monthly Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_Monthly" runat="server"  CssClass="form-control" AutoPostBack="True" Enabled="true"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Monthly" runat="server" CssClass="vclassrooms_send" OnClick="AddToFee_Monthly_Click"/>
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>  
                        <asp:TabPanel runat="server" HeaderText="Registration Fee" 
                         ID="TabPaneregfee" >
                            <HeaderTemplate>Transport Fee</HeaderTemplate>
                            <ContentTemplate> 
                                <div class="fee-form">
                                <div class="col-md-3">
                                        <asp:Label ID="Label19" runat="server" Text="Months" 
                                        CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:checkboxlist ID="trasportmnth" runat="server" CellPadding="5" 
                                            CellSpacing="5" RepeatDirection="Horizontal" AutoPostBack="true" 
                                            RepeatColumns="12"  OnSelectedIndexChanged="trasportmnth_SelectedIndexChanged" 
                                            CssClass="chkChoice">
                                            
                                            <asp:listitem text="Apr" Value="11" />
                                            <asp:listitem text="May"  Value="12"/>
                                            <asp:listitem text="Jun"  Value="1"/>
                                            <asp:listitem text="Jul"  Value="2"/>
                                            <asp:listitem text="Aug"  Value="3"/>
                                            <asp:listitem text="Sep"  Value="4"/>
                                            <asp:listitem text="Oct"  Value="5"/>
                                            <asp:listitem text="Nov"  Value="6"/>
                                            <asp:listitem text="Dec"  Value="7"/>
                                            <asp:listitem text="Jan"  Value="8"/>
                                            <asp:listitem text="Feb"  Value="9"/>
                                            <asp:listitem text="Mar"  Value="10"/>
                                         
                                        </asp:checkboxlist> 
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label33" runat="server" Text="Area" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddltransport" runat="server" AutoPostBack="True" 
                                            CssClass="form-control" 
                                            onselectedindexchanged="ddltransport_SelectedIndexChanged"> 
                                        </asp:DropDownList>
                                    </div> 
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbltranscon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txttranscon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div>                                    
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label34" runat="server" Text="Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txtamount" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Trasport" runat="server" 
                                            CssClass="vclassrooms_send" OnClick="AddToFee_Transport_Click" />
                                    </div>
                                </div>                               
                            </ContentTemplate> 
                        </asp:TabPanel>
                         <asp:TabPanel runat="server" HeaderText="Maintinance Fee" ID="TabPanel10">
                            <HeaderTemplate>Misc.</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form">   
                                    <div class="col-md-3">
                                        <asp:Label ID="Label23" runat="server" Text="Misc Amount" 
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_misc" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblmiscon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtmiscon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&#160;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="Label24" runat="server" CssClass="control-label" Text="Remark"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtRemark_misc" runat="server" AutoPostBack="True" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:Button ID="AddToFee_Misc" runat="server" CssClass="vclassrooms_send" 
                                            OnClick="AddToFee_Misc_Click" text="Add To Fee" />
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>

                          
                          <asp:TabPanel runat="server" HeaderText="photo Insurance" ID="tabLateFee">
                            <HeaderTemplate>Photo &amp; Insurance</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form"> 
                                <%--<div class="col-md-3">
                                        <asp:Label ID="Label31" runat="server" Text="Months" 
                                        CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:checkboxlist ID="mnthlistphoto" runat="server" CellPadding="5" 
                                            CellSpacing="5" RepeatDirection="Horizontal" AutoPostBack="true" 
                                            RepeatColumns="12"  OnSelectedIndexChanged="trasportmnth_SelectedIndexChanged" 
                                            CssClass="chkChoice">
                                            
                                            <asp:listitem text="Apr" Value="11" />
                                            <asp:listitem text="May"  Value="12"/>
                                            <asp:listitem text="Jun"  Value="1"/>
                                            <asp:listitem text="Jul"  Value="2"/>
                                            <asp:listitem text="Aug"  Value="3"/>
                                            <asp:listitem text="Sep"  Value="4"/>
                                            <asp:listitem text="Oct"  Value="5"/>
                                            <asp:listitem text="Nov"  Value="6"/>
                                            <asp:listitem text="Dec"  Value="7"/>
                                            <asp:listitem text="Jan"  Value="8"/>
                                            <asp:listitem text="Feb"  Value="9"/>
                                            <asp:listitem text="Mar"  Value="10"/>
                                         
                                        </asp:checkboxlist> 
                                    </div>--%>  
                                    <div class="col-md-3">
                                        <asp:Label ID="Label35" runat="server" Text="Photo & Insurance" 
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_Photo" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblphotocon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtphotocon" runat="server" Text="0"  CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&nbsp;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="Lblphotormk" runat="server" Text="Remark" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtphotormk" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Photo" runat="server" 
                                            CssClass="vclassrooms_send" OnClick="AddToFee_photo_Click"/>
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>  
                        

                        <asp:TabPanel runat="server" HeaderText="Late Fee" ID="TabPanel4">
                            <HeaderTemplate>Late Fees</HeaderTemplate>
                            <ContentTemplate>   
                                <div class="fee-form">   
                                    <div class="col-md-3">
                                        <asp:Label ID="Label11" runat="server" Text="Late Amount" 
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAmount_Late" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div>
                                    <div class="clearfix col-md-12">&nbsp;</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lbllatecon" runat="server" Text="Concession Amount" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtlatecon" runat="server" Text="0" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix col-md-12">&nbsp;</div>                      
                                    
                                    <div class="col-md-3">
                                        <asp:Label ID="lblRemark_Late" runat="server" Text="Remark" 
                                            CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtRemark_Late" runat="server"  CssClass="form-control" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </div> 
                                    <div class="clearfix"></div>
                                    <div class="col-md-3">
                                        <asp:button text="Add To Fee" ID="AddToFee_Late" runat="server" 
                                            CssClass="vclassrooms_send" OnClick="AddToFee_Late_Click"/>
                                    </div>
                                </div> 
                            </ContentTemplate> 
                        </asp:TabPanel>  

                          
                        

                         


                        
                                            
                    </asp:TabContainer>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-1">
                </div>
                <div class="col-md-9">
                    <asp:GridView ID="grdPayments" CssClass="table tabular-table fee-table" 
                        runat="server" AutoGenerateColumns="False" 
                        OnRowCommand="grdPayments_RowCommand" OnRowDeleting="grdPayments_RowDeleting">                        
                        <columns>
                            <asp:boundfield datafield="FeeType" headertext="Fee Type"/>
                            <asp:boundfield datafield="Remark" headertext="Remark" />
                            <asp:boundfield datafield="Amount" headertext="Amount"/>
                            <asp:boundfield datafield="ConcessionAmount" headertext="Concession Amount"/>
                            <asp:boundfield datafield="TotalAmount" headertext="Total Amount"/>
                            <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="delete">
                            <controlstyle cssclass="btn btn-sm btn-primary" />
                            </asp:ButtonField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
            <div class="col-md-1">
                     <asp:Label ID="lblMonths" runat="server" Text="Months" Visible="False" CssClass="control-label"></asp:Label>
                </div>
                <div>                    
                        <asp:Panel ID="monthsPanel" runat="server" Visible ="False"></asp:Panel>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlMonths" runat="server" Visible="False" CssClass="form-control"
                        onselectedindexchanged="ddlMonths_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                <asp:Label ID="lblToMonth" runat="server" Text="To Month" Visible="False" CssClass="control-label"></asp:Label> 
                </div>
                <div class="col-md-2">
                <asp:DropDownList ID="drpToMonth" runat="server" AutoPostBack="True" Visible="False" CssClass="form-control"
                     OnSelectedIndexChanged="drpToMonth_SelectedIndexChanged">
                    <asp:ListItem Text="---Select To Month---" Value="0"></asp:ListItem>                           
                </asp:DropDownList>
                </div>

                <div class="col-md-1">
                     <asp:Label ID="Label4" runat="server" Text="Fee Head" CssClass="control-label" 
                        Visible="False"></asp:Label>
                </div>
                <div class="col-md-5">
                 <asp:GridView ID="gvHead" runat="server" AutoGenerateColumns="False" 
                    CssClass="mGrid" DataKeyNames="intTutionId" Width="100%" Visible="False">
                    <Columns>
                        <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvMonthlyMulti" runat="server" AutoGenerateColumns="False" Visible="False"
                    CssClass="mGrid" DataKeyNames="intTutionId" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvYearly" runat="server" AutoGenerateColumns="False" Visible="False"
                    CssClass="mGrid" DataKeyNames="intTutionId" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvOneTime" runat="server" AutoGenerateColumns="False" Visible="False"
                    CssClass="mGrid" DataKeyNames="intTutionId" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="intTutionId" HeaderText="Id" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Particulars">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("intFee_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="numAmount" HeaderText="Amount" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                <asp:DropDownList ID="ddlFeeHead" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlFeeHead_SelectedIndexChanged" Visible="False">
                </asp:DropDownList>
                </div>
                
            <!--</div>
            <div class="form-group">-->
              <div class="col-md-1">
                 <asp:Label ID="lblInstallment" runat="server" Text="Payment Type" Visible="False" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                <asp:DropDownList ID="ddlInstallment" runat="server" Visible="False" AutoPostBack="True"
                        CssClass="form-control" 
                        onselectedindexchanged="ddlInstallment_SelectedIndexChanged" >
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem> 
                 <asp:ListItem Text="Full Payment" Value="1"></asp:ListItem> 
                  <asp:ListItem Text="Part Payment" Value="2"></asp:ListItem> 
                   </asp:DropDownList>
                </div>
                  <div class="col-md-1">
            <asp:Label ID="lblPartAmt" runat="server" Text="Part Amount" CssClass="control-label" Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtPartAmount" runat="server"  CssClass="form-control" 
                    Visible="False" AutoPostBack="True" ontextchanged="txtPartAmount_TextChanged"></asp:TextBox>
            </div>
                <div class="col-md-1">
                 <asp:Label ID="lblYearly" runat="server" Text="Year" Visible="False" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                <asp:DropDownList ID="ddlYearly" runat="server" Visible="False" CssClass="form-control" >
                   </asp:DropDownList>
                </div>
                <div class="col-md-1">
                 <asp:Label ID="lblOneTime" runat="server" Text="One Time" Visible="False" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                <asp:DropDownList ID="ddlOneTime" runat="server" Visible="False" CssClass="form-control" >
                                                                            </asp:DropDownList>
                </div>
                <div class="col-md-1">
                <asp:Label ID="Label8" runat="server" Text="Head Amt" Visible="False" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                <asp:TextBox ID="txtHeadAmt" runat="server" CssClass="form-control"
                   Visible="False"></asp:TextBox>
                </div>
                <div class="col-md-1">
                <asp:Label ID="lblEnterAmt" runat="server" Text="Monthly Amount" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                 <asp:TextBox ID="txtEnterAmt" runat="server" CssClass="form-control" Visible="False"
                    Enabled="False"></asp:TextBox>
                </div>
            <!--</div>
            <div class="form-group">-->
            <div class="col-md-1">
                <asp:Label ID="lblYearlyamt" runat="server" Text="Yearly Amount" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-md-2">
             <asp:TextBox ID="txtYearlyAmt" runat="server" CssClass="form-control" Visible="False"
                                                                                Enabled="False"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lblOneTimeAmt" runat="server" Text="One Time Amount" Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="txtOneTimeAmt" runat="server" CssClass="form-control" Visible="False"
                  Enabled="False"></asp:TextBox>
            </div>
            <div class="col-md-1">
               <asp:Label ID="lblOtherAmt" runat="server" Text="Other Amount" Visible="False" CssClass="control-label"></asp:Label>
            </div>
            <div class="col-md-2">
             <asp:TextBox ID="txtOtherAmt" runat="server" CssClass="form-control" Visible="False" 
                AutoPostBack="True" ontextchanged="txtOtherAmt_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-1">
            <asp:Label ID="Label16" runat="server" Text="Total Amount" CssClass="control-label" 
                    Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
                 <asp:TextBox ID="txtTotalAmt" runat="server"  CssClass="form-control" 
                    Enabled="False" Visible="False"></asp:TextBox>
            </div>
            </div>
            <div class="form-group">
                <div class="col-md-1" style="display:none">
                      <asp:Label ID="Label12" runat="server" Text="Late Fee" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2" style="display:none">
                 <asp:TextBox ID="txtLateFee" runat="server"  CssClass="form-control" 
                        AutoPostBack="True" ontextchanged="txtLateFee_TextChanged" ></asp:TextBox>
                </div>
                
                <div class="col-md-1" style="padding:0 2px;">
                <asp:Label ID="Label7" runat="server" Text="Pay Amount" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                 <asp:TextBox ID="txtAfterDiscount" runat="server" CssClass="form-control"
                         Enabled="False"></asp:TextBox>
                </div>
                <div class="col-md-1" style="padding:0 5px;"> 
             <asp:Label ID="Label13" runat="server"  CssClass="control-label" Text="Pay Mode"></asp:Label>           
            </div>
            <div class="col-md-2">
            <asp:DropDownList ID="drpPayMode" runat="server" AutoPostBack="True"  CssClass="form-control"
                OnSelectedIndexChanged="drpPayMode_SelectedIndexChanged">
                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                <asp:ListItem Text="Cheque" Value="2"></asp:ListItem>
                <asp:ListItem Text="Bank" Value="3"></asp:ListItem>
            </asp:DropDownList>
            </div>
                 <div class="col-md-2"><asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" 
                         OnClick="btnSubmit_Click" Text="Pay" /></div>
               
            </div>
            <div class="form-group">
            <div class="col-md-1" style="padding:0 3px; ">
              <asp:Label ID="lblc3" runat="server"  CssClass="control-label" Text="Bank Name" 
             Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="txtBankName" runat="server" 
            CssClass="form-control" Font-Names="Verdana" ForeColor="Black" Visible="False"></asp:TextBox>
            </div>

            <div class="col-md-1" style="padding:0 5px; ">
            <asp:Label ID="lblc1" runat="server" CssClass="control-label" Text="Cheque No" 
                Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtChequeNo" runat="server" 
                   CssClass="form-control" Font-Names="Verdana" ForeColor="Black" Visible="False"></asp:TextBox>
            </div>
            <div class="col-md-1" style="padding:0 0px; font-size: 13px; ">
              <asp:Label ID="lblc2" runat="server"  CssClass="control-label" Text="Cheque Date" 
                                                                                Visible="False"></asp:Label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="txtChequeDate" runat="server" 
                 CssClass="form-control" Font-Names="Verdana" ForeColor="Black" Visible="False"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                Format="dd/MM/yyyy" TargetControlID="txtChequeDate">
            </asp:CalendarExtender>
            </div>
                       
            </div>
            <div class="form-group">
            <div class="col-md-1">
            <asp:Label ID="lblRemark" runat="server" CssClass="control-label" Text="Remark" 
                    Visible="False"></asp:Label>
            </div>
            <div class="col-md-6">
             <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" 
                    Font-Names="Verdana" ForeColor="Black" Visible="False"></asp:TextBox>
            </div> 
            </div>
            </div>
            <div class="form-group">
            
            <div class="col-md-2">
                <asp:Button ID="btnReport" runat="server" CssClass="vclassrooms_send" 
                        OnClick="btnReport_Click"  Text="Receipt" Visible="False" />
            </div>
            </div>

            <CR:CrystalReportViewer ID="StudentDetails" runat="server" 
              AutoDataBind="True" GroupTreeImagesFolderUrl="" ToolbarImagesFolderUrl="" 
              ToolPanelWidth="200px" />
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
              AutoDataBind="True" GroupTreeImagesFolderUrl="" ToolbarImagesFolderUrl="" 
              ToolPanelWidth="200px"></CR:CrystalReportViewer>
           
                 <div class="col-md-2">
                    <asp:DropDownList ID="ddlGvType" runat="server" CssClass="form-control"
                        AutoPostBack="True" onselectedindexchanged="ddlGvType_SelectedIndexChanged" 
                         Visible=False>
                        <asp:ListItem Value="0">---Select Type---</asp:ListItem>
                        <asp:ListItem  Value="3">Monthly</asp:ListItem>
                        <asp:ListItem Value="2">Session</asp:ListItem>
                         <asp:ListItem Value="1">Admission</asp:ListItem>
                    </asp:DropDownList>
                 </div>
            <div class="col-md-12">
            <asp:GridView ID="grdTrans" runat="server" AutoGenerateColumns="False" 
            CssClass="table  tabular-table " DataKeyNames="Receipt_Id,feeFate,dtTime,intID" 
            EmptyDataText="No Data Found" OnRowDeleting="grdTrans_RowDeleting" 
            Width="90%" onrowediting="grdTrans_RowEditing">
            <Columns>
                <asp:BoundField DataField="Receipt_Id" HeaderText="Tran Id" ReadOnly="True" />
                <asp:BoundField DataField="feeFate" HeaderText="Date" ReadOnly="True" />  
                <asp:BoundField DataField="vchFee" HeaderText="Fee Type" ReadOnly="True" />                                                                             
                <asp:BoundField DataField="intAfterDiscount" HeaderText="Amount" ReadOnly="True" />
                <asp:BoundField DataField="FromMonth" HeaderText="Month" ReadOnly="True" />                                                                                   
                <asp:BoundField DataField="intPayMode" HeaderText="Payment Mode" ReadOnly="True" />
                                                                                                                                                              
                <asp:TemplateField HeaderText="Print">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                            ImageUrl="~/images/print.png" />
                    </ItemTemplate>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
<asp:Label ID="lblTotal" runat="server" Visible="False"></asp:Label>
            </div>

         </div>
      </div>
                         </ContentTemplate>
                      </asp:TabPanel>

                      <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel3">
                       <HeaderTemplate> Fees details </HeaderTemplate>
                         <ContentTemplate>
                         <div class="col-md-12 pd-rl5" style="margin-top: 20px;">
              <div class="clearfix"></div>
            <div class="form-group">
              <div class="col-md-1"><!-- style="padding: 0px 0 0 6px;"-->
                    <asp:Label ID="Label20" runat="server" Text="Class" CssClass="control-label"></asp:Label> 
                 </div>
                 <div class="col-md-2">
                  <asp:DropDownList ID="detailddlSTD" runat="server" AutoPostBack="True" CssClass="form-control"
                  onselectedindexchanged="detailddlSTD_SelectedIndexChanged">
                    </asp:DropDownList>
                 </div>
                  <div class="col-md-1"><!-- style="padding: 0px 0 0 6px;"-->
                    <asp:Label ID="Label21" runat="server" Text="Gender" CssClass="control-label"></asp:Label> 
                 </div>
                 <div class="col-md-2">
                  <asp:DropDownList ID="detailddlgender" runat="server" AutoPostBack="True" CssClass="form-control"
                  onselectedindexchanged="detailddlgender_SelectedIndexChanged">
                                                 <asp:ListItem Value="0">---Select---</asp:ListItem>
                        <asp:ListItem  Value="Female">Female</asp:ListItem>
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                    </asp:DropDownList>
                 </div>

                 <div class="col-md-1">
                    <asp:Label ID="Label22" runat="server" Text="Name" CssClass="control-label"></asp:Label>
                 </div>
                 <div class="col-md-3">
                    <asp:DropDownList ID="detailddlStudentName" runat="server" AutoPostBack="True" CssClass="form-control"
                           onselectedindexchanged="detailddlStudentName_SelectedIndexChanged">
                      </asp:DropDownList>
                 </div>
                 <div class="col-md-2">
                <asp:TextBox ID="txtSearchVal" runat="server" CssClass="form-control" AutoPostBack="True" placeholder="Enter Serial Number"  OnTextChanged="txtSearchVal_TextChanged"></asp:TextBox>
                </div>
                
            </div>
            <center>
            <div class="col-md-12 pd-rl5" style="margin-top: 20px;">

                                                            <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" DataKeyNames="Receipt_Id"
                                                                OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing">
                                                                <Columns>
                                                                <asp:BoundField DataField="Receipt_Id" HeaderText="Receipt Id" ReadOnly="True" />
                                                                 <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                 <%--<asp:BoundField DataField="intTutionID" HeaderText="Fee Type" ReadOnly="True" />--%>
                                                                 <%--<asp:BoundField DataField="Month_Name" HeaderText="Month Name" ReadOnly="True" />--%>
                                                                   <asp:BoundField DataField="intPaidAmt" HeaderText="Paid Amount" ReadOnly="True" />
                                                                   <%--<asp:BoundField DataField="intPendingAmt" HeaderText="Pending Amount" ReadOnly="True" />
                                                                   <asp:BoundField DataField="intTotalAmt" HeaderText="Total Amount" ReadOnly="True" />--%>
                                                                   <asp:BoundField DataField="feeFate" HeaderText="Paid Date" ReadOnly="True" />
                                                                   <asp:BoundField DataField="vchremark" HeaderText="Remark" ReadOnly="True" />
<%--                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Print">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To print Selected Record?');" ImageUrl="~/images/print.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div>
                       </center>
            </div>
                         </ContentTemplate>
                         </asp:TabPanel>
              </asp:TabContainer>   
            </div>
        </div>
    </section>
    </div>
</section>
  
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

