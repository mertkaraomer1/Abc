using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class AplicationRole:IdentityRole
    {
        public string Description { get; set; }
        public AplicationRole()
        {

        }
        public AplicationRole(string rolname,string description)
        {
            this.Description = description;
        }
    }
}