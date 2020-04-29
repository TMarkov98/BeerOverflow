using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BeerOverflow.Models
{
    public class User : IdentityUser<int>, IDeletable, IAudible, IBannable
    {
        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.BeersDrank = new HashSet<BeerDrank>();
            this.Wishlist = new HashSet<WishlistBeer>();
            this.Reviews = new List<Review>();
        }
        public HashSet<BeerDrank> BeersDrank { get; set; }
        public HashSet<WishlistBeer> Wishlist { get; set; }
        public List<Review> Reviews { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
