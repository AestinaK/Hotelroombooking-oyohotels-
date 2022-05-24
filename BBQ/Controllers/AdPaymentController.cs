using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdPaymentController : Controller
    {
        public IActionResult PaymentIndex()

        {
            return View();
        }
    }
}
