<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmAttendanceMarkStaff.aspx.cs" Inherits="frmAttendanceMarkStaff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript">
     function checkDate() {
         var idate = document.getElementById("<%=txtDate.ClientID %>").value;
         var myDate = new Date(idate);
         alert(myDate);
         var today = new Date();
         alert(today);
         if (myDate > today) {
             alert("Please check date.");
             document.forms.form1.date.focus();
             return false;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
     <%-- <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Mark Attendance </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Attendance</a></li>
              <li class="breadcrumb-item active"> Mark Attendance</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> --%>
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
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Mark Attendance</a>
                    </li>
                   
                  </ul>
                </div>
                    <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                           <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" CssClass="col-form-label" runat="server" Text="Date"></asp:Label>
                                  <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                  <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                                    </asp:CalendarExtender>
                                   
                                </div>
                             </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6"> 
                                                                
                                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"  CssClass="btn btn-danger btn-sm mt-18"  Text="Update" Visible="False" />
                               <asp:Button ID="btnSMS" runat="server" CssClass="btn btn-danger btn-sm mt-18" Text="SMS" Visible="False"  OnClick="btnSMS_Click" />
                                </div>


                                </div>
                         
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grdMarkAttendance" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="table table table-hover table-bordered cus-table tabular-table " PageSize="20" DataKeyNames="intStaff_id,FCMToken"
                                            EmptyDataText="No Records Found">
                                        <Columns>
                                           <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestID" runat="server" Text='<%#Eval("intStaff_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:CheckBox ID="chkCtrl" Checked="<%# bool.Parse(Eval("status").ToString()) %>" runat="server" AutoPostBack="true" Style="width: 10px;
                                                                        left: 20px;" />--%>
                                                        <asp:CheckBox ID="chkCtrl" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server"
                                                            AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("status").ToString())%>'>
                                                        </asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                 <asp:BoundField DataField="vchfirst_name" HeaderText="Staff Name">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAttstatus" runat="server" Text='<%#Eval("Attstatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("status") %>' Visible="false" />
                                                        <asp:DropDownList ID="drpStatus" runat="server" AutoPostBack="true" CssClass="selectf"
                                                            OnSelectedIndexChanged="Status_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Present" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Absent" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>

                            </div>
                          </div>
                     

                      </div>
                    </div>


                 </div>
            </div>
         </div>
       </div>
     </section>  
                    
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server" ActiveTabIndex="1">
                                    <asp:TabPanel ID="tab" runat="server">
                                  
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server"  ID="TabPanel1">
                                         
                                     
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            
                </ContentTemplate>
            </asp:UpdatePanel>
         
</asp:Content>