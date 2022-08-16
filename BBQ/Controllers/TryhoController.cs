using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class TryhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
