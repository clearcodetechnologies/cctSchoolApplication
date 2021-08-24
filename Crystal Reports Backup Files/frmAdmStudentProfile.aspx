<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmAdmStudentProfile.aspx.cs" Inherits="frmAdmStudentProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        }
    </script>
    <div class="content-header content-header1 pd-0">
        <ul class="top_navlg">
            <li><a>Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a>School Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
            </li>
            <li><a href="frmSchoolEntry.aspx">School Master</a></li>
            <li><a href="frmNetworkAdmMaster.aspx">SMS Master</a></li>
            <li><a href="frmAcademicYearMaster.aspx">Academic Year Master</a></li>
            <li><a href="frmCategoryMaster.aspx">Category Master</a></li>
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
            <li class="active1"><a href="frmAdmStudentProfile.aspx">Student Master</a></li>
            <li><a href="FrmAdmTeacherProfile.aspx">Teacher Master</a></li>
            <li><a href="FrmAdminStaffProfile.aspx">Staff Master</a></li>
            <li><a href="FrmAdminMaster.aspx">Admin Master</a></li>
        </ul>
    </div>
    <section class="content">
            
    <div style="padding: 5px 0 0 0">
        
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
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" 
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            Detail
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                                
                                                <table width="50%">
                                                 <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Standard : " Style="font-size: 13px;"></asp:Label>
                                                    
                                                    </td>
                                                    <td align="justify" style="    width: 50px;">
                                                        <asp:DropDownList ID="ddlStandrd" Width="155px"  runat="server" 
                                                            AutoPostBack="True" onselectedindexchanged="ddlStandrd_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                        <td align="center">
                                                        <asp:Label ID="Label33" runat="server" Font-Bold="False" Text="Division : " Style="font-size: 13px;"></asp:Label>
                                                    
                                                    </td>
                                                    <td align="justify">
                                                        <asp:DropDownList ID="ddlDivision" Width="155px"  runat="server" 
                                                            AutoPostBack="True" onselectedindexchanged="ddlDivision_SelectedIndexChanged">
                                                        </asp:DropDownList></td>

                                                                   <td align="center">


                                                         <asp:Label ID="label41" runat="server" Font-Bold="false" Text="Search: " Style="font-size:13px;"></asp:Label>
                                                     </td>
                                                     <td align="justify">
                                                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Student-Id/Name"></asp:TextBox>
                                                         </td>


                                                    <td align="justify">
                                                        <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Search" OnClick="Button2_Click"></asp:Button>
                                                    </td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%">
                                                    </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="intStudent_id" OnRowDeleting="grvDetail_RowDeleting" 
                                                                    OnRowEditing="grvDetail_RowEditing" PageSize="20" 
                                                                    style="width:98%;border-collapse:collapse;margin:1% auto;">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="intGRNo" HeaderText="REG. No." ReadOnly="True" 
                                                                            Visible="False" />
                                                                        <asp:BoundField DataField="intstanderd_id" HeaderText="Standard" 
                                                                            ReadOnly="True"  Visible="False"/>
                                                                        <asp:BoundField DataField="intDivision_id" HeaderText="Division" 
                                                                            ReadOnly="True" Visible="False" />
                                                                        <asp:BoundField DataField="SrNo" HeaderText="Sr. No" 
                                                                        ReadOnly="True" />

                                                                        <asp:BoundField DataField="intStudentID_Number" HeaderText="Student Id" 
                                                                            ReadOnly="True" />
                                                                       
                                                                       <asp:TemplateField HeaderText="Time (hrs)" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblstudentsid" runat="server" Text='<%# Eval("intStudent_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                               
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Roll No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="txtName" class="input-width" runat="server" Text='<%# Eval("intRollNo") %>'> </asp:Label><%--AutoPostBack="true" OnTextChanged="text_changed" />--%>
                                                                            </ItemTemplate>
                                                                           <%--<ItemStyle Width="50px" />--%>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="vchStudentName" HeaderText="Student Name" 
                                                                            ReadOnly="True" />
                                                                             <asp:BoundField DataField="vchaadhar_no" HeaderText="Student Aadhar" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="intBusAlert1" HeaderText="SMS Alert No." 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True" />
                                                                        <asp:BoundField DataField="Dtdob" HeaderText="DOB" ReadOnly="True" />
                                                                        <asp:BoundField DataField="chrBloodGrp" HeaderText="Blood Group" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchMOtherName" HeaderText="Mother Name" 
                                                                            ReadOnly="True" />
                                                                        <asp:BoundField DataField="vchpresentAddress" HeaderText="Address" 
                                                                            ReadOnly="True" />
                                                                        <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" 
                                                                                    CommandName="Edit" ImageUrl="~/images/edit.png" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" 
                                                                                    CommandName="Delete" ImageUrl="~/images/delete.png" 
                                                                                    OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                </table>
                                           
                                        </ContentTemplate>
                                    </asp:TabPanel>

                                      <%--  <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2" >
                                        <HeaderTemplate>
                                            Fee Details
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                          
                                            <table width="96%">
                                           <table>
                                           <th>Concession</th>
                                          <tr>
                                          <td>
                                          <asp:Label ID="lblcon" runat="server" Text="Concession"></asp:Label>
                                          </td>
                                          <td>
                                          <asp:DropDownList ID="drpconcession" Width="225px"  runat="server" >
                                                        </asp:DropDownList>
                                          </td>
                                          </tr>
                                             <tr>
                                          <td>
                                          <asp:Label ID="Label45" runat="server" Text="Start Date"></asp:Label>
                                          </td>
                                          <td>
                                            <asp:TextBox ID="TextBox3" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="TextBox3" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                          </tr>
                                          <tr>
                                          <td>
                                          <asp:Label ID="Label46" runat="server" Text="To Date"></asp:Label>
                                          </td>
                                          <td>
                                            <asp:TextBox ID="TextBox4" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="TextBox4" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                          </tr>
                                          <tr>
                                          <td colspan="2"> 
                                          <asp:Button ID="btnSaveConcession" class="btn btn-success" runat="server" Text="Save" OnClick="btnSaveConcession_Click"></asp:Button>
                                          </td>
                                          </tr>
                                           </table> 
                                             
                                           <table>
                                           <tr>
                                           <td>
                                           <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="int_ID"  
                                                                    style="width:98%;border-collapse:collapse;margin:1% auto;">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="int_ID" HeaderText="int_ID." ReadOnly="True" 
                                                                            Visible="False" />
                                                                        <asp:BoundField DataField="vchConcession_name" HeaderText="Concession Name" 
                                                                            ReadOnly="True"  Visible="true"/>

                                                                        <asp:BoundField DataField="dtfrom_date" HeaderText="From Date" 
                                                                            ReadOnly="True" />
                                                                     
                                                                        <asp:BoundField DataField="dtto_date" HeaderText="To Date" 
                                                                            ReadOnly="True" />
                                                                       
                                                                    </Columns>
                                                                </asp:GridView>
                                           </td>
                                           </tr>
                                           </table>
                                           </table>           
                                        </ContentTemplate>
                                    </asp:TabPanel>
--%>

<asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">
                                        <HeaderTemplate>
                                            Fee Details
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                        <table width="50%">
                                        <tr>
                                        <td align="justify" style="    width: 50px;">
                                                        <asp:Label ID="Label44" runat="server" Font-Bold="False" Text="Fee Type : " Style="font-size: 13px;"></asp:Label>
                                                    
                                                    </td>
                                        <td align="justify" style="    width: 50px;">
                                                        <asp:DropDownList ID="ddlexamstdsub" Width="155px"  runat="server" 
                                                            AutoPostBack="True"  onselectedindexchanged="ddlexamstdsub_SelectedIndexChanged">
                                                            <asp:ListItem Value="0" Text="--- Select ---"></asp:ListItem>                                                            
                                                            <asp:ListItem Value="1" Text="Concession"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Transport Fee"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                        </tr>
                                        </table>

                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="Concession" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Concession</th>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="lblcon" runat="server" Text="Concession"></asp:Label>
                                            </td>
                                            <td runat="server">
                                           <asp:DropDownList ID="drpconcession" Width="225px"  runat="server" >
                                                        </asp:DropDownList>
                                          
                                          </td>
                                           </tr>
                                           <tr runat="server">
                                          <td runat="server">
                                         <asp:Label ID="Label45" runat="server" Text="Start Date"></asp:Label>
                                         </td>
                                         <td runat="server">
                                            <asp:TextBox ID="TextBox3" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="TextBox3" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                         <asp:Label ID="Label46" runat="server" Text="To Date"></asp:Label>
                                          </td>
                                          <td runat="server">
                                            <asp:TextBox ID="TextBox4" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="TextBox4" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                         </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                          <td runat="server">
                                         <asp:Button ID="btnSaveConcession" class="btn btn-success" runat="server" Text="Save" OnClick="btnSaveConcession_Click"></asp:Button>
                                          </td>
                                          <td runat="server">
                                         
                                          </td>
                                          </tr>
                                          <tr runat="server">
                                          <td colspan="3" runat="server">
                                          <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="int_ID"  OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting"
                                                                    style="width:98%;border-collapse:collapse;margin:1% auto;">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="int_ID" HeaderText="int_ID." ReadOnly="True" 
                                                                            Visible="False" />
                                                                        <asp:BoundField DataField="vchConcession_name" HeaderText="Concession Name" 
                                                                            ReadOnly="True"/>

                                                                        <asp:BoundField DataField="dtfrom_date" HeaderText="From Date" 
                                                                            ReadOnly="True" />
                                                                     
                                                                        <asp:BoundField DataField="dtto_date" HeaderText="To Date" 
                                                                            ReadOnly="True" />
                                                                       
                                                                       <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" 
                                                                                    CommandName="Edit" ImageUrl="~/images/edit.png" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" 
                                                                                    CommandName="Delete" ImageUrl="~/images/delete.png" 
                                                                                    OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                       

                                                                    </Columns>
                                                                </asp:GridView>
                                          </td>
                                          </tr>
              

                                        </table>


                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="Transport" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Transport</th>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="Label48" runat="server" Text="Transport Area"></asp:Label>
                                            </td>
                                            <td runat="server">
                                           <asp:DropDownList ID="drptransport" Width="225px"  runat="server" >
                                                        </asp:DropDownList>
                                          
                                          </td>
                                           </tr>
                                           <tr runat="server">
                                          <td runat="server">
                                         <asp:Label ID="Label49" runat="server" Text="Start Date"></asp:Label>
                                         </td>
                                         <td runat="server">
                                            <asp:TextBox ID="TextBox5" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="TextBox5" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                         <asp:Label ID="Label50" runat="server" Text="To Date"></asp:Label>
                                          </td>
                                          <td runat="server">
                                            <asp:TextBox ID="TextBox6" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" 
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="TextBox6" Format="dd/MM/yyyy"
                                                                                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                          </td>
                                         </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                          <td runat="server">
                                         <asp:Button ID="btntransport" class="btn btn-success" runat="server" Text="Save" OnClick="btntransport_Click"></asp:Button>
                                          </td>
                                          <td runat="server">
                                         
                                          </td>
                                          </tr>
                                          <tr runat="server">
                                          <td colspan="3" runat="server">
                                          <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table " 
                                                                    DataKeyNames="int_ID"     OnRowEditing="GridView2_RowEditing" OnRowDeleting="GridView2_RowDeleting"
                                                                    style="width:98%;border-collapse:collapse;margin:1% auto;">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="int_ID" HeaderText="int_ID." ReadOnly="True" 
                                                                            Visible="False" />
                                                                        <asp:BoundField DataField="vchArea_Name" HeaderText="Area Name" 
                                                                            ReadOnly="True"/>

                                                                        <asp:BoundField DataField="dtfrom_date" HeaderText="From Date" 
                                                                            ReadOnly="True" />
                                                                     
                                                                        <asp:BoundField DataField="dtto_date" HeaderText="To Date" 
                                                                            ReadOnly="True" />
                                                                       
                                                                        <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" 
                                                                                    CommandName="Edit" ImageUrl="~/images/edit.png" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" 
                                                                                    CommandName="Delete" ImageUrl="~/images/delete.png" 
                                                                                    OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                    </Columns>
                                                                </asp:GridView>
                                          </td>
                                          </tr>
              
              

                                        </table>

                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="table11sciC" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Mandatory Subject</th>
                                          <th runat="server">Optional Subject Group1</th>
                                          <th runat="server">Optional Subject Group2</th>
                                          <th runat="server">Optional Subject Group3</th>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="Label53" runat="server" Text="1.English" />
              
              
                                           <asp:Label ID="Label54" runat="server" Text="2.Chemistry" />
              
             
                                           <asp:Label ID="Label55" runat="server" Text="3.Physics" />
             
            
                                           
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton11" runat="server"  GroupName="1stGroup" 
                                                  Text="1.Biology" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton12" runat="server" GroupName="1stGroup" 
                                                  Text="1.CA"  />
                        
              
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton13" runat="server"  GroupName="2stGroup" 
                                                  Text="2.CS" Checked="True" AutoPostBack="True"   />
                                                    
                                                    <asp:RadioButton ID="RadioButton15" runat="server" GroupName="2stGroup" 
                                                  Text="2.P.ed" AutoPostBack="True" />
                        
              
                                          </td>
                                           <td runat="server">
                                          <asp:RadioButton ID="RadioButton16" runat="server"  GroupName="3stGroup" 
                                                   Text="3.Hindi" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton17" runat="server" GroupName="3stGroup" 
                                                   Text="3.Bengali"  />
                                                    <asp:RadioButton ID="RadioButton18" runat="server" GroupName="3stGroup" 
                                                   Text="3.P.ed"  />
                                                    <asp:RadioButton ID="RadioButton40" runat="server" GroupName="3stGroup" 
                                                   Text="3.None"  />
                        
              
                                          </td>

                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                          <td runat="server">
                                          
                                          <asp:Label ID="Label65" runat="server" Text="* CA- Commercial Arts" />
                                          </td>
                                          <td runat="server">
                                          <asp:Label ID="Label62" runat="server" Text="* CS- Computer Science" />
                                          </td>
                                          <td runat="server">
                                          <asp:Label ID="Label66" runat="server" Text="* P.ed- Physical Education" />
                                          
                                          </td>
                                          </tr>
              

                                        </table>

                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="table11sciD" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Mandatory Subject</th>
                                          <th runat="server">Optional Subject Group1</th>
                                          <th runat="server">Optional Subject Group2</th>
                                        
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="Label56" runat="server" Text="1.English" />
              
              
                                           <asp:Label ID="Label57" runat="server" Text="2.Chemistry" />
              
             
                                           <asp:Label ID="Label58" runat="server" Text="3.Physics" />

                                           <asp:Label ID="Label591" runat="server" Text="3.Mathematics" />
             
            
                                           
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton14" runat="server"  GroupName="1stGroup" 
                                                  Text="1.Biology" Checked="True"  />
                                          <asp:RadioButton ID="RadioButton22" runat="server"  GroupName="1stGroup" 
                                                  Text="1.CS"  />
                                                    <asp:RadioButton ID="RadioButton19" runat="server" GroupName="1stGroup" 
                                                  Text="1.CA"  />
                        
              
                                          </td>
                                          <td runat="server">

                                          <asp:RadioButton ID="RadioButton23" runat="server"  GroupName="2stGroup" 
                                                  Text="2.Hindi" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton24" runat="server" GroupName="2stGroup" 
                                                  Text="2.Bengali"  />
                                                    <asp:RadioButton ID="RadioButton25" runat="server" GroupName="2stGroup" 
                                                  Text="2.P.ed"   />
                                                    <asp:RadioButton ID="RadioButton41" runat="server" GroupName="2stGroup" 
                                                  Text="2.None"  />                                       
                        
              
                                          </td>
                                           

                                          </tr>

                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                          <td runat="server">
                                          
                                          <asp:Label ID="Label67" runat="server" Text="* CA- Commercial Arts" />
                                         
                                          <asp:Label ID="Label68" runat="server" Text="* CS- Computer Science" />
                                          </td>
                                          <td runat="server">
                                          <asp:Label ID="Label69" runat="server" Text="* P.ed- Physical Education" />
                                          
                                          </td>
                                          </tr>
              

                                        </table>

                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="table1comm" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Mandatory Subject</th>
                                          <th runat="server">Optional Subject Group1</th>
                                          <th runat="server">Optional Subject Group2</th>
                                          <th runat="server">Optional Subject Group3</th>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="Label601" runat="server" Text="1.English" />
              
              
                                           <asp:Label ID="Label611" runat="server" Text="2.Accountant" />
              
             
                                           <asp:Label ID="Label621" runat="server" Text="3.BusinessStudy" />
             
            
                                           
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton28" runat="server"  GroupName="1stGroup" 
                                                  Text="1.Hindi" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton29" runat="server" GroupName="1stGroup" 
                                                  Text="1.Bengali"  />
                                                    <asp:RadioButton ID="RadioButton30" runat="server" GroupName="1stGroup" 
                                                  Text="1.P.ed"  />
                        
              
                                          </td>
                                          <td runat="server">

                                          <asp:RadioButton ID="RadioButton20" runat="server"  GroupName="2stGroup" 
                                                  Text="2.Economics" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton21" runat="server" GroupName="2stGroup" 
                                                  Text="2.Comm. Arts"  />
                        
              
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton26" runat="server"  GroupName="3stGroup" 
                                                  Text="3.Mathematics" Checked="True"   />
                                                    
                                                    <asp:RadioButton ID="RadioButton27" runat="server" GroupName="3stGroup" 
                                                  Text="3.Entrepreneurship" />
                                                    <asp:RadioButton ID="RadioButton42" runat="server" GroupName="3stGroup" 
                                                  Text="3.None"  />
                        
              
                                          </td>
                                           

                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                         
                                          <td runat="server">
                                          <asp:Label ID="Label72" runat="server" Text="* P.ed- Physical Education" />
                                          
                                          </td>
                                          <td runat="server">
                                          
                                          </td>
                                          <td runat="server">
                                          </td>
                                          </tr>
              

                                        </table>

                                        <table width="100%" class="custom-table-grn table table-bordered table-hovered" 
                                                id="table1arts" runat="server" visible="False">
                                        <tr runat="server">   
                                          <th runat="server">Mandatory Subject</th>
                                          <th runat="server">Optional Subject Group1</th>
                                          <th runat="server">Optional Subject Group2</th>
                                          <th runat="server">Optional Subject Group3</th>
                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">

                                           <asp:Label ID="Label631" runat="server" Text="1.English" />
              
              
                                           <asp:Label ID="Label641" runat="server" Text="2.Geography" />
              
             
                                           <asp:Label ID="Label651" runat="server" Text="3.Political Science" />
             
            
                                           
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton31" runat="server"  GroupName="1stGroup" 
                                                  Text="1.Hindi" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton32" runat="server" GroupName="1stGroup" 
                                                  Text="1.Bengali"  />
                                                    <asp:RadioButton ID="RadioButton33" runat="server" GroupName="1stGroup" 
                                                  Text="1.P.ed"  />
                        
              
                                          </td>
                                          <td runat="server">

                                          <asp:RadioButton ID="RadioButton34" runat="server"  GroupName="2stGroup" 
                                                  Text="2.History" Checked="True"  />
                                                    <asp:RadioButton ID="RadioButton35" runat="server" GroupName="2stGroup" 
                                                  Text="2.Sociology"  />
                        
              
                                          </td>
                                          <td runat="server">
                                          <asp:RadioButton ID="RadioButton36" runat="server"  GroupName="3stGroup" 
                                                  Text="3.Economics" Checked="True"   />
                                                    
                                                    <asp:RadioButton ID="RadioButton37" runat="server" GroupName="3stGroup" 
                                                  Text="3.Comm. Arts" />
                                                    <asp:RadioButton ID="RadioButton43" runat="server" GroupName="3stGroup" 
                                                  Text="3.None"  />
                        
              
                                          </td>
                                           

                                          </tr>
                                          <tr runat="server">
                                          <td runat="server">
                                          
                                          </td>
                                          
                                          <td runat="server">
                                          <asp:Label ID="Label73" runat="server" Text="* P.ed- Physical Education" />
                                          
                                          </td>
                                          <td runat="server"></td>
                                          <td runat="server"></td>
                                          </tr>
                                          
              

                                        </table>


                                        </ContentTemplate>
                                        </asp:TabPanel>
                                      

                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
  
  <table width="96%">
<table width="66%" style="text-align: right; margin:0 0 0 2%;">
    <tr>
        <td align="justify">
            &nbsp;
        </td>
        <td align="justify">
            &nbsp;
        </td>
         <td align="justify">
            &nbsp;
        </td>
        <td align="justify">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="imgViewFile" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                                                
                runat="server" Style="line-height: normal; height: 100px; float:left; width: 80px;"
                                                                                border="2" 
                ToolTip="Image" ></asp:Image>
        </td>
        <td id="img" runat="server" align="left">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="efffield" Style="width: 50%;
                                                                        position: relative;  float: left;" />
                    &nbsp;<br />
                    <br />
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Style="float: left; position: relative;
                    " OnClick="Button1_Click" OnClientClick="if (!validatePage()) {return true;}"
                    Text="Upload Image" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Button1" >
                    </asp:PostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            <asp:TextBox ID="date1" runat="server" hidden="true"></asp:TextBox>
            <br />
        </td>
         <td align="justify">
            &nbsp;
        </td>
        <td align="justify">
            &nbsp;
        </td>
    </tr>
    </table>
<table width="48%" style="text-align: right; margin:0 0 0 2%; float:left;">
 <tr>
        <td align="justify">
            <asp:Label ID="Label47" runat="server" Font-Bold="False" Text="Start  Date"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtstartdate" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtstartdate" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>
            
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="REG. No." Style="font-size: 13px;"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtGRNo" runat="server" MaxLength="30" AutoPostBack="True" 
                                                              Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Standard" Style="font-size: 13px;"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DropDownList2" Width="225px"  runat="server" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" InitialValue="0"
                                                                                ErrorMessage="Please select Standerd" ControlToValidate="DropDownList2" ValidationGroup="g1"
                                                                                Display="None" Font-Bold="False"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RequiredFieldValidator15"
                                                                                Enabled="True">
            </asp:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label27" runat="server" Font-Bold="False" Text="Division Id" Style="font-size: 13px;"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="225px"
                                                                                 OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="Please select Division"
                                                                                ControlToValidate="DropDownList3" ValidationGroup="g1" InitialValue="0" Display="None"
                                                                                Font-Bold="False"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="RegularExpressionValidator19"
                                                                                Enabled="True">
            </asp:ValidatorCalloutExtender>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Card. no." Style="font-size: 13px;"></asp:Label>
             <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtStudentID" runat="server" MaxLength="30" AutoPostBack="True"  OnTextChanged="txtStudentID_TextChanged"
              Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStudentID"
                                                                                Display="None" ErrorMessage="Please Enter Card No." Font-Bold="False"
                                                                                ValidationGroup="p1"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
            </asp:ValidatorCalloutExtender>
            
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Admission Date"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtAdmissionDate" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAdmissionDate" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>
            
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label28" runat="server" Font-Bold="False" Text="Roll No" Style="font-size: 13px;"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="4" AutoPostBack="True" OnTextChanged="checkroll"
                                                                                Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Width="140px" Font-Bold="False" ForeColor="#FF3300"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblvchno" runat="server" Font-Bold="False">First Name</asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt1" runat="server" Font-Names="Verdana" MaxLength="100" 
                                                            Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False">Middle Name</asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt2" runat="server" Font-Names="Verdana" MaxLength="100" Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblvchdrivername" runat="server" Text="Last Name" Font-Bold="False"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt3" runat="server" Font-Names="Verdana" 
                                                             Width="225px" 
                CssClass="input-blue" ForeColor="Black" ValidationGroup="b" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lbldrivermobno" runat="server" Font-Bold="False" Text="Father Name"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt4" runat="server" Font-Names="Verdana" 
                                                            Width="225px" 
                CssClass="input-blue" ForeColor="Black" ValidationGroup="b" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblmother" runat="server" Font-Bold="False" Text="Mother Name"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt5" runat="server" Font-Names="Verdana" 
                                                            MaxLength="100" Width="225px" 
                CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="fbtem" runat="server" TargetControlID="txt5"
                                                                                    FilterType="Custom, UppercaseLetters, LowercaseLetters" 
                                                                                    ValidChars=" " Enabled="True">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Gender" runat="server" Font-Bold="False" Text="Email ID"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt6" runat="server" Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"
                                                                             Width="225px"    MaxLength="50"></asp:TextBox>
            <asp:RegularExpressionValidator ID="regexEmailValid" CssClass="input-blue" runat="server"
                                                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt6"
                                                                                Display="None" ErrorMessage="Invalid Email Format" Font-Bold="False"></asp:RegularExpressionValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
            </asp:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblbob" runat="server" Font-Bold="False" Text="Date of Birth"></asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt7" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt7" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt7"
                                                                                Display="None" ErrorMessage="Please Enter Dob" ValidationGroup="p1" Font-Bold="False"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                                TargetControlID="RequiredFieldValidator12">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp;
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="date1"
                                                                                ControlToValidate="txt7" Display="None" Type="Date" ErrorMessage="age must be greater then 2 year"
                                                                                Font-Bold="False" Operator="LessThan" ValidationGroup="p1"></asp:CompareValidator>
            <asp:ValidatorCalloutExtender
                                                                                    ID="ValidatorCalloutExtender60" runat="server" Enabled="True" TargetControlID="CompareValidator1">
            </asp:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label7" runat="server" Font-Bold="False">Place Of Birth</asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtPlaceOfBirth" runat="server" Font-Names="Verdana" MaxLength="20" Width="225px" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label12" runat="server" Font-Bold="False">Blood Group</asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt44" runat="server" Font-Names="Verdana" MaxLength="3" ForeColor="Black"
                                                                             Width="225px"    CssClass="input-blue"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblpalceofbirth0" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Cast"></asp:Label>
            <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
        </td>
        <td align="justify">
            <asp:DropDownList ID="txt9" runat="server"  
            Font-Names="Verdana" ForeColor="Black"
            ValidationGroup="p1" Width="225px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblpalceofbirth1" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Sub Cast"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt10" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label11" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Religion"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtReligion" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
   
     <tr>
        <td align="justify">
            <asp:Label ID="Label10" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mothertounge"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtMothertounge" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label13" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="First Language"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtFirstLanguage" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify" width="200px !important;">
            <asp:Label ID="Label16" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Second Language"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtSecondLanguage" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label17" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Third Language"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtThirdLanguage" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>

     <tr>
        <td align="justify">
            <asp:Label ID="Label34" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Student Aadhar Number"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtstdaadhar" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify" width="200px !important;">
            <asp:Label ID="Label35" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Father Aadhar Number"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtfatheraadhar" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label36" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mother Aadhar Number"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtmotheraadhar" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
        
    </table>
    <div class"clearfix"></div>
     <table width="48%" style="text-align: right; margin:0 0 0 2%;">
     <tr>
        <td align="justify">
            <asp:Label ID="Label59" runat="server" Font-Bold="False" Text="End  Date"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtenddate" runat="server"  Font-Names="Verdana" CssClass="input-blue" ForeColor="Black" ValidationGroup="b"
                                                                            Width="225px"     MaxLength="20"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtenddate" Format="dd/MM/yyyy"
                                                                                Enabled="True">
            </asp:CalendarExtender>
            
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label52" runat="server" Style="position: relative; top: -8px;" Font-Bold="False"
                                                                                Text="Gender"></asp:Label>
            <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
        </td>
        <td align="justify">
            <asp:DropDownList ID="txt11" runat="server"  
                                                                                Font-Names="Verdana" ForeColor="Black"
                                                                                ValidationGroup="p1" Width="225px">
                <asp:ListItem Selected="True" Value="Select">---Select---</asp:ListItem>
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblpalceofbirth2" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Father Mobile No"></asp:Label>
            <font color="red" style="position: relative; top: -8px;" size="1px">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt13" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                               
                Width="225px"  MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt13"
                                                                                Display="None" ErrorMessage="Please Enter Father Mobile No" Font-Bold="False"
                                                                                ValidationGroup="p1"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender5"
                                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
            </asp:ValidatorCalloutExtender>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt13"
                                                                                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="lblpalceofbirth3" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mother Mobile No"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt14" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                               
                Width="225px"  MaxLength="10"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt14"
                                                                                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label8" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="SMS Mobile No"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtSMSMobile" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                               
                Width="225px"  MaxLength="10"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSMSMobile"
                                                                                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label18" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Father Occupation"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtFatherOccupation" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label19" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mother Occupation"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtMotherOccupation" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label20" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Father Designation"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtFatherDesignation" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label21" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mother Designation"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtMotherDesignation" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label22" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Father Income"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtFatherIncome" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label23" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Mother Income"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtMotherIncome" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label30" runat="server" Style="position: relative; top: -8px;" Font-Bold="False"
                                                                                Text="Country"></asp:Label>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DdlCountryName" runat="server" Font-Names="Verdana" ForeColor="Black"
               ValidationGroup="p1" Width="225px" AutoPostBack="True" 
                onselectedindexchanged="DdlCountryName_SelectedIndexChanged">
               
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label31" runat="server" Style="position: relative; top: -8px;" Font-Bold="False"
                                                                                Text="State"></asp:Label>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DdlStateName" runat="server" Font-Names="Verdana" ForeColor="Black"
               ValidationGroup="p1" Width="225px" AutoPostBack="True" 
                onselectedindexchanged="DdlStateName_SelectedIndexChanged">
               
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label32" runat="server" Style="position: relative; top: -8px;" Font-Bold="False"
                                                                                Text="City"></asp:Label>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DdlCityName" runat="server" Font-Names="Verdana" ForeColor="Black"
               ValidationGroup="p1" Width="225px">
               
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label1" runat="server" Font-Bold="False">Present Address</asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt34" runat="server" Font-Names="Verdana" MaxLength="250" ForeColor="Black"
                                                                                
                Width="225px" Height="40px" CssClass="input-blue" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label3" runat="server" Font-Bold="False">Permanent Address</asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt35" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                                
                Height="47px" MaxLength="250"  Width="225px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label25" runat="server" Font-Bold="False">Landmark</asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtLandmark" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                                
                Height="47px" MaxLength="250"  Width="225px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label29" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Pincode"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtPincode" runat="server" CssClass="input-blue" 
                Font-Names="Verdana" ForeColor="Black"
                                                                               
                Width="225px"  MaxLength="10"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPincode"
                                                                                FilterType="Numbers" Enabled="True">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
     <tr>
        <td align="justify">
            <asp:Label ID="Label24" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Nationality"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtNationality" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label37" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="User Name"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label38" Style="position: relative; top: -8px;" runat="server"
                                                                                Font-Bold="False" Text="Password"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black"
                                                                        Width="225px"  MaxLength="20" ValidationGroup="b" TextMode="Password" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label14" runat="server" Font-Bold="False">Any Health Disability</asp:Label>
            <font size="1px" color="red">*</font>
        </td>
        <td align="justify">
            <asp:DropDownList ID="DropDownList1" runat="server"  Width="225px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label15" runat="server" Text="Description"  Font-Bold="False"></asp:Label>
        </td>
        <td align="justify">
            <asp:TextBox ID="txt45" runat="server" Font-Names="Verdana" MaxLength="250" ForeColor="Black"
                                                                         
                Width="225px"        ValidationGroup="b" CssClass="input-blue" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="justify">
            <asp:Label ID="Label39" runat="server" Font-Bold="False" Text="Serial Number"></asp:Label>
        </td>
        <td align="justify">
           <%-- <asp:TextBox ID="txtreceiptno" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black" MaxLength="10" Width="225px"></asp:TextBox>--%>
            <asp:TextBox ID="txtreceiptno" runat="server" CssClass="input-blue" Font-Names="Verdana" ForeColor="Black" MaxLength="10" Width="225px" AutoPostBack="True" OnTextChanged="checkReceiptNo"></asp:TextBox>
              <asp:Label ID="Label40" runat="server" Font-Bold="False" Text="" ForeColor="#FF3300" Visible="false" ></asp:Label>
        </td>
        
        <tr>
        <td align="justify">
        <asp:Label ID="Label42" runat="server" Text="Guardian Name" Font-Bold="false"></asp:Label>
        </td>
        <td align="justify">
         <asp:TextBox ID="txtGuardianName" runat="server" Font-Names="Verdana" MaxLength="250" ForeColor="Black"
          Width="225px" ValidationGroup="b" CssClass="input-blue" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td align="justify">
        <asp:Label ID="Label43" runat="server" Text="Guardian Number" Font-Bold="false"></asp:Label>
        </td>
        <td align="justify">
        <asp:TextBox ID="txtGuardianNumber" runat="server" Font-Names="Verdana" MaxLength="250" ForeColor="Black"
         Width="225px" ValidationGroup="b" CssClass="input-blue"></asp:TextBox>
        </td>
        </tr>

       

        <tr>
            <td align="left" colspan="2">
                <table style="margin:0 0 0 40%;" width="40%">
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();" Text="Submit" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" CssClass="vclassrooms_send" OnClick="btnClear_Click" OnClientClick="return ConfirmInsertUpdate();" Text="Clear" />
                        </td>
                        <td align="left" style="padding-left:10px">
                            <asp:Button ID="Update" runat="server" OnClick="Update1" Text="Update12" />
                            <asp:Label ID="idv1" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="auto-style5" colspan="2">&nbsp; </td>
        </tr>
    </tr>
</table>
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
