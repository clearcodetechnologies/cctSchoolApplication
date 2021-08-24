<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!doctype html>
<html>
<head>
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- TemplateBeginEditable name="doctitle" -->
    <title>Vclassrooms</title>

    <!-- Bootstrap 3.3.5 -->
   <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body class="wrapper1">
    <form id="form1" runat="server">
    <section>
	<div class="login-form">
    	<div class="logo">
        	<img src="images/logo2.png" class="img-responsive center-block" alt="Vclassrooms">
        </div>
		<%--<div class="form-group">
        	<asp:DropDownList ID="drpSchool" runat="server" class="form-control form-style" 
            AutoPostBack="True" onselectedindexchanged="drpSchool_SelectedIndexChanged"></asp:DropDownList>
          
        </div>
         
         <div class="form-group">
        <asp:DropDownList ID="drpUserType" runat="server" 
                    class="form-control form-style"></asp:DropDownList>
        </div>--%>
        <div class="form-group">
        <asp:DropDownList ID="ddlAcademiYr" runat="server" 
                    class="form-control form-style"></asp:DropDownList>
        </div>
        <div class="form-group">
        <asp:TextBox ID="txtUserName" class="form-control form-style" placeholder="User ID" runat="server"></asp:TextBox>  
			
        </div>	
       
          <div class="form-group">
          <asp:TextBox ID="txtPassword" class="form-control form-style" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>  
			
        </div>	
        <asp:Button ID="btnSubmit"  class="btn my-btn1" runat="server" Text="Login" onclick="btnSubmit_Click" ></asp:Button>
        
    </div>
</section>  
<footer id="copyright">
	<div class="container-fluid">
	<h5 style="text-align:center;">Copyright © 2019-2021. All rights reserved. | Design & Developed by <a href="http://www.clearcodetech.com/" target="_blank">Clearcode Technologies Private Limited</a></h5>
	</div>
</footer>  

    
    </form>
 <script src="js/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/custom.js"></script>
   
</body>
</html>
