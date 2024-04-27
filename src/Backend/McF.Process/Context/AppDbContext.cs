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

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(e => e.ProductType)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ProductTypeId)
                .IsRequired();

            new DbInitializer(modelBuilder).Seed();
        }

    }
}
