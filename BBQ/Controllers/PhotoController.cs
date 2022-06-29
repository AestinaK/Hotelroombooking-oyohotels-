using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
