using McF.Product.Service.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace McF.Product.Service.Context
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

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity() { Id = 1, ProductTypeId = 1, Name = "Cocacola", ImageByteArray = File.ReadAllBytes("..//McF.Service//img//cocacola.jpg") },
                new ProductEntity() { Id = 2, ProductTypeId = 1, Name = "Sprite", ImageByteArray = File.ReadAllBytes("..//McF.Service//img//sprite.jpg") },
                new ProductEntity() { Id = 3, ProductTypeId = 1, Name = "Fanta", ImageByteArray = File.ReadAllBytes("..//McF.Service//img//fanta.jpg") },
                new ProductEntity() { Id = 4, ProductTypeId = 2, Name = "Hamburger" },
                new ProductEntity() { Id = 5, ProductTypeId = 2, Name = "Cheesehamburger" },
                new ProductEntity() { Id = 6, ProductTypeId = 2, Name = "Spicy Burger" },
                new ProductEntity() { Id = 7, ProductTypeId = 3, Name = "Small fries" },
                new ProductEntity() { Id = 8, ProductTypeId = 3, Name = "Medium fries" },
                new ProductEntity() { Id = 9, ProductTypeId = 3, Name = "Large fries" }
            );
        }
    }
}
