using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeerOverflow.Models
{
    public class Beer : IBeer, IAudible, IDeletable, ILikeable
    {
        public Beer()
        {
            this.Likes = new List<Like>();
            this.Reviews = new List<Review>();
            this.CreatedOn = DateTime.Now;
            if(this.ImgUrl == null)
            {
                this.ImgUrl = "\\images\\Beer-Placeholder.jpg";
            }
        }
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        public int TypeId { get; set; }
        public BeerType Type { get; set; }
        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [Range(3, 13)]
        public double AlcoholByVolume { get; set; }
        public List<Like> Likes { get; set; }
        public List<Review> Reviews { get; set; }
        public string ImgUrl { get; set; }
    }
}
