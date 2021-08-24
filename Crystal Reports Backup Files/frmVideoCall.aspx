<%@ Page Title="VCLASSROOMS" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmVideoCall.aspx.cs" Inherits="frmVideoCall" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
    prm.add_beginRequest(BeginRequestHandler);
    // Raised after an asynchronous postback is finished and control has been returned to the browser.
    prm.add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        //Shows the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.show();
        }
    }

    function EndRequestHandler(sender, args) {
        //Hide the modal popup - the update progress
        var popup = $find('<%= modalPopup.ClientID %>');
        if (popup != null) {
            popup.hide();
        }
    }
    </script>
    <style type="text/css">        
        .modalPopup
        {
            position: fixed;
            left: 0px;
            top: 0px;
            z-index: 10000;
            width: 100%;
            height: 100%;
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            z-index:-1;
           
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/hourglass.gif"></asp:Image>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
            PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
            Enabled="True">
        </asp:ModalPopupExtender>
 <!-- Main content -->
   
    <section class="content-header padd-tb25">
      
      <%--<ol class="breadcrumb">
        <li><a href="frmDashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>       
        <li class="active">VCLASSROOMS</li>
  
      </ol>--%>
    </section>

   <section class="content bg-crystal">
       
      <!-- Small boxes (Stat box) -->
      			<div class="row">
                    <section class="col-md-12 col-xs-12">
                          <div class="box box-orange">
                          	<div class="box-header">
                             <!-- tools box -->
                                    <div class="pull-right box-tools">                                  
                                        <button class="btn btn-danger btn-sm" data-widget='collapse' data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>                                       
                                    </div><!-- /. tools -->
                            	<h3 class="text-center">VCLASSROOMS</h3>
                            </div>
                            <div class="box-body"> 

     <asp:TabContainer  class="mytabstyle" ID="TabContainer1" runat="server" 
        ActiveTabIndex="0" CssClass="mytabstyle">
<asp:TabPanel  ID="TabPan1" runat="server" HeaderText="TabPan1">
            <HeaderTemplate>
             
            </HeaderTemplate>
            <ContentTemplate>

                <div class="col-lg-2 col-md-2 col-sm-6 padd-rl5">
                                         <div class="form-group">
                                            <label class="col-sm-12 padd-rl5" >Standard</label>
                                            <div class="col-sm-12 padd-rl5 ">
                                                <asp:DropDownList ID="ddlSearchStandard" runat="server" class="form-control searchable"
                                                    AutoPostBack="True" onselectedindexchanged="ddlSearchStandard_SelectedIndexChanged"></asp:DropDownList>
                                             </div>                          	
                                        </div>		<!-- form group close --> 
                                </div>
                <div class="col-lg-2 col-md-2 col-sm-6 padd-rl5">
                                         <div class="form-group">
                                            <label class="col-sm-12 padd-rl5" >Division</label>
                                            <div class="col-sm-12 padd-rl5 ">
                                                <asp:DropDownList ID="ddlSearchDivision" runat="server" class="form-control searchable"></asp:DropDownList>
                                             </div>                          	
                                        </div>		<!-- form group close --> 
                                </div>
                  <div class="col-lg-2 col-md-2 col-sm-6 padd-rl5">
                            <div class="form-group">
                                <label class="col-sm-12 padd-rl5" > Join </label>
                                <div class="col-sm-12 padd-rl5"> 
                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                        <asp:Button ID="btnSearch" class="btn btn-orange1 col-md-12" runat="server" 
                                        Text="JOIN"  OnClick="btnSearchRpt_Click"></asp:Button>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnSearch" />
                                            </Triggers>
                                    </asp:UpdatePanel>
                                  </div>
                            </div>
                    </div>
                  
                           
                            
        </ContentTemplate>
        </asp:TabPanel>

 </asp:TabContainer> 
                          </div>
                        </section>
                    </div>
      <!-- /.row (main row) -->
       
     
</section><!-- /.content -->
 
<!-- Bootstrap WYSIHTML5 -->
<script src="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<script src="plugins/moment.js"></script>
<script src="plugins/jQuery/jquery-2.2.0.js"></script>     
   
     </ContentTemplate>  
  </asp:UpdatePanel>
</asp:Content>

