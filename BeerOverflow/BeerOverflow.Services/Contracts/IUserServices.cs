using BeerOverflow.Services.DTO;
using System.Collections.Generic;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserServices
    {
        IUserDTO CreateUser(IUserDTO userDTO);
        bool DeleteUser(int id);
        ICollection<UserDTO> GetAllUsers();
        IUserDTO GetUser(int id);
        ICollection<BeerDTO> GetBeersDrank(int id);
        ICollection<BeerDTO> GetWishlist(int id);
        IUserDTO UpdateUser(int id, string userName, string email, bool isBanned, string banReason);
        bool AddToWishlist(int userId, int beerId);
        bool AddToBeersDrank(int userId, int beerId);
    }
}