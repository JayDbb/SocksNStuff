using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SocksNStuff
{
        public class ApplicationUser : IdentityUser
        {
        
            public string fname;
            public string lname;
            public DateTime createdAt { get; set; }

    }

        public class ApplicationRole : IdentityRole
        {
            public ApplicationRole() : base() { }
            public ApplicationRole(string roleName) : base(roleName) { }
        }
   }

