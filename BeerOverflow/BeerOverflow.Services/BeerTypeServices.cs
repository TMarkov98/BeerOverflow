using BeerOverflow.Database;
using BeerOverflow.Models;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var beerTypeExists = _context.BeerTypes
                .FirstOrDefault(b => b.Name == beerTypeDTO.Name);
            if (beerTypeExists != null)
            {
                throw new ArgumentException($"BeerType {beerTypeExists.Name} already exists");
            }
            _context.BeerTypes.Add(beerType);
            _context.SaveChanges();
            return beerTypeDTO;
        }

        public bool DeleteBeerType(int id)
        {
            var beerType = _context.BeerTypes
                .FirstOrDefault(bt => bt.Id == id);
            if (beerType == null || beerType.IsDeleted)
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
            var beerType = _context.BeerTypes
                .FirstOrDefault(bt => bt.Id == id);
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

            if (beerType == null)
                throw new ArgumentNullException("BeerType not found.");

            var beerTypeExists = _context.BeerTypes
                .FirstOrDefault(b => b.Name == name);
            if (beerTypeExists != null)
            {
                throw new ArgumentException($"BeerType {beerTypeExists.Name} already exists");
            }

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
