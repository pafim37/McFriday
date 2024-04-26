using McF.Process.Models;
using Microsoft.EntityFrameworkCore;

namespace McF.Process.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }

        public DbSet<Entity> Entities { get; set; }
    }
}
