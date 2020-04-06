using BeerOverflow.Models.Contracts;
using BeerOverflow.Models.Enums;
using System;

namespace BeerOverflow.Models
{
    public class Beer : Contracts.IBeer
    {
        int

        public string Name
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public BeerType BeerType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Brewery { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AlcoholByVolume
        {
            get
            {
                return 
            };
            set => throw new NotImplementedException();
        }
    }
}
