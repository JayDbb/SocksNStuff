using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Linq;
using System.Web;

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

            // Initialize database context
            var cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            CustomerDataClassDataContext customerData = new CustomerDataClassDataContext(cs);

            // Check if a customer with the given email already exists
            var checkCustomer = customerData.Customers.FirstOrDefault(x => x.Email == txtEmail.Text);
            if (checkCustomer != null)
            {
                AccontExist.IsValid = false;
                return;
            }

            // Initialize UserManager and RoleManager
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = Context.GetOwinContext().Get<ApplicationRoleManager>();

            // Ensure the roles exist
            string roleName = txtEmail.Text.Contains("admin") ? "Admin" : "User";
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }

            // Create a new ApplicationUser
            var newUser = new ApplicationUser
            {
                UserName = txtEmail.Text,
                Email = txtEmail.Text,
                fname = txtFname.Text,
                lname = txtLname.Text,
                createdAt = DateTime.Today
            };

            // Create the user with a password
            IdentityResult result = userManager.Create(newUser, txtPassword.Text);

            if (result.Succeeded)
            {
                // Add the new user to the role
                IdentityResult roleResult = userManager.AddToRole(newUser.Id, roleName);

                if (roleResult.Succeeded)
                {
                    // If role assignment succeeded, create customer record
                    Customer cus = new Customer
                    {
                        Fname = txtFname.Text,
                        Lname = txtLname.Text,
                        Password = txtPassword.Text,  // Note: storing plain passwords is not secure; consider hashing
                        Email = txtEmail.Text,
                        CreatedAt = DateTime.Today
                    };

                    // Insert new customer record and save changes
                    customerData.Customers.InsertOnSubmit(cus);
                    customerData.SubmitChanges();

                    // Redirect to a different page after registration
                    if (roleName == "Admin") { Response.Redirect("~/Admin/Manage.aspx"); }
                    else { Response.Redirect("~/User/Cart.aspx"); }
                }
                else
                {
                    
                }
            }
            else
            {
                // Handle user creation errors
                foreach (var error in result.Errors)
                {
                    ErrorMessage.Text += error + "<br />"; // Display or log the error
                }
            }
        }

        protected void btnNavigate(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
