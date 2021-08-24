<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmPromotionDemotion.aspx.cs" Inherits="frmPromotionDemotion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Student Promotion/Demotion </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Registration Form</a></li>
              <li class="breadcrumb-item active"> Student Promotion/Demotion</li>
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
                                   <asp:Label ID="lblAcademicYear" class="col-form-label" runat="server" Text="Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlAcademiYear" runat="server" CssClass="form-control">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblStdf" class="col-form-label" runat="server" Text="From Standard"></asp:Label> 
                                    <asp:DropDownList ID="ddlFromSTD" runat="server" CssClass="form-control"  AutoPostBack="True" 
                                                                onselectedindexchanged="ddlFromSTD_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                   
                                </div>
                             </div>

                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="From Division"></asp:Label> 
                                    <asp:DropDownList ID="ddlfromdiv" runat="server" CssClass="form-control"  > 
                                                                
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlfromdiv"
                                        Display="None" ErrorMessage="Please Enter Division"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>
                                   
                                </div>
                             </div>

                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label7" class="col-form-label" runat="server" Text="To Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="ddlToAcademiYear" runat="server" CssClass="form-control"  > 
                                                                
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                   
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblStdt" class="col-form-label" runat="server" Text="To Standard"></asp:Label> 
                                    <asp:DropDownList ID="ddlToSTD" runat="server" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="ddlToSTD_SelectedIndexChanged"  > 
                                                                
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                   
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label10" class="col-form-label" runat="server" Text="To Division"></asp:Label> 
                                    <asp:DropDownList ID="ddltodiv" runat="server" CssClass="form-control"  > 
                                                                
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddltodiv"
                                        Display="None" ErrorMessage="Please Enter Division"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                    </asp:ValidatorCalloutExtender>
                                   
                                </div>
                             </div>

                             <div class="row">
                             <div class="col-lg-12 col-md-12">
                                 <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" 
                                                            Text="Promote" onclick="btnSubmit_Click" OnClientClick="count();" />
                                </div>
                             
                             </div>


                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="gvList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intStudent_id,StudentName" 
                                    >
                                    <Columns>                                                                 
                                        <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>
                                                                                 <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkCtrlAll" runat="server" />
                                                                                </HeaderTemplate>
                                                                                    <ItemTemplate>                                                                    
                                                                                    <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">  </asp:CheckBox>                                                                    
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


