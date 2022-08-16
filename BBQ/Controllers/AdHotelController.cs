using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace BBQ.Controllers
{
    public class AdHotelController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Hadd vm)
        {


            try
            {
                Userregister login = new Userregister()
                {
                   name=vm.username,
                   email=vm.email,
                   password = Encryption(vm.password)

                };

                Ususerlogin login1 = new Ususerlogin()
                {
                    
                    email = vm.email,
                    password = Encryption(vm.password),
                    role="admin",
                    hname=vm.hotelname
                };
                Hotels login3 = new Hotels()
                {
                    name=vm.hotelname,
                    address=vm.address,
                    star=vm.star,
                    price=0

                };



                dal.Hotelss.Add(login3);
                dal.Ususerlogins.Add(login1);
                dal.Userregisters.Add(login);

                dal.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            dal.SaveChanges();

            return RedirectToAction("Index", "Ususerlogin");

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



    }
}
