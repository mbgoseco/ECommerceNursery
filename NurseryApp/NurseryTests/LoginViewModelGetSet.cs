using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NurseryTests
{
    public class LoginViewModelGetSet
    {
        [Fact]
        public void CanGetEmail()
        {
            LoginViewModel lvm = new LoginViewModel()
            {
                Email = "test@test.com"
            };
            Assert.Equal("test@test.com", lvm.Email);
        }

        [Fact]
        public void CanSetEmail()
        {
            LoginViewModel lvm = new LoginViewModel()
            {
                Email = "test@test.com"
            };
            lvm.Email = "new@test.com";
            Assert.Equal("new@test.com", lvm.Email);
        }

        [Fact]
        public void CanGetPassword()
        {
            LoginViewModel lvm = new LoginViewModel()
            {
                Password = "Test!123"
            };
            Assert.Equal("Test!123", lvm.Password);
        }

        [Fact]
        public void CanSetPassword()
        {
            LoginViewModel lvm = new LoginViewModel()
            {
                Password = "Test!123"
            };
            lvm.Password = "Test!1234";
            Assert.Equal("Test!1234", lvm.Password);
        }
    }
}
