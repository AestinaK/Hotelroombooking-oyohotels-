using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdLoginController : Controller
    {
        public IActionResult LoginIndex()

        {
            return View();
        }
    }
}
