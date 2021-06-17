using System.Collections.Generic;
using AutoMapper;
using Dotnet_WebAPI.Models.Dtos;
using Dotnet_WebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace Dotnet_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : ControllerBase
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;
        public HomeController(ITrailRepository trailRepository, IMapper Mapper)
        {
            _mapper = Mapper;
            _trailRepository = trailRepository;

        }

        [HttpGet("{id}")]
        public IActionResult GetTrailsByNationalParkId(int id)
        {
            var result = _trailRepository.GetTrailsByNationalParkId(id);
            // var response = _mapper.Map<IEnumerable<GetTrailsByNationalParkDto>>(result);
            // return Ok(response);
            return Ok(result);
        }

       

    }
}