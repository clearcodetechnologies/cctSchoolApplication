<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="frmPeriod_Master.aspx.cs" Inherits="frmPeriod_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
       <script>
             //$('.gbtn-edit').on('click', function (e) {
                 
             //    alert("test222");
             //    debugger;
           
          
             //$('#tab2').trigger('click')
                 
             ////$('#tab2Entry').tab('show');
             ////$("#custom-tabs-five-overlay").removeClass("show").addClass('hide');
             ////$('#custom-tabs-five-overlay').tab('hide');
             //});

             function edit (id) {
               
                 //alert(id);
                 //alert($('#'+id).data("rowid"));
                 
                 $.ajax({

                     type: "POST",
                     url: "frmPeriod_Master.aspx/pullData",
                     data: '{id: "' +  $('#' + id).data("rowid")+ '" }',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",                      
                     success: function (result) {
                         $("#<%=hid1.ClientID%>").val(result.d.id)
                         $("#<%=TextBox1.ClientID%>").val(result.d.frmdt)
                         $("#<%=TextBox2.ClientID%>").val(result.d.todt)
                          $("#<%=drop1.ClientID%>").val(result.d.ddlval)
                        if (result.d.check == "true") {
                             $("#<%=CheckBox1.ClientID%>").prop('checked', true)
                         } else {
                             $("#<%=CheckBox1.ClientID%>").prop('checked', false)
                        }
                         $("#<%=Button1.ClientID%>").addClass('d-none');
                         $("#<%=Button2.ClientID%>").removeClass('d-none');                         
                             },
                     error: function () { alert("errors")}
                 });

                 $('#tab2').trigger('click')
             };

           function funcswitchtab() {
               $("#<%=hid1.ClientID%>").val("")
               $("#<%=TextBox1.ClientID%>").val("")
               $("#<%=TextBox2.ClientID%>").val("")
               $("#<%=drop1.ClientID%>").val("")
               $("#<%=Button1.ClientID%>").removeClass('d-none');
               $("#<%=Button2.ClientID%>").addClass('d-none'); 




               $("#tab2Entry").addClass("active show");
               $("#custom-tabs-five-overlay").removeClass("active");
               $("#custom-tabs-five-overlay").removeClass("show");
               //$('.tab-pane #tab2Entry"]').show();
               //window.location.href = "#tab2Entry";
           }
         

           function clrflds()
           {
               alert(1)
               $("#btnClear").click();
               funcswitchtab()
              
           }
         //('#ImgEdit').click(function (e) {
         //    alert("test");
         //    e.preventDefault();
         //    $(this).tab('show');
         //});
         //$('ImgEdit').click(function (e) {
         //    alert("test1");
         //    e.preventDefault();
         //    $(this).tab('show');
         //});
          
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  

    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">   Period Master </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active"> Period Master</li>
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
                <button type="button" id="sd">Button </button>
                <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">Details</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="tab2" data-toggle="pill" data-href="#tab2Entry" onclick="funcswitchtab()" role="tab" aria-controls="tab2Entry" aria-selected="false">New Entry</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="Session"></asp:Label> 
                                    <asp:DropDownList ID="ddlSessionName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSessionName_SelectedIndexChanged" TabIndex="2" AutoPostBack="True">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSessionName"
                                        Display="None" ErrorMessage="Please select Session"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                          <%--remove edit event
                              data-id=" set id value"
                              ajax function
                              --%>
                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="PeriodReport" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  OnPageIndexChanging="PeriodReport_PageIndexChanging"
                                    OnRowDataBound="PeriodReport_RowDataBound" OnRowEditing="PeriodReport_RowEditing"
                                    DataKeyNames="intPeriod_id" OnRowDeleting="PeriodReport_RowDeleting" OnRowCommand="PeriodReport_RowCommand"
                                     OnSelectedIndexChanged="PeriodReport_SelectedIndexChanged">
                                    <Columns>   
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="intPeriod_id" runat="server" Text='  <%# Eval("intPeriod_id")  %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>                                                              
                                         <asp:BoundField DataField="dtFromTime" HeaderText="From Time" ReadOnly="True" />
                                        <asp:BoundField DataField="dtToTime" HeaderText="To Time" ReadOnly="True" />
                                        <asp:BoundField DataField="intSession_id" HeaderText="Session" ReadOnly="True" />
                                        <asp:BoundField DataField="btrecess" HeaderText="Recess" ReadOnly="True" />                                     
                                                                 
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="grd<%# Eval("intPeriod_id")%>" OnClick="edit(this.id)" CssClass="gdlinkedit" data-rowid="<%# Eval("intPeriod_id")%>"> Edit</asp:LinkButton>
                                               <%-- <a href="javascript:void(0);" class="gdlinkedit" data-rowid="<%# Eval("intPeriod_id")%>"> Edit </a>--%>
                                               <%-- <asp:ImageButton ID="ImgEdit" CssClass="gbtn-edit" CommandName="Edit" CausesValidation="false"
                                                    ImageUrl="~/images/edit.svg" />--%>
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
                      </div>
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label1" class="col-form-label" runat="server" Text="From Time"></asp:Label> 
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" MaxLength="75"
                                                runat="server" AutoPostBack="false" Font-Bold="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator
                                                    ID="refvdt1" runat="server" ControlToValidate="TextBox1" ValidationGroup="p1"
                                                    Display="None" ErrorMessage="Please Enter Period From Time" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="ValiCaEr1" runat="server" Enabled="True" TargetControlID="refvdt1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="TextBox1"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" ErrorTooltipEnabled="True" Century="2000"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="mark1" runat="server" Display="None" InvalidValueMessage="Enter Valid From Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox1" ControlExtender="MaskedEditExtender2"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="VrCEer2" runat="server" Enabled="True" TargetControlID="mark1">
                                                </asp:ValidatorCalloutExtender>
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label4" class="col-form-label" runat="server" Text="To Time"></asp:Label> 
                                    <asp:TextBox ID="TextBox2" runat="server" AutoComplete="Off" CssClass="form-control" MaxLength="75"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                    runat="server" ControlToValidate="TextBox2" Display="None" ErrorMessage="Please Enter Period To Time"
                                                    ValidationGroup="p1" Font-Bold="False"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                        ID="VatCatEx2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextBox2"
                                                Mask="99:99" AcceptAMPM="True" MaskType="Time" DisplayMoney="Left" ErrorTooltipEnabled="True"
                                                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" />
                                            <asp:MaskedEditValidator ID="MaEVor1" runat="server" Display="None" InvalidValueMessage="Enter Valid To Time"
                                                SetFocusOnError="True" ControlToValidate="TextBox2" ControlExtender="MaskedEditExtender1"
                                                ErrorMessage="mark1" Font-Bold="False"></asp:MaskedEditValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="MaEVor1">
                                                </asp:ValidatorCalloutExtender>
                                </div>
                             </div>

                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label2" class="col-form-label" runat="server" Text="Session"></asp:Label> 
                                    <asp:DropDownList ID="drop1" runat="server" CssClass="form-control" AutoPostBack="false" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drop1"
                                        Display="None" ErrorMessage="Please Enter Session Value"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                    <asp:CheckBox ID="CheckBox1" Style="margin-top: 10px; margin-left: 10px; left: 0px"
                                                runat="server" Text="Recess" Value="1" Font-Bold="False" TabIndex="3" /> 
                                </div>
                             </div>
                                
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                                 <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-success btn-sm mt-18" 
                                    Text="Submit"/>--%>
                                     <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="vclassrooms_send"
                                                ValidationGroup="p1" OnClick="Button1_Click" TabIndex="4" />
                                    <asp:Button ID="Button2"
                                                    runat="server" Text="Update" CssClass="vclassrooms_send d-none" OnClick="Button2_Click" /><asp:HiddenField
                                                        ID="hid1" runat="server" />
                                <asp:Button ID="btnClear" runat="server" CausesValidation="False"  CssClass="btn btn-danger btn-sm mt-18"
                                    Text="Clear" Visible="True" />
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