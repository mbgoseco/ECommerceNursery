using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NurseryTests
{
    public class RegisterViewModelGetSet
    {
        [Fact]
        public void CanGetFirstName()
        {
            RegisterViewModel rvm = new RegisterViewModel
            {
                FirstName = "name"
            };
            Assert.Equal("name", rvm.FirstName);
        }
        [Fact]
        public void CanGetLastName()
        {
            RegisterViewModel rvm = new RegisterViewModel
            {
                LastName = "name"
            };
            Assert.Equal("name", rvm.LastName);
        }
        [Fact]
        public void CanGetBirthday()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Birthday = new DateTime(12 / 12 / 12)
            };
            Assert.Equal(new DateTime(12 / 12 / 12), rvm.Birthday);
        }



        [Fact]
        public void CanSetFirstName()
        {
            RegisterViewModel rvm = new RegisterViewModel
            {
                FirstName = "another name"
            };
            rvm.FirstName = "name";
            Assert.Equal("name", rvm.FirstName);
        }
        [Fact]
        public void CanSetLastName()
        {
            RegisterViewModel rvm = new RegisterViewModel
            {
                LastName = "another name"
            };
            rvm.LastName = "name";
            Assert.Equal("name", rvm.LastName);
        }
        [Fact]
        public void CanSetBirthday()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Birthday = new DateTime(12 / 12 / 12)
            };
            rvm.Birthday = new DateTime(11 / 11 / 11);
            Assert.Equal(new DateTime(11 / 11 / 11), rvm.Birthday);
        }

        [Fact]
        public void CanGetEmail()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Email = "test@test.com"
            };
            Assert.Equal("test@test.com", rvm.Email);
        }

        [Fact]
        public void CanSetEmail()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Email = "test@test.com"
            };
            rvm.Email = "new@test.com";
            Assert.Equal("new@test.com", rvm.Email);
        }

        [Fact]
        public void CanGetPassword()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Password = "Test!123"
            };
            Assert.Equal("Test!123", rvm.Password);
        }

        [Fact]
        public void CanSetPassword()
        {
            RegisterViewModel rvm = new RegisterViewModel()
            {
                Password = "Test!123"
            };
            rvm.Password = "Test!1234";
            Assert.Equal("Test!1234", rvm.Password);
        }
    }
}
