using Microsoft.AspNetCore.Mvc;

namespace BBQ.Controllers
{
    public class AdReportController : Controller
    {
        public IActionResult ReportIndex()

        {
            return View();
        }
    }
}
