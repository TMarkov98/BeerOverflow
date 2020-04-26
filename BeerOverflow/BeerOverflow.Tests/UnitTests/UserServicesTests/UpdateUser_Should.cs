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
    public class UpdateUser_Should
    {
        [TestMethod]
        public void CorrectlyUpdateUser_WhenDataIsValid()
        {
            var options = Utils.GetOptions(nameof(CorrectlyUpdateUser_WhenDataIsValid));
            var user1 = TestsModelsSeeder.Seed_User();
            var user2 = TestsModelsSeeder.Seed_User_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.UpdateUser(2, "User2Name", "user2email@biri.com", "admin", false, null);
                var result = sut.GetUser(2);
                Assert.AreEqual("User2Name", result.UserName);
                Assert.AreEqual("user2email@biri.com", result.Email);
            }
        }
        [TestMethod]
        public void Throw_WhenUserNameTaken()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenUserNameTaken));
            var user1 = TestsModelsSeeder.Seed_User();
            var user2 = TestsModelsSeeder.Seed_User_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.UpdateUser(2, user1.UserName, "user2email@biri.com", "admin", false, null));
            }
        }
        [TestMethod]
        public void Throw_WhenEmailAlreadyTaken()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenEmailAlreadyTaken));
            var user1 = TestsModelsSeeder.Seed_User();
            var user2 = TestsModelsSeeder.Seed_User_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentException>(() => sut.UpdateUser(2, "User2Name", user1.Email, "admin", false, null));
            }
        }
        [TestMethod]
        public void Throw_WhenUserIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenUserIdIsInvalid));
            var user1 = TestsModelsSeeder.Seed_User();
            var user2 = TestsModelsSeeder.Seed_User_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateUser(5, "User2Name", "user2email@biri.com", "admin", false, null));
            }
        }
    }
}