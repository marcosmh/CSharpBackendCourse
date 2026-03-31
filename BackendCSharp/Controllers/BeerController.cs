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

        private IValidator<BeerInsertDTO> _beerInsertValidator;

        private IValidator<BeerUpdateDTO> _beerUpdateValidator;

        private ICommonService<BeerDTO,BeerInsertDTO,BeerUpdateDTO> _beerService;


        public BeerController(
            IValidator<BeerInsertDTO> beerInsertValidator,
            IValidator<BeerUpdateDTO> beerUpdateValidator,
           [FromKeyedServices("beerService")] ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO> beerService)
        {
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
        public async Task<ActionResult<BeerDTO>> Add(BeerInsertDTO dto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(dto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if(!_beerService.Validate(dto))
            {
                return BadRequest(_beerService.Errors);
            }

            var beerDto = await _beerService.Add(dto);
            
            return CreatedAtAction(nameof(GetById), new { id = beerDto.Id }, beerDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDTO>> Update(int id, BeerUpdateDTO dto)
        {
            var validationResult = await _beerUpdateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_beerService.Validate(dto))
            {
                return BadRequest(_beerService.Errors);
            }

            var beerDto = await _beerService.Update(id, dto);

            return beerDto == null ? NotFound() : Ok(beerDto);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDTO>> Delete(int id)
        {
            var beerDto = await _beerService.Delete(id);

            return beerDto == null ? NotFound() : Ok(beerDto);
        }


    }
}

