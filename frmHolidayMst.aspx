<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Title="Holiday Master" CodeFile="frmHolidayMst.aspx.cs" Inherits="frmHolidayMst"
    EnableEventValidation="false" Culture="en-gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
       <script type="text/javascript">
function funcswitchtab() {
    $('#custom-tabs-five-normal-tab').trigger('click')
    $("#custom-tabs-five-normal").addClass("active show");
    $("#custom-tabs-five-overlay-dark-tab").removeClass("active");
    $("#custom-tabs-five-overlay-dark").removeClass("show").removeClass("active");
 $("#custom-tabs-five-overlay-tab").removeClass("active");
    $("#custom-tabs-five-overlay").removeClass("show").removeClass("active");
}         
</script>

    <style type="text/css">
        .color-code{ margin:0px; padding:0px; list-style:none;}
.color-code li{ float:left; margin:5px 10px 5px 5px}

.Absent{ background:#FF0000; width:8px; height:8px; margin-right:5px; margin-top:6px;  display:block; float: left}  
.Present { background:BurlyWood; width:8px; height:8px; margin-right:5px; margin-top:6px; display:block; float: left}        
.Present1 { background:green; width:8px; height:8px; margin-right:5px; margin-top:6px; display:block; float: left}          
.Late { background:#f39c12; width:8px; height:8px; margin-right:5px; margin-top:6px; display:block; float: left}          
.Leave   { background:#3c8dbc; width:8px; height:8px; margin-right:5px;  margin-top:6px; display:block; float: left}        
.Sunday   { background:#e67c7c; width:8px; height:8px; margin-right:5px; margin-top:6px; display:block; float: left}         
.Holidaynotusemayur{ background:SkyBlue; width:8px; height:8px; margin-right:5px; margin-top:6px;  display:block; float: left }
.Holiday{ background:#F14C57; width:8px; height:8px; margin-right:5px; margin-top:6px;  display:block; float: left } 
.attendance-list{ margin:10px 0px;}
.attendance-summary{ margin:20px 0px; padding:0px; list-style:none; border: 1px solid #e1e1e1; border-bottom:0px; border-right:0px;}
.attendance-summary li{ width:25%; float:left; height:130px; line-height:90px; padding:0px 10px 0px 0px; text-align: center;     border-right: 1px solid #e1e1e1; border-bottom: 1px solid #e1e1e1; font-size:18px; color:#333; position:relative;}
.attendance-summary li ul{ position: relative;    clear: both;    width: 100%;    left: 13px;    top: -12px;    margin: 0px 0 0 5px;    padding: 0px;    line-height: 20px;    list-style: none;    border: 0px;}
    .attendance-summary li ul li{border:0px; float:left; display:block; width:50%; font-size:12px; font-weight: bold; text-align:left; line-height:20px; height:20px; margin-top:20px;}
.attendance-summary li ul li:first-child{ float:right}
.attendance-summary li ul li .badge {    font-size: 10px;}
.apply-application{ padding:6px 13px; margin-bottom:20px; display: inline-block; background:#3498db; border-radius:3px; color:#fff;}
.apply-application:hover{ color:#CCC}
 .myCalendar
        {   background-color: #f2f2f2;  width: 156px;  height: 100px; border: 2px solid White !important; -webkit-box-shadow: 0 0 30px 2px black;    border-top: 0px !important;
        }
        .myCalendar1
        {    background-color: white;   width: 156px;
            height: 100px;     border: 1px solid White !important;   /*-webkit-box-shadow: 0 0 30px 2px black;*/   border-top: 0px !important;
        }
        .myCalendar a,.myCalendar1 a
        {  text-decoration: none;    color: White;
        }
        .myCalendar .myCalendarTitle,.myCalendar1 .myCalendarTitle 
        { font-weight: bold;    font-size: xx-large; height: 50px;  line-height: 50px;   color: #ffffff;
        }
        .myCalendar th.myCalendarDayHeader
        {   height: 50px;  font-size: smaller;  color: Black;   text-align:center;
            background-color: #3498db;  border-bottom: outset 2px #fbfbfb; border-right: outset 2px #fbfbfb;
        }
        .myCalendar1 th.myCalendarDayHeader
        {
            height: 50px;
            font-size: smaller;
            color: white;
            text-align:center;
            background-color: #3498db;
            border:1px solid white;
        }
       
        .myCalendar td.myCalendarDay
        {
            border: 1px solid #fbfbfb;
        }
        .myCalendar1 td.myCalendarDay
        {
            border: 1px solid #f2f2f2;
        }
        .myCalendar1 td.myCalendarDay:nth-child(7),.myCalendar1 td.myCalendarDay:nth-child(6){
        background-color:#d3ddf9 !important
        }
        .myCalendar td.myCalendarDay:nth-child(7),.myCalendar td.myCalendarDay:nth-child(6){
        background-color:#d3ddf9 !important
        }
        .myCalendar1 td.myCalendarDay:nth-child(7) a,.myCalendar1 td.myCalendarDay:nth-child(6) a
        {
            /*  color: White !important;*/
            color: #e81d1d !important;
                 text-shadow: 1px 1px 5px grey;
        }
        .myCalendar td.myCalendarDay:nth-child(7) a,.myCalendar td.myCalendarDay:nth-child(6) a
        {
          /*  color: White !important;*/
            color: #e81d1d !important;
                 text-shadow: 1px 1px 5px grey;
        }
        .myCalendar1 .myCalendarNextPrev
        {
            text-align: center;
            font-size: 40px;
        }
        .myCalendar .myCalendarNextPrev,.myCalendar1 .myCalendarNextPrev
        {
            text-align: center;
            font-size: 40px;
            height: 24px !important;
    line-height: 20px;
        }
        .myCalendar .myCalendarNextPrev a,.myCalendar1 .myCalendarNextPrev a
        {
            font-size: 13px;

        }
        .myCalendar .myCalendarNextPrev:nth-child(1) a,.myCalendar1 .myCalendarNextPrev:nth-child(1) a
        {
            color: black !important;
            background: url("prevMonth.png") no-repeat center center;
        }
        .myCalendar .myCalendarNextPrev:nth-child(1) a:hover, .myCalendar .myCalendarNextPrev:nth-child(3) a:hover,
        .myCalendar1 .myCalendarNextPrev:nth-child(1) a:hover, .myCalendar1 .myCalendarNextPrev:nth-child(3) a:hover
        {
            background-color: transparent;
        }
        .myCalendar .myCalendarNextPrev:nth-child(3) a,.myCalendar1 .myCalendarNextPrev:nth-child(3) a
        {
            color: black !important;
            background: url("nextMonth.png") no-repeat center center;
        }
        .myCalendar td.myCalendarSelector a,.myCalendar1 td.myCalendarSelector a
        {
            background-color: #E6C520;
        }
        .myCalendar .myCalendarDayHeader a, .myCalendar .myCalendarDay a, .myCalendar .myCalendarSelector a, .myCalendar .myCalendarNextPrev a,
        .myCalendar1 .myCalendarDayHeader a, .myCalendar1 .myCalendarDay a, .myCalendar1 .myCalendarSelector a, .myCalendar1 .myCalendarNextPrev a
        {
            display: inline-block;
            line-height: 40px;
        }
        .myCalendar .myCalendarToday
        {
            background-color: #ffd20c !important;
            /* -webkit-box-shadow: 0 0 7px 3px black;
            box-shadow: 0 0 7px 3px black; */
            box-shadow: 1px 1px 6px 2px black;
                -webkit-box-shadow: 1px 1px 6px 2px black;    
        }
        .myCalendar1 .myCalendarToday
        {
            background-color: #ffd20c !important;
            /* -webkit-box-shadow: 0 0 7px 3px black;
            box-shadow: 0 0 7px 3px black; 
            box-shadow: 1px 1px 6px 2px black;
                -webkit-box-shadow: 1px 1px 6px 2px black;*/
        }
        .myCalendar .myCalendarToday a,.myCalendar1 .myCalendarToday a
        {
            color: #e43d09 !important;
            font-size: medium;
        }
        .myCalendar .myCalendarDay a:hover, .myCalendar .myCalendarSelector a:hover,
        /*.myCalendar1 .myCalendarDay a:hover, .myCalendar1 .myCalendarSelector a:hover*/
        {
            background-color: #DADFDA;
        }
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: gray;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Verdana;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function NoOfDays() {
            //var frmDt = document.getElementById('<=%txtFrmDt.ClientID%>');
            //alert(frmDt);
            //var ToDt = Date.parse(document.getElementById('txtToDt').value);
            //var datediff = ((ToDt - frmDt)/1000*60*60*24).toFixed(0);
            //document.getElementById('txtNoOfdays').value = datediff.value;

            var txtdate1 = document.getElementById('txtFrmDt').value;
            var txtdate2 = document.getElementById('txtToDt').value;
            var date1 = new Date(txtdate1.split('-')[0], txtdate1.split('-')[1] - 1, txtdate1.split('-')[2]);
            var date2 = new Date(txtdate2.split('-')[0], txtdate2.split('-')[1] - 1, txtdate2.split('-')[2]);
            var timediffsec = date2.getTime() - date1.getTime();
            var timediffday = parseInt(timediffsec / (24 * 3600 * 1000));
            document.getElementById('txtNoOfdays').value = timediffday;
        }
    </script>
    <script type="text/javascript">
        function messageConfirm(msg) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(msg)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }

            document.forms[0].reset();
            document.forms[0].appendChild(confirm_value);
        }


        function ConfirmDelete() {
            var del = confirm('Do You Really Want To Delete Selected Record?');
            if (del) {
                return true;
            }
            else {
                return false;
            }
        }

        function ConfirmInsertUpdate() {
            //            if (Page_ClientValidate()) {
            var btn = document.getElementById('<%=btnSubmit.ClientID %>').value;
            if (btn == 'Submit') {
                var del = confirm('Do You Really Want To Save Entered Record?');
                if (del) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var del = confirm('Do You Really Want To Update Entered Record?');
                if (del) {
                    return true;
                }
                else {
                    return false;
                }

            }
            //            }
        }
    </script>
    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        }

        function uploadError(sender) {
            $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        }
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        function GetFileSize() {
            var uploadedFile = document.getElementById("<%=FileUp.ClientID %>");
            var fileSize = uploadedFile.files[0].size;

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Holiday</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Calendar</a></li>
              <li class="breadcrumb-item active">Holiday</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div> 

   <%-- <div class="content-header pd-0">       
        <ul class="top_nav1">
        <li><a >Calendar <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>        
            <li class="active1"> <a href="frmHolidayMst.aspx"> Holiday </a></li>
                  <li><a href="frmVacationMst.aspx"> Vacation</a></li>                 
        </ul>
    </div>--%>
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
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">    Calendar </a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Detail</a>
                    </li>
                        <li class="nav-item">
                      <a class="nav-link" id="custom-tabs-five-normal-tab" data-toggle="pill" href="#custom-tabs-five-normal" role="tab" aria-controls="custom-tabs-five-normal" aria-selected="false"> New Entry  </a>
                    </li> 
                    
                  </ul>
                </div>
                     <div class="card-body">
                       <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="form-horizontal">
                            <div class="row">
                           <div class="col-lg-12 col-md-12 col-sm-12">
                              <asp:Calendar ID="CalHoliday" runat="server" Font-Names="Tahoma"
                                        Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full" SelectMonthText="»"
                                        SelectWeekText="›" CssClass="fc-body myCalendar1" OnDayRender="Calendar1_DayRender" style="width:100% !important;"
                                        CellPadding="4" OnVisibleMonthChanged="CalHoliday_VisibleMonthChanged">
                                        <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                        <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                        <DayHeaderStyle CssClass="myCalendarDayHeader" ForeColor="#2D3338" />
                                        <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                                        <TodayDayStyle CssClass="myCalendarToday" />
                                        <SelectorStyle CssClass="myCalendarSelector" />
                                        <NextPrevStyle CssClass="myCalendarNextPrev" />
                                        <TitleStyle CssClass="myCalendarTitle" />
                                    </asp:Calendar>
                             </div>


                                </div>
                            </div>
                          </div>
                              <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="tab2">
                                 <div class="col-lg-12 col-md-12">
                                       <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged"
                                                                                Text="All" />

                                      <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                CssClass="table  table-hover table-bordered cus-table" DataKeyNames="intHoliday_id" OnPageIndexChanging="grvDetail_PageIndexChanging"
                                                OnRowCommand="grvDetail_RowCommand" OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing"
                                                PageSize="20" Width="100%" EmptyDataText="No Records Found For Selected Month. Please Check All CheckBox To View All Holidays">
                                                <Columns>
                                                <asp:BoundField DataField="intHoliday_Type_Id" HeaderText="Holiday Type" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="dtFromDate" HeaderText="From Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="dtToDate" HeaderText="To Date" ReadOnly="True" />
                                                    <asp:BoundField DataField="intNoOfDay" HeaderText="No Of Days" ReadOnly="True" />
                                                    <asp:TemplateField HeaderText="Document">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgView" CommandName="View" OnClientClick="SetTarget();" CausesValidation="false"
                                                                runat="server" CommandArgument='<%#Bind("vchDocPath") %>' ImageUrl="~/images/action_success.png" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="intHoliday_id" HeaderText="Id" Visible="False" />
                                                                                  
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                ImageUrl="~/images/edit.png" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                                ImageUrl="~/images/delete.png" OnClientClick="return ConfirmDelete();" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                                                    
                                                </Columns>
                                            </asp:GridView>

                                  </div>
                              </div>
                             <div class="tab-pane fade" id="custom-tabs-five-normal" role="tabpanel" aria-labelledby="tab2">
                                   <div id="divEntry" class="" runat="server">
                                   <div class="form-horizontal">
                                       <div class="row">
                                               
                                                     <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                        <asp:Label ID="Label1" runat="server" Text="Holiday Type" CssClass="textcss"></asp:Label>
                                                              <asp:DropDownList ID="ddlHolidayType" Style="" runat="server" CssClass="form-control">
                                                                <%-- <asp:ListItem Text="Select"></asp:ListItem>
                                                                <asp:ListItem Text="Public"></asp:ListItem>
                                                                <asp:ListItem Text="Private"></asp:ListItem>
                                                                <asp:ListItem Text="Bank"></asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Holiday Type"
                                                                InitialValue="Select" Display="None" CssClass="textsize" ControlToValidate="ddlHolidayType"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator3"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>

                                                        </div>
                                                    </div>
                                                     <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="textcss"></asp:Label>
                                                              <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="75" AutoComplete="Off"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Name"
                                                            Display="None" ControlToValidate="txtName" Font-Names="Verdana" Font-Size="Smaller"
                                                            CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                                                runat="server" TargetControlID="RequiredFieldValidator1" Enabled="True">
                                                            </asp:ValidatorCalloutExtender>

                                                        </div>
                                                    </div>
                                                       <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                         <asp:Label ID="Label3" runat="server" Text="Date" style="display:block;" CssClass="textcss"></asp:Label>
                                                            <asp:TextBox ID="txtFrmDt" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                    AutoComplete="Off" OnTextChanged="txtFrmDt_TextChanged" MaxLength="10" Style="width: 49%; display:inline-block;"></asp:TextBox><asp:CalendarExtender
                                                                        ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt" Format="dd/MM/yyyy"
                                                                        Enabled="True">
                                                                    </asp:CalendarExtender>
                                                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                    WatermarkText="From Date" Enabled="True">
                                                                </asp:TextBoxWatermarkExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter From Date"
                                                                    Display="None" ControlToValidate="txtFrmDt" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                        ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2"
                                                                        Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Date Should Be Greater Than or Equal Today's Date"
                                                                    Display="None" ControlToCompare="txtFrmDt" ControlToValidate="TextBox1" Operator="GreaterThan"
                                                                    CssClass="textsize"></asp:CompareValidator><asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4"
                                                                        runat="server" TargetControlID="CompareValidator2" Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>

                                                              <asp:TextBox ID="txtToDt" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                        OnTextChanged="txtToDt_TextChanged" MaxLength="10" Style="width: 49%; margin-left:1%; display:inline-block;" ></asp:TextBox><asp:CalendarExtender
                                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtToDt" Format="dd/MM/yyyy"
                                                                            Enabled="True">
                                                                        </asp:CalendarExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtToDt"
                                                                        WatermarkText="To Date" Enabled="True">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtToDt"
                                                                        ErrorMessage="Please Enter To Date" CssClass="textsize" Display="None"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                            ID="ValidatorCalloutExtender6" TargetControlID="RequiredFieldValidator4" runat="server"
                                                                            Enabled="True">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1"
                                                                        Enabled="True">
                                                                    </asp:ValidatorCalloutExtender>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ErrorMessage="From Date Should Be Less Than Or Equal To To Date"
                                                                        ControlToCompare="txtFrmDt" ControlToValidate="txtToDt" Font-Size="Smaller" Type="Date"
                                                                        Operator="GreaterThanEqual" CssClass="textsize"></asp:CompareValidator>
                                                        </div>
                                                    </div>
                                                     <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                          <asp:Label ID="Label4" runat="server" Text="No Of Days" CssClass="textcss"></asp:Label>
                                                              <asp:TextBox ID="txtNoOfdays" runat="server" AutoComplete="Off" CssClass="form-control"
                                                                                Enabled="False" AutoPostBack="True"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                     <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                           <asp:Label ID="lblDesc" runat="server" CssClass="textcss" Text="Description "></asp:Label>
                                                                <asp:TextBox ID="txtDesc" runat="server" AutoComplete="Off" CssClass="form-control" Height="80px"
                                                                              MaxLength="200" TextMode="MultiLine"></asp:TextBox><asp:TextBoxWatermarkExtender
                                                                                    ID="txtDesc_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtDesc"
                                                                                    WatermarkText="Enter Description Here">
                                                                                </asp:TextBoxWatermarkExtender>

                                                        </div>
                                                    </div>
                                                      <div class="col-lg-3 col-md-4 col-sm-6">
                                                        <div class="form-group">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                                                OnClientClick="return ConfirmInsertUpdate();" CssClass="btn btn-success btn-sm mt-18"  />
                                                            <asp:Button ID="btnClear0" runat="server" CausesValidation="False" CssClass="btn btn-danger btn-sm mt-18"  
                                                                                OnClick="btnClear_Click" Text="Clear" />
                                                        </div>
                                                    </div>

                                                          <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>


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

<section class="content d-none">

        
                       
                                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                                ActiveTabIndex="2">
                                                <asp:TabPanel ID="Calendar" runat="server">
                                                    <HeaderTemplate>
                                                        Calendar</HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                           
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                                    <HeaderTemplate>
                                                        </HeaderTemplate>
                                                    <ContentTemplate>
                                                        <center>
                                                            <div id="div1" runat="server">
                                                                
                                                            </div>
                                                        </center>
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                                    <HeaderTemplate>
                                                       </HeaderTemplate>
                                                    <ContentTemplate>
                                                        
                                                      
                                                                <table width="55%" style="text-align: center; margin:2% 0 2% 2%;">
                                                                  
                                                                    
                                                                    
                                                                    <tr >
                                                                        <td align="center" width="100%" class="style1" valign="top" style="padding-top:10px;">
                                                                           
                                                                        </td>
                                                                         <td class="auto-style6 " style="padding: 10px 8px;">
                                                                         
                                                                        </td>
                                                                        <td align="left" valign="top"  class="style1" style="display:none">
                                                                            <table width="100%">
                                                                                <tr >
                                                                                    <td>
                                                                                        <asp:FileUpload ID="FileUp" runat="server" style="width:50% !important;" Visible="false"/>
                                                                                    </td>
                                                                                     <td width="40%">
                                                                                        <asp:Button ID="btnUpload" CssClass="vclassrooms_send" style="width:184px !important;margin-left:-184px !important;" OnClientClick="GetFileSize();"
                                                                                            runat="server" Text="Upload" OnClick="btnUpload_Click" Visible="false" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblMesg" runat="server" Width="100%" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                 
                                                                            </table>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                    <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" Visible="False" />
                                                                            <br />
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td align="left" width="50%" dir="rtl" valign="top">
                                                                           &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left" width="50%" dir="rtl" valign="top">
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" class="auto-style5" colspan="3">
                                                                       
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                      
                                                    </ContentTemplate>
                                                </asp:TabPanel>
                                            </asp:TabContainer>
                                       
                            <Triggers>
                                <%-- <asp:AsyncPostBackTrigger ControlID="TabContainer1$TabPanel1$btnUpload" EventName="Click" />--%>
                                <asp:PostBackTrigger ControlID="TabContainer1$TabPanel1$btnUpload" />
                       </Triggers>
             <table width="100%">
                 <tr>         
            <td align="right" width="100%" valign="top">
                <table width="100%">
                     
                    <tr>
                        <td align="center" width="100%" valign="top" colspan="2">
                            <div class="word" stye="width:100px;">
                                <asp:ImageButton ID="ImgXls" CssClass="export" ToolTip="Export in Excel" CausesValidation="false"
                                    ImageUrl="~/images/xlsImg.gif" runat="server" OnClick="ImgXls_Click" />
                                <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" Style="position: relative;
                                    top: -22px; left: -27px;" CausesValidation="false" ImageUrl="~/images/pdfImg.gif"
                                    runat="server" OnClick="ImgPdf_Click" />
                                <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" Style="position: relative;
                                    top: -43px; left: 25px;" CausesValidation="false" ImageUrl="~/images/docImg.gif"
                                    runat="server" OnClick="ImgDoc_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</section>

                                     
                                </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>
