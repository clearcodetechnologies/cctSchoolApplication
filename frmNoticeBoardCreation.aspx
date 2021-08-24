<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmNoticeBoardCreation.aspx.cs" Inherits="frmNoticeBoardCreation" Title="VClassrooms - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <script type="text/javascript">
function funcswitchtab() {
    $('#tab2').trigger('click')
    $("#tab2Entry").addClass("active show");
    $("#custom-tabs-five-overlay-tab").removeClass("active");
    $("#custom-tabs-five-overlay").removeClass("show").removeClass("active");
}         
</script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Notice Board </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Notice Board</a></li>
              <li class="breadcrumb-item active"> Notice Board</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false">New Entry</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                                
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grdNotice" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intNotice_id" OnRowDeleting="grdNotice_RowDeleting" 
                                                     OnRowEditing="grdNotice_RowEditing">
                                    <Columns>                                                                 
                                        <asp:BoundField DataField="Subject" HeaderText="Subject" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="Notice" HeaderText="Notice" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="Issue_Date" HeaderText="Issue Date" ReadOnly="True">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         </asp:BoundField>
                                                         <asp:BoundField DataField="End_Date" HeaderText="Last Date" ReadOnly="True">
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
                      </div>
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="User Type"></asp:Label> 
                                    <asp:DropDownList ID="drpUserType" runat="server" CssClass="form-control" AutoPostBack="True" >
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpUserType"
                                        Display="None" ErrorMessage="Please Enter User Type"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="drpStandard" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpStandard"
                                        Display="None" ErrorMessage="Please Enter Standard"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" runat="server"  class="col-form-label"  Text="Issue Date"></asp:Label> 
                                   <asp:TextBox ID="txtfromdate" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtfromdate"
                                        Display="None" ErrorMessage="Please Enter Exam"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                     <asp:CalendarExtender ID="calfrom" runat="server" Enabled="True" 
                                                        Format="dd/MM/yyyy" TargetControlID="txtfromdate">
                                                    </asp:CalendarExtender>
                                </div>
                             </div>
                             </div>
                             <div class="row">
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label5" runat="server"  class="col-form-label"  Text="End Date"></asp:Label> 
                                   <asp:TextBox ID="txtTodate" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTodate"
                                        Display="None" ErrorMessage="Please Enter Passing Marks"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtTodate">
                                                </asp:CalendarExtender>
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label6" runat="server"  class="col-form-label"  Text="Subject"></asp:Label> 
                                   <asp:TextBox ID="txtSubject" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSubject"
                                        Display="None" ErrorMessage="Please Enter Subject"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label3" runat="server"  class="col-form-label"  Text="Notice"></asp:Label> 
                                   <asp:TextBox ID="txtNotice" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNotice"
                                        Display="None" ErrorMessage="Please Enter Notice"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>
                                <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label7" runat="server"  class="col-form-label"  Text="Attach Document"></asp:Label> 
                                   <asp:FileUpload ID="FileUpload1" runat="server"  class="custom-file-label" accept=".png,.jpg,.jpeg,.gif"></asp:FileUpload>
                                    
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                                                            BackgroundCssClass="modalPopup" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="UpdateProgress1" TargetControlID="UpdateProgress1">
                                                        </asp:ModalPopupExtender>
                                                        <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" 
                                                                    OnClick="btnSubmit_Click" Text="Submit" />
                                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="vclassrooms_send" 
                                                            OnClick="btnUpdate_Click" Text="Update" />
                                                            </ContentTemplate>

                                                              
                                                           <triggers>

                                                               <asp:postbacktrigger controlid = "btnsubmit" />
                                                            <asp:postbacktrigger controlid = "btnupdate" />
                                                        </triggers>
                                                        </asp:UpdatePanel>
                                    
                                     
                                </div>
                             </div>
                             </div>
                                <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                </div>
                                </div>

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
