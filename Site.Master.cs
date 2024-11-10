using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["isAuth"] == null || !(bool)Session["isAuth"])
            //{
            //    liCart.Visible = false; 
            //    logout.Visible = false;

            //    login.Visible = true;
            //    signup.Visible = true;

            //}
            //else
            //{
            //    login.Visible = false;
            //    signup.Visible = false;
            //    liCart.Visible = true;
            //    logout.Visible = true;
            //}
        } 

        protected void Logout(object sender, EventArgs e)
        {
            // Clear Forms Authentication
            FormsAuthentication.SignOut();

            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            // Clear specific cookies
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1), // Expire immediately
                HttpOnly = true
            };
            Response.Cookies.Add(authCookie);

            var authManager = Context.GetOwinContext().Authentication;
            authManager.SignOut();

            // Redirect to the homepage or login page after logout
            Response.Redirect("/");
        }
    }
}