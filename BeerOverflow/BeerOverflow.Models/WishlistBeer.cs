namespace BeerOverflow.Models
{
    public class WishlistBeer : IWishlistBeer
    {
        public int UserId { get; set; }
        public int BeerId { get; set; }

        public User User { get; set; }
        public Beer Beer { get; set; }
    }
}
