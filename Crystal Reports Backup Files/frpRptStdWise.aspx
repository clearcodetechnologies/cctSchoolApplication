<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frpRptStdWise.aspx.cs" Inherits="frpRptStdWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="content-header">
        <h1>
            Standard Wise Collection
        </h1>
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>School Fee</a></li>
            <li class="active">Standard Wise Details</li>
        </ol>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="50%">
                                                 <tr>
                                                        <td>
                                                            <div class="vclassrooms" id="vclassrooms">
                                                                <table width="70%">
                                                                    <tr>
                                                                    <td align="center">
                                                                            <asp:Label ID="Label7" runat="server" Text="Standard" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="drpSTD" runat="server"  AutoPostBack="True" onselectedindexchanged="drpSTD_SelectedIndexChanged" 
                                                                                >
                                                                            </asp:DropDownList>
                                                                        </td>                                                                      
                                                                      
                                                                        </td>
                                                                        <td></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td>
                                                            <div class="vclassrooms" id="Div2">
                                                                <table width="70%">
                                                                <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label3" runat="server" CssClass="lalfont" Text="Total Student"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtStudent" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label13" runat="server" CssClass="lalfont" Text="Total Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtTotalFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>

                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label1" runat="server" CssClass="lalfont" Text="Paid Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPaidFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>

                                                                    <tr>
                                                                    <td align="left">
                                                             <asp:Label ID="Label2" runat="server" CssClass="lalfont" Text="Pending Fee"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:TextBox ID="txtPendingFee" runat="server" CssClass="input-blue" Enabled="False"></asp:TextBox>
                                                            </td><td></td><td></td>
                                                                    </tr>
                                                                </table>
                                                            </div>
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
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

