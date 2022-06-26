using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdRoomController : Controller
    {

        DataContext dal = new DataContext();
        public IActionResult RoomIndex()

        {
            return View();
        }

        //for adding room
        public IActionResult AddRoomIndex()
        {
            var roomtype = dal.Roomtypes.ToList();
            ViewBag.roomtype = roomtype;

            return View();
        }
       /* public IActionResult AddRoomIndex()
        {
            var hotels = dal.Hotelss.ToList();
            ViewBag.hotels = hotels;

            return View();
        }
*/

        [HttpPost]
        public IActionResult Insert(Addroomvm vm)
        {
            var roomtype = vm.typename;
            var hotelname = vm.hname;

            var types=dal.Roomtypes.Where(x=>x.type == roomtype).ToList();
           // var type = types.Select(x => x.Key);
            var hotel = dal.Hotelss.Where(x => x.name == hotelname).ToList();
            //var typeid = types.rtid;
            //dal.SaveChanges();
            var roomid = types[0].rtid;
            var hotelid = hotel[0].hid;
            try
            {
                Room login = new Room()
                {
                    rtid = roomid,
                    hid=hotelid,
                    roomno=vm.roomno

                };

                

                dal.Rooms.Add(login);
                
                dal.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return RedirectToAction("AddRoomIndex", "AdRoom");

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





        public IActionResult RoomTypeIndex()
        {
            var types = dal.Roomtypes.ToList();
            ViewBag.types = types;
            return View();
        }

        public IActionResult AddRoomTypeIndex()
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

