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
    public class CheckoutViewModelGetSet
    {
        [Fact]
        public void CanGetID()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                ID = 1
            };
            Assert.Equal(1, checkout.ID);
        }
        [Fact]
        public void CanGetName()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Name = "name"
            };
            Assert.Equal("name", checkout.Name);
        }
        [Fact]
        public void CanGetAddress()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Address = "address"
            };
            Assert.Equal("address", checkout.Address);
        }
        [Fact]
        public void CanGetCity()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                City = "City"
            };
            Assert.Equal("City", checkout.City);
        }

        [Fact]
        public void CanGetState()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                State = "State"
            };
            Assert.Equal("State", checkout.State);
        }

        [Fact]
        public void CanGetZip()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                ZipCode = 1
            };
            Assert.Equal(1, checkout.ZipCode);
        }

        [Fact]
        public void CanGetOrderDate()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                OrderDate = new DateTime(12 / 12 / 12)
            };
            Assert.Equal(new DateTime(12 / 12 / 12), checkout.OrderDate);
        }

        [Fact]
        public void CanGetTotal()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Total = 100
            };
            Assert.Equal(100, checkout.Total);
        }
        [Fact]
        public void CanGetExpirationDateMonth()
        {
            CheckoutViewModel checkout = new CheckoutViewModel()
            {
                ExpirationDateMonth = "12"
            };

            Assert.Equal("12", checkout.ExpirationDateMonth);
        }
        [Fact]
        public void CanGetExpirationDateYear()
        {
            CheckoutViewModel checkout = new CheckoutViewModel()
            {
                ExpirationDateYear = "12"
            };

            Assert.Equal("12", checkout.ExpirationDateYear);
        }

        [Fact]
        public void CanSetID()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                ID = 2
            };
            checkout.ID = 1;
            Assert.Equal(1, checkout.ID);
        }
       
        [Fact]
        public void CanSetName()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Name = "another name"
            };
            checkout.Name = "name";
            Assert.Equal("name", checkout.Name);
        }
        [Fact]
        public void CanSetAddress()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Address = "another address"
            };
            checkout.Address = "address";
            Assert.Equal("address", checkout.Address);
        }
        [Fact]
        public void CanSetCity()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                City = "another city"
            };
            checkout.City = "City";
            Assert.Equal("City", checkout.City);
        }

        [Fact]
        public void CanSetState()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                State = "another state"
            };
            checkout.State = "State";
            Assert.Equal("State", checkout.State);
        }

        [Fact]
        public void CanSetZip()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                ZipCode = 3
            };
            checkout.ZipCode = 1;
            Assert.Equal(1, checkout.ZipCode);
        }

        [Fact]
        public void CanSetOrderDate()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                OrderDate = new DateTime(11 / 11 / 11)
            };
            checkout.OrderDate = new DateTime(12 / 12 / 12);
            Assert.Equal(new DateTime(12 / 12 / 12), checkout.OrderDate);
        }

        [Fact]
        public void CanSetTotal()
        {
            CheckoutViewModel checkout = new CheckoutViewModel
            {
                Total = 5
            };
            checkout.Total = 100;
            Assert.Equal(100, checkout.Total);
        }

        [Fact]
        public void CanSetExpirationDateMonth()
        {
            CheckoutViewModel checkout = new CheckoutViewModel()
            {
                ExpirationDateMonth = "12"
            };
            checkout.ExpirationDateMonth = "11";
            Assert.Equal("11", checkout.ExpirationDateMonth);
        }
        [Fact]
        public void CanSetExpirationDateYear()
        {
            CheckoutViewModel checkout = new CheckoutViewModel()
            {
                ExpirationDateYear = "12"
            };
            checkout.ExpirationDateYear = "11";
            Assert.Equal("11", checkout.ExpirationDateYear);
        }
    }

}

