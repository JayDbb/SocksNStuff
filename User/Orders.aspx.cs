using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff.User
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;

                int userId = 0;
                var isAuth = User.Identity.IsAuthenticated;
                // Retrieve orders for the current user
                if (isAuth)
                {
                    CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);
                    var user = customerData.Customers.FirstOrDefault(x => x.Email == User.Identity.Name);

                    if (user != null)
                    {

                        userId = user.Id;

                    }
                    else
                    {
                        //Response.Redirect("/Login");
                        return;
                    }
                }
                else
                {
                    Response.Redirect("/Login");
                }



                OrdersDCDataContext orderDC = new OrdersDCDataContext(cs);
                var orders = orderDC.Orders.Where(x => x.UserId == userId);
                
                // Bind the orders to the repeater
                OrdersRepeater.DataSource = orders;
                OrdersRepeater.DataBind();
            }
        }
    }
}