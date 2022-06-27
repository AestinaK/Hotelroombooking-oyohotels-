using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
   
    public class PriceaddController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            var listtype = dal.Roomtypes.ToList();
            ViewBag.types = listtype;
            return View();
        }
    }
}
