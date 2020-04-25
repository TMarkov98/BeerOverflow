using BeerOverflow.Services.DTO;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewServices
    {
        IReviewDTO CreateReview(IReviewDTO reviewDTO);
        ICollection<ReviewDTO> GetAllReviews();
        ReviewDTO GetReview(int id);
        ReviewDTO UpdateReviews(int id, string name, string text, int rating);
    }
}