using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCore.Web.Helpers;
using MyAspNetCore.Web.Models;
using MyAspNetCore.Web.ViewModels;

namespace MyAspNetCore.Web.Controllers
{
    public class ProductsController : Controller
    {
        
        private  AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        //Dependency Injection
        public ProductsController(AppDbContext context, IMapper mapper)
        {
            //DI Container
            //Dependency Injection Pattern
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
        }

        [Route("[controller]/[action]/{page}/{pageSize}")]
        public IActionResult Pages(int page, int pageSize)
        {
            //Skip => atlar
            

            var products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        [Route("urunler/urun/{productid}")]
        public IActionResult GetById(int productid)
        {
            var product = _context.Products.Find(productid);

            return View(_mapper.Map<ProductViewModel>(product));
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
        public IActionResult Add(ProductViewModel newProduct)
        {
            //if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            //{
            //    ModelState.AddModelError(String.Empty, " Ürün ismi A harfi başlayamaz.");
            //}

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
            }, "Value", "Data");

            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception("db hatası");
                    //validasyondan datalar geçmişsse true gelir
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();

                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty,"Ürün kaydedilirken bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.");
                    return View();
                }
                

            }
            else
            {
                return View(); 
            }

           
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


            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            //var product = _context.Products.Find(updateProduct.Id);

           if(!ModelState.IsValid)
           {
                ViewBag.radioExpireValue = updateProduct.Expire;
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
                }, "Value", "Data", updateProduct.Color);

                return View();
            }



            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi";

            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct=_context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if(anyProduct)
            {
                return Json("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
