using System;
using BackendCSharp.DTOs;
using BackendCSharp.Models;
using BackendCSharp.Services;
using Microsoft.EntityFrameworkCore;


namespace BackendCSharp.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<BeerDTO>> Get() =>
            await _context.Beers.Select(b => new BeerDTO
            {
                Id = b.BeerID,
                Name = b.Name,
                Alcohol = b.Alcohol,
                BrandID = b.BrandID
            }).ToListAsync();



        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if(beer != null)
            {
                var beerDto = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID
                };
                return beerDto;
            }
            return null;
        }

        public async Task<BeerInsertDTO> Add(BeerInsertDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<BeerDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}

