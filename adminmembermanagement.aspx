<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="LibraryManagement.membermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      //$(document).ready(function () {
      //    $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      //});
        $(document).ready(function () {
            $('member_master_tbl').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container-fluid">
        <div class="row">
            <div class="col-5">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/imgs/generaluser.png"  width="100px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>                                    
                                    <asp:Button class="btn btn-primary " ID="Button3" runat="server" Text="Go" OnClick="Button3_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" placeholder="Member Name" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mr-1" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton class="btn btn-primary mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-danger mr-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="DOB"  TextMode="Date" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" placeholder="Conatct Number" TextMode="Phone" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" placeholder="Email ID" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="State" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" placeholder="City" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                        
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">    
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Pincode" TextMode="Phone" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Full Postal Address</label>
                                <div class="form-group">                                  
                                     <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" placeholder=" Postal Adress"  ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        
                           
                        </div>

                        <div class="row">
                            <div class="col-12">
                                
                               <div class="form-group">
                                    
                                        <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button1" runat="server" Text="Delete User Permanently" OnClick="Button1_Click" />
                                   
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
             
               
            </div>

            <div class="col-7">
                 <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                                                
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" SelectCommand="SELECT [full_name], [email], [member_id], [account_status] FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Id" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account status" SortExpression="account_status" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                         

                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>
