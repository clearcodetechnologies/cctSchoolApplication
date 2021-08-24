<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAcademicYearMaster.aspx.cs" Inherits="frmAcademicYearMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
      <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Academic Master </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Academic Master</li>
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
                      <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Entry</a>
                    </li> --%>
                  </ul>
                </div>
                    <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="table table table-hover table-bordered cus-table tabular-table " PageSize="20" DataKeyNames="intAcademic_id"
                                  >
                                <%-- onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing"--%>
                                        <Columns>
                                             <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year" ReadOnly="True" />
                                             <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" />                  
                                            <%--<asp:TemplateField HeaderText="Edit">
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
                                            </asp:TemplateField>--%>
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
     </section>  
                    
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server" ActiveTabIndex="1">
                                    <asp:TabPanel ID="tab" runat="server">
                                  
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server"  ID="TabPanel1">
                                         
                                     
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            
                </ContentTemplate>
            </asp:UpdatePanel>
         
</asp:Content>
