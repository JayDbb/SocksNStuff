<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SocksNStuff._Default" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron text-center">
        <h1>Welcome to Our Online Store!</h1>
        <p>Discover our featured products.</p>
        <a href="Products.aspx" class="btn btn-primary">Browse More Products</a>
        <hr />



        <div class="row">
            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://i5.walmartimages.com/asr/9717a431-b321-4e7a-9c4e-ec9d2a060a09.e7c3fffce5cb0a802c8bffb42617914b.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF" alt="Product 4" class="img-fluid">
                    <div class="mx-3">
                    <h3>Skelly Sock Shenanigans</h3>
                    <h5>ID: 4</h5>
                    <p>Category: Spooky Socks</p>
                    <p>Price: $9.99</p>
                        <hr />
                    <p><i>Description:</i></p>
                    <p>Women's crossbones sock for those days when you feel like toe-tally owning the pirate look!</p>
                  
                         <asp:Button class="py-2 text-white cartButton" id="cartButton" CommandArgument="4" runat="server" Text="Add To Cart" OnClick="AddToCart" />

</div>                    
                </div>
            </div>
            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://thelagaadi.com/cdn/shop/files/Colorful-Rainbow-Socks-4_169b5d06-cdcd-4899-9e67-1f726043baf6.jpg?v=1707818481&width=1080" alt="Product 5" class="img-fluid">
                    <div class="mx-3">
                    <h3>Guac & Sock</h3>
                    <h5>ID: 5</h5>
                    <p>Category: Fruity Footwear</p>
                    <p>Price: $11.99</p>
                        <hr />
<p><i>Description:</i></p>
                    <p>Men's avocado pattern sock. Perfect for making your sock drawer look a little extra, like your favorite toast.</p>
                         <asp:Button class="py-2 text-white cartButton" id="Button1" CommandArgument="5" runat="server" Text="Add To Cart" OnClick="AddToCart" />

               </div>

                </div>
            </div>
            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://m.media-amazon.com/images/I/61c2WmfHfvL._AC_SY580_.jpg" alt="Product 6" class="img-fluid">
                    <div class="mx-3">
                    <h3>Woolly Warm Wonders</h3>
                    <h5>ID: 6</h5>
                    <p>Category: Cozy Toes</p>
                    <p>Price: $8.99</p>
                        <hr />
                    <p><i>Description:</i></p>
                    <p>Cozy woolen socks to keep your toes toasty, no matter how cold it gets. Perfect for socking it to winter!</p>
                         <asp:Button class="py-2 text-white cartButton" id="Button2" CommandArgument="6" runat="server" Text="Add To Cart" OnClick="AddToCart" />
               
                        </div>
                    </div>
            </div>

        </div>


    </div>

</asp:Content>
