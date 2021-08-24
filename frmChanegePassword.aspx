<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmChanegePassword.aspx.cs" Inherits="frmChanegePassword" Title="Change Password" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Change Password </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Settings</a></li>
              <li class="breadcrumb-item active"> Change Password</li>
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
                   <%-- <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false">Exam Entry</a>
                    </li> --%>
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="User Name"></asp:Label> 
                                   <asp:TextBox ID="TextBox1" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="Please Enter User Name"
                                                                ControlToValidate="TextBox1" Display="None" ValidationGroup="g1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                                runat="server" TargetControlID="RFV1" Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="RegEV1" runat="server" ControlToValidate="TextBox1"
                                                                ErrorMessage="Only alphabets are allowed" ValidationGroup="g1" ForeColor="Red"
                                                                ValidationExpression="[a-zA-Z]+" Font-Bold="False" Display="None"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True"
                                                                TargetControlID="RegEV1">
                                                            </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                        
                        </div>
                        <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label7" class="col-form-label" runat="server" Text="Old Password"></asp:Label> 
                                   <asp:TextBox ID="TextBox2" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RegEV2" runat="server" ErrorMessage="Please Enter Old Password"
                                                                ControlToValidate="TextBox2" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RegEV2">
                                                            </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                        
                        </div>

                         <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label8" class="col-form-label" runat="server" Text="New Password"></asp:Label> 
                                   <asp:TextBox ID="TextBox3" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="ReqFV3" runat="server" ErrorMessage="Please Enter New Password"
                                                                ControlToValidate="TextBox3" Display="None" ValidationGroup="g1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="ReqFV3"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                        
                        </div>

                        <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label9" class="col-form-label" runat="server" Text="Confirm Password"></asp:Label> 
                                   <asp:TextBox ID="TextBox4" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="ReqFdV4" runat="server" ErrorMessage="Please Enter Confirm Password"
                                                                ControlToValidate="TextBox4" ValidationGroup="g1" Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="ReqFdV4"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="TextBox3"
                                                                ControlToValidate="TextBox4" ValidationGroup="g1" ErrorMessage="Your new password and confirm password do not match!"
                                                                Display="None" Font-Bold="False" />
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="comparePasswords"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                        
                        </div>
                         <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Image ID="imgCaptcha" runat="server" />
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:TextBox runat="server" ID="txtImg" />
                                </div>
                             </div>
                        
                        </div>
                        <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblCaptchaResult" runat="server" />
                                </div>
                             </div>
                        
                        </div>

                        <div class="row">
                        <div class="col-lg-3 col-md-4 col-sm-6">
                                 <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-success btn-sm mt-18" OnClick="change_pass" OnClientClick="return ConfirmInsertUpdate();"
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
