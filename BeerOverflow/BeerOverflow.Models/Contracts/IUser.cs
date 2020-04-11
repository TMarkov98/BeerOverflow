using BeerOverflow.Models.Enums;
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
        ICollection<IBeer> BeersDrank { get; set; }
        ICollection<IBeer> Wishlist { get; set; }
        ICollection<IReview> Reviews { get; set; }
    }
}
