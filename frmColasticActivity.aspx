<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" EnableEventValidation="true" CodeFile="frmColasticActivity.aspx.cs" Inherits="frmColasticActivity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">
function funcswitchtab() {
    $('#tab2').trigger('click')
    $("#tab2Entry").addClass("active show");
    $("#custom-tabs-five-overlay-tab").removeClass("active");
    $("#custom-tabs-five-overlay").removeClass("show").removeClass("active");
}         
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Colastic Activity </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Activity Master</li>
            </ol>
          </div> 
        </div> 
      </div> 
    </div> 
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
    <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Details</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false">Entry</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" 
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intColasticActivity_id" OnRowDeleting="grvDetail_RowDeleting" OnRowEditing="grvDetail_RowEditing" >
                                    <Columns>                                                                 
                                        <asp:BoundField DataField="intSection_id" HeaderText="Section" ReadOnly="True" />
                                                                 <asp:BoundField DataField="dtDate" HeaderText="Date" ReadOnly="True" />
                                                                 <asp:BoundField DataField="vchDescription" HeaderText="Details" ReadOnly="True" />
                                                               
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgEdit" runat="server" CssClass="gbtn-edit" CommandName="Edit" CausesValidation="false"
                                                    ImageUrl="~/images/edit.svg" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete" runat="server" CssClass="gbtn-delete" CommandName="Delete" CausesValidation="false"
                                                    OnClientClick="return confirm('Do You Really Want To Delete Selected Record?');" ImageUrl="~/images/delete.svg" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                        </div> 
                      </div>
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="Section"></asp:Label> 
                                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="--Select Section--"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Primary"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Secondary"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSection"
                                        Display="None" ErrorMessage="Please select Section"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label2" runat="server"  class="col-form-label"  Text="Date"></asp:Label> 
                                   <asp:TextBox ID="txtDate" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDate"
                                        Display="None" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                    Format="yyyy/MM/dd" TargetControlID="txtDate">
                                                </asp:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ControlToValidate="txtDate" ErrorMessage="Please Enter proper date format in yyyy/mm/dd"
            ValidationExpression="\d{4}(\/|\-)((10|11|12)|0[1-9]{1})(\/|\-)(([0-2][1-9])|(3[01]{1}))"></asp:RegularExpressionValidator>
                                     
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="Details"></asp:Label> 
                  
                                   <asp:TextBox ID="txtDet" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDet"
                                        Display="None" ErrorMessage="Please Enter Details"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                                
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                 <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success btn-sm mt-18" OnClick="btnSubmit_Click" OnClientClick="return ConfirmInsertUpdate();"
                                    Text="Submit"/>
                                <asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click" CssClass="btn btn-danger btn-sm mt-18"
                                    Text="Clear" Visible="False" />
                                </div>


                            </div>
                         </div>
                       </div> 
                     
                       </div>
                    </div>

                </div>
            </div>
         </div>
       </div>
     </section>               
 </ContentTemplate>
            </asp:UpdatePanel>

 
           <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle d-none" runat="server"  
                                    ActiveTabIndex="1">
                                    <asp:TabPanel HeaderText="g" CssClass="vclassrooms" ID="tab" runat="server">
                                         
                                    </asp:TabPanel>
                                    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"> 
                                    </asp:TabPanel>
                                </asp:TabContainer>
                         
    
</asp:Content>