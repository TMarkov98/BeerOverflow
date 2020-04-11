﻿using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class Brewery : IBrewery, IAudible, IDeletable
    {
        public Brewery()
        {
            this.CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Country BreweryCountry { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}