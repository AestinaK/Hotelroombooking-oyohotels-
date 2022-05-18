using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
