using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeerOverflow.Models
{
    public class Country : ICountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
