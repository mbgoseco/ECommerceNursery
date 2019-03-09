//using NurseryApp.Models;
//using System;
//using Microsoft.AspNetCore.Identity;
//using Xunit;

//namespace NurseryTests
//{
//    public class ApplicationUserGetSet
//    {



//        [Fact]
//        public void CanGetFirstName()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                FirstName = "name"
//            };
//            Assert.Equal("name", applicationUser.FirstName);
//        }
//        [Fact]
//        public void CanGetLastName()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                LastName = "name"
//            };
//            Assert.Equal("name", applicationUser.LastName);
//        }
//        [Fact]
//        public void CanGetBirthday()
//        {
//            ApplicationUser applicationUser = new ApplicationUser()
//            {
//                Birthday = new DateTime(12 / 12 / 12)
//            };
//            Assert.Equal(new DateTime(12 / 12 / 12), applicationUser.Birthday);
//        }
//        [Fact]
//        public void CanGetAddress()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                Address = "address"
//            };
//            Assert.Equal("address", applicationUser.Address);
//        }
//        [Fact]
//        public void CanGetCity()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                City = "City"
//            };
//            Assert.Equal("City", applicationUser.City);
//        }

//        [Fact]
//        public void CanGetState()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                State = "State"
//            };
//            Assert.Equal("State", applicationUser.State);
//        }

//        [Fact]
//        public void CanGetZip()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                ZipCode = 1
//            };
//            Assert.Equal(1, applicationUser.ZipCode);
//        }



//        [Fact]
//        public void CanSetFirstName()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                FirstName = "another name"
//            };
//            applicationUser.FirstName = "name";
//            Assert.Equal("name", applicationUser.FirstName);
//        }
//        [Fact]
//        public void CanSetLastName()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                LastName = "another name"
//            };
//            applicationUser.LastName = "name";
//            Assert.Equal("name", applicationUser.LastName);
//        }
//        [Fact]
//        public void CanSetBirthday()
//        {
//            ApplicationUser applicationUser = new ApplicationUser()
//            {
//                Birthday = new DateTime(12 / 12 / 12)
//            };
//            applicationUser.Birthday = new DateTime(11 / 11 / 11);
//            Assert.Equal(new DateTime(11 / 11 / 11), applicationUser.Birthday);
//        }
//        [Fact]
//        public void CanSetAddress()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                Address = "another address"
//            };
//            applicationUser.Address = "address";
//            Assert.Equal("address", applicationUser.Address);
//        }
//        [Fact]
//        public void CanSetCity()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                City = "another city"
//            };
//            applicationUser.City = "City";
//            Assert.Equal("City", applicationUser.City);
//        }

//        [Fact]
//        public void CanSetState()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                State = "another state"
//            };
//            applicationUser.State = "State";
//            Assert.Equal("State", applicationUser.State);
//        }

//        [Fact]
//        public void CanSetZip()
//        {
//            ApplicationUser applicationUser = new ApplicationUser
//            {
//                ZipCode = 3
//            };
//            applicationUser.ZipCode = 1;
//            Assert.Equal(1, applicationUser.ZipCode);
//        }
//    }
//}
