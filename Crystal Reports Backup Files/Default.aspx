<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="index_Default" %>

<!DOCTYPE html>
<html>
<head>
    <link href="http://vjs.zencdn.net/c/video-js.css" rel="stylesheet">
    <script src="http://vjs.zencdn.net/c/video.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>E-SMS</title>
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="main">
        <!--Header Start-->
        <div class="main_body">
            <div class="header_innerbody">
                <!-- Header Main Start -->
                <div id="header">
                    <div style="float: left; margin: 20px 0; height: 64px; width: 250px; border: solid red 0px;">
                        <img src="images/logo.png" alt="" title="" border="0"></div>
                    <!-- HTML for SEARCH BAR -->
                    <div id="tfheader">
                        <div class="social_icon">
                            <div class="social_img">
                                <a href="#">
                                    <img src="images/social_link1.png" alt="dl SEO Friendly Images!" title="Facebook" /></a></div>
                            <div class="social_img">
                                <a href="#">
                                    <img src="images/social_link2.png" alt="dl SEO Friendly Images!" title="Stumble Upon" /></a></div>
                            <div class="social_img">
                                <a href="#">
                                    <img src="images/social_link3.png" alt="dl SEO Friendly Images!" title="Facebook" /></a></div>
                            <div class="social_img">
                                <a href="#">
                                    <img src="images/social_link4.png" alt="dl SEO Friendly Images!" title="Facebook" /></a></div>
                            <div class="social_img">
                                <a href="#">
                                    <img src="images/social_link5.png" alt="dl SEO Friendly Images!" title="Twitter" /></a></div>
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div id="content_navi">
                            <ul id="menu_nav">
                                <li><a href="index.html" onmouseover="mopen('m1')" onmouseout="mclosetime()">Home</a></li>
                                <li><a href="#" onmouseover="mopen('m2')" onmouseout="mclosetime()">Attaindance</a>
                                </li>
                                <li><a href="#" onmouseover="mopen('m3')" onmouseout="mclosetime()">Identity Card</a></li>
                                <li><a href="#" onmouseover="mopen('m4')" onmouseout="mclosetime()">Leave</a></li>
                                <li><a href="#" onmouseover="mopen('m5')" onmouseout="mclosetime()">Holiday</a></li>
                                <li><a href="#" onmouseover="mopen('m6')" onmouseout="mclosetime()">Bus Service</a></li>
                                <!--<li><a href="#" onMouseOver="mopen('m7')" onMouseOut="mclosetime()">Notification</a></li>-->
                                <%-- <li><a href="#" onmouseover="mopen('m8')" onmouseout="mclosetime()">View Profile</a></li>--%>
                                <li><a href="#" onmouseover="mopen('m9')" onmouseout="mclosetime()">Login</a>
                                    <div id="m9" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
                                        <a href="frmlogin.aspx?usertype=student">Student</a> <a href="frmlogin.aspx?usertype=parents">
                                            Parents</a> <a href="frmlogin.aspx?usertype=admin">Admin</a> <a href="frmlogin.aspx?usertype=teacher">
                                                Teacher/Staff</a>
                                    </div>
                                </li>
                            </ul>

                            <script type="text/javascript">
                <!--
                                var timeout = 500;
                                var closetimer = 0;
                                var ddmenuitem = 0;

                                // open hidden layer
                                function mopen(id) {
                                    // cancel close timer
                                    mcancelclosetime();

                                    // close old layer
                                    if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';

                                    // get new layer and show it
                                    ddmenuitem = document.getElementById(id);
                                    ddmenuitem.style.visibility = 'visible';

                                }
                                // close showed layer
                                function mclose() {
                                    if (ddmenuitem) ddmenuitem.style.visibility = 'hidden';
                                }

                                // go close timer
                                function mclosetime() {
                                    closetimer = window.setTimeout(mclose, timeout);
                                }

                                // cancel close timer
                                function mcancelclosetime() {
                                    if (closetimer) {
                                        window.clearTimeout(closetimer);
                                        closetimer = null;
                                    }
                                }

                                // close layer when click-out
                                document.onclick = mclose; 
                // -->
                            </script>

                        </div>
                        <!--<div id="cssmenu">
              <ul>
                <li class="active"><a href="#"><span>Home</span></a></li>
                <li><a href="#"><span>Products</span></a></li>
                <li><a href="#"><span>Company</span></a>
                	<div id="m9">
                    <a href="admin_login.html">Admin Login</a>
                    <a href="employee_login.html">Employee Login</a>
                    <a href="frmlogin.aspx">Student Login</a>
                    <a href="parents_login.html">Parents Login</a>
                  </div>
                </li>
                <li class="last"><a href="#"><span>Contact</span></a></li>
              </ul>
            </div>-->
                        <div style="clear: both;">
                        </div>
                    </div>
                    <!-- HTML for SEARCH BAR -->
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <!--Navigation Start-->
            <!--<div id="navigation_bg">  
        <div id="navigation">	
          <div id="content_navi">
            <ul id="menu_nav">
              <li><a href="index.html" onMouseOver="mopen('m1')" onMouseOut="mclosetime()">Home</a></li>
              <li><a href="#" onMouseOver="mopen('m2')" onMouseOut="mclosetime()">Attaindance</a>
              </li>
              <li><a href="#" onMouseOver="mopen('m3')" onMouseOut="mclosetime()">Identity Card</a></li>
              <li><a href="#" onMouseOver="mopen('m4')" onMouseOut="mclosetime()">Leave</a></li>
              <li><a href="#" onMouseOver="mopen('m5')" onMouseOut="mclosetime()">Holiday</a></li>
              <li><a href="#" onMouseOver="mopen('m6')" onMouseOut="mclosetime()">Bus Service</a></li>
              <li><a href="#" onMouseOver="mopen('m7')" onMouseOut="mclosetime()">Notification</a></li>
              <li><a href="#" onMouseOver="mopen('m8')" onMouseOut="mclosetime()">View Profile</a></li>
              <li><a href="#" onMouseOver="mopen('m9')" onMouseOut="mclosetime()">Login</a>
                <div id="m9" onMouseOver="mcancelclosetime()" onMouseOut="mclosetime()">
                  <a href="admin_login.html">Admin Login</a>
                  <a href="employee_login.html">Employee Login</a>
                  <a href="frmlogin.aspx">Student Login</a>
                  <a href="parents_login.html">Parents Login</a>
                </div>
              </li>
            </ul>
            <script type="text/javascript">
							
							var timeout         = 500;
							var closetimer		= 0;
							var ddmenuitem      = 0;
							
							function mopen(id)
							{	
								mcancelclosetime();
							
								if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';
							
								ddmenuitem = document.getElementById(id);
								ddmenuitem.style.visibility = 'visible';
							
							}
							function mclose()
							{
								if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';
							}
							
							function mclosetime()
							{
								closetimer = window.setTimeout(mclose, timeout);
							}
							
							function mcancelclosetime()
							{
								if(closetimer)
								{
									window.clearTimeout(closetimer);
									closetimer = null;
								}
							}
							
							document.onclick = mclose; 
							
							</script>
        	</div>
        </div>
      </div>-->
            <!-- Navigation End -->
            <div style="clear: both;">
            </div>
        </div>
        <!--Header ENd-->
        <div style="clear: both;">
        </div>
        <!--Banner Start-->
        <div class="body_innerbody" style="background: #fcfdf9;">
            <div class="main_banner">
            </div>
        </div>
        <!--Banner End-->
        <div style="clear: both; height: 20px;">
        </div>
        <!--Body Start-->
        <div class="body_innerbody">
            <div class="body_inner">
                <div class="body_tagline">
                    The answer to all your school’s administrative running. An excellent way to systematically
                    manage schools, colleges and institutions.</div>
                <div style="clear: both; height: 10px;">
                </div>
                <div class="content">
                    <div class="content_text">
                        e-SMS(efficient School Management System) aims to completely revolutionize the concept
                        of school management and the much needed child security embedded into it. It allows
                        capturing of Essential input data in an Organized, Systematic & Structured manner
                        and subsequent usage of the same on both real time as well as historical basis by
                        Students, Teachers, Parents and the Administrative staff of the Institute. It allows
                        multilevel Control Mechanism by allowing different logins for Students/ Parents/
                        Teachers. Further the SMS alerts to parents at different levels provides the status
                        of their Ward on Real-Time basis makes life more Simple and Secure. It also allows
                        administrative staff to manage various activities like scheduling Timetable, Activities,Sports,
                        Notifications etc.<br>
                        <br>
                        The whole system has been designed in such a way that it provides seamless platform
                        for systematic interaction between Students, Teachers, Parents and the Management
                        that can be accessed over the web from any part of the Globe.
                    </div>
                    <div class="features">
                        <div class="features_heading">
                            The Key features/modules of the System are as follows:</div>
                        <div style="clear: both;">
                        </div>
                        <div class="features_points">
                            1. Automation of the Attendance System.<br>
                            2. Students/ Teachers can Plan the Vacation/Holidays.<br>
                            3. Automation of the Timetable of Students and Teachers.<br>
                            4. Transport Management& SMS Alerts.
                            <br>
                            5. Tracking of School bus by the Parents.<br>
                            6. Complete Automation of Student Profile Data Management.<br>
                            7. Providing Gate-Way for Fee Payment.
                        </div>
                    </div>
                </div>
                <div style="clear: both; border-top: solid #ccc 1px;">
                </div>
                <div class="profile_head">
                    Multiple User Logins – Web School ERP</div>
                <div style="clear: both; height: 10px;">
                </div>
                <div class="content">
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/attendence.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Attendance Capture</div>
                        </div>
                        <div class="product_bottext">
                            Capturing of Attendance across all levels i.eStudents, Teachers and General Staff
                            will be completed Automated and can be viewedat any time and from any location.
                            User can view the attendance details in a Calendar / tabular format and can also
                            navigate to next and previous months.
                        </div>
                    </div>
                    <div class="gap">
                    </div>
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/sms1.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                SMS Alerts</div>
                        </div>
                        <div class="product_bottext">
                            Easy and quick way to send messages to any user in the system. System sends all
                            activity, notification, attendance remark to parents in the form of SMS.Parent also
                            gets SMS alerts ifthere is any exceptional event occurs such as school bus over
                            speeding define by admin.
                        </div>
                    </div>
                    <div class="gap">
                    </div>
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/leave-icon.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Leave Management</div>
                        </div>
                        <div class="product_bottext">
                            Student, Staff or Teacher can manage their leave andapply leave and emergency leave
                            online. Once system user apply for leave, will automatically go to next approval
                            process depending on the hierarchy defined.
                        </div>
                    </div>
                    <div class="gap">
                    </div>
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/calendar-icon.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Calendar Scheduling</div>
                        </div>
                        <div class="product_bottext">
                            Student, Parent, Teachers and Staff can view holiday and vacation defined by Administration
                            and schedule their vacation accordingly on-line.
                        </div>
                    </div>
                    <div style="clear: both; height: 10px;">
                    </div>
                </div>
                <div style="clear: both; height: 10px;">
                </div>
                <div class="content">
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/bus.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Transport Management</div>
                        </div>
                        <div class="product_bottext">
                            Administrative staff can define route, trip, schedule and timetable of bus. Parents
                            will gets SMS once bus left last bus stop and heading towards their desired destination.Admin
                            and parent can view last location and live tracking of bus. System also provides
                            re-play tracking of any particular day.
                        </div>
                    </div>
                    <div class="gap">
                    </div>
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/paypal.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Payment Gateway</div>
                        </div>
                        <div class="product_bottext">
                            Parent can track and pay school fee, examination fee, bus service charges, and package
                            fee online with highly securedgate-way.
                        </div>
                    </div>
                    <div class="gap">
                    </div>
                    <div class="product_box">
                        <div class="product_outer">
                            <div class="product_img">
                                <img src="images/right.png" style="padding: 10px;"></div>
                            <div class="product_text">
                                Define Rights</div>
                        </div>
                        <div class="product_bottext">
                            Based on department functionality and designation, admin can define different rights
                            for different user.
                        </div>
                    </div>
                    <div style="clear: both; height: 10px;">
                    </div>
                </div>
            </div>
            <div style="clear: both; height: 10px;">
            </div>
            <div id="ListCon">
                <div class="appShadow">
                    <img src="images/appShadow.png"></div>
                <div style="clear: both;">
                </div>
                <div class="relPos_box">
                    <div class="relPos">
                        <div style="float: left; margin: 15px 30px;">
                            <img src="images/products.png"></div>
                        <div style="float: left;">
                            <div class="box_text" style="margin-top: 20px;">
                                Please Try Our</div>
                            <div class="box_text" style="margin-left: 70px;">
                                Beta Version</div>
                            <div>
                                <button id="js-trigger-overlay" type="button">
                                    Register Now</button>
                            </div>
                        </div>
                    </div>
                    <div style="width: 50px; height: 20px; float: left;">
                    </div>
                    <div class="relPos" style="float: right;">
                        <div style="float: left; margin: 15px 30px;">
                            <img src="images/products.png"></div>
                        <div style="float: left;">
                            <div class="box_text" style="margin-top: 20px;">
                                Please Try Our</div>
                            <div class="box_text" style="margin-left: 70px;">
                                Beta Version</div>
                            <div>
                                <button id="js-trigger-overlay" type="button">
                                    Register Now</button>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both; height: 10px;">
                    </div>
                </div>
            </div>
            <div style="clear: both; height: 10px;">
            </div>
        </div>
        <!--Body ENd-->
        <div style="clear: both; height: 30px;">
        </div>
        <!--Footer Start-->
        <div class="footer_topmain">
            <div class="footer_inner_main">
                <div class="menu_simple">
                    <ul>
                        <li class="menu_head"></li>
                        <li class="menu_content"><a href="#">Home</a></li>
                        <li class="menu_content"><a href="#">About Us</a></li>
                        <li class="menu_content"><a href="#">Services</a></li>
                        <li class="menu_content"><a href="#">Attendance</a></li>
                        <li class="menu_content"><a href="#">Contact Us</a></li>
                    </ul>
                </div>
                <div class="space">
                </div>
                <div class="menu_simple">
                    <ul>
                        <li class="menu_head">Other Features</li>
                        <li class="menu_content"><a href="#">Library Management Software</a></li>
                        <li class="menu_content"><a href="#">Payroll Management System</a></li>
                        <li class="menu_content"><a href="#">Visitor Management Software</a></li>
                        <li class="menu_content"><a href="#">Hospital Management Software</a></li>
                        <li class="menu_content"><a href="#">Smartcard Based Solution</a></li>
                    </ul>
                </div>
                <div class="space">
                </div>
                <div class="menu_simple">
                    <ul>
                        <li class="menu_head">Download Broucher</li>
                        <li><a href="#">
                            <img src="images/pdf.png">&nbsp;&nbsp;&nbsp;Brouchers 1</a></li>
                        <li><a href="#">
                            <img src="images/pdf.png">&nbsp;&nbsp;&nbsp;Brouchers 2</a></li>
                        <li><a href="#">
                            <img src="images/pdf.png">&nbsp;&nbsp;&nbsp;Brouchers 3</a></li>
                        <li><a href="#">
                            <img src="images/pdf.png">&nbsp;&nbsp;&nbsp;Brouchers 4</a></li>
                        <li><a href="#">
                            <img src="images/pdf.png">&nbsp;&nbsp;&nbsp;Brouchers 5</a></li>
                    </ul>
                </div>
                <div class="space">
                </div>
                <div class="menu_simple">
                    <ul>
                        <li class="menu_head">Newsletters</li>
                    </ul>
                    <div style="border: solid red 0px; width: 220px; float: left; margin: 10px 0 0 30px;">
                        <form name="input" method="post" style="background: none; border: none;">
                        <input type="text" name="user" class="subs_input">
                        </form>
                        <div class="gray-button-div" align="right">
                            <input type="button" name="button" value="Subscribe Now" class="button-gray" style="margin: 10px" /></div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
        <div class="footer_main">
            <div class="footer_inner_main">
                <div class="footer_copy">
                    Copyright &copy 2014. All Right Reserved</div>
                <div class="footer_copy" style="float: right;">
                    Design & Developed by Mayuresh Kesalkar</div>
            </div>
        </div>
        <!--Footer End-->
    </div>
</body>
</html>
