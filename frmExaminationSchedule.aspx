<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmExaminationSchedule.aspx.cs" Inherits="frmExaminationSchedule" Title="VClassrooms - Student attendance management system, Fees management, School bus
        tracking, Exam schedule, time table management"
    Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript">

     function checkDate(sender, args) {
         if (sender._selectedDate < new Date()) {
             alert("You cannot select a day earlier than today!");
             sender._selectedDate = new Date();
             // set the date back to the current date
             sender._textbox.set_Value(sender._selectedDate.format(sender._format))
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
    <script type="text/javascript">
function funcswitchtab() {
    $('#custom-tabs-five-overlay-dark-tab').trigger('click')
    $("#custom-tabs-five-overlay-dark").addClass("active show");
    $("#custom-tabs-five-overlay-tab").removeClass("active");
    $("#custom-tabs-five-overlay").removeClass("show").removeClass("active");
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
     <head>
    </head>
    <div class="clearfix">
    </div>    
    <style>
        .vclassrooms span
        {
            position: relative;
            left: -15px;
        }
        .vclassrooms input[type="image"]
        {
            border: 0px;
            padding: 0px;
            width: 33%;
        }
    </style>

     <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Examination </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Study</a></li>
              <li class="breadcrumb-item active">  Examination </li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

      <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
              <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">   Details </a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">  New Entry </a>
                    </li>
                      
                  </ul>
                </div>         <%--card-header --%>
    <div class="card-body">
            <div class="tab-content" id="custom-tabs-five-tabContent">
                <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                    <div class="form-horizontal">
                    <div class="row">

                        <div class="col-lg-3 col-md-4 col-sm-6">
                            <div class="form-group">
                             <asp:Label ID="lbladmStandard" runat="server" CssClass="col-form-label"   Text="Standard "></asp:Label>
                                     <asp:DropDownList ID="drpAdmStandard" runat="server" AutoPostBack="True"  CssClass="form-control"  onselectedindexchanged="drpAdmStandard_SelectedIndexChanged">
                                                 <asp:ListItem>---Select--</asp:ListItem>
                                       </asp:DropDownList>

                            </div>
                        </div>
                         <div class="col-lg-3 col-md-4 col-sm-6">
                            <div class="form-group">
                             <asp:Label ID="Label6" runat="server"  CssClass="col-form-label"  Text="Select Exam"></asp:Label>
                                   <asp:DropDownList ID="drpSelExam" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpSelExam_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                      </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-lg-3 col-md-4 col-sm-6">
                            <div class="form-group">
                             <asp:Label ID="Label7" runat="server" CssClass="col-form-label"  Text="Select Exam"></asp:Label>
                                   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpSelExam_SelectedIndexChanged">
                                                                                        <asp:ListItem>---Select--</asp:ListItem>
                                      </asp:DropDownList>

                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="col=col-lg-12 col-xs-12">
                             <asp:GridView ID="grdExamination" AutoGenerateColumns="False" runat="server" DataKeyNames="intExamSchedule_id"
                            CssClass="table table-hover table-bordered cus-table" Width="100%" EmptyDataText="No Examination schedule"
                            OnRowDeleting="grdExamination_RowDeleting" 
                            OnRowEditing="grdExamination_RowEditing" 
                            onrowdatabound="grdExamination_RowDataBound" 
                            >
                            <Columns>
                                <asp:BoundField DataField="intExamSchedule_id" HeaderText="Id" Visible="False" />
                                <asp:BoundField DataField="dtExamination_date" HeaderText="Date" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="theDayName" HeaderText="Day" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vchSubjectName" HeaderText="Subject" ReadOnly="True" />
                                <asp:BoundField DataField="dtExamination_FromTime" HeaderText="From Time" ReadOnly="True" />
                                <asp:BoundField DataField="dtExamination_ToTime" HeaderText="To Time" ReadOnly="True" />
                                <asp:BoundField DataField="ExamTypeName" HeaderText="Type" ReadOnly="True" />  
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                            ImageUrl="~/images/edit.png" /></ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                            ImageUrl="~/images/delete.png" OnClientClick="return confirm('Are you sure you want to delete ?');" /></ItemTemplate>
                                </asp:TemplateField>
                                                                                                                                                    
                            </Columns>
                        </asp:GridView>
                        </div>


                        </div>
                        </div>
                </div>

                   <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="tab2">
                        <div class="form-horizontal" id="divEntry" runat="server">
                            <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" CssClass="col-form-label" Text="Standard" ></asp:Label>
                                             <asp:DropDownList ID="drpStandard" runat="server"  CssClass="form-control" AutoPostBack="True"
                                                    OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select"></asp:ListItem>
                                                </asp:DropDownList>

                                    </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                     <asp:Label ID="Label1" runat="server" CssClass="col-form-label" Text="Exam" ></asp:Label>
                                          <asp:DropDownList ID="drpExam" runat="server"  CssClass="form-control"   onselectedindexchanged="drpExam_SelectedIndexChanged" >
                                                                                <asp:ListItem Text="Select"></asp:ListItem>
                                                                            </asp:DropDownList>

                                    </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                       <asp:Label ID="Label3" runat="server" CssClass="col-form-label" Text="Exam Type" ></asp:Label>
                                          <asp:DropDownList ID="drpExamType" runat="server"  AutoPostBack="True"  CssClass="form-control"   onselectedindexchanged="drpExamType_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Select"></asp:ListItem>
                                                                            </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                       <asp:Label ID="Label4" runat="server" CssClass="col-form-label" Text="Subject"></asp:Label>
                                           <asp:DropDownList ID="drpSubject" CssClass="form-control" runat="server"  OnSelectedIndexChanged="drpSubject_SelectedIndexChanged">
                                                                                <asp:ListItem Text="---Select---"></asp:ListItem>
                                                                            </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                       <asp:Label ID="lblDesc0" runat="server" CssClass="col-form-label"  Text="Date"></asp:Label>
                                           <asp:TextBox ID="txtExaminationDate" runat="server" Width="100%"  CssClass="form-control"
                                            AutoPostBack="True" AutoComplete="Off" MaxLength="10"></asp:TextBox><asp:CalendarExtender
                                                ID="CalendarExtender1" runat="server" TargetControlID="txtExaminationDate" Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate"
                                                Enabled="True">
                                            </asp:CalendarExtender>
                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtExaminationDate"
                                            WatermarkText="Examination Date" Enabled="True">
                                        </asp:TextBoxWatermarkExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Examination Date"
                                            Display="None" ControlToValidate="txtExaminationDate" ></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                Enabled="True">
                                            </asp:ValidatorCalloutExtender>

                                    </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblDesc" runat="server"  CssClass="col-form-label" style="display:block;display: flex;padding: 0;" Text="Time"></asp:Label>
                                          <asp:TextBox ID="txtFromTime"  CssClass="form-control" runat="server" AutoComplete="Off" style="display:inline-block; width:49%;" AutoPostBack="True"
                                                    MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromTime"
                                                    Display="None" ErrorMessage="Please Enter From Time"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"
                                                AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtFromTime">
                                            </asp:MaskedEditExtender>

                                        <asp:TextBox ID="txtToDt" CssClass="form-control" runat="server" Style="width: 50% !important; display:inline-block;" AutoPostBack="True"
                                                MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDt"
                                                Display="None" ErrorMessage="Please Enter To Time"></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                            TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="True"
                                            AutoCompleteValue="99:99 AM" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                            CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtToDt">
                                        </asp:MaskedEditExtender>

                                    </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="form-group">
                                       <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-sm mt-18" OnClick="btnSubmit_Click"  Text="Submit" />
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
               </div>
            </div>
        </div>
    </section>

        </ContentTemplate>
      </asp:UpdatePanel>


<section class="content d-none">
    <table width="100%">
        <tr>
            <td>
                <div style="padding: 5px 0 0 0">
                    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                ActiveTabIndex="1">
                                               
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        Detail</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <br />
                                                        <table width="100%" class="vclassrooms">
                                                            <tr>
                                                                <td>
                                                                    <center>
                                                                        <table width="60%">
                                                                            <tr>
                                                                                <td align="right">
                                                                                    
                                                                                </td>
                                                                                <td width="200">
                                                                                   
                                                                                </td>
                                                                                <td align="right" style="position: relative; top: -5px; padding-right: 10px;">
                                                                                   
                                                                                    
                                                                                </td>
                                                                                <td width="200">
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                        New Entry</HeaderTemplate>
                                                    <ContentTemplate>
                                                      
                                                            <div >
                                                                <table width="40%" style="text-align: center; margin:2% 0 2% 4%;">
                                                                
                                                                    
                                                                    <tr id="trDivision" runat="server" visible="False">
                                                                        <td align="justify" class="auto-style3" runat="server">
                                                                            <asp:Label ID="Label5" runat="server"  Text="Select Division"></asp:Label>
                                                                        </td>
                                                                        <td align="justify" class="auto-style4" colspan="2" runat="server" style="position: relative; left: -175px;">
                                                                            <asp:DropDownList ID="drpDivision" runat="server"  OnSelectedIndexChanged="drpDivision_SelectedIndexChanged">
                                                                                <asp:ListItem Text="---Select---"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify">
                                                                           
                                                                        </td>
                                                                        <td align="justify" >
                                                                          
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style3">
                                                                           
                                                                        </td>
                                                                        <td width="100%" align="left" valign="top"  >
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style1" align="justify">
                                                                           
                                                                        </td>
                                                                        <td align="left" valign="top" class="auto-style4" >
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                          
                                                                        </td>
                                                                        <td align="left" valign="top" dir="rtl" width="50%">
                                                                            
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left" dir="rtl" valign="top" width="50%">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="justify" class="auto-style5">
                                                                        </td>
                                                                        <td align="justify" class="auto-style5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="auto-style5" colspan="3">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                       
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                 <asp:TabPanel ID="Calendar" runat="server">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <asp:Calendar ID="CalHoliday" runat="server" Height="300px" Font-Size="14px" TodayDayStyle-BackColor="Yellow"
                                                                TodayDayStyle-ForeColor="Red" CssClass="fc-body CalAttendance" OnDayRender="Calendar1_DayRender"
                                                                CellPadding="4"></asp:Calendar>
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
            </td>
            <td align="right" width="100%" valign="top">
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="right" width="100%" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</section>
</asp:Content>
