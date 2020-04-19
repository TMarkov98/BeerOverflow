using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly BeerOverflowContext context = new BeerOverflowContext();

        public IUserDTO GetUser(int id)
        {
            var user = context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            if (user == null)
                throw new ArgumentNullException("User not found.");

            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role.RoleName,
                IsBanned = user.IsBanned,
                BanReason = user.BanReason
            };
            return userDTO;
        }
        public ICollection<BeerDTO> GetBeersDrank(int id)
        {
            var user = context.Users.Include(u => u.Role).Include(u => u.BeersDrank).FirstOrDefault(i => i.Id == id);
            var beers = user.BeersDrank
                .Select(x => new BeerDTO
                {
                    Id = x.Beer.Id,
                    Name = x.Beer.Name,
                    BeerType = x.Beer.Type.Name,
                    Brewery = x.Beer.Brewery.Name,
                    BreweryCountry = x.Beer.Brewery.Country.Name,
                    AlcoholByVolume = x.Beer.AlcoholByVolume,
                })
                .ToList();
            return beers;
        }
        public ICollection<BeerDTO> GetWishlist(int id)
        {
            var user = context.Users.Include(u => u.Role).Include(u => u.Wishlist).FirstOrDefault(i => i.Id == id);
            var beers = user.Wishlist
                .Select(x => new BeerDTO
                {
                    Id = x.Beer.Id,
                    Name = x.Beer.Name,
                    BeerType = x.Beer.Type.Name,
                    Brewery = x.Beer.Brewery.Name,
                    BreweryCountry = x.Beer.Brewery.Country.Name,
                    AlcoholByVolume = x.Beer.AlcoholByVolume,
                })
                .ToList();
            return beers;
        }
        public ICollection<UserDTO> GetAllUsers()
        {
            var users = context.Users.Where(u => !u.IsDeleted)
                .Select(user => new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = user.Role.RoleName,
                    IsBanned = user.IsBanned,
                    BanReason = user.BanReason
                }).ToList();
            return users;
        }
        public IUserDTO CreateUser(IUserDTO userDTO)
        {
            var role = context.UserRoles.FirstOrDefault(ur => ur.RoleName == userDTO.Role);
            if (role == null)
                throw new ArgumentNullException("Invalid user role.");
            var user = new User
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Role = role,
                IsBanned = userDTO.IsBanned,
                BanReason = userDTO.BanReason
            };

            return userDTO;
        }
        public IUserDTO UpdateUser(int id, string userName, string email, string role, bool isBanned, string banReason)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            user.UserName = userName;
            user.Email = email;
            user.Role = context.UserRoles.FirstOrDefault(r => r.RoleName.ToLower() == role.ToLower()) ?? throw new ArgumentException($"Role {role} not found.");
            user.IsBanned = isBanned;
            user.BanReason = banReason;
            var userDTO = new UserDTO
            {
                UserName = userName,
                Email = email,
                Role = role,
                IsBanned = isBanned,
                BanReason = banReason
            };
            return userDTO;
        }
        public bool DeleteUser(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null || user.IsDeleted)
                return false;

            user.IsDeleted = true;
            user.DeletedOn = DateTime.Now;
            return true;
        }
    }
}
