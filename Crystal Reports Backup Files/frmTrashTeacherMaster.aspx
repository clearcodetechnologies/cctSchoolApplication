﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTrashTeacherMaster.aspx.cs" Inherits="frmTrashTeacherMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <h1 style="box-sizing: border-box; margin: 0px; font-size: 24px; font-family: &quot;Source Sans Pro&quot;, sans-serif; font-weight: 500; line-height: 1.1; color: rgb(51, 51, 51); font-style: normal; font-variant: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(236, 240, 245);">
           Teacher Master</h1>
        <h1>
            &nbsp;</h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Trash</a></li>
            <li><a ><i ></i>School Master</a></li>
            <li class="active">Teacher Master</li>
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
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List of Teachers
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                        <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%" 
                                                                DataKeyNames="intTeacher_id" onrowediting="grvDetail_RowEditing" 
                                                                >
                                                                <Columns>
                                                                <asp:BoundField DataField="intteacher_id" HeaderText="intTeacher_id" 
                                                                        ReadOnly="True" Visible="False" />
                                                                <asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" ReadOnly="True" />
                                                                 <asp:BoundField DataField="dtDeleted_Date" HeaderText="Deleted Date" ReadOnly="True" />
                                                                
                                                                     <asp:TemplateField HeaderText="Enable">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
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
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>


