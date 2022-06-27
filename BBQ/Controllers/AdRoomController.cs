using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BBQ.Controllers
{
    public class AdRoomController : Controller
    {


        DataContext dal = new DataContext();
        public IActionResult RoomIndex(string hname)

        {
            var hotel = dal.Hotelss.Where(x => x.name == hname).ToList();
            var hid = hotel[0].hid;

            var rooms = dal.Rooms.Where(x => x.hid == hid).ToList();
           // var roomt = rooms[0].rtid;

            var roomtyp = dal.Roomtypes.ToList();

            ViewBag.rooms = rooms;
            ViewBag.roomtypess = roomtyp;
            
            return View();
        }

        //for adding room
        public IActionResult AddRoomIndex()
        {
            var types = dal.Roomtypes.ToList();
            ViewBag.types = types;
            return View();

           
        }




       

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



        //for facilities and services

        public IActionResult FacilitiesIndex()



        {
            return View();
        }





        public IActionResult Price(string hname)
        {
            
            var hotel = dal.Hotelss.Where(x => x.name == hname).ToList();
            var hid = hotel[0].hid;

            


            var roomtyp = dal.Roomtypes.ToList();

         
            ViewBag.roomtypess = roomtyp;




            return View();
        }
        public IActionResult  Pricein()
        { 
          
        
        
          return View();
        
        }


        //for amenities
        public IActionResult AmenitiesIndex()




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

