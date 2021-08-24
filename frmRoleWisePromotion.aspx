<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmRoleWisePromotion.aspx.cs" Inherits="frmRoleWisePromotion" %>

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
            <h1 class="m-0">   Promotion </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Settings</a></li>
              <li class="breadcrumb-item active"> Promotion</li>
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
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="Role"></asp:Label> 
                                    <asp:DropDownList ID="drpRole" runat="server" CssClass="form-control" onselectedindexchanged="drpRole_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpRole"
                                        Display="None" ErrorMessage="Please Enter Role"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intTransUser_id" onrowediting="grvDetail_RowEditing">
                                    <Columns>                                                                 
                                       <asp:BoundField DataField="intUserType_id" HeaderText="Role" ReadOnly="True" 
                                                                Visible="False"/>
                                                        <asp:BoundField DataField="intUser_id" HeaderText="Name" ReadOnly="True" />
                                                        <asp:BoundField DataField="intAcademic_id" HeaderText="Academic Year" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDepartment_id" HeaderText="Department" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDesignation_Id" HeaderText="Designation" ReadOnly="True" />
                                                         <asp:BoundField DataField="intstandard_id" HeaderText="Standard" ReadOnly="True" />
                                                        <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                                 
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
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="From Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlAcademiYear" runat="server" CssClass="form-control" AutoPostBack="True" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAcademiYear"
                                        Display="None" ErrorMessage="Please Enter Academiyear"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="To Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlToAcademicYear" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlToAcademicYear"
                                        Display="None" ErrorMessage="Please Enter Academicyear"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" runat="server"  class="col-form-label"  Text="Role"></asp:Label> 
                                   <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" AutoPostBack="True"   onselectedindexchanged="ddlRole_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"   ControlToValidate="ddlRole"
                                        Display="None" ErrorMessage="Please Enter Role"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label5" runat="server"  class="col-form-label"  Text="Department"></asp:Label> 
                                   <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" AutoPostBack="True"   onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"   ControlToValidate="ddlDepartment"
                                        Display="None" ErrorMessage="Please Enter Department"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label6" runat="server"  class="col-form-label"  Text="Designation"></asp:Label> 
                                   <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control" AutoPostBack="True"   onselectedindexchanged="ddlDesignation_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDesignation"
                                        Display="None" ErrorMessage="Please Enter Total Marks"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                    </asp:ValidatorCalloutExtender>
                                     
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label7" runat="server"  class="col-form-label"  Text="Name"></asp:Label> 
                                   <asp:DropDownList ID="ddlName" runat="server" CssClass="form-control"  AutoPostBack="True" >
                                    </asp:DropDownList>
                                    
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblStd" runat="server"  class="col-form-label"  Text="Standard"></asp:Label> 
                                   <asp:DropDownList ID="ddlSTD" runat="server"  AutoPostBack="True" onselectedindexchanged="ddlSTD_SelectedIndexChanged" CssClass="form-control"   >
                                    </asp:DropDownList>
                                    
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblDiv" runat="server"  class="col-form-label"  Text="Division"></asp:Label> 
                                   <asp:DropDownList ID="ddlDIV" runat="server"   CssClass="form-control"   >
                                    </asp:DropDownList>
                                    
                                     
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

