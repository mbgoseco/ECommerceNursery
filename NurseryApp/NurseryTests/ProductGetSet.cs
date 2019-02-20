using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class ProductGetSet
    {
        // Getters
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

        //Setters
        [Fact]
        public void CanSetID()
        {
            Product product = new Product
            {
                ID = 1
            };

            Assert.Equal(1, product.ID);
        }


        [Fact]
        public void CanSetName()
        {
            Product product = new Product
            {
                Name = "SunFlower"
            };
            product.Name = "Apple Tree";

            Assert.Equal("Apple Tree", product.Name);
        }

        [Fact]
        public void CanSetType()
        {
            Product product = new Product
            {
                Type = Product.PlantType.Flower
            };
            product.Type = Product.PlantType.Houseplant;

            Assert.Equal(Product.PlantType.Houseplant, product.Type);
        }

        [Fact]
        public void CanSetSku()
        {
            Product product = new Product
            {
                Sku = "12345"
            };
            product.Sku = "abcde";

            Assert.Equal("abcde", product.Sku);
        }

        [Fact]
        public void CanSetDescription()
        {
            Product product = new Product
            {
                Description = "A Description"
            };
            product.Description = "Different Description";

            Assert.Equal("Different Description", product.Description);
        }

        [Fact]
        public void CanSetPrice()
        {
            Product product = new Product
            {
                Price = 100
            };
            product.Price = 200;

            Assert.Equal(200, product.Price);
        }

        [Fact]
        public void CanSetImg()
        {
            Product product = new Product
            {
                Img = "Img.Path"
            };
            product.Img = "new.Path";
            Assert.Equal("new.Path", product.Img);
        }
    }
}
