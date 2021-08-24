<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmOnlinePaymentReport.aspx.cs" Inherits="frmOnlinePaymentReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" language="javascript">
         function ValidateText(val) {
             var intValue = parseInt(val.value, 10);

             if (isNaN(intValue)) {
                 alert("please enter only number");
             }
         }

</script>
<script type="text/javascript">
    function OpenModal() {
        $('#myModal').modal();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header content-header1 pd-0">
       
        <ul class="top_navlg">
        <li><a >Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        <li><a >School Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a href="frmSchoolEntry.aspx">School Master</a></li>
             <li><a href="frmNetworkAdmMaster.aspx">SMS Master</a></li>
            <li><a href="frmAcademicYearMaster.aspx">Academic Year Master</a></li>
            <li class="active1"><a href="frmCategoryMaster.aspx">Category Master</a></li>
            <li><a href="frmLectureTypeMaster.aspx">Lecture Type Master</a></li>
            <li><a href="frmDepartmentMaster.aspx">Department Master</a></li>
            <li><a href="frmDesignationMaster.aspx">Designation Master</a></li>
            <li><a href="frmExamMaster.aspx">Exam Master</a></li>
            <li><a href="frmExamType.aspx">Exam Type Master</a></li>
            <li><a href="frmExamSubjectLink.aspx">Exam Passing Criteria</a></li>
            <li><a href="frmLeaveTypeMaster.aspx">Leave Type Master</a></li>
            <li><a href="frmHolidayTypeMaster.aspx">Holiday Type Master</a></li>
            <li><a href="frmVacationTypeMaster.aspx">Vacation Type Master</a></li>
            <li><a href="frmStatusMaster.aspx">Status Master</a></li>
            <li><a href="frmSessionMaster.aspx">Session Master</a></li>
            <li><a href="frmPeriod_Master.aspx">Period Master</a></li>
            <li><a href="frmStandardMaster.aspx">Standard Master</a></li>
            <li><a href="frmDivision_master.aspx">Division Master</a></li>
            <li><a href="frmSubject_Entry.aspx">Subject Master</a></li>
            <li><a href="frmAdmLectureAssign.aspx">Lecture Schedule</a></li>
            <li><a href="FrmRouteMaster.aspx">Route Master</a></li>
            <li><a href="frmBloodGroupMaster.aspx">Blood Group Master</a></li>
            <li><a href="frmCountryMaster.aspx">Country Master</a></li>
            <li><a href="frmStateMaster.aspx">State Master</a></li>
            <li><a href="frmCityMaster.aspx">City Master</a></li>
            <li><a href="frmAdmStudentProfile.aspx">Student Master</a></li>
            <li><a href="FrmAdmTeacherProfile.aspx">Teacher Master</a></li>
            <li><a href="FrmAdminStaffProfile.aspx">Staff Master</a></li>
            <li><a href="FrmAdminMaster.aspx">Admin Master</a></li>
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
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                         <div class="vclassrooms">
                                                <table style="font-weight: bolder; width: 60%; margin: 10px 0;" align="center">
                                                    <tr id="teachhide" runat="server">
                                                        <td id="Td127" runat="server" align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label86" runat="server" Font-Bold="False">Standard</asp:Label>
                                                        </td>
                                                        <td id="Td1" runat="server" style="padding-top: 10px">
                                                            <asp:DropDownList ID="drpstandard" runat="server" Width="140px" OnSelectedIndexChanged="drpstandard_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpstandard"
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
                                                         <td width="30%">
                                                           <%-- <asp:Button ID="btnReport" runat="server" CssClass="vclassrooms_send" 
                                                                    Text="Report" onclick="btnReport_Click" Visible="False"  />--%>
                                                        </td> 
                                                        <td>
                                                            <%--<asp:Button ID="btnExcel" runat="server" Text="Export" width="100%"
                                                            CssClass="btn btn-success col-md-5" style="margin-right:1px;" OnClientClick="HideLoader();" 
                                                             OnClick="btnExcel_Click"></asp:Button>--%>
                                                             <asp:Button ID="BtnExportToExcel" runat="server" CssClass="btn btn-success col-md-5"   OnClick="BtnExportToExcel_Click"
                                                                               Text="Export To Excel" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <center>
                                                <table width="100%">
                                                            


                                                    <tr>
                                                      
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="intStudFee_id" OnRowDeleting="grvDetail_RowDeleting" 
                                                                    OnRowEditing="grvDetail_RowEditing" PageSize="20" Width="100%">
                                                                    <Columns>
                                                                     <asp:BoundField DataField="intStudentID_Number" HeaderText="Student ID" 
                                                                            ReadOnly="True" />
                                                                             <asp:BoundField DataField="intRoll_no" HeaderText="Roll No" ReadOnly="True" />
                                                                         <asp:BoundField DataField="student_name" HeaderText="Name" ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchDivisionName" HeaderText="Division" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="overallDiscount" HeaderText="Discount" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchNet_amt" HeaderText="Total Paid Amount" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchRemark" HeaderText="Remark" ReadOnly="True" />
                                                                        <asp:BoundField DataField="ModeOfPayment" HeaderText="Payment Mode" 
                                                                            ReadOnly="True" />
                                                                            <asp:BoundField DataField="dtInserted_date" HeaderText="Payment Date" 
                                                                            ReadOnly="True" />
                                                                            <asp:BoundField DataField="status" HeaderText="Payment Status" 
                                                                            ReadOnly="True" />
                                                                        <asp:TemplateField HeaderText="Details">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" 
                                                                                    CommandName="Edit" ImageUrl="~/images/edit.png" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Receipt">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgReceipt" runat="server" CausesValidation="false" 
                                                                                    CommandName="Delete" ImageUrl="~/images/print.png" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <div ID="myModal" class="modal fade" role="dialog">
                                                                    <div class="modal-dialog">
                                                                        <!-- Modal content-->
                                                                        <div class="modal-content">
                                                                            <div class="modal-header">
                                                                                <button class="close" data-dismiss="modal" type="button">
                                                                                    ×
                                                                                </button>
                                                                                <h4 class="modal-title">
                                                                                    Fee Details</h4>
                                                                            </div>
                                                                            <div class="modal-body">
                                                                                <p>
                                                                                    <asp:GridView ID="GridView3" runat="server" AllowSorting="True" 
                                                                                        AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                                        DataKeyNames="intStudFee_DetailId" OnRowDeleting="grvDetail_RowDeleting" 
                                                                                        OnRowEditing="grvDetail_RowEditing" PageSize="20" ShowFooter="True" 
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="intStudFee_DetailId" 
                                                                                                HeaderText="intStudFee_DetailId" ReadOnly="True" Visible="False" />
                                                                                            <asp:BoundField DataField="Fee_Name" HeaderText="Fee Name" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="intMonth_id" HeaderText="Month" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="vchAmount" HeaderText="Amount" ReadOnly="True" />
                                                                                            <asp:BoundField DataField="vchLate_charges" HeaderText="Late Fee" 
                                                                                                ReadOnly="True" />
                                                                                            <asp:BoundField DataField="intConcession_amt" HeaderText="Concession Amt" 
                                                                                                ReadOnly="True" />
                                                                                            <asp:BoundField DataField="vchNetDetail_amt" HeaderText="Net Amount" 
                                                                                                ReadOnly="True" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </p>
                                                                            </div>
                                                                            <div class="modal-footer">
                                                                                <button class="btn btn-default" data-dismiss="modal" type="button">
                                                                                    Close
                                                                                </button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
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
</section>
</asp:Content>


