using BBQ.Models;
using BBQ.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
            // var result = dal.Roomdetailss.Where(X => X.address.Equals(address)).ToList();
            /* var res = dal.Hotelss.Where(x => x.address.Contains(address) && x.Rooms.Count(y => !y.Reservations.Any(z => z.StartDate <= start && z.EndDate >= start && z.StartDate <= end && z.EndDate >= end))>= count)




                 var res = dal.Hotelss.Where(x => x.address.Contains(address) && x.Roomreservations.Count(y => !y.RoomReservations.Any(z => z.checkin <= checkin && z.checkout >= checkin && z.checkin <= checkout && z.checkout >= checkout)) >= noofroom);


             var price_low = hotel.select(a => a.rooms.min(b => b.roomtype.price));

             ViewBag.datas = result ; */

            ViewBag.address = vm.address;
            ViewBag.checkin = vm.start;
            ViewBag.checkout = vm.end;
            ViewBag.noofroom = vm.noofrooms;

            DateOnly start = DateOnly.Parse(vm.start);
            DateOnly end = DateOnly.Parse(vm.end);


            var hotelse = dal.Hotelss.Where(x => x.address.Equals(vm.address)).ToList();

            var booked_rooms = dal.Roomreservations.Where(x => (start >= x.checkin && start <= x.checkout) || (end >= x.checkin && end <= x.checkout)).Select(a => a.roomid).Distinct();


             /*var bookedroom = from b in dal.Roomreservations where
                              ((vm.start >= b.checkin) && (vm.start <= b.checkout))||
                              ((vm.end >= b.checkin) && (vm.end <= b.checkout))||
                              ((vm.start<=b.checkin)&&(vm.end>=b.checkin))&&((vm.end<=b.checkout))||
                              ((vm.start>=b.checkin)&&(vm.start<=b.checkout))&&
                              ((vm.end>=b.checkout))||
                              ((vm.start<=b.checkin)&&(vm.end>=b.checkout))
                              select b;
            var availablerooms = dal.Rooms.Where(r => !bookedroom.Any(b => b.roomid == r.rid)).ToList();*/
           

/*            var bookedroo = dal.Roomreservations.Where(room => room.roomid.ToString().All(res => res.checkout < vm.start || res.checkin > vm.end)).ToList();
*/            ViewBag.datas = hotelse;
            /*var bookedroom = dal.Roomreservations.Where(room => room.Roomreservations.All(z => z.checkin <= vm.start && z.checkout >= vm.start && z.checkin <= vm.end && z.checkout >= vm.end)).ToList();
            Where(room => room.Reservations.All(res => res.Departure < arrivalDate || res.Arrival > departureDate))
*/
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