<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmStudFeeReport.aspx.cs" Inherits="frmStudFeeReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function Print() {
        var dvReport = document.getElementById("dvReport");
        var frame1 = dvReport.getElementsByTagName("iframe")[0];
        if (navigator.appName.indexOf("Internet Explorer") != -1) {
            frame1.name = frame1.id;
            window.frames[frame1.id].focus();
            window.frames[frame1.id].print();
        }
        else {
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.print();
        }
    }
</script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <head >
    <title></title>

</head>
<body>
    <form id="form1" >
   
<input type="button" id="btnPrint" value="Print" CssClass="print-btn" onclick="Print()"
    style="   width: 10% !important;    background: #3498db !important;    border: none !important;    font-size: 16px;    -webkit-border-radius: 5px;
    -moz-border-radius: 5px;    border-radius: 2px;    color: #fff;    margin: 7px 0 7px 30% !important;    padding: 3px;    cursor: pointer;    height: 28px !important;
    float: left;    text-align: center !important;" />
<div class="clearfix"></div>

    <div id="dvReport">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" ToolPanelView="None" DisplayToolbar="False" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        </CR:CrystalReportSource>
       
    </div>    

    </form>
</asp:Content>

