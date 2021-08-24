<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTansportMaster.aspx.cs" Inherits="frmTansportMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .mGrid th
        {
            text-align: center !important;
        }
        .vclassrooms textarea
        {
            width: 97% !important;
        }
        .vclassrooms input[type=checkbox], input[type=radio]
        {
            float: left;
        }
        .vclassrooms input[type=checkbox] + label {<a href="frmTransportFee.aspx">frmTransportFee.aspx</a>
            display: block;
            /* width: auto !important; */
            /* height: auto !important; */
            border: 0.0625em solid rgb(192,192,192);
            border-radius: 0.25em;
            /* background: white !important; */
            vertical-align: middle;
            line-height: 1em;
            /* font-size: 14px; */
            /* color: #000; */
            padding: 1px 0px;
            text-align: center;
            width: 30px;
            /* height: 50px; */
            margin-top: 3px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        //        function confirm() {
        //            if (Page_ClientValidate() == false) {
        //                return false;
        //            }
        //            else {

        //                var atLeast = 1;
        //                var count = 0;
        //                var chkLst = document.getElementById('<%=chkSTD.ClientID %>');
        //                var chk = chkLst.getElementsByTagName("input");
        //                for (var i = 0; i < chk.length; i++) {
        //                    if (chk[i].checked) {
        //                        count++;
        //                    }
        //                }
        //                if (atLeast > count) {
        //                    alert('Please Select Atleast One Standard');
        //                    return false;
        //                }
        //                //ConfMsg();

        //            }
        //        }

        function ConfMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {

                if (confirm('Do You Really Want To Save Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {

                if (confirm('Do You Really Want To Update Entered Record?')) {
                    return true;
                }
                else {
                    return false;
                }
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
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="content-header pd-0">
       
        <ul class="top_nav">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >Fee Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmDurationMaster.aspx">Duration Master</a></li>
             <li><a href="frmYearlyMaster.aspx">Yearly Master</a></li>
            <li><a href="frmHalfYearlyMaster.aspx">Half Yearly Master</a></li>
            <li><a href="frmQuartarlyMaster.aspx">Quarterly Master</a></li>
            <li><a href="frmFeeHead.aspx">Fee Head </a></li>
            <li class="active1"><a href="frmFeesAssignMst.aspx">Fee Chart</a></li>
        </ul>
    </div>
<section class="content">
    <div style="padding: 10px 0 0 0">
       
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail</HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <div class="vclassrooms" id="vclassrooms">
                                                                <table width="70%">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label6" runat="server" Text="Area" ></asp:Label>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:DropDownList ID="ddlSTD" runat="server"  OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged"
                                                                                AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table" Width="70%" OnRowDataBound="grvDetail_RowDataBound" AllowPaging="false"
                                                                DataKeyNames="intTransport_id" OnRowEditing="grvDetail_RowEditing" OnRowDeleting="grvDetail_RowDeleting">
                                                                <Columns>
                                                                <asp:TemplateField HeaderText="intTransport_id" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("intTransport_id") %>'></asp:Label></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchArea_Name" HeaderText="Particulars" ReadOnly="True" />
                                                                    <asp:BoundField DataField="dtStart_date" HeaderText="Start Date" ReadOnly="True" />
                                                                    <asp:BoundField DataField="dtEnd_date" HeaderText="End Date" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Startday" HeaderText="Start Day" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Dueday" HeaderText="Due Day" ReadOnly="True" />
                                                                    <asp:BoundField DataField="numAmout" HeaderText="Amount" ReadOnly="True" />       
                                                                     <asp:BoundField DataField="IsConcession" HeaderText="Concession" ReadOnly="True" />                                    
                                                                    
                                                                   
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="False"
                                                                                ImageUrl="~/images/delete.png" /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                      <%-- Total Annual Fee : <asp:Label ID="lblTotal" runat="server" ></asp:Label>--%>
                                                    </td>
                                                    </tr>
                                                </table>
                                                </div></center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry</HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <div class="vclassrooms" style="background-color:White;">
                                                    <table width="50%" style="margin-left:2%;">
                                                        
                                                        <tr>
                                                            <td  class="style5" align="left">
                                                                <asp:Label ID="Label2" runat="server"  Text="Area"></asp:Label>
                                                            </td>
                                                            <td class="auto-style6" align="left" valign="top">
                                                                 <asp:DropDownList ID="chkSTD" runat="server"    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                       
                                                       <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label1" runat="server"  Text="Start Date"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtFromDate" runat="server"  CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                               <asp:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                             <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate" Display="None" ErrorMessage="Please Select Start Date">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                               <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtAmt" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>--%>
                                                            </td>
                                                        </tr>


                                                          <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label7" runat="server"  Text="End Date"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="input-blue"  MaxLength="30" AutoComplete="Off">
                                                                </asp:TextBox>
                                                             <asp:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" TargetControlID="txtToDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                             <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please Select End Date">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                               <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtAmt" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>--%>
                                                            </td>
                                                        </tr>

                                                        
                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label8" runat="server"  Text="Concession"></asp:Label>
                                                            </td>
                                                            <td align="justify">
                                                               <asp:RadioButton ID="rbtnYes" runat="server"  GroupName="Concession"    Text="Yes" Checked="true" /><br />
                                                               <asp:RadioButton ID="rtbnNo" runat="server" GroupName="Concession"    Text="No" />
                                                           
                                                            </td>
                                                           
                                                        </tr>

                                                         <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label9" runat="server"  Text="Start Day"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtStartday" runat="server" CssClass="input-blue"  MaxLength="30" AutoComplete="Off">
                                                                </asp:TextBox>
                                                             <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartday"  ErrorMessage="Please Select Start Day">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                                    TargetControlID="txtStartday" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label10" runat="server"  Text="Due Day"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtDueday" runat="server" CssClass="input-blue"  MaxLength="30" AutoComplete="Off">
                                                                </asp:TextBox>
                                                             <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDueday"  ErrorMessage="Please Select Due Day">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers"
                                                                    TargetControlID="txtDueday" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="style4" align="left">
                                                                <asp:Label ID="Label3" runat="server"  Text="Amount"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAmt" runat="server" Width="100%" CssClass="input-blue" MaxLength="7"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="R2" runat="server" ControlToValidate="txtAmt" Display="None" ErrorMessage="Please Enter Amount"
                                                                   ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="V3"
                                                                        TargetControlID="R2" runat="server" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:FilteredTextBoxExtender ID="FT" runat="server" FilterType="Custom, Numbers"
                                                                    ValidChars="." TargetControlID="txtAmt" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr1" visible="False" runat="server">
                                                            <td id="Td1" class="style5" align="left" runat="server">
                                                                <asp:Label ID="Label4" runat="server"  Text="Effective Date"></asp:Label>
                                                            </td>
                                                            <td id="Td2" width="100%" runat="server">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left"  width="50%">
                                                                            <asp:TextBox ID="txtFrmDt" runat="server" Style="width: 91%;" ></asp:TextBox><asp:CalendarExtender
                                                                                ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy"
                                                                                Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                                WatermarkText="From Date" Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:RequiredFieldValidator ID="R4" runat="server" ControlToValidate="txtFrmDt" Display="None"
                                                                                ErrorMessage="Please Enter From Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V4" TargetControlID="R4" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                        <td>
                                                                            &#160;&#160;
                                                                        </td>
                                                                        <td align="left"  width="70%">
                                                                            <asp:TextBox ID="txtToDt" runat="server" Width="94%" CssClass="input-blue"></asp:TextBox><asp:TextBoxWatermarkExtender
                                                                                ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt" WatermarkText="To Date"
                                                                                Enabled="True">
                                                                            </asp:TextBoxWatermarkExtender>
                                                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDt"
                                                                                Format="dd/MM/yyyy" Enabled="True">
                                                                            </asp:CalendarExtender>
                                                                            <asp:CompareValidator ID="CV1" runat="server" Display="None" ControlToValidate="txtToDt"
                                                                                ControlToCompare="txtFrmDt" Type="Date" Operator="GreaterThanEqual" ErrorMessage="From Date Should Be Less Than Or Equal To ToDate"
                                                                                ></asp:CompareValidator><asp:ValidatorCalloutExtender ID="V1"
                                                                                    TargetControlID="CV1" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                            <asp:RequiredFieldValidator ID="R5" runat="server" ControlToValidate="txtToDt" Display="None"
                                                                                ErrorMessage="Please Enter To Date" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                                    ID="V5" TargetControlID="R5" runat="server" Enabled="True">
                                                                                </asp:ValidatorCalloutExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2" visible="False" runat="server">
                                                            <td id="Td3" class="style6"  align="left" runat="server">
                                                                <asp:Label ID="Label5" runat="server"  Text="Description"></asp:Label>
                                                            </td>
                                                            <td id="Td4" align="left" runat="server">
                                                                <asp:TextBox ID="txtDesc" runat="server" CssClass="input-blue" width="100%" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" OnClick="btnSubmit_Click"
                                                                                Text="Submit" />
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnClear" runat="server" CausesValidation="False" CssClass="vclassrooms_send"
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
       
    </div>
</section>
</asp:Content>