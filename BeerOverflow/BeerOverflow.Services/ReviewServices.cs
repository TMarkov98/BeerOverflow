using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly BeerOverflowContext _context;
        public ReviewServices(BeerOverflowContext context)
        {
            this._context = context;
        }

        public IReviewDTO CreateReview(IReviewDTO reviewDTO)
        {
            var review = new Review
            {
                Rating = reviewDTO.Rating,
                Name = reviewDTO.Name,
                Text = reviewDTO.Text,
                Author = _context.Users.FirstOrDefault(u => u.UserName == reviewDTO.Author)
                            ?? throw new ArgumentNullException("No author with this name."),
                TargetBeer = _context.Beers.FirstOrDefault(b => b.Name == reviewDTO.TargetBeer)
                                ?? throw new ArgumentNullException("No beer with this name."),
            };
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return reviewDTO;
        }

        public ICollection<ReviewDTO> GetAllReviews()
        {
            var reviews = _context.Reviews
                .Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Text = r.Text,
                    Rating = r.Rating,
                    //TODO Need check if exist
                    TargetBeer = r.TargetBeer.Name,
                    Author = r.Author.UserName,
                }).ToList();
            return reviews;
        }

        public ReviewDTO GetReview(int id)
        {
            var review = _context.Reviews.Include(r => r.TargetBeer).Include(r => r.Author).FirstOrDefault(r => r.Id == id);
            if (review == null)
            {
                throw new ArgumentNullException("Review can NOT be null.");
            }
            var reviewDTO = new ReviewDTO
            {
                Id = review.Id,
                Name = review.Name,
                Text = review.Text,
                Rating = review.Rating,
                TargetBeer = review.TargetBeer.Name,
                Author = review.Author.UserName,
            };
            return reviewDTO;
        }
        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(b => b.Id == id);
            if (review == null || review.IsDeleted)
                return false;

            review.IsDeleted = true;
            review.DeletedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        public ReviewDTO UpdateReviews(int id, string name, string text, int rating)
        {
            var review = _context.Reviews
                .Where(r => r.IsDeleted == false)
                .FirstOrDefault(r => r.Id == id);
            review.Name = name;
            review.Text = text;
            review.Rating = rating;

            var reviewDTO = new ReviewDTO
            {
                Name = review.Name,
                Text = review.Text,
                Rating = review.Rating,
                Author = review.Author.UserName,
                TargetBeer = review.TargetBeer.Name
            };
            _context.SaveChanges();
            return reviewDTO;
        }
    }
}
