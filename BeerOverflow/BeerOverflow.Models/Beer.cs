using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;

namespace BeerOverflow.Models
{
    public class Beer : IBeer
    {
        private double _alcoholByVolume;
        private string _name;
        private string _brewery;
        private string _country;
        public Beer(string name, BeerType beerType, string brewery, string country, double AbV)
        {
            this.Name = name;
            this.BeerType = beerType;
            this.Brewery = brewery;
            this.Country = country;
            this.AlcoholByVolume = AbV;
            
        }
        public int Id { get; set; }
        public string Name
        {
            get => this._name;
            set
            {
                if (value.Length <= 0 || value.Length > 50)
                    throw new ArgumentException("Name can not be <= 0 and > 50.");
                this._name = value;
            }
        }
        public BeerType BeerType { get; set; }
        public string Brewery
        {
            get => this._brewery;
            set
            {
                if (value.Length <= 0 || value.Length > 50)
                    throw new ArgumentException("Brewery can not be <= 0 and > 50.");
                this._brewery = value;
            }
        }
        public string Country
        {
            get => this._country;
            set
            {
                if (value.Length <= 0 || value.Length > 50)
                    throw new ArgumentException("Country can not be <= 0 and > 50.");
                this._country = value;
            }
        }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public double AlcoholByVolume
        {
            get => this._alcoholByVolume;
            set
            {
                if (value < 3 || value > 13)
                    throw new ArgumentOutOfRangeException("AbV must be > 3 and < 13.");
                this._alcoholByVolume = value;
            }
        }
    }
}
