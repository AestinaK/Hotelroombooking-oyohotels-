using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdSupportController : Controller
    {
        public IActionResult SupportIndex()

        {
            return View();
        }
    }
}
