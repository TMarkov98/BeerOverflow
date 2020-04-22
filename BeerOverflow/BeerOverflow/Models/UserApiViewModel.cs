using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class UserApiViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
    }
}
