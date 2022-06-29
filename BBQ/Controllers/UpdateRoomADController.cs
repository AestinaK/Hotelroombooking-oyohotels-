using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class UpdateRoomADController : Controller
    {

        DataContext dal = new DataContext();
        public IActionResult Index(int rid)
        {

            var roomdetails = dal.Rooms.Find(rid);
            ViewBag.roomdetails = roomdetails;

           /* ViewBag.rid = roomdetails[0].rid;*/



            var rtid = roomdetails.rtid;



            var roomrtid = dal.Roomtypes.Where(x => x.rtid == rtid).Select(a => a.type);
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
    }
}
