using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NurseryTests
{
    public class ExternalLoginViewModelGetSet
    {

        [Fact]
        public void CanGetFirstName()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel
            {
                FirstName = "name"
            };
            Assert.Equal("name", elvm.FirstName);
        }
        [Fact]
        public void CanGetLastName()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel
            {
                LastName = "name"
            };
            Assert.Equal("name", elvm.LastName);
        }
        [Fact]
        public void CanGetBirthday()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel()
            {
                Birthday = new DateTime(12 / 12 / 12)
            };
            Assert.Equal(new DateTime(12 / 12 / 12), elvm.Birthday);
        }



        [Fact]
        public void CanSetFirstName()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel
            {
                FirstName = "another name"
            };
            elvm.FirstName = "name";
            Assert.Equal("name", elvm.FirstName);
        }
        [Fact]
        public void CanSetLastName()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel
            {
                LastName = "another name"
            };
            elvm.LastName = "name";
            Assert.Equal("name", elvm.LastName);
        }
        [Fact]
        public void CanSetBirthday()
        {
            ExternalLoginViewModel elvm = new ExternalLoginViewModel()
            {
                Birthday = new DateTime(12 / 12 / 12)
            };
            elvm.Birthday = new DateTime(11 / 11 / 11);
            Assert.Equal(new DateTime(11 / 11 / 11), elvm.Birthday);
        }
    }
}
