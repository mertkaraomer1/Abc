using Abc.MvcWebUI.entity;
using Abc.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if(product!=null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart =(Cart)Session["Cart"];
            if(cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;

        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if(cart.CartLines.Count==0)
            {
                ModelState.AddModelError("Ürün yok Error", "sepetinizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }



        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A"+(new Random()).Next(111111, 999999).ToString();
            order.Total = cart.total();
            order.OrderDate = DateTime.Now;
            order.UserName = entity.UserName;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;
            order.OrderLines = new List<OrderLine>();


            foreach (var pr in cart.CartLines)
         
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Qantity;
                orderline.Price = pr.Qantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.FindAsync(order);
            db.SaveChanges();





        }
    }
}