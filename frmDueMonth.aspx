<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmDueMonth.aspx.cs" Inherits="frmDueMonth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <center>
            <asp:GridView ID="grdDet" runat="server" CssClass="table  tabular-table " EmptyDataText="No Details Available"
                Width="50%">
            </asp:GridView>
        </center>
    </div>
</asp:Content>

