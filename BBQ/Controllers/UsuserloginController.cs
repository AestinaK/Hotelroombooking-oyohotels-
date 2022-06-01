using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class UsuserloginController : Controller
    {
        DataContext dal = new DataContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var userlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();

            if (userlist.Count() == 1 && userlist[0].email.Equals(email) && userlist[0].password.Equals(password) && userlist[0].role.Equals("user"))

            {
                return Redirect("/Landing/Index");
            }

            else if (userlist.Count() == 1 && userlist[0].email.Equals(email) && userlist[0].password.Equals(password) && userlist[0].role.Equals("admin"))

            {
                return Redirect("/AdDash1/Dash1Index");
            }
            else
            {
                return Redirect("/Ususerlogin/Index");

            }




        }
    }

}