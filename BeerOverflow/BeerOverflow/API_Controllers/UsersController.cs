using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using BeerOverflow.Web.Models;
using BeerOverflow.Web.Models.ApiViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.API_Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            this._userServices = userServices ?? throw new ArgumentNullException("UserServices can NOT be null.");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var model = _userServices.GetAllUsers().Select(userDTO => new UserViewModel(userDTO));
            return Ok(model);
        }
        [HttpGet]
        [Route("sort")]
        public IActionResult Get([FromQuery]string param)
        {
            var model = _userServices.GetAllUsers().Select(userDTO => new UserViewModel(userDTO));
            switch (param.ToLower())
            {
                case "name":
                case "username":
                    model = model.OrderBy(u => u.UserName);
                    break;
                case "email":
                case "emailaddress":
                    model = model.OrderBy(u => u.EmailAddress);
                    break;
                case "role":
                case "userrole":
                    model = model.OrderBy(u => u.Role);
                    break;
                case "banned":
                    model = model.OrderBy(u => u.IsBanned);
                    break;
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var userDTO = _userServices.GetUser(id);
            var model = new UserViewModel(userDTO);
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}/wishlist")]
        public IActionResult GetWishlist(int id)
        {
            var beerDTOs = _userServices.GetWishlist(id);
            var model = beerDTOs.Select(beerDTO => new WishlistBeerViewModel(beerDTO));
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}/beersdrank")]
        public IActionResult GetBeersDrank(int id)
        {
            var beerDTOs = _userServices.GetBeersDrank(id);
            var model = beerDTOs.Select(beerDTO => new WishlistBeerViewModel(beerDTO));
            return Ok(model);
        }
        [HttpPut]
        [Route("{id}/wishlist/add")]
        public IActionResult AddToWishlist(int id, [FromBody] int beerId)
        {
            var user = _userServices.GetUser(id);
            _userServices.AddToWishlist(id, beerId);
            return Ok(user);
        }
        [HttpPut]
        [Route("{id}/beersdrank/add")]
        public IActionResult AddToBeersDrank(int id, [FromBody] int beerId)
        {
            var user = _userServices.GetUser(id);
            _userServices.AddToBeersDrank(id, beerId);
            return Ok(user);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            if (userViewModel == null)
                return BadRequest();
            if (this.UserExists(userViewModel.UserName, userViewModel.EmailAddress))
                return ValidationProblem($"User with {userViewModel.UserName} or {userViewModel.EmailAddress} already exist.");
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
        private bool UserExists(string name, string email)
        {
            return _userServices.GetAllUsers().Any(r => r.UserName == name || r.Email == email);
        }
    }
}