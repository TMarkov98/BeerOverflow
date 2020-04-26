﻿using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class UpdateReview_Should
    {
        [TestMethod]
        public void UpdateCurrectReview_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(UpdateCurrectReview_When_ParamsValid));
            var review = TestsModelsSeeder.Seed_Review();
            var beer = TestsModelsSeeder.Seed_Beer();
            var user = TestsModelsSeeder.Seed_User();
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Add(review);
                arrangeContext.Beers.Add(beer);
                arrangeContext.SaveChanges();
            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new ReviewServices(assertContext);
                var act = sut.UpdateReviews(1, "NewReviewName", "Changed my mind, I don't like it.", 2);
                var result = assertContext.Reviews.ToList()[0];
                Assert.AreEqual("NewReviewName", result.Name);
                Assert.AreEqual("Changed my mind, I don't like it.", result.Text);
                Assert.AreEqual(2, result.Rating);
            }
        }
    }
}
//public ReviewDTO UpdateReviews(int id, string name, string text, int rating)
//{
//    var review = _context.Reviews
//        .Where(r => r.IsDeleted == false)
//        .FirstOrDefault(r => r.Id == id);
//    review.Name = name;
//    review.Text = text;
//    review.Rating = rating;

//    var reviewDTO = new ReviewDTO
//    {
//        Name = review.Name,
//        Text = review.Text,
//        Rating = review.Rating,
//        Author = review.Author.UserName,
//        TargetBeer = review.TargetBeer.Name
//    };
//    _context.SaveChanges();
//    return reviewDTO;
//}