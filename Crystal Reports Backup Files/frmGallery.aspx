<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmGallery.aspx.cs" Inherits="frmGallery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .vclassrooms_send
        {
            width: 50% !important;
            background: #3498db;
            border: none;
            font-size: 16px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 2px;
            color: #fff;
            margin: 10px auto;
            padding: 3px;
            cursor: pointer;
            height: 30px;
            margin-right: 10px;
            float: none;
            text-align: center;
        }
        
        .textcss
        {
            font-size: 13px !important;
        }
        
        .textsize
        {
            width: 230px;
            height: 30px;
            font-size: 13px;
            border-radius: 5px;
            border: 1px solid #3498db;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        table img
        {
            height: 150px;
            width: 150px;
            cursor: pointer;
        }
        
        
        .modal
        {
            display: none;
            background: #000;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            opacity: .8;
        }
        
        .modal .modal-content
        {
            position: absolute;
            top: 50%;
            left: 50%;
            margin-top: -120px;
            margin-left: -150px;
            color: #fff;
        }
        
        .modal img, .modal span
        {
            z-index: 10;
        }
    </style>
    <script type="text/javascript">
        $.noConflict();

        var images = document.querySelectorAll('[id*=gvImages] img'),
        modal = document.querySelector('.modal');

        // Loops through the all the images selected...
        images.forEach(function (image) {

            // When the image is clicked...
            image.addEventListener('click', function (event) {

                modal.innerHTML = '<div class="modal-content"><img src="' + event.target.src + '"><br><span>' + event.target.alt + '</span></div>';
                modal.style.display = 'block';
            });
        });

        // When the user clicks somewhere in the "modal" area it automatically closes itself
        modal.addEventListener('click', function () {
            this.style.display = 'none';
        });   

    </script>
    <script src="https://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript">
        /*      var images = document.querySelectorAll('[id*=gvImages] img'),
        modal = document.querySelector('.modal');

        // Loops through the all the images selected...
        images.forEach(function (image) {
          
        // When the image is clicked...
        image.addEventListener('click', function (event) {
             
        modal.innerHTML = '<div class="modal-content"><img src="' + event.target.src + '"><br><span>' + event.target.alt + '</span></div>';
        modal.style.display = 'block';
        });
        });

        // When the user clicks somewhere in the "modal" area it automatically closes itself
        modal.addEventListener('click', function () {
        this.style.display = 'none';
        });     */

        var table = document.getElementById("gvImages");

        table.onclick = function (e) {
            e = e || window.event;
            var target = e.target || e.srcElement;
            if (target.nodeName.toLowerCase() == "td" && target.HeaderText == "image") {
                alert("Image input clicked");
            }
        };

        /*   $(document).ready(function() {
        $("#dialog1").dialog({
            
        autoOpen: false,
        modal: true,
        height: 600,
        width: 600,
        title: "Zoomed Image"
        });
        $("[id*=gvImages] img").click(function () {

        $('#dialog1').html('');
        $('#dialog1').append($(this).clone());
        $('#dialog1').dialog('open');
        });
        }); */

        var images = document.querySelectorAll('[id*=gvImages] img'),
        modal = document.querySelector('.modal');

        // Loops through the all the images selected...
        images.forEach(function (image) {

            // When the image is clicked...
            image.addEventListener('click', function (event) {

                modal.innerHTML = '<div class="modal-content"><img src="' + event.target.src + '"><br><span>' + event.target.alt + '</span></div>';
                modal.style.display = 'block';
            });
        });

        // When the user clicks somewhere in the "modal" area it automatically closes itself
        modal.addEventListener('click', function () {
            this.style.display = 'none';
        });   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header content-header1 pd-0">
        <ul class="top_navlg">
            <li><a>Gallery <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
        </ul>
    </div>
    <div class="content">
        <div class="row">
        
            <div class="col-md-12">

                <div class="box">
                    <div class="box-body">
                    <div class="form-group">
             
                  <div class="col-md-3">
                   <asp:Label ID="Label6" runat="server" Text="Event" CssClass="control-label"></asp:Label>    
                
                   <asp:TextBox ID="txtEvent" runat="server"></asp:TextBox>
                 </div>
                 <div class="col-md-3">
                     <asp:Label ID="Label10" runat="server" Text="Category" CssClass="control-label"></asp:Label> 
                 
                  <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true"
                         onselectedindexchanged="ddlCategory_SelectedIndexChanged" >
                                        <asp:ListItem Value="Select" Selected="True">---Select---</asp:ListItem>
                                    </asp:DropDownList>
                 </div>
                  <div class="col-md-3"><!-- style="padding: 0px 0 0 6px;"-->
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                 </div>
                 <div class="col-md-2">
                   <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
                 </div>
                 <div class="col-md-3">
                    <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                         
                   
                 </div>
                
            </div>
                             <div class="clearfix"></div>
                           <%-- </div>--%>
                            <div class="col-md-12">
                                <asp:GridView ID="gvImages" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false"
                                    DataKeyNames="id,Name" OnRowDeleting="gvImages_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Image Id" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="EventDescription" HeaderText="DESCRIPTION" />
                                        <asp:ImageField DataImageUrlField="Path" HeaderText="Image" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                    ImageUrl="~/images/delete.png" OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div id="dialog" style="display: none">
                                </div>
                                <div class="modal">
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
