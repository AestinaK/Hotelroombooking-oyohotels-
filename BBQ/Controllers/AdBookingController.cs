using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdBookingController : Controller
    {
        public IActionResult BookingIndex()

        {
            return View();
        }
    }
}
