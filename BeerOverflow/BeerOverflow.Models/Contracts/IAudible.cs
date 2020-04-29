using System;

namespace BeerOverflow.Models.Contracts
{
    public interface IAudible
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
