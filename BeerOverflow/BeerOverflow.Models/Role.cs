using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BeerOverflow.Models
{
    public class Role : IdentityRole<int>, IUserRole
    {
    }
}
