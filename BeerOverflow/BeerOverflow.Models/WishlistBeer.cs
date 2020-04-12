using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class WishlistBeer
    {
        public int UserId { get; set; }
        public int BeerId { get; set; }

        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
