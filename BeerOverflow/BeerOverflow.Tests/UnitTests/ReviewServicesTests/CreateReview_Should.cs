using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class CreateReview_Should
    {
        [TestMethod]
        public void CreateCurrectReview_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(CreateCurrectReview_When_ParamsValid));
            var reviewDTO = TestsModelsSeeder.SeedReviewDTO();
            var user = TestsModelsSeeder.SeedUser();
            var targetbeer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(targetbeer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var act = sut.CreateReview(reviewDTO);
                assertContext.SaveChanges();
                var result = assertContext.Reviews.ToList()[0];
                Assert.AreEqual(reviewDTO.Name, result.Name);
                Assert.AreEqual(reviewDTO.Rating, result.Rating);
                Assert.AreEqual(reviewDTO.Text, result.Text);
                Assert.AreEqual(reviewDTO.Author, reviewDTO.Author);
            }
        }
        [TestMethod]
        public void ThrowArgumentException_When_UserNotValid()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentException_When_UserNotValid));
            var reviewDTO = TestsModelsSeeder.SeedReviewDTO();
            var targetbeer = TestsModelsSeeder.SeedBeer();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(targetbeer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.CreateReview(reviewDTO));
            }
        }
        [TestMethod]
        public void ThrowArgumentException_When_TargetBeerNotValid()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentException_When_TargetBeerNotValid));
            var user = TestsModelsSeeder.SeedUser();
            var reviewDTO = TestsModelsSeeder.SeedReviewDTO();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.CreateReview(reviewDTO));
            }
        }
        //TODO Add it maybe
        //[TestMethod]
        //public void ThrowArgumentException_When_UsersReviewAlreadyExists() { }
    }
}