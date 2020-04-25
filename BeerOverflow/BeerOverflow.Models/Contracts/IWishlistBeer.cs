namespace BeerOverflow.Models
{
    public interface IWishlistBeer
    {
        Beer Beer { get; set; }
        int BeerId { get; set; }
        User User { get; set; }
        int UserId { get; set; }
    }
}