using SocksNStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class Cart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        public void RemoveItem(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            RepeaterItem repeater = (RepeaterItem)btn.NamingContainer;

            // Get the associated HiddenField to retrieve the product ID
            HiddenField productIDField = (HiddenField)repeater.FindControl("ProductIDHiddenField");
            int productId = Convert.ToInt32(productIDField.Value);

            List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;
            cartItems.Remove(cartItems.Find(x=> x.Id == productId));

            Session["CartItems"] = cartItems;
            Response.Redirect("/Cart");

        }
        private void BindCart()
        {
            if (Session["CartItems"] != null)
            {

                List<CartItem> CartItems = Session["CartItems"] as List<CartItem>;
                // Bind the cart items to the repeater
                CartItemsRepeater.DataSource = CartItems;
                CartItemsRepeater.DataBind();

                // Update subtotal, tax, and total labels
                decimal subtotal = CartItems.Sum(item => item.quantity* item.product.Price);
                decimal tax = subtotal * 0.10m;
                decimal total = subtotal + tax;

                SubtotalLabel.Text = subtotal.ToString("C");
                TaxLabel.Text = tax.ToString("C");
                TotalLabel.Text = total.ToString("C");
                
                   
            }
            else
            {
                SubtotalLabel.Text = 0.ToString("C");
                TaxLabel.Text = 0.ToString("C");
                TotalLabel.Text = 0.ToString("C");
            }
        }

    }
}