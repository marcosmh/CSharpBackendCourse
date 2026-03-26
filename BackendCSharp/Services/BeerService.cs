using System;
using BackendCSharp.DTOs;
using BackendCSharp.Models;
using BackendCSharp.Repository;
using BackendCSharp.Services;
using BackendCSharp.Validators;
using Microsoft.EntityFrameworkCore;


namespace BackendCSharp.Services
{
    public class BeerService : ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO>
    {

        private IRepository<Beer> _beerRepository;



        public BeerService(IRepository<Beer> beerRepository)
        {
            _beerRepository = beerRepository;
        }


        public async Task<IEnumerable<BeerDTO>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select( b => new BeerDTO()
            {
                Id = b.BeerID,
                Name = b.Name,
                BrandID = b.BrandID,
                Alcohol = b.Alcohol

            });
        }

           
        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

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

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

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
            var beer = await _beerRepository.GetById(id);
                

            if(beer != null)
            {
                beer.Name = dto.Name;
                beer.Alcohol = dto.Alcohol;
                beer.BrandID = dto.BrandId;
                
                _beerRepository.Update(beer);
                await _beerRepository.Save();

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

            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = new BeerDTO
                {
                    Id = beer.BeerID,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandID = beer.BrandID

                };

                _beerRepository.Delete(beer);
                await _beerRepository.Save();

                return beerDto;
            }

            return null;

        }

      
    }
}

