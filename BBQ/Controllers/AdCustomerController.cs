using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdCustomerController : Controller
    {
        public IActionResult CustomerIndex()
        {
            return View();
        }
    }
}
