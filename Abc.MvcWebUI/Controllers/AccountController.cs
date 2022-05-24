using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AplicationUser> UserManager;
        private RoleManager<AplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<AplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<AplicationUser>(userStore);
            var roleStore = new RoleStore<AplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<AplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            var user = new AplicationUser();
            user.Name = model.Name;
            user.Surname = model.SurName;
            user.Email = model.Email;
            user.UserName = model.UserName;

            IdentityResult result = UserManager.Create(user, model.Password);
            if(result.Succeeded)
            {
                //kullanıcı oluştu ve kullanıcıya bir role atayabilirsiniz.
                if(RoleManager.RoleExists("User"))
                {
                    UserManager.AddToRole(user.Id, "User");
                }
                return RedirectToAction("Login", "Account");

            }
            else
            {
                ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
            }






            return View();
        }
    }
}