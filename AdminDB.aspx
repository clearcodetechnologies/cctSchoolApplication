<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="AdminDB.aspx.cs" Inherits="AdminDB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<body >--%>
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
      <%--  var popup = $find('<%= modalPopup.ClientID %>');--%>
        //if (popup != null) {
        //    popup.hide();
        }
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
        {
            background-color: #f2f2f2;
            width: 156px;
            height: 100px;
            border: 2px solid White !important;
            -webkit-box-shadow: 0 0 30px 2px black;
            border-top: 0px !important;
        }
        .myCalendar1
        {
            background-color: white;
            width: 156px;
            height: 100px;
            border: 1px solid White !important;
            /*-webkit-box-shadow: 0 0 30px 2px black;*/
            border-top: 0px !important;
        }
        .myCalendar a,.myCalendar1 a
        {
            text-decoration: none;
            color: White;
        }
        .myCalendar .myCalendarTitle,.myCalendar1 .myCalendarTitle,
        {
            font-weight: bold;
            font-size: xx-large;
            height: 50px;
            line-height: 50px;
            background-color:#3c8dbc;
            color: #ffffff;
        }
        .myCalendar th.myCalendarDayHeader
        {
            height: 50px;
            font-size: smaller;
            color: Black;
            text-align:center;
            background-color: #3498db;
            border-bottom: outset 2px #fbfbfb;
            border-right: outset 2px #fbfbfb;
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
           
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
 <!-- Main content -->

   <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/hourglass.gif"></asp:Image>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
            Enabled="True">
        </asp:ModalPopupExtender>

            <div class="content">
                <div class="container-fluid">
                <!-- Small boxes (Stat box) -->
                <div class="row" style="display:none;">
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-aqua">
                            <div class="inner">
                                <h4>
                                    <asp:Label ID="lastLogin" runat="server" Text="Label"></asp:Label></h4>
                                <p>
                                    Last seen</p>
                            </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/attendance-img.png"></i>
                            </div>
                            <a href="FrmStudentLog.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-green">
                            <div class="inner">
                                <h4>
                                    <asp:Label ID="Label2" runat="server" Text="Fee Collection"></asp:Label></h4>
                                <%--<h6>
                                    <asp:Label ID="lblDue" runat="server" Text="Due Till Date : "></asp:Label></h6>--%>
                                    <h6>
                                    <asp:Label ID="lblDue" runat="server" Text="Gross Till Date : "></asp:Label></h6>
                                <h6>
                                    <asp:Label ID="lblRecd" runat="server" Text="Recd Till Date : "></asp:Label></h6>
                                    <h6>
                                    <asp:Label ID="lblPending" runat="server" Text="Pending Till Date : "></asp:Label></h6>
                            </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/Exams-mg.png"></i>
                            </div>
                            <a href="frmStandardWiseRpt.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-yellow" id="Attendace" runat="server">
                            <div class="inner"  >
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text="Attendance"></asp:Label></h4>
                                <h5>
                                    <asp:Label ID="lblStudentCnt" runat="server" Text="Student : "></asp:Label></h5>
                                <h5>
                                    <asp:Label ID="lblTeacherCnt" runat="server" Text="Teacher : "></asp:Label></h5>
                                <h5>
                            <asp:Label ID="lblStaffCnt" runat="server" Text="Staff : "></asp:Label></h5>
                        </div>
                            <div class="icon">
                                <i class="ion">
                                    <img src="img/dashboard-img/homework-img.png"></i>
                            </div>
                            <a href="frmTeacherStaffAtt.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6">
                        <!-- small box -->
                        <div class="small-box bg-red"  id="selfAttendance" runat="server" >
                            <div class="inner">
                                <h4>
                                    Attendance</h4>
                                <p>
                                    Self % :
                                    <asp:Label ID="lblcumulative" runat="server" Text="Label"></asp:Label>
                                </p>
                            </div>
                            <div class="icon">
                                <i class="ion ">
                                    <img src="img/dashboard-img/Fee-img.png"></i>
                            </div>
                            <a href="frmMonthlyAttendance.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right">
                            </i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>

                <div class="row" style="margin-bottom: 20px; ">
                    <div class="col-md-4">                
<div class="table-responsive">
<h4 style="color: White;">    </h4>  
<div style="display:block; margin:0 auto;">
<asp:Chart ID="Chart1" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
BorderlineWidth="0"  Palette="None" PaletteCustomColors="Maroon"  
BorderlineColor="64, 0, 64">  
<Titles>  
<asp:Title ShadowOffset="10" Name="Items" />  
</Titles>  
<Legends>  
<asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
LegendStyle="Row" />  
</Legends>  
<Series>  
<asp:Series Name="Student Attendance" />  
</Series>  
<ChartAreas>  
<asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
</ChartAreas>  
</asp:Chart> 
</div>
</div>   <!-- box-body student--> 
</div> 
                        
<div class="col-md-4">                
<div class="table-responsive">
<h4 style="color: White;">    </h4>  
<div style="display:block; margin:0 auto;">
<asp:Chart ID="Chart2" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
BorderlineWidth="0"  Palette="None" PaletteCustomColors="Maroon"  
BorderlineColor="64, 0, 64">  
<Titles>  
<asp:Title ShadowOffset="10" Name="Items" />  
</Titles>  
<Legends>  
<asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
LegendStyle="Row" />  
</Legends>  
<Series>  
<asp:Series Name="Teacher Attendance" />  
</Series>  
<ChartAreas>  
<asp:ChartArea Name="ChartArea2" BorderWidth="0" />  
</ChartAreas>  
</asp:Chart> 
</div>
</div>   <!-- box-body Teacher--> 
</div>       
                        
                        <div class="col-md-4">                
<div class="table-responsive">
<h4 style="color: White;">    </h4>  
<div style="display:block; margin:0 auto;">
<asp:Chart ID="Chart3" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
BorderlineWidth="0"  Palette="None" PaletteCustomColors="Maroon"  
BorderlineColor="64, 0, 64">  
<Titles>  
<asp:Title ShadowOffset="10" Name="Items" />  
</Titles>  
<Legends>  
<asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
LegendStyle="Row" />  
</Legends>  
<Series>  
<asp:Series Name="Staff Attendance" />  
</Series>  
<ChartAreas>  
<asp:ChartArea Name="ChartArea3" BorderWidth="0" />  
</ChartAreas>  
</asp:Chart> 
</div>
</div>   <!-- box-body Staff--> 
</div>           

                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="card card-primary card-outline card-outline-tabs" id="Cal" runat="server" >
                            <!-- Tabs within a box -->
                           <div class="card-header p-0 border-bottom-0">
                            <ul class="nav nav-tabs" id="custom-tabs-four-tab" role="tablist">
<%--                                <li class="nav-item active"><a href="#Month" data-toggle="tab">Month </a></li> --%>
                                <li class="nav-item"><a class="nav-link active"> Calendar </a></li>
                            </ul>
                               </div>
                            <div class="card-body tab-content">
                                <!-- Morris chart - Sales -->
                                <div class="chart tab-pane active" id="Month">
                                    <div id='calendar' runat="server" >
                                        <%--<asp:Calendar ID="CalAttendance" runat="server" Height="300px" Font-Size="14px" TodayDayStyle-BackColor="Yellow"
                                            TodayDayStyle-ForeColor="Red" CssClass="fc-body CalAttendance" 
                                            CellPadding="4" OnDayRender="Calendar1_DayRender"></asp:Calendar>--%>

                                            <asp:Calendar ID="CalAttendance" runat="server" Font-Names="Tahoma" Height="250px"
                                                Width="100%" Font-Size="14px" NextMonthText=">>" PrevMonthText="<<"
                                                SelectMonthText="»" SelectWeekText="›" CssClass="myCalendar1" OnDayRender="Calendar1_DayRender"
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
                                    </div>
                                    <ul class="color-code">
                                       <li><span class="color-box Absent"></span>Absent </li>
                                        <li><span class="color-box Present1"></span>Present </li> 
                                        <li><span class="color-box Present"></span>Vacation </li>       
                                        <%--<li><span class="color-box Leave"></span>Leave </li>
                                <li><span class="color-box Holiday"></span>Holiday</li>--%>
                                    </ul>
                                </div>
                                <div class="chart tab-pane" id="graph" style="width: 300px; margin: 0px auto; display: none">
                                </div>
                            </div>
                        </div>
                        <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.0.3/jquery.min.js"></script>
                        <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.2/raphael-min.js"></script>
                        <script src="js/morris.js"></script>
                        <script>                            Morris.Donut({
                                element: 'graph',
                                colors: ["#00a65a  ", "#f56954 ", "#3c8dbc"],

                                data: [
                                    { value: 70, label: 'Present', formatted: '70%' },
                                    { value: 30, label: 'Absent', formatted: '30%' },
                              ],
                                formatter: function (x, data) { return data.formatted; }
                            });</script>
                        <!-- chart screen -->
                        <div class="card topborder " id="SendMessage" runat="server" >
                            <div class="card-header with-border">
                                <h3 class="card-title">
                                    Send Message</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="card-body ">
                                <div class="form-horizontal">
                                    <div class="form-group row">                                            
                                         <asp:Label ID="lblUserType" runat="server" CssClass="col-sm-2 col-form-label" Text="User type" visible="true"></asp:Label>
                                            <div class="col-sm-10">                                              
                                                <asp:DropDownList ID="drpUserType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpUserType_SelectedIndexChanged" visible="true">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>
                                    <div visible="false" runat="server" id="trStudent">
                                     <div class="form-group row">                                      
                                          <asp:Label ID="Label3" runat="server" CssClass="col-sm-2 col-form-label"  Text="Std"></asp:Label>       
                                            <div class="col-sm-10">                                              
                                                <asp:DropDownList ID="drpStandard" runat="server" CssClass="form-control"  AutoPostBack="True"
                                                    OnSelectedIndexChanged="drpStandard_SelectedIndexChanged">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>
                                        <div class="form-group row">                                      
                                             <asp:Label ID="Label11" runat="server" CssClass="col-sm-2 col-form-label" Text="Div" ></asp:Label> 
                                            <div class="col-sm-10">                                              
                                               <asp:DropDownList ID="drpDivision" runat="server" CssClass="form-control"  AutoPostBack="True"
                                                    OnSelectedIndexChanged="drpDivision_SelectedIndexChanged" >
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>
                                         <div class="form-group row">                            
                                               <asp:Label ID="Label12"  CssClass="col-sm-2 col-form-label" runat="server" Text="Student"></asp:Label>        
                                            <div class="col-sm-10">                                              
                                               <asp:DropDownList ID="drpStudent" runat="server" CssClass="form-control"  >
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>
                                         <div class="form-group row">                            
                                               <asp:Label ID="Label9"  CssClass="col-sm-2 col-form-label" runat="server" Text="Student"></asp:Label>        
                                            <div class="col-sm-10">                                              
                                               <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"  >
                                                    <asp:ListItem>---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>

                                        </div>
                                     <div visible="false" runat="server" id="trStaff">
                                          <div class="form-group row">                
                                               <asp:Label ID="lblDepartment"  CssClass="col-sm-2 col-form-label" runat="server" Text="Department"></asp:Label>         
                                            <div class="col-sm-10">                                              
                                              <asp:DropDownList ID="drpDepartment" runat="server" CssClass="form-control"  AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                                    <asp:ListItem>---ALL---</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                      </div>
                                          <div class="form-group row">                
                                              <asp:Label ID="Label13"  CssClass="col-sm-2 col-form-label" runat="server" Text="Staff"></asp:Label>
                                                
                                            <div class="col-sm-10">                                              
                                              <asp:DropDownList ID="drpStaff" CssClass="form-control"  runat="server">
                                                    <asp:ListItem>---select---</asp:ListItem>
                                                </asp:DropDownList> 
                                            </div>
                                      </div> 
                                         </div>
                                      <div class="form-group row">                 
                                                 <asp:Label ID="Label16" runat="server" CssClass="col-sm-2 col-form-label" Text="Notice" visible="true"></asp:Label>
                                            <div class="col-sm-10">                                              
                                                 <asp:TextBox ID="txtNotice" runat="server" CssClass="form-control"  TextMode="MultiLine" Height="68px"  
                                                    placeholder="Message" visible="true"></asp:TextBox>
                                            </div>
                                      </div>
                                    <div class="form-group row">                 
                                                 <asp:Label ID="Label10" runat="server" CssClass="col-sm-2 col-form-label" Text=" " visible="true"></asp:Label>
                                            <div class="col-sm-10">                                              
                                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success btn-sm "
                                                    runat="server" Text="Submit" OnClick="btnSubmit_Click" visible="true" />
                                            </div>
                                      </div>

                                </div>
                                <div class="inner-panel">
                                    <table >
                                         
                                         
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="text-align: left; margin-top: 10px">
                                            
                                                <asp:GridView ID="grvLibrary" runat="server" AllowPaging="True" 
                                                    AllowSorting="True" AutoGenerateColumns="False" 
                                                    CssClass="table  tabular-table " EmptyDataText="Record not Found." PageSize="5" 
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Book" HeaderText="Book Name" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                                        <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Return Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReturn" runat="server" Text='<%#Eval("Return") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>
                                            </td>
                                         
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <!-- /.box-body -->
                            <!-- /.box-footer-->
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Library Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Inventory Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvInventory" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                                    PageSize="5" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Item" HeaderText="Items" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Issue" HeaderText="Issue Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Return" HeaderText="Return Date" Visible="false" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Return Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturn" Text='<%#Eval("Return") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual Return Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActual" Text='<%#Eval("dtActualReturnDt") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>


                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Leave Status</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvLeaveStatus" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CssClass="table  tabular-table " EmptyDataText="Record not Found." DataKeyNames="intLeaveApplocation_id"
                                    Width="100%" PageSize="5">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveId" Text='<%#Eval("intLeaveApplocation_id") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="vchLeaveType_name" HeaderText="Type" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ToDate" HeaderText="To Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotDt" HeaderText="Total Days" />
                                        <asp:BoundField DataField="Status" HeaderText="Total Days" />
                                        <%--<asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkstatus" Text='<%#Eval("Status") %>' runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="card  topborder" id="noticeboard" runat="server" >
                            <div class="card-header">
                                <h3 class="card-title">
                                    Notice Board
                                </h3>
                            </div>
                            <div class="card-tools chart-responsive">
                              <div id="" style="overflow:scroll; height:300px;">
                                <ul class="notice">
                                    <li id="Notice1" visible="false" runat="server">                                        
                                        <div class="board">
                                        <p class="time">
                                               <strong> Issue Date:
                                                <asp:Label ID="lblIssueDate1" runat="server"></asp:Label>
                                                <%--End Date:
                                                <asp:Label ID="lblEndDate1" runat="server"></asp:Label> </strong>--%>
                                            </p>
                                            <p><strong> Subject :  <asp:Label ID="lblSubject1" runat="server"></asp:Label> </strong></p>
                                            <p><strong> Notice :  <asp:Label ID="lblNotice1" runat="server"></asp:Label> </strong></p>
                                          <p><strong> Image : </strong>  <asp:Image ID="NoticeImage1" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Li1" visible="false" runat="server">                                        
                                        <div class="board">
                                        <p class="time">
                                                Issue Date:
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                            </p>
                                            <p><strong> Subject : </strong> <asp:Label ID="Label6" runat="server"></asp:Label></p>
                                            <p><strong> Notice : </strong> <asp:Label ID="Label7" runat="server"></asp:Label></p>

                                           
                                            
                                        </div>
                                    </li>
                                    <li id="Notice2" visible="false" runat="server">
                                        <asp:Label ID="lblSubject2" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice2" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate2" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate2" runat="server"></asp:Label></p>
                                                 <p><strong> Image : </strong>  <asp:Image ID="NoticeImage2" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice3" visible="false" runat="server">
                                        <asp:Label ID="lblSubject3" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice3" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate3" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate3" runat="server"></asp:Label></p>
                                                <p><strong> Notice : </strong> <asp:Label ID="Label8" runat="server"></asp:Label></p>
                                                  <p><strong> Image : </strong>  <asp:Image ID="NoticeImage3" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice4" visible="false" runat="server">
                                        <asp:Label ID="lblSubject4" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice4" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate4" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate4" runat="server"></asp:Label></p>

                                                <p><strong> Image : </strong>  <asp:Image ID="NoticeImage4" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice5" visible="false" runat="server">
                                        <asp:Label ID="lblSubject5" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice5" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate5" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate5" runat="server"></asp:Label></p>
                                                 <p><strong> Image : </strong>  <asp:Image ID="NoticeImage5" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice6" visible="false" runat="server">
                                        <asp:Label ID="lblSubject6" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice6" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate6" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate6" runat="server"></asp:Label></p>
                                                  <p><strong> Image : </strong>  <asp:Image ID="NoticeImage6" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice7" visible="false" runat="server">
                                        <asp:Label ID="lblSubject7" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice7" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate7" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate7" runat="server"></asp:Label></p>
                                                  <p><strong> Image : </strong>  <asp:Image ID="NoticeImage7" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice8" visible="false" runat="server">
                                        <asp:Label ID="lblSubject8" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice8" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate8" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate8" runat="server"></asp:Label></p>
                                                 <p><strong> Image : </strong>  <asp:Image ID="NoticeImage8" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice9" visible="false" runat="server">
                                        <asp:Label ID="lblSubject9" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice9" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate9" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate9" runat="server"></asp:Label></p>
                                                 <p><strong> Image : </strong>  <asp:Image ID="NoticeImage9" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>
                                    <li id="Notice10" visible="false" runat="server">
                                        <asp:Label ID="lblSubject10" runat="server"></asp:Label>
                                        <div class="board">
                                            <p>
                                                <asp:Label ID="lblNotice10" runat="server"></asp:Label></p>
                                            <p class="time">
                                                Issue Date:
                                                <asp:Label ID="lblIssueDate10" runat="server"></asp:Label>
                                                End Date:
                                                <asp:Label ID="lblEndDate10" runat="server"></asp:Label></p>
                                        <p><strong> Image : </strong>  <asp:Image ID="NoticeImage10" runat="server" Height="10%" Width="100%"
                                                              ImageUrl='<%# Eval("ImageUrl") %>' /> </p>
                                        </div>
                                    </li>                                   
                                </ul>
                            </div> </div>
                        </div>
                         <div class="card topborder" id="GenderWiserCount" runat="server" >
                            <div class="card-header with-border">
                                <h3 class="card-title">
                                   Standard Wise Student
                                </h3>
                            </div>
                            <div class="card-body no-padding">
                            <div class=" table-height">
                                <asp:GridView ID="grdStudentCnt" CssClass="table table-hover table-bordered cus-table" runat="server"
                                    AutoGenerateColumns="False" Width="100%" ShowFooter="True" >
                                    <Columns>
                                        <asp:BoundField DataField="Standard" HeaderText="Standard" />
                                        <asp:BoundField DataField="Division" HeaderText="Division" />
                                        <asp:BoundField DataField="Male" HeaderText="Male" />
                                       <asp:BoundField DataField="Female" HeaderText="Female" />
                                       <asp:BoundField DataField="Total" HeaderText="Total" />
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="box border-blue" style="display: none">
                            <div class="box-header">
                                <h3 class="box-title">
                                    Device Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <asp:GridView ID="grvHoliday" runat="server" AllowPaging="True" AllowSorting="false"
                                    AutoGenerateColumns="False" CssClass="table  tabular-table " EmptyDataText="Record not Found."
                                    PageSize="5" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="vchHoliday_name" HeaderText="Name" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromDate" HeaderText="Date" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Day" HeaderText="Day" ReadOnly="True">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
                    
                </div>
            </div>
    </ContentTemplate>
</asp:UpdatePanel>
     <%-- </body>--%>
</asp:Content>
