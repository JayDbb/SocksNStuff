using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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

            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = signInManager.PasswordSignIn(txtEmail.Text, txtPassword.Text, true, shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                // Sign-in successful
                var user = userManager.FindByEmail(txtEmail.Text);

               



            var data = from Customer in customerData.Customers select Customer;
            var loginCustomer = data.FirstOrDefault(x => x.Email == txtEmail.Text);

            if (loginCustomer == null)
            {
                cvLoginErrorEmail.IsValid = false;
            }
            else
            {
                var role = userManager.GetRoles(user.Id);
                if (loginCustomer.Password == txtPassword.Text)
                {
                    Session["isAuth"] = true;
                    Session["UserId"] = loginCustomer.Id;
                        FormsAuthentication.SetAuthCookie(txtEmail.Text, true);

                        // Check if the user is in the "admin" role
                        if (userManager.IsInRole(user.Id, "Admin"))
                        {
                            // User is an admin, redirect to an admin-specific page if needed
                            Response.Redirect("~/Admin/Manage.aspx");
                        }
                        else
                        {
                            // User is not an admin, redirect to Cart or another page
                            Response.Redirect("~/User/Cart.aspx");
                        }
                    }
                else
                {
                    cvLoginErrorPwd.IsValid = false;

                }
            }

            }
            else
            {
                cvLoginErrorEmail.IsValid = false;
                cvLoginErrorPwd.IsValid = false;

                // Handle sign-in failure
            }

        }

        protected void btnNavigate(object sender, EventArgs e)
        {
            // Redirect the user to AnotherPage.aspx
            Response.Redirect("SignUp.aspx");
        }
    }
}