using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace BBQ.Controllers
{
    public class UsuserregistrationController : Controller
    {
        DataContext dal = new DataContext();
        /*  public IActionResult Index()
          {
              return View();
          }*/

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Ususerlogin us)
        {

            //ModelState.Remove("password");
            var data = dal.Ususerlogins.ToList();

            if (dal.Ususerlogins.Where(x => x.email.Equals(us.email)).Count() >= 1)
            {
                ModelState.AddModelError("email", "already registered with this email");
            }

            /*Ususerlogin login = new Ususerlogin()
            {
                email = us.email,
                
                password=us.password,
                name=us.name,
                role = "user",
                hname = "test"


            };*/

            /*Userregister register = new Userregister()
              {

                  name = us.name,
                  email = us.email,
                  password = Encryption(us.password)


              };*/

            if (CheckUser(data, us.email))
            {
                ModelState.AddModelError("email", "already registered with this email");
            }


            if (ModelState.IsValid)
            {




                us.password = Encryption(us.password);

                dal.Ususerlogins.Add(us);
                /* dal.Userregisters.Add(register);*/
                dal.SaveChanges();
                return View(us);
            }

            return View(us);





        }


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

        //binary search algorithem for user exist search
        private static bool CheckUser(List<Ususerlogin> userlogin, string email)
        {
            int left = 0;
            int right = userlogin.Count - 1;
            bool check = true;
            while (left < right)
            {
                int mid = left + ((right - left) / 2);
                if (userlogin[mid].email.Equals(email))
                {
                    return true;
                }
                else
                {
                    for (int i = left; i < mid; i++)
                    {
                        if (userlogin[i].email.Equals(email))
                        {
                            check = true;
                            right = mid - 1;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    for (int j = mid; j < right; j++)
                    {
                        if (userlogin[j].email.Equals(email))
                        {
                            check = true;
                            left = mid + 1;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                }
                if (check == false)
                {
                    return false;
                }
            }
            return false;
        }




    }
}
