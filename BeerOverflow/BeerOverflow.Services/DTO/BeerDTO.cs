using BeerOverflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO
{
    public class BeerDTO
    {
        private double _alcoholByVolume;


        public int Id { get; set; }
        public string Name { get; set; }
        public BeerType BeerType { get; set; }
        public string Brewery { get; set; }
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
