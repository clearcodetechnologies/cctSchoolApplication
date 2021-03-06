<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTopScoresStudent.aspx.cs" Inherits="frmTopScoresStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-family: Verdana;
        }

            .style1 select
            {
                display: block;
                border: 1px solid #3498db;
                width: 100%;
                padding: 5px;
                height: auto !important;
                -webkit-border-radius: 7px;
                -moz-border-radius: 7px;
                border-radius: 0px;
                padding: 6px 0px;
                font-size: 13px;
                text-align: left;
                margin-top: 10px;
                margin-right: 30px;
            }

        .inputf
        {
            width: 140px;
            height: auto;
            padding: 4px;
            border: 1px solid green;
        }

        .inputfCheck
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .selectf
        {
            width: 100px;
            height: auto;
            padding: 4px;
            border: 1px solid #078DB9;
        }

        .search
        {
            border: 1px solid #078DB9 !important;
            padding: 3px;
        }

        .vclassrooms_Submit
        {
            border: none;
            width: 130% !important;
            background: #3498db;
            border: 1px solid #00000;
            font-size: 12px;
            color: #fff;
            margin: 0px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            float: right;
            position: relative;
            left: 10px;
            text-align: center;
        }

        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }

        .td, th
        {
            padding: 0;
            padding-right: 300px;
        }
        .style1 input[type=text] {
            display: block;
            border: 1px solid #3498db;
            width: 70%;
            padding: 5px;
            -webkit-border-radius: 7px;
            -moz-border-radius: 7px;
            border-radius: 0px;
            padding: 6px 0px;
            font-size: 13px;
            text-align: left;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header1 pd-0">
       
        <ul class="top_navlg rpt_center">
        <li><a >Report Center <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>     
       
            <li> <a href="frmAdmListStudentDetails.aspx"> Student Details </a></li>
            
                  <li><a href="frmStandardWiseRpt.aspx"> Student Fee Collection</a></li>
                  <li><a href="frmRPTFeecollectionInDate.aspx">Date Wise Collection</a></li>   
                  <li><a href="frmHeadwiseFeeRpt.aspx"> Head Wise Collection</a></li>
                  <li><a href="frmStudentAttendance.aspx">Student Attendance</a></li>
                  <li><a href="frpRptStdWise.aspx"> Standard wise Fee Collection</a></li>
                  <li><a href="frmFeePaidTillDate.aspx"> Fee Collection Till Summary</a></li>
                  <li><a href="frmAbsentSummary.aspx"> Student Attendance Summary</a></li>
                  <li><a href="frmAttendanceSummary.aspx"> Staff Attendance Summary</a></li>                  
                  <li><a href="frmGenderwiseAttendence.aspx"> Gender Wise Abscent Summary</a></li>
                  <li class="active1"><a href="frmTopScoresStudent.aspx"> Top 10 Scores Student</a></li>
                    <li><a href="TeacherWiseTimeTable.aspx"> Teacher Wise Time Table</a></li>                  
                      <li><a href="StudentWiseTimeTable.aspx"> Student Wise Time Table </a></li>                  
        </ul>
    </div>
<section class="content">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <table>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" ActiveTabIndex="0"
                                Width="850px" Visible="false">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>Top Scores</HeaderTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"
                                    Visible="False">
                                </asp:TabPanel>
                            </asp:TabContainer>
                            <table class="style1">
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" style="padding-right: 30px;">
                                            <tr>                                                
                                                <td valign="middle" align="center" style="width:12%">
                                                        <asp:Label ID="lblSTD" runat="server" Text="STD" CssClass="textsize" style="padding-left: 20px;"></asp:Label>
                                                    </td>
                                                     <td style="width:27%">
                                                        <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" Style="padding-right: 30px;"
                                                            CssClass="textsize" onselectedindexchanged="ddlSTD_SelectedIndexChanged" >
                                                        </asp:DropDownList>
                                                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:GridView ID="grdScores" runat="server" AutoGenerateColumns="False" DataKeyNames="intstudent_id"
                                            CssClass="table  tabular-table " EmptyDataText="No Data Found" 
                                            Width="100%" onrowdatabound="grdScores_RowDataBound">
                                            <Columns> 
                                         
                                                                                                                                      
                                                <asp:TemplateField HeaderText="Student Name">
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>   
                                                 <asp:TemplateField HeaderText="Division">
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Obtained">
                                                    <ItemTemplate> 
                                                        <asp:LinkButton ID="lnkObtained" runat="server"  CommandName="Delete" Text='<%#Eval("Obtained") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                                                    </ItemTemplate>
                                              </asp:TemplateField>  
                                                     <%-- <asp:TemplateField HeaderText="View" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentId" runat="server" Text='<%#Eval("intstudent_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                               
                                                                                         
                                                <%--<asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkScores" runat="server" CommandName="Delete" Text='<%#Eval("Count") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField> --%>                                               
                                            </Columns>
                                        </asp:GridView>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                                            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                </table>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</section>
</asp:Content>

