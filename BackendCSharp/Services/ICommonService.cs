using System;
using BackendCSharp.DTOs;

namespace BackendCSharp.Services
{
	public interface ICommonService<T, TI, TU>
	{
        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<T> Add(TI dto);

        Task<T> Update(int id, TU dto);

        Task<T> Delete(int id);
    }
}

