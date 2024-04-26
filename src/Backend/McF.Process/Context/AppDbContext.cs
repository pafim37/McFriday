using McF.Process.Models;
using McF.Process.Models.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace McF.Process.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(d => d.Type)
                .HasConversion(new EnumToStringConverter<ProductType>());
            new DbInitializer(modelBuilder).Seed();
        }

    }
}
