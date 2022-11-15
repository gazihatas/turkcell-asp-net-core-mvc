using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCore.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.baseUrl = _configuration["baseUrl"];
            ViewBag.smsKey = _configuration["Keys:Sms"];
            ViewBag.emailKey = _configuration.GetSection("Keys")["email"];
            return View();
        }
    }
}
