<%@ Page Title="Subject Entry" Language="C#" MasterPageFile="~/MasterPage2.master"
    AutoEventWireup="true" CodeFile="frmSubject_Entry_Old.aspx.cs" Inherits="frmSubject_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   

 <section class="content">
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0"> List of Subjects</h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active"> List of Subjects</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div>

<section class="content">
      <div class="container-fluid">
         
        <div class="card card-default"> 
            <div class="card-header">
            <h3 class="card-title">Subject Master</h3>

            <div class="card-tools">
              <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
              <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
            </div>
          </div>

       
          <div class="card-body">
            <div class="row">
              <div class="col-md-6">
                <div class="form-group">
                  <asp:Label ID="ssst" runat="server">Select Standard</asp:Label>
                    <asp:DropDownList ID="Stdrop1" runat="server" CssClass="form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="Stdrop1_SelectedIndexChanged">
                    </asp:DropDownList>
                     
                </div>
                <!-- /.form-group -->
                 
              </div>
              <!-- /.col -->
             
 
             
            </div>
            <!-- /.row -->
          </div>
     </div>

    </div>
    </section>

            <div style="padding: 5px 0 0 0">
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="tabpanel2" runat="server">
                                    <HeaderTemplate>
                                       </HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="vclassrooms">
                                            <table width="100%">
                                                <tr>
                                                    <td align="right" style="padding: 0 15px;">
                                                       
                                                    </td>
                                                    <td>
                                                      
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:GridView ID="SubReport" runat="server" OnPageIndexChanging="SubReport_PageIndexChanging"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                                            OnRowDataBound="SubReport_RowDataBound" 
                                                            OnRowEditing="SubReport_RowEditing" DataKeyNames="intSubject_id"
                                                            OnRowDeleting="SubReport_RowDeleting" OnRowCommand="SubReport_RowCommand" Width="95%"
                                                            OnSelectedIndexChanged="SubReport_SelectedIndexChanged"
                                                            PageSize="20">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="intSubject_id" runat="server" Text='  <%# Eval("intSubject_id")  %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchSubjectName" HeaderText="Subject Name" ReadOnly="True" />
                                                                
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 18px !important; outline: 0;"
                                                                            ImageUrl="~/images/edit.png" CommandName="Edit" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 22px !important; outline: 0;"
                                                                            ImageUrl="~/images/delete.png" CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                            CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                        Subject Entry</HeaderTemplate>
                                    <ContentTemplate>
                                        <div class="vclassrooms">
                                      
                                                <table style="font-weight: bolder; width: 40%; margin: 10px 0 10px 15px;" align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Select Standard" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="Standard_id" runat="server" Font-Bold="False">
                                                            </asp:DropDownList>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Standard_id" InitialValue="0"
                                                            Display="None" ErrorMessage="Please Select Standard"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                        </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="subj1" runat="server" Text="Enter Subject" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="text1"  CssClass="input-blue" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="text1"
                                                            Display="None" ErrorMessage="Please Enter Subject"></asp:RequiredFieldValidator>
                                                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender1"
                                                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                        </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <table width="80%">
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Button ID="Button1"  style="padding-left:10px" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="vclassrooms_send" />
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="Button2_Click" 
                                                                            CssClass="vclassrooms_send" Visible="False" /><asp:HiddenField
                                                                            ID="hid1" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>

                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>
