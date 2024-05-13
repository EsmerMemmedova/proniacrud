using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia3.Models
{
	public class Slider
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Duzgun daxil edin")]
		public string Title { get; set; }
		[StringLength(30,ErrorMessage ="Uzunlugu Duzgun Daxil edin")]
		public string SubTitle { get; set; }
		public string Description { get; set; }
		public string? ImgUrl { get; set; }

		[NotMapped]
		public IFormFile PhotoFile { get; set; }
	}
}
