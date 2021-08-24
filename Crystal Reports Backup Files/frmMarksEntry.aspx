﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-Gb" EnableViewState="true" CodeFile="frmMarksEntry.aspx.cs" Inherits="frmMarksEntry"
    Title="VClassrooms - Student attendance management system, Fees management, School bus tracking, Exam schedule, time table management" %>

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
    <script type="text/javascript">
        function forNumeric1(evt) {
            var charCode = evt.keyCode;
            var target = event.target || event.srcElement;
            var id = target.id
            var value = document.getElementById(id).value;

            var MaxMark = document.getElementById('<%=SubMaxMarks.ClientID %>').value;
            value = value + String.fromCharCode(evt.keyCode);

            if (charCode >= 48 && charCode <= 57) {
                if (Number(value) > Number(MaxMark)) {
                    alert('Marks Should Less Than ' + MaxMark);
                    value = 0;
                    return false;
                }
                return true;
            }


            return false;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="content-header pd-0">
       
        <ul class="top_nav1 sp">
        <li><a >Study <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>                  
             <li><a href="frmTeacherTimeTable.aspx">Time Table</a></li>
            <li><a href="frmExaminationSchedule.aspx">Examination</a></li>
            <li><a href="frmSyllabusMst.aspx">Syllabus</a></li>
            <li class="active1"><a href="frmMarksEntry.aspx">Marks Entry</a></li>            
            <li><a href="Result.aspx">Result</a></li>  
                               
        </ul>
    </div>
<section class="content">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TabContainer runat="server" ActiveTabIndex="0" CssClass="MyTabStyle" ID="MainTab"
                    Width="100%">
                     <asp:TabPanel runat="server" ID="tb2" HeaderText="All Entries">
                        <ContentTemplate>
                            <center>
                                <br />
                                <div class="vclassrooms">
                                    <table width="60%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="padding-left: 2px" width="25x">
                                                            <asp:Label ID="lblSTD1" runat="server" Text="Standard"></asp:Label>
                                                        </td>
                                                        <td width="25x" align="center" style="padding-left: 18px">
                                                            <asp:DropDownList ID="ddlSTD1" runat="server" Style="width: 100px !important" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlSTD1_SelectedIndexChanged">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left" width="25x">
                                                            <asp:Label ID="lblDIV1" runat="server" Text="Division"></asp:Label>
                                                        </td>
                                                        <td width="25x" style="padding-left: -10px">
                                                            <asp:DropDownList ID="ddlDIV1" runat="server" Style="width: 100px !important" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlDiv1_SelectedIndexChanged">
                                                                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td id="trStudent" runat="server" visible="False">
                                                            <asp:Label ID="lblStudentName" runat="server" Text="Student Name" Visible="False"></asp:Label>
                                                        </td>
                                                        <td width="73%" colspan="3">
                                                            <asp:DropDownList ID="ddlStud" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"
                                                                Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text="Exam Type"></asp:Label>
                                                        </td>
                                                        <td width="73%" colspan="3">
                                                            <asp:DropDownList ID="drpExamType" runat="server" AutoPostBack="True" 
                                                                onselectedindexchanged="drpExamType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text="Examination"></asp:Label>
                                                        </td>
                                                        <td width="73%" colspan="3">
                                                            <asp:DropDownList ID="ddlExam1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left" style="padding-top: 12px;">
                                                            <asp:Label ID="Label9" runat="server" Text="Declare Date-Time" Width="100%"></asp:Label>
                                                        </td>
                                                        <td valign="top" align="left">
                                                            <asp:TextBox ID="txtDate" runat="server" CssClass="input-blue" AutoPostBack="True"></asp:TextBox>
                                                            <asp:CalendarExtender ID="calDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate"
                                                                Enabled="True">
                                                            </asp:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Enter Date For Result Declaration"
                                                                Display="None" ControlToValidate="txtDate" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RequiredFieldValidator10"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                            <asp:HiddenField ID="SubMaxMarks" runat="server" Value="0" />
                                                        </td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtTime" CssClass="input-blue" runat="server"></asp:TextBox>
                                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"
                                                                AutoCompleteValue="00:00" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTime">
                                                            </asp:MaskedEditExtender>
                                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" Display="None" ControlToValidate="txtTime"
                                                                ControlExtender="MaskedEditExtender1" InvalidValueMessage="Please enter a valid time."
                                                                EmptyValueMessage="Please Enter Valid Time" SetFocusOnError="True" ErrorMessage="Please Enter Valid Time"
                                                                runat="server" CssClass="textsize"></asp:MaskedEditValidator>
                                                            <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender4" TargetControlID="MaskedEditValidator1"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Time For Result Declaration"
                                                                Display="None" ControlToValidate="txtTime" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                        </td>
                                                        <td width="30%">
                                                            &nbsp
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="div2" runat="server" style="overflow: scroll; height: 280px;">
                                        <asp:GridView ID="grvMarks" runat="server" AutoGenerateColumns="False" CssClass="table  tabular-table "
                                            EnableViewState="False" OnRowDataBound="grvMarks_RowDataBound" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Roll No.">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStudentId" Text='<%#Eval("intStudent_id") %>'></asp:Label></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Justify" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sub1">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub1" EnableViewState="false" CssClass="groupOfTexbox" onkeypress="return forNumeric(event)"
                                                            runat="server" Width="60%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub2">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub2" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub3">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub3" CssClass="unwatermarked" runat="server" onkeypress="return forNumeric(event)"
                                                            Width="60%"></asp:TextBox>
                                                        <%--<asp:textboxwatermarkextender id="TextBoxWatermarkExtender1" WatermarkCssClass="watermarked" runat="server" targetcontrolid="txtSub3"
                                                            watermarktext="80">
                                                        </asp:textboxwatermarkextender>--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub4">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub4" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub5">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub5" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub6">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub6" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub7">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub7" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub8">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub8" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub9">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub9" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub10">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub10" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub11">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub11" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub12">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSub12" runat="server" onkeypress="return forNumeric(event)" Width="60%"></asp:TextBox></ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <table width="28%">
                                        <tr>
                                            <td width="50%" align="right">
                                                <asp:Button ID="btnSubmit1" runat="server" CssClass="vclassrooms_send" Text="Submit"
                                                    Visible="False" OnClick="btnSubmit1_Click" />
                                            </td>
                                            <td width="50%" align="right">
                                                <asp:Button ID="btnClear1" CssClass="vclassrooms_send" runat="server" Text="Clear"
                                                    Visible="False" OnClick="btnClear1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="View Details" Visible="false">
                        <ContentTemplate>
                            <div class="vclassrooms">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                             <iframe id="frame1" style="border:none;height:576px; width:100%" src="ResultStudent.aspx" scrolling="auto" runat="server" ></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel runat="server" ID="tb3" HeaderText="View Details" Visible="false">
                        <ContentTemplate>
                            <div class="vclassrooms">
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <table width="50%">
                                                <tr>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblSTD2" runat="server" Text="STD"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlSTD2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblDIV2" runat="server" Text="DIV"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlDIV2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDIV2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="lblStud" runat="server" Text="Student Name"></asp:Label></div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlStudent2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div style="width: 360px; margin: 0 auto;">
                                                            <div style="width: 115px; float: left;">
                                                                <asp:Label ID="Label8" runat="server" Style="padding-right: 0 !important; margin-right: 0 !important;"
                                                                    Text="Examination"></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:DropDownList ID="ddlExam2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td align="left" style="padding-right: 20px">
                                                        <asp:Label ID="lblGetName" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td colspan="2" align="right">
                                                        <asp:LinkButton ID="btnView" runat="server" OnClick="btnView_Click" Visible="False">View</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div id="divMarksHeader" runat="server">
                                                        </div>
                                                        <div id="divMarks" runat="server" style="overflow: none; height: 300px">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                   
                    <asp:TabPanel runat="server" Visible="false" ID="tbl1" HeaderText="Entry">
                        <ContentTemplate>
                            <center>
                                <br />
                                <div class="vclassrooms">
                                    <table width="50%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="padding-left: 2px">
                                                            <asp:Label ID="lblStd" runat="server" Text="STD"></asp:Label>
                                                        </td>
                                                        <td style="padding-left: 16px">
                                                            <asp:DropDownList ID="ddlSTD" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="padding-left: 25px">
                                                            <asp:Label ID="lblDIV" runat="server" Text="DIV"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDiv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblStudent" runat="server" Text="Student Name"></asp:Label>
                                                        </td>
                                                        <td width="73%">
                                                            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblExam" runat="server" Text="Examination"></asp:Label>
                                                        </td>
                                                        <td width="73%">
                                                            <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                        <td width="73%">
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divTable" class="vclassrooms" runat="server">
                                    </div>
                                    <table width="28%">
                                        <tr>
                                            <td width="50%" align="right">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" Text="Submit"
                                                    Visible="False" />
                                            </td>
                                            <td width="50%" align="right">
                                                <asp:Button ID="btnClear" CssClass="vclassrooms_send" runat="server" Text="Clear"
                                                    Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</section>
</asp:Content>
