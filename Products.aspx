<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SocksNStuff.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Our Products</h2>

        <div class="row">
            <div class="col-md-4 ">
                <div class="product-card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZFz3vnT_pJeis4P7YsgPXYduK1tZKujyr8A&s" alt="Product 1" class="img-fluid">
                    <div class="mx-3">
                        <h3>Toe-tal Tech Triumph</h3>
                        <h5>ID: 1</h5>
                        <p>Category: Sock Gadgets</p>
                        <p>Price: $199.99</p>
                        <p><i>Description:</i></p>
                        <p>A futuristic gadget that looks like a sock but powers your electronics! Who knew socks could be so shocking?</p>

                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyqyrTwmFR0QnKSgvMXH4TOzoLwC_RTosR1w&s" alt="Product 2" class="img-fluid">
                    <div class="mx-3">
                        <h3>Sock Couture Supreme</h3>
                        <h5>ID: 2</h5>
                        <p>Category: Fancy Feet Apparel</p>
                        <p>Price: $49.99</p>
                        <p><i>Description:</i></p>
                        <p>A sock-inspired fashion piece that elevates your wardrobe. Finally, an excuse to wear socks to a formal event!</p>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbE90WuRg2drnoHqlxUeHeX7aO1IrWSHEBKtYg1iKnf62FH4Z-MRScSvKqboooyODBsx0&usqp=CAU" alt="Product 3" class="img-fluid">
                    <div class="mx-3">
                        <h3>Sock-tastic Home Helper</h3>
                        <h5>ID: 3</h5>
                        <p>Category: Sock-cessories</p>
                        <p>Price: $299.99</p>
                        <p><i>Description:</i></p>
                        <p>The sock that folds socks for you! Say goodbye to mismatched socks and hello to perfection.</p>
                    </div>

                </div>
            </div>


            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://i5.walmartimages.com/asr/9717a431-b321-4e7a-9c4e-ec9d2a060a09.e7c3fffce5cb0a802c8bffb42617914b.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF" alt="Product 4" class="img-fluid">
                    <div class="mx-3">
                        <h3>Skelly Sock Shenanigans</h3>
                        <h5>ID: 4</h5>
                        <p>Category: Spooky Socks</p>
                        <p>Price: $9.99</p>
                        <p><i>Description:</i></p>
                        <p>Women's crossbones sock for those days when you feel like toe-tally owning the pirate look!</p>
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
                        <p><i>Description:</i></p>
                        <p>Men's tropical pattern sock. Perfect for making your sock drawer look a little extra, like your favorite rainbow.</p>
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
                        <p><i>Description:</i></p>
                        <p>Cozy woolen socks to keep your toes toasty, no matter how cold it gets. Perfect for socking it to winter!</p>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://www.crazysocks.com/cdn/shop/products/rainbow-metallic-socks-small_1200x.jpg?v=1595977722" alt="Product 7" class="img-fluid">
                    <div class="mx-3">
                        <h3>Stripey Sock Spectacle</h3>
                        <h5>ID: 7</h5>
                        <p>Category: Funky Feet</p>
                        <p>Price: $12.99</p>
                        <p><i>Description:</i></p>
                        <p>Striped pattern socks that bring the party to your feet. Because sometimes your toes just need to dance!</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7OWX7mvtVe_L6Fh0mnYpHrNjxMZ4YMykSJA&s" alt="Product 8" class="img-fluid">
                    <div class="mx-3">
                        <h3>Pedal Pusher Prints</h3>
                        <h5>ID: 8</h5>
                        <p>Category: Sockcycle</p>
                        <p>Price: $10.99</p>
                        <p><i>Description:</i></p>
                        <p>Unisex bicycle print socks for the stylish cyclist who likes to keep their sock game on a roll.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="product-card">
                    <img src="https://www.gripgrab.com/cdn/shop/products/3020_01_1800x1800.jpg?v=1649074892" alt="Product 9" class="img-fluid">
                    <div class="mx-3">
                        <h3>Sock Safari</h3>
                        <h5>ID: 9</h5>
                        <p>Category: Wild Socks</p>
                        <p>Price: $13.99</p>
                        <p><i>Description:</i></p>
                        <p>Black And White print socks that make you feel like the king or queen of the sock jungle!</p>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

