<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="SocksNStuff.User.Orders" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>My Orders</h2>

        <div class="row">
            <asp:Repeater ID="OrdersRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-12 mb-3">
                        <div class="order-card p-3">
                            <h3>Order ID: <%# Eval("OrderId") %></h3>
                            <p>Date: <%# Eval("DateAdded", "{0:MMMM dd, yyyy}") %></p>
                            <p>Total: <%# String.Format("{0:C}", Eval("Total")) %></p>
                            <hr />                           
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
