using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocksNStuff
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isAuth"] == null || !(bool)Session["isAuth"])
            {
                liCart.Visible = false; 
                logout.Visible = false;

                login.Visible = true;
                signup.Visible = true;

            }
            else
            {
                login.Visible = false;
                signup.Visible = false;
                liCart.Visible = true;
                logout.Visible = true;
            }
        } 

        protected void Logout(object sender, EventArgs e)
        {
            Session["isAuth"] = false;
            Session["UserId"] = null;
            Response.Redirect("/");
        }
    }
}