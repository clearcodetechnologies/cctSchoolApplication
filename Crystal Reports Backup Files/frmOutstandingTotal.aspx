<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmOutstandingTotal.aspx.cs" Inherits="frmOutstandingTotal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="vclassrooms">
                                                <table style="font-weight: bolder; width: 60%; margin: 10px 0;" align="center">
                                                    <tr id="teachhide" runat="server">
                                                        <td id="Td127" runat="server" align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label86" runat="server" Font-Bold="False">Standard</asp:Label>
                                                        </td>
                                                        <td id="Td1" runat="server" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownL1" runat="server" Width="140px" OnSelectedIndexChanged="DropDownL1_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownL1"
                                                                Display="None" ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                        </td>
                                                    </tr>
                                                    <tr id="teachhide1" runat="server">
                                                        <td id="Td2" align="left" runat="server" style="padding-top: 10px">
                                                            <asp:Label ID="Label17" runat="server" Font-Bold="False">Division</asp:Label>
                                                        </td>
                                                        <td id="Td3" runat="server" style="padding-top: 10px">
                                                            <asp:DropDownList ID="DropDownL2" runat="server" Font-Names="Verdana" ForeColor="Black"
                                                                MaxLength="50" Width="140px" OnSelectedIndexChanged="DropDownL2_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownL2"
                                                                Display="None" ErrorMessage="Select Division " Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False">Select Student</asp:Label>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Droptypeuser"
                                                                Display="None" ErrorMessage="Select Student " Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                        </td>
                                                         <td width="30%">
                                                         
                                                        </td> 
                                                        
                                                    </tr>
                                                    <tr>
                                                        <asp:GridView ID="GridView1" runat="server"  CssClass="table  tabular-table"
                                                         designer:wfdid="w36" EmptyDataText="Record not Found." >
                                                        </asp:GridView>
                                                    </tr>
                                                </table>

                                            </div>
</asp:Content>

