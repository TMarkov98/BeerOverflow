﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class UserDTO : IUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
    }
}
