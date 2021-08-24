<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmlogin.aspx.cs" Inherits="frmlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>E-SMS</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function callUserNamePassword() {            
            $.ajax({                        
                type: "POST",
                url: "frmlogin.aspx/UserNamePassword",
                data: '{name: "' + $("#<%=txtUsername.ClientID%>")[0].value + '",password: "' + $("#<%=txtpassword.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,                                 
                failure: function(response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {            
                window.location = "../frmstudentTravelDet.aspx"; 
            }  
    </script>

</head>
<body>
    <div>
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
                        </div>
                        <div style="clear: both;">
                        </div>
                        <div id="content_navi" style="float: right;">
                            <ul id="menu_nav">
                                <li><a href="index.html" onmouseover="mopen('m1')" onmouseout="mclosetime()">Home</a></li>
                                <li><a href="#" onmouseover="mopen('m9')" onmouseout="mclosetime()">Login</a>
                                    <div id="m9" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
                                        <a href="student_login.html">Admin Login</a> <a href="student_login.html">Employee Login</a>
                                        <a href="student_login.html">Student Login</a> <a href="student_login.html">Parents
                                            Login</a>
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
                    <a href="student_login.html">Student Login</a>
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
                  <a href="student_login.html">Student Login</a>
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
        <div style="clear: both; width: 1024px; background: #dcdcdc; margin: 0 auto; height: 1px;">
        </div>
        <!--Body Start-->
        <div class="main_innerbody">
            <div class="content_outer">
                <div id="content">
                    <div class="player-profile-div-new" style="border: solid red 0px;">
                        <!-- Start login-form -->
                        <!--<span id="toggle-login" class="button" href="#">Log in</span>-->
                        <div id="login">
                            <div id="triangle">
                            </div>
                            <h1>
                                Students Login</h1>
                            <form id="Form1" runat="server">
                            <input id="txtUsername" type="text" runat="server" placeholder="User name" />
                            <input id="txtpassword" type="password" placeholder="Password" runat="server" />
                            <input id="Submit1" type="submit" value="Log in" runat="server" onclick="return callUserNamePassword();" />
                            </form>
                        </div>
                        <!-- end login-form -->

                        <script>
                            $('#toggle-login').click(function() {
                                $('#login').toggle();
                            });
                        </script>

                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
            </div>
        </div>
        <!--<script src="http://code.jquery.com/jquery-1.7.2.min.js"></script>-->

        <script>
            $(document).ready(function() {
                $("#content").find("[id^='tab']").hide(); // Hide all content
                $("#crumbs li:first").attr("id", "current"); // Activate the first tab
                $("#content #tab1").fadeIn(); // Show first tab's content

                $('#crumbs a').click(function(e) {
                    e.preventDefault();
                    if ($(this).closest("li").attr("id") == "current") { //detection for current tab
                        return;
                    }
                    else {
                        $("#content").find("[id^='tab']").hide(); // Hide all content
                        $("#crumbs li").attr("id", ""); //Reset id's
                        $(this).parent().attr("id", "current"); // Activate this
                        $('#' + $(this).attr('name')).fadeIn(); // Show content for the current tab
                    }
                });
            });
           

        </script>

        <!--Body ENd-->
        <div style="clear: both; height: 30px;">
        </div>
    </div>
</body>
</html>
