﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmModuleMaster.aspx.cs" Inherits="frmModuleMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
        <h1>
            Module
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Master</a></li>
             <li><a ><i ></i>School Master</a></li>
            <li class="active">Module Master</li>
        </ol>
    </div>
    <div style="padding: 5px 0 0 0">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%" 
                                                                DataKeyNames="intModule_Id" onrowdeleting="grvDetail_RowDeleting" 
                                                                onrowediting="grvDetail_RowEditing"  >
                                                                <Columns>
                                                                 <asp:BoundField DataField="vchModule" HeaderText="Module" ReadOnly="True" />
                                                                    
                                                                    <asp:TemplateField HeaderText="Edit" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <asp:TemplateField HeaderText="Delete" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1" Visible="false">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="36%" style="text-align: right">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="Module"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="padding-left:-20px">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="vclassrooms_send"
                                                                            OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px" Visible="false"
                                                                            CssClass="vclassrooms_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

