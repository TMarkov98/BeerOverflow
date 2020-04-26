using System;

namespace BeerOverflow.Models.Contracts
{
    public interface IAudible
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
