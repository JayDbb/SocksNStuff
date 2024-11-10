using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace SocksNStuff
{
    public partial class Manage : System.Web.UI.Page
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

        public void Delete(object sender, EventArgs e)
        {
            Button editButton = (Button)sender;
            string productId = editButton.CommandArgument;

            delProductModalLabel.Text = "Are you sure you want to delete ID: " + productId;
            del.CommandArgument = productId;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#delProductModal').modal('show');", true);


        }

        public void SaveChangesDel(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            ProductDCDataContext productDC = new ProductDCDataContext(cs);

            Button delButton = (Button)sender;
            int productId = int.Parse(delButton.CommandArgument);

           ;

            productDC.Products.DeleteOnSubmit(productDC.Products.FirstOrDefault(x => x.Id == productId));
            productDC.SubmitChanges();
            Response.Redirect("/Manage");


        }

        public void SaveChanges(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Url = url.Text,
                Name = name.Text,
                Category = category.Text,
                Price = decimal.Parse(price.Text),
                Description = desc.Text,
                AmountLeft = int.Parse(amount.Text)
            };

            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            ProductDCDataContext productDC = new ProductDCDataContext(cs);

            productDC.Products.InsertOnSubmit(product);
            productDC.SubmitChanges();
            Response.Redirect("/Manage");


        }

        public void SaveChangesEdit(object sender, EventArgs e)
        {
            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            ProductDCDataContext productDC = new ProductDCDataContext(cs);

            Product product = productDC.Products.FirstOrDefault(x => x.Id == int.Parse(ProductIdHiddenField.Value));

            product.Url = ProductUrlTextBox.Text;
            product.Name = ProductNameTextBox.Text ;
            product.Category = ProductCategoryTextBox.Text;
            product.Price = decimal.Parse(ProductPriceTextBox.Text) ;
            product.Description = ProductDescriptionTextBox.Text;
            product.AmountLeft = int.Parse(ProductAmountLeftTextBox.Text);

            productDC.SubmitChanges();
            Response.Redirect("/Manage");
        }

        public void AddModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#addProductModal').modal('show');", true);

        }

        protected void Edit(object sender, EventArgs e)
        {
            // Get the product ID from the CommandArgument
            Button editButton = (Button)sender;
            int productId = Convert.ToInt32(editButton.CommandArgument);

            string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;

            // Fetch the product from the database using the productId
            using (ProductDCDataContext productDC = new ProductDCDataContext(cs))
            {
                var product = productDC.Products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    // Populate the modal with product data
                    ProductIdHiddenField.Value = product.Id.ToString();
                    ProductNameTextBox.Text = product.Name;
                    ProductCategoryTextBox.Text = product.Category;
                    ProductPriceTextBox.Text = product.Price.ToString();
                    ProductDescriptionTextBox.Text = product.Description;
                    ProductAmountLeftTextBox.Text = product.AmountLeft.ToString();
                    ProductUrlTextBox.Text = product.Url;

                    // Use JavaScript to show the modal
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#editProductModal').modal('show');", true);
                }
            }
        }

    }
}