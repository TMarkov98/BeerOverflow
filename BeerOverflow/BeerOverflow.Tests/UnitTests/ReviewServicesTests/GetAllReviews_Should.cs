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
    public class GetAllReviews_Should
    {
        //TODO WHY ARE THESE ASSERTS NOT PASSING ???
        // AND WHY THE ADDED REVIEWS DISAPPERAS AFTER THE FIRST USING???
        [TestMethod]
        public void ReturnCurrectReviews_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCurrectReviews_When_ParamsValid));

            var review = TestsModelsSeeder.Seed_Review();
            var review2 = TestsModelsSeeder.Seed_Review_v2();
            var review3 = TestsModelsSeeder.Seed_Review_v3();
            var beer = TestsModelsSeeder.Seed_Beer();
            var beer2 = TestsModelsSeeder.Seed_Beer_v2();
            var beer3 = TestsModelsSeeder.Seed_Beer_v3();
            var user = TestsModelsSeeder.Seed_User();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Reviews.Add(review);
                arrangeContext.Reviews.Add(review2);
                arrangeContext.Reviews.Add(review3);
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.Beers.Add(beer2);
                arrangeContext.Beers.Add(beer3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = sut.GetAllReviews().ToList();
                Assert.AreEqual(3, result.Count());
                Assert.AreEqual(review.Name, result[0].Name);
                Assert.AreEqual(review2.Name, result[1].Name);
                Assert.AreEqual(review3.Name, result[2].Name);
            }
        }
    }
}
