using Abc.MvcWebUI.entity;
using Abc.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        DataContext context = new DataContext();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var urunler = context.Products.Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
            {
                    Id=i.Id,
                    Name=i.Name,
                    Description =i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price =i.Price,
                    Image=i.Image,
                    CategoryId=i.CategoryId
                    

                }).ToList();

            
            return View(urunler);
        }
       
        public ActionResult Details(int? id )
        {
            return View(context.Products.Where(i => i.Id==id ).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = context.Products.Where(i => i.IsApproved )
               .Select(i => new ProductModel()
               {
                   Id = i.Id,
                   Name = i.Name,
                   Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                   Price = i.Price,
                   Image = i.Image ?? "4.jpg",
                   CategoryId = i.CategoryId


               }).ToList();
            //Helper.SetImageUrl(urunler);
            //urunler.ForEach(f => f.SetImageUrl());
            //urunler.FirstOrDefault().ImageWithBaseUrl;
            //if (id!=null)
            //{
            //    urunler = urunler.Where(i => i.CategoryId == id);

            //}
            return View(urunler.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }
       
    }
}