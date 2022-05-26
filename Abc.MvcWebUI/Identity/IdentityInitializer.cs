using Abc.MvcWebUI.entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer: CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Rolleri
            if(!context.Roles.Any(i=>i.Name=="Admin"))
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);
                var role = new AplicationRole{ Name = "Admin", Description = "yönetici rolü" };
                manager.Create(role);

            }

            //User
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);
                var role = new AplicationRole {Name="user",Description= "user rolü" };
                manager.Create(role);

            }
            if (!context.Users.Any(i => i.Name == "mertkaraomer"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);
                var user = new AplicationUser() { Name="mert",Surname="karaomer",UserName="mertkaraomer",Email="m.karaomer1@gmail.com"};
                manager.Create(user ,"12345");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "user");


            }
            if (!context.Users.Any(i => i.Name == "mertkaraomer"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);
                var user = new AplicationUser() { Name = "asrın", Surname = "karaomer", UserName = "asrınkaraomer", Email = "a.karaomer41@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");


            }


            base.Seed(context); 
        }
    }
}