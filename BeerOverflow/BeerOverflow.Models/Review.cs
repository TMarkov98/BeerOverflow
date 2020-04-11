using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class Review : IReview, IAudible, IDeletable, ILikeable
    {
        public int Id { get; set; }
        public Review()
        {
            this.CreatedOn = DateTime.Now;
        }
        public int Rate { get; set; }
        public int Name { get; set; }
        public string Text { get; set; }
        public int TargetBeerId { get; set; }
        public IBeer TargetBeer { get; set; }
        public int AuthorId { get; set; }
        public IUser Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int Likes { get; set; }
    }
}
