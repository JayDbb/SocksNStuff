using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SocksNStuff
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Check if the request is secure (HTTPS)
            if (Request.IsSecureConnection)
            {
                // Ensure that the ASP.NET session cookie is secure
                if (Response.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Secure = true;
                }

                // Ensure that the Forms Authentication cookie is secure (if using Forms authentication)
                if (Response.Cookies[".ASPXAUTH"] != null)
                {
                    Response.Cookies[".ASPXAUTH"].Secure = true;
                }
            }
        }
    }
}
