using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

        List<Category> kategoriler = new List<Category>()
        {
            new Category(){Name="kamera",Description="kamera ürünleri"},
            new Category(){Name="bilgisayar",Description="bilgisayar ürünleri"},
            new Category(){Name="elektronik",Description="elektronik ürünleri"},
            new Category(){Name="telefon",Description="telefon ürünleri"},
            new Category(){Name="Beyaz eşya",Description="beyaz eşya ürünleri"},

        };
            foreach(var kategori in kategoriler)
            {
                context.Categories.Add(kategori);

            }
            context.SaveChanges();
            List<product> urunler = new List<product>()
            {
                new product(){Name="",Description="",Price=,Stock=,IsApproved=,CategoryId=}
            };
            base.Seed(context);
        }

    }

}
