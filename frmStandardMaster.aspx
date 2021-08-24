<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmStandardMaster.aspx.cs" Inherits="frmStandardMaster" Title="VClassrooms - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script type="text/javascript">
     

       function funcswitchtab() {
           $('#custom-tabs-five-overlay-dark-tab').trigger('click')
           $("#custom-tabs-five-overlay-dark").addClass("active show");
           $("#custom-tabs-five-overlay").removeClass("active");
           $("#custom-tabs-five-overlay").removeClass("show");
           //$('.tab-pane #tab2Entry"]').show();
           //window.location.href = "#tab2Entry";
       }
         
   </script>
      <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Standard Master </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Standard Master</li>
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
                      <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Entry</a>
                    </li> 
                  </ul>
                </div>
                    <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="table table table-hover table-bordered cus-table tabular-table " PageSize="20" DataKeyNames="intstandard_id"
                                        OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing">
                                        <Columns>
                                            <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                   
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
                       <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-dark-tab">
                     <div class="form-horizontal">
                            <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" CssClass="col-form-label" runat="server" Text="Standard"></asp:Label>
                                  <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="75" AutoComplete="Off"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                   
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6"> 
                                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success btn-sm mt-18"
                                                                            OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" />
                                
                                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click"  CssClass="btn btn-danger btn-sm mt-18"  Text="Clear" CausesValidation="False" />
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
                    
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server" ActiveTabIndex="1">
                                    <asp:TabPanel ID="tab" runat="server">
                                  
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server"  ID="TabPanel1">
                                         
                                     
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            
                </ContentTemplate>
            </asp:UpdatePanel>
         
</asp:Content>
