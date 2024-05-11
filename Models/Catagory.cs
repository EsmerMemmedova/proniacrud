using System.ComponentModel.DataAnnotations;

namespace Pronia3.Models
{
    public class Catagory
    { 
        public int Id { get; set; }
        [Required(ErrorMessage ="Duzgun doldur!")]
        public string Name { get; set; }
      public  List<Product>? Products { get; set; }
    }
}
