<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmEventMaster.aspx.cs" Inherits="frmEventMaster" Title="E-Smarts - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .efficacious_send {
            width: 50% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }

        .textcss {
            font-size: 13px !important;
        }

        .textsize {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
    </style>
    <div class="content-header content-header1 pd-0">

        <ul class="top_navlg">
            <li><a>Event <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
           
        </ul>

    </div>
    <section class="content">
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
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" DataKeyNames="intEvent_id" OnRowDeleting="grvDetail_RowDeleting" OnSelectedIndexChanged="grvDetail_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:BoundField DataField="dtRegistrartionStartDate" HeaderText="Registration Start Date" ReadOnly="True" />
                                                                   <asp:BoundField DataField="dtRegistrationEndDate" HeaderText="Registration End Date" ReadOnly="True" />
                                                                   <asp:BoundField DataField="dtEventStartDate" HeaderText="Event Start Date" ReadOnly="True" />
                                                                   <asp:BoundField DataField="dtEventEndDate" HeaderText="Event End Date" ReadOnly="True" />
                                                                   <asp:BoundField DataField="vchEventName" HeaderText="Event Name" ReadOnly="True" />                                                                  
                                                                   <asp:BoundField DataField="vchEventDescription" HeaderText="Event Description" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchEventFees" HeaderText="Event Fees" ReadOnly="True" />
                                                                  
                                                                     <asp:TemplateField HeaderText="Delete">
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <table width="50%" style="text-align: right; margin:0 0 0 2%;">
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
                                                            <asp:Label ID="Label2" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                              <asp:DropDownList ID="ddlstd" Width="225px"  runat="server" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="ddlstd_SelectedIndexChanged">
            </asp:DropDownList>       </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lblregistrationdate" runat="server" Style="width: 100% !important; color: #000 !important;">Registration Start Date</asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txtregistrationstart" runat="server" ForeColor="Black" MaxLength="20" Style="width: 96%;"
                                                               ></asp:TextBox><asp:CalendarExtender
                                                                    ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtregistrationstart" runat="server"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                        </td>
                                                       <%-- <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Registration Date cannot be null "
                                                                ControlToValidate="txtregistrationstart" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lblResgistrationEnddate" runat="server" Text="Registration End Date" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txtregEnddate" runat="server" ForeColor="Black" MaxLength="20" 
                                                                Style="width: 96%;"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtregEnddate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                        <%--<td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="registration End Date cannot be null "
                                                                ControlToValidate="txtregEnddate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                            <br />
                                                        </td>--%>
                                                    </tr>
                                                     <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lblEventstartdate" runat="server" Style="width: 100% !important; color: #000 !important;">Event Start Date</asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txteventstartdate" runat="server" ForeColor="Black" MaxLength="20" Style="width: 96%;"
                                                               ></asp:TextBox><asp:CalendarExtender
                                                                    ID="CalendarExtender3" Format="dd/MM/yyyy" TargetControlID="txteventstartdate" runat="server"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                        </td>
                                                       <%-- <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Event Date cannot be null "
                                                                ControlToValidate="lblEventstartdate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; width: 145px;">
                                                            <asp:Label ID="lbleventenddate" runat="server" Text="Event End Date" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:TextBox ID="txteventenddate" runat="server" ForeColor="Black" MaxLength="20" 
                                                                Style="width: 96%;" AutoPostBack="True" ></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" TargetControlID="txteventenddate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                        </td>
                                                       <%-- <td style="padding-top: 10px">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Event End Date cannot be null "
                                                                ControlToValidate="txteventenddate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                            <br />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                            <td align="justify">
                                                                <asp:Label ID="lblEventname" runat="server" Font-Bold="False">Event Name</asp:Label>
                                                            </td>
                                                            <td align="justify">
                                                                <asp:TextBox ID="txtEventname" runat="server" Font-Names="Verdana" MaxLength="100" Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                            </td>
                                                        </tr> 
                                                         <tr>
                                                            <td align="justify">
                                                                <asp:Label ID="lblEventfees" runat="server" Font-Bold="False">Event Fees</asp:Label>
                                                            </td>
                                                            <td align="justify">
                                                                <asp:TextBox ID="txtEventfees" runat="server" Font-Names="Verdana" MaxLength="100" Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                                                                         <tr>
                                                            <td align="justify">
                                                                <asp:Label ID="lbleventdescription" runat="server" Font-Bold="False">Event dscription</asp:Label>
                                                            </td>
                                                            <td align="justify">
                                                                <asp:TextBox ID="txteventdescription" runat="server" Font-Names="Verdana" MaxLength="100" Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="padding-left:-20px">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                            OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Style="padding-left: 10px"
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
        </center>
    </div>
</section>
</asp:Content>
