using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopContext
{
    public static class ServiceCollection
    {
        public static void AddDatabase(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ShopContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DBConnection")), ServiceLifetime.Singleton);
            service.AddTransient<IRepository<Product>, ProductRepos>();

        }
    }
}
