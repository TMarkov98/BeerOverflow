using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class GetAllUsers_Should
    {
        [TestMethod]
        public void ReturnCorrectList_WhenDataIsPresent()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectList_WhenDataIsPresent));
            var userRole = TestsModelsSeeder.SeedUserRole();
            var user1 = TestsModelsSeeder.SeedUser();
            var user2 = TestsModelsSeeder.SeedUser2();
            var user3 = TestsModelsSeeder.SeedUser3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.UserRoles.Add(userRole);
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.Users.Add(user3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = sut.GetAllUsers().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(user1.UserName, result[0].UserName);
                Assert.AreEqual(user2.UserName, result[1].UserName);
                Assert.AreEqual(user3.UserName, result[2].UserName);
            }
        }
    }
}