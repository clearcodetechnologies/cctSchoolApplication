<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmMessaging.aspx.cs" Inherits="frmMessaging" Title="Messaging" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Messaging </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Messaging</a></li>
              <li class="breadcrumb-item active"> Messaging</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 
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
    <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Details</a>
                    </li>
                    
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <h3 class="text-center">Send Message</h3>
                      <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="User Type"></asp:Label> 
                                    <asp:DropDownList ID="drpUserType" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged">
                                       <asp:ListItem>---select---</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpUserType"
                                        Display="None" ErrorMessage="Please Enter Standard"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                             </div>

                             <div class="row" visible="false" id="Numbers" runat="server">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="Numbers"></asp:Label> 
                                    <asp:TextBox ID="txtNumbers" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    
                                </div>
                             </div>
                             </div>
                             <div class="row" visible="false" id="trStudent" runat="server">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                       <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                    
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label2" class="col-form-label" runat="server" Text="Section"></asp:Label> 
                                    <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpDivision_SelectedIndexChanged">
                                       <asp:ListItem>---select---</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                             
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label5" class="col-form-label" runat="server" Text="Gender"></asp:Label> 
                                    <asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                                       <asp:ListItem>---select---</asp:ListItem>
                                       <asp:ListItem  Value="Female">Female</asp:ListItem>
                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                             </div>

                              <div class="row" visible="false" id="trStaff" runat="server">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label6" class="col-form-label" runat="server" Text="Department"></asp:Label> 
                                    <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                       <asp:ListItem>---select---</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                             </div>

                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label7" class="col-form-label" runat="server" Text="Notice"></asp:Label> 
                                    <asp:TextBox ID="txtNotice" TextMode="MultiLine" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    
                                </div>
                             </div>
                             </div>

                             <div class="row">
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grdMessage" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="ID,Name,Mobile,FCMToken" >
                                    <Columns>                                                                 
                                        <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                <HeaderTemplate>  
                                                    <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="chckchanged" runat="server" />
                                                     </HeaderTemplate>
                                                    <ItemTemplate>
                                                     <asp:CheckBox ID="chkCtrl" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile No">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                                 
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgEdit" runat="server" CssClass="gbtn-edit" CommandName="Edit" CausesValidation="false"
                                                    ImageUrl="~/images/edit.svg" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CssClass="gbtn-delete" CommandName="Delete" CausesValidation="false"
                                                    OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.svg" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div>
                        </div> 

                        <div class="col-lg-3 col-md-4 col-sm-6">
                                 <asp:Button ID="btnSMS" runat="server" CssClass="btn btn-success btn-sm mt-18" OnClick="btnSMS_Click" OnClientClick="return ConfirmInsertUpdate();"
                                    Text="Submit"/>
                                <asp:Button ID="btnClear" runat="server" CausesValidation="False"  CssClass="btn btn-danger btn-sm mt-18"
                                    Text="Clear" Visible="False" />
                                </div>

                        </div>
                      </div>
                     
                     
                       </div>
                    </div>

                </div>
            </div>
         </div>
       </div>
     </section>               
 </ContentTemplate>
            </asp:UpdatePanel>

 
           <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server"  
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" CssClass="vclassrooms" ID="tab" runat="server">
                                         
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"> 
                                    </asp:TabPanel>
                                </asp:TabContainer>
                         
    
</asp:Content>
