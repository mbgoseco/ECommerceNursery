using NurseryApp.Models;
using System;
using Xunit;

namespace NurseryTests
{
    public class CheckoutGetSet
    {


        [Fact]
        public void CanGetID()
        {
            Checkout checkout = new Checkout();
            checkout.ID = 1;
            Assert.Equal(1, checkout.ID);
        }
        [Fact]
        public void CanGetUserID()
        {
            Checkout checkout = new Checkout();
            checkout.UserID = "String";
            Assert.Equal("String", checkout.UserID);
        }
        [Fact]
        public void CanGetName()
        {
            Checkout checkout = new Checkout();
            checkout.Name = "name";
            Assert.Equal("name", checkout.Name);
        }
        [Fact]
        public void CanGetAddress()
        {
            Checkout checkout = new Checkout();
            checkout.Address = "address";
            Assert.Equal("address", checkout.Address);
        }
        [Fact]
        public void CanGetCity()
        {
            Checkout checkout = new Checkout();
            checkout.City = "City";
            Assert.Equal("City", checkout.City);
        }

        [Fact]
        public void CanGetState()
        {
            Checkout checkout = new Checkout();
            checkout.State = "State";
            Assert.Equal("State", checkout.State);
        }

        [Fact]
        public void CanGetZip()
        {
            Checkout checkout = new Checkout();
            checkout.ZipCode = 1;
            Assert.Equal(1, checkout.ZipCode);
        }

        [Fact]
        public void CanGetOrderDate()
        {
            Checkout checkout = new Checkout();
            checkout.OrderDate = new DateTime(12/12/12);
            Assert.Equal(new DateTime(12/12/12), checkout.OrderDate);
        }

        [Fact]
        public void CanGetTotal()
        {
            Checkout checkout = new Checkout();
            checkout.Total = 100;
            Assert.Equal(100, checkout.Total);
        }
    }
}
