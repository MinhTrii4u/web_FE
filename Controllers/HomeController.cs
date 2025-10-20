using System.Collections.Generic; 
using System.Web.Mvc;
using web_FE.Models;

namespace web_FE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Adidas Superstar XLG", Price = 2800000m, ImageUrl = "https://i.ibb.co/d4zQqdLs/download.jpg", Brand = "Adidas Originals" },
                new Product { Id = 2, Name = "Adidas Samba OG", Price = 3200000m, ImageUrl = "https://i.ibb.co/rf5vXPQy/download-1.jpg", Brand = "Adidas Originals" },
                new Product { Id = 3, Name = "Adidas Forum Low", Price = 2600000m, ImageUrl = "https://i.ibb.co/9H9RN6Kp/download-4.jpg", Brand = "Adidas Originals" },
                new Product { Id = 4, Name = "Adidas Gazelle", Price = 2750000m, ImageUrl = "https://i.ibb.co/6JwXxBF3/download-3.jpg", Brand = "Adidas Originals" },
                new Product { Id = 5, Name = "Adidas NMD_R1", Price = 3600000m, ImageUrl = "https://i.ibb.co/9HJtHpLz/Giay-Adidas-Originals-Prophere-Grey-ID0542.png", Brand = "Adidas Sportswear" },
                new Product { Id = 6, Name = "Forum Low White", Price = 2650000m, ImageUrl = "https://i.ibb.co/8QsvtqD/images-1.jpg", Brand = "Adidas Originals" },
                new Product { Id = 7, Name = "Ozweego", Price = 3100000m, ImageUrl = "https://i.ibb.co/5Xvb78wZ/OIP.webp", Brand = "Adidas Originals" },
                new Product { Id = 8, Name = "Ultraboost Light", Price = 4800000m, ImageUrl = "https://i.ibb.co/KcN74rmD/OIP-1.webp", Brand = "Adidas Running" }
            };


            return View(products);
        }

        public ActionResult Detail()
        {
         
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
      
        public ActionResult Category()
        {
            
            var products = new List<Product>
    {
        new Product { Id = 1, Name = "Adidas Superstar XLG", Price = 2800000m, ImageUrl = "https://i.ibb.co/d4zQqdLs/download.jpg", Brand = "Adidas Originals" },
        new Product { Id = 2, Name = "Adidas Samba OG", Price = 3200000m, ImageUrl = "https://i.ibb.co/rf5vXPQy/download-1.jpg", Brand = "Adidas Originals" },
        new Product { Id = 3, Name = "Adidas Forum Low", Price = 2600000m, ImageUrl = "https://i.ibb.co/9H9RN6Kp/download-4.jpg", Brand = "Adidas Originals" },
        new Product { Id = 4, Name = "Adidas Gazelle", Price = 2750000m, ImageUrl = "https://i.ibb.co/6JwXxBF3/download-3.jpg", Brand = "Adidas Originals" },
        new Product { Id = 5, Name = "Adidas NMD_R1", Price = 3600000m, ImageUrl = "https://i.ibb.co/9HJtHpLz/Giay-Adidas-Originals-Prophere-Grey-ID0542.png", Brand = "Adidas Sportswear" },
        new Product { Id = 6, Name = "Forum Low White", Price = 2650000m, ImageUrl = "https://i.ibb.co/8QsvtqD/images-1.jpg", Brand = "Adidas Originals" },
        new Product { Id = 7, Name = "Ozweego", Price = 3100000m, ImageUrl = "https://i.ibb.co/5Xvb78wZ/OIP.webp", Brand = "Adidas Originals" },
        new Product { Id = 8, Name = "Ultraboost Light", Price = 4800000m, ImageUrl = "https://i.ibb.co/KcN74rmD/OIP-1.webp", Brand = "Adidas Running" }
    };

           
            return View(products);
        }

        
        public ActionResult Checkout()
        {
            
            return View();
        }
        

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}