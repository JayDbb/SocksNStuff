<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SocksNStuff.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="d-flex">
            <h2>Users</h2>
            <asp:LinkButton runat="server" class="ml-3 text-white text-center rounded-2" 
                style="text-decoration:none;margin-left: 15px; margin-top: 5px; width: 30px; height: 30px; background-color: cadetblue;">+</asp:LinkButton>
        </div>

        <div class="row">
            <asp:Repeater ID="UsersRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="product-card p-3">
                            <!-- User details -->
    <h3><%# String.Format("{0} {1}", Eval("fname"), Eval("lname")) %></h3>
                            <p>Email: <%# Eval("email") %></p>
                            <p>Created At: <%# Eval("createdAt", "{0:MMMM dd, yyyy}") %></p>
                            <hr />
                            <asp:Button class="py-2 my-2 text-white btn btn-info" CommandArgument='<%# Eval("Id") %>' 
                                runat="server" Text="Edit"  />
                            <asp:Button class="py-2 my-2 text-white btn btn-danger" data-toggle="modal" data-target="#deleteUserModal" CommandArgument='<%# Eval("Id") %>' 
                                runat="server" Text="Delete"  />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    
</asp:Content>
