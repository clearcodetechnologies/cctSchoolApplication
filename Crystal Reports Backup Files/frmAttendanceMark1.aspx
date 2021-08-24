<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmAttendanceMark1.aspx.cs" Inherits="frmAttendanceMark1" Title="Attendance Mark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript">
        function checkDate() {
            var idate = document.getElementById("<%=txtDate.ClientID %>").value;
            var myDate = new Date(idate);
            alert(myDate);
            var today = new Date();
            alert(today);
            if (myDate > today) {
                alert("Please check date.");
                document.forms.form1.date.focus();
                return false;
            }

        }
    </script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }
        .style1 select {
            display: block;
            border: 1px solid #3498db;
            width: 100%;
            padding: 5px;
            height: auto !important;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-right: 30px;
        }
                .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }
        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }
        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }
        .search
        {
            border: 1px solid #078DB9 !important;
            padding: 3px;
        }
        .vclassrooms_Submit
        {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            width: 110% !important;
            background: #3498db;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
        }
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
        .td, th {
            padding: 0;
            padding-right:300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">       
        <ul class="top_nav1 sp">
        <li><a >Attendance <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a href="frmTeacherAttendance.aspx">Teacher Attendance</a></li>
            <li><a href="frmStaffAttendance.aspx">Staff Attendance</a></li>
            <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
            <li><a href="frmAttendanceMarkAdmin.aspx">Admin Attendance Mark</a></li>   
            <li><a href="frmAttendanceMarkTeacher.aspx">Teacher Attendance Mark</a></li>   
            <li><a href="frmAttendanceMarkStaff.aspx">Staff Attendance Mark</a></li>   
            <li class="active1"><a href="frmAttendanceMark.aspx">Student Attendance Mark</a></li>            
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <center>
                <table style="width:90%;">
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>Mark Attendance</HeaderTemplate></asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" 
                                    Visible="False"></asp:TabPanel>
                            </asp:TabContainer>
                            <table class="style1">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table width="74%" style="padding-right:30px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Standard" style="padding-right:30px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpStandard" runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="drpStandard_SelectedIndexChanged" style="padding-right:30px;">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="padding-left:20px;">
                                                    <asp:Label ID="Label2" runat="server" Text="Division" style="padding-right:30px;" Visible="false"></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:DropDownList ID="drpDivision" runat="server" AutoPostBack="True" onselectedindexchanged="drpDivision_SelectedIndexChanged"
                                                     style="padding-right:30px;">
                                                        <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                
                                                <td style="padding-left:20px;">                                                    
                                                    <asp:Label ID="Label3" runat="server" Text="Date" style="padding-right:30px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="selectf" Font-Names="Verdana"
                                                        ForeColor="Black" OnTextChanged="txtDate_TextChanged" AutoPostBack="True" style="padding-right:30px;"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="false" Format="dd/MM/yyyy"
                                                        TargetControlID="txtDate">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="grdMarkAttendance" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                            DataKeyNames="intStudent_id,intRollNo,Name,vchUser_name,vchPassword,intHomePhoneNo1"
                                            EmptyDataText="No Records Found" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intStudent_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="intRollNo" HeaderText="Roll No">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Student Name">
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="intHomePhoneNo1" HeaderText="Mobile No">
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchUser_name" HeaderText="User Name">
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="vchPassword" HeaderText="Password">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                
                                            </Columns>
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="vclassrooms_Submit" Text="Update"
                                                        Visible="False" OnClick="btnUpdate_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSMS" runat="server" CssClass="vclassrooms_Submit" Text="SMS to Parents" Visible="False"
                                                        OnClick="btnSMS_Click" />
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Button ID="btnSMSAdmin" runat="server" CssClass="vclassrooms_Submit" 
                                                        Text="SMS To Admin" Visible="False" onclick="btnSMSAdmin_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>
