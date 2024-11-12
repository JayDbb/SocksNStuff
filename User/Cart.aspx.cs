using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
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
            if (User.Identity.Name == null)
            {
                Response.Redirect("/Login");
                return;
            }
            //if (Session["isAuth"] == null || !(bool)Session["isAuth"])
            //{
            //    Response.Redirect("/Login");
            //    return;
            //}

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
         

            Response.Redirect("/User/Cart");

        }
        private void BindCart()
        {
            
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            // Retrieve the full user object using the current user's identity name
            //IdentityUser user = userManager.FindByName(User.Identity.Name);
            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);
            var user = customerData.Customers.FirstOrDefault(x=> x.Email == User.Identity.Name);
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
                CartDCDataContext cartDC = new CartDCDataContext(cs);
                ProductDCDataContext productDC = new ProductDCDataContext(cs);



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


            Order newOrder = new Order
            {

                UserId = userId,
                Total = float.Parse(totalText),
                DateAdded = DateTime.Today,

            };

            orderDC.Orders.InsertOnSubmit(newOrder);

            orderDC.SubmitChanges();

            CartDCDataContext cartDC = new CartDCDataContext(cs);
            cartDC.Carts.DeleteAllOnSubmit(cartDC.Carts.Where(x => x.UserId == userId));

            cartDC.SubmitChanges();

            int orderId = newOrder.OrderId;


            Response.Redirect("/User/Order?order=" + orderId);
        }

    }
}