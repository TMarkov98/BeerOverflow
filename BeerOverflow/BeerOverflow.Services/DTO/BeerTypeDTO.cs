﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class BeerTypeDTO : IBeerTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
