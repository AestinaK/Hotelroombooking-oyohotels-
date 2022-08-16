using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace BBQ.Controllers
{
    public class LandingController : Controller
    {

        DataContext dal = new DataContext();
        public IActionResult Index()
        {

             var addresss = HttpContext.Session.GetString("address"); 
            var email = HttpContext.Session.GetString("email");
            var rec = dal.Recommends.Where(a=> a.user == email).ToList();
            var address = "bhadrapur";
            var no=rec.Count();
            
            var hotele = dal.Hotelss.Where(x => x.address == address).ToList();
            var hc=hotele.Count();
            var hcc = hc - 1;
            var c = no - 1;
            
            List<Hotels> hot= new List<Hotels>();
            var newdata = hotele.Where(x => rec.Any(y => y.star == x.star)).Select(x => new Hotels()
            {
                address = x.address,
                name = x.name,
                star = x.star,
                hid = x.hid,
                price = x.price
            }).ToList();
            var com = dal.Comments.ToList();

            var ra = com.Where(x=> newdata.Any(y=>y.hid==x.hid)).Select(x=> new Comment()
            {
                hid = x.hid,
                rating = x.rating
            }).ToList();
           
            var racount=ra.Count();
            var racountt = racount - 1;

            /*var resw = ra.GroupBy(x => x.hid);
            foreach (var result in resw)
            {
                var ratingavg = result.Average(x=>x.rating);
                Console.WriteLine(ratingavg);
            }*/

            var result = ra.GroupBy(s => s.hid)
                     .Select(g => new { hid = g.Key, Avg = g.Average(s => s.rating) }).OrderByDescending(s => s.Avg).ToList();

            /*var detailss = dal.Hotelss.Where(x => x.hid == result[0].hid);*/
            /*var des = result.OrderByDescending(s => s.Avg).ToList();*/

            List<Hotels> avg = new List<Hotels>();

            /*for (int i=0; i<= result.Count()-1; i++)
            {
                avg.Add()
            };*/
           

            var ritu = hotele.Where(x => result.Any(y => y.hid == x.hid)).Select(x => new Hotels()
            {
                address = x.address,
                name = x.name,
                star = x.star,
                hid = x.hid,
                price = x.price
            }).ToList();



            /*for(int i = 0; i <= hcc; i++)
            {
                for (int j = 0; j <= c; j++)
                {

                    hot.Add(dal.Hotelss.Where(y => y.hotele[i].star == rec[j].star));

                }
            }*/
            ViewBag.data = newdata;

            var image = dal.Hphotos.ToList();

            ViewBag.photo = image;

            return View();
        }


       /* public IActionResult search(string address )
        {
            var userlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();
            var result = dal.Roomdetailss.Where(X => X.address.Equals(address)).ToList();
            ViewBag.datas = result;
            return RedirectToAction("Index", "Test");
        }*/
    }
}
