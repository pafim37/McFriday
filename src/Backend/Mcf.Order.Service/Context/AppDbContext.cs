using Mcf.Order.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mcf.Order.Service.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Cart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }
    }
}
