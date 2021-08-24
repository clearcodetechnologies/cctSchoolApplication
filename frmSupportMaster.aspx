<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmSupportMaster.aspx.cs" Inherits="frmSupportMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
   </script>
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
              <li><a href="frmFeetypeMaster.aspx">FeeType Master</a></li>
              <li><a href="frmConcessionMaster.aspx">Concession Master</a></li>
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
                                            <center>
                                                <table align="left">
                                                    <tr>
                                                     </tr>
                                                </table>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%"  OnRowEditing="grvDetail_RowEditing" 
                                                                DataKeyNames="int_id"  >
                                                                <Columns>
                                                                  <asp:BoundField DataField="Phone_Number" HeaderText="Phone Number" ReadOnly="True" />
                                                                  <asp:BoundField DataField="EmailID" HeaderText="Email ID" ReadOnly="True" />
                                                                    <asp:BoundField DataField="FromTime" HeaderText="From Time" ReadOnly="True" />
                                                                    
                                                                  <asp:BoundField DataField="ToTime" HeaderText="To Time" ReadOnly="True" />
                                                                  <asp:BoundField DataField="ContactPersonName" HeaderText="Contact Person" ReadOnly="True" /> 
                                                                  
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
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
                                            
                                                <table width="36%" style="text-align: right; margin:0 0 0 2%;">
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
                                                            <asp:Label ID="Label2" runat="server" >Phone Number<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtphoneno" runat="server" CssClass="input-blue" MaxLength="12" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr
                                                          <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label5" runat="server" >Contact Person Name<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtperson" runat="server" CssClass="input-blue" MaxLength="20" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr
                                                        
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label1" runat="server" >Email ID<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtEmailID" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label3" runat="server" >From Time<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="TextBox3" Width="100%" CssClass="input-blue" Style="float: left"
                                                runat="server" AutoPostBack="True" Font-Bold="False"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="refvdt1" runat="server" ControlToValidate="TextBox3" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValiCaEr1" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TextBox3"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="mark1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox3" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="VrCEer2" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify" class="style1">
                                                            <asp:Label ID="Label4" runat="server" >To Time<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                          <asp:TextBox ID="TextBox1" Width="100%" CssClass="input-blue" Style="float: left"
                                                runat="server" AutoPostBack="True" Font-Bold="False"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox1"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox1" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="right" style="padding-left:-20px">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="vclassrooms_send"
                                                                            OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px" Visible="false"
                                                                            CssClass="vclassrooms_send" Text="Clear" CausesValidation="False" />
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

