using Abc.MvcWebUI.entity;
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
        private DataContext db = new DataContext();
        private UserManager<AplicationUser> UserManager;
        private RoleManager<AplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<AplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<AplicationUser>(userStore);
            var roleStore = new RoleStore<AplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<AplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
                { 
                    Id=i.Id,
                    OrderNumber=i.OrderNumber,
                    OrderDate=i.OrderDate,
                    OrderState=i.OrderState,
                    Total=i.Total
                }).OrderByDescending(i=>i.OrderDate).Any();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber=i.OrderNumber,
                    OrderDate=i.OrderDate,
                    Total=i.Total,
                    OrderState=i.OrderState,
                    AdresBasligi=i.AdresBasligi,
                    Adres=i.Adres,
                    Sehir=i.Sehir,
                    Semt=i.Semt,
                    Mahalle=i.Mahalle,
                    PostaKodu=i.PostaKodu,
                    OrderLines=i.OrderLines.Select(a=>new OrderLineModel()
                    { 
                        ProductId=a.ProductId,
                        ProductName=a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                        Image=a.Product.Image,
                        Quantity=a.Quantity,
                        Price=a.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
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