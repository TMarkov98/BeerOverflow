using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    interface IUserRole
    {
        int Id { get; set; }
        string RoleName { get; set; }
    }
}
