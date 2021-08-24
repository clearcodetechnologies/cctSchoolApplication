<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmModuleDetails.aspx.cs" Inherits="frmModuleDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   ModuleAssignment </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Settings</a></li>
              <li class="breadcrumb-item active"> Module Assiggnment</li>
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
                    
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlAcademiYear" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAcademiYear"
                                        Display="None" ErrorMessage="Please Enter Academic Year"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                                </div>
                                
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="Role"></asp:Label> 
                                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRole"
                                        Display="None" ErrorMessage="Please Enter Role"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblStd" runat="server"  class="col-form-label"  Text="Standard"></asp:Label> 
                                   <asp:DropDownList ID="ddlSTD" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlSTD_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlSTD"
                                        Display="None" ErrorMessage="Please Enter Standard"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblDept" runat="server"  class="col-form-label"  Text="Department"></asp:Label> 
                                   <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartment"
                                        Display="None" ErrorMessage="Please Enter Department"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblDesi" runat="server"  class="col-form-label"  Text="Designation"></asp:Label> 
                                   <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDesignation"
                                        Display="None" ErrorMessage="Please Enter Designation"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>

                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblTchr" runat="server"  class="col-form-label"  Text="Teacher"></asp:Label> 
                                   <asp:DropDownList ID="ddlTeacher" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                                                    onselectedindexchanged="ddlTeacher_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTeacher"
                                        Display="None" ErrorMessage="Please Enter Teacher"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             </div>

                             


                             <div class="row">


                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="gvDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intModule_Id" >
                                    <Columns>                                                                 
                                        <asp:BoundField DataField="vchModule" HeaderText="Module" ReadOnly="True" />
                                                                  <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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

