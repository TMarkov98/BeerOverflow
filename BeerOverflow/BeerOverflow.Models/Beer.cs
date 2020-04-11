using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class Beer : IBeer, IAudible, IDeletable, ILikeable
    {
        public Beer()
        {
            this.Reviews = new List<IReview>();
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public BeerType BeerType { get; set; }
        public int BreweryId { get; set; }
        public IBrewery Brewery { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public double AlcoholByVolume{ get; set; }
        public int Likes { get; set; }
        public ICollection<IReview> Reviews { get; set; }
    }
}
