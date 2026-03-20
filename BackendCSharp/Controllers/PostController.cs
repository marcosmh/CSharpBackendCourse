
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendCSharp.Services;
using BackendCSharp.DTOs;


namespace BackendCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        IPostService _titlesService;

        public PostController(IPostService titlesService)
        {
            _titlesService = titlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() =>
            await _titlesService.Get();



    }
}

