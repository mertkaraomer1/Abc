using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
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
            //Kayıt işlemleri
            var user = new AplicationUser();
            user.Name = model.Name;
            user.Surname = model.SurName;
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = UserManager.Create(user, model.Password);
            if(result.Succeeded)
            {
                //kullanıcı oluştu ve kullanıcıya bir role atayabilirsiniz.
                if(RoleManager.RoleExists("user"))
                {
                    UserManager.AddToRole(user.Id, "user");
                }
                return RedirectToAction("Login", "Account");

            }
            else
            {
                ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
            }






            return View();
        }




        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            //login işlemleri
            var user =UserManager.Find(model.UserName, model.Password);
            if (user != null)
            {
                //var olan kullanıcıyı sisteme dahil et
                //Applicationcookie oluşturup sisteme bırak.

                var autManeger = HttpContext.GetOwinContext().Authentication;

                var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                var authProperties = new AuthenticationProperties();
                authProperties.IsPersistent = model.RememberMe;
                autManeger.SignIn(authProperties, identityclaims);
                if (!String.IsNullOrEmpty(ReturnUrl))
                {
                    Redirect(ReturnUrl);
                }



                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("LoginUserError", "böyle bir kullanıcı yok.");

            }
            return View(model);
        }


        public ActionResult Logout()
        {

            var autManeger = HttpContext.GetOwinContext().Authentication;
            autManeger.SignOut();


            return RedirectToAction("Index","Home");
        }
    }
}