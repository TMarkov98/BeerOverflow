using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.ReviewServicesTests
{
    [TestClass]
    public class CreateReview_Should
    {
        [TestMethod]
        public void CreateCurrectReview_When_ParamsValid()
        {
        }
    }
}
//public IReviewDTO CreateReview(IReviewDTO reviewDTO)
//{
//    var review = new Review
//    {
//        Rating = reviewDTO.Rating,
//        Name = reviewDTO.Name,
//        Text = reviewDTO.Text,
//        Author = _context.Users.FirstOrDefault(u => u.UserName == reviewDTO.Author)
//                    ?? throw new ArgumentNullException("No author with this name."),
//        TargetBeer = _context.Beers.FirstOrDefault(b => b.Name == reviewDTO.TargetBeer)
//                        ?? throw new ArgumentNullException("No beer with this name."),
//    };
//    _context.Reviews.Add(review);
//    _context.SaveChanges();
//    return reviewDTO;
//}