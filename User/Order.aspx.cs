using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class Order1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;


                // Get the order ID from the query string
                string orderIdParam = Request.QueryString["order"];

                // Check if orderId is present and valid
                if (!string.IsNullOrEmpty(orderIdParam) && int.TryParse(orderIdParam, out int orderId))
                {
                    // Fetch the order details using the orderId
                    using (OrdersDCDataContext orderDC = new OrdersDCDataContext(cs))
                    {
                        var order = orderDC.Orders.FirstOrDefault(o => o.OrderId == orderId);

                        if (order != null)
                        {
                            // Set order number and total
                            OrderNumberLabel.Text = order.OrderId.ToString();
                            OrderTotalLabel.Text = String.Format("{0:C}", order.Total);
                        }
                        else
                        {
                            // Handle case when the order is not found
                            OrderNumberLabel.Text = "Order not found.";
                            OrderTotalLabel.Text = "N/A";
                        }
                    }
                }
            }
        }
    }
}