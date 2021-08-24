<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmOutstandingReport.aspx.cs" Inherits="frmOutstandingReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="updat4" runat="server">


        <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >
        
                    <%--<ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                    </ProgressTemplate>--%>
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

                                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        All student Outstanding Report
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <center>
                                        <div style="margin:5px; padding:5px">
                                        <table width="100%">
                                        <tr>
                                        <td>
                                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary"  
                                                                    Text="Export to Excel" onclick="Button2_Click"  />



                                                                   
                                                        </td> 
                                        </tr>
                                        </table>
                                        </div>
                                         <div style="width:1000px; height:500px; position:relative; left:0; overflow-x:auto; overflow-y:auto;">
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" ShowFooter="true" >
                                                                <Columns>
                                                                 <asp:BoundField DataField="Rollno" HeaderText="SR. No" ReadOnly="True" />
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Standard_name" HeaderText="Standard name" ReadOnly="True" />
                                                                <asp:BoundField DataField="DivisionName" HeaderText="Division Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="mnthcount" HeaderText="Month Count" ReadOnly="True" />
                                                           

                                                                <asp:BoundField DataField="Admissionfee" HeaderText="Receivable Admission Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Admission Fee" HeaderText="Paid Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intAdmissionConcession_amt" HeaderText="Concession Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Admissionfeeoutstanding" HeaderText="Outstanding Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="AdmissionfeeAdvance" HeaderText="Advance Admission Fee (Rs.)"  ReadOnly="True" />

                                                                    <asp:BoundField DataField="Exam Fee" HeaderText="Receivable Exam Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Exam Fee" HeaderText="Paid Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intExamFeeConcession_amt" HeaderText="Concession Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Examfeeoutstanding" HeaderText="Outstanding Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="ExamfeeAdvance" HeaderText="Advance Exam Fee (Rs.)"  ReadOnly="True" />


                                                                    <asp:BoundField DataField="ReceivableSessionCharges" HeaderText="Receivable Session Charges (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidSessionCharges" HeaderText="Paid Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intSessionChargesConcessionAmt" HeaderText="Concession Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="SessionChargesoutstanding" HeaderText="Outstanding Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="SessionChargesAdvance" HeaderText="Advance Session Charges (RS.)"  ReadOnly="True" />

                                                                    <asp:BoundField DataField="ReceivableMonthlyfee" HeaderText="Receivable Monthly Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Monthly Fee" HeaderText="Paid Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intMonhlyfeeConcession_amt" HeaderText="Concession Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Monthlyoutstanding" HeaderText="Outstanding Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="MonthlyAdvance" HeaderText="Advance Monthly fee (RS.)" ReadOnly="True" />

                                                                    <asp:BoundField DataField="Total fee" HeaderText="Current Total receive (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidtotalFee" HeaderText="Paid Total (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="TotalConcession" HeaderText="Total Concession (RS.)" ReadOnly="True" />

                                                                    <asp:BoundField DataField="totaloutstanding" HeaderText="Due Fee (Rs.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="totalAdvance" HeaderText="Advancs (RS.)" ReadOnly="True" />
                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                        </div>
                                        </center>
                                        </ContentTemplate>
                                        </asp:TabPanel>
                                        
                                        

                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                        Student Wise Outstanding Report
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
                                                            <asp:DropDownList ID="Droptypeuser" AutoPostBack="True" runat="server" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="50" Width="140px" OnSelectedIndexChanged="Droptypeuser_SelectedIndexChanged"
                                                                ValidationGroup="b">
                                                                <asp:ListItem>---Select---</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Droptypeuser"
                                                                Display="None" ErrorMessage="Select Student " Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator1">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                        </td>
                                                         <td width="30%">
                                                            </td> 
                                                        <td width="30%">
                                                            <asp:Button ID="Button1" runat="server" CssClass="vclassrooms_send" 
                                                                    Text="Export to Excel" onclick="Button1_Click"  />
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
                                                            Total Outstanding Report
                                                        </td>
                                                    </tr>
                                                    <tr id="listparengrid1" runat="server">
                                                        <td id="Td5" style="padding: 10px 0 20px 0;" align="center" runat="server">
                                                           
                                                            <div style =" width:999px; overflow:auto;">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" ShowFooter="true" >
                                                                <Columns>
                                                                 <asp:BoundField DataField="Rollno" HeaderText="SR. No" ReadOnly="True" />
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Standard_name" HeaderText="Standard name" ReadOnly="True" />
                                                                <asp:BoundField DataField="DivisionName" HeaderText="Division Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="mnthcount" HeaderText="Month Count" ReadOnly="True" />
                                                           

                                                                <asp:BoundField DataField="Admissionfee" HeaderText="Receivable Admission Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Admission Fee" HeaderText="Paid Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intAdmissionConcession_amt" HeaderText="Concession Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Admissionfeeoutstanding" HeaderText="Outstanding Admission Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="AdmissionfeeAdvance" HeaderText="Advance Admission Fee (Rs.)"  ReadOnly="True" />

                                                                    <asp:BoundField DataField="Exam Fee" HeaderText="Receivable Exam Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Exam Fee" HeaderText="Paid Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intExamFeeConcession_amt" HeaderText="Concession Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Examfeeoutstanding" HeaderText="Outstanding Exam Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="ExamfeeAdvance" HeaderText="Advance Exam Fee (Rs.)"  ReadOnly="True" />


                                                                    <asp:BoundField DataField="ReceivableSessionCharges" HeaderText="Receivable Session Charges (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidSessionCharges" HeaderText="Paid Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="intSessionChargesConcessionAmt" HeaderText="Concession Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="SessionChargesoutstanding" HeaderText="Outstanding Session Charges (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="SessionChargesAdvance" HeaderText="Advance Session Charges (RS.)"  ReadOnly="True" />

                                                                    <asp:BoundField DataField="ReceivableMonthlyfee" HeaderText="Receivable Monthly Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Monthly Fee" HeaderText="Paid Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intMonhlyfeeConcession_amt" HeaderText="Concession Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Monthlyoutstanding" HeaderText="Outstanding Monthly fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="MonthlyAdvance" HeaderText="Advance Monthly fee (RS.)" ReadOnly="True" />

                                                                    <asp:BoundField DataField="Total fee" HeaderText="Current Total receive (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidtotalFee" HeaderText="Paid Total (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="TotalConcession" HeaderText="Total Concession (RS.)" ReadOnly="True" />

                                                                    <asp:BoundField DataField="totaloutstanding" HeaderText="Due Fee (Rs.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="totalAdvance" HeaderText="Advancs (RS.)" ReadOnly="True" />
                                                                    
                                                                </Columns>
                                                            </asp:GridView>
                                                            </div>
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


