using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models.ApiViewModels;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewsController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //TODO Need check if TargetBeer exist
            var model = this._reviewServices
                .GetAllReviews()
                .Select(reviewDTO => new ReviewViewModel(reviewDTO));
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reviewDTO = this._reviewServices.GetReview(id);
            var model = new ReviewViewModel(reviewDTO);
            return Ok(model);
        }
        [HttpPost("")]
        public IActionResult Post([FromBody] ReviewViewModel reviewViewModel)
        {
            if (reviewViewModel == null)
                return BadRequest();
            if (this.ReviewExists(reviewViewModel.Name, reviewViewModel.Author))
                return ValidationProblem($"Review of {reviewViewModel.TargetBeer} from {reviewViewModel.Author} already exists.");
            //TODO Need check if exist
            if (reviewViewModel.TargetBeer == null)
                return BadRequest("Target beer not found.");
            var reviewDTO = new ReviewDTO
            {
                Name = reviewViewModel.Name,
                Text = reviewViewModel.Text,
                Rating = reviewViewModel.Rating,
                TargetBeer = reviewViewModel.TargetBeer,
                Author = reviewViewModel.Author,
            };
            var review = _reviewServices.CreateReview(reviewDTO);
            return Created("Post", review);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]ReviewViewModel reviewViewModel)
        {
            if (reviewViewModel == null)
                return BadRequest();
            var review = this._reviewServices.UpdateReviews(id, reviewViewModel.Name, reviewViewModel.Text, reviewViewModel.Rating);
            return Ok(review);
        }
        private bool ReviewExists(string beer, string author)
        {
            return _reviewServices.GetAllReviews().Any(r => r.TargetBeer == beer && r.Author == author);
        }
    }
}
