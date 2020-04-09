using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class Brewery : IBrewery
    {
        public Brewery(string name, string country)
        {
            this.Name = name;
            this.BreweryCountry = (Countries)Enum.Parse(typeof(Countries), country, true);
        }
        //TODO remove 'set'
        public int Id { get; set; }

        public string Name { get; set; }
        public Countries BreweryCountry { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
