using CarDealership.Data;
using CarDealership.Models.DataModels;
using CarDealership.Services;
using CarDealership.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CarDealership.Tests
{
    public class UserServiceTests
    {
        private Mock<UserManager<DealershipUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<DealershipUser>>();

            return new Mock<UserManager<DealershipUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        private UserManager<DealershipUser> GetUserManager()
        {
            var firstUserMock = new Mock<DealershipUser>();

            firstUserMock.Setup(u => u.Id).Returns("123");
            firstUserMock.Setup(u => u.UserName).Returns("Pesho");
            firstUserMock.Setup(u => u.Email).Returns("pesho@abv.bg");

            var firstUser = firstUserMock.Object;

            var secondUserMock = new Mock<DealershipUser>();

            secondUserMock.Setup(u => u.Id).Returns("456");
            secondUserMock.Setup(u => u.UserName).Returns("Gosho");
            secondUserMock.Setup(u => u.Email).Returns("gosho@gmail.com");

            var secondUser = secondUserMock.Object;

            var userManagerMock = this.GetMockUserManager();

            userManagerMock.Setup(um => um.Users).Returns(new List<DealershipUser> { firstUser, secondUser }.AsQueryable());

            userManagerMock.Setup(um => um.AddToRoleAsync(firstUser, "Admin"));
            userManagerMock.Setup(um => um.AddToRoleAsync(secondUser, "User"));

            var userManager = userManagerMock.Object;

            return userManager;
        }

        [Fact]
        public void GetAllUsersWorksCorrectly()
        {
            var userManager = GetUserManager();

            var service = new UserService(userManager);

            var users = service.GetAllUsers("Pesho");

            Assert.True(users.Count() == 1);
            Assert.True(users.First().Username == "Gosho");
        }

        [Fact]
        public void GetUserByIdWorksCorrectly()
        {
            var userManager = this.GetUserManager();

            var service = new UserService(userManager);

            var user = service.GetUserById("123");

            Assert.True(user.UserName == "Pesho");

            user = service.GetUserById("456");

            Assert.True(user.UserName == "Gosho");
        }

        [Fact]
        public void GetErrorModelWorksCorrectly()
        {
            var userManager = this.GetUserManager();

            var service = new UserService(userManager);

            var errorModel = service.GetErrorModel();

            Assert.True(errorModel.Message == Constants.InvalidUserMessage);
        }

        [Fact]
        public void GetUserByUsernameWorksCorrectly()
        {
            var userManager = this.GetUserManager();

            var service = new UserService(userManager);

            var user = service.GetUserByUsername("Pesho");

            Assert.True(user.Id == "123");

            user = service.GetUserByUsername("Gosho");

            Assert.True(user.Id == "456");
        }
    }
}