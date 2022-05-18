using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class UsdashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
