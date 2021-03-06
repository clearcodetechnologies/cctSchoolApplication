<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master"
    Culture="en-Gb" AutoEventWireup="true" CodeFile="frmTeachLeavAppro.aspx.cs" Inherits="frmTeachLeavAppro"
    Title="VClassrooms - Student attendance management system, Fees management, School bus tracking, Exam schedule, time table management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script type="text/javascript">
function funcswitchtab() {
    $('#tab2').trigger('click')
    $("#tab2Entry").addClass("active show");
    $("#custom-tabs-five-overlay-tab").removeClass("active");
    $("#custom-tabs-five-overlay").removeClass("show").removeClass("active");
}         
</script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Leave Approval </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Leave Approval</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
    <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Approval Request</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false" id=>Approval</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                        <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label8" runat="server" Text="User Type:"></asp:Label>
                                                            <asp:DropDownList ID="drop1" runat="server" AutoPostBack="True" 
                                                                style="width:200px; display:inline-block;" 
                                                                onselectedindexchanged="drop1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                </div>
                             </div>
                        <div class="col-lg-12 col-md-12">
                              <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                                    AutoGenerateColumns="False" CssClass="table  tabular-table" 
                                                    DataKeyNames="lblid" EmptyDataText="No Records Found" 
                                                    OnPageIndexChanging="GridView2_OnPageIndexChanging" 
                                                    OnRowEditing="GridView2_RowEditing" Width="100%">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approval">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkBtn" runat="server" CommandName="Edit">
                                                                    <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TeacherName" HeaderText="Name" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfLeave" HeaderText="Type Of Leave" 
                                                            ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalLeaveDays" HeaderText="Total Leave Days" 
                                                            ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Reson" HeaderText="Reason" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                                </asp:GridView>
                        </div> 
                        </div>
                        <div class="row">
                        <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                               <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CssClass="table  tabular-table" 
                                                DataKeyNames="lblid" EmptyDataText="No Records Found" 
                                                OnPageIndexChanging="GridView1_OnPageIndexChanging" 
                                                OnRowEditing="GridView1_RowEditing" 
                                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%">
                                                <AlternatingRowStyle CssClass="alt" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approval">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBtn" runat="server" CommandName="Edit">
                                                                    <asp:Image ID="Img" runat="server" ImageUrl="images/edit.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="studrollno" HeaderText="Roll No" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TypeOfLeave" HeaderText="Type Of Leave" 
                                                        ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalLeaveDays" HeaderText="Total Leave Days" 
                                                        ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Reson" HeaderText="Reason" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="parentsapproval" HeaderText="Parents Approval" 
                                                        ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="pareapprdate" HeaderText="Approval Date" 
                                                        ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Remark" HeaderText="Remark" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                            </asp:GridView>
                              </div>
                              </div>
                        
                        </div>
                      </div>
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2" runat="server">
                     <div class="form-horizontal">
                            <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="User Type:"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                                style="width:200px; display:inline-block;" 
                                                                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                </div>
                             </div>
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CssClass="table  tabular-table" DataKeyNames="lblid" OnPageIndexChanging="GridView3_OnPageIndexChanging"
                                                    EmptyDataText="No Records Found" Width="100%">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:BoundField DataField="TeacherID" HeaderText="ID" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfLeave" HeaderText="Type Of Leave" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalLeaveDays" HeaderText="Total Leave Days" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Reson" HeaderText="Reason" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Approvaldate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                                </asp:GridView>
                                     
                                </div>
                             </div>
                             </div>
                             <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:GridView ID="GridViewRepo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CssClass="table  tabular-table" DataKeyNames="lblid" OnPageIndexChanging="GridViewRepo_OnPageIndexChanging"
                                                    EmptyDataText="No Records Found" Width="100%">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:BoundField DataField="studrollno" HeaderText="Roll No" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="studentname" HeaderText="Name" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfLeave" HeaderText="Type Of Leave" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalLeaveDays" HeaderText="Total Leave Days" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Reson" HeaderText="Reason" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="parentsapproval" HeaderText="Parents Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="pareapprdate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Remark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Teacherapproval" HeaderText="Teacher Approval" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Teacherappdate" HeaderText="Approval Date" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TeacherRemark" HeaderText="Remark" ReadOnly="True">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="LightCyan" Font-Bold="True" ForeColor="DarkBlue" />
                                                </asp:GridView>
                                     
                                </div>
                             </div>
                                
                                 


                            </div>
                         </div>
                       </div> 
                     
                       </div>
                    </div>

                </div>
            </div>
         </div>
       <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1" Visible="False">
                            <HeaderTemplate>
                                Approval
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div class="vclassrooms">
                                    <center>
                                        <br />
                                        <table style="width: 50%">
                                            <tr>
                                                <td colspan='2'>
                                                    <asp:Label ID="LblApplication" runat="server" Text="Application Id" Font-Bold="False"
                                                        Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Name" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label1" runat="server" Text="Type Of Leave" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="leaveType" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="From Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="FromLbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label5" runat="server" Text="To Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="ToLbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label7" runat="server" Text="Total No Of Days"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="TotalLbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                </td>
                                                <tr>
                                                    <td align="center" colspan='2'>
                                                        <asp:RadioButtonList ID="RadioApproved" runat="server" RepeatDirection="Horizontal"
                                                            Height="16px" Width="288px">
                                                            <asp:ListItem Value="1">Approved</asp:ListItem>
                                                            <asp:ListItem Value="2">Rejected</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="a1"
                                                            ControlToValidate="RadioApproved" ErrorMessage="Choose Approval Status"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label2" runat="server" Text="Remark"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="Resontxt" runat="server" Height="47px" Font-Size="X-Small" Width="152px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a1" runat="server"
                                                            ControlToValidate="Resontxt" ErrorMessage="Please Enter Reson"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" class="style2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button CssClass="vclassrooms_send" ID="btnSubmin" runat="server" ValidationGroup="a1"
                                                            OnClick="Submitval" Text="Submit" Width="60%" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button CssClass="vclassrooms_send" ID="btnClear" runat="server" OnClientClick="if (!validatePage()) {return true;}"
                                                            OnClick="btnClear_Click" Text="Clear" Width="60%" />
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </ContentTemplate>
                        </asp:TabPanel>
     </section>               
 </ContentTemplate>
            </asp:UpdatePanel>

 
           <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server"  
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" CssClass="vclassrooms" ID="tab" runat="server">
                                         
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"> 
                                    </asp:TabPanel>
                                </asp:TabContainer>
                         
    
</asp:Content>