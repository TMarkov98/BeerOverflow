using BeerOverflow.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class BeerType : IBeerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
