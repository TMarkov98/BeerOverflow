using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IReview
    {
        int Rate { get; set; }
        int Name { get; set; }
        string Text { get; set; }
        int TargetBeerId { get; set; }
        IBeer TargetBeer { get; set; }
        int AuthorId { get; set; }
        IUser Author { get; set; }
    }
}
