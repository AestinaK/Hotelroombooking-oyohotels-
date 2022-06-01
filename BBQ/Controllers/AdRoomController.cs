using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdRoomController : Controller
    {

       /* DataContext dal = new DataContext();*/
        public IActionResult RoomIndex()

        {
            return View();
        }

        //for adding room
        public IActionResult AddRoomIndex()


        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Insert(AdRoom vmodel)
        {
            

                dal.AdRooms.Add(vmodel);
                dal.SaveChanges();
            
            return RedirectToAction("AddRoomIndex","AdRoom");

        }*/






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





        public IActionResult RoomTypeIndex()
        {
            return View();
        }


        //for direction
        public IActionResult DirIndex()
        {
            return View();
        }



    }
}

