using ETicaret.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccessLayer.Concrete.EfCore
{
    public class MyInitialData
    {
        private static Category[] Categories = new Category[]
        {
            new Category() {Name = "Telefon", Url="telefon"},
            new Category() {Name = "Bilgisayar", Url="bilgisayar"},
            new Category() {Name = "Elektronik", Url="elektronik"},
            new Category() {Name = "Giyim", Url="giyim"},
            new Category() {Name = "Televizyon", Url="televizyon"},
            new Category() {Name = "Beyaz Eşya", Url="beyaz-esya"},
            new Category() {Name = "Küçük Ev Aletleri", Url="kucuk-ev-aletleri"}
        };

        private static Product[] Products = new Product[]
        {
            new Product() {Name= "Iphone 11", Description="Iphone serisi", ImageUrl="iphone11.jpg", Price=1500, IsApproved=true, Url="iphone11", IsHome=true},
            new Product() {Name= "Iphone 12", Description="Iphone serisi", ImageUrl="iphone12.jpg", Price=1800, IsApproved=true, Url="iphone12", IsHome=true},
            new Product() {Name= "Iphone 13", Description="Iphone serisi", ImageUrl="iphone13.jpg", Price=2000, IsApproved=true, Url="iphone13", IsHome = false},
            new Product() {Name= "Asus", Description="Notebook bilgisayar", ImageUrl="asus.jpg", Price=2500, IsApproved=true, Url="asus", IsHome=true},
            new Product() {Name= "Toshiba A50", Description="Notebook bilgisayar", ImageUrl="toshibaa50.jpg", Price=2600, IsApproved=true, Url="toshibaa50", IsHome = false},
            new Product() {Name= "LG Tv", Description="Televizyon", ImageUrl="lgtv.jpg", Price=2600, IsApproved=true, Url="lgtv", IsHome = true},
            new Product() {Name= "Gömlek", Description="Gömlek", ImageUrl="gomlek.jpg", Price=2600, IsApproved=true, Url="gomlek", IsHome = true},
            new Product() {Name= "Arçelik Buzdolabı", Description="Güzel buzdolabı", ImageUrl="arcelik-buzdolabi.jpg", Price=15200, IsApproved=true, Url="arcelik-buzdolabi", IsHome = true},
            new Product() {Name= "Çamaşır Makinası", Description="Çamaşır yıkar", ImageUrl="camasir-makinasi.jpg", Price=21600, IsApproved=true, Url="camasir-makinasi", IsHome = false},
            new Product() {Name= "Pantalon", Description="Pantalon", ImageUrl="pantalon.jpg", Price=600, IsApproved=true, Url="pantalon" , IsHome=true},
            new Product() {Name= "Ütü", Description="Ütü", ImageUrl="utu.jpg", Price=1200, IsApproved=true, Url="utu", IsHome = true},
            new Product() {Name= "Air Fryer", Description="Güzel pişirir", ImageUrl="air-fryer.jpg", Price=12600, IsApproved=true, Url="air-fryer", IsHome=false},
            new Product() {Name= "Huawei Mate 20 Lite", Description="İdare eder telefon", ImageUrl="huaweim20lite.jpg", Price=5600, IsApproved=true, Url="huaweimate20lite", IsHome=true},
            new Product() {Name= "Bulaşık Makinası", Description="Bulaşık yıkar", ImageUrl="bulasik-makinasi.jpg", Price=12800, IsApproved=true, Url="bulasik-makinasi", IsHome=true}
        };

        private static ProductCategory[] productCategories = new ProductCategory[]
        {
            new ProductCategory() {Product = Products[0], Category = Categories[0]},
            new ProductCategory() {Product = Products[1], Category = Categories[0]},
            new ProductCategory() {Product = Products[2], Category = Categories[0]},
            new ProductCategory() {Product = Products[3], Category = Categories[1]},
            new ProductCategory() {Product = Products[4], Category = Categories[1]},
            new ProductCategory() {Product = Products[5], Category = Categories[2]},
            new ProductCategory() {Product = Products[6], Category = Categories[3]},
            new ProductCategory() {Product = Products[7], Category = Categories[5]},
            new ProductCategory() {Product = Products[8], Category = Categories[5]},
            new ProductCategory() {Product = Products[9], Category = Categories[4]},
            new ProductCategory() {Product = Products[10], Category = Categories[6]},
            new ProductCategory() {Product = Products[11], Category = Categories[6]},
            new ProductCategory() {Product = Products[12], Category = Categories[0]},
            new ProductCategory() {Product = Products[13], Category = Categories[5]},
        };

        public static void Seed()
        {
            ETicaretContext context = new ETicaretContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    foreach (var cat in Categories)
                    {
                        context.Add(cat);
                    }
                }
                if (context.Products.Count() == 0)
                {
                    foreach (var product in Products)
                    {
                        context.Add(product);
                    }
                    foreach (var prodCat in productCategories)
                    {
                        context.Add(prodCat);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
