<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="frmTrashAdmLectureAssign.aspx.cs" Inherits="frmTrashAdmLectureAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
        <h1>
            Lecture Schedule</h1>
        
        <ol class="breadcrumb">
            <li><a ><i ></i>Home</a></li>
            <li><a ><i ></i>Trash</a></li>
            <li><a ><i ></i>School Master</a></li>
            <li class="active">Lecture Schedule</li>
        </ol>
    </div>
    <div style="padding: 5px 0 0 15px">
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:TabContainer ID="TabContainer1" CssClass="MyTabStyle" runat="server" Width="1015px"
                                    ActiveTabIndex="0">
                                    <asp:TabPanel HeaderText="g" ID="tab" runat="server">
                                        <HeaderTemplate>
                                            List
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <center>
                                                <table width="96%" style="margin-left:2%;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="50%"  OnPageIndexChanging="grvDetail_PageIndexChanging"
                                                                DataKeyNames="intLecture_id" onrowediting="grvDetail_RowEditing" 
                                                                AllowPaging="True">
                                                                <Columns>
                                                                <asp:BoundField DataField="vchLecture_name" HeaderText="Lecture Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="intLecture_type" HeaderText="Lecture Type" ReadOnly="True" />
                                                                <asp:BoundField DataField="intStandard_id" HeaderText="Standard" ReadOnly="True" />
                                                                <asp:BoundField DataField="intDivision_id" HeaderText="Division" ReadOnly="True" />
                                                                <asp:BoundField DataField="vchDay" HeaderText="Day" ReadOnly="True" />
                                                                <asp:BoundField DataField="intPeriod_id" HeaderText="Period" ReadOnly="True" />
                                                                <asp:BoundField DataField="intTeacher_id" HeaderText="Teacher Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="intSubject_id" HeaderText="Subject Name" ReadOnly="True" />
                                                                     <asp:TemplateField HeaderText="Enable">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                                ImageUrl="~/images/edit.png" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </ContentTemplate>
                                    </asp:TabPanel>   
                                </asp:TabContainer>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

