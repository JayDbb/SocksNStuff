using SocksNStuff.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (Session["isAuth"] == null || !(bool)Session["isAuth"])
            {
                Response.Redirect("/Login");
                return;
            }

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

            string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            CartDCDataContext cartDC = new CartDCDataContext(cs);

            cartDC.Carts.DeleteOnSubmit(cartDC.Carts.FirstOrDefault(x => x.ItemId == productId));
            cartDC.SubmitChanges();
         

            Response.Redirect("/Cart");

        }
        private void BindCart()
        {
            
                string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
                CartDCDataContext cartDC = new CartDCDataContext(cs);
                ProductDCDataContext productDC = new ProductDCDataContext(cs);

                var userId = (int)Session["UserId"];

            List<Cart> myCart = cartDC.Carts.Where(x => x.UserId == userId).ToList();

            List<CartItemWithDetails> cartItems = new List<CartItemWithDetails>();
            
            foreach (var i in myCart)
            {
                var product = productDC.Products.FirstOrDefault(x => x.Id == i.ItemId);
                cartItems.Add(new CartItemWithDetails { 
                    Id = i.ItemId,
                    Name = product.Name,
                    Quantity = i.Quantity,
                    Price = (decimal)product.Price
                });
            }

            // Bind the custom cart items to the repeater
            CartItemsRepeater.DataSource = cartItems;
            CartItemsRepeater.DataBind();

            // Update subtotal, tax, and total labels
            decimal subtotal = (decimal)cartItems.Sum(item => item.TotalPrice);
                decimal tax = subtotal * 0.10m;
                decimal total = subtotal + tax;

                SubtotalLabel.Text = subtotal.ToString("C");
                TaxLabel.Text = tax.ToString("C");
                TotalLabel.Text = total.ToString("C");
                
                   
           
        }

        protected void Checkout(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;

            OrdersDCDataContext orderDC = new OrdersDCDataContext(cs);
            string totalText = TotalLabel.Text.Replace("$", "").Replace(",", "").Trim();
            Order newOrder = new Order
            {

                UserId = (int)Session["UserId"],
                Total = float.Parse(totalText),
                DateAdded = DateTime.Today,

            };

            orderDC.Orders.InsertOnSubmit(newOrder);

            orderDC.SubmitChanges();

            CartDCDataContext cartDC = new CartDCDataContext(cs);
            cartDC.Carts.DeleteAllOnSubmit(cartDC.Carts.Where(x => x.UserId == (int)Session["UserId"]));

            cartDC.SubmitChanges();

            int orderId = newOrder.OrderId;


            Response.Redirect("/Order?order=" + orderId);
        }

    }
}