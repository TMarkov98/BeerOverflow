using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class BeerTypeServices : IBeerTypeServices
    {
        private readonly BeerOverflowContext _context;
        public BeerTypeServices(BeerOverflowContext context)
        {
            this._context = context;
        }
        public IBeerTypeDTO CreateBeerType(IBeerTypeDTO beerTypeDTO)
        {
            var beerType = new BeerType
            {
                Name = beerTypeDTO.Name
            };
            _context.SaveChanges();
            return beerTypeDTO;
        }

        public bool DeleteBeerType(int id)
        {
            var beerType = _context.BeerTypes.FirstOrDefault(bt => bt.Id == id);
            if (beerType == null)
                return false;
            beerType.IsDeleted = true;
            beerType.DeletedOn = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public ICollection<BeerTypeDTO> GetAllBeerTypes()
        {
            var beerTypes = _context.BeerTypes
                .Select(bt => new BeerTypeDTO
                {
                    Id = bt.Id,
                    Name = bt.Name
                }).ToList();
            return beerTypes;
        }

        public BeerTypeDTO GetBeerType(int id)
        {
            var beerType = _context.BeerTypes.FirstOrDefault(bt => bt.Id == id);
            if (beerType == null)
                throw new ArgumentNullException("BeerType not found.");
            var beerTypeDTO = new BeerTypeDTO
            {
                Id = beerType.Id,
                Name = beerType.Name
            };
            return beerTypeDTO;
        }

        public BeerTypeDTO UpdateBeerType(int id, string name)
        {
            var beerType = _context.BeerTypes
                .Where(r => r.IsDeleted == false)
                .FirstOrDefault(r => r.Id == id);
            beerType.Name = name;
            
            var beerTypeDTO = new BeerTypeDTO
            {
                Name = beerType.Name
            };
            _context.SaveChanges();
            return beerTypeDTO;
        }
    }
}
