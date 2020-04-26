using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class DeleteUser_Should
    {
        [TestMethod]
        public void DeleteUser_WhenIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(DeleteUser_WhenIdIsCorrect));
            var user = TestsModelsSeeder.SeedUser();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var act = sut.DeleteUser(user.Id);
                var result = assertContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
                Assert.IsTrue(result.IsDeleted);
            }
        }
        [TestMethod]
        public void ReturnTrue_WhenUserIdIsCorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_WhenUserIdIsCorrect));
            var user = TestsModelsSeeder.SeedUser();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = sut.DeleteUser(user.Id);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public void ReturnFalse_WhenUserIdIsIncorrect()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_WhenUserIdIsIncorrect));
            var user = TestsModelsSeeder.SeedUser();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = sut.DeleteUser(user.Id + 1);
                Assert.IsFalse(result);
            }
        }
    }
}