using BeerOverflow.Services.DTO;

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
