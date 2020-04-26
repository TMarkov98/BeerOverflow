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
    public class GetUser_Should
    {
        [TestMethod]
        public void ReturnCorrectUser_WhenIdIsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectUser_WhenIdIsValid));
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
                var result = sut.GetUser(2);
                Assert.AreEqual(user2.Id, result.Id);
                Assert.AreEqual(user2.UserName, result.UserName);
                Assert.AreEqual(user2.Email, result.Email);
            }
        }
        [TestMethod]
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetUser(1));
            }
        }
    }
}