using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pronia3.DAL;
using Pronia3.Models;
using System.Reflection.Metadata;

namespace Pronia3.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		AppDbContext _context;
		IWebHostEnvironment _environment;

        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index()
		{

			List<Slider> sliders = _context.Sliders.ToList();
			return View(sliders);
		}

		public IActionResult Create()
		{


			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Slider slider)
		{
			if (!slider.PhotoFile.ContentType.Contains("image/"))
		    {
                ModelState.AddModelError("PhotoFile","Formati duzgunn daxil edin");
				return View();

			}
			

			string filename = slider.PhotoFile.FileName;
			string path = _environment.WebRootPath + @"\Upload\Slider\" + filename;

            using (FileStream fileStream = new(path, FileMode.Create))
			{
				slider.PhotoFile.CopyTo(fileStream);

			}
			slider.ImgUrl = filename;

			if(!ModelState.IsValid)
            {
				return View();
			}
			await _context.Sliders.AddAsync(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		 public IActionResult Update(int id)
		{
			return View(_context.Sliders.Find(id));
		}
		public IActionResult Delete(int id)
		{
			
			var slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
			string path = _environment.WebRootPath + @"\Upload\Slider" + slider.ImgUrl;
			FileInfo fileInfo = new FileInfo(path);
			if(fileInfo.Exists)
			{
				fileInfo.Delete();
			}
            _context.Sliders.Remove(slider);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));


        }
	}
}
