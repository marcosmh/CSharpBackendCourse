using System;
using BackendCSharp.DTOs;


namespace BackendCSharp.Services
{
	public interface IBeerService
	{
        Task<IEnumerable<BeerDTO>> Get();

        Task<BeerDTO> GetById(int id);

        Task<BeerDTO> Add(BeerInsertDTO dto);

        Task<BeerDTO> Update(int id, BeerUpdateDTO dto);

        Task<BeerDTO> Delete(int id);
    }
}

