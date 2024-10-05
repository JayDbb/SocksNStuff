using Newtonsoft.Json;
using SocksNStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public class BasePage:Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session["AllItems"] == null)
            {

                List<Product> products = new List<Product>{
            new Product
            {
                Id = 1,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZFz3vnT_pJeis4P7YsgPXYduK1tZKujyr8A&s",
                ProductName = "Toe-tal Tech Triumph",
                Description = "A futuristic gadget that looks like a sock but powers your electronics! Who knew socks could be so shocking?",
                Price = 199.99M
            },
            new Product
            {
                Id = 2,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyqyrTwmFR0QnKSgvMXH4TOzoLwC_RTosR1w&s",
                ProductName = "Sock Couture Supreme",
                Description = "A sock-inspired fashion piece that elevates your wardrobe. Finally, an excuse to wear socks to a formal event!",
                Price = 49.99M
            },
            new Product
            {
                Id = 3,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbE90WuRg2drnoHqlxUeHeX7aO1IrWSHEBKtYg1iKnf62FH4Z-MRScSvKqboooyODBsx0&usqp=CAU",
                ProductName = "Sock-tastic Home Helper",
                Description = "The sock that folds socks for you! Say goodbye to mismatched socks and hello to perfection.",
                Price = 299.99M
            },
            new Product
            {
                Id = 4,
                Image = "https://i5.walmartimages.com/asr/9717a431-b321-4e7a-9c4e-ec9d2a060a09.e7c3fffce5cb0a802c8bffb42617914b.jpeg?odnHeight=768&odnWidth=768&odnBg=FFFFFF",
                ProductName = "Skelly Sock Shenanigans",
                Description = "Women's crossbones sock for those days when you feel like toe-tally owning the pirate look!",
                Price = 9.99M
            },
            new Product
            {
                Id = 5,
                Image = "https://thelagaadi.com/cdn/shop/files/Colorful-Rainbow-Socks-4_169b5d06-cdcd-4899-9e67-1f726043baf6.jpg?v=1707818481&width=1080",
                ProductName = "Guac & Sock",
                Description = "Men's tropical pattern sock. Perfect for making your sock drawer look a little extra, like your favorite rainbow.",
                Price = 11.99M
            },
            new Product
            {
                Id = 6,
                Image = "https://m.media-amazon.com/images/I/61c2WmfHfvL._AC_SY580_.jpg",
                ProductName = "Woolly Warm Wonders",
                Description = "Cozy woolen socks to keep your toes toasty, no matter how cold it gets. Perfect for socking it to winter!",
                Price = 8.99M
            },
            new Product
            {
                Id = 7,
                Image = "https://www.crazysocks.com/cdn/shop/products/rainbow-metallic-socks-small_1200x.jpg?v=1595977722",
                ProductName = "Stripey Sock Spectacle",
                Description = "Striped pattern socks that bring the party to your feet. Because sometimes your toes just need to dance!",
                Price = 12.99M
            },
            new Product
            {
                Id = 8,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7OWX7mvtVe_L6Fh0mnYpHrNjxMZ4YMykSJA&s",
                ProductName = "Pedal Pusher Prints",
                Description = "Unisex bicycle print socks for the stylish cyclist who likes to keep their sock game on a roll.",
                Price = 10.99M
            },
            new Product
            {
                Id = 9,
                Image = "https://www.gripgrab.com/cdn/shop/products/3020_01_1800x1800.jpg?v=1649074892",
                ProductName = "Sock Safari",
                Description = "Black And White print socks that make you feel like the king or queen of the sock jungle!",
                Price = 13.99M
            }
        };
                Session["AllItems"] = products;
            }

            // Serialize the list of products to JSON
            string productsJson = JsonConvert.SerializeObject(Session["CartItems"]);
            Page.Response.Write("<script>console.log(" + productsJson + ");</script>");
        }

        public void ChangeQuantity(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Find the RepeaterItem that contains this TextBox
            RepeaterItem repeater = (RepeaterItem)textBox.NamingContainer;

            // Get the associated HiddenField to retrieve the product ID
            HiddenField productIDField = (HiddenField)repeater.FindControl("ProductIDHiddenField");
            int productId = Convert.ToInt32(productIDField.Value);

            Label errorlabel = (Label)repeater.FindControl("ErrorMessageLabel");

            
            
            string newQuantity = textBox.Text;

            int quantity;
            if (int.TryParse(newQuantity, out quantity) && quantity >= 0)
            {
                              
                errorlabel.Text = "";
                errorlabel.Visible = false;

                List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;

                //if quantity 0, note it as removal
                if (quantity == 0)
                {
                    cartItems.Remove(cartItems.Find(x => x.Id == productId));

                    Session["CartItems"] = cartItems;
                    Response.Redirect("/Cart");
                    return;
                }

                foreach (var item in cartItems)
                {

                    if (productId == item.Id)
                    {
                        item.quantity = quantity;
                        item.totalPrice = quantity * item.product.Price;
                    }
                }

                Session["CartItems"] = cartItems;

            Response.Redirect("/Cart");
            }
            else
            {
                if(quantity < 0)
                {
                    errorlabel.Text = "Enter a number greater than 0";
                    errorlabel.Visible = true;
                    return;
                }

                errorlabel.Text = "Enter a valid number";
                errorlabel.Visible = true;
                
            }
            

        }

        public void AddToCart(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            var id = int.Parse(clicked.CommandArgument);

            var allItems = Session["AllItems"] as List<Product>;

            var product = allItems.FirstOrDefault(x => x.Id == id);

            CartItem newCartItem = new CartItem
            {
                Id = id,
                quantity = 1,
                product = product,
                totalPrice = (decimal)product.Price * 1

            };

            if (Session["CartItems"] != null)
            {
                List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;

                //Using ID Match to prevent repeated additions
                if(!cartItems.Exists(x => x.Id == newCartItem.Id))
                {
                    cartItems.Add(newCartItem);

                }

                Page.Response.Write("<script>console.log(" + JsonConvert.SerializeObject(cartItems) + ");</script>");
            }
            else
            {
                Session["CartItems"] = new List<CartItem> { newCartItem };
            }

            Response.Redirect("/Cart");
            //Session["Cart"] = ToString(JSON.Validate([Session["Cart"]));
        }
    }
}