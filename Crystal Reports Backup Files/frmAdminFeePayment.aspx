<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAdminFeePayment.aspx.cs" Inherits="frmAdminFeePayment" %>

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
  <style>
        .note
        {
            text-align: center;
            height: 80px;
            background: -webkit-linear-gradient(left, #0072ff, #8811c5);
            color: #fff;
            font-weight: bold;
            line-height: 80px;
        }
        
        .input-width
        {
            width: 60px;
        }
        .modalPopup
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 10000;
            width: 100%;
            height: 100%;
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            z-index: -1;
        }
        
        .MyTabStyle .ajax__tab_body
        {
            font-family: Verdana;
            font-size: 10pt;
            min-height: 1350px;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #d7d7d7;
            margin-top: -1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function showLoader(){
        $("#myLoadingElement").show();
    };
    function hideLoader() {
        $("#myLoadingElement").hide();
    };
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
                                                <table width="100%">
                                                            </tr>


                                                    <tr>
                                                        <td>
                                                            <center>
                                                                <table width="80%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblstd" runat="server" 
                                                                                Style="position: relative; top: 0px !important" Text="Standard"></asp:Label>
                                                                        </td>
                                                                        <td width="200">
                                                                            <asp:DropDownList ID="drpstandard" runat="server" AutoPostBack="True" 
                                                                                OnSelectedIndexChanged="drpstandard_SelectedIndexChanged" Width="30%">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </center>

                                                        </td>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="intStudFee_id" OnRowDeleting="grvDetail_RowDeleting" 
                                                                    OnRowEditing="grvDetail_RowEditing" PageSize="20" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="vchStandard_name" HeaderText="Standard" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchDivisionName" HeaderText="Division" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="intStudentID_Number" HeaderText="Student ID" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="student_name" HeaderText="Name" ReadOnly="True" />
                                                                        <asp:BoundField DataField="intRoll_no" HeaderText="Roll No" ReadOnly="True" />
                                                                        <asp:BoundField DataField="overallDiscount" HeaderText="Discount" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchNet_amt" HeaderText="Total Paid Amount" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchRemark" HeaderText="Remark" ReadOnly="True" />
                                                                        <asp:BoundField DataField="ModeOfPayment" HeaderText="Payment Mode" 
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
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                             <div id="myLoadingElement" style="display: none;">
                                                        <img src="img/ajax-loader.gif" alt="Loading..." />
                                                 </div>
                                             
                                                <table width="36%" style="text-align: right; margin:0 0 0 2%;">
                                                 
                                                    <tr>
                                                     <td align="justify">
                                                            <asp:Label ID="Label3" runat="server" >StudentId<font color="red">*</font></asp:Label>
                                                        </td>
                                                    <td align="justify" style="width:50%;">
                                                       <%-- <asp:DropDownList ID="ddlStudent" Width="155px"  runat="server" 
                                                            AutoPostBack="True"  OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>--%>

                                                     <asp:TextBox ID="txtStudentId" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off" Width="90px" AutoPostBack="true" OnTextChanged="txtStudentId_TextChanged" ></asp:TextBox>

                                                    </td>

                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server">&nbsp;&nbsp;From <font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtFromDate" runat="server" Width="90px" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>
                                                               <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:Label ID="Label1" runat="server" >To&nbsp;Date<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="input-blue" AutoPostBack="true"  OnTextChanged="txtToDate_TextChanged"  MaxLength="30" AutoComplete="Off"></asp:TextBox>

                                                             <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtToDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                        </td>
                                                        
                                                    </tr>
                                                        
                                                      <tr>
                                                        <%--<td align="justify">
                                                            <asp:Label ID="Label1" runat="server" Text="To Date"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>

                                                             <asp:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtToDate"
                                                             runat="server" Enabled="True"></asp:CalendarExtender>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                          <%--<td align="justify">
                                                            <asp:Label ID="Label3" runat="server" Text="StudentId"></asp:Label>
                                                        </td>
                                                    <td align="justify" style="    width: 50px;">
                                                       

                                                     <asp:TextBox ID="txtStudentId" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off" AutoPostBack="true" OnTextChanged="txtStudentId_TextChanged" ></asp:TextBox>

                                                    </td>--%>
                                                      
                                                  
                                                     </tr>

                                                    <tr>
                                                         
                                                        <td align="justify">
                                                            <asp:Label ID="Label6" runat="server" Text="Name"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtName" runat="server" CssClass="input-blue" Width="90px" MaxLength="30" AutoComplete="Off"></asp:TextBox>

                                                        </td>
                                                        
                                                         <td align="justify">
                                                            <asp:Label ID="Label9" runat="server" >&nbsp;&nbsp;Standard&nbsp;</asp:Label> 
                                                        </td>
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtStanderd" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off" Width="100px"></asp:TextBox>

                                                        </td>
                                                          <td align="justify">
                                                            <asp:Label ID="Label4" runat="server" >&nbsp;&nbsp;Div&nbsp;</asp:Label> 
                                                        </td>
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtDiv" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off" Width="100px"></asp:TextBox>

                                                        </td>
                                                         <td align="justify">
                                                            <asp:Label ID="Label7" runat="server" >&nbsp;&nbsp;Roll&nbsp;No&nbsp;</asp:Label> 
                                                        </td>
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtRollNo" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off" Width="100px"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                   
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
                                                <table width="50%" style="text-align: right; margin:0 0 0 2%;">
                                                <tr>
                                                        <td>
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"  Enabled="true"
                                                             PageSize="25"  OnRowDeleting="OnRowDeleting" HorizontalAlign="Center" OnRowDataBound="OnRowDataBound" 
                                                             CssClass="table  tabular-table "  Width="40%"  >
                                                              <HeaderStyle  />
                                                                <Columns>  
                                                                     <asp:BoundField  DataField="intFeemaster_id" HeaderText="id" Visible="false" />
                                                                    <asp:BoundField  DataField="Fee_Name" HeaderText="Fee Name"/>
        
                                                                     <asp:BoundField  DataField="month" HeaderText="Month" />  
        
                                                                    <asp:BoundField  DataField="vchfee" HeaderText="Amount" />

                                                                    <asp:BoundField  DataField="vchLateCharge" HeaderText="Late Fee" />
                                                                       <asp:TemplateField HeaderText = "Late Amt (Rs.)" >
                                                                           <itemstyle horizontalalign="Right" />
                                                                    <ItemTemplate>        
                                                                        <asp:TextBox ID="txtlatecharges" style="text-align:left;" Text="0" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtlatecharges_TextChanged"  onkeyup="ValidateText(this);" ></asp:TextBox>
                                                                    </ItemTemplate>
                                                                      </asp:TemplateField>

                                                                    <asp:BoundField  DataField="vchconssion" HeaderText="Concession" />
                                                                     <asp:TemplateField HeaderText = "Concession Amt (Rs.)" >
                                                                    <ItemTemplate>        
                
                                                                        <%--<asp:DropDownList ID="ddlprocess1" runat="server"  > </asp:DropDownList>--%>            
                                                                        <asp:TextBox ID="txtConssion" Text="0"  runat="server" AutoPostBack="true" OnTextChanged="txtConssion_TextChanged"  onkeyup="ValidateText(this);" ></asp:TextBox>
<%--                                                                               <asp:RegularExpressionValidator ID="regUnitsInStock" runat="server" ControlToValidate="txtConssion" ErrorMessage="Only numbers allowed"
                                                                                ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" Display="Dynamic"></asp:RegularExpressionValidator>--%>
 
                                                                    </ItemTemplate>
                                                                      </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText = "Net Amount (Rs.)" >
                                                                    <ItemTemplate>        
                
                                                                        <%--<asp:DropDownList ID="ddlprocess1" runat="server"  > </asp:DropDownList>--%>            
                                                                        <asp:TextBox ID="txtAmount" runat="server" ReadOnly="true"></asp:TextBox>
                                                                        
                                                                    </ItemTemplate>
                                                                      </asp:TemplateField>
                                                                     <asp:CommandField ShowDeleteButton="True" ButtonType="Button" HeaderText="Action" />

                                                                </Columns>
                                                         </asp:GridView>
                                                        </td>
                                                    <td>
                                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True"  Enabled="true"
                                                             PageSize="25" OnRowDataBound="GridView2_RowDataBound"  DataKeyNames="intAdminFeeChild_id" HorizontalAlign="Center"  CssClass="table  tabular-table "  Width="50%" ShowFooter="True" >
                                                              <HeaderStyle  />
                                                                <Columns>
                                                                     <asp:BoundField  DataField="intAdminFeeChild_id" HeaderText="id" />
                                                                    <asp:BoundField  DataField="Fee_Name" HeaderText="FeeName" />       
                                                                      <asp:BoundField  DataField="month" HeaderText="Month" />  
                                                                    <asp:BoundField  DataField="vchfee" HeaderText="Amount" />
                                                                    <asp:BoundField  DataField="vchconssion" HeaderText="Conssion" />
                                                                     <asp:TemplateField HeaderText = "ConssionAmt" >
                                                                           <itemstyle horizontalalign="Right" />
                                                                    <ItemTemplate>        
                                                                        <asp:TextBox ID="txtConssion" style="text-align:left;" Text="0"  runat="server" AutoPostBack="true" OnTextChanged="txtConssion_TextChanged"  onkeyup="ValidateText(this);" ></asp:TextBox>
                                                                    </ItemTemplate>
                                                                      </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText = "Net Amount" >
                                                                        <itemstyle horizontalalign="Right" />
                                                                    <ItemTemplate >        

                                                                        <asp:TextBox ID="txtAmount" runat="server" style="text-align:left;" ></asp:TextBox>
                                                                        
                                                                    </ItemTemplate>
                                                                  
                                                                      </asp:TemplateField>
                                                                     <asp:CommandField ShowDeleteButton="True" ButtonType="Button" HeaderText="Action" />
                                                                </Columns>
                                                         </asp:GridView>
                                                        </td>
                                                </tr>
                                                                    </table>            
                                            <table width="50%" style="text-align: right; margin:0 0 0 2%;">
                                               
                                                    <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="Label12" runat="server" Text="Total Amount"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtTotalAmt" runat="server" ReadOnly="true" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="Label13" runat="server" Text="Discount"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtDiscount" runat="server" CssClass="input-blue" MaxLength="30" Text="0" AutoPostBack="true"  OnTextChanged="txtDiscount_TextChanged" AutoComplete="Off"   onkeyup="ValidateText(this);"></asp:TextBox>

                                                               <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                                    TargetControlID="txtDiscount" Enabled="True">
                                                                </asp:FilteredTextBoxExtender>

                                                        </td>
                                                    </tr>
                                                      <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="Label15" runat="server" Text="Net Amount Receivable"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtnetamt" runat="server" ReadOnly="true" CssClass="input-blue" MaxLength="30" Text="0" AutoComplete="Off"></asp:TextBox>

                                                        </td>
                                                    </tr>

                                                <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="Label10" runat="server" Text="Remarks"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                             <asp:TextBox ID="txtRemarks" runat="server" CssClass="input-blue" MaxLength="30" AutoComplete="Off"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                 <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="Label11" runat="server" Text="Payment Mode"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            
                                                                             <asp:DropDownList ID="ddlPayment" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlPayment_Change" >
                                                                                
                                                                                     <asp:ListItem  Selected="True" Value="1">Cash</asp:ListItem>
                                                                                 <asp:ListItem  Value="2">Bank</asp:ListItem>
                                                                             </asp:DropDownList>          
                                                                            
                                                        </td>
                                                      
                                                    </tr>
                                                 <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="lblcheque" runat="server"  Text="Cheque No"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtChequeNo" CssClass="input-blue" runat="server"></asp:TextBox>
                                                                            
                                                        </td>
                                                    </tr>
                                                 <tr>
                                                      
                                                      <td align="justify">
                                                            <asp:Label ID="lblbank" runat="server" Text="Bank Name"></asp:Label>
                                                        </td>
                                                        
                                                       
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtBankName" runat="server" CssClass="input-blue"></asp:TextBox>
                                                                            
                                                        </td>
                                                    
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                    </td>
                                                     <td>
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="vclassrooms_send"
                                                                            UseSubmitBehavior="false"
                                                                            OnClientClick="this.disabled='true', this.value='Please Wait...';" onclick="btnSubmit_Click" />
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

