<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="SocksNStuff.Order1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8 col-sm-12">
                <div class=" shadow-sm">
                    <div class="card-header text-white rounded-2 p-2 text-center" style="background-color:cadetblue;">
                        <h4 class="mb-0">Thank You for Your Order!</h4>
                    </div>
                    <div class="card-body text-center mt-2">
                        <h5 class="mb-4">Your order has been placed successfully.</h5>
                        
                        <p class="lead text-white">Order Number: <strong><asp:Label runat="server" ID="OrderNumberLabel" /></strong></p>
                        <p class="leadtext-white">Order Total: <strong><asp:Label runat="server" ID="OrderTotalLabel" /></strong></p>
                        
                        <p class="text-muted">You will receive a confirmation email shortly with the details of your purchase.</p>
                        
                        <asp:Button runat="server" Text="Continue Shopping" CssClass="btn btn-primary btn-lg mt-4" PostBackUrl="~/Products.aspx" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


