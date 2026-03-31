using System;
using AutoMapper;
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

        private IMapper _mapper;

        public List<string> Errors { get; }


        public BeerService(IRepository<Beer> beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }


        public async Task<IEnumerable<BeerDTO>> Get()
        {
            var beers = await _beerRepository.Get();

            return beers.Select( b => _mapper.Map<BeerDTO>(b));
        }

           
        public async Task<BeerDTO> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if(beer != null)
            {
                var beerDto = _mapper.Map<BeerDTO>(beer);

                return beerDto;
            }
            return null;
        }

        public async Task<BeerDTO> Add(BeerInsertDTO dto)
        {

            var beer = _mapper.Map<Beer>(dto);

            await _beerRepository.Add(beer);
            await _beerRepository.Save();

            var beerDto = _mapper.Map<BeerDTO>(beer);

            return beerDto;
        }

        public async Task<BeerDTO> Update(int id, BeerUpdateDTO dto)
        {
            var beer = await _beerRepository.GetById(id);
                

            if(beer != null)
            {
                beer = _mapper.Map<BeerUpdateDTO, Beer>(dto, beer);
                
                _beerRepository.Update(beer);
                await _beerRepository.Save();

                var beerDto = _mapper.Map<BeerDTO>(beer);

                return beerDto;
            }

            return null;
        }

        public async Task<BeerDTO> Delete(int id)
        {

            var beer = await _beerRepository.GetById(id);

            if (beer != null)
            {
                var beerDto = _mapper.Map<BeerDTO>(beer);

                _beerRepository.Delete(beer);
                await _beerRepository.Save();

                return beerDto;
            }

            return null;

        }

        public bool Validate(BeerInsertDTO dto)
        {
            if(_beerRepository.Search( b => b.Name == dto.Name ).Count() > 0 )
            {
                Errors.Add("No puede existir una cerveza con el mismo nombre ya existente.");
                return false;
            }

            return true;
        }

        public bool Validate(BeerUpdateDTO dto)
        {
            if (_beerRepository.Search(b => b.Name == dto.Name
                && dto.Id != b.BeerID ).Count() > 0)
            {
                Errors.Add("No puede existir una cerveza con el mismo nombre ya existente.");
                return false;
            }

            return true;
        }

        
    }
}

