namespace Pronia3.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Product> Products{ get; set; }    
    }
}
