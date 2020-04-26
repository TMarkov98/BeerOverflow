using System.Collections.Generic;

namespace BeerOverflow.Models.Contracts
{
    public interface ILikeable
    {
        List<Like> Likes { get; set; }
    }
}
