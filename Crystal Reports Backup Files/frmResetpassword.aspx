<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmResetpassword.aspx.cs" Inherits="frmResetpassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript">

        // JQUERY ".Class" SELECTOR.
        $(document).ready(function () {

            $("#txtSub1").keypress(function (event) { return isNumber(event) });

            $('#txtSub1').keyup(function () {
            });
        });

        // THE SCRIPT THAT CHECKS IF THE KEY PRESSED IS A NUMERIC OR DECIMAL VALUE.
        function isNumber(evt) {


            var charCode = (evt.which) ? evt.which : event.keyCode

            if (charCode != 45 && (charCode != 46 ||
                $(this).val().indexOf('.') != -1) && (charCode < 48 || charCode > 57)) {
                return false;
            }
            var currVal = String.fromCharCode(evt.keyCode);
            alert(currVal);
            return true;
        }    
    </script>
       <script language="javascript" type="text/javascript">
           function TopicValidation() {
               var TextBox3 = document.getElementById("<%=txtpassword.ClientID %>").value;
               var txt4 = document.getElementById("<%=TextBox4.ClientID %>").value;
               if (TextBox3.length <= 3) {
                   alert('New password should be more then 3 charecter');
                   return false;
               }

               if (txt4.length <= 3) {
                   alert('Confirm password should be more then 3 charecter');
                   return false;
               }

               return true;
           }
    </script>
  
    <style type="text/css">
        .groupOfTexbox
        {
        }
        .vclassrooms select{ width:61% !important;}
        .mGrid th{text-align="center !important"} 
        .vclassrooms span{ font-size:13px !important;}
        .input-blue {
            width: 75%  !important;
            border: 1px solid #3498db;
            margin: 8px 0px;
            padding: 10px 10px;
            height: 30px;
        }
    </style>
    <style type="text/css">
        .watermarked
        {
            background-color: #F7F6F3;
            border: solid 1px #808080;
            padding: 3px;
            color: Gray;
        }
        
        .unwatermarked
        {
            border: solid 1px #808080;
            padding: 3px;
            color: Black;
        }
  .vclassrooms_send{      /* background: #3498db !important; */
       width:50% !important;                         
        border: none !important;
        font-size: 16px;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 2px;
        color: #fff;
        margin: 7px 5px 7px 0;
        padding: 3px;
        cursor: pointer;
        height: 28px !important;
        float: left;
        text-align: center !important;       }
        
.left{  float:left;     float: left;    width: 100%;    background-color: white;    padding: 13px 0px; }      
.markslist-table{   width:100%;     table-layout: fixed }
.markslist-table tr th{ text-align: center; vertical-align: inherit;    width: 140px;}
.markslist-table tr th:nth-child(1){   }
  
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="content-header">
        <h1>
           Reset Password
        </h1>
        <ol class="breadcrumb">
            <li><a><i></i>Home</a></li>
            <li><a><i></i>Study</a></li>
            <li class="active">Marks Entry Master</li>
        </ol>
    </div>
    <section class="content"> 
        <div class="row">
            <%--<section class="col-md-12 col-xs-12">
                <div class="box box-orange">--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" ActiveTabIndex="0" CssClass="MyTabStyle" ID="MainTab"
                    Width="100%">
                     <asp:TabPanel runat="server" ID="tb2" HeaderText="All Entries">
                        <ContentTemplate>
                            <div class="form-horizontal" style="margin-top:15px;">
                                <div class="col-md-12">
                                    <div class="row">
                                  
                                    <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="Label1" runat="server" Text="User Type" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                         <asp:DropDownList ID="ddlusertype" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlusertype_SelectedIndexChanged"  >
                                                            <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                               <asp:ListItem Value="1" Text="Student"></asp:ListItem>
                                                               <asp:ListItem Value="3" Text="Teacher"></asp:ListItem>
                                                               <asp:ListItem Value="4" Text="Staff"></asp:ListItem>
                                                               <asp:ListItem Value="5" Text="Admin"></asp:ListItem>
                                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    </div>

                                      <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:Label ID="lblSTD1" runat="server" Text="Standard" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                         <asp:DropDownList ID="ddlSTD1" runat="server" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlSTD1_SelectedIndexChanged" CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                               
                                                            </asp:DropDownList>
                                          </div>      
                                   
                                    </div> 
                                    </div> <!-- col-3-->
                                    <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="lblDIV1" runat="server" Text="Division" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                          <asp:DropDownList ID="ddlDIV1" runat="server" AutoPostBack="True" CssClass="form-control"
                                                                OnSelectedIndexChanged="ddlDiv1_SelectedIndexChanged">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>

                                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    </div> 
                                    
                                     <div class="col-md-3">
                                    <div class="form-group">
                                       <asp:Label ID="Label4" runat="server" Text="Users" CssClass="col-md-12 p-rl5"></asp:Label>
                                       <div class="col-md-12 p-rl5">
                                                             <asp:DropDownList ID="ddusers" runat="server"  CssClass="form-control">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>

                                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    </div> 
                                    
                                    <div>
                                                    
                                <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                    <ProgressTemplate>
                                    <asp:Image ID="Image1" ImageUrl="~/images/waiting.gif" AlternateText="Processing" runat="server" />
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    </div>
                                    


                                    </div>  <!-- ROW-->
                                </div>
                            </div>
                               
                                 <div class="vclassrooms">
                                                <table style="font-weight: bolder; width: 45%; padding-top: 10px; margin-top: 50px;" align="center">
                                                   
                                                    <tr>
                                                        <td align="left" nowrap="nowrap" style="padding-bottom: 15px">
                                                            <asp:Label ID="lblvchmake" runat="server" Font-Bold="False">New Password</asp:Label>
                                                        </td>
                                                        <td style="padding-bottom: 15px">
                                                            <asp:TextBox ID="txtpassword" runat="server" CssClass="selectf" ValidationGroup="b" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="ReqFV3" runat="server" ErrorMessage="Please Enter New Password"
                                                                ControlToValidate="txtpassword" Display="None" ValidationGroup="g1" Font-Bold="False"></asp:RequiredFieldValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="ReqFV3"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        &nbsp;
                                                        </tr>
                                                        <tr>
                                                            <td align="left" nowrap="nowrap">
                                                                <asp:Label ID="lblvchdrivername" runat="server" Font-Bold="False" 
                                                                    Text="Confirm Password"></asp:Label>
                                                            </td>
                                                            <td style="padding-bottom: 15px">
                                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="selectf" 
                                                                    TextMode="Password" ValidationGroup="b"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="ReqFdV4" runat="server" 
                                                                    ControlToValidate="TextBox4" Display="None" 
                                                                    ErrorMessage="Please Enter Confirm Password" Font-Bold="False" 
                                                                    ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                                                                    Enabled="True" TargetControlID="ReqFdV4">
                                                                </asp:ValidatorCalloutExtender>
                                                                <asp:CompareValidator ID="comparePasswords" runat="server" 
                                                                    ControlToCompare="txtpassword" ControlToValidate="TextBox4" Display="None" 
                                                                    ErrorMessage="Your new password and confirm password do not match!" 
                                                                    Font-Bold="False" ValidationGroup="g1"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" 
                                                                    Enabled="True" TargetControlID="comparePasswords">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="imgCaptcha" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtImg" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="lblCaptchaResult" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3" nowrap="nowrap" style="padding-left: 62px;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width:100%; padding-left:105px;">
                                                                            <asp:Button ID="btnsubmit" runat="server" CssClass="vclassrooms_send" 
                                                                                OnClick="change_pass" OnClientClick="return TopicValidation()" Text="Submit" 
                                                                                ValidationGroup="g1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>
                                            </div>       
                                  
                                      
                               
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
   

   <%-- </div>
            </section>--%>
            
        </div>
    </section>
</asp:Content>