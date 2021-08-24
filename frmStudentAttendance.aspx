<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    EnableEventValidation="false" Culture="en-GB" Title="Student Attendance Report"
    CodeFile="frmStudentAttendance.aspx.cs" Inherits="frmStudentAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function ChangeStatus() {
            var value = document.getElementById('<%=drpselect.ClientID %>').value;
            var txt = document.getElementById('<%=txtTime.ClientID %>');
            var lbl = document.getElementById('<%=lblTime.ClientID %>');
            if (value == 'Late') {
                txt.style.visibility = 'visible';
                lbl.style.visibility = 'visible';
            }
            else {
                txt.style.visibility = 'hidden';
                lbl.style.visibility = 'hidden';
            }
        }

        function Confirm() {
            var txt = document.getElementById('<%=txtTime.ClientID %>');
            if (txt.style.visibility == 'visible') {
                if (txt.value == '') {
                    alert('Please enter Late Time');
                    return false;
                }
            }


            var update = confirm('Do You Really Want To Update Current Status ?');

            if (update) {
                return true;
            }
            else {
                return false;
            }
        }

        function UpdateStatus() {
            var value = document.getElementById('<%=drpselect.ClientID %>').value;
            var txt = document.getElementById('<%=txtTime.ClientID %>');
            if (txt.visible == true) {
                alert('Please enter Late Time');
                return false;
            }
            return true;
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
    <style type="text/css">  .color-code{ margin:0px; padding:0px; list-style:none;}
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
        {   background-color: #f2f2f2;  width: 156px;  height: 100px; border: 2px solid White !important;     border-top: 0px !important;
        }
        .myCalendar1
        {    background-color: white;   width: 156px;
            height: 100px;     border: 1px solid White !important;   /*-webkit-box-shadow: 0 0 30px 2px black;*/   border-top: 0px !important;
        }
        .myCalendar a,.myCalendar1 a
        {  text-decoration: none;    color: White;
        }
        .myCalendar .myCalendarTitle,.myCalendar1 .myCalendarTitle 
        { font-weight: bold;    font-size: xx-large; height: 35px;  line-height: 35px;   color: #ffffff;
        }
        .myCalendar th.myCalendarDayHeader
        {   height: 40px;  font-size: smaller;  color: Black;   text-align:center;
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
            /*box-shadow: 0 0 7px 3px black; 
            box-shadow: 1px 1px 6px 2px black;
                -webkit-box-shadow: 1px 1px 6px 2px black;*/    
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

        .Leave {
    background: #FF6600;
    width: 8px;
    height: 8px;
    margin-right: 5px;
    margin-top: 6px;
    display: block;
    float: left;
}    
.table-height
{   height: 350px !important;
    min-height: 340px;
    overflow-y: auto;
    width: 100%;} 
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
            z-index:-1;
           
        .excel
        {
            width: 30px;
            height: 30px;
            float: left;
            left: -114px !important;
            top: 50px !important;
            position: relative;
        }
        .word
        {
            top: 18px !important;
        }
        .pdf
        {
            width: 30px;
            height: 30px;
            float: left;
            position: relative;
            top: 9px !important;
            left: -146px !important;
        }
        .mGrid th
        {
            text-align: center !important;
        }
        .ajax__tab_default .ajax__tab_tab
        {
            overflow: hidden;
            text-align: center;
            display: -moz-inline-box;
            display: inline-block;
            margin-top: -5px;
        }
        
        .MyTabStyle .ajax__tab_body {
            /* font-family: Verdana; */
            /* font-size: 10pt; */
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #d7d7d7;
            margin-top: -1px;
        }
       
        .table>thead>tr>th {
            padding: 5px;
            line-height: 1.42857143;
            vertical-align: top;
            border-top: 1px solid #ddd;
        }
        
         .content-style{font-family: Verdana;
    font-size: 10pt;
    min-height: 1350px;
    background-color: #fff;
    border-top-width: 0;
    border: solid 1px #d7d7d7;
    border-top-color: #d7d7d7;}
    </style>
    
<style type="text/css">
    .modalPopup
    {
    background-color: #696969;
    filter: alpha(opacity=40);
    opacity: 0.7;
    xindex:-1;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Student Attendance </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Attendance</a></li>
              <li class="breadcrumb-item active">  Student Attendance</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 

 <asp:UpdateProgress ID="UpdateProgress" runat="server">
    <ProgressTemplate>
    <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
    </ProgressTemplate>
    </asp:UpdateProgress>

 <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                 <div class="card card-primary card-tabs">

                <div class="card-body">
                
               <div class="form-horizontal">
                       <div class="row">
                          
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize"></asp:Label>

                                <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                        </asp:DropDownList>                               
                               </div>
                         </div>
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblDIV" runat="server" Text="DIV" CssClass="textsize"></asp:Label>

                                 <asp:DropDownList ID="ddlDIV" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlDIV_SelectedIndexChanged">
                                                        </asp:DropDownList>                          
                               </div>
                         </div>
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                    <asp:Label ID="lblStudName" runat="server" Text="Student Name" CssClass="textsize"></asp:Label>

                               <asp:ModalPopupExtender ID="modalPopup" runat="server" DynamicServicePath="" TargetControlID="UpdateProgress"
                                                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup"
                                                                Enabled="True"></asp:ModalPopupExtender>
                                                           <asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                        <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" CssClass="form-control" 
                                                            OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                           
                               </div>
                         </div>
                            <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">

                           <asp:ImageButton ID="ImgXls"   CssClass="export mt-18" ToolTip="Export in Excel" style="   width: 24px;"          
                                                             ImageUrl="~/images/excel.png" runat="server" OnClick="ImgXls_Click" />
                                  <%-- <asp:Label ID="Label3" runat="server" Text="Export to Excel"></asp:Label>--%>
                                  </div>

                            </div>


                                </div>

                       </div>
                    </div> 

                     <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs card-primary" id="custom-tabs-two-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Calendar</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Attendance</a>
                    </li> 
                  </ul>
                      </div>
  <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                       <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="col-lg-12 col-md-12">
                             <asp:Panel ID="panel_Calender" runat="server">
                                            <br>
                                            <asp:Calendar ID="CalAttendance" runat="server" Font-Names="Tahoma" Width="100%"
                                                Font-Size="14px" NextMonthText=">>" PrevMonthText="<<" DayNameFormat="Full" SelectMonthText="»"
                                                SelectWeekText="›" CssClass="myCalendar" OnDayRender="CalAttendance_DayRender"
                                                CellPadding="4">
                                                <OtherMonthDayStyle ForeColor="#B0B0B0" />
                                                <DayStyle CssClass="myCalendarDay" ForeColor="#2D3338" />
                                                <DayHeaderStyle CssClass="myCalendarDayHeader" />
                                                <SelectedDayStyle Font-Bold="True" Font-Size="12px" CssClass="myCalendarSelector" />
                                                <TodayDayStyle CssClass="myCalendarToday" />
                                                <SelectorStyle CssClass="myCalendarSelector" />
                                                <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                <TitleStyle CssClass="myCalendarTitle" />
                                            </asp:Calendar>
                                            <br />
                                            <asp:HiddenField ID="hidForModel" runat="server" />
                                        </asp:Panel>
                              <br />
                                 <%--    <asp:Image ID="Image1" ImageUrl="~/images/LEGEND.png" runat="server" />--%>
                            </div>
                          </div>

                     
                     <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblYear" runat="server" Text="Year" CssClass="textsize"></asp:Label>
                                   <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                        </asp:DropDownList>
                               </div>
                            </div>
                                  <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblMonth" runat="server" Text="Month" CssClass="textsize"></asp:Label>
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                            <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="February" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                        </asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                     <asp:Label ID="Label1" runat="server" Visible="true" Text="From" CssClass="textsize"></asp:Label>
                                  <asp:TextBox ID="txtFrmDate" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtFrmDate_TextChanged"
                                                                                    CssClass="form-control"  ></asp:TextBox>
                                  </div> 
                            </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                     <asp:Label ID="Label5" runat="server" Text="To" Visible="true" CssClass="textsize"></asp:Label>
                                   <asp:TextBox ID="txtToDate" runat="server" Width="100%" OnTextChanged="txtToDate_TextChanged"
                                            AutoPostBack="True" CssClass="form-control"  ></asp:TextBox>
                                  </div> 
                            </div>
                                    <asp:CalendarExtender ID="CalFrmDate" runat="server" TargetControlID="txtFrmDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:TextBoxWatermarkExtender ID="txtF" runat="server" TargetControlID="txtFrmDate"
                                        WatermarkText="From Date" Enabled="True">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:CalendarExtender ID="CalToDate" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"
                                        Enabled="True">
                                    </asp:CalendarExtender>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtToDate"
                                        WatermarkText="To Date" Enabled="True">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtFrmDate"
                                        ControlToValidate="txtToDate" CssClass="textsize" Display="None" ErrorMessage="FromDate Should Be Less Than Or Equal To ToDate"
                                        Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="CompareValidator2_ValidatorCalloutExtender" runat="server"
                                        Enabled="True" TargetControlID="CompareValidator2">
                                    </asp:ValidatorCalloutExtender>


                          </div>
                      </div>
                        <div class="col-md-12">
                             <asp:GridView ID="grdattendance" runat="server" AutoGenerateColumns="False" CssClass="table table-hover talb-bordered cus-table"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="4" DataKeyNames="UserId" EmptyDataText="No Record Found" ForeColor="Black" OnRowDataBound="grdattendance_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:TemplateField HeaderText="1">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn01" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    Text='<%# Eval("01") %>' OnClick="lnkbtn_Click"></asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="2">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn02" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("02") %>'>2</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="3">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn03" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("03") %>'>3</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="4">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn04" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("04") %>'>4</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="5">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn05" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("05") %>'>5</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="6">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn06" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("06") %>'>6</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="7">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn07" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("07") %>'>7</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="8">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn08" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("08") %>'>8</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="9">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn09" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("09") %>'>9</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="10">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn10" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("10") %>'>10</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="11">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn11" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("11") %>'>11</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="12">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn12" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("12") %>'>12</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="13">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn13" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("13") %>'>13</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="14">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn14" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("14") %>'>14</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="15">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn15" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("15") %>'>15</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="16">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn16" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("16") %>'>16</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="17">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn17" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("17") %>'>17</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="18">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn18" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("18") %>'>18</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="19">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn19" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("19") %>'>19</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="20">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn20" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("20") %>'>20</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="21">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn21" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("21") %>'>22</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="22">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn22" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("22") %>'>22</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="23">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn23" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("23") %>'>23</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="24">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn24" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("24") %>'>24</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="25">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn25" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("25") %>'>25</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="26">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn26" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("26") %>'>26</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="27">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn27" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("27") %>'>27</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="28">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn28" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("28") %>'>28</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="29">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn29" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("29") %>'>29</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="30">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn30" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("30") %>'>30</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="31">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtn31" runat="server" CommandArgument='<%#Eval("UserId")%>'
                                                    OnClick="lnkbtn_Click" Text='<%# Eval("31") %>'>30</asp:LinkButton></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" HorizontalAlign="Center" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle HorizontalAlign="left" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                </asp:GridView> 
                                    </div>
                           <asp:Button ID="btnPop" runat="server" Style="display: none" /><asp:ModalPopupExtender
                                                                    ID="ModalPopupExtender1" runat="server" TargetControlID="btnPop" PopupControlID="pnlPopUp"
                                                                    OkControlID="btnPop" DynamicServicePath="" Enabled="True">
                                                                </asp:ModalPopupExtender>
                    <div class="col-md-12">
                               <asp:Panel ID="pnlPopUp" BorderWidth="1px" BackColor="White" Width="40%" runat="server">
                            <div class="form-horizontal">
                       <div class="row">
                            <asp:Label ID="lbltitle" runat="server" Font-Names="Verdana" Font-Size="10pt" ForeColor="White"
                                Text="Change Attendance Status"></asp:Label>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;<asp:ImageButton
                                    ID="btnOk" runat="server" Height="22px" ImageUrl="~/images/cross.png" Width="25px"
                                    OnClick="btnOk_Click" />
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                 <asp:Label ID="lblAttendanceStatus" runat="server" Text="Attendance Status" CssClass="textsize"></asp:Label>

                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                        </asp:DropDownList>                               
                               <asp:DropDownList ID="drpselect" runat="server" onchange="return ChangeStatus();"
                                            CssClass="form-control" AutoPostBack="True">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Present" Value="Present"></asp:ListItem>
                                            <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                                            <asp:ListItem Text="Late" Value="Late"></asp:ListItem>
                                            <asp:ListItem Text="Leave" Value="Leave"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                         </div>
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblTime" runat="server" CssClass="textsize" Text="Time"></asp:Label>

                                 <asp:TextBox ID="txtTime" runat="server" CssClass="form-control"  ></asp:TextBox>
                                    </div>
                         </div>
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblRemark" runat="server" CssClass="textsize" Text="Remark"></asp:Label>

                                  <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                         </div>
                           <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Button ID="btnUpload" runat="server" OnClientClick="return Confirm();" CssClass="btn btn-success btn-sm mt-18"  Text="Update" OnClick="btnUpload_Click"  />
                                  <asp:Button ID="btnClose" runat="server" BackColor="White"  CssClass="btn btn-close btn-sm mt-18" />
                                    </div>
                         </div>

                           </div>

                            </div>
                             </asp:Panel>
                    </div>
                      </div>

                     </div>
                </div>

                   
                     </div>
                </div>
            </div> 
</section>


<section class="content" style="display:none">
    <div style="width: 100%" class="content-style">
        <table width="100%">
            <tr>
                <td width="100%">
                    <asp:UpdatePanel runat="server" ID="Up">
                        <ContentTemplate>
                            <table width="100%">
                                 
                                <tr>
                            <td>
                               <div class="excel" style="width: 100%;top:0 !important;left:87% !important">
                                  Export:
                            </td>
                        </tr>
                                <tr>
                                    <td align="left" colspan="6" width="100%">
                                        <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="3"
                                            Width="100%" Visible="true" AutoPostBack="true" >
                                            <asp:TabPanel runat="server" ID="Calendar">
                                                <HeaderTemplate>
                                                    </HeaderTemplate>
                                                
                                            </asp:TabPanel>
                                           
                                            <asp:TabPanel ID="All" runat="server">
                                                <HeaderTemplate>
                                                    </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" class="style1">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td align="center">
                                                             
                                                              
                                                                    <table bgcolor="white" width="100%">
                                                                        <tr align="right">
                                                                            <td valign="middle" style="background-color: Gray">
                                                                              
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table bgcolor="white" width="100%">
                                                                                   
                                                                                    <tr>
                                                                                        <td align="left" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="left" class="style1">
                                                                                           
                                                                                        </td>
                                                                                        <td class="style1" align="left">
                                                                                           
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td align="center" class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                        <td class="style1">
                                                                                            &#160;&#160;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="4">
                                                                                            &#160;&#160;&#160;&#160;
                                                                                        </td>

                                                                                    </tr>
                                                                                    <%--tr>
                                                                                        <td align="center" colspan="4">
                                                                                            &#160;&#160;<asp:Button ID="Button1" runat="server"
                                                                                                Text="Update" OnClick="btnUpload_Click" />&#160;&#160;
                                                                                        </td>

                                                                                    </tr>--%>
                                                                                    <tr>
                                                                                        <td>
                                                                                            
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table> 
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="Summery" runat="server">
                                                <HeaderTemplate>
                                                    Yearly</HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" class="style1">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <div class="vclassrooms" id="vclassrooms">
                                                                    <table width="50%">
                                                                        <tr>
                                                                            <td align="right" valign="top">
                                                                                <asp:Label ID="Label2" runat="server" Style="position: relative; top: 18px; margin-right: 10px"
                                                                                    CssClass="textsize" Text="Year"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:DropDownList ID="ddlYear1" Width="50%" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                    OnSelectedIndexChanged="ddlYear1_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                            <td align="left">
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" runat="server">
                                                                <asp:GridView ID="grvSummery" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                                    Width="100%" PageSize="12">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Att" HeaderText="Present" ReadOnly="True"></asp:BoundField>
                                                                        <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Absent" HeaderText="Absent"></asp:BoundField>
                                                                        <asp:BoundField DataField="Leave" HeaderText="Leave"></asp:BoundField>
                                                                         <asp:BoundField DataField="Total" HeaderText="Total" Visible="false"></asp:BoundField>
                                                                        <asp:BoundField DataField="Att" HeaderText="Attendance" ReadOnly="True" Visible="false">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="TotDays" HeaderText="Days" ReadOnly="True" Visible="true">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID='AllSummery' runat="server">
                                                <HeaderTemplate>
                                                    Monthly</HeaderTemplate>
                                                <ContentTemplate>
                                                    <center>
                                                        <br />
                                                        <br />
                                                        <center>
                                                            <div class="vclassrooms" id="vclassrooms">
                                                                <table width="70%">
                                                                    <tr valign="top">
                                                                        <td align="left">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="textsize" Text="Month"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged">
                                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblYear2" runat="server" CssClass="textsize" Text="Year"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlYear2" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                                OnSelectedIndexChanged="ddlYear2_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="left">
                                                                            &nbsp;&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <asp:GridView ID="grvStudSumm" runat="server" AllowPaging="false" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                                Width="100%" PageSize="150" OnPageIndexChanging="grvStudSumm_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Roll" HeaderText="Roll No" />
                                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                    <asp:BoundField DataField="Present" HeaderText="Present" ReadOnly="True"></asp:BoundField>
                                                                    <asp:BoundField DataField="Late" HeaderText="Late" ReadOnly="True" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Absent" HeaderText="Absent"></asp:BoundField>
                                                                    <asp:BoundField DataField="Leave" HeaderText="Leave"></asp:BoundField>
                                                                    <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="TotDays" HeaderText="Total Days" ReadOnly="True" Visible="false">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <RowStyle HorizontalAlign="Left"></RowStyle>
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
                                                        </center>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                             <asp:TabPanel runat="server" ID="Tabular123" Visible="false">
                                                <HeaderTemplate>
                                                    Tabular</HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" class="style1">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <div class="tabular">
                                                                    <table width="30%" class="tabular" >
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:ImageButton ID="lnkPrevious" OnClick="lnkPrevious_Click" runat="server" ImageUrl="~\images\previous.png"
                                                                                    ToolTip="Previous" Width="30px" Style="position: relative; top: -5px; left: -4px;" />
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:DropDownList ID="ddlMonth1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlMonth1_SelectedIndexChanged">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                                    <asp:ListItem Value="6">June</asp:ListItem>
                                                                                    <asp:ListItem Value="7">July</asp:ListItem>
                                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:ImageButton ID="lnkNext" OnClick="lnkNext_Click" runat="server" ImageUrl="~\images\next.png"
                                                                                    ToolTip="Next" Width="30px" Style="position: relative; top: -5px; left: 4px;" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <center>
                                                        <asp:GridView ID="grvAttendance" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                            Width="100%" PageSize="31">
                                                            <Columns>
                                                                <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="vchday" HeaderText="Day" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dtinTime" HeaderText="In-Time" ReadOnly="True" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="dtoutTime" HeaderText="Out-Time" ReadOnly="True" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="vchlatestatus" HeaderText="Status" ReadOnly="True">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Latetime" HeaderText="Late Time (HH:MM)" ReadOnly="True" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <RowStyle HorizontalAlign="Left"></RowStyle>
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <PagerStyle CssClass="pgr" />
                                                        </asp:GridView>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID='TabPanel1' runat="server" Visible="false">
                                                <HeaderTemplate>
                                                    Analysis</HeaderTemplate>
                                                <ContentTemplate>
                                                    <br />
                                                    <br />
                                                    <center runat="server">
                                                        <div class="vclassrooms" id="vclassrooms">
                                                            <table width="100%" runat="server">
                                                                <tr runat="server">
                                                                    <td align="center" runat="server" valign="middle">
                                                                        <asp:Label ID="Label4" runat="server" CssClass="textsize" Text="Status"></asp:Label>
                                                                    </td>
                                                                    <td align="left" runat="server">
                                                                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="center" runat="server">
                                                                        <asp:Label ID="Label7" runat="server" CssClass="textsize" Text="Min"></asp:Label>
                                                                    </td>
                                                                    <td align="left" runat="server">
                                                                        <asp:DropDownList ID="ddlMin" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            OnSelectedIndexChanged="ddlMin_SelectedIndexChanged">
                                                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                                                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                                                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td runat="server" valign="top">
                                                                        %
                                                                    </td>
                                                                    <td align="center" style="margin-left: 40px" runat="server">
                                                                        <asp:Label ID="Label8" runat="server" CssClass="textsize" Text="Max"></asp:Label>
                                                                    </td>
                                                                    <td align="left" runat="server">
                                                                        <asp:DropDownList ID="ddlMax" runat="server" AutoPostBack="True" CssClass="textsize"
                                                                            OnSelectedIndexChanged="ddlMax_SelectedIndexChanged">
                                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                                                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                                                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                                                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td runat="server" valign="top">
                                                                        %
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server">
                                                                    <td align="left" runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="left" runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                    <td runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                    <td runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                    <td runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                    <td runat="server">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <asp:GridView ID="grvpercent" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" CssClass="table  tabular-table" EmptyDataText="Record not Found."
                                                            OnPageIndexChanging="grvStudSumm_PageIndexChanging" PageSize="150" Width="100%">
                                                            <AlternatingRowStyle CssClass="alt" />
                                                            <Columns>
                                                                <asp:BoundField DataField="SrNo" HeaderText="S.R. No"></asp:BoundField>
                                                                <asp:BoundField DataField="Roll" HeaderText="Roll No"></asp:BoundField>
                                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                                <asp:BoundField DataField="Tot" HeaderText="Percent(%)" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pgr" />
                                                            <RowStyle HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                    </center>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </td>
                                    <td align="right" width="100%" valign="top">
                                        <div class="pdf">
                                            <asp:ImageButton ID="ImgPdf" ToolTip="Export in PDF" CssClass="export" ImageUrl="~/images/pdfImg.gif"
                                                runat="server" OnClick="ImgPdf_Click" style="margin-top:-18px;" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td align="right" width="100%" valign="top">
                    <table width="100%">
                        
                        <tr>
                            <td align="center" width="100%" valign="top" colspan="2">
                                <div class="word">
                                    <asp:ImageButton ID="ImgDoc" ToolTip="Export in DOC" CssClass="export" ImageUrl="~/images/docImg.gif"
                                        runat="server" OnClick="ImgDoc_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</section>
</asp:Content>
