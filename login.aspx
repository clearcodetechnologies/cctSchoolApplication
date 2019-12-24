﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!doctype html>
<html>
<head>
 <meta charset="UTF-8">
  <meta name="description" content="Free Web tutorials">
  <meta name="keywords" content="HTML,CSS,XML,JavaScript">
  <meta name="author" content="John Doe">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <!--<meta name="viewport" content="width=device-width, initial-scale=1.0">-->

  <!-- bootstrap file -->
<link rel="icon" type="image/png" href="images/E-serve-shiksha-logosm.png" />
 <link rel="stylesheet" href="css_folder/bootstrap.min.css" type="text/css">
 <link rel="stylesheet" href="css_folder/bootstrap-grid.min.css" type="text/css">
 <link rel="stylesheet" href="css_folder/bootstrap-flex.min.css" type="text/css">
  <link rel="stylesheet" href="css_folder/animate.min.css" type="text/css">
 <link rel="stylesheet" href="css_folder/bootstrap-touch-slider.css" type="text/css">

 <!-- custom -->
 <link rel="stylesheet" href="css_folder/custom.css" type="text/css">
 <link rel="stylesheet" href="css_folder/responsive.css" type="text/css">
 <link rel="stylesheet" href="css_folder/font-awesome.min.css" type="text/css">

 
<!--  <link rel="stylesheet" href="css/jquery.animateSlider.css" type="text/css"> 
<link rel="stylesheet" href="css/normalizer.css" type="text/css"> -->
 

 <link rel="stylesheet" href="css_folder/style.css" type="text/css">
 <link rel="stylesheet" href="css_folder/tether.min.css" type="text/css">
 
 

 <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,600,700|Roboto:400,500,700" rel="stylesheet">
 

</head>
<body>
	
<header id="">


	<div class="container">
		<div class="row">
			<div class="social-header">
				<div class="col-lg-8 col-md-8">
					<div class="info-contact">
						<p><strong>Call Us :  +91-022-49707524  - Mail :-  info@efficacious.co.in</strong> </p>

					</div>
				</div>
				<div class="col-lg-4 col-md-4 no-padd-r">
					<ul class="header-social-icon">
						<li><a href="https://www.facebook/profile.php?id=100009143120129&ref=bookmarks" target="_blank"><i class="fa fa-facebook-square fa" aria-hidden="true"></i></a></li>
							<!--<li><a href="https://plus.google.com/u/0/101529290302241595945" target="_blank"><i class="fa fa-google-plus-square" aria-hidden="true"></i></a></li>-->
							<li><a href="https://twitter.com/EfficaciousInd" target="_blank"><i class="fa fa-twitter-square" aria-hidden="true"></i></a></li>

						<li><a href="https://www.linkedin.com/in/efficacious-india-5a7144216" target="_blank"><i class="fa fa-linkedin-square" aria-hidden="true"></i></a></li>
						<li><a href=""><i class="fa fa-" aria-hidden="true"></i></a></li>
						<li><a href="">Support</a></li>
					</ul>
				</div>	
		</div><!-- social header close -->

	

	</div>	<!-- roww -->
</div>		<!-- container -->

<nav class="navbar navbar-expand-lg bg-light navbar-light custom-nav fixed-nav">
	<div class="container">
  <a class="navbar-brand" href="#"><img src="images/E-serve-shiksha-logo1.png"></a>
  <button class="navbar-toggler navbar-right" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
    
  </button>
  <div class="collapse navbar-collapse justify-content-end" id="collapsibleNavbar">
    <ul class="navbar-nav custom-links">
      <li class="nav-item">
        <a class="nav-link hvr-underline-from-left" href="index.html">Home</a>
      </li>
      <li class="nav-item">
        <a class="nav-link hvr-underline-from-left" href="about.html">About Us</a>
      </li>
      <li class="nav-item" >
        <a class="nav-link hvr-underline-from-left" href="solution.html">Our Product</a>
      </li>
       <li class="nav-item">
        <a class="nav-link hvr-underline-from-left" href="benefits.html">Benefits</a>
      </li>
       <li class="nav-item">
        <a class="nav-link hvr-underline-from-left" href="files/e-ServeshikshaEMSEbrochure.pdf" target="_blank">Download</a>
      </li>
      <li class="nav-item">
        <a class="nav-link hvr-underline-from-left" href="contact.html">Contact Us</a>
      </li>
      <li class="nav-item">
        <a class="nav-link login  active" href="login.aspx">Login</a>
      </li>    
    </ul>
  </div>  
  </div>
</nav>
</header>

<div class="clearfix"></div>
<form id="Form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
                <asp:UpdatePanel id="UpdatePanel1" runat="server">                                
                                    <contenttemplate>
<section class="login_img">
<div class="container">
<div class="row justify-content-center">
	<div class="col-lg-5 col-md-8 col-sm-8 col-sm-12">
			<div class="form-box1">
				<a href="index.html"><img src="images/E-serve-shiksha-logo1.png" class="img-fluid mx-auto d-block" alt="e-smarts"></a>

					
						<div class="form-group">
							 <div class="group mb-30">      
							<%-- <select>
							 	<option value="" disabled selected>Select School</option>
				                  <option value="1">e-serveshiksha</option>
				                  <option value="2">mbmp</option>				                  
							 </select>	--%>
                             <asp:DropDownList ID="drpSchool" runat="server" class="form-control form-style" 
                                AutoPostBack="True" onselectedindexchanged="drpSchool_SelectedIndexChanged"></asp:DropDownList>					      
						    </div>
						</div>	
						<div class="form-group">
							 <div class="group mb-30">      
							 <%--<select>
							 	<option value="" disabled selected>Academic Year</option>
				                  <option value="1">2017-2018</option>
				                  <option value="2">2018-2019</option>				                  
							 </select>--%>
                             <asp:DropDownList ID="ddlAcademiYr" runat="server" 
                                class="form-control form-style"></asp:DropDownList>						      
						    </div>
						</div>	
						<div class="form-group">
							 <div class="group mb-30">      
							<%-- <select>
							 	<option value="" disabled selected>Select Role</option>
				                  <option value="1">Admin</option>
				                  <option value="2">Parent</option>
				                  <option value="3">Student</option>
							 </select>--%>		
                             <asp:DropDownList ID="drpUserType" runat="server" 
                    class="form-control form-style"></asp:DropDownList>				      
						    </div>
						</div>	
						<div class="form-group">
							 <div class="group ">      
						      <%--<input type="text" required>--%>
                              <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" required></asp:TextBox>
						      <span class="highlight"></span>
						      <span class="bar"></span>
						      <label>User Name</label>
                              
						    </div>
						</div>	
						<div class="form-group">
							 <div class="group">      
						     <%-- <input type="text" required>--%>
                              <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="50" required></asp:TextBox>
						      <span class="highlight"></span>
						      <span class="bar"></span>
						      <label>Password</label>
                             
						    </div>
						</div>							
						<%--<button type="submit" class="btn btn-primary">SEND </button>--%>
                        <asp:Button ID="btnSubmit"  class="btn btn-primary" runat="server" Text="Login" onclick="btnSubmit_Click" ></asp:Button>
				
                  
			</div>	
		</div>		
	</div>
</div>
</section>
  </contenttemplate>
                    </asp:UpdatePanel>
                    	</form>

<footer >
	<div class="copyright1">
		<div class="container">
			<div clas="row">
				<div clas="col-md-6 wow fadeIn" data-wow-duration="1s" data-wow-delay="0.8s">
					<p>@2018 Efficacious India Limited | All Rights Reserved</p>
				</div>
			</div>
		</div>
	</div>	

</footer>




	
	<!-- script files -->

	<script src="js_folder/jquery-3.2.1.slim.min.js" type="text/javascript"></script>
	<script src="js_folder/bootstrap.min.js" type="text/javascript"></script>
	<!--<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/js/bootstrap.min.js"></script>-->
	<script src="js_folder/tether.min.js" type="text/javascript"></script>
	<script src="js_folder/bootstrap-touch-slider-min.js" type="text/javascript"></script>	
	<script src="js_folder/wow.min.js" type="text/javascript"></script>	
	<script src="js_folder/tilt.jquery.min.js" type="text/javascript"></script>	
	<script src="js_folder/custom.js" type="text/javascript"></script>	
	
	
	<!--<script async defer
    src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap">
    </script> -->
	
	<!--<script src="js/jquery.animateSlider.js" type="text/javascript"></script>
	<script src="js/modernizr.js" type="text/javascript"></script>  -->
	
	    <script type="text/javascript">
	        $('#bootstrap-touch-slider').bsTouchSlider();

            
        </script>

</body>	
</html>