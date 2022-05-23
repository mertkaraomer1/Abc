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
            var urunler = new List<product>()
            {
                new product(){Name="canon eos 1200D",Description="Fotoğraf Makinesi Profesyonel",Price=10000,Stock=5,IsApproved=true,CategoryId=1},
                new product(){Name="canon eos 10D",Description="Fotoğraf Makinesi",Price=5500,Stock=5,IsApproved=true,CategoryId=1},
                new product(){Name="canon eos 700D",Description="Fotoğraf Makinesi Yarı Profesyonel",Price=7000,Stock=1,IsApproved=false,CategoryId=1},

                new product(){Name="Dell Inspiron 5 ıntel core i5",Description="Leptop",Price=12000,Stock=7,IsApproved=true,CategoryId=2},
                new product(){Name="lenovo Ideapad ıntel core i7",Description="Leptop",Price=23222,Stock=1,IsApproved=false,CategoryId=2},
                new product(){Name="lenovo legion y520 ıntel core i7",Description="Leptop",Price=23233,Stock=2,IsApproved=false,CategoryId=2},
                new product(){Name="Asus UX310UQ-FB418T  ıntel core i5",Description="Notebook",Price=15000,Stock=4,IsApproved=true,CategoryId=2},
                new product(){Name="Asus N580VD-DM160T ıntel core i7",Description="Notebook",Price=12122,Stock=9,IsApproved=true,CategoryId=2},

                new product(){Name="Vestel buz dolabı",Description="Telefon",Price=3500,Stock=4,IsApproved=true,CategoryId=3},
                new product(){Name="Xiomi robot süpürge",Description="Beyaz eşya",Price=12122,Stock=9,IsApproved=true,CategoryId=3},

                new product(){Name="Apple Iphone 7 plus 32 GB",Description="telefon",Price=3500,Stock=4,IsApproved=true,CategoryId=4},
                new product(){Name="Xiomi Mİ 5S 64GB",Description="telefon",Price=12122,Stock=9,IsApproved=true,CategoryId=4},

                new product(){Name="Samsun tv",Description="TV",Price=15000,Stock=4,IsApproved=true,CategoryId=5},
                new product(){Name="Vestel tv",Description="TV",Price=12122,Stock=9,IsApproved=true,CategoryId=5}


            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();
            base.Seed(context);
        }

    }

}
