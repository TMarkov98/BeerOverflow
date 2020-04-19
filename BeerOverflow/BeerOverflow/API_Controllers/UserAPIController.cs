using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.DTO;
using BeerOverflow.Services.UserServices;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserAPIController(IUserServices userServices)
        {
            this._userServices = userServices ?? throw new ArgumentNullException("UserServices can NOT be null.");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = _userServices.GetAllUsers().Select(userDTO => new UserViewModel
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                EmailAddress = userDTO.Email,
                Role = userDTO.Role,
                IsBanned = userDTO.IsBanned,
                BanReason = userDTO.BanReason
            });
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var userDTO = _userServices.GetUser(id);
            var model = new UserViewModel
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                EmailAddress = userDTO.Email,
                Role = userDTO.Role,
                IsBanned = userDTO.IsBanned,
                BanReason = userDTO.BanReason
            };
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}/wishlist")]
        public IActionResult GetWishlist(int id)
        {
            var beerDTOs = _userServices.GetWishlist(id);
            var model = beerDTOs.Select(x => new BeerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                BeerType = x.BeerType.ToString(),
                Brewery = x.Brewery,
                BreweryCountry = x.BreweryCountry,
                AlcoholByVolume = x.AlcoholByVolume,
            });
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}/beersdrank")]
        public IActionResult GetBeersDrank(int id)
        {
            var beerDTOs = _userServices.GetBeersDrank(id);
            var model = beerDTOs.Select(x => new BeerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                BeerType = x.BeerType.ToString(),
                Brewery = x.Brewery,
                BreweryCountry = x.BreweryCountry,
                AlcoholByVolume = x.AlcoholByVolume,
            });
            return Ok(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            if (userViewModel == null)
                return BadRequest();
            var userDTO = new UserDTO
            {
                Id = userViewModel.Id,
                UserName = userViewModel.UserName,
                Email = userViewModel.EmailAddress,
                Role = userViewModel.Role,
                IsBanned = userViewModel.IsBanned,
                BanReason = userViewModel.BanReason
            };
            var user = _userServices.CreateUser(userDTO);
            return Created("Post", userViewModel);
        }
        [HttpPut]
        [Route("")]
        public IActionResult Put(int id, [FromBody]UserViewModel userViewModel)
        {
            if (userViewModel == null)
                return BadRequest();
            var user = this._userServices.UpdateUser(id, userViewModel.UserName, userViewModel.EmailAddress, userViewModel.Role, userViewModel.IsBanned, userViewModel.BanReason);
            return Ok(user);
        }
    }
}