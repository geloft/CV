using Microsoft.AspNetCore.Mvc;

namespace CV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
