<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookissue.aspx.cs" Inherits="LibraryManagement.bookissue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <div class="row">
            <div class="col-4">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/imgs/books.png"  width="100px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>                                    
                                </div>
                            </div>                        
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Book ID" ></asp:TextBox>
                                    <asp:Button class="btn btn-primary " ID="Button1" runat="server" Text="Go" OnClick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">                                  
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Member Name" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                        
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">    
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Book Name" ReadOnly="True"></asp:TextBox>                                    
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">                                  
                                     <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="End Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                
                               <div class="form-group">
                                    
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button3" runat="server" Text="Issue" OnClick="Button3_Click" />
                                    
                                </div>
                                
                            </div>

                            <div class="col-md-6">
                                
                               <div class="form-group">
                                   
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" Text="Return" OnClick="Button2_Click" />
                                    
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
                
                
               
            </div>

            <div class="col-8">
                 <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                                                
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:elibraryDBConnectionString %>' SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView AlternatingRowStyle-CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<AlternatingRowStyle CssClass="table table-striped table-bordered"></AlternatingRowStyle>
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
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
