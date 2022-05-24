using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult hoteldetails()
        {
            return RedirectToAction("Index", "Usproductdetails");
        }
    }
}
