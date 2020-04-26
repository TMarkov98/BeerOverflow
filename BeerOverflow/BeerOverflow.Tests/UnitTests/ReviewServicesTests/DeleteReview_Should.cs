using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class DeleteReview_Should
    {
        [TestMethod]
        public void ReturnTrue_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_ParamsValid));

            var review = TestsModelsSeeder.Seed_Review();
            var beer = TestsModelsSeeder.Seed_Beer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Add(review);
                arrangeContext.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = sut.DeleteReview(1);
                Assert.IsTrue(result);
                Assert.IsTrue(assertContext.Reviews.FirstOrDefault().IsDeleted);
            }
        }
        [TestMethod]
        public void ReturnFalse_When_ParamsNotValid()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_When_ParamsNotValid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = sut.DeleteReview(1);
                Assert.IsFalse(result);
            }
        }
        [TestMethod]
        public void ReturnFalse_When_ReviewAlreadyDel()
        {
            var options = Utils.GetOptions(nameof(ReturnFalse_When_ReviewAlreadyDel));

            var review = TestsModelsSeeder.Seed_Review();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Reviews.Add(review);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var act = sut.DeleteReview(1);
                var result = sut.DeleteReview(1);
                Assert.IsFalse(result);
            }
        }
    }
}
