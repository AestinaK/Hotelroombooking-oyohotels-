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
           var sstart = vm.start.ToString();
            var eend = vm.end.ToString();
            ViewBag.address = vm.address;
            ViewBag.checkin = sstart;
            ViewBag.checkout = eend;
            ViewBag.noofroom = vm.noofrooms;

            var start = DateOnly.Parse(vm.start);
            var end = DateOnly.Parse(vm.end);


            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomHotelGroup = available_rooms.GroupBy(x => x.hid); 
            var hotelIds = roomHotelGroup.Where(x => x.Count() >= vm.noofrooms).Select(z => z.Key).ToList();
            
            var hotels = dal.Hotelss.Where(a => a.address==vm.address).Where(x => hotelIds.Contains(x.hid)).ToList();
            var image = dal.Hphotos.ToList();
                ViewBag.image = image;
/*           
 *           
 *           
 *           var price = dal.Prices.Where(a => a.rtid == 1).Where(x => hotels.Contains(x.hid)).ToList();            
*/          
            ViewBag.datas = hotels;


           /* var review = dal.Commnets.ToList();
            var ratingcount = review.Count;
            double ratingc = review.Count;
            int c = ratingcount - 1;
            double ra = 0;
             List<double> reviews = new List<double>();

            foreach(var it in hotels)
            {
                for (int i = 0; i <= c; i++)
                {
                    reviews = ra + review[i].rating;

                }
            }

            for (int i = 0; i <= c; i++)
            {
                ra = ra + review[i].rating;

            }

            double rno = ra / ratingc;

            int ratings = (int)Math.Ceiling(rno);
*/

            return View();
        }
        
        // returns available rooms grouped on type for a hotel id
        [HttpPost]
        public IActionResult testMethod(Hotelsearchviewmodel vm)
        {

            ViewBag.start = vm.start;
            ViewBag.end = vm.end;
            ViewBag.noofrooms = vm.noofrooms;

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
            var details = dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
            var price = dal.Prices.Where(b => b.hid == hotelID).Where(x => grouptypekey.Contains(x.rtid));

            //  var roomtypeid=grouptype.Select rtid 

            ViewBag.datass = roomTypeGroup;
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