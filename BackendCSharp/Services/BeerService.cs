using System;
using BackendCSharp.DTOs;
using BackendCSharp.Models;
using BackendCSharp.Services;
using BackendCSharp.Validators;
using Microsoft.EntityFrameworkCore;


namespace BackendCSharp.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
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

        public async Task<BeerDTO> Add(BeerInsertDTO dto)
        {

            var beer = new Beer()
            {
                Name = dto.Name,
                BrandID = dto.BrandId,
                Alcohol = dto.Alcohol
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDTO
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID

            };

            return beerDto;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO dto)
        {
            var beer = await _context.Beers.FindAsync(id);

            if(beer != null)
            {
                beer.Name = dto.Name;
                beer.Alcohol = dto.Alcohol;
                beer.BrandID = beer.BrandID;
                await _context.SaveChangesAsync();

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

        public async Task<BeerDTO> Delete(int id)
        {

            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                var beerDto = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID

                };

                _context.Remove(beer);
                await _context.SaveChangesAsync();

                return beerDto;
            }

            return null;

        }

      
    }
}

