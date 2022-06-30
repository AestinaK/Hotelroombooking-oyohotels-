using Microsoft.AspNetCore.Mvc;




namespace BBQ.Controllers
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ReportController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }


    public class PhotoController : Controller
    {
       
           [HttpPost]
            [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accident(AccidentViewModel AccidentReport)
        {
            string folderpath = "image/";
            if (ModelState.IsValid)
            {

                Accident accident = new Accident()
                {
                    Number = AccidentReport.Number,
                    Image_Urls = await UploadImage(folderpath, AccidentReport.file),
                    Contact = AccidentReport.Contact,
                    Location = AccidentReport.Location,
                    ReportersName = AccidentReport.ReportersName,
                };
                //product.ImageUrl = "hello";//await UploadImage(folderpath, file); //use the function here from Doctor Patient Model

                dal.accidents.Add(accident);
                dal.SaveChanges();

                return RedirectToAction("Index", "Dash1");
            }
            return View();
            //return View(AccidentReport);
        }



        public async Task<string> UploadImage(string folderpath, IFormFile file)
        {
            folderpath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderpath;
        }
    }
}
