using Mcf.Order.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mcf.Order.Service.Context
{
    public class OrderContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public OrderContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<CartEntity> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }
    }
}
