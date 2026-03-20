using System;
using BackendCSharp.DTOs;

namespace BackendCSharp.Services
{
	public interface IPostService
	{
		public Task<IEnumerable<PostDto>> Get();
	}
}

