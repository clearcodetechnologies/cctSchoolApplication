<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTransportOutstanding.aspx.cs" Inherits="frmTransportOutstanding" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
    <style>
        .mGrid .pgr td
        {
            border: solid 1px #666 !important;
        }
        .mGrid .pgr
        {
            background: #fff !important;
        }
        .vclassrooms span
        {
            display: block;
            height: auto;
            padding: 10px 0px;
            
            margin: 0 !important;
            padding: 2%;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            margin-bottom: 10px;
            width: auto !important;
            color: #000 !important;
        }
        .vclassrooms input[type="image"]
        {
            width: 75%;
            margin: 0 auto;
        }
    </style>
    <asp:UpdatePanel ID="updat4" runat="server">

        <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                    PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                    Enabled="True">
                </asp:ModalPopupExtender>
<div class="content-header pd-0">
       
       <%-- <ul class="top_nav1">
        <li><a >Profile <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a href="FrmAdminProfile.aspx">Personal Detail</a></li>
            <li><a href="FrmAdmsTeacherProfile.aspx">Teacher Detail</a></li>
            <li><a href="FrmAdmsStaffProfile.aspx">Staff Detail</a></li>
            <li class="active1"><a href="frmAdmListStudentDetails.aspx">Student Detail</a></li>            
        </ul>--%>
    </div>
<section class="content">

            <div style="padding-top: 5px 0 0 0">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
                                CssClass="MyTabStyle">
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Transport Outstanding Report
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
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
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownL1"
                                                                Display="None" ErrorMessage="Select Standard" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>
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
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownL2"
                                                                Display="None" ErrorMessage="Select Division " Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label1" runat="server" Font-Bold="False">Select Student</asp:Label>
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            <asp:DropDownList ID="Droptypeuser" AutoPostBack="True" runat="server" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="50" Width="140px" OnSelectedIndexChanged="Droptypeuser_SelectedIndexChanged"
                                                                ValidationGroup="b">
                                                                <asp:ListItem>---Select---</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Droptypeuser"
                                                                Display="None" ErrorMessage="Select Student " Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                         <td width="30%" >
                                                            <asp:Button ID="btnReport" runat="server" CssClass="vclassrooms_send" 
                                                                    Text="Report" onclick="btnReport_Click" Visible="false"  />
                                                        </td> 
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                            <asp:Label ID="lbltext" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="vclassrooms">
                                                <table width="100%">
                                                    <tr align="center" id="listparengrid" runat="server">
                                                        <td id="Td4" class="style10" runat="server">
                                                            Transport Outstanding Report
                                                        </td>
                                                    </tr>
                                                    <tr id="listparengrid1" runat="server">
                                                        <td id="Td5" style="padding: 10px 0 20px 0;" align="center" runat="server">
                                                            <asp:GridView ID="GridViewliststud" runat="server" designer:wfdid="w36"
                                                                AllowSorting="True" OnRowEditing="GridViewliststud_RowEditing" OnDataBound="GridViewliststud_DataBound"
                                                                OnRowDataBound="GridViewliststud_RowDataBound" OnRowDeleting="GridViewliststud_RowDeleting"
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" OnPageIndexChanging="GridViewliststud_OnPageIndexChanging"
                                                                 EmptyDataText="Record not Found." 
                                                                Width="100%" Visible="false">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                  
                                                                    <asp:TemplateField HeaderText="Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" Text="Delete" AlternateText="Details" ToolTip="Click"
                                                                                Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Parents Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnpareDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" align="center" Text="parets" AlternateText="Details"
                                                                                ToolTip="Click" Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Paid Transportation Fee" HeaderText="Paid Transportation Fee"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Transportfee" HeaderText="Transportfee"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="CurrentReceivableTransportfee" HeaderText="CurrentReceivableTransportfee" ReadOnly="True" />
                                                                    <asp:BoundField DataField="TotaltransportFee" HeaderText="Total transport Fee" ReadOnly="True" />
                                                                    <asp:BoundField DataField="outstabding" HeaderText="outstanding" ReadOnly="True" />
                                                                 <%--   <asp:BoundField DataField="dtDOB" HeaderText="Date of Birth" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="chrBloodGrp" HeaderText="Blood Group" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="vchReligion" HeaderText="Religion" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="vchPlaceofBirth" HeaderText="Place Of Birth" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchMotherName" HeaderText="Mother Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intFatherMobile" HeaderText="Father Mobile No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchpresentAddress" HeaderText="Present Address" ReadOnly="True" />--%>
                                                                     
                                                                    <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 18px !important;" ImageUrl="~/images/edit.png"
                                                                                CommandName="Edit" CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 22px !important;" ImageUrl="~/images/delete.png"
                                                                                CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>

                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table "  Width="100%" DataKeyNames="StudentID" >
                                                                <Columns>
                                                                <asp:TemplateField HeaderText="Student Id">
                                                                    <ItemTemplate>                                                        
                                                                        <asp:Label ID="lblStudentId" runat="server" Text='<%#Eval("StudentID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField> 
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="mnthcount" HeaderText="Total Month(No)" ReadOnly="True" />
                                                                <asp:BoundField DataField="Transportfee" HeaderText="Monthly fee (Rs.)"  ReadOnly="True" />
                                                                <asp:BoundField DataField="CurrentReceivableTransportfee" HeaderText="Till date receivable (Rs.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Paid Transportation Fee" HeaderText="Paid Fee (Rs.)"  ReadOnly="True" />
                                                                    <%--<asp:BoundField DataField="TotaltransportFee" HeaderText="Annual Transport Fee" ReadOnly="True" />--%>
                                                                    <%--<asp:BoundField DataField="outstabding" HeaderText="Due Fee (Rs.)" ReadOnly="True" />--%>
                                                                    <asp:TemplateField HeaderText="Due Fee(Rs.)">
                                                                    <ItemTemplate>                                                        
                                                                      <%--  <asp:Label ID="lblMale" runat="server" Text='<%#Eval("Male") %>'></asp:Label>--%>
                                                                      <asp:LinkButton ID="lnkDue" runat="server" OnClick="lnkEdit_Click" Text='<%#Eval("outstabding") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                    <asp:BoundField DataField="Advance" HeaderText="Advance Fee (Rs.)" ReadOnly="True" />
                                                                </Columns>
                                                            </asp:GridView>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

