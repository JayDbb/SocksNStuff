<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SocksNStuff.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Our Products</h2>

        <div class="row">
            <asp:Repeater ID="ProductsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 ">
                        <div class="product-card">
                            <img src='<%# Eval("Url") %>' alt='<%# Eval("Name") %>' class="img-fluid " />

                            <!-- Product details -->
                            <div class="mx-3 mt-2">
                                <h3><%# Eval("Name") %></h3>
                                <h5>ID: <%# Eval("Id") %></h5>
                                <p>Category: <%# Eval("Category") %></p>
                                <p>Price: <%# String.Format("{0:C}", Eval("Price")) %></p>
                                <hr />
                                <p><i>Description:</i></p>
                                <p><%# Eval("Description") %></p>
                                <asp:Button class="py-2 text-white cartButton" CommandArgument='<%# Eval("Id") %>' runat="server" Text="Add To Cart" OnClick="AddToCart" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>


    </div>
</asp:Content>

