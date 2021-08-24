<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmTeacherTimeTable.aspx.cs" Inherits="frmTeacherTimeTable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Time Table </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Study</a></li>
              <li class="breadcrumb-item active"> Time Table</li>
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
                <%--<div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Detail</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" runat="server" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false" id=>Subject Entry</a>
                    </li> 
                  </ul>
                </div>--%>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">

                      <asp:Panel id="selection" runat="server">
                      <div class="row">
                        <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblDept" class="col-form-label" runat="server" Text="Department"></asp:Label> 
                                  <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True"  Width="200px" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblTeacher" class="col-form-label" runat="server" Text="Teacher Name"></asp:Label> 
                                    <asp:DropDownList ID="ddlTeacher" runat="server" AutoPostBack="True" Width="200px"
                                                        OnSelectedIndexChanged="ddlTeacher_SelectedIndexChanged">
                                                        <asp:ListItem>---Select---</asp:ListItem>
                                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             </div>

                             </asp:Panel>

                             <div class="row">

                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvTimetable" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" 
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"   
                                    OnRowDataBound="grvTimetable_RowDataBound">
                                    <Columns>                                                                 
                                        <asp:TemplateField HeaderText="Sr No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSrno" Font-Bold="true" runat="server" Text='<%#Eval("SrNo")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Period Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("Time")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonday" runat="server" Text='<%#Eval("Monday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tuesday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTuesday" runat="server" Text='<%#Eval("Tuesday")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Wednesday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWednesday" runat="server" Text='<%#Eval("Wednesday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Thursday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblThursday" runat="server" Text='<%#Eval("Thursday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Friday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFriday" runat="server" Text='<%#Eval("Friday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Saturday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSaturday" runat="server" Text='<%#Eval("Saturday")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BitRecess" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecess" runat="server" Text='<%#Eval("btrecess")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Height="20%" />
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
