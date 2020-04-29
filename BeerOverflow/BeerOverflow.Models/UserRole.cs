using BeerOverflow.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BeerOverflow.Models
{
    public class UserRole : IdentityRole<int>, IUserRole
    {
        public override string Name { get; set; }
    }
}
