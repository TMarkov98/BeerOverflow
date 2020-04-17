using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface ILikeable
    {
        List<Like> Likes { get; set; }
    }
}
