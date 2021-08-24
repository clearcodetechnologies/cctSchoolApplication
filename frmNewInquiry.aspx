<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmNewInquiry.aspx.cs" Inherits="frmNewInquiry" %>

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
            <h1 class="m-0">   Registration Form </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Registration Form</li>
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
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="Selected/Rejected"></asp:Label> 
                                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged = "DropDownList1_SelectedIndexChanged" class="pull-left" AutoPostBack="True" Width="150px"  >
                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Selected" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1"
                                        Display="None" ErrorMessage="Please Select"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Button ID="BtnExportToExcel" runat="server" CssClass="nikhil_s"   OnClick="BtnExportToExcel_Click"
                                                                               Text="Export To Excel" />
                                </div>
                             </div>
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intInquiry_id" onrowdeleting="grvDetail_RowDeleting"  OnRowUpdating="grvDetail_RowUpdating1"
                onrowediting="grvDetail_RowEditing">
                                    <Columns>                                                                 
                                        <asp:BoundField DataField="vchInquiry_no" HeaderText="Enquiry No" 
                        ReadOnly="True" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="dtInquiryDate" HeaderText="Enquiry Date" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchName" HeaderText="First Name" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchMiddleName" HeaderText="Middle Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchLastName" HeaderText="Last Name" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="intstandard_id" HeaderText="Standard" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="dtDOB" HeaderText="D.O.B." ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherMobile" HeaderText="Mobile" 
                        ReadOnly="True" ></asp:BoundField>
                                                                 
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
                                        <asp:TemplateField HeaderText="Rejected Student" >
                                              <ItemTemplate>
                                                  <center>  <asp:ImageButton ID="ImgUpdate" runat="server" CommandName="Update" CausesValidation="true"                                                                          
                                                                                                    ImageUrl="~/images/sign/Reject.png" Width="40px" Height="40px" />
                                                </center></ItemTemplate>
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
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="Enquiry No"  Visible="False"></asp:Label> 
                                    <asp:TextBox ID="txtInquiryNo" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"  Visible="False"></asp:TextBox>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAcademicYear"
                                        Display="None" ErrorMessage="Please Select AcademicYear"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label7" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="drpStandard" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpStandard"
                                        Display="None" ErrorMessage="Please Select Standard"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" runat="server"  class="col-form-label"  Text="Candidate First Name"></asp:Label> 
                                   <asp:TextBox ID="txtCondidatename" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCondidatename"
                                        Display="None" ErrorMessage="Please Enter First name"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label5" runat="server"  class="col-form-label"  Text="Candidate Last Name"></asp:Label> 
                                   <asp:TextBox ID="txtLastName" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName"
                                        Display="None" ErrorMessage="Please Enter Last name"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label6" runat="server"  class="col-form-label"  Text="Date Of Birth"></asp:Label> 
                                   <asp:TextBox ID="txtDOB" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtDOB"
                                        runat="server" Enabled="True"></asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDOB"
                                        Display="None" ErrorMessage="Please Enter DOB"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label8" class="col-form-label" runat="server" Text="Gender"></asp:Label> 
                                    <asp:DropDownList ID="drpGender" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpGender"
                                        Display="None" ErrorMessage="Please Select Gender"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label9" runat="server"  class="col-form-label"  Text="Telephone No"></asp:Label> 
                                   <asp:TextBox ID="txtTelNo" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelNo"
                                        Display="None" ErrorMessage="Please Enter Telephone"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtTelNo"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label10" runat="server"  class="col-form-label"  Text="Father name"></asp:Label> 
                                   <asp:TextBox ID="txtfatherName" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfatherName"
                                        Display="None" ErrorMessage="Please Enter Father name"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label11" runat="server"  class="col-form-label"  Text="Father Mobile"></asp:Label> 
                                   <asp:TextBox ID="txtFatherMobile" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                               
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFatherMobile"
                                        Display="None" ErrorMessage="Please Enter MobileNumber"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator10">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" TargetControlID="txtFatherMobile"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label12" runat="server"  class="col-form-label"  Text="Father Email"></asp:Label> 
                                   <asp:TextBox ID="txtFatherEmail" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFatherEmail"
                                        Display="None" ErrorMessage="Please Enter DOB"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label13" runat="server"  class="col-form-label"  Text="Father Occupation"></asp:Label> 
                                   <asp:TextBox ID="txtFatherOccupation" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFatherOccupation"
                                        Display="None" ErrorMessage="Please Enter Occupation"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator12">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label14" runat="server"  class="col-form-label"  Text="Mother name"></asp:Label> 
                                   <asp:TextBox ID="txtMotherName" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMotherName"
                                        Display="None" ErrorMessage="Please Enter Mother Name"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator13">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label23" runat="server"  class="col-form-label"  Text="Mother Mobile"></asp:Label> 
                                   <asp:TextBox ID="txtMotherMobile" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMotherMobile"
                                        Display="None" ErrorMessage="Please Enter Mother Name"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator14">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label15" runat="server"  class="col-form-label"  Text="Mother Email"></asp:Label> 
                                   <asp:TextBox ID="txtMotherEmail" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                             
                                  
                                    
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label16" runat="server"  class="col-form-label"  Text="Mother Occupation"></asp:Label> 
                                   <asp:TextBox ID="txtMotherOccupation" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtMotherOccupation"
                                        Display="None" ErrorMessage="Please Enter Mother Occupation"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label17" runat="server"  class="col-form-label"  Text="Address"></asp:Label> 
                                   <asp:TextBox ID="txtAddress" runat="server" AutoComplete="Off" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAddress"
                                        Display="None" ErrorMessage="Please Enter Address"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator16">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label18" runat="server"  class="col-form-label"  Text="Pincode"></asp:Label> 
                                   <asp:TextBox ID="txtPincode" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPincode"
                                        Display="None" ErrorMessage="Please Enter Pincode"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator17">
                                    </asp:ValidatorCalloutExtender>

                                     <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" TargetControlID="txtPincode"
                                        FilterType="Numbers" runat="server" Enabled="True"></asp:FilteredTextBoxExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label19" runat="server"  class="col-form-label"  Text="State"></asp:Label> 
                                   <asp:TextBox ID="txtState" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtState"
                                        Display="None" ErrorMessage="Please Enter State"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender17"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator18">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label20" runat="server"  class="col-form-label"  Text="City"></asp:Label> 
                                   <asp:TextBox ID="txtCity" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtCity"
                                        Display="None" ErrorMessage="Please Enter City"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator19">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label21" runat="server"  class="col-form-label"  Text="Remark"></asp:Label> 
                                   <asp:TextBox ID="txtRemark" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtRemark"
                                        Display="None" ErrorMessage="Please Enter Remark"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender19"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator20">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label22" runat="server"  class="col-form-label"  Text="Amount"></asp:Label> 
                                   <asp:TextBox ID="txtAmount" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAmount"
                                        Display="None" ErrorMessage="Please Enter Amount"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender20"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator21">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>


                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                 <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-sm mt-18" OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();"
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

