using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShopSignUp(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);
            

            var data = from Customer in customerData.Customers select Customer;
            var checkCustomer = data.FirstOrDefault(x => x.Email == txtEmail.Text);

            if (checkCustomer != null)
            {
                AccontExist.IsValid = false;
                return;
            }

            Customer cus = new Customer
            {
                Fname = txtFname.Text,
                Lname = txtLname.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                CreatedAt = DateTime.Today

            };

            customerData.Customers.InsertOnSubmit(cus);

            customerData.SubmitChanges();

        }

        protected void btnNavigate(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }


}