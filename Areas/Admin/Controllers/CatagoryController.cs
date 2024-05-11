using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia3.DAL;
using Pronia3.Models;

namespace Pronia3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        AppDbContext _context;

        public CatagoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Catagory> catagories = _context.Catagories.Include(x => x.Products).ToList();

            return View(catagories);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Catagories.Add(catagory);
                _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var catagory=_context.Catagories.FirstOrDefault(x=>x.Id==id);
            if (catagory == null)
            {
                return RedirectToAction("Index");
            }
            return View(catagory);
        }
        public IActionResult Update(Catagory newcatagory)
		{
			var oldcatagory = _context.Catagories.FirstOrDefault(x => x.Id == newcatagory.Id);
			if (oldcatagory == null)
			{
				return RedirectToAction("Index");
			}
            if (!ModelState.IsValid)
            {
                return View();
            }
            oldcatagory.Name = newcatagory.Name;
            _context.SaveChanges();
			return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            var catagory=_context.Catagories.FirstOrDefault(x => x.Id == id);
            _context.Catagories.Remove(catagory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
