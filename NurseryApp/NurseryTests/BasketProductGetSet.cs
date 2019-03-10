using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class BasketProductGetSet
    {
        [Fact]
        public void CanGetBasketID()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                BasketID = 1
            };
            Assert.Equal(1, basketProduct.BasketID);
        }
        [Fact]
        public void CanGetProductID()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                ProductID = 1
            };
            Assert.Equal(1, basketProduct.ProductID);
        }
        [Fact]
        public void CanGetQuantity()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                Quantity = 1
            };
            Assert.Equal(1, basketProduct.Quantity);
        }

        [Fact]
        public void CanSetBasketID()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                BasketID = 1
            };
            basketProduct.BasketID = 2;
            Assert.Equal(2, basketProduct.BasketID);
        }
        [Fact]
        public void CanSetProductID()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                ProductID = 1
            };
            basketProduct.ProductID = 2;
            Assert.Equal(2, basketProduct.ProductID);
        }
        [Fact]
        public void CanSetQuantity()
        {
            BasketProduct basketProduct = new BasketProduct()
            {
                Quantity = 1
            };
            basketProduct.Quantity = 2;
            Assert.Equal(2, basketProduct.Quantity);
        }
    }
}
