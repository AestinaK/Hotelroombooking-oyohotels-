using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
   
    public class PriceaddController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            var listtype = dal.Roomtypes.ToList();
            ViewBag.types = listtype;
            return View();
        }

        public IActionResult Addprice( Pricevm vm)
        {
            var hotel = dal.Hotelss.Where(x => x.name == vm.hname).ToList();
            var hid = hotel[0].hid;
            var roomtyp=dal.Roomtypes.Where(x => x.type == vm.roomtype).ToList();
            var rtid = roomtyp[0].rtid;


            try
            {
                Price login = new Price()
                {
                    hid=hid,
                    rtid=rtid,
                    price=vm.price

                };

                if (vm.roomtype.Equals("Classic"))
                {
                    var hot = from x in dal.Hotelss where x.hid == hid select x;

                    foreach(var item in hot)
                    {
                        item.price = vm.price;

                    }
                    dal.SaveChanges();
                }

                dal.Prices.Add(login);
                dal.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            return Redirect("/Priceadd/Index");
        }
    }
}
