using BBQ.Models;
using Microsoft.AspNetCore.Mvc;





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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> UploadImage(string folderpath, IFormFile file)
        {
            folderpath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderpath;
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(Photovm vm)
        {
            var ho = dal.Hotelss.Where(x => x.name == vm.hname).ToList();
            int hid = ho[0].hid;
            string folderpath = "hotelimage/";
            Photo upload1=new Photo()
            {
                hid = hid,
                photosurl= await UploadImage(folderpath,vm.img1)



            };
            Photo upload2 = new Photo()
            {
                hid = hid,
                photosurl = await UploadImage(folderpath, vm.img2)



            };
            Photo upload3 = new Photo()
            {
                hid = hid,
                photosurl = await UploadImage(folderpath, vm.img3)



            };
            Photo upload4 = new Photo()
            {
                hid = hid,
                photosurl = await UploadImage(folderpath, vm.img4)



            };
            Photo upload5 = new Photo()
            {
                hid = hid,
                photosurl = await UploadImage(folderpath, vm.img5)



            };
            dal.Photos.Add(upload1);
            dal.Photos.Add(upload2);
            dal.Photos.Add(upload3);
            dal.Photos.Add(upload4);
            dal.Photos.Add(upload5);
            dal.SaveChanges();
            return RedirectToAction("Index", "Photo");
           
        }
       
    }

}