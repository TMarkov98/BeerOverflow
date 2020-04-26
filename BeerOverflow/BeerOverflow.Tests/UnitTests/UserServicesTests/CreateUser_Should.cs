using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class CreateUser_Should
    {
        [TestMethod]
        public void ReturnCorrectUser_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectUser_WhenParamsAreValid));
            var userDTO = TestsModelsSeeder.Seed_UserDTO();
            var userRole = TestsModelsSeeder.Seed_UserRole();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.UserRoles.Add(userRole);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.CreateUser(userDTO);
                var result = assertContext.Users.FirstOrDefault(user => user.UserName == userDTO.UserName);
                Assert.AreEqual(userDTO.Id, result.Id);
                Assert.AreEqual(userDTO.UserName, result.UserName);
                Assert.AreEqual(userDTO.Email, result.Email);
            }
        }
        [TestMethod]
        public void Throw_WhenUserAlreadyExists()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenUserAlreadyExists));
            var userDTO = TestsModelsSeeder.Seed_UserDTO();
            var user = TestsModelsSeeder.Seed_User();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.CreateUser(userDTO));
            }
        }
        [TestMethod]
        public void Throw_WhenEmailTaken()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenEmailTaken));
            var userDTO = TestsModelsSeeder.Seed_UserDTO();
            var user = TestsModelsSeeder.Seed_User();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.UpdateUser(1, "asdf", userDTO.Email, userDTO.Role, userDTO.IsBanned, userDTO.BanReason);
                Assert.ThrowsException<ArgumentException>(() => sut.CreateUser(userDTO));
            }
        }
    }
}