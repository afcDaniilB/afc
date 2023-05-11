using Microsoft.EntityFrameworkCore;


namespace ShopContext
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public ShopContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=shop;Username=shop;Password=4Thehorde!");
        }
    }
}