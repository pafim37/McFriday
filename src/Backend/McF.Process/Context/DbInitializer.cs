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
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Type = Models.Primitives.ProductType.Drink, Name = "CocaCola", PhotoPath=string.Empty},
                new Product() { Id = 2, Type = Models.Primitives.ProductType.Drink, Name = "Sprite", PhotoPath=string.Empty},
                new Product() { Id = 3, Type = Models.Primitives.ProductType.Drink, Name = "Fanta", PhotoPath=string.Empty},
                new Product() { Id = 4, Type = Models.Primitives.ProductType.Sandwich, Name = "Hamburger", PhotoPath=string.Empty},
                new Product() { Id = 5, Type = Models.Primitives.ProductType.Sandwich, Name = "Cheesehamburger", PhotoPath=string.Empty},
                new Product() { Id = 6, Type = Models.Primitives.ProductType.Sandwich, Name = "Spicy Burger", PhotoPath=string.Empty},
                new Product() { Id = 7, Type = Models.Primitives.ProductType.Fries, Name = "Small fries", PhotoPath=string.Empty},
                new Product() { Id = 8, Type = Models.Primitives.ProductType.Fries, Name = "Medium fries", PhotoPath=string.Empty},
                new Product() { Id = 9, Type = Models.Primitives.ProductType.Fries, Name = "Large fries", PhotoPath=string.Empty}
            );
        }
    }
}
