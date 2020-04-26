﻿using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UnitTests.UserServicesTests
{
    [TestClass]
    public class GetBeersDrank_Should
    {
        [TestMethod]
        public void ReturnCorrectDrankList_WhenParamsAreValid()
        {
            var options = Utils.GetOptions(nameof(ReturnCorrectDrankList_WhenParamsAreValid));
            var user1 = TestsModelsSeeder.Seed_User();
            var beer1 = TestsModelsSeeder.Seed_Beer();
            var beer2 = TestsModelsSeeder.Seed_Beer_v2();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user1);
                arrangeContext.Beers.Add(beer1);
                arrangeContext.Beers.Add(beer2);
                arrangeContext.SaveChanges();
                arrangeContext.Users.FirstOrDefault().BeersDrank = new HashSet<BeerDrank>
                {
                    new BeerDrank
                    {
                        UserId = 1,
                        BeerId = 1,
                    },
                    new BeerDrank
                    {
                        UserId = 1,
                        BeerId = 2,
                    }
                };
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                var result = sut.GetBeersDrank(1).ToList();
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(2, result[0].Id);
                Assert.AreEqual(1, result[1].Id);
            }
        }
        [TestMethod]
        public void Throw_WhenIdIsInvalid()
        {
            var options = Utils.GetOptions(nameof(Throw_WhenIdIsInvalid));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserServices(assertContext);
                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBeersDrank(1));
            }
        }
    }
}