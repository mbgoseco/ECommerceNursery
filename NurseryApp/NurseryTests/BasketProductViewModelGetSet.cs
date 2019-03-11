using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models;
using NurseryApp.Models.Services;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NurseryTests
{
    public class BasketProductViewModelGetSet
    {
        //BasketProductViewModels
        [Fact]
        public void CanGetBasketID()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                BasketID = 1 
            };
            Assert.Equal(1, bpvm.BasketID);
        }
        [Fact]
        public void CanSetBasketID()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                BasketID = 1
            };
            bpvm.BasketID = 2;
            Assert.Equal(2, bpvm.BasketID);
        }

        [Fact]
        public void CanGetProductID()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                ProductID = 1
            };
            Assert.Equal(1, bpvm.ProductID);
        }
        [Fact]
        public void CanSetProductID()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                ProductID = 1
            };
            bpvm.ProductID = 2;
            Assert.Equal(2, bpvm.ProductID);
        }

        [Fact]
        public void CanGetQuantity()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                Quantity = 1
            };
            Assert.Equal(1, bpvm.Quantity);
        }
        [Fact]
        public void CanSetQuantity()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                Quantity = 1
            };
            bpvm.Quantity = 2;
            Assert.Equal(2, bpvm.Quantity);
        }

        [Fact]
        public void CanGetSku()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Sku = "12345"
            };

            Assert.Equal("12345", bpvm.Sku);
        }

        [Fact]
        public void CanGetDescription()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Description = "A Description"
            };

            Assert.Equal("A Description", bpvm.Description);
        }

        [Fact]
        public void CanGetPrice()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Price = 100
            };

            Assert.Equal(100, bpvm.Price);
        }

        [Fact]
        public void CanGetImg()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Img = "Img.Path"
            };

            Assert.Equal("Img.Path", bpvm.Img);
        }

        //Setters
        [Fact]
        public void CanSetName()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Name = "SunFlower"
            };
            bpvm.Name = "Apple Tree";

            Assert.Equal("Apple Tree", bpvm.Name);
        }

        [Fact]
        public void CanSetType()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel()
            {
                Type = Product.PlantType.Flower
            };
            bpvm.Type = Product.PlantType.Houseplant;

            Assert.Equal(Product.PlantType.Houseplant, bpvm.Type);
        }

        [Fact]
        public void CanSetSku()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Sku = "12345"
            };
            bpvm.Sku = "abcde";

            Assert.Equal("abcde", bpvm.Sku);
        }

        [Fact]
        public void CanSetDescription()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Description = "A Description"
            };
            bpvm.Description = "Different Description";

            Assert.Equal("Different Description", bpvm.Description);
        }

        [Fact]
        public void CanSetPrice()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Price = 100
            };
            bpvm.Price = 200;

            Assert.Equal(200, bpvm.Price);
        }

        [Fact]
        public void CanSetImg()
        {
            BasketProductViewModel bpvm = new BasketProductViewModel
            {
                Img = "Img.Path"
            };
            bpvm.Img = "new.Path";
            Assert.Equal("new.Path", bpvm.Img);
        }
    }
}
