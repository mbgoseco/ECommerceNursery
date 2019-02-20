using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class ProductGetSet
    {
        [Fact]
        public void CanGetID()
        {
            Product product = new Product
            {
                ID = 1
            };

            Assert.Equal(1, product.ID);
        }

            
        [Fact]
        public void CanGetName()
        {
            Product product = new Product
            {
                Name = "SunFlower"
            };

            Assert.Equal("SunFlower", product.Name);
        }
            
        [Fact]
        public void CanGetType()
        {
            Product product = new Product
            {
                Type = Product.PlantType.Flower
            };

            Assert.Equal(Product.PlantType.Flower, product.Type);
        }

        [Fact]
        public void CanGetSku()
        {
            Product product = new Product
            {
                Sku = "12345"
            };

            Assert.Equal("12345", product.Sku);
        }

        [Fact]
        public void CanGetDescription()
        {
            Product product = new Product
            {
                Description = "A Description"
            };

            Assert.Equal("A Description", product.Description);
        }

        [Fact]
        public void CanGetPrice()
        {
            Product product = new Product
            {
                Price = 100
            };

            Assert.Equal(100, product.Price);
        }

        [Fact]
        public void CanGetImg()
        {
            Product product = new Product
            {
                Img = "Img.Path"
            };

            Assert.Equal("Img.Path", product.Img);
        }

    }
}
