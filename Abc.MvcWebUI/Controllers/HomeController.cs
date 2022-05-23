using Abc.MvcWebUI.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        DataContext context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            
            return View(context.Products.ToList());
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
    }
}