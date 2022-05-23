using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdSettingController : Controller
    {
        public IActionResult SettingIndex()

        {
            return View();
        }
    }
}
