using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocksNStuff
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext() : base("DefaultConnection")
        {
        }

        public static AppDBContext Create()
        {
            return new AppDBContext();
        }
    }

}