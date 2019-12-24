<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="hrPaymentTypes.aspx.cs" Inherits="hrPaymentTypes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function confirmMsg() {
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">
        <ul class="top_nav">
            <li><a>Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a>Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
            </li>
            <li><a href="frmBuildingMaster.aspx">Building Master </a></li>
            <li class="active1"><a href="frmWingMaster.aspx">Wing Master</a></li>
            <li><a href="frmFloorMaster.aspx">Floor Master</a></li>
            <li><a href="frmRoomMaster.aspx">Room Master</a></li>
            <li><a href="frmEquipItemMaster.aspx">Item Master</a></li>
            <li><a href="frmItemTypeMaster.aspx">Item Details Master</a></li>
        </ul>
    </div>
    <section class="content">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC"  Width="1015px" 
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <left>
<table width="100%">
    <caption>
        &nbsp;
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowPaging="True" 
                                                        AllowSorting="True" AutoGenerateColumns="False" 
                                                        CssClass="table  tabular-table " DataKeyNames="IntPayableId" 
                                                      
                                                        Width="50%" onpageindexchanging="grvDetail_PageIndexChanging" 
                                                        onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing"><Columns>
<asp:TemplateField HeaderText="Floor_Id" Visible="False">
    <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("IntPayableId") %>'></asp:Label>
                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="VchPayableTypeName" HeaderText="Payable" 
                                                                ReadOnly="True"></asp:BoundField>
<asp:TemplateField HeaderText="Edit">
    <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" 
                                                                        ImageUrl="~/images/edit.png" />
                                                                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
    <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="true" 
                                                                        CommandName="Delete" ImageUrl="~/images/delete.png" 
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');" />
                                                                
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

                                                </td>
    </tr>
</caption>
</table>
</left>
                                </ContentTemplate>
                            </asp:TabPanel>
                           <asp:TabPanel runat="server" ID="TB2">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <table width="36%" style="text-align: right; margin:0 0 0 10%;">
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
                                                            <asp:Label ID="Label2" runat="server" Text="Payable Type Name"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            

                                                        <asp:TextBox ID="txtPayableName" runat="server" CssClass="input-blue" MaxLength="50" ToolTip="Payable Type Name Here "></asp:TextBox>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPayableName"
                                                            FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" 
                                                            ValidChars=" " Enabled="True">
                                                        </asp:FilteredTextBoxExtender>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" >
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" >
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" />
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
