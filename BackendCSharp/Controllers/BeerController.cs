using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendCSharp.Models;
using BackendCSharp.DTOs;
using BackendCSharp.Services;
using FluentValidation;


namespace BackendCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {

        private StoreContext _context;

        private IValidator<BeerInsertDTO> _beerInsertValidator;

        private IValidator<BeerUpdateDTO> _beerUpdateValidator;

        private IBeerService _beerService;


        public BeerController(StoreContext context,
            IValidator<BeerInsertDTO> beerInsertValidator,
            IValidator<BeerUpdateDTO> beerUpdateValidator,
            IBeerService beerService)
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IEnumerable<BeerDTO>> Get() =>
            await _beerService.Get();

        
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDTO>> GetById(int id)
        {
            var beerDto = await _beerService.GetById(id);

            return beerDto == null ? NotFound() : Ok(beerDto);
        }


        [HttpPost]
        public async Task<ActionResult<BeerInsertDTO>> Add(BeerInsertDTO dto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(dto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

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


            return CreatedAtAction(nameof(GetById), new {id = beer.BeerID}, beerDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDTO>> Update(int id, BeerUpdateDTO dto)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beer = await _context.Beers.FindAsync(id);

            if(beer == null)
            {
                return NotFound();
            }

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

            return Ok(beerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDTO>> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDTO
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID

            };

            return Ok(beerDto);
        }


    }
}

