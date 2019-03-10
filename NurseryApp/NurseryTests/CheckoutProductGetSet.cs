using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class CheckoutProductGetSet
    {
        [Fact]
        public void CanGetCheckoutID()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                CheckoutID = 1
            };
            Assert.Equal(1, checkoutProduct.CheckoutID);
        }
        [Fact]
        public void CanGetProductID()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                ProductID = 1
            };
            Assert.Equal(1, checkoutProduct.ProductID);
        }
        [Fact]
        public void CanGetQuantity()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                Quantity = 1
            };
            Assert.Equal(1, checkoutProduct.Quantity);
        }

        [Fact]
        public void CanSetCheckoutID()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                CheckoutID = 1
            };
            checkoutProduct.CheckoutID = 2;
            Assert.Equal(2, checkoutProduct.CheckoutID);
        }
        [Fact]
        public void CanSetProductID()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                ProductID = 1
            };
            checkoutProduct.ProductID = 2;
            Assert.Equal(2, checkoutProduct.ProductID);
        }
        [Fact]
        public void CanSetQuantity()
        {
            CheckoutProduct checkoutProduct = new CheckoutProduct()
            {
                Quantity = 1
            };
            checkoutProduct.Quantity = 2;
            Assert.Equal(2, checkoutProduct.Quantity);
        }
    }
}
