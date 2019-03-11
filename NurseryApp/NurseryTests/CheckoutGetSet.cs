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
            Checkout checkout = new Checkout
            {
                ID = 1
            };
            Assert.Equal(1, checkout.ID);
        }
        [Fact]
        public void CanGetUserID()
        {
            Checkout checkout = new Checkout
            {
                UserID = "String"
            };
            Assert.Equal("String", checkout.UserID);
        }
        [Fact]
        public void CanGetName()
        {
            Checkout checkout = new Checkout
            {
                Name = "name"
            };
            Assert.Equal("name", checkout.Name);
        }
        [Fact]
        public void CanGetAddress()
        {
            Checkout checkout = new Checkout
            {
                Address = "address"
            };
            Assert.Equal("address", checkout.Address);
        }
        [Fact]
        public void CanGetCity()
        {
            Checkout checkout = new Checkout
            {
                City = "City"
            };
            Assert.Equal("City", checkout.City);
        }

        [Fact]
        public void CanGetState()
        {
            Checkout checkout = new Checkout
            {
                State = "State"
            };
            Assert.Equal("State", checkout.State);
        }

        [Fact]
        public void CanGetZip()
        {
            Checkout checkout = new Checkout
            {
                ZipCode = 1
            };
            Assert.Equal(1, checkout.ZipCode);
        }

        [Fact]
        public void CanGetOrderDate()
        {
            Checkout checkout = new Checkout
            {
                OrderDate = new DateTime(12 / 12 / 12)
            };
            Assert.Equal(new DateTime(12/12/12), checkout.OrderDate);
        }

        [Fact]
        public void CanGetTotal()
        {
            Checkout checkout = new Checkout
            {
                Total = 100
            };
            Assert.Equal(100, checkout.Total);
        }

        [Fact]
        public void CanSetID()
        {
            Checkout checkout = new Checkout
            {
                ID = 2
            };
            checkout.ID = 1;
            Assert.Equal(1, checkout.ID);
        }
        [Fact]
        public void CanSetUserID()
        {
            Checkout checkout = new Checkout
            {
                UserID = "Another string"
            };
            checkout.UserID = "String";
            Assert.Equal("String", checkout.UserID);
        }
        [Fact]
        public void CanSetName()
        {
            Checkout checkout = new Checkout
            {
                Name = "another name"
            };
            checkout.Name = "name";
            Assert.Equal("name", checkout.Name);
        }
        [Fact]
        public void CanSetAddress()
        {
            Checkout checkout = new Checkout
            {
                Address = "another address"
            };
            checkout.Address = "address";
            Assert.Equal("address", checkout.Address);
        }
        [Fact]
        public void CanSetCity()
        {
            Checkout checkout = new Checkout
            {
                City = "another city"
            };
            checkout.City = "City";
            Assert.Equal("City", checkout.City);
        }

        [Fact]
        public void CanSetState()
        {
            Checkout checkout = new Checkout
            {
                State = "another state"
            };
            checkout.State = "State";
            Assert.Equal("State", checkout.State);
        }

        [Fact]
        public void CanSetZip()
        {
            Checkout checkout = new Checkout
            {
                ZipCode = 3
            };
            checkout.ZipCode = 1;
            Assert.Equal(1, checkout.ZipCode);
        }

        [Fact]
        public void CanSetOrderDate()
        {
            Checkout checkout = new Checkout
            {
                OrderDate = new DateTime(11 / 11 / 11)
            };
            checkout.OrderDate = new DateTime(12 / 12 / 12);
            Assert.Equal(new DateTime(12 / 12 / 12), checkout.OrderDate);
        }

        [Fact]
        public void CanSetTotal()
        {
            Checkout checkout = new Checkout
            {
                Total = 5
            };
            checkout.Total = 100;
            Assert.Equal(100, checkout.Total);
        }
    }
}
