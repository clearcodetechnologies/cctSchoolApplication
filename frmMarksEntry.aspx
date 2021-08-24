<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    Culture="en-Gb" EnableViewState="true" CodeFile="frmMarksEntry.aspx.cs" Inherits="frmMarksEntry"
    Title="VClassrooms - Student attendance management system, Fees management, School bus tracking, Exam schedule, time table management" %>

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
            <h1 class="m-0">   Marks Entry </h1>
          </div>  
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Study</a></li>
              <li class="breadcrumb-item active"> Marks Entry</li>
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
                      <a class="nav-link" id="tab2" data-toggle="pill" href="#tab2Entry" role="tab" aria-controls="tab2Entry" aria-selected="false">Exam Entry</a>
                    </li> 
                  </ul>
                </div>
                <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                      <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblSTD1" class="col-form-label" runat="server" Text="Standard"></asp:Label> 
                                    <asp:DropDownList ID="ddlSTD1" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlSTD1_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblDIV1" class="col-form-label" runat="server" Text="Division"></asp:Label> 
                                    <asp:DropDownList ID="ddlDIV1" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlDiv1_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblStudentName" class="col-form-label" runat="server" Text="Student Name" ></asp:Label> 
                                    <asp:DropDownList ID="ddlStud" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" >
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label3" class="col-form-label" runat="server" Text="Exam Type" ></asp:Label> 
                                    <asp:DropDownList ID="drpExamType" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                OnSelectedIndexChanged="drpExamType_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label10" class="col-form-label" runat="server" Text="Examination" ></asp:Label> 
                                    <asp:DropDownList ID="ddlExam1" runat="server" CssClass="form-control" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlExam1_SelectedIndexChanged">
                                        <%-- <asp:ListItem Value="0">---Select---</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="Label7" class="col-form-label" runat="server" Text="Declare Date-Time" ></asp:Label> 
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
                                    
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   
                                    <asp:TextBox ID="txtTime" runat="server" CssClass="input-blue" AutoPostBack="True"></asp:TextBox>
                                     <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptAMPM="True"
                                                                AutoCompleteValue="00:00" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                                CultureTimePlaceholder="" Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTime">
                                                            </asp:MaskedEditExtender>
                                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" Display="None" ControlToValidate="txtTime"
                                                                ControlExtender="MaskedEditExtender1" InvalidValueMessage="Please enter a valid time."
                                                                EmptyValueMessage="Please Enter Valid Time" SetFocusOnError="True" ErrorMessage="Please Enter Valid Time"
                                                                runat="server" CssClass="textsize"></asp:MaskedEditValidator>
                                                            <asp:ValidatorCalloutExtender runat="server" ID="ValidatorCalloutExtender3" TargetControlID="MaskedEditValidator1"
                                                                Enabled="True">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Time For Result Declaration"
                                                                Display="None" ControlToValidate="txtTime" CssClass="textsize"></asp:RequiredFieldValidator><asp:ValidatorCalloutExtender
                                                                    ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator3"
                                                                    Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                    
                                </div>
                             </div>

                             

                        <div class="col-lg-12 col-md-12">
                             <asp:GridView ID="grvMarks" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-bordered cus-table tabular-table "  PageSize="20"  DataKeyNames="intID" 
                                    OnRowDataBound="grvMarks_RowDataBound">
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

                        <div class="row">
                         <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Button ID="btnSubmit1" runat="server" CssClass="vclassrooms_send" Text="Submit"
                                                    Visible="False" OnClick="btnSubmit1_Click" />
                                    
                                </div>
                             </div>

                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Button ID="btnClear1" CssClass="vclassrooms_send" runat="server" Text="Clear"
                                                    Visible="False" OnClick="btnClear1_Click" />
                                    
                                </div>
                             </div>

                          </div>

                        </div>
                      </div>
                    <div class="tab-pane fade" id="tab2Entry" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblSTD2" class="col-form-label" runat="server" Text="STD"></asp:Label> 
                                    <asp:DropDownList ID="ddlSTD2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD2_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblDIV2" class="col-form-label" runat="server" Text="DIV"></asp:Label> 
                                    <asp:DropDownList ID="ddlDIV2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDIV2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblStud" runat="server"  class="col-form-label"  Text="Student Name"></asp:Label> 
                                   <asp:DropDownList ID="ddlStudent2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                     
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="Label5" runat="server"  class="col-form-label"  Text="Examination"></asp:Label> 
                                   <asp:DropDownList ID="ddlExam2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                     
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                              <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label>
                                  <asp:Label ID="lblGetName" runat="server" Font-Bold="False"></asp:Label>
                                  <asp:LinkButton ID="btnView" runat="server" OnClick="btnView_Click" Visible="False">View</asp:LinkButton>
                                     
                                </div>
                             </div>
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <div id="divMarksHeader" runat="server">
                                                        </div>
                                                        <div id="divMarks" runat="server" style="overflow: none; height: 300px">
                                                        </div>
                                     
                                </div>
                             </div>
                            
                                
                              


                            </div>
                         </div>
                       </div> 
                     
                     <div class="tab-pane fade" id="Div1" role="tabpanel" aria-labelledby="tab2">
                     <div class="form-horizontal">
                            <div class="row">
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblStd" class="col-form-label" runat="server" Text="STD"></asp:Label> 
                                    <asp:DropDownList ID="ddlSTD" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSTD_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                   <asp:Label ID="lblDIV" class="col-form-label" runat="server" Text="DIV"></asp:Label> 
                                    <asp:DropDownList ID="ddlDiv" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDiv_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblStudent" runat="server"  class="col-form-label"  Text="Student Name"></asp:Label> 
                                   <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                     
                                </div>
                             </div>
                              <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Label ID="lblExam" runat="server"  class="col-form-label"  Text="Examination"></asp:Label> 
                                   <asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                     
                                </div>
                             </div>

                             <div id="divTable" class="vclassrooms" runat="server">
                                    </div>
                             
                             <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                  <asp:Button ID="btnSubmit" runat="server" CssClass="vclassrooms_send" Text="Submit"
                                                    Visible="False" />

                                                    <asp:Button ID="btnClear" CssClass="vclassrooms_send" runat="server" Text="Clear"
                                                    Visible="False" />
                                     
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