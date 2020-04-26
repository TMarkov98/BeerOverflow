﻿
using BeerOverflow.Services.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models.ApiViewModels
{
    public class BeerViewModel
    {
        public BeerViewModel()
        {

        }
        public BeerViewModel(IBeerDTO beerDTO)
        {
            this.Id = beerDTO.Id;
            this.Name = beerDTO.Name;
            this.BeerType = beerDTO.BeerType;
            this.BreweryCountry = beerDTO.BreweryCountry;
            this.AlcoholByVolume = beerDTO.AlcoholByVolume;
            this.Likes = beerDTO.Likes;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BeerType { get; set; }
        public string Brewery { get; set; }
        public string BreweryCountry { get; set; }
        public double AlcoholByVolume { get; set; }
        public int Likes { get; set; }
    }
}