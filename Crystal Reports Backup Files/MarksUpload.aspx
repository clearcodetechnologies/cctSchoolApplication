<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="MarksUpload.aspx.cs" Inherits="MarksUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="container py-3">  
            <h2 class="text-center text-uppercase">Marks Upload from Excel </h2>  
            <div class="card">  
                <div class="card-header bg-primary text-uppercase text-white">  
                    <h5>Import Excel File</h5>  
                </div>  
                <div class="card-body">  
                    <button style="margin-bottom:10px;" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">  
                        <i class="fa fa-plus-circle"></i> Import Excel  
                    </button> 
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>  
                    <div class="modal fade" id="myModal">  
                        <div class="modal-dialog">  
                            <div class="modal-content">  
                                <div class="modal-header">  
                                    <h4 class="modal-title">Import Excel File</h4>  
                                    <button type="button" class="close" data-dismiss="modal">×</button>  
                                </div>  
                                <div class="modal-body">  
                                    <div class="row">  
                                        <div class="col-md-12">  
                                            <div class="form-group">  
                                                <label>Choose excel file</label>  
                                                <div class="input-group">  
                                                    <div class="custom-file">  
                                                        <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input" runat="server" />  
                                                        <label class="custom-file-label"></label>  
                                                    </div>  
                                                    <script>
                                                        $('#FileUpload1').on('change', function () {
                                                            //get the file name
                                                            var fileName = $(this).val();
                                                            var cleanFileName = fileName.replace('C:\\fakepath\\', " ");
                                                            //replace the "Choose a file" label
                                                            $(this).next('.custom-file-label').html(cleanFileName);
                                                        })
        </script>
                                                    <label id="filename"></label>  
                                                    <div class="input-group-append">  
                                                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-outline-primary" Text="Upload" OnClick="btnUpload_Click" />  
                                                    </div>  
                                                </div>  
                                                <asp:Label ID="lblMessage" runat="server"></asp:Label>  
                                            </div>  
                                        </div>  
                                    </div>  
                                </div>  
                                <div class="modal-footer">  
                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>  
                                </div>  
                            </div>  
                        </div>  
                    </div>  
                    <asp:GridView ID="GridView1" HeaderStyle-CssClass="bg-primary text-white" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered``">  
                        <EmptyDataTemplate>  
                            <div class="text-center">No record found</div>  
                        </EmptyDataTemplate>  
                        <Columns>  
                            <asp:BoundField HeaderText="ID" DataField="ID" />  
                            <asp:BoundField HeaderText="Name" DataField="Name" />  
                            <asp:BoundField HeaderText="Position" DataField="Position" />  
                            <asp:BoundField HeaderText="Office" DataField="Office" />  
                            <asp:BoundField HeaderText="Salary" DataField="Salary" />  
                        </Columns>  
                    </asp:GridView>  
                </div>  
            </div>  
        </div>  

</asp:Content>

