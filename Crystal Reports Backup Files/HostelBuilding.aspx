﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="HostelBuilding.aspx.cs" Inherits="HostelBuilding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style>
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function confirmMsg() {
            var txt = document.getElementById("<%=txtBuilding.ClientID %>").value;
            if (txt.trim() == '') {
                alert('Please Enter Building Name');
                return false
            }
            else {
                var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
                if (btn == 'Submit') {
                    var msg = confirm('Do You Really Want To Save Entered Record ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    var msg = confirm('Do You Really Want To Update Entered Record ?');
                    if (msg) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Hostel Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li class="active1"><a href="HostelBuilding.aspx">Hostel Building</a></li>
             <li><a href="HostelWing.aspx">Hostel Wing</a></li>
            <li><a href="HostelFloor.aspx">Hostel Floor</a></li>
            <li><a href="HostelRoom.aspx">Hostel Room</a></li>
            <li><a href="HostelBed.aspx">Hostel Bed</a></li>
            <li><a href="HostelFeeHead.aspx">Hostel Fee</a></li>
            <li><a href="HostelStudentMaster.aspx">Hostel Student Entry</a></li>
            <li><a href="HostelInquiry.aspx">Hostel Enquiry</a></li>
        </ul>
    </div>

<section class="content">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="100%" 
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="50%" AllowPaging="True" 
                                                        DataKeyNames="HostelBuilding_id" 
                                                        onpageindexchanging="grvDetail_PageIndexChanging" 
                                                        onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing" >
                                                        <Columns>
                                                             <asp:BoundField DataField="Building_name" HeaderText="Building Name" ReadOnly="True" />
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" ImageUrl="~/images/edit.png" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Floor_Id" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" Text='<%#Eval("HostelBuilding_id") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');"
                                                                        ImageUrl="~/images/delete.png" />
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
                            <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <center>
                                        <div class="vclassrooms">
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label1" runat="server" Text="Building Name"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2">
                                                        <asp:TextBox ID="txtBuilding" runat="server" CssClass="input-blue" MaxLength="50" ToolTip="Enter Building Name Here "></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtBuilding"
                                                            FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" 
                                                            ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" 
                                                            OnClientClick="return confirmMsg();" Text="Submit" onclick="btnSubmit_Click" 
                                                            />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="vclassrooms_send" Visible="false"
                                                            Text="Cancel" 
                                                           />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </center>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

