using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Session;
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
                var sessionlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();

                string em = sessionlist[0].email;
                string pw = sessionlist[0].password;
                string role = sessionlist[0].role;
                

                HttpContext.Session.SetString("role", role);
                
                HttpContext.Session.SetString("email", em);
                HttpContext.Session.SetString("password", pw);

                return Redirect("/Landing/Index");
            }

            else if (userlist.Count() == 1 && userlist[0].email.Equals(email) && userlist[0].password.Equals(password) && userlist[0].role.Equals("admin"))

            {
                var sessionlist= dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(password)).ToList();
                
                //String email = userlist[0].email;
               // String name = userlist[0].username;
               // String role = userlist[0].role;
               string em=sessionlist[0].email;
                string pw=sessionlist[0].password;
                string role=sessionlist[0].role;
                string hm = sessionlist[0].hname;

                
                HttpContext.Session.SetString("role", role);
                HttpContext.Session.SetString("hname", hm);
                HttpContext.Session.SetString("email", em);
                HttpContext.Session.SetString("password", pw);
                return Redirect("/AdDash1/Dash1Index");
            }
            else
            {
                return Redirect("/Ususerlogin/Index");

            }




        }
    }

}