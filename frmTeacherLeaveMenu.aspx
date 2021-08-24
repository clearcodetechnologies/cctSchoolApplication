<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmTeacherLeaveMenu.aspx.cs" Inherits="frmTeacherLeaveMenu" Title="Apply Leave"
    Culture='en-GB' %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Leave Application </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Leave Application</li>
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
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Leave Application</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false" id=>Application Status</a>
                    </li> 
                    <li class="nav-item">
                      <a class="nav-link" id="tab3" data-toggle="pill" href="#tab3Entry" role="tab" aria-controls="tab3Entry" aria-selected="false" id=>Reports</a>
                    </li> 
                    <li class="nav-item">
                      <a class="nav-link" id="tab4" data-toggle="pill" href="#tab4Entry" role="tab" aria-controls="tab4Entry" aria-selected="false" id=>Pending Leave</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                        <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                    <asp:RadioButtonList ID="Radioleave" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="0">Normal</asp:ListItem>
                                                                            <asp:ListItem Value="1">Emergency</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None"
                                                                            ControlToValidate="Radioleave" ErrorMessage="Choose Leave Type"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                                            TargetControlID="RequiredFieldValidator5">
                                                                        </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Label ID="Lal2" runat="server" Style="width: 100% !important; color: #000 !important;">Leave Type</asp:Label>
                              <asp:DropDownList ID="drop1" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drop1"
                                                                Display="None" ErrorMessage="Select Leave Type" Font-Bold="False" InitialValue="0"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator3">
                                                            </asp:ValidatorCalloutExtender>
                              </div>
                              </div>


                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                             <asp:Label ID="lblvchmake" runat="server" Style="width: 100% !important; color: #000 !important;">From Date</asp:Label>
                             <asp:TextBox ID="txtfromdate" runat="server" ForeColor="Black" MaxLength="20" Style="width: 96%;"
                                                                ValidationGroup="b" AutoPostBack="True" OnTextChanged="cleartodata"></asp:TextBox><asp:CalendarExtender
                                                                    ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate" runat="server"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="From Date cannot be null "
                                                                ControlToValidate="txtfromdate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator2">
                                                            </asp:ValidatorCalloutExtender>
                              </div>
                              </div>


                             </div>

                              <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Label ID="lblvchdrivername" runat="server" Text="To Date" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                             <asp:TextBox ID="txttodate" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                Style="width: 96%;" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                                                runat="server" Enabled="True">
                                                            </asp:CalendarExtender>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="To Date cannot be null "
                                                                ControlToValidate="txttodate" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator4">
                                                            </asp:ValidatorCalloutExtender>
                              </div>
                              </div>


                             </div>

                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Label ID="lbldrivermobno" runat="server" Text="Total Leave Days" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                              <asp:TextBox ID="txtNoofDays" runat="server" ForeColor="Black" MaxLength="20" ValidationGroup="b"
                                                                AutoPostBack="True" OnTextChanged="check_val" Style="width: 96%;" ReadOnly="True"></asp:TextBox>
                                                                <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                              </div>
                              </div>


                             </div>

                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Label ID="Label3" runat="server" Text="Reason" Style="width: 100% !important;
                                                                color: #000 !important;"></asp:Label>
                             <textarea id="content" runat="server" style="width: 97%;" class="textcss"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Leave Reason cannot be null "
                                                                ControlToValidate="content" Display="None"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                                                TargetControlID="RequiredFieldValidator4">
                                                            </asp:ValidatorCalloutExtender>
                              </div>
                              </div>


                             </div>

                             <div class="row">
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Button ID="Button3" runat="server" CssClass="vclassrooms_send"
                                                                Text="Save" OnClick="Button1_Click" />
                              </div>
                              </div>


                             </div>
                             </div>



                     
                         

                       
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                            <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="GridView5" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                            DataKeyNames="intLeaveApplocation_id,ApplicationDate" EmptyDataText="Record not Found." 
                                                            Width="100%" onrowediting="GridView5_RowEditing">
                                                            <Columns>
                                                              <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                     <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>  
                                                                                <asp:RadioButtonList ID="rdbAction" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Value="1" Text="Approve"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="Reject"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Submit">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                            </div>
                               


                            </div>

                            <div class="row">

                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="GridView2" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                            DataKeyNames="intLeaveApplocation_id,ApplicationDate" EmptyDataText="Record not Found." 
                                                            Width="100%" onrowediting="GridView5_RowEditing">
                                                            <Columns>
                                                              <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" 
                                                                    ReadOnly="True" Visible="False"/>
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                        </div> 
                        </div>
                         </div>
                       </div> 

                         <div class="tab-pane fade" id="tab3Entry" role="tabpanel" aria-labelledby="tab3">
                     <div class="form-horizontal">
                            <div class="row">
                            <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="GridViewRepo" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" CssClass="table  tabular-table"
                                                            DataKeyNames="ApplicationDate" EmptyDataText="Record not Found." 
                                                            Width="100%" OnSelectedIndexChanged="GridViewRepo_SelectedIndexChanged">
                                                            <Columns>
                                                            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField DataField="TotalnoofDays" HeaderText="Total Days" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApproval" HeaderText="Admin Approval" ReadOnly="True" />
                                                                <asp:BoundField DataField="AdminApprovaldate" HeaderText="Approval Date" 
                                                                    ReadOnly="True" Visible="False"/>
                                                                <asp:BoundField DataField="AdminRemark" HeaderText="Admin Remark" 
                                                                    ReadOnly="True" Visible="False"/>
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                            </div>
                               


                            </div>
                         </div>
                       </div>

                       <div class="tab-pane fade" id="tab4Entry" role="tabpanel" aria-labelledby="tab4">
                     <div class="form-horizontal">
                            <div class="row">
                            <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="GridView1" runat="server" __designer:wfdid="w36" AllowPaging="True"
                                                            AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_OnPageIndexChanging"
                                                            CssClass="table  tabular-table" DataKeyNames="vchLeaveType_name" EmptyDataText="Record not Found."
                                                            Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <Columns>
                                                                <asp:BoundField DataField="vchLeaveType_name" HeaderText="Leave Type" ReadOnly="True" />
                                                                <asp:BoundField DataField="inttotal" HeaderText="Total Leave" ReadOnly="True" />
                                                                <asp:BoundField DataField="pending" HeaderText="Pending Leave" ReadOnly="True" />
                                                                <asp:BoundField DataField="taken" HeaderText="Leave Taken " ReadOnly="True" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
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