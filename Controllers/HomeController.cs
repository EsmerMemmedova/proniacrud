using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia3.DAL;
using Pronia3.Models;
using Pronia3.ViewModel;
using System.Diagnostics;

namespace Pronia3.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Product> products = _context.Products.Include(x => x.ProductPhotos).Where(x => x.ProductPhotos.Count > 0).ToList();

            HomeVM homeVM = new HomeVM()
            {
                Products = products,
                Sliders = _context.Sliders.ToList()
            };


            return View(homeVM);

        }
           

        
      
        public IActionResult Detail(int? id)
        {
            return View();
        }
       
    }
}
