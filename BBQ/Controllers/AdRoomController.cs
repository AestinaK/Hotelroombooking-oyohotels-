using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdRoomController : Controller
    {
        public IActionResult RoomIndex()

        {
            return View();
        }

        //for adding room
        public IActionResult AddRoomIndex()


        {
            return View();
        }
        //for facilities and services

        public IActionResult FacilitiesIndex()



        {
            return View();
        }

        //for amenities
        public IActionResult AmenitiesIndex()




        {
            return View();
        }






    }
}
