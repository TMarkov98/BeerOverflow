using BeerOverflow.Database;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.BeerServicesTests
{
    [TestClass]
    public class GetAllBeers_Should
    {
        [TestMethod]
        public void ReturnCurrectBeers_When_ParamsValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCurrectBeers_When_ParamsValid));

            var beer = TestsModelsSeeder.Seed_Beer();
            var beer_2 = TestsModelsSeeder.Seed_Beer_v2();
            var beer_3 = TestsModelsSeeder.Seed_Beer_v3();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Beers.Add(beer);
                arrangeContext.Beers.Add(beer_2);
                arrangeContext.Beers.Add(beer_3);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerServices(assertContext);
                var result = sut.GetAllBeers().ToList();
                Assert.AreEqual(3, result.Count);
                Assert.AreEqual(beer.Name, result[0].Name);
                Assert.AreEqual(beer_2.Name, result[1].Name);
                Assert.AreEqual(beer_3.Name, result[2].Name);
            }
        }
    }
}
//public ICollection<BeerDTO> GetAllBeers()
//{
//    var beers = _context.Beers
//        .Select(x => new BeerDTO
//        {
//            Id = x.Id,
//            Name = x.Name,
//            BeerType = x.Type.Name,
//            Brewery = x.Brewery.Name,
//            BreweryCountry = x.Brewery.Country.Name,
//            AlcoholByVolume = x.AlcoholByVolume,
//        })
//        .ToList();

//    return beers;
//}