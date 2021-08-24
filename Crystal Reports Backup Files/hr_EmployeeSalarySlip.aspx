<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="hr_EmployeeSalarySlip.aspx.cs" Inherits="hr_EmployeeSalarySlip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintDiv1() {
            var contents = document.getElementById("dvContents1").innerHTML;
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-1000000px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><title>Salary Slip</title>');
            frameDoc.document.write('</head><body>');
            frameDoc.document.write(contents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                document.body.removeChild(frame1);
            }, 500);
            return false;
        }
    </script>
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
        .style2
        {
            width: 543px;
            height: 32px;
        }
        .style3
        {
            height: 32px;
        }
        .style4
        {
            width: 521px;
            height: 31px;
        }
        .style5
        {
            height: 31px;
        }
        .style10
        {
            width: 436px;
            height: 31px;
        }
        .style11
        {
            width: 436px;
        }
        .style19
        {
            width: 275px;
            height: 26px;
        }
        .style27
        {
            width: 26%;
        }
        .style28
        {
            width: 313px;
            height: 26px;
        }
        .style29
        {
            width: 313px;
        }
        .style30
        {
            width: 190px;
        }
        .style31
        {
            width: 190px;
            height: 26px;
        }
        .style32
        {
            width: 115px;
        }
        .style33
        {
            width: 521px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">
        <ul class="top_nav">
            <li><a>Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a>Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
            </li>
            <li><a href="frmBuildingMaster.aspx">Building Master </a></li>
            <li class="active1"><a href="frmWingMaster.aspx">Wing Master</a></li>
            <li><a href="frmFloorMaster.aspx">Floor Master</a></li>
            <li><a href="frmRoomMaster.aspx">Room Master</a></li>
            <li><a href="frmEquipItemMaster.aspx">Item Master</a></li>
            <li><a href="frmItemTypeMaster.aspx">Item Details Master</a></li>
        </ul>
    </div>
    <section class="content">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" 
                            ActiveTabIndex="0">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <left>
                                        <table style="margin:0 0 0 2%; width: 78%;">
                                                 <tr>
                                                    <td align= "right" class="style2">
                                                        <asp:Label ID="Label4" runat="server" Text="Designation:"></asp:Label>
                                                    </td>
                                                    <td align="left" class="style3">
                                                         <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px" Width="130px"
                                                                onselectedindexchanged="ddlDesignation_SelectedIndexChanged"></asp:DropDownList>


                                                    </td>
                                                    <td align= "right" class="style4">
                                                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Employee"></asp:Label>

                                                    </td>
                                                    <td align="left" class="style32">
                                                        <asp:DropDownList ID="ddlEmployee" Height="38px" Width="130px" runat="server" AutoPostBack="True" onselectedindexchanged="ddlEmployee_SelectedIndexChanged" 
                                                             ></asp:DropDownList>











































                                                    </td>
                                                    <td align="left" class="style5">
                                                        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Month"></asp:Label>












































                                                    </td>
                                                    <td align="left">
                                                       <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px" Width="130px" 
                                                            onselectedindexchanged="ddlmonth_SelectedIndexChanged">
                                                           <asp:ListItem Value="0">--Select---</asp:ListItem>
<asp:ListItem Value="1">January</asp:ListItem>
<asp:ListItem Value="2">February</asp:ListItem>
<asp:ListItem Value="3">March</asp:ListItem>
<asp:ListItem Value="4">April</asp:ListItem>
<asp:ListItem Value="5">May</asp:ListItem>
<asp:ListItem Value="6">June</asp:ListItem>
<asp:ListItem Value="7">July</asp:ListItem>
<asp:ListItem Value="8">August</asp:ListItem>
<asp:ListItem Value="9">September</asp:ListItem>
<asp:ListItem Value="10">October</asp:ListItem>
<asp:ListItem Value="11">November</asp:ListItem>
<asp:ListItem Value="12">December</asp:ListItem>
</asp:DropDownList>













































                                                    </td>
                                                    <td align="left">
                                                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                                </tr> 
                                                <tr>
                                                <td>
                                                        <input class="vclassrooms_send" onclick="PrintDiv1();" type="button" 
                                                        value="Print" /></td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style33">
                                                    &nbsp;</td>
                                                <td align="right" class="style32">
                                                        &nbsp;</td>
                                                  </tr> 
                                                </table>
                                               <table style="margin:0 0 0 2%; width:80%;"> 
                                                   <tr>
                         <td colspan="6" align="center">
                       <asp:Panel ID="Panel50" runat="server" width="90%" GroupingText=" ">
                            <div id="dvContents1" style="border: 1px dotted black; padding: 5px; width:90%">
                                <table>
                                    <tr>
                                  
                                    
                                        <td style="height: 30px;" colspan="6">
                                            <div id="Div2" style="border: 2px solid #333333">
                                                <table style="width: 100%; font-size: x-small;">
                                                    <tr>
                                                        <td style="text-align: left; font-weight: 700; width: 170px;" colspan="1" 
                                                            class="style2" rowspan="2">
                                                            <asp:Image ID="Image2" runat="server" Height="68px"  ImageUrl="~/images/logo.jpg"
                                                                Width="74px" />









































                                                        </td>
                                                        <td style="font-weight: 800; " class="style10" align="center" >
                                                <span style="font-size: x-large; font-family: Arial; height:33px;">vclassrooms India Limited (P) 
                                                            LTD.</span>
                                                <br />
                                                            <asp:Label ID="Label503" runat="server" Text="Address :" Visible="False"></asp:Label>









































                                                <asp:Label ID="Label60" runat="server" 
                                                    Style="font-weight: 700; font-size: small;"></asp:Label>









































                                            </td>
                                                    </tr>
                                                    
                                                     <tr>
                                                        <td style="height: 9px; text-align: center;" colspan="2">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                    
                                                    <tr>
                                                        <td style="text-align: left;   font-size: small; width: 160px;">
                                                            <strong>Month:</strong> <strong>
                                                            <asp:Label ID="lblmonth" runat="server" 
                                                                Text="Label"></asp:Label>









































                                                            </strong>
                                                        </td>
                                                        <td style="text-align: center; font-size: medium; " class="style11">
                                                            <span><span class="ui-priority-primary">
                                                            <asp:Label ID="lblsalaryslip" runat="server" 
                                                                style="font-weight: 700; font-size: small;" Text="SALARY SLIP"></asp:Label>









































                                                            </span></span>
                                                        </td>
                                                        <td style="text-align: center; font-size: small; " align="left">
                                                            <strong>Date:</strong>
                                                            <asp:Label ID="lbldate" runat="server" Text="Label" Width="90px" 
                                                                style="font-weight: 700"></asp:Label>









































                                                        </td>
                                                    </tr>
                                                </table>
                                                <hr />

                                                <table style="width: 100%;  font-size: x-small;">
                                                    <tr class="style3">
                                                 
                                                        <td style="border: 1px solid #000000;  text-align: left; vertical-align: top; "  colspan="1" 
                                                            class="style28">
                                                            <b><span style="font-weight: normal"><span style="font-size: small"><strong>Employee Name: &#160;&#160;<asp:Label 
                                                                ID="lblemployename" runat="server" style="font-size: small;" Text="Label"></asp:Label>
































                                                            &nbsp;&nbsp;&nbsp; </strong></span></span></b>
                                                        </td>
                                                        <td align="left" 
                                                            style="border: 1px solid #000000; vertical-align: top; font-size: small;" 
                                                        colspan="2"  class="style19">
                                                            <strong>
                                                            <asp:Label ID="lbl100" runat="server" Text="Department"></asp:Label>









































                                                            </strong><b>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong>&nbsp;&nbsp;<asp:Label 
                                                                ID="lbldepartment" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            &nbsp;</strong></span></span></b></td>
                                                    </tr>
                                                      <tr class="style3">
                                                          <td class="style28" 
                                                              style="border: 1px solid #000000;  text-align: left; vertical-align: top; "   >
                                                              <b><span style="font-weight: normal"><span style="font-size: small"><strong>Employee Id:&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;<asp:Label 
                                                                  ID="lblemployeid" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                              &nbsp;&nbsp;&nbsp; </strong></span></span></b>
                                                          </td>
                                                          <td align="left" class="style19" colspan="2" 
                                                              style="border: 1px solid #000000; vertical-align: top; font-size: small;">
                                                              <b><strong>
                                                              <asp:Label ID="Label800" runat="server" Text="Designation"></asp:Label>




























                                                              </strong>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong>&nbsp;&nbsp;<asp:Label 
                                                                  ID="lblDesignation" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                              &nbsp;</strong></span></span></b></td>
                                                      </tr>
                                                     
                                                      <tr>
                                                        <td  style="border: 1px solid #000000; text-align:center;   font-size: small; " 
                                                              class="style29">
                                                            <strong>Description</strong> 
                                                        </td>
                                                         <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style27">
                                                            <strong>Earnings</strong> 
                                                        </td>
                                                        <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style30">
                                                            <strong>Deduction</strong> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td  style="border: 1px solid #000000; text-align: left;   font-size: small; " 
                                                              class="style29">
                                                            <strong>Basic:</strong> 
                                                        </td>
                                                        <td class="style27"  
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblbasicamount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                          
                                                            <strong>Hra:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblhraamount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>Conveyance:<b> </b></strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblCONVEYANCEAmount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>Esi:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblEsiAmount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>Loan:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblloanAmount" runat="server" style="font-size: small;" Text="Label"></asp:Label>


































                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>Ptx:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblPtaxAmount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>Tsd:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            &nbsp;</td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblTsdAmount" runat="server" style="font-size: small;" Text="Label"></asp:Label>






































                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style29" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            <strong>
                                                            Total:</strong></td>
                                                        <td class="style27" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lblearningamount" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            </strong></span></span></b></td>
                                                        <td class="style30" 
                                                            style="border: 1px solid #000000; text-align: right;   font-size: small; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small">
                                                            <strong>
                                                            <asp:Label ID="lbltotalAmountdeduction" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            </strong></span></span></b></td>
                                                    </tr>

                                                    <tr class="style3">
                                                 
                                                        <td   align="left" style="border: 1px solid #000000;  vertical-align: top; "  colspan="2" 
                                                            class="style28">
                                                            <b><strong>Bank Name:</strong>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong>&#160;&#160;&#160;&#160;&#160;&#160; 
                                                            <asp:Label 
                                                                ID="Label2" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            &nbsp;&nbsp;&nbsp; </strong></span></span></b>
                                                        </td>
                                                        <td align= "center"
                                                            style="border: 1px solid #000000; vertical-align: top; font-size: small;" 
                                                        colspan="1"  class="style31">
                                                            <strong>
                                                            &#160;<asp:Label ID="Label3" runat="server" Text="Net Pay Amount"></asp:Label>









































                                                            </strong><b>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong>&nbsp;&nbsp;&nbsp;</strong></span></span></b></td>
                                                    </tr>
                                                    <tr class="style3">
                                                        <td class="style28" align="left" colspan="2" 
                                                            style="border: 1px solid #000000;  vertical-align: top; ">
                                                            <b><span style="font-weight: normal"><span style="font-size: small"><strong>Account Holder:
                                                            <asp:Label 
                                                                ID="lblAccountHolder" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            &nbsp;&nbsp;&nbsp; </strong></span></span></b></td>
                                                        <td align="center" class="style31" colspan="1" 
                                                            style="border: 1px solid #000000; vertical-align: top; font-size: small;">
                                                            <b><span style="font-weight: normal"><span style="font-size: small"><strong>
                                                            <asp:Label ID="lblNetPayAmount" runat="server" style="font-size: small;" 
                                                                Text="Label"></asp:Label>




















                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr class="style3">
                                                        <td  align="left" class="style28" colspan="2" 
                                                            style="border: 1px solid #000000;  vertical-align: top; ">
                                                            <b><strong>Account No:</strong>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong>&#160;&#160;&#160;&#160;&#160;&#160;
                                                            <asp:Label ID="Label798" runat="server" style="font-size: small;" Text="Label"></asp:Label>









































                                                            &nbsp;&nbsp;&nbsp; </strong></span></span></b></td>
                                                        <td align="left" class="style31" colspan="1" 
                                                            style="border: 1px solid #000000; vertical-align: top; font-size: small;">
                                                            <b><span style="font-weight: normal"><span style="font-size: small"><strong>
                                                            <asp:Label ID="lblamountinwordnotshow" runat="server" style="font-size: small;" 
                                                                Text="Label"></asp:Label>



















                                                            </strong></span></span></b></td>
                                                    </tr>
                                                    <tr>
                                                          <td class="ui-priority-primary" 
                                                              
                                                              style="border: 1px solid #000000;  height: 22px; text-align: left; font-size: small;" 
                                                              colspan="3"   >
                                                              <span class="style5"><strong>
                                                              RUPEES IN WORD:-</strong></span><b>&nbsp;&nbsp;<span style="font-weight: normal"><span style="font-size: small"><strong><asp:Label 
                                                                  ID="lblwordamount" runat="server" Text="Label"></asp:Label>









































                                                              &nbsp;&nbsp;&nbsp; </strong></span></span></b>
                                                          </td>

                                                      </tr>
                                                      
                                                     
                                                    
                                                      
                                                </table>

                                                <table style="width: 100%; font-size: x-small;">
                                                      
                                                    
                                                   

                                                      <tr>
                                                          <td 
                                                              
                                                              style="height: 20px; font-size: small; font-style: normal;" class="style3" 
                                                              colspan="2">
                                                              &nbsp;</td>
                                                      </tr>
                                                      <tr>
                                                          <td class="style3" colspan="2" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              &nbsp;</td>
                                                      </tr>
                                                      <tr>
                                                          <td class="style3" colspan="2" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              &nbsp;</td>
                                                      </tr>
                                                      <tr>
                                                          <td class="style3" colspan="2" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              <strong>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                              AUTHORIZED SIGNATURE</strong></td>
                                                      </tr>
                                                      <tr>
                                                          <td class="style3" colspan="2" 
                                                              style="height: 19px; text-align: center; ">
                                                              <strong>(This is a Computer generated receipt) </strong>
                                                          </td>
                                                      </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            &nbsp;</asp:Panel>









































                    </td>

</tr>
                                                </table>


                                    </left>
                                    

                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                    New Entry
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <left>
                                        <div class="vclassrooms">
                                            <table width="50%">
                                               
                                            </table>
</div>
                                    </left>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </section>
</asp:Content>
