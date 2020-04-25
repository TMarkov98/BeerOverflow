using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Models.Contracts;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class UserServices : IUserServices
    {
        private readonly BeerOverflowContext _context;

        public UserServices(BeerOverflowContext context)
        {
            this._context = context;
        }

        public IUserDTO GetUser(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id && !u.IsDeleted);
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
            var user = _context.Users.Include(u => u.Role).Include(u => u.BeersDrank).FirstOrDefault(i => i.Id == id);
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
            var user = _context.Users.Include(u => u.Role).Include(u => u.Wishlist).ThenInclude(w => w.Beer).FirstOrDefault(i => i.Id == id);
            var beers = user.Wishlist
                .Select(x => new BeerDTO
                {
                    Id = x.Beer.Id,
                    Name = x.Beer.Name,
                    AlcoholByVolume = x.Beer.AlcoholByVolume,
                })
                .ToList();
            return beers;
        }
        public ICollection<UserDTO> GetAllUsers()
        {
            var users = _context.Users.Where(u => !u.IsDeleted)
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
            var role = _context.UserRoles.FirstOrDefault(ur => ur.RoleName == userDTO.Role);
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
            _context.SaveChanges();
            return userDTO;
        }
        public IUserDTO UpdateUser(int id, string userName, string email, string role, bool isBanned, string banReason)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            user.UserName = userName;
            user.Email = email;
            user.Role = _context.UserRoles.FirstOrDefault(r => r.RoleName.ToLower() == role.ToLower()) ?? throw new ArgumentException($"Role {role} not found.");
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
            _context.SaveChanges();
            return userDTO;
        }
        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null || user.IsDeleted)
                return false;

            user.IsDeleted = true;
            user.DeletedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
        public bool AddToWishlist(int userId, int beerId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
            var isAdded = user.Wishlist.Add(new WishlistBeer
            {
                BeerId = beerId,
                UserId = userId,
            });
            _context.SaveChanges();
            return isAdded; 
        }
        public bool AddToBeersDrank(int userId, int beerId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId && !u.IsDeleted);
            var isAdded = user.BeersDrank.Add(new BeerDrank
            {
                BeerId = beerId,
                UserId = userId,
            });
            _context.SaveChanges();
            return isAdded;
        }
    }
}
