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

            var types = dal.Roomtypes.Where(x => x.type == roomtype).ToList();
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
                    hid = hotelid,
                    roomno = vm.roomno

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



        //roomtype
        public IActionResult RoomTypeIndex()
        {
            var roomtype = dal.Roomtypes;
            ViewBag.roomtype = roomtype;
            return View();
        }

        public IActionResult AddRoomTypeIndex()
        {

            return View();
        }

        public IActionResult TypeInsert(Roomtype vm)
        {
            dal.Roomtypes.Add(vm);
            dal.SaveChanges();
            // dal.SaveChanges();


            return RedirectToAction("AddRoomTypeIndex", "AdRoom");

        }







        //update room


        
        public IActionResult UpdateRoom( int rid)
        {

            var roomdetails=dal.Rooms.Where(x=>x.rid==rid).ToList();
            ViewBag.roomdetails = roomdetails;


            var rtid=roomdetails[0].rtid;


            var roomrtid=dal.Roomtypes.Where(x=>x.rtid==rtid).Select(a=>a.type);
            ViewBag.roomrtid = roomrtid;

            var roomtype = dal.Roomtypes.ToList();
            ViewBag.roomtype = roomtype;

           

            /*var roomdetails = dal.Rooms.Where(x => x.rid = vm.rid).ToList();
            try
            {
                foreach (var d in roomdetails)
                {
                    d.Roomno = vm.roomno;
                    d.roomtype = rtid;
                }
            }
            dal.SaveChanges();
        }catch(Exception e){
            Console.WriteLine(e);

        
         var rtid = dal.roomtype.Where(x => x.type = vm.roomtype);*/
            return View();

        }


        [HttpPost]
        public IActionResult Up(Room datamodel)


        {
            dal.Rooms.Update(datamodel);
            dal.SaveChanges();
            return RedirectToAction("RoomIndex", "AdRoom");
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

