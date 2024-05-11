using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia3.DAL;
using Pronia3.Models;
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

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Include(x=>x.ProductPhotos).Where(x=>x.ProductPhotos.Count>0).ToListAsync();
            return View(products);
        }
      
        public IActionResult Detail(int? id)
        {
            return View();
        }
       
    }
}
