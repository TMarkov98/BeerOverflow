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
        List<Beer> BeersDrank { get; set; }
        List<Beer> Wishlist { get; set; }
        List<Review> Reviews { get; set; }
    }
}
