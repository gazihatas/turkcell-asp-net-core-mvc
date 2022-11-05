using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;

namespace MyAspNetCore.Web.Controllers
{
    public class ProductsController : Controller
    {
        
        private  AppDbContext _context;
        private readonly ProductRepository _productRepository;

        //Dependency Injection
        public ProductsController(AppDbContext context)
        {
            //DI Container
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();
          
            _context = context;
            //Herhangi bir kayıt yok ise dataları veri tabanına ekler.
            //Linq method
            
            //Veritabanına ekleme metodu
            //if(!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100, Color="Red",});
            //    _context.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 200, Color = "Red",});
            //    _context.Products.Add(new Product() { Name = "Kalem 3", Price = 300, Stock = 300, Color = "Red",});
                
            //    //Ef Core dataları memeory de tuttuğu dataları db ye yansıtır.
            //    _context.SaveChanges();
            //}
            


        }
        public IActionResult Index()
        {
 
            
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            //_productRepository.Remove(id);

            var product = _context.Products.Find(id);

            _context.Products.Remove(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }  
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Sarı",Value="Sarı"}
            },"Value","Data");
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            // Request Header-Body

            //1. Yöntem
            //var name  = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2. Yöntem
            //Product newProduct = new Product() { Name=Name,Price=Price,Color=Color, Stock=Stock};

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var product = _context.Products.Find(id);

            ViewBag.radioExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){Data="Mavi",Value="Mavi"},
                new(){Data="Kırmızı",Value="Kırmızı"},
                new(){Data="Sarı",Value="Sarı"}
            }, "Value", "Data",product.Color);


            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct,int productId)
        {
            updateProduct.Id = productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi";

            return RedirectToAction("Index");
        }
    }
}
