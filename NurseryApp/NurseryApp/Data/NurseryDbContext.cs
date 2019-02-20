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
                    Type = Product.PlantType.Tree
                },
                new Product
                {
                    ID = 2,
                    Name = "Yoshino Cherry Tree",
                    Type = Product.PlantType.Tree
                },
                new Product
                {
                    ID = 3,
                    Name = "Rhododendron",
                    Type = Product.PlantType.Shrub
                },
                new Product
                {
                    ID = 4,
                    Name = "Dwarf Apple Tree",
                    Type = Product.PlantType.Tree
                },
                new Product
                {
                    ID = 5,
                    Name = "Dwarf Plum Tree",
                    Type = Product.PlantType.Tree
                },
                new Product
                {
                    ID = 6,
                    Name = "Red Raspberry",
                    Type = Product.PlantType.Shrub
                },
                new Product
                {
                    ID = 7,
                    Name = "Echivera",
                    Type = Product.PlantType.Houseplant
                },
                new Product
                {
                    ID = 8,
                    Name = "Magestic Palm",
                    Type = Product.PlantType.Houseplant
                },
                new Product
                {
                    ID = 9,
                    Name = "California Black Oak",
                    Type = Product.PlantType.Tree,
                },
                new Product
                {
                    ID = 10,
                    Name = "Giant Sunflower",
                    Type = Product.PlantType.Flower
                }
                );
        }
        public DbSet<Product> Products { get; set; }

    }
}
