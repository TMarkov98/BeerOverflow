using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerOverflow.Database
{
    public interface IBeerOverflowContext
    {
        DbSet<Beer> Beers { get; set; }
        DbSet<BeerDrank> BeersDrank { get; set; }
        DbSet<Brewery> Breweries { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WishlistBeer> WishlistBeers { get; set; }
    }
}