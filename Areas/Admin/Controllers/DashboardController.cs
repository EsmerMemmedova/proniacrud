using Microsoft.AspNetCore.Mvc;

namespace Pronia3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {

            return View();
        }
    }
}
