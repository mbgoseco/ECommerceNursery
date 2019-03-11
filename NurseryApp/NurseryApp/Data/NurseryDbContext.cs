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
            modelBuilder.Entity<BasketProduct>().HasKey(ce => new { ce.BasketID, ce.ProductID });
            modelBuilder.Entity<CheckoutProduct>().HasKey(ce => new { ce.CheckoutID, ce.ProductID });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Rainier Cherry Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "abcdef",
                    Description = "Rainier Cherry (Prunus avium 'Rainier') is an outstanding sweet cherry tree that produces large, delicious yellow fruit with a beautiful dark red blush. It's an easy to grow, low maintenance backyard variety that was originally produced by crossing the popular Bing red cherry with the age-old favorite, Van red cherry. Ships as 4 to 5 ft bareroot.",
                    Price = 1.25m,
                    Img = "/Assets/ProductPictures/RainierCherryTree.jpg",
                    Bulk = false
                },
                new Product
                {
                    ID = 2,
                    Name = "Yoshino Cherry Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "qwerty",
                    Description = "The classic elegance of an iconic cherry tree is second to none, and the Yoshino is no exception. With good looks and the strength to match, our Yoshino Cherry Tree ticks all the boxes of a landscape favorite. Ships as 3 to 4 ft bareroot.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/YoshinoCherryTree.jpg",
                    Bulk = false
                },
                new Product
                {
                    ID = 3,
                    Name = "Nova Zembla Rhododendron",
                    Type = Product.PlantType.Shrub,
                    Sku = "123345",
                    Description = "A small, dense, upright, evergreen shrub prized for its large trusses of showy, bright red flowers. A cold hardy rhododendron that thrives in cooler regions but benefits from protection from winter winds. Flower color develops a deep pink tone in sunnier exposures. Very useful in foundation plantings or as a landscape accent. Ships as 24 inch potted.",
                    Price = 0.75m,
                    Img = "/Assets/ProductPictures/RhododendronNova.jpg",
                    Bulk = false
                },
                new Product
                {
                    ID = 4,
                    Name = "Dwarf Honeycrisp Apple Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "yuiop",
                    Description = "Developed at the University of Minnesota, this hardy apple tree bears crisp, sweet fruit. However, this tree requires some extra care to grow and tends to only bear a heavy crop every two years. Because it's prone to bitter pit, which creates dark spots that are dry, spongy and have a bitter taste, you may need to make adjustments to the nitrogen and potassium levels in the soil. Adding Quik-Cal Pelletized Calcium may be necessary. This apple variety performs better in cooler climates than warmer regions. Ripens in early September. Honeycrisp took the apple world by storm when it was first introduced and is still a flavor favorite. Ships as 30 inch potted.",
                    Price = 1.50m,
                    Img = "/Assets/ProductPictures/DwarfApple.jpg",
                    Bulk = false
                },
                new Product
                {
                    ID = 5,
                    Name = "Toka (Bubblegum) Plum Tree",
                    Type = Product.PlantType.Tree,
                    Sku = "567ghj",
                    Description = "Easy-to-grow fruit that smells and tastes like bubblegum! This heavy-producing tree yields crops of medium-to-large plums. Fruit has reddish-bronze skin and juicy yellow flesh that’s as sweet as candy. Tree has a lovely, erect, vase shape. Originates from South Dakota in 1911. Tolerant of temperatures as low as -50ºF. Cold-hardy. Clingstone. Ripens in July. Ships as 2 to 3 ft potted.",
                    Price = 0.85m,
                    Img = "/Assets/ProductPictures/TokaPlum.jpg",
                    Bulk = false
                },
                new Product
                {
                    ID = 6,
                    Name = "Red Raspberry",
                    Type = Product.PlantType.Shrub,
                    Sku = "098lkjh",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = false
                },
                new Product
                {
                    ID = 7,
                    Name = "Echivera",
                    Type = Product.PlantType.Houseplant,
                    Sku = "zxcv34",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = false
                },
                new Product
                {
                    ID = 8,
                    Name = "Magestic Palm",
                    Type = Product.PlantType.Houseplant,
                    Sku = "9d9emd",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = false
                },
                new Product
                {
                    ID = 9,
                    Name = "California Black Oak",
                    Type = Product.PlantType.Tree,
                    Sku = "098asdf",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = false
                },
                new Product
                {
                    ID = 10,
                    Name = "Giant Sunflower",
                    Type = Product.PlantType.Flower,
                    Sku = "abci876k",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = false
                },
                new Product
                {
                    ID = 11,
                    Name = "Rainier Cherry Tree - Bulk",
                    Type = Product.PlantType.Tree,
                    Sku = "abcdef",
                    Description = "Rainier Cherry (Prunus avium 'Rainier') is an outstanding sweet cherry tree that produces large, delicious yellow fruit with a beautiful dark red blush. It's an easy to grow, low maintenance backyard variety that was originally produced by crossing the popular Bing red cherry with the age-old favorite, Van red cherry. Ships as 4 to 5 ft bareroot.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/YoshinoCherryTree.jpg",
                    Bulk = true

                },
                new Product
                {
                    ID = 12,
                    Name = "Yoshino Cherry Tree - Bulk",
                    Type = Product.PlantType.Tree,
                    Sku = "qwerty",
                    Description = "The classic elegance of an iconic cherry tree is second to none, and the Yoshino is no exception. With good looks and the strength to match, our Yoshino Cherry Tree ticks all the boxes of a landscape favorite. Ships as 3 to 4 ft bareroot.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/YoshinoCherryTree.jpg",
                    Bulk = true
                },
                new Product
                {
                    ID = 13,
                    Name = "Nova Zembla Rhododendron - Bulk",
                    Type = Product.PlantType.Shrub,
                    Sku = "123345",
                    Description = "A small, dense, upright, evergreen shrub prized for its large trusses of showy, bright red flowers. A cold hardy rhododendron that thrives in cooler regions but benefits from protection from winter winds. Flower color develops a deep pink tone in sunnier exposures. Very useful in foundation plantings or as a landscape accent. Ships as 24 inch potted.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/RhododendronNova.jpg",
                    Bulk = true
                },
                new Product
                {
                    ID = 14,
                    Name = "Dwarf Honeycrisp Apple Tree - Bulk",
                    Type = Product.PlantType.Tree,
                    Sku = "yuiop",
                    Description = "Developed at the University of Minnesota, this hardy apple tree bears crisp, sweet fruit. However, this tree requires some extra care to grow and tends to only bear a heavy crop every two years. Because it's prone to bitter pit, which creates dark spots that are dry, spongy and have a bitter taste, you may need to make adjustments to the nitrogen and potassium levels in the soil. Adding Quik-Cal Pelletized Calcium may be necessary. This apple variety performs better in cooler climates than warmer regions. Ripens in early September. Honeycrisp took the apple world by storm when it was first introduced and is still a flavor favorite. Ships as 30 inch potted.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/DwarfApple.jpg",
                    Bulk = true
                },
                new Product
                {
                    ID = 15,
                    Name = "Toka (Bubblegum) Plum Tree - Bulk",
                    Type = Product.PlantType.Tree,
                    Sku = "567ghj",
                    Description = "Easy-to-grow fruit that smells and tastes like bubblegum! This heavy-producing tree yields crops of medium-to-large plums. Fruit has reddish-bronze skin and juicy yellow flesh that’s as sweet as candy. Tree has a lovely, erect, vase shape. Originates from South Dakota in 1911. Tolerant of temperatures as low as -50ºF. Cold-hardy. Clingstone. Ripens in July. Ships as 2 to 3 ft potted.",
                    Price = 1.00m,
                    Img = "/Assets/ProductPictures/TokaPlum.jpg",
                    Bulk = true
                },
                new Product
                {
                    ID = 16,
                    Name = "Red Raspberry - Bulk",
                    Type = Product.PlantType.Shrub,
                    Sku = "098lkjh",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk =  true
                },
                new Product
                {
                    ID = 17,
                    Name = "Echivera- Bulk",
                    Type = Product.PlantType.Houseplant,
                    Sku = "zxcv34",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = true
                },
                new Product
                {
                    ID = 18,
                    Name = "Magestic Palm - Bulk",
                    Type = Product.PlantType.Houseplant,
                    Sku = "9d9emd",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = true
                },
                new Product
                {
                    ID = 19,
                    Name = "California Black Oak - Bulk",
                    Type = Product.PlantType.Tree,
                    Sku = "098asdf",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = true
                },
                new Product
                {
                    ID = 20,
                    Name = "Giant Sunflower - Bulk",
                    Type = Product.PlantType.Flower,
                    Sku = "abci876k",
                    Description = "Placeholder Description",
                    Price = 1.00m,
                    Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    Bulk = true
                }
                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutProduct> CheckoutProducts { get; set; }

    }
}
