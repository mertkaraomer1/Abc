﻿using Abc.MvcWebUI.entity;
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
            
            return View(context.Products.Where(i=>i.IsHome&&i.IsApproved).ToList());
        }
        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List()
        {
            return View(context.Products.Where(i=> i.IsApproved).ToList());
        }
    }
}