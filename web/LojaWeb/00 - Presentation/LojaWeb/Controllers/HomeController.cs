using Microsoft.AspNetCore.Mvc;

namespace LojaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}