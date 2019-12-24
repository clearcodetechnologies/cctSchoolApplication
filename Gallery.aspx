<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table img
        {
            height: 150px;
            width: 150px;
            cursor: pointer;
        }
        #dialog img
        {
            height: 550px;
            width: 575px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Label ID="lblImage" runat="server" Text="EVENT"></asp:Label>
    <asp:TextBox ID="txtEvent" runat="server"></asp:TextBox>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
    <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
    <hr />
      <asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Image Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
             <asp:BoundField DataField="EventDescription" HeaderText="DESCRIPTION" />
            <asp:ImageField DataImageUrlField="Path" HeaderText="Image" />
            
        </Columns>
    </asp:GridView>
   <%-- <asp:GridView runat="server" Width="100%" ID="GridView1" ShowFooter="False" AllowPaging="True"
        AutoGenerateColumns="False" DataKeyNames="ID" PageSize="25">
        <AlternatingRowStyle BackColor="WhiteSmoke" Height="28px" />
        <Columns>
           <%-- <asp:TemplateField HeaderText="Sr.No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    <asp:HiddenField ID="hdnIdField" Value='<%# Eval("id") %>' runat="server" />
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField><asp:ListBox runat="server"></asp:ListBox>
            <asp:TemplateField HeaderText="Image Name">
                <ItemTemplate>
                    <asp:Label ID="lblQuestionPath" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="lblCorrectAnswer" runat="server" Text='<%# Eval("EventDescription")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" SortExpression="Score">
                <ItemTemplate>
                    <asp:Image ID="Image1" Width="100" Height="100" runat="server" ImageUrl='<%# "GetImage.ashx?ImgID="+ Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
    <div id="dialog" style="display: none">
    </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/start/jquery-ui.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#dialog").dialog({
                autoOpen: false,
                modal: true,
                height: 600,
                width: 600,
                title: "Zoomed Image"
            });
            $("[id*=gvImages] img").click(function () {
                $('#dialog').html('');
                $('#dialog').append($(this).clone());
                $('#dialog').dialog('open');
            });
        });
    </script>
    </form>
</body>
</html>
