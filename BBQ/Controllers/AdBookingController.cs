using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdBookingController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult BookingIndex(string hname)

        {
            var hotel = dal.Hotelss.Where(x => x.name == hname).ToList();
            var hid = hotel[0].hid;

            var rooms = dal.Roomreservations.Where(x => x.hid == hid).ToList();
            // var roomt = rooms[0].rtid;

            

            ViewBag.rooms = rooms;
            
            return View();
        }
    }
}
