using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeerOverflow.Models
{
    public class Review : IReview, IAudible, IDeletable
    {
        public int Id { get; set; }
        public Review()
        {
            this.CreatedOn = DateTime.Now;
        }
        [Range (0, 10)]
        public int Rating { get; set; }
        [Required]
        [StringLength (30, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public int TargetBeerId { get; set; }
        public Beer TargetBeer { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
