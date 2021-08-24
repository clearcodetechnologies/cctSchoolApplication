<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="FrmAdmsTeacherProfile.aspx.cs" Inherits="FrmAdmsTeacherProfile" Title="Teacher Profile"
    Culture="es-MX" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     
  
<!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Teacher Profile</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Master</a></li>
              <li class="breadcrumb-item active">Teacher Profile</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

 
       <asp:UpdatePanel ID="up2" runat="server">
            <ContentTemplate>
             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/waiting.gif"></asp:Image>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress1"
                PopupControlID="UpdateProgress1" BackgroundCssClass="modalPopup" DynamicServicePath=""
                Enabled="True">
            </asp:ModalPopupExtender>

 <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
              <div class="card card-primary card-tabs">
                <div class="card-header p-0 pt-1">
                  <ul class="nav nav-tabs" id="custom-tabs-five-tab" role="tablist">
                    <li class="nav-item">
                      <a class="nav-link active" id="custom-tabs-five-overlay-tab" data-toggle="pill" href="#custom-tabs-five-overlay" role="tab" aria-controls="custom-tabs-five-overlay" aria-selected="true">   Personal Details </a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="custom-tabs-five-overlay-dark-tab" data-toggle="pill" href="#custom-tabs-five-overlay-dark" role="tab" aria-controls="custom-tabs-five-overlay-dark" aria-selected="false">Education Details </a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" id="custom-tabs-five-normal-tab" data-toggle="pill" href="#custom-tabs-five-normal" role="tab" aria-controls="custom-tabs-five-normal" aria-selected="false">Details </a>
                    </li> 
                  </ul>
                </div>
                   <div class="card-body">
                  <div class="tab-content" id="custom-tabs-five-tabContent">
                      <div class="tab-pane fade show active" id="custom-tabs-five-overlay" role="tabpanel" aria-labelledby="custom-tabs-five-overlay-tab">
                        <div class="form-horizontal">
                            <div class="row">
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                 <asp:Label ID="lblvchno" CssClass="col-form-label" runat="server" Font-Bold="False">First Name</asp:Label>
                                     <asp:Label ID="Label1" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Verdana" CssClass="form-control"
                                                                ForeColor="Black" MaxLength="50" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox1"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter First Name" Font-Bold="False"></asp:RequiredFieldValidator>
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                     <asp:Label ID="lblvchmake" CssClass="col-form-label" runat="server" Font-Bold="False">Middle Name</asp:Label>
                                   <asp:Label ID="Label2" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox2" runat="server" Font-Names="Verdana"  CssClass="form-control"
                                                                ForeColor="Black" MaxLength="50" ValidationGroup="b"></asp:TextBox>
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group">
                                      <asp:Label ID="lblvchdrivername" CssClass="col-form-label" runat="server" Text="Last Name" Font-Bold="False"></asp:Label>
                                   <asp:Label ID="Label5" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox3" runat="server" Font-Names="Verdana" CssClass="form-control"
                                                                ForeColor="Black" MaxLength="50" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter last Name" Font-Bold="False"></asp:RequiredFieldValidator>
                                </div>
                             </div>
                               
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                   <asp:Label ID="Label35" runat="server" CssClass="col-form-label" Text="Academic Year" Font-Bold="False"></asp:Label>
                                                        
                                        <asp:Label ID="lblAcademicYear" runat="server" Font-Bold="False"></asp:Label>
                                        <asp:DropDownList ID="ddlAcademicYear" runat="server"  CssClass="form-control"
                                            DataTextField="AcademicYear" DataValueField='intAcademic_id'  >
                                        </asp:DropDownList>
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                      <asp:Label ID="Label12" CssClass="col-form-label" runat="server" Text="Department Name" Font-Bold="False"></asp:Label>
                                                      
                                    <asp:Label ID="Label10" runat="server" Font-Bold="False"></asp:Label>
                                    <asp:DropDownList ID="TextBox5" runat="server" DataTextField="vchDepartment_name"
                                        DataValueField='intDepartment' CssClass="form-control"
                                        OnSelectedIndexChanged="TextBox5_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Department"
                                        ValidationGroup="a1" ControlToValidate="TextBox5" InitialValue="Select" Display="None"
                                        Font-Bold="False"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator2">
                                    </asp:ValidatorCalloutExtender>
                                </div>
                             </div>

                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label7" runat="server" CssClass="col-form-label"  Text="Designation" Font-Bold="False"></asp:Label>
                                                     
                                    <asp:Label ID="Label8" runat="server" Font-Bold="False"></asp:Label>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" DataTextField="vchDesignation"  CssClass="form-control"
                                        DataValueField='intDesignation_Id'>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Designation"
                                        ValidationGroup="a1" ControlToValidate="ddlDesignation" InitialValue="Select" Display="None"
                                        Font-Bold="False"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                        TargetControlID="RequiredFieldValidator3">
                                    </asp:ValidatorCalloutExtender>

                                </div>
                             </div>

                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label13" CssClass="col-form-label" runat="server" Text="Gender" Font-Bold="False"></asp:Label>
                                                      
                                    <asp:UpdatePanel runat="server" ID="uid1" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:DropDownList ID="TextBox6" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Select" Selected="True">---Select---</asp:ListItem>
                                                <asp:ListItem Value="Male">Male</asp:ListItem>
                                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Gender"
                                                ControlToValidate="TextBox6" InitialValue="Select" Display="None" ValidationGroup="a1"
                                                Font-Bold="False"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                      <asp:Label ID="Label14" CssClass="col-form-label" runat="server" Text="Date of Birth" Font-Bold="False"></asp:Label>
                                                       
                                            <asp:Label ID="Label22" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Font-Names="Verdana" 
                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>&nbsp;&nbsp;
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox7" Format="dd/MM/yyyy"
                                                Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"
                                                ValidationGroup="a1" Display="None" ErrorMessage="Please Enter Dob Name" Font-Bold="False"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                                </asp:ValidatorCalloutExtender>
                                            &nbsp;&nbsp;
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="TextBox7"
                                                Display="None" ErrorMessage="Enter proper date.(DD/MM/YYYY)" Font-Bold="False"
                                                Operator="LessThan" SetFocusOnError="True" Type="Date" ValidationGroup="a1"></asp:CompareValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="CompareValidator3">
                                                </asp:ValidatorCalloutExtender> 
                                </div>
                             </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                      <asp:Label ID="lbldrivermobno" CssClass="col-form-label" runat="server" Text="Email" Font-Bold="False"></asp:Label>
                                                        
                                            <asp:Label ID="Label23" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Font-Names="Verdana"
                                                ForeColor="Black" MaxLength="50" ValidationGroup="b"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ControlToValidate="TextBox8" Display="None" ValidationGroup="p1" ErrorMessage="Invalid Email Format"
                                                Font-Bold="False"></asp:RegularExpressionValidator><asp:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender43" runat="server" Enabled="True" TargetControlID="regexEmailValid">
                                                </asp:ValidatorCalloutExtender>
                                </div>
                             </div>

                                <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label15" CssClass="col-form-label" runat="server" Text="Highest Qualification" Font-Bold="False"></asp:Label>
                                                        
                                            <asp:Label ID="Label24" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" Font-Names="Verdana"
                                                ForeColor="Black" MaxLength="50" ValidationGroup="b" 
                                                ></asp:TextBox>
                                </div>
                             </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label18" runat="server" CssClass="col-form-label" Text="Mobile Number" Font-Bold="False"></asp:Label>
                                                       
                                            <asp:Label ID="Label27" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:TextBox ID="TextBox12" runat="server"  CssClass="form-control" Font-Names="Verdana"
                                                ForeColor="Black" MaxLength="10" ValidationGroup="b" 
                                                onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                                                      
                                </div>
                             </div>

                                  <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label34" runat="server" CssClass="col-form-label" Text="Time To Contact" Font-Bold="False"></asp:Label>
                                                     
                                        <asp:Label ID="Label33" runat="server" Font-Bold="False"></asp:Label>
                                        <asp:TextBox ID="TextBox18" runat="server" Font-Names="Verdana" ForeColor="Black"
                                            MaxLength="20" ValidationGroup="b" CssClass="form-control"></asp:TextBox>
                                                         
                                </div>
                             </div>
                                  <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                     <asp:Label ID="Label3" CssClass="col-form-label"  runat="server" Font-Bold="False">Present Address</asp:Label>
                                                    
                                        <asp:Label ID="Label31" runat="server" Font-Bold="False"></asp:Label>
                                        <asp:TextBox ID="TextBox16" Style="float: left;" runat="server" Font-Names="Verdana"
                                            Font-Size="Small" ForeColor="Black" MaxLength="250" ValidationGroup="b"  
                                            CssClass="form-control"  ></asp:TextBox>
                                </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                              <div class="form-group"> 
                                      <asp:Label ID="Label4" CssClass="col-form-label" runat="server" Text="Permanent Address" Font-Bold="False"></asp:Label>
                                                      
                                            <asp:Label ID="Label32" runat="server" Font-Bold="False"></asp:Label>
                                            <asp:TextBox ID="TextBox17" Style="float: left;" runat="server" Font-Names="Verdana"
                                                Font-Size="Small" ForeColor="Black" MaxLength="250" ValidationGroup="b" CssClass="form-control"  ></asp:TextBox>
                                </div>
                                </div>
                                 <div class="col-lg-3 col-md-4 col-sm-6">
                             
                                </div>

                            </div>
                        </div>
                      </div>
                        <div class="tab-pane fade" id="custom-tabs-five-overlay-dark" role="tabpanel" aria-labelledby="tab2">
                      <div class="col-lg-12 col-md-12">
                              
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDegree1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtInstitution1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPassingYear1"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtPercent1"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtMajorSubject1"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDegree2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtInstitution2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPassingYear2"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPercent1"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtMajorSubject2"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtDegree3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtInstitution3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtPassingYear3"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtPercent3"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtMajorSubject3"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txtDegree4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txtInstitution4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" TargetControlID="txtPassingYear4"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" TargetControlID="txtPercent4"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" TargetControlID="txtMajorSubject4"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txtDegree5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="' ,./" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" TargetControlID="txtInstitution5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" TargetControlID="txtPassingYear5"
                                                FilterType="Numbers" Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" TargetControlID="txtPercent5"
                                                FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" ValidChars="%."
                                                Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" TargetControlID="txtMajorSubject5"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="'  ," Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:CalendarExtender ID="cal1" runat="server" TargetControlID="txtPassingYear1"
                                                Format="yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPassingYear2"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPassingYear3"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtPassingYear4"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPassingYear5"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                            <table   class="table table-hover table-bordered cus-table tabular-table ">
                                                <thead>
                                                <tr>
                                                    <th class="style6">
                                                        &nbsp;
                                                    </th>
                                                    <th align="center">
                                                        Degree / Diploma / Other
                                                    </th>
                                                    <th align="center">
                                                        Institution
                                                    </th>
                                                    <th align="center" class="auto-style1">
                                                        University
                                                    </th>
                                                    <th align="center" class="style4">
                                                        Year of Passing
                                                    </th>
                                                    <th align="center" class="style5">
                                                        % Score / Grade
                                                    </th>
                                                    <th align="center">
                                                        Major Subjects
                                                    </th> 
                                                </tr>
                                                    </thead>
                                                <tbody>
                                                <tr id="tr1" runat="server">
                                                    <td align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button4" runat="server" CssClass="btn btn-success btn-sm" 
                                                           Text="+" OnClientClick="if (!validatePage()) {return true;}" OnClick="Button4_Click" />
                                                    </td>
                                                    <td valign="top" align="center" runat="server" style="white-space: nowrap">
                                                        <asp:TextBox ID="txtDegree1" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"  MaxLength="50"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution1" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity1" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox runat="server" MaxLength="5" CssClass="form-control"  ID="txtPassingYear1"
                                                            oncopy="return false" oncut="return false" AutoComplete="Off" onpaste="return false"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent1" oncopy="return false" CssClass="form-control" oncut="return false"
                                                            AutoComplete="Off" onpaste="return false" runat="server"  MaxLength="5"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" runat="server" aling="center">
                                                        <asp:TextBox ID="txtMajorSubject1" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv1" runat="server" Font-Bold="False"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr id="tr2" runat="server" visible="False">
                                                    <td align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button5" runat="server" Text="+" CssClass="btn btn-success btn-sm" OnClick="Button5_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}" />
                                                    </td>
                                                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree2" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution2" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity2" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"  ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear2" runat="server"   CssClass="form-control"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent2" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"  MaxLength="5"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject2" runat="server" CssClass="input-blue" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv2" runat="server" Font-Bold="False"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr id="tr3" runat="server" visible="False">
                                                    <td align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button6" runat="server" Text="+" CssClass="btn btn-success btn-sm" OnClick="Button6_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}"   />
                                                    </td>
                                                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree3" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution3" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity3" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear3" runat="server"  CssClass="form-control"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent3" runat="server" oncopy="return false" oncut="return false"
                                                            CssClass="input-blue" onpaste="return false" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject3" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv3" runat="server" Font-Bold="False"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr id="tr4" runat="server" visible="False">
                                                    <td align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        <asp:Button ID="Button7" runat="server" Text="+" CssClass="btn btn-success btn-sm" OnClick="Button7_Click"
                                                            OnClientClick="if (!validatePage()) {return true;}" />
                                                        &nbsp;
                                                    </td>
                                                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree4" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            CssClass="formlbl" runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear4" runat="server" Width="45px" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject4" oncopy="return false" oncut="return false" onpaste="return false"
                                                            runat="server" ></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv4" runat="server" Font-Bold="False"></asp:Label>
                                                    </td> 
                                                </tr>
                                                <tr id="tr5" runat="server" visible="False">
                                                    <td align="center" nowrap="nowrap" valign="middle" class="style6" runat="server">
                                                        &nbsp;
                                                    </td>
                                                    <td align="center" nowrap="nowrap" valign="top" runat="server">
                                                        <asp:TextBox ID="txtDegree5" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtDegreev5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtInstitution5" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtInstitutionv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server" class="auto-style1">
                                                        <asp:TextBox ID="txtUniversity5" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtUniversityv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" class="style4" runat="server">
                                                        <asp:TextBox ID="txtPassingYear5" runat="server" CssClass="form-control"
                                                            MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPassingYearv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" align="center" runat="server">
                                                        <asp:TextBox ID="txtPercent5" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server" MaxLength="10"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtPercentv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    <td valign="top" runat="server" align="center">
                                                        <asp:TextBox ID="txtMajorSubject5" oncopy="return false" oncut="return false" CssClass="form-control"
                                                            onpaste="return false" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="txtMajorSubjectv5" runat="server" Font-Bold="False"></asp:Label>
                                                    </td>
                                                    
                                                </tr>
                                                    </tbody>
                                                </table>

                           <asp:UpdatePanel ID="updat1" runat="server">
                                                            <ContentTemplate>
                                                                
                   
                                                                     
                    
                    <asp:Button ID="Button8" CssClass="btn btn-success btn-sm" runat="server" OnClick="Updateval" Text="Update">
                    </asp:Button>
                    <asp:Label ID="lab1" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lab2" runat="server" Visible="false"></asp:Label>
                                                                       
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                          </div>
                    </div>
                       <div class="tab-pane fade" id="custom-tabs-five-normal" role="tabpanel" aria-labelledby="tab2">
                      <div class="col-lg-12 col-md-12">
                           <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CssClass="table table-hover table-bordered cus-table tabular-table " PageSize="20" 
                                DataKeyNames="intTeacher_id" onrowediting="grvDetail_RowEditing" >
                                <Columns>
                                    <asp:BoundField DataField="vchFirst_name" HeaderText="First Name" ReadOnly="True" />
                                    <asp:BoundField DataField="vchLast_name" HeaderText="Last Name" ReadOnly="True" />  
                                    <asp:BoundField DataField="intDepartment_id" HeaderText="Department" ReadOnly="True" />
                                    <asp:BoundField DataField="intMobileNo" HeaderText="Mobile" ReadOnly="True" />  
                                    <asp:TemplateField HeaderText="Edit/View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                ImageUrl="~/images/edit.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                </Columns>
                            </asp:GridView>
                          </div>

                       </div>

                      </div>
              
                   </div>  <%--card-body--%>

            </div>
        </div>
        </div>
    </div>


    </section>    
  </ContentTemplate>
        </asp:UpdatePanel>
 <section class="content" style="display:none">
    <div style="padding: 05px 0 0 0">
       
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Labnorecord" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="1015px"
                                CssClass="MyTabStyle">
                                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                                    <HeaderTemplate>
                                     </HeaderTemplate>
                                    <ContentTemplate>
                                        <div>
                                            <center>
                                                <table style="font-weight: bolder; width: 100%" align="center">
                                                    <tr>
                                                        <td rowspan="6">
                                                            <asp:Image ID="TeacherImg" AlternateText="Image" ImageUrl="images/Sample%20Photo1.jpg"
                                                                runat="server" Style="line-height: normal; height: 100px; width: 80px; margin-right: 27px;"
                                                                border="2" ToolTip="Image" />
                                                        </td>
                                                        <td align="left">
                                                            
                                                            <br />
                                                        </td>
                                                        <td align="left" nowrap="nowrap">
                                                           
                                                            <%--<asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                                                                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                                            </asp:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="Reg30" runat="server" ValidationGroup="a1" ControlToValidate="TextBox1"
                                                                Display="None" ErrorMessage="Only alphabets are allowed" Font-Bold="False" ForeColor="Red"
                                                                ValidationExpression="^[a-zA-Z]$+"></asp:RegularExpressionValidator>
                                                            &nbsp;&nbsp;
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" Enabled="True"
                                                                TargetControlID="Reg30">
                                                            </asp:ValidatorCalloutExtender>--%>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr >
                                                        <td align="left">
                                                            <asp:Label ID="Label9" runat="server" Text="Preferred Subjects" 
                                                                Font-Bold="False" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="False" Visible="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Verdana" 
                                                                CssClass="input-blue" Visible="False"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label16" runat="server" Text="Home Telephone Number 1" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label25" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="12" ValidationGroup="b" 
                                                                onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>&nbsp;&nbsp;
                                                              
                                                              
                                                               </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label17" runat="server" Text="Home Telephone Number 2" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label26" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="7" ValidationGroup="b" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>&nbsp;&nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                              </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label19" runat="server" Text="Facebook Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label28" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegE22" runat="server" ControlToValidate="TextBox13"
                                                                ValidationGroup="a1" Display="None" ErrorMessage="Enter Valid facebook id" Font-Bold="False"
                                                                ValidationExpression="^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$"></asp:RegularExpressionValidator>
                                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                                                TargetControlID="RegE22">
                                                            </asp:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label20" runat="server" Text="Twitter Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label29" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="padding-top: 10px">
                                                            <asp:Label ID="Label21" runat="server" Text="Other Url" Font-Bold="False"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label30" runat="server" Font-Bold="False"></asp:Label>
                                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="input-blue" Font-Names="Verdana"
                                                                ForeColor="Black" MaxLength="20" ValidationGroup="b"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                           </td>
                                                    </tr>
                                                    <tr id="bro1" runat="server">
                                                        <td runat="server">
                                                        </td>
                                                        <td id="img" runat="server" align="left" colspan="2">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input-blue_Brower" Style="width: 29.8%" />
                                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn" Style="position: relative;
                                                                        left: 260px;" OnClientClick="if (!validatePage()) {return true;}" Text="Upload File" />
                                                                    &nbsp;<br />
                                                                    <br />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="Button1" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 10px">
                                                        </td>
                                                        <td style="padding-top: 10px">
                                                            &nbsp;
                                                        </td>
                                                        <td align="right">
                                                           </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                    <HeaderTemplate>
                                       
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <div>
                                            <center>
                                                <table style="font-weight: bolder; width: 70%; margin: 10px 0;" align="center">
                                                    <tr>
                                                        <td align="left">
                                                           
                                                        </td>
                                                        <td align="left">
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="style3" nowrap="nowrap">
                                                           
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </ContentTemplate>
                                </asp:TabPanel>
                                <asp:TabPanel ID="TabPanel3" runat="server">
                                    <HeaderTemplate>
                                        </HeaderTemplate>
                                    <ContentTemplate>
                                        
                                    </ContentTemplate>
                                </asp:TabPanel>
                                  <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                               
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                            </asp:TabContainer>
                        </td>
                    </tr>
                </table>
          
    </div>
</section>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
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
    <style>
     .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>
    <style type="text/css">
        .style3
        {
            height: 39px;
        }
        .auto-style1
        {
            width: 241px;
        }
        .auto-style2
        {
            width: 455px;
        }
        .auto-style3
        {
            width: 494px;
        }
    </style>
</asp:Content>