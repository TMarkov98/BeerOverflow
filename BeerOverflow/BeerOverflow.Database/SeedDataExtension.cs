using BeerOverflow.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BeerOverflow.Database
{
    public static class SeedDataExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //SEED ALL COUNRTIES

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo regionInfo = new RegionInfo(ci.Name);
                if (countries.Count(x => x.EnglishName == regionInfo.EnglishName) <= 0)
                    countries.Add(regionInfo);
            }
            int id = 1;
            foreach (RegionInfo regionInfo in countries.OrderBy(x => x.EnglishName))
            {
                modelBuilder.Entity<Country>().HasData(
                    new Country
                    {
                        Id = id,
                        Name = regionInfo.EnglishName,
                        Code = regionInfo.TwoLetterISORegionName
                    }
                );
                id++;
            }

            //SEED ALL BREWERIES

            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 1,
                    Name = "Mythos Breweries",
                    CountryId = 87,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 2,
                    Name = "Ah! Brew Works Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 3,
                    Name = "Ailyak Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 4,
                    Name = "Astika Brewery Haskovo",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 5,
                    Name = "Beer Bastards Burgas",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 6,
                    Name = "Beerbox Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 7,
                    Name = "Beershop-BG Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 8,
                    Name = "Birariya River Side Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 9,
                    Name = "Blek Pine Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 10,
                    Name = "Boliarka Brewery Veliko Tarnovo",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 11,
                    Name = "Bro Beer Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 12,
                    Name = "Brothers Brew Varna",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 13,
                    Name = "Pivovarnata Burgas",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 14,
                    Name = "Can Supply Blagoevgrad",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 15,
                    Name = "Cohones Brewery Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 16,
                    Name = "Dorst Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 17,
                    Name = "Dunav Craft Brewery Ruse",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 18,
                    Name = "Glarus Craft Brewing Company Varna",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 19,
                    Name = "Halbite Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 20,
                    Name = "Hills Brewery Perushtitsa",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 21,
                    Name = "Jägerhof Plovdiv",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 22,
                    Name = "Kazan Artizan Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 23,
                    Name = "Lomsko Pivo AD Lom",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 24,
                    Name = "Birariya Tryavna",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 25,
                    Name = "Mad Panda Brewery Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 26,
                    Name = "Meadly Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 27,
                    Name = "Metalhead Brewery Burgas",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 28,
                    Name = "Pirinsko Pivo Blagoevgrad",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 29,
                    Name = "Pivoteka Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 30,
                    Name = "Pivovaren Zavod Kamenitsa Plovdiv",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 31,
                    Name = "Pivovarna 359 Mramor",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 32,
                    Name = "Pivovarna Britos Veliko Tarnovo",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 33,
                    Name = "Pivovarna Zagorka Stara Zagora",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 34,
                    Name = "Rhombus Craft Brewery Pazardzhik",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 35,
                    Name = "Royal Cat Varna",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 36,
                    Name = "Shumensko Pivo Shumen",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 37,
                    Name = "Trima i Dvama Sliven",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 38,
                    Name = "White Stork Beer Company Sofia",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 39,
                    Name = "The Black Sheep Varna",
                    CountryId = 34,
                });
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery
                {
                    Id = 40,
                    Name = "Meltum Brewery Lovech",
                    CountryId = 34,
                });

            //SEED ALL BEER TYPES

            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 1,
                    Name = "Pale Lager"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 2,
                    Name = "Blonde Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 3,
                    Name = "Hefewizen"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 4,
                    Name = "Pale Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 5,
                    Name = "IPA"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 6,
                    Name = "Amber Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 7,
                    Name = "Irish Red Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 8,
                    Name = "Brown Ale"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 9,
                    Name = "Porter"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 10,
                    Name = "Stout"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 11,
                    Name = "Pilsner"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 12,
                    Name = "Mead"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 13,
                    Name = "Bock"
                });
            modelBuilder.Entity<BeerType>().HasData(
                new BeerType
                {
                    Id = 14,
                    Name = "Cider"
                });
            //SEED ALL BEERS

            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 1,
                    Name = "Kaiser",
                    BreweryId = 1,
                    AlcoholByVolume = 5,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 2,
                    Name = "Ah! 7 - Mursalski Red Ale",
                    BreweryId = 2,
                    AlcoholByVolume = 6.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 3,
                    Name = "Ah! 5 - Bad Baba",
                    BreweryId = 2,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 4,
                    Name = "Ah! 3 - Bulgarian Pale Ale",
                    BreweryId = 2,
                    AlcoholByVolume = 5.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 5,
                    Name = "Ah! Sofia Streets",
                    BreweryId = 2,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 6,
                    Name = "Mr. Habi Benero",
                    BreweryId = 2,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 7,
                    Name = "Ah! 6 - Funky Janky",
                    BreweryId = 2,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 8,
                    Name = "Ah! 13 - Corruption Brown Ale",
                    BreweryId = 2,
                    AlcoholByVolume = 8.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 9,
                    Name = "Ah! 9 - Kiss My Kvass",
                    BreweryId = 2,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 10,
                    Name = "Ah! 23 - French Apple Cider",
                    BreweryId = 2,
                    AlcoholByVolume = 6.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 14
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 11,
                    Name = "Ah! 9 - Indian Pale Ale",
                    BreweryId = 2,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 12,
                    Name = "Ailyak Cryo Mosaic IPA",
                    BreweryId = 3,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 13,
                    Name = "Ailyak Cryo DDH NEIPA",
                    BreweryId = 3,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 14,
                    Name = "Ailyak ProViotic",
                    BreweryId = 3,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 15,
                    Name = "Ailyak Birthday IPA",
                    BreweryId = 3,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 16,
                    Name = "Astika Fine Quality Lager",
                    BreweryId = 4,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 17,
                    Name = "Astika Lux Premium",
                    BreweryId = 4,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 18,
                    Name = "Burgasko Svetlo",
                    BreweryId = 4,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 19,
                    Name = "Astika Special",
                    BreweryId = 4,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 20,
                    Name = "Haskovo Beck's",
                    BreweryId = 4,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 21,
                    Name = "Beer Bastards Basi Kefa",
                    BreweryId = 5,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 22,
                    Name = "Beer Bastards Po-Poleka",
                    BreweryId = 5,
                    AlcoholByVolume = 5.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 23,
                    Name = "Beer Bastards Faster Bastard",
                    BreweryId = 5,
                    AlcoholByVolume = 5.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 24,
                    Name = "Beer Bastards Freigeist Dirty Flamingo",
                    BreweryId = 5,
                    AlcoholByVolume = 4.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 25,
                    Name = "Beer Bastards Opasen Char",
                    BreweryId = 5,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 26,
                    Name = "Beer Bastards Bash Maistora",
                    BreweryId = 5,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 27,
                    Name = "Beer Bastards Edno Vreme",
                    BreweryId = 5,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 28,
                    Name = "Beer Bastards Solo New Garash Cake",
                    BreweryId = 5,
                    AlcoholByVolume = 9.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 29,
                    Name = "Beer Bastards Bone Chance",
                    BreweryId = 5,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 30,
                    Name = "Beer Bastards Gusto Maina",
                    BreweryId = 5,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 31,
                    Name = "Beer Bastards Tok i Zhica",
                    BreweryId = 5,
                    AlcoholByVolume = 9.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 32,
                    Name = "Beer Bastards Dami Kanyat",
                    BreweryId = 5,
                    AlcoholByVolume = 8.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 33,
                    Name = "Beer Bastards Toplo Takova",
                    BreweryId = 5,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 34,
                    Name = "Astika Tumno",
                    BreweryId = 4,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 35,
                    Name = "Astika Svetlo",
                    BreweryId = 4,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 36,
                    Name = "Beerbox Galleon Weiss",
                    BreweryId = 6,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 37,
                    Name = "Beerbox Galleon Premium Lager",
                    BreweryId = 6,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 38,
                    Name = "HBH Tumna Jiva Bira",
                    BreweryId = 8,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 39,
                    Name = "Beershop-BG Gaida",
                    BreweryId = 7,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 40,
                    Name = "HBH Svetla Jiva Bira",
                    BreweryId = 8,
                    AlcoholByVolume = 5.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 41,
                    Name = "Blek Pine Stout",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 42,
                    Name = "Blek Pine Rauchbier with Cocoa and Blek Pepper",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 43,
                    Name = "Blek Pine Kokonut Porter",
                    BreweryId = 9,
                    AlcoholByVolume = 7.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 44,
                    Name = "Blek Pine Summer Is Coming",
                    BreweryId = 9,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 45,
                    Name = "Blek Pine Pumpking Ale",
                    BreweryId = 9,
                    AlcoholByVolume = 7.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 46,
                    Name = "Blek Pine IPA",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 47,
                    Name = "Blek Pine WCOS IPA",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 48,
                    Name = "Blek Pine New England",
                    BreweryId = 9,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 49,
                    Name = "Blek Pine Sour Session",
                    BreweryId = 9,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 50,
                    Name = "Blek Pine Blek & Red",
                    BreweryId = 9,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 51,
                    Name = "Blek Pine Rum Pum Pum",
                    BreweryId = 9,
                    AlcoholByVolume = 9.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 52,
                    Name = "Blek Pine Chilli in the Hills Chipotle Hoppy Stout",
                    BreweryId = 9,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 53,
                    Name = "Blek Pine Blanche De Citron",
                    BreweryId = 9,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 54,
                    Name = "Blek Pine Summer Is Coming - Episode 2",
                    BreweryId = 9,
                    AlcoholByVolume = 5.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 55,
                    Name = "Blek Pine Divo Divo",
                    BreweryId = 9,
                    AlcoholByVolume = 7.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 56,
                    Name = "Blek Pine Seriez Peach",
                    BreweryId = 9,
                    AlcoholByVolume = 6.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 57,
                    Name = "Blek Pine Session",
                    BreweryId = 9,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 58,
                    Name = "Blek Pine Sofia Metal Fest IPA",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 59,
                    Name = "Blek Pine Rye IPA",
                    BreweryId = 9,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 60,
                    Name = "Blek Pine IPA Limited Edition",
                    BreweryId = 9,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 61,
                    Name = "Boliarka Tumno",
                    BreweryId = 10,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 62,
                    Name = "Schweik Cheshko Pivo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 63,
                    Name = "Balkansko Svetlo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 64,
                    Name = "Boliarka Svetlo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 65,
                    Name = "Diana Lager",
                    BreweryId = 10,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 66,
                    Name = "Kings Premium",
                    BreweryId = 10,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 67,
                    Name = "Boliarka Elba Svetlo Pivo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 68,
                    Name = "Boliarka Fort Premium Lager 100% Malt",
                    BreweryId = 10,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 69,
                    Name = "Tsarsko Svetlo",
                    BreweryId = 10,
                    AlcoholByVolume = 3.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 70,
                    Name = "Boliarka Unpasteurised",
                    BreweryId = 10,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 71,
                    Name = "Diana Premium Lager",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 72,
                    Name = "Peti Okean Jiva Bira",
                    BreweryId = 10,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 73,
                    Name = "Kehlstein Premium Lager",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 74,
                    Name = "Boliarka Special",
                    BreweryId = 10,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 75,
                    Name = "Stara Stolitsa Svetlo Pivo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 76,
                    Name = "Boliarka Weiss",
                    BreweryId = 10,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 77,
                    Name = "Nashensko Svetlo",
                    BreweryId = 10,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 78,
                    Name = "Bro Beer Fat Free Pig",
                    BreweryId = 11,
                    AlcoholByVolume = 3.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 79,
                    Name = "Bro Beer Importered Pig",
                    BreweryId = 11,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 80,
                    Name = "Brothers Brew Team Make Coffee Great Again",
                    BreweryId = 12,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 81,
                    Name = "Brothers Brew Team Right As Rain",
                    BreweryId = 12,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 82,
                    Name = "Brothers Brew Team Mosaic",
                    BreweryId = 12,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 83,
                    Name = "Brothers Deutschamerikaner",
                    BreweryId = 12,
                    AlcoholByVolume = 5.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 84,
                    Name = "Brothers Brew Team Hello, World!",
                    BreweryId = 12,
                    AlcoholByVolume = 4.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 85,
                    Name = "Brothers Brew Team Little Princess",
                    BreweryId = 12,
                    AlcoholByVolume = 8.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 86,
                    Name = "Brothers Brew Team Liberation",
                    BreweryId = 12,
                    AlcoholByVolume = 7.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 87,
                    Name = "Veritas Spetsialen Lager",
                    BreweryId = 13,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 88,
                    Name = "Veritas Single & Single",
                    BreweryId = 13,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 89,
                    Name = "Burgaska - Pivovarnata Summer Ale",
                    BreweryId = 13,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 90,
                    Name = "Veritas Schwarz",
                    BreweryId = 13,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 91,
                    Name = "Veritas IPA",
                    BreweryId = 13,
                    AlcoholByVolume = 5.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 92,
                    Name = "Veritas Green Lager",
                    BreweryId = 13,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 93,
                    Name = "Veritas Tumna",
                    BreweryId = 13,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 94,
                    Name = "Veritas Chervena",
                    BreweryId = 13,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 95,
                    Name = "Veritas Weizen",
                    BreweryId = 13,
                    AlcoholByVolume = 5.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 96,
                    Name = "Veritas Amber",
                    BreweryId = 13,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 97,
                    Name = "Can Supply Stobsko Pivo",
                    BreweryId = 14,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 98,
                    Name = "Can Supply Brexit Craft Beer",
                    BreweryId = 14,
                    AlcoholByVolume = 4.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 99,
                    Name = "Can Supply Odesos Markovo Pivo",
                    BreweryId = 14,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 100,
                    Name = "Can Supply Odesos Svetlo Pivo",
                    BreweryId = 14,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 101,
                    Name = "Can Supply Grussberg Pilsner",
                    BreweryId = 14,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 102,
                    Name = "Cohones Holy St. Out",
                    BreweryId = 15,
                    AlcoholByVolume = 7.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 103,
                    Name = "Cohones St. Out",
                    BreweryId = 15,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 104,
                    Name = "Cohones Family Jewels",
                    BreweryId = 15,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 105,
                    Name = "Dorst Zimen Bok",
                    BreweryId = 16,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 106,
                    Name = "Dorst Hippy Shake",
                    BreweryId = 16,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 107,
                    Name = "Dorst Pink Future Mosaic",
                    BreweryId = 16,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 108,
                    Name = "Roustchouk Porter",
                    BreweryId = 17,
                    AlcoholByVolume = 5.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 109,
                    Name = "Dunav Sans Changement",
                    BreweryId = 17,
                    AlcoholByVolume = 5.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 110,
                    Name = "Dunav Radetzky",
                    BreweryId = 17,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 111,
                    Name = "Glarus Porter",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 112,
                    Name = "Glarus Black Sea IPA",
                    BreweryId = 18,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 113,
                    Name = "Glarus Special English Ale",
                    BreweryId = 18,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 114,
                    Name = "Glarus Dubbel",
                    BreweryId = 18,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 115,
                    Name = "Glarus Saison",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 116,
                    Name = "Glarus Premium Ale",
                    BreweryId = 18,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 117,
                    Name = "Glarus Marzen",
                    BreweryId = 18,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 118,
                    Name = "Glarus Jester",
                    BreweryId = 18,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 119,
                    Name = "Glarus Halo",
                    BreweryId = 18,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 120,
                    Name = "Glarus Fruity & Hazy",
                    BreweryId = 18,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 121,
                    Name = "Glarus Rhodopi Dream",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 122,
                    Name = "Glarus Signature Session IPA Mandarina Bavaria",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 123,
                    Name = "Glarus Holy Night",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 124,
                    Name = "Glarus London Porter",
                    BreweryId = 18,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 125,
                    Name = "Halbite Nashto Pivo",
                    BreweryId = 19,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 126,
                    Name = "Hills Helles Rauch",
                    BreweryId = 20,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 127,
                    Name = "Hills Pils",
                    BreweryId = 20,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 128,
                    Name = "Hills Summer Blanche - Session Ale",
                    BreweryId = 20,
                    AlcoholByVolume = 3.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 129,
                    Name = "Hills Smooth Bock",
                    BreweryId = 20,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 13
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 130,
                    Name = "Hills Single Stout",
                    BreweryId = 20,
                    AlcoholByVolume = 5.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 131,
                    Name = "Hills Weizen",
                    BreweryId = 20,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 132,
                    Name = "Jägerhof Weiss",
                    BreweryId = 21,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 133,
                    Name = "Jägerhof Dunkel",
                    BreweryId = 21,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 134,
                    Name = "Jägerhof Ale",
                    BreweryId = 21,
                    AlcoholByVolume = 5.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 135,
                    Name = "Jägerhof Bock",
                    BreweryId = 21,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 13
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 136,
                    Name = "Jägerhof Dunkel Weisse",
                    BreweryId = 21,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 137,
                    Name = "Kazan Artizan Stout",
                    BreweryId = 22,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 138,
                    Name = "Kazan Artizan Ad Hoc IPA",
                    BreweryId = 22,
                    AlcoholByVolume = 5.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 139,
                    Name = "Almus Tumno",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 140,
                    Name = "Almus Cherveno",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 141,
                    Name = "Vitoshko Lale",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 142,
                    Name = "Almus Lager",
                    BreweryId = 23,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 143,
                    Name = "Almus Lux",
                    BreweryId = 23,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 144,
                    Name = "Vitoshko Lale Hoppy Weiss",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 145,
                    Name = "Lomsko Pivo Ubav Pustinyak",
                    BreweryId = 23,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 146,
                    Name = "Lomsko Amber Beer",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 147,
                    Name = "Hmelo Lale",
                    BreweryId = 23,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 148,
                    Name = "Lomsko Pivo Blag Pustinyak",
                    BreweryId = 23,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 149,
                    Name = "Lomsko Pivo Shopsko Pivo",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 150,
                    Name = "Lomsko Pivo Bash Pustinyak",
                    BreweryId = 23,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 151,
                    Name = "Lomsko Pivo Pustinyak",
                    BreweryId = 23,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 152,
                    Name = "Lomsko Pivo Yak Pustinyak",
                    BreweryId = 18,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 153,
                    Name = "Lomsko Porter",
                    BreweryId = 23,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 154,
                    Name = "Vitoshko Lale Pale Ale",
                    BreweryId = 23,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 155,
                    Name = "Vitoshko Lale Tumno Pivo",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 156,
                    Name = "Lomsko Pivo Everyday Lager",
                    BreweryId = 23,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 157,
                    Name = "Lomsko Pivo Everyday Luxe",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 158,
                    Name = "Shipka",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 159,
                    Name = "Lomsko Lux",
                    BreweryId = 23,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 160,
                    Name = "Gredberg",
                    BreweryId = 23,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 161,
                    Name = "Shopsko Svetlo",
                    BreweryId = 23,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 162,
                    Name = "Almus Special",
                    BreweryId = 23,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 163,
                    Name = "Tsarsko Lager",
                    BreweryId = 23,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 164,
                    Name = "Miziya Svetlo",
                    BreweryId = 23,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 165,
                    Name = "Dunavsko Lager",
                    BreweryId = 23,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 166,
                    Name = "Optima Svetlo",
                    BreweryId = 23,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 167,
                    Name = "Lucs Plum",
                    BreweryId = 24,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 168,
                    Name = "Lucs Cherry",
                    BreweryId = 24,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 169,
                    Name = "Lucs Trevnensko",
                    BreweryId = 24,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 170,
                    Name = "Lucs Kehlibar",
                    BreweryId = 24,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 171,
                    Name = "Lucs Svetlo",
                    BreweryId = 24,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 172,
                    Name = "Mad Panda Cryo Bandit",
                    BreweryId = 25,
                    AlcoholByVolume = 5.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 173,
                    Name = "Mad Panda God Gave the Hops",
                    BreweryId = 25,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 174,
                    Name = "Mad Panda Powder Mafia",
                    BreweryId = 25,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 175,
                    Name = "Mad Panda PsycHOP Therapy",
                    BreweryId = 25,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 176,
                    Name = "Meadly Sweet Mead",
                    BreweryId = 26,
                    AlcoholByVolume = 11.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 12
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 177,
                    Name = "Meadly Traditional Mead",
                    BreweryId = 26,
                    AlcoholByVolume = 13.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 12
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 178,
                    Name = "Meadly Live Mead With Herbs",
                    BreweryId = 26,
                    AlcoholByVolume = 12.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 12
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 179,
                    Name = "Meadly Zhiva Medovina",
                    BreweryId = 26,
                    AlcoholByVolume = 10.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 12
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 180,
                    Name = "Metalhead Space Lord",
                    BreweryId = 27,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 181,
                    Name = "Metalhead Sweet Stout of Mine",
                    BreweryId = 27,
                    AlcoholByVolume = 10.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 182,
                    Name = "Metalhead Your Girlfriend's Girlfriend",
                    BreweryId = 27,
                    AlcoholByVolume = 6.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 183,
                    Name = "Metalhead Lickitup",
                    BreweryId = 27,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 184,
                    Name = "Metalhead Headbangers Boil",
                    BreweryId = 27,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 185,
                    Name = "Metalhead Cinn City",
                    BreweryId = 27,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 186,
                    Name = "Metalhead Supermassive Black IPA",
                    BreweryId = 27,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 187,
                    Name = "Metalhead King Nothing",
                    BreweryId = 27,
                    AlcoholByVolume = 7.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 188,
                    Name = "Metalhead Turbo Lover",
                    BreweryId = 27,
                    AlcoholByVolume = 5.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 189,
                    Name = "Metalhead Pleasure and Pain",
                    BreweryId = 27,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 190,
                    Name = "Metalhead Sweet Stout of Mine Barrel Aged: Jack Daniel's",
                    BreweryId = 27,
                    AlcoholByVolume = 10.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 191,
                    Name = "Metalhead Running Mild",
                    BreweryId = 27,
                    AlcoholByVolume = 3.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 192,
                    Name = "Metalhead Metalingus",
                    BreweryId = 27,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 193,
                    Name = "Metalhead Hop Suey",
                    BreweryId = 27,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 194,
                    Name = "Pirinsko Svetlo Pivo",
                    BreweryId = 28,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 195,
                    Name = "Pirinsko Mlado Pivo",
                    BreweryId = 28,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 196,
                    Name = "Pirinsko Ledeno",
                    BreweryId = 28,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 197,
                    Name = "Pirinsko Tumno Pivo",
                    BreweryId = 28,
                    AlcoholByVolume = 4.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 198,
                    Name = "Pivoteka Hala",
                    BreweryId = 29,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 199,
                    Name = "Kamenitza Staro Pivo",
                    BreweryId = 30,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 200,
                    Name = "Kamenitza Tamno",
                    BreweryId = 30,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 201,
                    Name = "Kamenitza Lev",
                    BreweryId = 30,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 202,
                    Name = "Kamenitza Extra",
                    BreweryId = 30,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 203,
                    Name = "Kamenitza 1881",
                    BreweryId = 30,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 204,
                    Name = "Slavena Svetlo",
                    BreweryId = 30,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 205,
                    Name = "Kamenitza Cherveno",
                    BreweryId = 30,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 206,
                    Name = "Kamenitza Bialo",
                    BreweryId = 30,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 207,
                    Name = "Pleven Svetlo Pivo",
                    BreweryId = 30,
                    AlcoholByVolume = 4.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 208,
                    Name = "Kamenitza Nefiltrirano",
                    BreweryId = 30,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 209,
                    Name = "Kamenitza Tumno",
                    BreweryId = 30,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 210,
                    Name = "Kamenitza Pshenichno",
                    BreweryId = 30,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 211,
                    Name = "Kamenitza Live",
                    BreweryId = 30,
                    AlcoholByVolume = 5.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 212,
                    Name = "Kamenitza Tvurdo",
                    BreweryId = 30,
                    AlcoholByVolume = 9.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 213,
                    Name = "Pleven Svetlo",
                    BreweryId = 30,
                    AlcoholByVolume = 4.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 214,
                    Name = "Divo Pivo",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 215,
                    Name = "Divo Pivo HD Limited",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 216,
                    Name = "Divo Pivo Red Ale",
                    BreweryId = 31,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 218,
                    Name = "Divo Pivo Session IPA",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 219,
                    Name = "Divo Pivo DDH DDH",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 220,
                    Name = "Kotka & Mishka Session IPA",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 221,
                    Name = "Samets",
                    BreweryId = 31,
                    AlcoholByVolume = 4.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 222,
                    Name = "Na Specialnata Peika",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 223,
                    Name = "Na Peikata",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 224,
                    Name = "Divo Pivo Gaillot",
                    BreweryId = 31,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 225,
                    Name = "Divo Pivo Kapana Ale",
                    BreweryId = 31,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 226,
                    Name = "Divo Pivo Weiss",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 227,
                    Name = "Divo Pivo 3rd of March",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 228,
                    Name = "Divo Pivo First Birthday Edition",
                    BreweryId = 31,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 229,
                    Name = "Britos",
                    BreweryId = 32,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 230,
                    Name = "Britos Contintental Lager",
                    BreweryId = 32,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 231,
                    Name = "Britos Hoppy Blond",
                    BreweryId = 32,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 232,
                    Name = "Britos Opusheno",
                    BreweryId = 32,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 233,
                    Name = "Nazdrave Svetlo",
                    BreweryId = 32,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 234,
                    Name = "Kronberg",
                    BreweryId = 32,
                    AlcoholByVolume = 4.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 235,
                    Name = "Stolichno Bock",
                    BreweryId = 33,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 13
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 236,
                    Name = "Stolichno Weiss",
                    BreweryId = 33,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 237,
                    Name = "Stolichno Pale Bock",
                    BreweryId = 33,
                    AlcoholByVolume = 7.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 13
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 238,
                    Name = "Stolichno Amber Pils",
                    BreweryId = 33,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 239,
                    Name = "Stolichno Pale Ale",
                    BreweryId = 33,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 240,
                    Name = "Kradetsut na Yabulki Sochna Yabulka",
                    BreweryId = 33,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 14
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 241,
                    Name = "Ariana Tumno",
                    BreweryId = 33,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 242,
                    Name = "Zagorka Rezerva",
                    BreweryId = 33,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 243,
                    Name = "Zagorka IPA",
                    BreweryId = 33,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 244,
                    Name = "Zagorka Retro",
                    BreweryId = 33,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 245,
                    Name = "Zagorka Spetsialno",
                    BreweryId = 33,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 246,
                    Name = "Ariana",
                    BreweryId = 33,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 247,
                    Name = "Zagorka Gold",
                    BreweryId = 33,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 248,
                    Name = "Kradetsut na Yabulki Krade I Slivi",
                    BreweryId = 33,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 14
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 249,
                    Name = "Kradetsut na Yabulki Krade I Vishni",
                    BreweryId = 33,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 14
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 250,
                    Name = "Amstel Dark",
                    BreweryId = 33,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 251,
                    Name = "Ariana Varka7",
                    BreweryId = 33,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 252,
                    Name = "Rhombus Impreial Porter (Barrel Aged)",
                    BreweryId = 34,
                    AlcoholByVolume = 9.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 253,
                    Name = "Rhombus Dirty",
                    BreweryId = 34,
                    AlcoholByVolume = 7.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 254,
                    Name = "Rhombus Imperial Porter",
                    BreweryId = 34,
                    AlcoholByVolume = 7.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 255,
                    Name = "Rhombus Aloha IPA",
                    BreweryId = 34,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 256,
                    Name = "Rhombus Weizen IPA",
                    BreweryId = 34,
                    AlcoholByVolume = 5.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 257,
                    Name = "Rhombus English Porter",
                    BreweryId = 34,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 258,
                    Name = "Rhombus Dr. Brettish",
                    BreweryId = 34,
                    AlcoholByVolume = 6.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 259,
                    Name = "Rhombus Dr. Cherry Kriek",
                    BreweryId = 34,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 260,
                    Name = "Rhombus Alba - White IPA",
                    BreweryId = 34,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 261,
                    Name = "Rhombus Apfel Strudel",
                    BreweryId = 34,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 262,
                    Name = "Rhombus Pearl",
                    BreweryId = 34,
                    AlcoholByVolume = 7.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 263,
                    Name = "Rhombus In the Blooming Rye",
                    BreweryId = 34,
                    AlcoholByVolume = 6.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 264,
                    Name = "Rhombus Violet",
                    BreweryId = 34,
                    AlcoholByVolume = 3.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 265,
                    Name = "Rhombus Lavender Nights",
                    BreweryId = 34,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 266,
                    Name = "Rhombus Mint Nights",
                    BreweryId = 34,
                    AlcoholByVolume = 6.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 267,
                    Name = "Rhombus Hakuna Matata",
                    BreweryId = 34,
                    AlcoholByVolume = 3.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 268,
                    Name = "Rhombus Tok i Zhica",
                    BreweryId = 34,
                    AlcoholByVolume = 9.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 269,
                    Name = "Rhombus Orpheus Gruit",
                    BreweryId = 34,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 270,
                    Name = "Rhombus The Crow",
                    BreweryId = 34,
                    AlcoholByVolume = 8.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 271,
                    Name = "Rhombus Christmas Fever",
                    BreweryId = 34,
                    AlcoholByVolume = 5.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 272,
                    Name = "Rhombus AnimAle",
                    BreweryId = 34,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 273,
                    Name = "Rhombus Pardon I'm Brut",
                    BreweryId = 34,
                    AlcoholByVolume = 7.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 274,
                    Name = "Rhombus Irish Red",
                    BreweryId = 34,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 275,
                    Name = "Rhombus Weiss",
                    BreweryId = 34,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 276,
                    Name = "Rhombus Pale Ale",
                    BreweryId = 34,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 277,
                    Name = "Rhombus Dark Steel",
                    BreweryId = 34,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 278,
                    Name = "Rhombus St. Patrick's Beer",
                    BreweryId = 34,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 279,
                    Name = "Rhombus Catch the Wave",
                    BreweryId = 34,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 333,
                    Name = "Rhombus Pilsner",
                    BreweryId = 34,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 334,
                    Name = "Rhombus Easter",
                    BreweryId = 34,
                    AlcoholByVolume = 7.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 335,
                    Name = "Rhombus Belona",
                    BreweryId = 34,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 336,
                    Name = "Rhombus Mart",
                    BreweryId = 34,
                    AlcoholByVolume = 5.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 337,
                    Name = "Rhombus Black Widow",
                    BreweryId = 34,
                    AlcoholByVolume = 5.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 338,
                    Name = "Rhombus Arriba Arriba",
                    BreweryId = 34,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 339,
                    Name = "Rhombus Boston Tea Party",
                    BreweryId = 34,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 340,
                    Name = "Rhombus Kirschtorte",
                    BreweryId = 34,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 341,
                    Name = "Rhombus Breakfast Oatmeal Stout",
                    BreweryId = 34,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 342,
                    Name = "Rhombus Star Anise Stout",
                    BreweryId = 34,
                    AlcoholByVolume = 5.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 280,
                    Name = "Rhombus Brown Ale",
                    BreweryId = 34,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 281,
                    Name = "Rhombus Flanders Brown Ale Special Selection",
                    BreweryId = 34,
                    AlcoholByVolume = 5.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 282,
                    Name = "Rhombus Belgian Blond",
                    BreweryId = 34,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 283,
                    Name = "Rhombus Spetsialno",
                    BreweryId = 34,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 284,
                    Name = "Rhombus Imperial Ale",
                    BreweryId = 34,
                    AlcoholByVolume = 6.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 285,
                    Name = "Rhombus Svetlo",
                    BreweryId = 34,
                    AlcoholByVolume = 4.8,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 286,
                    Name = "Royal Cat",
                    BreweryId = 35,
                    AlcoholByVolume = 6.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 287,
                    Name = "Shumensko Kolektsiya Na Pivovarite Belgiyski Stil",
                    BreweryId = 36,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 288,
                    Name = "Shumensko Tumno",
                    BreweryId = 36,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 8
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 289,
                    Name = "Shumensko Cherveno",
                    BreweryId = 36,
                    AlcoholByVolume = 5.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 290,
                    Name = "Shumnesko Kolektsiya na Pivovarite Cheshki Stil",
                    BreweryId = 36,
                    AlcoholByVolume = 5.4,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 291,
                    Name = "Shumensko",
                    BreweryId = 36,
                    AlcoholByVolume = 5.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 292,
                    Name = "Shumensko Premium",
                    BreweryId = 36,
                    AlcoholByVolume = 4.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 293,
                    Name = "Shumensko Svetlo Pivo",
                    BreweryId = 36,
                    AlcoholByVolume = 4.3,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 294,
                    Name = "Trima I Dvama CHIPA",
                    BreweryId = 37,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 295,
                    Name = "Trima I Dvama Mashin' Pumpkins",
                    BreweryId = 37,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 296,
                    Name = "Trima I Dvama Bloody Muddy",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 297,
                    Name = "Trima I Dvama Ginger Sucker Happy Ginger Ale",
                    BreweryId = 37,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 298,
                    Name = "Trima I Dvama Janka",
                    BreweryId = 37,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 299,
                    Name = "Trima I Dvama Smoking Hot",
                    BreweryId = 37,
                    AlcoholByVolume = 5.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 300,
                    Name = "Trima I Dvama Ancient Meridian",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 301,
                    Name = "Trima I Dvama Unlackee",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 7
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 302,
                    Name = "Trima I Dvama Chai Malko",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 303,
                    Name = "Trima I Dvama Chisto I Prosto",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 2
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 304,
                    Name = "Trima I Dvama Black Head Stout",
                    BreweryId = 37,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 305,
                    Name = "White Stork Tropikalia IPA",
                    BreweryId = 38,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 306,
                    Name = "White Stork 1908 Stout",
                    BreweryId = 38,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 307,
                    Name = "White Stork White Stout",
                    BreweryId = 38,
                    AlcoholByVolume = 9.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 308,
                    Name = "White Stork Boys Don't Cry-o",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 1
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 309,
                    Name = "White Stork Cosmic Debris",
                    BreweryId = 38,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 310,
                    Name = "White Stork Pushing The Limets",
                    BreweryId = 38,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 311,
                    Name = "White Stork Rai",
                    BreweryId = 38,
                    AlcoholByVolume = 3.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 312,
                    Name = "White Stork Original",
                    BreweryId = 38,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 313,
                    Name = "White Stork Dark Side",
                    BreweryId = 38,
                    AlcoholByVolume = 6.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 10
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 314,
                    Name = "White Stork Sofiiski Weisse",
                    BreweryId = 38,
                    AlcoholByVolume = 3.6,
                    CreatedOn = DateTime.Now,
                    TypeId = 3
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 315,
                    Name = "White Stork Mutants",
                    BreweryId = 38,
                    AlcoholByVolume = 9.1,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 316,
                    Name = "White Stork BOOGIEon by Ramsey Hercules",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 317,
                    Name = "White Stork Hop Along",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 318,
                    Name = "White Stork Into The Galaxy",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 319,
                    Name = "White Stork Just a Pilsner",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 320,
                    Name = "White Stork Tropikalia V2.0",
                    BreweryId = 38,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 321,
                    Name = "White Stork Take Me Somewhere Nice",
                    BreweryId = 38,
                    AlcoholByVolume = 7.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 322,
                    Name = "White Stork Dry Hopped House Pilsner",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 323,
                    Name = "White Stork Kinky Afro",
                    BreweryId = 38,
                    AlcoholByVolume = 4.2,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 324,
                    Name = "White Stork Borderless",
                    BreweryId = 38,
                    AlcoholByVolume = 5.7,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 325,
                    Name = "White Stork Intergalactic DIPA DDH",
                    BreweryId = 38,
                    AlcoholByVolume = 10.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 326,
                    Name = "White Stork Summer",
                    BreweryId = 38,
                    AlcoholByVolume = 5.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 327,
                    Name = "Zlatna Varna Amber",
                    BreweryId = 39,
                    AlcoholByVolume = 5.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 6
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 328,
                    Name = "Zlatna Varna Pilsner",
                    BreweryId = 38,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 11
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 329,
                    Name = "G-n Xops Coconut Milk Porter",
                    BreweryId = 40,
                    AlcoholByVolume = 6.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 9
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 330,
                    Name = "G-n Xops NEIPA V2.0",
                    BreweryId = 40,
                    AlcoholByVolume = 6.0,
                    CreatedOn = DateTime.Now,
                    TypeId = 5
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 331,
                    Name = "G-n Xops Pale Ale V2.0",
                    BreweryId = 40,
                    AlcoholByVolume = 4.9,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });
            modelBuilder.Entity<Beer>().HasData(
                new Beer
                {
                    Id = 332,
                    Name = "G-n Xops",
                    BreweryId = 40,
                    AlcoholByVolume = 4.5,
                    CreatedOn = DateTime.Now,
                    TypeId = 4
                });


            //SEED ALL USER ROLES

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    RoleName = "Admin"
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 2,
                    RoleName = "User"
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 3,
                    RoleName = "Guest"
                });

            //SEED ALL USERS

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreatedOn = DateTime.Now,
                    UserName = "Pesho",
                    Password = "NaPeshoParolata",
                    Email = "Pesho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    CreatedOn = DateTime.Now,
                    UserName = "Gosho",
                    Password = "NaGoshoParolata",
                    Email = "Gosho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 3,
                    CreatedOn = DateTime.Now,
                    UserName = "Tosho",
                    Password = "NaToshoParolata",
                    Email = "Tosho@biri.com",
                    RoleId = 2
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 4,
                    CreatedOn = DateTime.Now,
                    UserName = "Slavcho",
                    Password = "NaSlavchoParolata",
                    Email = "Slavcho@biri.com",
                    RoleId = 2
                });

            //SEED ALL REVIEWS

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    AuthorId = 1,
                    TargetBeerId = 1,
                    Name = "Na Pesho Review-to",
                    Text = "Mnoo dobra bira brat",
                    Rating = 10,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 2,
                    AuthorId = 2,
                    TargetBeerId = 3,
                    Name = "Na Gosho Review-to",
                    Text = "Evalata Pesho mnoo dobra bira",
                    Rating = 7,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 3,
                    AuthorId = 3,
                    TargetBeerId = 2,
                    Name = "Na Tosho Review-to",
                    Text = "Toz Pesho mnoo hubavi gi prai",
                    Rating = 8,
                    CreatedOn = DateTime.Now
                });
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 4,
                    AuthorId = 4,
                    TargetBeerId = 1,
                    Name = "Kaiser nomer edno",
                    Text = "Bira ot butilka ne bqh pil do sq",
                    Rating = 10,
                    CreatedOn = DateTime.Now
                });

            //SEED WISHLIST BEERS

            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 1,
                    BeerId = 1
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 1,
                    BeerId = 2
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 1,
                    BeerId = 3
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 2,
                    BeerId = 1
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 2,
                    BeerId = 2
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 2,
                    BeerId = 4
                });
            modelBuilder.Entity<WishlistBeer>().HasData(
                new WishlistBeer
                {
                    UserId = 3,
                    BeerId = 4
                });

            //SEED BEERS DRANK

            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 1,
                    BeerId = 1
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 1,
                    BeerId = 2
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 1,
                    BeerId = 3
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 1,
                    BeerId = 4
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 2,
                    BeerId = 1
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 2,
                    BeerId = 3
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 2,
                    BeerId = 4
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 3,
                    BeerId = 1
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 3,
                    BeerId = 2
                });
            modelBuilder.Entity<BeerDrank>().HasData(
                new BeerDrank
                {
                    UserId = 3,
                    BeerId = 4
                });
        }
    }
}

