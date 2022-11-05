using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCore.Web.Controllers
{
    public class OrnekController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
