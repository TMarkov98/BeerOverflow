using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class UserRole : IUserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
