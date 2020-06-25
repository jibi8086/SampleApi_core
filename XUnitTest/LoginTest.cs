using API.Common;
using IRepository;
using Moq;
using SampleEntity;
using SampleInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class LoginTest
    {
        //[Fact]
        //public void LoginUser()
        //{
        //    //Arrange
        //    //int expected = 1;
        //    bool expected = true;
        //    UserModel emp = new UserModel();
        //    emp.EmailAddress = "test@gmail.com";
        //    emp.Passwd = "test";
        //    //Act
        //    bool actual = _loginEntity.TestLogin("sad",5);
        //    //Assert
        //    Assert.Equal(expected, actual);

        //}
        [Fact]
        public void LoginUserAuthenticate()
        {

            //Arrange
            UserModel us = new UserModel();
            var moqLogRepo = new Mock<ILoginRepo>();
            moqLogRepo.Setup(x => x.AuthenticateUser(It.IsAny<UserModel>())).Returns(()=> us);
            us.EmailAddress = "test@gmail.com";
            us.Passwd = "test";

            //Act
            ILoginEntity _loginEntity = new LoginEntity(moqLogRepo.Object);
            var actual = _loginEntity.AuthenticateUser(us);

            //Assert
            Assert.Equal(us, actual);
           
        }

    }
}
