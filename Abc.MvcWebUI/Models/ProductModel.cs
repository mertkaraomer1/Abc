using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class ProductModel
    {
        //public static class Helper
        //{
        //    public static string ImageUrl = "http:// ";
        //    public static void SetImageUrl(List<ProductModel> urunler)
        //    {
        //        urunler.ForEach(f => f.Image = "" + f.Image);
        //    }
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        //[NotMapped]
        //public string ImageWithBaseUrl => Helper.ImageUrl + Image;

        public int CategoryId { get; set; }
        //public void SetImageUrl()
        //{
        //    Image = Helper.ImageUrl + Image;
        //}

    }
}