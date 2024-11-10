using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocksNStuff;

namespace SocksNStuff
{
    public partial class Products : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;

            ProductDCDataContext productDC = new ProductDCDataContext(cs);
            ProductsRepeater.DataSource = productDC.Products;
            ProductsRepeater.DataBind();

            }
        }
    }
}