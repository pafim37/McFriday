using McF.Product.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace McF.Product.Service.Context
{
    public class ProductContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public ProductContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Models.ProductEntity> Products { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ProductEntity>()
                .HasOne(e => e.ProductType)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ProductTypeId)
                .IsRequired();

            new DbInitializer(modelBuilder).Seed();
        }

    }
}
