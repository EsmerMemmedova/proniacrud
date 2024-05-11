namespace Pronia3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CatagoryId { get; set; } 
        public Catagory Catagory { get; set;}
      public  List <ProductPhoto> ProductPhotos { get; set; }
      public  List<Tag> Tags { get; set; }
    }
}
