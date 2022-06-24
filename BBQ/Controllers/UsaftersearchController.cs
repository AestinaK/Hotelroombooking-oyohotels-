using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class UsaftersearchController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            return View();
        }

       /* public IActionResult search(string address)
        {
            // var userlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();
            var result = dal.Roomdetailss.Where(X => X.address.Equals(address)).ToList();
            ViewBag.datas = result;
            return View();
        }*/

    } 
}
