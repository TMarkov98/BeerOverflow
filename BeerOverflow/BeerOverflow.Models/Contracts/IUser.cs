using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        UserRole UserRole { get; set; }
        List<BeerDrank> BeersDrank { get; set; }
        List<WishlistBeer> Wishlist { get; set; }
        List<Review> Reviews { get; set; }
    }
}
