using BBQ.Models;
using BBQ.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class UsproductdetailsController : Controller
    {

        DataContext dal = new DataContext();
        public IActionResult Index( int hid ,string sstart , string eend , int noofrooms)
        {

            var start = DateOnly.Parse(sstart);
            var end = DateOnly.Parse(eend);

            ViewBag.rooms = noofrooms;

             var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(a => a.hid == hid).Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomTypeGroup = available_rooms.GroupBy(x => x.rtid).ToList();
            //var price = dal.Prices.Where(b => b.hid==hotelID).Where(x=>roomTypeGroup.Contains(x.rtid));
            //mailay ajha thapay ko 
            var grouptype = roomTypeGroup.Where(x => x.Count() >= noofrooms).ToList();

            var grouptypekey = grouptype.Select(z => z.Key).ToList();
            var details = dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
            var price = dal.Prices.Where(b => b.hid == hid).Where(x => grouptypekey.Contains(x.rtid));

            //  var roomtypeid=grouptype.Select rtid 

            ViewBag.typess = details;
            ViewBag.price = price; 

            return View();
        }


        [HttpPost]
        public IActionResult Indexx( int hid )
        {

           /* ViewBag.checkin = vm.start;
            ViewBag.checkout = vm.end;
            ViewBag.noofroom = vm.noofrooms;*/

           /* var start = DateOnly.Parse( start);
            var end = DateOnly.Parse( end)*/;

           /* var start= DateOnly.Parse(vm.start);
            var end = DateOnly.Parse(vm.end);*/

            var hotelid = hid;

           /* var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(a => a.hid == hid).Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomTypeGroup = available_rooms.GroupBy(x => x.rtid).ToList();
            //var price = dal.Prices.Where(b => b.hid==hotelID).Where(x=>roomTypeGroup.Contains(x.rtid));
            //mailay ajha thapay ko 
            var grouptype = roomTypeGroup.Where(x => x.Count() >= vm.noofrooms).ToList();

            var grouptypekey = grouptype.Select(z => z.Key).ToList();
            var details = dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
            var price = dal.Prices.Where(b => b.hid == hid).Where(x => grouptypekey.Contains(x.rtid));

            //  var roomtypeid=grouptype.Select rtid 

            ViewBag.datass = roomTypeGroup;
            ViewBag.price = price;*/
            return View();
        }
    }
}
