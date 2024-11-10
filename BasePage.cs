using Newtonsoft.Json;
using SocksNStuff.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public class BasePage:Page
    {
        private string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;

        protected void Page_Init(object sender, EventArgs e)
        {
            
            if (Session["AllItems"] == null)
            {
                ProductDCDataContext productDC = new ProductDCDataContext(cs);

                List<Product> products = (from Product in productDC.Products select Product).ToList();
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

               
                CartDCDataContext cartDC = new CartDCDataContext(cs);

                //if quantity 0, note it as removal
                if (quantity == 0)
                {
                    cartDC.Carts.DeleteOnSubmit(cartDC.Carts.FirstOrDefault(c => c.ItemId == productId));
                    cartDC.SubmitChanges();

                    Response.Redirect("/User/Cart");
                    return;
                }

                foreach (var item in cartDC.Carts)
                {

                    if (productId == item.ItemId)
                    {
                        item.Quantity = quantity;
                    }
                }

                cartDC.SubmitChanges();

                Response.Redirect("/User/Cart");
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
            // Check if Authorized
            if (User.Identity.Name == null)
            {
                Response.Redirect("/Login");
                return;
            }

            // Check for user Cart
            CartDCDataContext cartDC = new CartDCDataContext(cs);

            CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);
            var user = customerData.Customers.FirstOrDefault(x => x.Email == User.Identity.Name);
            var userId = 0;

            if (user != null)
            {

                userId = user.Id;

            }
            else
            {
                //Response.Redirect("/Login");
                return;
            }


            List<Cart> userCart = cartDC.Carts.Where(x => x.UserId == userId).ToList();

            // Items Id is stored in CommandArgument
            Button clicked = (Button)sender;
            var id = int.Parse(clicked.CommandArgument);

            // check if item exists in cart
            if (!userCart.Exists(x => x.ItemId == id))
            {
                cartDC.Carts.InsertOnSubmit(new Cart
                {
                    UserId = userId,
                    ItemId = id,
                    Quantity = 1,
                    DateAdded = DateTime.Today,
                });
            }

            cartDC.SubmitChanges();

            Response.Redirect("/User/Cart");
        }
    }
}