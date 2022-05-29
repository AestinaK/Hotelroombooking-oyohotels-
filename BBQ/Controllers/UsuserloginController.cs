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
        public IActionResult insert(Ususerlogin vmodel)
        {
            try
            {

                dal.Ususerlogins.Add(vmodel);
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Redirect("/Landing/Index");

        }
    }

}