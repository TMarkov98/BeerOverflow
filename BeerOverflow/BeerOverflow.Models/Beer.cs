using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;

namespace BeerOverflow.Models
{
    public class Beer : IBeer
    {
        private double _alcoholByVolume;

        public int Id { get; set; }
        public string Name
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public BeerType BeerType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Brewery { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double AlcoholByVolume
        {
            get
            {
                return this._alcoholByVolume;
            }
            set
            {
                if (value < 3 || value > 13)
                    throw new ArgumentOutOfRangeException("AbV must be > 3 and < 13.");
                this._alcoholByVolume = value;
            }
        }
    }
}
