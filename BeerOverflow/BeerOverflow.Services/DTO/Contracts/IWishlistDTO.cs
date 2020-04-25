using BeerOverflow.Models;

namespace BeerOverflow.Services.DTO.Contracts
{
    public interface IWishlistDTO
    {
        Beer Beer { get; set; }
        int BeerId { get; set; }
        User User { get; set; }
        int UserId { get; set; }
    }
}