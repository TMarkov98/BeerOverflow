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
    public class CreateReview_Should
    {
        [TestMethod]
        public void CreateCurrectReview_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(CreateCurrectReview_When_ParamsValid));
            var reviewDTO = TestsModelsSeeder.Seed_ReviewDTO();
            var user = TestsModelsSeeder.Seed_User();
            var targetbeer = TestsModelsSeeder.Seed_Beer();

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
        //TODO Add it maybe
        //[TestMethod]
        //public void ThrowArgumentException_When_UsersReviewAlreadyExists() { }
    }
}