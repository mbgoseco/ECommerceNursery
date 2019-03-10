using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class BasketGetSet
    {
        [Fact]
        public void CanGetID()
        {
            Basket basket = new Basket()
            {
                ID = 1
            };
            Assert.Equal(1, basket.ID);
        }
        [Fact]
        public void CanGetUserID()
        {
            Basket basket = new Basket()
            {
                UserID = "string"
            };
            Assert.Equal("string", basket.UserID);
        }
        [Fact]
        public void CanSetID()
        {
            Basket basket = new Basket()
            {
                ID = 1
            };
            basket.ID = 2;
            Assert.Equal(2, basket.ID);
        }
        [Fact]
        public void CanSetUserID()
        {
            Basket basket = new Basket()
            {
                UserID = "string"
            };
            basket.UserID = "new string";
            Assert.Equal("new string", basket.UserID);
        }
    }
}
