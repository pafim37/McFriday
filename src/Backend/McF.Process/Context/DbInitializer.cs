using McF.Process.Models;
using Microsoft.EntityFrameworkCore;

namespace McF.Process.Context
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var drinkType = new ProductType() { Id = 1, Name = "Drink" };
            var sandwitchType = new ProductType() { Id = 2, Name = "Sandwich" };
            var friesType = new ProductType() { Id = 3, Name = "Fries" };
            var setType = new ProductType() { Id = 4, Name = "Fries" };

            modelBuilder.Entity<ProductType>().HasData(
                drinkType,
                sandwitchType,
                friesType,
                setType
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, ProductTypeId = 1, Name = "Cocacola", ImageByteArray = File.ReadAllBytes("img//cocacola.jpg") },
                new Product() { Id = 2, ProductTypeId = 1, Name = "Sprite", ImageByteArray = File.ReadAllBytes("img//sprite.jpg") },
                new Product() { Id = 3, ProductTypeId = 1, Name = "Fanta", ImageByteArray = File.ReadAllBytes("img//fanta.jpg") },
                new Product() { Id = 4, ProductTypeId = 2, Name = "Hamburger" },
                new Product() { Id = 5, ProductTypeId = 2, Name = "Cheesehamburger"},
                new Product() { Id = 6, ProductTypeId = 2, Name = "Spicy Burger"},
                new Product() { Id = 7, ProductTypeId = 3, Name = "Small fries"},
                new Product() { Id = 8, ProductTypeId = 3, Name = "Medium fries"},
                new Product() { Id = 9, ProductTypeId = 3, Name = "Large fries"}
            );
        }
    }
}
