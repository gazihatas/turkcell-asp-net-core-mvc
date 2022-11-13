using Microsoft.AspNetCore.Mvc;
using MyAspNetCore.Web.Filters;

namespace MyAspNetCore.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [CustomResultFilter("x-version","1.0")]
    [Route("[controller]/[action]")]
    public class OrnekController1 : Controller
    {
        public IActionResult Index()
        {
            var productList = new List<Product2>()
            {
                new(){Id=1, Name="Kalem"},
                new(){Id=2, Name = "Dester"},
                new(){Id=3,Name = "Silgi"}
            };
            return View(productList);
        }
    }
}
