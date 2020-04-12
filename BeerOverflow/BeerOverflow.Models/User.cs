﻿using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class User : IUser, IDeletable, IAudible, IBannable
    {
        public int Id { get; set; }
        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.BeersDrank = new List<BeerDrank>();
            this.Wishlist = new List<WishlistBeer>();
            this.Reviews = new List<Review>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
        public List<BeerDrank> BeersDrank { get; set; }
        public List<WishlistBeer> Wishlist { get; set; }
        public List<Review> Reviews { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
