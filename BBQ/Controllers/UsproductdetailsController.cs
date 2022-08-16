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
            ViewBag.start = sstart;
            ViewBag.end = eend;
            ViewBag.hid = hid;

            var hehe = dal.Hotelss.Find(hid);
            ViewBag.hehe = hehe;

            var img=dal.Photos.Where(x=>x.hid==hid).ToList();
            ViewBag.img= img;


            var review = dal.Comments.Where(x=>x.hid==hid).ToList();
            ViewBag.reviews = review;

            var ratingcount = review.Count;
            ViewBag.Counts= ratingcount;
            double ratingc = review.Count;
            int c = ratingcount - 1;
            double ra = 0;
            // List<var> reviews = new List<int>();
            for (int i = 0; i <= c; i++)
            {
                ra = ra + review[i].rating;

            }

            double rno = ra / ratingc;
            
            int ratings = (int)Math.Ceiling(rno);

            ViewBag.ratings = ratings;

            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(a => a.hid == hid).Where(x => !booked_rooms.Contains(x.rid)).ToList();
            var roomTypeGroup = available_rooms.GroupBy(x => x.rtid).ToList(); 
             
            //var price = dal.Prices.Where(b => b.hid==hotelID).Where(x=>roomTypeGroup.Contains(x.rtid));
            //mailay ajha thapay ko 
            var grouptype = roomTypeGroup.Where(x => x.Count() >= noofrooms).ToList();

            var grouptypekey = grouptype.Select(z => z.Key).ToList();
            var details = dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
            var price = dal.Prices.Where(b => b.hid == hid).Where(x => grouptypekey.Contains(x.rtid));


            var features = dal.Featuress.ToList();
            ViewBag.features = features;

            //  var roomtypeid=grouptype.Select rtid 

            ViewBag.typess = details;
            ViewBag.price = price;

            //for releted product 

            var hotelsdetailsss = dal.Hotelss.Find(hid);

            var r_booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var r_available_rooms = dal.Rooms.Where(x => !r_booked_rooms.Contains(x.rid)).ToList();
            var r_roomHotelGroup = r_available_rooms.GroupBy(x => x.hid);
            var r_hotelIds = r_roomHotelGroup.Where(x => x.Count() >= noofrooms).Select(z => z.Key).ToList();

            var r_hotels = dal.Hotelss.Where(a => a.address == hotelsdetailsss.address).Where(x => r_hotelIds.Contains(x.hid)).OrderByDescending(y => y.star).ToList();
            ViewBag.r_hotel = r_hotels;
            var r_images = dal.Hphotos.ToList();
            ViewBag.r_image = r_images;

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
