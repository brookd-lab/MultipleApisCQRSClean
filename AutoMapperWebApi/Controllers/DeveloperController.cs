using AutoMapper;
using AutoMapperWebApi.Data.DTOs;
using AutoMapperWebApi.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IMapper _mapper;
        public DeveloperController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Developer developer)
        {
            var developerDtoMapped = _mapper.Map<DeveloperDTO>(developer);
            return Ok(developerDtoMapped);
        }
    }
}
