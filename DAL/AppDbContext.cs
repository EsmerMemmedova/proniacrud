using Microsoft.EntityFrameworkCore;
using Pronia3.Models;

namespace Pronia3.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public  DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; } 
    }
}
