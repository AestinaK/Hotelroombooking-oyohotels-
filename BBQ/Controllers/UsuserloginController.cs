using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Session;

using System.Security.Cryptography;

using System.Text;

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
            var userlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(Encryption(password))).ToList();

            if (userlist.Count() == 1 && userlist[0].email.Equals(email) && userlist[0].password.Equals(Encryption(password)) && userlist[0].role.Equals("user"))

            {
                var sessionlist = dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(Encryption(password))).ToList();

                string em = sessionlist[0].email;
                string pw = sessionlist[0].password;
                string role = sessionlist[0].role;
                

                HttpContext.Session.SetString("role", role);
                
                HttpContext.Session.SetString("email", em);
                HttpContext.Session.SetString("password", pw);

                return Redirect("/Landing/Index");
            }

            else if (userlist.Count() == 1 && userlist[0].email.Equals(email) && userlist[0].password.Equals(Encryption(password)) && userlist[0].role.Equals("admin"))

            {
                var sessionlist= dal.Ususerlogins.Where(X => X.email.Equals(email)).Where(X => X.password.Equals(Encryption(password))).ToList();
                
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

        public IActionResult logout()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.SetString("isLoggedIn", "false");

            return RedirectToAction("Index", "Ususerlogin");
        }

        public IActionResult changepassword()
        {
           

            return View();
        }

        public IActionResult pchange(pchangevm vm)
        {
            if (vm.pw.Equals(vm.oldp))
            {
                var hot = from x in dal.Ususerlogins where x.email == vm.email select x;

                foreach (var item in hot)
                {
                    item.password = Encryption(vm.newp);

                }
                dal.SaveChanges();
            }


            return RedirectToAction("Index", "Ususerlogin");
        }



        /*public IActionResult changeh(Hchange vm)
        {
            if (vm.pw.Equals(vm.oldp))
            {
                var hot = from x in dal.Ususerlogins where x.email == vm.email select x;

                foreach (var item in hot)
                {
                    item.password = Encryption(vm.newp);

                }
                dal.SaveChanges();
            }


            return RedirectToAction("Index", "Ususerlogin");
        }*/





        public string Encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //create a new string by using the encrypted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();

        }

    }

}