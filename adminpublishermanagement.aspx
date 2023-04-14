<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="LibraryManagement.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
      
          //$(document).ready(function () {
              //$('.table').DataTable();
         // });
      
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          //$('.table1').DataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/imgs/publisher.png"  width="100px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary " ID="Button1" runat="server" Text="Go" OnClick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>
                        
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Publisher Name" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                
                               <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                                    </a>
                                </div>
                                
                            </div>

                            <div class="col-md-4">
                                
                               <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <asp:Button class="btn btn-warning btn-block btn-lg" ID="Button3" runat="server" Text="Upadte" OnClick="Button3_Click" />
                                    </a>
                                </div>
                                
                            </div>

                            <div class="col-md-4">
                                
                               <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                                    </a>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"> << Back to Home</a>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>

            <div class="col-md-7">
                 <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher List</h4>
                                    <img src="img/imgs/publisher.png"  width="50px"/>
                               
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                            </div>
                        </div>
                         

                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>
