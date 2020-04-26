using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class GetAllReviews_Should
    {
        //TODO WHY ARE THESE ASSERTS NOT PASSING ???
        // AND WHY THE ADDED REVIEWS DISAPPERAS AFTER THE FIRST USING???
        [TestMethod]
        public void ReturnCorrectReviews_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectReviews_When_ParamsValid));

            var review = TestsModelsSeeder.SeedReview();
            var review2 = TestsModelsSeeder.SeedReview2();
            var review3 = TestsModelsSeeder.SeedReview3();
            var beer = TestsModelsSeeder.SeedBeer();
            var beer2 = TestsModelsSeeder.SeedBeer2();
            var beer3 = TestsModelsSeeder.SeedBeer3();
            var user = TestsModelsSeeder.SeedUser();

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
