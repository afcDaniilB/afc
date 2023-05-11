using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopContext
{
    public class ProductRepos : IRepository<Product>
    {
        readonly DbSet<Product> _dbSet;
        readonly ShopContext _context;
        public ProductRepos(DbSet<Product> dbSet, ShopContext context)
        {
            _dbSet = dbSet;
            _context = context;
        }
        public void AddProduct(string name, int count, int cost)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Count = count,
                Cost = cost
            };
            _dbSet.Add(product);
            _context.SaveChanges();
        }
        public Product FindById(Guid? id)
        {
            return _dbSet.Find(id);
        }
        public void UpdateProduct(string name, int count, int cost, Guid id)
        {
            var product = FindById(id);
            product.Name = name;
            product.Cost = cost;
            product.Count = count;
            _dbSet.Update(product);
            _context.SaveChanges();
        }
    }
}
