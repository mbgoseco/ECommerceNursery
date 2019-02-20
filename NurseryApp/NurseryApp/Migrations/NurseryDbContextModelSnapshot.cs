﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NurseryApp.Data;

namespace NurseryApp.Migrations
{
    [DbContext(typeof(NurseryDbContext))]
    partial class NurseryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NurseryApp.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Img");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sku");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Ranier Cherry Tree",
                            Price = 1.00m,
                            Sku = "abcdef",
                            Type = 0
                        },
                        new
                        {
                            ID = 2,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Yoshino Cherry Tree",
                            Price = 1.00m,
                            Sku = "qwerty",
                            Type = 0
                        },
                        new
                        {
                            ID = 3,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Rhododendron",
                            Price = 1.00m,
                            Sku = "123345",
                            Type = 1
                        },
                        new
                        {
                            ID = 4,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Dwarf Apple Tree",
                            Price = 1.00m,
                            Sku = "yuiop",
                            Type = 0
                        },
                        new
                        {
                            ID = 5,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Dwarf Plum Tree",
                            Price = 1.00m,
                            Sku = "567ghj",
                            Type = 0
                        },
                        new
                        {
                            ID = 6,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Red Raspberry",
                            Price = 1.00m,
                            Sku = "098lkjh",
                            Type = 1
                        },
                        new
                        {
                            ID = 7,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Echivera",
                            Price = 1.00m,
                            Sku = "zxcv34",
                            Type = 3
                        },
                        new
                        {
                            ID = 8,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Magestic Palm",
                            Price = 1.00m,
                            Sku = "9d9emd",
                            Type = 3
                        },
                        new
                        {
                            ID = 9,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "California Black Oak",
                            Price = 1.00m,
                            Sku = "098asdf",
                            Type = 0
                        },
                        new
                        {
                            ID = 10,
                            Description = "Placeholder Description",
                            Img = "https://images.pexels.com/photos/1002703/pexels-photo-1002703.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                            Name = "Giant Sunflower",
                            Price = 1.00m,
                            Sku = "abci876k",
                            Type = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
