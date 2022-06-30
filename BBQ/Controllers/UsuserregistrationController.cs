using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace BBQ.Controllers
{
    public class UsuserregistrationController : Controller
    {
        DataContext dal= new DataContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Usersignup us)
        {

            try
            {
                Ususerlogin login = new Ususerlogin()
                {
                    email = us.email,
                    password = Encryption(us.password),
                    role ="user",
                    hname="test"


                };

                Userregister register = new Userregister()
                {

                    name = us.name,
                    email = us.email,
                   
                    password=Encryption(us.password)


                };

                dal.Ususerlogins.Add(login);
                dal.Userregisters.Add(register);
                dal.SaveChanges();


            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Redirect("/Ususerlogin/Index");
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
