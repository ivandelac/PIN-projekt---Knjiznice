using Microsoft.AspNetCore.Mvc;

namespace Knjiznice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
