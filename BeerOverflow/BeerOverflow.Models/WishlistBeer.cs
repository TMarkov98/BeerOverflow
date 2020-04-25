﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public class WishlistBeer : IWishlistBeer
    {
        public int UserId { get; set; }
        public int BeerId { get; set; }

        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
