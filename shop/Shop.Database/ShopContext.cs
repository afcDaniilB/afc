using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=4Thehorde!");
        }
    }
}
