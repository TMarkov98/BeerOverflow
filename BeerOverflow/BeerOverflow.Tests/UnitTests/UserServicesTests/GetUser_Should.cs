using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class GetUser_Should
    {
        [TestMethod]
        public void ReturnCorrectUser_WhenIdIsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectUser_WhenIdIsValid));
            var userRole = TestsModelsSeeder.SeedUserRole();
            var user1 = TestsModelsSeeder.SeedUser();
            var user2 = TestsModelsSeeder.SeedUser2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.UserRoles.Add(userRole);
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