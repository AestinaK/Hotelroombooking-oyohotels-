using BBQ.Models;
using Microsoft.AspNetCore.Mvc;

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
                    password = us.password,
                    role="user"
                    
                };

                Userregister register = new Userregister()
                {

                    name = us.name,
                    email = us.email,
                    password=us.password


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

    }
}
