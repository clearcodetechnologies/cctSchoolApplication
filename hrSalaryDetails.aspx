<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="hrSalaryDetails.aspx.cs" Inherits="hrSalaryDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
        .style1
        {
            width: 115px;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function confirmMsg() {
            var btn = document.getElementById("<%=btnSubmit.ClientID %>").value;
            if (btn == 'Submit') {
                var msg = confirm('Do You Really Want To Save Entered Record ?');
                if (msg) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                var msg = confirm('Do You Really Want To Update Entered Record ?');
                if (msg) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header pd-0">
        <ul class="top_nav">
            <li><a>Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a></li>
            <li><a>Asset Master <i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
            </li>
            <li><a href="frmBuildingMaster.aspx">Building Master </a></li>
            <li class="active1"><a href="frmWingMaster.aspx">Wing Master</a></li>
            <li><a href="frmFloorMaster.aspx">Floor Master</a></li>
            <li><a href="frmRoomMaster.aspx">Room Master</a></li>
            <li><a href="frmEquipItemMaster.aspx">Item Master</a></li>
            <li><a href="frmItemTypeMaster.aspx">Item Details Master</a></li>
        </ul>
    </div>
    <section class="content">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left">
                         <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC" Width="100%" 
                            ActiveTabIndex="1">
                            <asp:TabPanel runat="server" ID="TB1">
                                <HeaderTemplate>
                                    Details
                                </HeaderTemplate>
                                <ContentTemplate>


                                 <table width="30%" style="margin:0 0 0 2%;">
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label1" runat="server" Text="Role"></asp:Label>
                                                    </td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="drpRole" runat="server" AutoPostBack="True" onselectedindexchanged="drpRole_SelectedIndexChanged" 
                                                             ></asp:DropDownList>
                                                    </td>
                                                </tr>  
                                                </table>

                                    <left>
<table width="100%">
    <tr>
        <td align="left">
            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="50%" AllowPaging="True" 
                                                        DataKeyNames="IntSalaryId" 
                                                        onpageindexchanging="grvDetail_PageIndexChanging" 
                                                        onrowediting="grvDetail_RowEditing" onrowdeleting="grvDetail_RowDeleting" >
                <Columns>
                    <asp:BoundField  DataField="vchDesignation" HeaderText="Designation" 
                        ReadOnly="True" >
                    </asp:BoundField>
                    <asp:BoundField DataField="employee_name" HeaderText="Employee name" 
                        ReadOnly="True" >
                    </asp:BoundField>
                    <asp:BoundField DataField="vchPayHeadName" HeaderText="PayHeadName" 
                        ReadOnly="True" >
                    </asp:BoundField>
                    <asp:BoundField DataField="vchUnit" HeaderText="vchUnit" ReadOnly="True" >
                    </asp:BoundField>
                    <asp:BoundField DataField="intAddition" HeaderText="Addition" ReadOnly="True" >
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" CausesValidation="true" OnClientClick="return confirm('Do You Really Want To Edit Selected Record ?');"
                                                                     ImageUrl="~/images/edit.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IntSalaryId" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId" Text='<%#Eval("IntSalaryId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"
                                                                        OnClientClick="return confirm('Do You Really Want To Delete Selected Record ?');"
                                                                        ImageUrl="~/images/delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </td>
    </tr>
</table>
</left>
                                </ContentTemplate>
                            </asp:TabPanel>
                                       <asp:TabPanel runat="server" ID="TB2">
                                <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            
                                                <table width="40%"  style="text-align: right; margin:0 0 0 10%;">
                                                    <tr>
                                                        <td align="justify" class="style1" >
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td align="justify" class="style1">
                                                            <asp:Label ID="Label6" runat="server" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px" 
                                                                onselectedindexchanged="ddlDesignation_SelectedIndexChanged">
                                                                
                                                            </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDesignation"
                                                                Display="None" ErrorMessage="Please Designation"></asp:RequiredFieldValidator>
                                                        



                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td align="justify" class="style1">
                                                            <asp:Label ID="Label4" runat="server" Text="Employee Name"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlEmployee" runat="server"  AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px" onselectedindexchanged="ddlEmployee_SelectedIndexChanged" 
                                                               >
                                                               
                                                                
                                                               
                                                            </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmployee"
                                                                Display="None" ErrorMessage="Please  select Employee"></asp:RequiredFieldValidator>
                                                        
                                                        </td>
                                                    </tr>


                                                      <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label5" runat="server" Text="Payhead Master"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlPayheadMaster" runat="server"  AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px">
                                                               
                                                            </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlPayheadMaster"
                                                                Display="None" ErrorMessage="Please PayheadMaster"></asp:RequiredFieldValidator>
                                                        



                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="Unit"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:TextBox ID="txtUnit" runat="server" CssClass="input-blue" 
                                                                MaxLength="50" ToolTip="Enter Unit Here" Height="38px"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                                Enabled="True" FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" 
                                                                TargetControlID="txtUnit" ValidChars=" ">
                                                            </asp:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUnit"
                                                                Display="None" ErrorMessage="Please enter Unit"></asp:RequiredFieldValidator>
                                                       
                                                        </td>
                                                    </tr>
                                                    

                                                     <tr>
                                                        <td align="justify" class="style1">
                                                            <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                  
                                                  <asp:DropDownList ID="ddlType" CssClass="input-blue" runat="server" AutoPostBack="True" Height="38px">
                                                      <asp:ListItem Value="0">Addition</asp:ListItem>
                                                      <asp:ListItem Value="1">Deduction</asp:ListItem>
                                                            </asp:DropDownList>

                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlType"
                                                                Display="None" ErrorMessage="Please Selact Type"></asp:RequiredFieldValidator>
                                                     
                                                        </td>
                                                    </tr>
                                                    






                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;

                                                            <asp:GridView ID="grvDetailAmout" runat="server" AllowPaging="True" 
                                                                AllowSorting="True" AutoGenerateColumns="False" 
                                                                CssClass="table  tabular-table " DataKeyNames="PayHead_Id" Width="50%">
                                                                <Columns>
                                                                <asp:TemplateField HeaderText="Select">
                                           <ItemTemplate>
                                               
                                               <asp:CheckBox ID="CheckBox1" ForeColor="Black"  Checked="true" runat="server" />
                                           </ItemTemplate>
                                       </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="PayHeadId" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPayHead_Id" runat="server" Text='<%# Bind("PayHead_Id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="vchPayHeadName" HeaderText="Pay Head" 
                                                                        ReadOnly="True" />
                                                                    <asp:TemplateField HeaderText="Pay Head">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtvchUnit" runat="server" Text="0"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Type">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddltypeAddition" runat="server" Width="100px">
                                                                                <asp:ListItem Value="0">Addition</asp:ListItem>
                                                                                <asp:ListItem Value="1">Deduction</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>


                                                        </td>
                                                    </tr>


                                                    <tr>
                                                    <td class="style1">&nbsp;</td>
                                                        <td align="left" >
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" >
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="efficacious_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px"
                                                                            CssClass="efficacious_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            
                                            

                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
     
    </section>
</asp:Content>
