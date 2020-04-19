using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.ReviewServices;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.DTO;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsAPIController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewsAPIController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        [HttpGet]
        public IActionResult  Get()
        {
            var model = this._reviewServices.GetAllReviews()
                .Select(x => new ReviewViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Text = x.Text,
                    Rating = x.Rating,
                    //TODO Need check if exist
                    TargetBeer = x.TargetBeer,
                    Author = x.Author,
                });
            return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var reviewDTO = this._reviewServices.GetReview(id);
            var model = new ReviewViewModel
            {
                Id = reviewDTO.Id,
                Name = reviewDTO.Name,
                Text = reviewDTO.Text,
                Rating = reviewDTO.Rating,
                //TODO Need check if exist
                TargetBeer = reviewDTO.TargetBeer,
                Author = reviewDTO.Author,
            };
            return Ok(model);
        }
        [HttpPost("")]
        public  IActionResult Post([FromBody] ReviewViewModel reviewViewModel)
        {
            if (reviewViewModel == null)
                return BadRequest();
            if (this.ReviewExists(reviewViewModel.Name))
                return ValidationProblem();
            var reviewDTO = new ReviewDTO
            {
                Name = reviewViewModel.Name,
                Text = reviewViewModel.Text,
                Rating = reviewViewModel.Rating,
                //TODO Need check if exist
                TargetBeer = reviewViewModel.TargetBeer,
                Author = reviewViewModel.Author,
            };
            var review = _reviewServices.CreateReview(reviewDTO);
            return Created("Post", review);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put (int id, [FromBody]ReviewViewModel reviewViewModel)
        {
            if (reviewViewModel == null)
                return BadRequest();
            var review = this._reviewServices.UpdateReviews(id, reviewViewModel.Name, reviewViewModel.Text, reviewViewModel.Rating, reviewViewModel.TargetBeer, reviewViewModel.Author);
            return Ok(review);
        }
        private bool ReviewExists(string name)
        {
            return _reviewServices.GetAllReviews().Any(r => r.Name == name);
        }
    }
}
