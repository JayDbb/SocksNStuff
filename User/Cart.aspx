<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SocksNStuff.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <h2 class="mb-4">Shopping Cart</h2>
        <div class="row">
            <div class="col-md-8 col-sm-12">
                <asp:Panel runat="server" ID="CartItemsPanel">
                    <div class="card shadow-sm">
                        <div class="card-header text-white" style="background-color:cadetblue">
                            <h5 class="mb-0">Cart Items</h5>
                        </div>
                        <div class="card-body p-0 table-responsive"> <!-- Add table-responsive for mobile -->
                            <table class="table table-striped mb-0">
                                <thead class="thead-light">
                                    <tr>
                                        <th>Product</th>
                                        <th>Quantity</th>
                                        <th>Price</th>
                                        <th>Total</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="CartItemsRepeater">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Name") %></td>
                                                <td>
                                                    <asp:HiddenField ID="ProductIDHiddenField" runat="server" Value='<%# Eval("Id") %>' />

                                                    <!-- Update the input style for mobile responsiveness -->
                                                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="ChangeQuantity" CssClass="form-control form-control-sm" Text='<%# Eval("Quantity") %>' />
                                                           <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                                                    <%--<input onchange="ChangeQuantity" type="number" class="form-control form-control-sm" value='<%# Eval("Quantity") %>' min="1" />--%>
                                                </td>
                                                <td><%# String.Format("{0:C}", Eval("Price")) %></td>
                                                <td><%# String.Format("{0:C}", Eval("totalPrice")) %></td>
                                                <td>
                                                    <asp:Button runat="server" Text="Remove" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClick="RemoveItem" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <div class="col-md-4 col-sm-12 mt-4 mt-md-0">
                <div class="card shadow-sm">
                    <div style="background-color:cadetblue" class="card-header text-white">
                        <h5 class="mb-0 text-center text-md-start">Cart Summary</h5>
                    </div>
                    <div class="card-body" style="color: black">
                        <p class="d-flex justify-content-between">
                            <span>Subtotal:</span>
                            <span><asp:Label runat="server" ID="SubtotalLabel" Text="$0.00"></asp:Label></span>
                        </p>
                        <p class="d-flex justify-content-between">
                            <span>Tax (10%):</span>
                            <span><asp:Label runat="server" ID="TaxLabel" Text="$0.00"></asp:Label></span>
                        </p>
                        <hr />
                        <h5 class="d-flex justify-content-between">
                            <span>Total:</span>
                            <span><asp:Label runat="server" ID="TotalLabel" Text="$0.00"></asp:Label></span>
                        </h5>
                        <!-- Add mobile-friendly button -->
                        <asp:Button runat="server" Text="Checkout" CssClass="btn btn-success btn-block mt-3" OnClick="Checkout" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
