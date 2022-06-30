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
    


    public class PhotoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        DataContext dal = new DataContext();


        public async Task<string> UploadImage(string folderpath, IFormFile file)
        {
            folderpath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderpath;
        }



        public IActionResult Index(Photovm vm)
        {


            Photo upload=new Photo()
            {



            };

            return View();
        }
       
    }

}