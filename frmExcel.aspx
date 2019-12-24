<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="FrmExcel.aspx.cs" Inherits="FrmExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:GridView ID="grvDetail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                
                CssClass="table  tabular-table " PageSize="20" Width="100%" 
                                                                
                DataKeyNames="intInquiry_id" onrowdeleting="grvDetail_RowDeleting"  
                onrowediting="grvDetail_RowEditing" Visible="false">
                <Columns>
                
                    <asp:BoundField DataField="vchInquiry_no" HeaderText="Enquiry No" 
                        ReadOnly="True" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="dtInquiryDate" HeaderText="Enquiry Date" 
                        ReadOnly="True" ></asp:BoundField>
                            <asp:BoundField DataField="intAcademic_id" HeaderText="Academic Year" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchName" HeaderText="First Name" ReadOnly="True" ></asp:BoundField>
                   <%-- <asp:BoundField DataField="vchMiddleName" HeaderText="Middle Name" 
                        ReadOnly="True" ></asp:BoundField>--%>
                    <asp:BoundField DataField="vchLastName" HeaderText="Last Name" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="intstandard_id" HeaderText="Standard" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="dtDOB" HeaderText="D.O.B." ReadOnly="True" ></asp:BoundField>
                      <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True" ></asp:BoundField>
                      <asp:BoundField DataField="vchTelNo" HeaderText="Telephone Number" ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchFatherMobile" HeaderText="Father Mobile" 
                        ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="vchFatherEmail" HeaderText="Father Email" 
                        ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="vchFatherOccupation" HeaderText="Father Occupation" 
                        ReadOnly="True" ></asp:BoundField>
                            <asp:BoundField DataField="vchMotherName" HeaderText="Mother Name" 
                        ReadOnly="True" ></asp:BoundField>
                    <asp:BoundField DataField="vchMotherMobile" HeaderText="Mother Mobile" 
                        ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="vchMotherEmail" HeaderText="Mother Email" 
                        ReadOnly="True" ></asp:BoundField>
                        <asp:BoundField DataField="vchMotherOccupation" HeaderText="Mother Occupation" 
                        ReadOnly="True" ></asp:BoundField>
                         <asp:BoundField DataField="vchAddress" HeaderText="Address" ReadOnly="True" ></asp:BoundField>
                          <asp:BoundField DataField="vcPincode" HeaderText="Pincode" ReadOnly="True" ></asp:BoundField>
                            <asp:BoundField DataField="vchState" HeaderText="State" ReadOnly="True" ></asp:BoundField>
                              <asp:BoundField DataField="vchCity" HeaderText="City" ReadOnly="True" ></asp:BoundField>
                                <asp:BoundField DataField="vchRemark" HeaderText="Remark" ReadOnly="True" ></asp:BoundField>
                                  <asp:BoundField DataField="intAmount" HeaderText="Amount" ReadOnly="True" ></asp:BoundField>
                   <%-- <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                           <center><asp:ImageButton ID="ImgEdit" CommandName="Edit" runat="server" ImageUrl="~/images/sign/Edit.png" width="22px" Height="22px" CssClass="effi_effi" />
                        </center></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Selected Student" >
                        <ItemTemplate>
                           <center> <asp:ImageButton ID="ImgDelete" runat="server" CommandName="Delete" CausesValidation="true"                                                                           
                                                                            ImageUrl="~/images/sign/accept.png" Width="40px" Height="40px" /></center>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Rejected Student" >
                      <ItemTemplate>
                          <center>  <asp:ImageButton ID="ImgUpdate" runat="server" CommandName="Update" CausesValidation="true"                                                                          
                                                                            ImageUrl="~/images/sign/Reject.png" Width="40px" Height="40px" />
                        </center></ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" ShowFooter="true" Visible="false" >
                                                                <Columns>
                                                                                                               <asp:BoundField DataField="Rollno" HeaderText="SR. No" ReadOnly="True" />
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Standard_name" HeaderText="Standard name" ReadOnly="True" />
                                                                <asp:BoundField DataField="DivisionName" HeaderText="Division Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="mnthcount" HeaderText="Month Count" ReadOnly="True" />
                                                              <%--  <asp:BoundField DataField="Admissionfee" HeaderText="Receivable Admission Fee (RS.)" ReadOnly="True" />
                                                                <asp:BoundField DataField="paid Admission Fee" HeaderText="Paid Admission Fee (Rs.)" ReadOnly="True" />
                                                                <asp:BoundField DataField="Admconcession" HeaderText="Concession Admission Fee (Rs.)" ReadOnly="True" />
--%>

                                                                <asp:BoundField DataField="Annualfee" HeaderText="Receivable Annual Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Annual Fee" HeaderText="Paid Annual Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="Anuconcession" HeaderText="Concession Annual Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="annuloutstanding" HeaderText="Outstanding Annual Fee (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="annulAdvance" HeaderText="Advance Annual Fee (Rs.)"  ReadOnly="True" />

                                                                    <asp:BoundField DataField="PhotoInsurancefee" HeaderText="Receivable Photo and Insurance (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Photo and Insurance" HeaderText="Paid Photo and Insurance (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="photoconcession" HeaderText="Concession Photo and Insurance (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="photooutstanding" HeaderText="Outstanding Photo and Insurance (Rs.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="photoAdvance" HeaderText="Advance Photo and Insurance (Rs.)"  ReadOnly="True" />


                                                                    <asp:BoundField DataField="CurrentReceivableMonthfee" HeaderText="Receivable Tuition Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="paid Tuition Fee" HeaderText="Paid Tuition Fee (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="tuitconcession" HeaderText="Concession Tuition Fee (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="tuitionoutstanding" HeaderText="Outstanding Tuition Fee (RS.)"  ReadOnly="True" />
                                                                    <asp:BoundField DataField="tuitionAdvance" HeaderText="Advance Tuition Fee (RS.)"  ReadOnly="True" />


                                                                  <%--  <asp:BoundField DataField="currentreceivabletransport" HeaderText="Receivable Transport Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Paid Transportation Fee" HeaderText="Paid Transport Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Transportconcession" HeaderText="Concession Transport Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="transportoutstanding" HeaderText="Outstanding Transport Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="transportAdvance" HeaderText="Advance Transport Fee (RS.)" ReadOnly="True" />
--%>
                                                                    <asp:BoundField DataField="currentreceivableexamfee" HeaderText="Receivable Exam Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Paid Exam fee" HeaderText="Paid Exam fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="Examconcession" HeaderText="Concession Exam fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="examoutstanding" HeaderText="Outstanding Exam fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="examAdvance" HeaderText="Advance Exam fee (RS.)" ReadOnly="True" />


                                                                    
                                                                    <asp:BoundField DataField="Total fee" HeaderText="Receivable Total Fee (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="PaidtotalFee" HeaderText="Paid Total (RS.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="TotalConcession" HeaderText="Total Concession (RS.)" ReadOnly="True" />

                                                                    <asp:BoundField DataField="totaloutstanding" HeaderText="Due Fee (Rs.)" ReadOnly="True" />
                                                                    <asp:BoundField DataField="totalAdvance" HeaderText="Advancs (RS.)" ReadOnly="True" />
                                                                    
                                                                </Columns>
                                                            </asp:GridView>

                                                  <asp:GridView ID="grdFeeM" runat="server" CssClass="table  tabular-table " EmptyDataText="No Fee Paid Yet"
                                                        Width="80%" ShowFooter="true" Visible="false">
                                                    </asp:GridView>

                                                     <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                CssClass="table  tabular-table " PageSize="20" Width="100%" ShowFooter="true" >
                                                                <Columns>
                                                                 <asp:BoundField DataField="Rollno" HeaderText="SR. No" ReadOnly="True" />
                                                                <asp:BoundField DataField="StuName" HeaderText="Student Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="Standard_name" HeaderText="Standard name" ReadOnly="True" />
                                                                <asp:BoundField DataField="DivisionName" HeaderText="Division Name" ReadOnly="True" />
                                                                <asp:BoundField DataField="paid_Misc_Fee" HeaderText="Misc Fee (RS)" ReadOnly="True" />
                                                                <asp:BoundField DataField="paid_Late_Fee" HeaderText="Late Fee (RS.)" ReadOnly="True" />
                                                                 <asp:BoundField DataField="Admission_Fee" HeaderText="Admission Fee (RS.)" ReadOnly="True" />
                                                                <asp:BoundField DataField="Transport_Fee" HeaderText="Transport Fee (RS.)" ReadOnly="True" />
                                                                 
                                                                    
                                                                </Columns>
                                                            </asp:GridView>


                                                            
                                                            <asp:GridView ID="GridViewliststud" runat="server" designer:wfdid="w36"
                                                                
                                                                AutoGenerateColumns="False" CssClass="table  tabular-table" 
                                                                DataKeyNames="intStudent_id" EmptyDataText="Record not Found." 
                                                                Width="100%">
                                                                <AlternatingRowStyle CssClass="alt" />
                                                                <Columns>
                                                                  
                                                                    <asp:TemplateField HeaderText="Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" Text="Delete" AlternateText="Details" ToolTip="Click"
                                                                                Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Parents Details" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnpareDetails" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                ImageUrl="images/icon_edit.png" align="center" Text="parets" AlternateText="Details"
                                                                                ToolTip="Click" Style="width: 20px !important;" ForeColor="#CC0000" /></ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="intStudent_id" HeaderText="ID" ReadOnly="True" />
                                                                     <asp:BoundField DataField="receipt_no" HeaderText="Serial Number" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intstanderd_id" HeaderText="Standard" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intDivision_id" HeaderText="Division" Visible="true" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intRollNo" HeaderText="Roll No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="name" HeaderText="Student Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchEmail" HeaderText="Email ID" ReadOnly="True" Visible="false"  />
                                                                    <asp:BoundField DataField="dtDOB" HeaderText="Date of Birth" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchGender" HeaderText="Gender" ReadOnly="True"  />
                                                                    <asp:BoundField DataField="chrBloodGrp" HeaderText="Blood Group" ReadOnly="True" Visible="false"  />
                                                                    <asp:BoundField DataField="vchReligion" HeaderText="Religion" ReadOnly="True" Visible="false"   />
                                                                    <asp:BoundField DataField="vchPlaceofBirth" HeaderText="Place Of Birth" ReadOnly="True" visible="false" />
                                                                     <asp:BoundField DataField="vchFatherName" HeaderText="Father Name" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchMotherName" HeaderText="Mother Name" ReadOnly="True" />
                                                                    <asp:BoundField DataField="intFatherMobile" HeaderText="Father Mobile No" ReadOnly="True" />
                                                                    <asp:BoundField DataField="vchpresentAddress" HeaderText="Present Address" ReadOnly="True" />
                                                                     <asp:BoundField DataField="vchaadhar_no" HeaderText="Aadhar Card Number" ReadOnly="True" />
                                                                      <asp:BoundField DataField="vchcategory" HeaderText="Cast" ReadOnly="True" />
                                                                     
                                                                    <asp:TemplateField HeaderText="Edit" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgEdit" runat="server" Style="width: 18px !important;" ImageUrl="~/images/edit.png"
                                                                                CommandName="Edit" CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Delete" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImgDelete" runat="server" Style="width: 22px !important;" ImageUrl="~/images/delete.png"
                                                                                CommandName="Delete" OnClientClick="return confirm(&quot;Are you sure you want delete the user?&quot;);"
                                                                                CausesValidation="false" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="pgr" />
                                                            </asp:GridView>
    <asp:GridView ID="GridView3" runat="server">
    </asp:GridView>
</asp:Content>

