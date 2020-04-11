using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Beer : IBeer, IAudible, IDeletable, ILikeable
    {
        public Beer()
        {
            this.Reviews = new List<Review>();
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public BeerType BeerType { get; set; }
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public double AlcoholByVolume{ get; set; }
        public int Likes { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
