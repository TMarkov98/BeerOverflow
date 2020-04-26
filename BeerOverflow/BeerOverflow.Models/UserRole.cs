using BeerOverflow.Models.Contracts;

namespace BeerOverflow.Models
{
    public class UserRole : IUserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
