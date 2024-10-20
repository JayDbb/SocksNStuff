using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShopLogin(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                cvLoginError.IsValid = false;
                return;
            }

            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);

            var data = from Customer in customerData.Customers select Customer;
            var loginCustomer = data.FirstOrDefault(x => x.Email == txtEmail.Text);

            if (loginCustomer == null)
            {
                cvLoginErrorEmail.IsValid = false;
            }
            else
            {
                if(loginCustomer.Password == txtPassword.Text)
                {
                    Session["isAuth"] = true;
                    Session["UserId"] = loginCustomer.Id;
                    Response.Redirect("/Products");
                }
                else
                {
                    cvLoginErrorPwd.IsValid = false;

                }
            }
            
        }

        protected void btnNavigate(object sender, EventArgs e)
        {
            // Redirect the user to AnotherPage.aspx
            Response.Redirect("SignUp.aspx");
        }
    }
}