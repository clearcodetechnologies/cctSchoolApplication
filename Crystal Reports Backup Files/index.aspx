<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="login_index" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!doctype html>
<html>
<head runat="server">
 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <!-- TemplateBeginEditable name="doctitle" -->
    <title>VClassRooms</title>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="dist/css/bootstrap.min.css" type="text/css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="dist/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="dist/css/after-custom2.css" type="text/css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body class="wrapper1">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <section>
	<div class="login-form">
    	<div class="logo">
        	<img src="images/logo2.png" class="img-responsive center-block" alt="VClassRooms">
        </div>
		
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <div class="form-group">
                      <asp:DropDownList ID="drpSchool" CssClass="form-control form-style" runat="server"  AutoPostBack="True" onselectedindexchanged="drpSchool_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                   
                    </asp:DropDownList>
                             </div>
                         <div class="form-group">
                     <asp:DropDownList ID="drpYear" CssClass="form-control form-style" runat="server"  AutoPostBack="True" onselectedindexchanged="drpYear_SelectedIndexChanged">
                        <asp:ListItem>---Select---</asp:ListItem>                   
                    </asp:DropDownList>  
                             </div>
                         <div class="form-group">
                    <asp:DropDownList ID="drpUserType" CssClass="form-control form-style" runat="server">
                             
                    </asp:DropDownList>
                             </div>
                     <div class="form-group">
                    <asp:TextBox ID="txtUserName" CssClass="form-control form-style" placeholder="User Name" runat="server"></asp:TextBox>
                    </div>
                         <div class="form-group">
                    <asp:TextBox ID="txtPassword" CssClass="form-control form-style" TextMode="Password" placeholder="Password"
                        runat="server"></asp:TextBox>
                   </div>
                    <asp:Button ID="btnSubmit"  CssClass="btn my-btn1" runat="server" Text="Login" onclick="btnSubmit_Click" ></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>


        
        
    </div>
</section>  
<footer id="copyright">
	<div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
	<h5 style="text-align:center;">Copyright © 2019-2020. All rights reserved. | Design & Developed by <a href="http://www.clearcodetech.com/" target="_blank">Clearcode Technologies Pvt. Ltd.</a></h5>
	
                </div>
            </div>
        </div>
</footer>  

    
    </form>
<script src="plugins/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="plugins/bootstrap.min.js"></script>
</body>
</html>
