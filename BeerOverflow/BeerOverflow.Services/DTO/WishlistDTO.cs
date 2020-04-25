using BeerOverflow.Models;
using BeerOverflow.Services.DTO.Contracts;

namespace BeerOverflow.Services.DTO
{
    public class WishlistDTO : IWishlistDTO
    {
        public int UserId { get; set; }
        public int BeerId { get; set; }

        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
