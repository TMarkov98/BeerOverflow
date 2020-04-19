using BeerOverflow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class ReviewDTO : IReviewDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string TargetBeer { get; set; }
        public string Author { get; set; }
    }
}
