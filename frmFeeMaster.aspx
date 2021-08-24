<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmFeeMaster.aspx.cs" Inherits="frmFeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript">
      function isNumberKey(evt)
      {
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
                                                        
                                                        <td align="left">
                                                        <asp:Label ID="Label8" runat="server" >Standard:</asp:Label>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlStandardSearch" runat="server"  onselectedindexchanged="ddlStandardSearch_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList> 
                                                        </td>
                                                        
                                                          
                                                     <%--<td>
                                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="vclassrooms_send"     onclick="btnSearch_Click" />
                                                        </td>--%>
                                                    </tr>
                                                    
                                                </table>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%" 
                                                                DataKeyNames="intFeemaster_id" onrowdeleting="grvDetail_RowDeleting" onrowediting="grvDetail_RowEditing"
                                                                >
                                                                <Columns>
                                                                  <asp:BoundField DataField="Fee_Name" HeaderText="FeeName" ReadOnly="True" />
                                                                  <asp:BoundField DataField="FeeTypeName" HeaderText="FeeTypeName" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchStandard_name" HeaderText="StandardName" ReadOnly="True" />
                                                                    
                                                                  <asp:BoundField DataField="intFeetype_id" HeaderText="FeeType" ReadOnly="True" />
                                                                  <asp:BoundField DataField="dtstart_date" HeaderText="Start&nbsp;Date" ReadOnly="True" /> 
                                                                  <asp:BoundField DataField="dtduetill_date" HeaderText="Till Date" ReadOnly="True" />
                                                                  <asp:BoundField DataField="vchconssion" HeaderText="Concession" ReadOnly="True" /> 
                                                                     
                                                                  <asp:BoundField DataField="vchfee" HeaderText="FeeAmt" ReadOnly="True" /> 
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
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
                                                            <asp:Label ID="Label2" runat="server" >Fee Name<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr
                                                        
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label1" runat="server" >Fee Type<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                           <%-- <asp:TextBox ID="txtNamePer" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>--%>
                                                             <asp:DropDownList ID="ddlFeeType" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label3" runat="server" >Start Date<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDueDate" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                             <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtDueDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify" class="style1">
                                                            <asp:Label ID="Label4" runat="server" >Due till Date<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtDueTilldate" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtDueTilldate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label7" runat="server" Text="Concession"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                               <asp:RadioButton ID="rbYES" AutoPostBack="true" OnCheckedChanged="rbYES_CheckedChanged"   runat="server" Checked="true" Text="Yes"/>  
                                                               <asp:RadioButton ID="rbNo" AutoPostBack="true" OnCheckedChanged="rbNo_CheckedChanged"  runat="server" Text="No"  />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label5" runat="server" >Standard<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                              <asp:DropDownList ID="ddlStandard" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label6" runat="server" >Fee<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                             <asp:TextBox ID="txtFee" runat="server" CssClass="input-blue" MaxLength="7" onkeypress="return isNumberKey(event)" AutoComplete="Off"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtName"
                                                                Display="None" ErrorMessage="Please Enter Category"></asp:RequiredFieldValidator>
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

