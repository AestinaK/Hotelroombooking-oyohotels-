using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class BookRoom : Controller
    {
        DataContext dal = new DataContext();
        /*public IActionResult Index()
        {
            return View();
        }*/

        
        public IActionResult Index(int hid,string user, string sstart, string eend, int noofrooms,int rtid)
        {


            var start = DateOnly.Parse(sstart);
            var end = DateOnly.Parse(eend);

            ViewBag.rooms = noofrooms;
            ViewBag.start = sstart;
            ViewBag.end = eend;
            ViewBag.hid = hid;

            


            

            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct().ToList();
            var available_rooms = dal.Rooms.Where(a => a.hid == hid).Where(b => b.rtid == rtid).Where(x => !booked_rooms.Contains(x.rid)).ToList();
            int nf = noofrooms - 1;

           List<Roomreservation> bookrooms = new List<Roomreservation>();
            try
            {
                for (int i = 0; i <=nf; i++)
            {
                var r = available_rooms[i].rid;

                    bookrooms.Add(new Roomreservation()
                    {
                        hid = hid,
                        checkin = start,
                        checkout = end,
                        roomid = r,

                        user = user

                    }) ;




                }

                int t = bookrooms.Count - 1;
               for (int i = 0; i <=t; i++) { 
                dal.Roomreservations.Add(bookrooms[i]);
                }

                var rec = dal.Hotelss.Where(a => a.hid == hid).SingleOrDefault().star;

                Recommend reco = new Recommend()
                {
                     user = user,
                    star = rec
                    

                };

                dal.Recommends.Add(reco);

                dal.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




            /* var roomTypeGroup = available_rooms.GroupBy(x => x.rtid).ToList();

             //var price = dal.Prices.Where(b => b.hid==hotelID).Where(x=>roomTypeGroup.Contains(x.rtid));
             //mailay ajha thapay ko 
             var grouptype = roomTypeGroup.Where(x => x.Count() >= noofrooms).ToList();

             var grouptypekey = grouptype.Select(z => z.Key).ToList();
             var details = dal.Roomtypes.Where(x => grouptypekey.Contains(x.rtid)).ToList();
             var price = dal.Prices.Where(b => b.hid == hid).Where(x => grouptypekey.Contains(x.rtid));



             //  var roomtypeid=grouptype.Select rtid 

             ViewBag.typess = details;
             ViewBag.price = price;
 */
            var print = dal.Roomreservations.Where(y => y.checkin == start).Where(x => x.checkout == end).ToList();
            ViewBag.roomreservation = print;
            var hidd=print[0].hid;

            var rtidd = print[0].roomid;

            var hotel = dal.Hotelss.Where(x => x.hid == hidd).ToList();
            var hotelname = hotel[0].name;

            ViewBag.hname = hotelname;

            var roomes = dal.Roomtypes.Where(x => x.rtid == rtid).ToList();
            var roomt = roomes[0].type;
            ViewBag.roomtype = roomt;

            var price=dal.Prices.Where(y => y.hid == hid).Where(x => x.rtid == rtid).ToList();
            var roomp=price[0].price;
            ViewBag.price = roomp;

            var total = roomp * noofrooms;
            ViewBag.total = total;

            return View();
        }

        public IActionResult Rating(Comment vm)

        {
            dal.Comments.Add(vm);
            dal.SaveChanges();
            return RedirectToAction("Index", "Landing");
        }




    }
}
