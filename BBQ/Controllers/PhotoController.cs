using BBQ.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;




namespace BBQ.Controllers
{
    /* private readonly IWebHostEnvironment _webHostEnvironment;
     public ReportController(IWebHostEnvironment webHostEnvironment)
     {
         _webHostEnvironment = webHostEnvironment;
     }*/


    public class PhotoController : Controller
    {
        DataContext dal = new DataContext();
        public IActionResult Index()
        {
            return View();
        }
       
    }

}