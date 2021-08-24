<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="hrEmployeeSalary.aspx.cs" Inherits="hrEmployeeSalary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mGrid th
        {
            text-align: center !important;
        }
        .style1
        {
            width: 121px;
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
                        <asp:TabContainer runat="server" CssClass="MyTabStyle" ID="TBC"  Width="1015px" 
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
    <caption>
        &nbsp;
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                        CssClass="table  tabular-table " Width="50%" AllowPaging="True" 
                                                        DataKeyNames="intEmployeeSalaryId" 
                                                        onpageindexchanging="grvDetail_PageIndexChanging" 
                                                        onrowediting="grvDetail_RowEditing" onrowdeleting="grvDetail_RowDeleting" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="intEmployeeSalaryId" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("intEmployeeSalaryId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="VchMonthName" HeaderText="Month Name" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Role" HeaderText="Role" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="employee_name" HeaderText="Employee Name" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Designation" HeaderText="Designation" 
                                                                ReadOnly="True">
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" CausesValidation="true" OnClientClick="return confirm('Do You Really Want To Edit Selected Record ?');"
                                                                     ImageUrl="~/images/edit.png" />
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
                                                </td>
    </tr>
</caption>
</table>
</left>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel1">
                                        <HeaderTemplate>
                                            New Entry
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            
                                            <div class="row">
                       

                                                <table width="36%" style="text-align: right; margin:0 0 0 10%;">
                                                    <tr>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                        <td align="justify">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                   <tr>
                                                        <td align="justify">
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
                                                        <td align="justify">
                                                            <asp:Label ID="Label4" runat="server" Text="Employee Name"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlEmployee" runat="server" AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px">
                                                                
                                                            </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEmployee"
                                                                Display="None" ErrorMessage="Please  select Employee"></asp:RequiredFieldValidator>
                                                        
                                                        </td>
                                                    </tr>
                                                   


                                                   
                                                     
                                                 
                                                 <tr>
                                                        <td align="justify">
                                                            <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label>
                                                        </td>
                                                        <td align="justify">
                                                            <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" 
                                                                CssClass="input-blue" Height="38px">
                                                                <asp:ListItem Value="0">--Select---</asp:ListItem>
                                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                                <asp:ListItem Value="12">December</asp:ListItem>


                                                            </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlmonth"
                                                                Display="None" ErrorMessage="Please  select Month"></asp:RequiredFieldValidator>
                                                 
                                                        </td>
                                                    </tr>


                                                    

                                                    <tr>
                                                    <td>&nbsp;</td>
                                                        <td align="left" >
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" >
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="vclassrooms_send"
                                                                             OnClientClick="return ConfirmInsertUpdate();" onclick="btnSubmit_Click" />
                                                                    </td>
                                                                    <td align="left" style="padding-left:10px">
                                                                        <asp:Button ID="btnClear" runat="server"  Style="padding-left: 10px"
                                                                            CssClass="vclassrooms_send" Text="Clear" CausesValidation="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>




                                                    <tr>
                                                        <td align="center" class="auto-style5" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                    </tr>

                                                    
                                                </table>
                                          </div>
                                          

 
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
