using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class GetReview_Should
    {
        [TestMethod]
        public void ReturnCorrectReview_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectReview_When_ParamsValid));
            var review = TestsModelsSeeder.SeedReview();
            var beer = TestsModelsSeeder.SeedBeer();
            var user = TestsModelsSeeder.SeedUser();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Add(review);
                arrangeContext.Users.Add(user);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var result = sut.GetReview(1);
                Assert.AreEqual(review.Name, result.Name);
                Assert.AreEqual(review.Author.UserName, result.Author);
                Assert.AreEqual(review.Text, result.Text);
                Assert.AreEqual(review.Rating, result.Rating);
            }
        }
        [TestMethod]
        public void ThrowArgumentNullException_When_ReviewMissing()
        {
            var options = Utils.GetOptions(nameof(ThrowArgumentNullException_When_ReviewMissing));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetReview(1));
            }
        }
    }
}

//public ReviewDTO GetReview(int id)
//{
//    var review = _context.Reviews.Include(r => r.TargetBeer).Include(r => r.Author).FirstOrDefault(r => r.Id == id);
//    if (review == null)
//    {
//        throw new ArgumentNullException("Review can NOT be null.");
//    }
//    var reviewDTO = new ReviewDTO
//    {
//        Id = review.Id,
//        Name = review.Name,
//        Text = review.Text,
//        Rating = review.Rating,
//        TargetBeer = review.TargetBeer.Name,
//        Author = review.Author.UserName,
//    };
//    return reviewDTO;
//}