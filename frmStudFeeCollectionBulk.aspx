<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStudFeeCollectionBulk.aspx.cs" Inherits="frmStudFeeCollection" %>

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

    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>

  <style type="text/css">
  .hiddencol
  {
    display: none;
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
                     <asp:Label ID="Label10" runat="server" Text="Division" CssClass="control-label"></asp:Label> 
                 </div>
                  <div class="col-md-2">
                  <asp:DropDownList ID="ddlDiv" runat="server" AutoPostBack="True" CssClass="form-control"
                  onselectedindexchanged="ddlDiv_SelectedIndexChanged">
                    </asp:DropDownList>
                 </div>
                 <div class="col-md-1">
                    <asp:Label ID="Label1" runat="server" Text="Month" CssClass="control-label" Visible="false"></asp:Label>
                 </div>
                     <div class="col-md-3">
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" Visible="false"
                           onselectedindexchanged="ddlmonth_SelectedIndexChanged" > 
                           <asp:listitem text="---Select---"  Value="0"/>
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
                                                    
                      </asp:DropDownList>

                     
                 </div>
                 
                
            </div>
            <div class="form-group">
            
            <asp:GridView ID="grdstudent" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table" DataKeyNames="intStudFee_id"
                                            
                                            EmptyDataText="No Records Found" Width="100%">
                                            <Columns>
                                            <asp:TemplateField>
                                            <HeaderTemplate>  
                                                    <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" />
                                                     </HeaderTemplate>
                                                
                                                    <ItemTemplate>
                                                     <asp:CheckBox ID="chkCtrl" AutoPostBack="true" runat="server"  /> <%--OnCheckedChanged="chkctrlchanged"--%> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="intStudent_id" HeaderText="intStudent_id" Visible="true" />
                                                <asp:BoundField DataField="intStudentID_Number" HeaderText="Student ID" Visible="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Student Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NetAmount" HeaderText="Total Fee" >
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="Month" HeaderText="Months" >
                                                <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                             
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>


                                         <asp:GridView ID="grdStudentsFee" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table" DataKeyNames="intStudent_id"
                                            
                                            EmptyDataText="No Records Found" Width="100%">
                                            <Columns>
                                            <asp:TemplateField>
                                            <HeaderTemplate>  
                                                    <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" />
                                                     </HeaderTemplate>
                                                
                                                
                                                    <ItemTemplate>
                                                     <asp:CheckBox ID="chkCtrl" AutoPostBack="true" runat="server"  /> <%--OnCheckedChanged="chkctrlchanged"--%> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="intStudent_id" HeaderText="intStudent_id" ItemStyle-CssClass="hiddencol"/>
                                                <asp:BoundField DataField="intStudentID_Number" HeaderText="Student ID" Visible="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Student Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="netamt" HeaderText="Total Month Fee">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                              
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>

            
            </div>
             <div class="form-group">
                <div class="col-md-1">
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="control-label"></asp:Label>
                </div>
                 <div class="col-sm-10 col-md-10">
                   
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="vclassrooms_send"
                    onclick="btnSubmit_Click" />


                </div>
            </div>
            <div class="form-group" >
                <div class="col-md-1">
                </div>
                <div class="col-md-9">
                 
                </div>
            </div>
           

         </div>
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

