using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IAudible
    {
        int Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
