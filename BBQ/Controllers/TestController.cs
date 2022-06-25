using BBQ.Models;
using BBQ.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BBQ.Controllers
{
    public class TestController : Controller
    {
        DataContext dal = new DataContext();
        /*public IActionResult Index()
        {

            return View();
        }*/
        [HttpPost]
        public IActionResult Index(Hotelsearchviewmodel vm)
        {
            ViewBag.address = vm.address;
            ViewBag.checkin = vm.start;
            ViewBag.checkout = vm.end;
            ViewBag.noofroom = vm.noofrooms;

            var start = DateOnly.Parse(vm.start);
            var end = DateOnly.Parse(vm.end);


            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomHotelGroup = available_rooms.GroupBy(x => x.hid);
            var hotelIds = roomHotelGroup.Where(x => x.Count() >= vm.noofrooms).Select(z => z.Key).ToList();
            
            var hotels = dal.Hotelss.Where(a => a.address==vm.address).Where(x => hotelIds.Contains(x.hid)).ToList();
           // var price = dal.Prices.Where(x => hotelsss.Contains(x.hid)).ToList();            
            ViewBag.datas = hotels;

            testMethod(vm);

            return View();
        }
        
        // returns available rooms grouped on type for a hotel id
        [HttpPost]
        public IActionResult testMethod(Hotelsearchviewmodel vm)
        {
            
            ViewBag.checkin = vm.start;
            ViewBag.checkout = vm.end;
            ViewBag.noofroom = vm.noofrooms;

            var start = DateOnly.Parse(vm.start);
            var end = DateOnly.Parse(vm.end);

            int hotelID = 1;

            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(a => a.hid == hotelID).Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomTypeGroup = available_rooms.GroupBy(x => x.rtid).ToList();
            //var price = dal.Prices.Where(b => b.hid==hotelID).Where(x=>roomTypeGroup.Contains(x.rtid));
            //mailay ajha thapay ko 
            var grouptype = roomTypeGroup.Where(x => x.Count() >= vm.noofrooms).ToList();

            var grouptypekey = grouptype.Select(z => z.Key).ToList();
            var details=dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
            var price = dal.Prices.Where(b => b.hid == hotelID).Where(x => grouptypekey.Contains(x.rtid));

            //  var roomtypeid=grouptype.Select rtid 

            ViewBag.datas = roomTypeGroup;
            return View();
        }


        public IActionResult hoteldetails()
        {
            return RedirectToAction("Index", "Usproductdetails");
        }


        /*public IActionResult search(string address)
        {
            // var userlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();
            

        }*/
    }
}