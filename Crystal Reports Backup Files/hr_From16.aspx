<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="hr_From16.aspx.cs" Inherits="hr_From16" %>

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
            frameDoc.document.write('<html><head><title>.</title>');
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
        .style19
        {
            width: 275px;
            height: 26px;
        }
        .style27
        {
            width: 26%;
        }
        .style30
        {
            width: 190px;
        }
        .style32
        {
            width: 115px;
        }
        .style33
        {
            width: 521px;
        }
        .style34
        {
            height: 26px;
        }
        .style35
        {
            width: 440px;
        }
        .style37
        {
            width: 190px;
            font-weight: bold;
        }
        .style39
        {
            width: 26%;
            font-weight: bold;
        }
        .style40
        {
        }
        .style41
        {
            width: 440px;
            font-weight: bold;
        }
        .style42
        {
            width: 320px;
            font-weight: bold;
        }
        .style43
        {
            height: 26px;
            width: 320px;
        }
        .style52
        {
            height: 32px;
            font-size: medium;
        }
        .style53
        {
            font-size: xx-small;
        }
        .style63
        {
        }
        .style64
        {
        }
        .style69
        {
            height: 26px;
        }
        .style70
        {
            height: 26px;
            width: 33px;
        }
        .style71
        {
            width: 33px;
        }
        .style74
        {
        }
        .style77
        {
            width: 116px;
        }
        .style78
        {
            width: 58px;
        }
        .style79
        {
            height: 26px;
            width: 58px;
        }
        .style82
        {
            height: 26px;
            width: 15px;
        }
        .style83
        {
            height: 26px;
            width: 29px;
        }
        .style89
        {
            width: 32px;
        }
        .style91
        {
            width: 75px;
        }
        .MyTabStyle
        {
        }
        .style93
        {
            height: 26px;
            width: 258px;
        }
        .style94
        {
            height: 45px;
            width: 15px;
        }
        .style95
        {
            height: 45px;
            width: 29px;
        }
        .style96
        {
            height: 45px;
        }
        .style97
        {
            height: 26px;
            font-weight: bold;
        }
        .style98
        {
            height: 26px;
            width: 258px;
            font-weight: bold;
        }
        .style99
        {
            height: 26px;
            width: 320px;
            font-weight: bold;
        }
        .style100
        {
            width: 75px;
            font-weight: bold;
        }
        .style101
        {
            width: 85px;
            font-weight: bold;
        }
        .style102
        {
            width: 116px;
            font-weight: bold;
        }
        .style103
        {
            width: 58px;
            font-weight: bold;
        }
        .style104
        {
            height: 26px;
            width: 258px;
            font-size: small;
        }
        .style105
        {
            font-size: small;
        }
        .style106
        {
            height: 32px;
            font-size: small;
        }
        .style107
        {
            height: 26px;
            font-size: small;
        }
        .style108
        {
            font-size: x-small;
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
                            ActiveTabIndex="0" Width="100%">
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
                                                        &nbsp;&nbsp;&nbsp;</td>
                                                    <td align="left">
                                                        &nbsp;</td>
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


                                                



                                              <table style="margin:0 0 0 2%; width:100%;"> 
                                                   <tr>
                         <td colspan="8" align="center">
                       
<asp:Panel ID="Panel50" runat="server" width="65%" GroupingText=" ">
                  <div id="dvContents1"  style="padding: 5px;  width:100%">

                                          <table style="width: 100%; font-size: x-small;">
                                                    <tr align="center">
                                                          <td 
                                                              
                                                              style="height: 20px; font-style: normal;" class="style52">
                                                              <strong>FORM NO.16</strong></td>
                                                      </tr>
                                                      <tr align="center">
                                                          <td class="style3" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              [ See rule 31(l )(a) ]</td>
                                                      </tr>
                                                      <tr align="center">
                                                          <td class="style3" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              <strong>PART A</strong></td>
                                                      </tr>
                                                      <tr>
                                                          <td class="style3" 
                                                              style="height: 20px;  font-style: normal; font-size: small;">
                                                              <strong>
                                                              &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                              <span class="style53">
                                                              &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </span> 
                                                              <span class="style108">Certificate under section 203 
                                                              ofthe Income Tax Act. 1961 for Tax deducted at source on Salary</span> 
                                                              &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;</strong></td>
                                                      </tr>
                                                      
                                                    
                                                    
                                                    
                                                    
                                                    
                                                </table>
                                         <table>
                                    <tr>
                                  
                                    
                                        <td style="height: 30px;" colspan="6">
                                            <div id="Div2" style="border: 2px solid #333333;">

                                           
                                               
                                                <table style="width:100%;  font-size: x-small;">
                                            
                                                   
                                                     <tr class="style3">
                                                          <td class="style40" 
                                                              
                                                              
                                                             style="border: 1px solid #000000;  text-align: left; vertical-align: top; "   >
                                                              <b><span style="font-weight: normal">
                                                              <span style="font-size: small">
                                                              <strong>Name & address of Employer</strong></span></span></b></td>
                                                          <td align="left" class="style19" colspan="3" 
                                                              style="border: 1px solid #000000; vertical-align: top; font-size: small;">
                                                              <b>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; &#160;<span style="font-weight: normal"><span style="font-size: small"><strong>Name &amp; designation of Employer</strong></span></span></b></td>
                                                      </tr>
                                                      <tr class="style3">
                                                          <td class="style40" 
                                                              
                                                              
                                                              style="border: 1px solid #000000;  text-align: left; vertical-align: top; "   >
                                                              <b><span style="font-weight: normal"><span style="font-size: small">
                                                              <strong>&#160;&#160;&#160; XXXXXXXXXXX</strong></span></span></b></td>
                                                          <td align="center" class="style19" colspan="3" 
                                                              style="border: 1px solid #000000; vertical-align: top; font-size: small;">
                                                              <asp:Label ID="lblemployename" runat="server" style="font-weight: 700" Text="Label"></asp:Label>












                                                          </td>
                                                      </tr>
                                                     
                                                      <tr>
                                                        <td  style="border: 1px solid #000000; text-align:center;   font-size: small; " 
                                                              class="style35">
                                                            PAN OF DEDCTUR</td>
                                                         <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style27">
                                                             TAN OF DEDCUTER</td>
                                                        <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style30" colspan="2">
                                                            PAN OF EMPLOYER</td>
                                                    </tr>
                                                     <tr>
                                                        <td  style="border: 1px solid #000000; text-align:center;   font-size: small; " 
                                                              class="style41">
                                                            <strong>ABCD1234</strong></td>
                                                         <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style27">
                                                             <strong>MUB2345</strong></td>
                                                        <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style30" colspan="2">
                                                            <strong>AAAAAA5678</strong></td>
                                                    </tr>
                                                     <tr>
                                                        <td  style="border: 1px solid #000000; text-align:center;   font-size: small; " 
                                                              class="style41">
                                                            CIT(TDS)</td>
                                                         <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style39">
                                                             ASSEMENT YEAR</td>
                                                        <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style37" colspan="2">
                                                            PER</td>
                                                    </tr>
                                                     <tr>
                                                        <td  style="border: 1px solid #000000; text-align:left;   font-size: small; " 
                                                              class="style41">
                                                            The Comissioner of IncomeTax (TDS) 4rth, Floor, A Wing, PMT Commercial Complex,Shanker Sheth Road, Swargate,</td>
                                                         <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style39" rowspan="3">
                                                             FINAL ASSISMENT</td>
                                                        <td  style="border: 1px solid #000000; text-align:center;    font-size: small; " 
                                                              class="style42" rowspan="2">
                                                            FROM</td>
                                                         <td class="style37" rowspan="2" 
                                                             
                                                             style="border: 1px solid #000000; text-align:center;    font-size: small; ">
                                                             TO</td>
                                                    </tr>
                                                     <tr>
                                                         <td  style="border: 1px solid #000000; text-align:center;   font-size: small; " 
                                                              class="style41">
                                                             &#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style41" 
                                                            style="border: 1px solid #000000; text-align: left;   font-size: small; ">
                                                            CITY: PUNE ,PINCODE:411037</td>
                                                        <td class="style42" 
                                                            
                                                            
                                                            style="border: 1px solid #000000; text-align:center;    font-size: small; ">
                                                            01-04-2016</td>
                                                        <td class="style37" 
                                                            
                                                            style="border: 1px solid #000000; text-align:center;    font-size: small; ">
                                                            31-03-2017</td>
                                                    </tr>
                                                    
                                                       <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; "  colspan="4" 
                                                            class="style34">
                                                            <strong>Summary of tax deducted at source</strong></td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                            class="style40">
                                                            <strong>Quater</strong></td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                             <strong>Receipt Numbers of original statements of TDS 
                                                             under sub-section (3) of section 200</strong></td>
                                                         <td class="style43" 
                                                             
                                                             style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                             <strong>Amount of tax deducted in respect of the 
                                                             employee1</strong></td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                             <strong>Amount of tax deposited / remitted in respect of 
                                                             the &apos;employee</strong></td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                            class="style40">
                                                            First</td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             &#160;</td>
                                                         <td class="style99" 
                                                             
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00</td>
                                                         <td class="style97" 
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                         <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                            class="style40">
                                                            Second</td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             &#160;</td>
                                                         <td class="style99" 
                                                             
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                         <td class="style97" 
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                            class="style40">
                                                            Third</td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             &#160;</td>
                                                         <td class="style99" 
                                                             
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                         <td class="style97" 
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  text-align:  left; vertical-align: top; " 
                                                            class="style40">
                                                            Fourth</td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             &#160;</td>
                                                         <td class="style99" 
                                                             
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                         <td class="style97" 
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                    </tr>
                                                     <tr class="style3">
                                                 
                                                        <td 
                                                            
                                                            style="border: 1px solid #000000;  vertical-align: top; " 
                                                            class="text-center">
                                                            <strong>Total </strong>
                                                            <br />
                                                         </td>
                                                         <td class="style34" 
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             &#160;</td>
                                                         <td class="style99" 
                                                             
                                                             
                                                             style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                             0.00 </td>
                                                         <td class="style97" 
                                                             
                                                             style="border: 1px solid #000000;  text-align:  right; vertical-align: top; ">
                                                             0.00 </td>
                                                    </tr>
                                                     
                                                    
                                                      
                                                </table>

                                                
                                            </div>
                                        </td>
                                    </tr>
                                </table>


                               <br />
                               


                                <table style="width: 100%;  font-size: x-small;">
                                                    <tr align="center">
                                                          
                                                              
                                                              <td class="style3" 
                                                              style="height: 5px;  font-style: normal; font-size: small;">
                                                              <strong>PART B (Refer Note 1)</strong></td>
                                                      </tr>
                                                    
                                                </table>

                              

                              <div id="Div1" style="border: 2px solid #333333;">
                                                 <table style="width:100%; border:1px solid #000000;   font-size: x-small;">
                                            
                                                                  <tr class="style3">
                                                                      <td class="style40" 
                                                                          
                                                                         style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="7">
                                                                          <b><span style="font-weight: normal"><span style="font-size: small">
                                                                          <strong>&#160;&#160;&#160;</strong><center><strong>DETAILS OF SALARY PAID 
                                                                              AND ANY OTTiER INCOME AND TAX DEDUCTED</strong></center></span></span></b></td>
                                                                      
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><span style="font-weight: normal"><span style="font-size: small">
                                                                          <strong>&#160;&#160;&#160;</strong></span></span></b></td>
                                                                      
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          &#160;</td>
                                                                      <td class="style101" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      <td class="style100" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      <td class="style100" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><span style="font-weight: normal"><span style="font-size: small">
                                                                          <strong>&#160;&#160;&#160;</strong><center>1</center></span></span></b></td>
                                                                      
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Grosss Salary</td>
                                                                      <td class="style101" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: bottom; " 
                                                                          rowspan="2">
                                                                          <asp:Label ID="lblsalaeryprovision" runat="server" Text="Label"></asp:Label>
























































                                                                          </td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; " 
                                                                          rowspan="5">
                                                                          <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>


















































                                                                      </td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; " 
                                                                          rowspan="15">
                                                                          <asp:Label ID="lblIncomechargeable" runat="server" Text="Label"></asp:Label>
















































                                                                          </td>
                                                                      
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (a)</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Salary as per provisions contained in sec. I 7 ( 1 )</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (b)</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Value of perquisites u/s l7(2) (as per Form No. l2BA wherever applicable)</td>
                                                                      <td class="style101" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          rowspan="18">
                                                                          &#160;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (c)</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Profits in lieu of salary under section l7(3) (as per Form No. l2BA&quot; wherever 
                                                                          applicable</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style94" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          </td>
                                                                      <td class="style95" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (d)</td>
                                                                      <td class="style96" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Total</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          2</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          less: Allowance to thc extent exempt uncler section l0</td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; " 
                                                                          rowspan="4">
                                                                          <asp:Label ID="Label10" runat="server" Text="0.00"></asp:Label>

















































                                                                      </td>
                                                                  </tr>

                                                                    <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                            
                                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                            
                                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                            style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Allowance</td>
                                                                        <td class="style89" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                            Rs</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                      </td>
                                                                      <td class="style89" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                      </td>
                                                                      <td class="style89" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          3</td>
                                                                      <td class="style83" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Balance(1-2)</td>
                                                                      <td class="style100" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="lablBalance12" runat="server" Text="Label"></asp:Label>

























































                                                                          </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          4</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Deductions:</td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; " 
                                                                          rowspan="4">
                                                                          <asp:Label ID="lblAggregate" runat="server" Text="Label"></asp:Label>



















































                                                                          </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (a)</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: Left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Entertainment Allowance&#160;&#160;&#160; &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Rs&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
                                                                          <asp:Label ID="Label1" runat="server" Text="0.00" style="font-weight: 700"></asp:Label>










































































</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Tax on Employe&#160;&#160;&#160; &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Rs&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
                                                                          <asp:Label ID="lbltax" runat="server" Text="Label" style="font-weight: 700"></asp:Label>








































































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          5<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>

























































                                                                      </td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          </td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Aggregate of 4 (a) and (b) </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          6</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Income chargeable urnder the head &apos;Salaries&apos; (3 - 5) </td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          rowspan="6">
                                                                          &#160;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          7</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style40" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Add. Any other income reported by the employee </td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; " 
                                                                          rowspan="4">
                                                                          <asp:Label ID="Label14" runat="server" Text="0.00"></asp:Label>















































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style63" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          &#160;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style63" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          &#160;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style63" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          &#160;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style82" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          8</td>
                                                                      <td class="style83" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style63" 
                                                                          
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="2">
                                                                          Grand Total(6+7)</td>
                                                                      <td class="style91" 
                                                                          
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="lblGrandTotal" runat="server" Text="Label" 
                                                                              style="font-weight: 700"></asp:Label>













































                                                                          <br />
                                                                      </td>
                                                                  </tr>
                                                     
                                                              </table>
                                                              </div>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
                                                              <br />
                                                              <div id="Div3" style="border: 2px solid #333333;">
                      <table style="width:100%; border:1px solid #000000;  font-size: x-small;">
                                            
                                                   
                                                     
                                                                  <tr class="style3">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><span style="font-weight: normal"><span style="font-size: small"><strong>&nbsp;&nbsp;&nbsp;</strong></span></span></b></td>
                                                                      
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &#160;</td>
                                                                      <td class="style103" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      <td class="style100" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      <td class="style102" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          Rs.</td>
                                                                      
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style107" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><span style="font-weight: normal"><span style="font-size: small"><strong>&nbsp;&nbsp;&nbsp;</strong><center>9</center></span></span></b></td>
                                                                      
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          </td>
                                                                      <td class="style105" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Deductions under Chapter VIA</span></td>
                                                                      <td class="style64" colspan="3" rowspan="2" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: bottom; ">
                                                                          


















                                                                          </td>
                                                                      
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style107" rowspan="2" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" rowspan="2" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <span class="style105">(A)</span></td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Sections 80C. 80CCC and 80CCD</span></td>
                                                                      </span></span>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style105" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: bottom; ">
                                                                          <span class="style105">Gross Amount</span></td>
                                                                      </span>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: bottom; ">
                                                                          Deductible Amount</span></td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (a)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          section 80Cl </td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (i)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label28" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label29" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label31" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (ii)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label16" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label30" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label32" runat="server" Text="0.00"></asp:Label>




































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (iii)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style64" colspan="3" rowspan="2" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                  </tr>

                                                                    <tr class="style106">
                                                                      <td class="style69" rowspan="3" 
                                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" rowspan="2" 
                                                                            style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (iv)</td>
                                                                      <td class="style74" 
                                                                            style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label33" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label34" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label35" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">(b)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          section 80CCC</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style69" rowspan="2" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          </td>
                                                                      <td class="style71" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <span class="style105">(c)</span></td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          section 80CCD<br />(Note: Not exceeding Rs.One Lakh 
                                                                          Fifty Thousand only)</td>
                                                                  
                                                                      </span>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style71" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (B)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Other Sections under Chapter VIA (for e.g 80E, BOG etc. )</td>
                                                                      <td class="style79" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Gross Amount</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Qualifying Amount </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: bottom; ">
                                                                          Deductib le Amount 0</td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (a)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label36" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label20" runat="server" Text="0.00"></asp:Label>



















































                                                                          </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label37" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          (b)</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: Left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          10</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Aggregate of deductible amounts under Chapter VI-A</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label38" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label39" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label40" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          11</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          </td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Total Income ( 8 - l0 )</td>
                                                                      <td class="style78" rowspan="8" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" rowspan="8" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          &nbsp;</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="lblTotalIncome" runat="server" Text="Label" 
                                                                              style="font-weight: 700"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          12</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Tax on Total lncome </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="lblTaxTotallncome" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          13</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Education Cess @ 3o/o (on tax computed at S.No. 12)</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label24" runat="server" Text="0.00"></asp:Label>















































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          14</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Tax Payable ( l2+13) </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label43" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          15</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: LEFT; vertical-align: top; ">
                                                                          Relief urnder section 89 (attach cletails) </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label44" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          16</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: LEFT; vertical-align: top; ">
                                                                          Tax Pavable ( 14 - I5) </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: bottom; ">
                                                                          <asp:Label ID="Label45" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          17</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Tax Dedr-rcted At Sourrce u/s 192</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label25" runat="server" Text="0.00"></asp:Label>













































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          18</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          Balance(16-l7)
                                                                      </td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <asp:Label ID="Label46" runat="server" Text="0.00"></asp:Label>



































                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                  </tr>

                                                                   <tr class="style106">
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style70" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style78" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style91" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                      <td class="style77" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          &nbsp;</td>
                                                                  </tr>

                                                                  <tr class="style3">
                                                                      <td class="style69" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; " 
                                                                          colspan="2">
                                                                          &nbsp;</td>
                                                                      <td class="style74" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; " 
                                                                          colspan="4">
                                                                          &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Verification<br /> I,_______________, son / daugh+er 
                                                                          of&#160;&#160; ________________ working in the capacity of ________________________________(in 
                                                                          words I has been deducted and deposited to the credit of the Central Government. I further certi! that the information given above is true, complete and correct and is based on the books ofaccount, documents, TDS statement, TDS deposited and other available records.
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          <br />
                                                                          &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                                                          Signature of the person responsible for Place: Navi 
                                                                          Mumbai&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;deduction of 
                                                                          tax
                                                                          <br />
                                                                          Date: 05-06-2018<br /> Designation : DIRECTOR 
                                                                          &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;Full Name : SANJAY AGRAWAL
</td>
                                                                  </tr>

                                                              </table>
 </div>

 
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />
 <br />

   <div id="Div4" style="border: 2px solid #333333;">
                      <table style="width:100%; border:1px solid #000000;  font-size: x-small;">
                                            
                                                   
                                                     
                                                                  <tr class="style3">
                                                                      <td class="style104" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Month</strong></b></td>
                                                                      
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Salary</strong></b></td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Others</strong></b></td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Total</strong></b></td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Prof Tax</strong></b></td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Net</strong></b></td>
                                                                      
                                                                  </tr>
                                                                  
                                                                  
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          April</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label56" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label57" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label58" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label59" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label60" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          May</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label62" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label63" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label64" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label65" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label66" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          June</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label68" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label69" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label70" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label71" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label72" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          July</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label74" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label75" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label76" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label77" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label78" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          August</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label80" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label81" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label82" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label83" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label84" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          September</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label86" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label87" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label88" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label89" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label90" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          October</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label92" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label93" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label94" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label95" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label96" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          November</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label104" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label105" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label106" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label107" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label108" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style98" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          December</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label110" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label111" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label112" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label113" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label114" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td class="style98" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          January</td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label18" runat="server" Text="0"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label103" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td class="style98" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          February</td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label26" runat="server" Text="0"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label47" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label48" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                  </tr>
                                                                  <tr>
                                                                      <td class="style98" 
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                          March</td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label50" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label51" runat="server" Text="0"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label52" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label53" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                      <td class="style97" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label54" runat="server" Text="Label"></asp:Label>





                                                                      </td>
                                                                  </tr>
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: left; vertical-align: top; ">
                                                                         


</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label99" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label100" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label101" runat="server" Text="Label"></asp:Label>















</td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                          <asp:Label ID="Label102" runat="server" Text="Label"></asp:Label>














                                                                          </td>
                                                                      <td class="style97" 
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label133" runat="server" Text="Label"></asp:Label>















</td>
                                                                  </tr>
                                                                  
                                                                  
                                                                  
                                                              </table>

                                                     




 </div>

 


  <br />
 <br />

 <table style="width: 100%;  font-size: x-small;">
                                                    <tr align="left">
                                                          
                                                              
                                                              <td class="style3" 
                                                              style="height: 5px;  font-style: normal; font-size: small;">
                                                              <strong> ADD:- Other pavments during the Gross year
 </strong></td>
                                                      </tr>
                                                    
                                                </table>

 <br />
 
 <div id="Div5" style="border: 2px solid #333333;">
                      <table style="width:100%; border:1px solid #000000;  font-size: x-small;">
                                            
                                                   
                                                     
                                                                  <tr class="style3">
                                                                      <td class="style104" 
                                                                          
                                                                          
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                          <b><strong>Gross</strong></b></td>
                                                                      
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                           <b><strong>
                                                                           <span class="style105">Ded.</span></strong></b><span class="style105"></span></td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: center; vertical-align: top; ">
                                                                           </span><b>
                                                                           <strong>
                                                                           <span class="style105">Net</span></strong></b></td>
                                                                      
                                                                      
                                                                      </span></span>
                                                                      </span></span>
                                                                      
                                                                      
                                                                  </tr>
                                                                  
                                                                  
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                         <asp:Label ID="Label115" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label116" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label117" runat="server" Text="0"></asp:Label>















</td>
                                                                                                                                       </tr>
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                         <asp:Label ID="Label118" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label119" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label120" runat="server" Text="0"></asp:Label>















</td>
                                                                                                                                       </tr>
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                         <asp:Label ID="Label121" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label122" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label123" runat="server" Text="0"></asp:Label>















</td>
                                                                                                                                       </tr>
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                         <asp:Label ID="Label124" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label125" runat="server" Text="0"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label126" runat="server" Text="0"></asp:Label>















</td>
                                                                                                                                       </tr>
                                                                  <tr class="style3">
                                                                      <td class="style93" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                         <asp:Label ID="Label134" runat="server" Text="Label" style="font-weight: 700"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label135" runat="server" Text="Label" style="font-weight: 700"></asp:Label>















</td>
                                                                      <td class="style69" 
                                                                          style="border: 1px solid #000000;  text-align: right; vertical-align: top; ">
                                                                           <asp:Label ID="Label136" runat="server" Text="Label" style="font-weight: 700"></asp:Label>















</td>
                                                                                                                                       </tr>
                                                                 
                                                                  
                                                                  
                                                              </table>

                                                     




 </div>





</div>
                                
                             </asp:Panel>































                             

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
