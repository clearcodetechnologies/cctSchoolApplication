<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAdmissionCancel.aspx.cs" Inherits="frmAdmissionCancel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Admission Cancelation </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Admission</a></li>
              <li class="breadcrumb-item active"> Admission Cancelation</li>
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
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">List</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false">Cancel Details</a>
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
                                   <asp:Label ID="lblStdf" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="ddlSTD" runat="server" CssClass="form-control" AutoPostBack="True" 
                                                                onselectedindexchanged="ddlSTD_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             <div class="row" >
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" 
                                                            Text="Submit" onclick="btnSubmit_Click" />
                                    
                                </div>
                             </div>
                             </div>
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="gvList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intStudent_id" >
                                    <Columns>                                                                 
                                       <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>                                                                                
                                                                                    <ItemTemplate>                                                                    
                                                                                    <asp:CheckBox ID="chkCtrl"  runat="server" AutoPostBack="true">  </asp:CheckBox>                                                                    
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
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="Academic Year"></asp:Label> 
                                    <asp:DropDownList ID="drpAcademicYear" runat="server" CssClass="form-control">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label2" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="drpStandard" runat="server" CssClass="form-control" AutoPostBack="True" onselectedindexchanged="drpStandard_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             <div class="row" >
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                    <asp:Button ID="btnCancel" runat="server" CssClass="vclassrooms_send" 
                                                            Text="Submit" onclick="btnCancel_Click" />
                                    
                                </div>
                             </div>
                             </div>
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="gvCancelDet" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intStudent_id" >
                                    <Columns>                                                                 
                                        <asp:BoundField ReadOnly="True" DataField="StudentName" HeaderText="Name" />                                                                                    
                                                                                 <asp:TemplateField>                                                                                
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