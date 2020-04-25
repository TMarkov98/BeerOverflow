using BeerOverflow.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }
        public UserViewModel(IUserDTO userDTO)
        {
            this.Id = userDTO.Id;
            this.UserName = userDTO.UserName;
            this.EmailAddress = userDTO.Email;
            this.Role = userDTO.Role;
            this.IsBanned = userDTO.IsBanned;
            this.BanReason = userDTO.BanReason;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
    }
}
