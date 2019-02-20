using Microsoft.EntityFrameworkCore;
using NurseryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Data
{
    public class NurseryDbContext : DbContext
    {
        public NurseryDbContext(DbContextOptions<NurseryDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Ranier Cherry Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "abcdef",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"

                },
                new Product
                {
                    ID = 2,
                    Name = "Yoshino Cherry Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "qwerty",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 3,
                    Name = "Rhododendron",
                    Type = Product.PlantType.Shrub,
                    Sku = "123345",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 4,
                    Name = "Dwarf Apple Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "yuiop",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 5,
                    Name = "Dwarf Plum Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "567ghj",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 6,
                    Name = "Red Raspberry",
                    Type = Product.PlantType.Shrub,
                    Sku = "098lkjh",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 7,
                    Name = "Echivera",
                    Type = Product.PlantType.Houseplant,
                    Sku = "zxcv34",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 8,
                    Name = "Magestic Palm",
                    Type = Product.PlantType.Houseplant,
                    Sku = "9d9emd",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 9,
                    Name = "California Black Oak",
                    Type = Product.PlantType.Tree,
                    Sku = "098asdf",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                },
                new Product
                {
                    ID = 10,
                    Name = "Giant Sunflower",
                    Type = Product.PlantType.Flower,
                    Sku = "abci876k",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                }
                );
        }
        public DbSet<Product> Products { get; set; }

    }
}
