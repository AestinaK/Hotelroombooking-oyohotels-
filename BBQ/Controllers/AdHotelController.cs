using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdHotelController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Hotels vmodel)
        {


            dal.Hotelss.Add(vmodel);
            dal.SaveChanges();

            return RedirectToAction("Index", "AdHotel");

        }



    }
}
