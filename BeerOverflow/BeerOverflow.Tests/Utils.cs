using BeerOverflow.Database;
using Microsoft.EntityFrameworkCore;

namespace BeerOverflow.Tests
{
    public class Utils
    {
        public static DbContextOptions<BeerOverflowContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<BeerOverflowContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
