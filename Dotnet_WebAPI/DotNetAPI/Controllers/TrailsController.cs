using System.Collections.Generic;
using AutoMapper;
using Dotnet_WebAPI.Models;
using Dotnet_WebAPI.Models.Dtos;
using Dotnet_WebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;

namespace Dotnet_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _Mapper;
        public TrailsController(ITrailRepository trailRepository, IMapper Mapper)
        {
            _Mapper = Mapper;
            _trailRepository = trailRepository;

        }


        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var fromRepo = _trailRepository.GetTrails();
            // var results = new List<YalaDtos>();
            // foreach (var item in result)
            // {
            //     results.Add(_Mapper.Map<YalaDtos>(item));
            // }  
            // return Ok(results);
            var toReturn = _Mapper.Map<IEnumerable<TrailsDtos>>(fromRepo);
            return Ok(toReturn);


        }
        [HttpGet("{id}", Name = "GetTrails")]
        public IActionResult GetTrails(int id)
        {
            var result = _trailRepository.GetTrail(id);
            if (result == null)
                return NotFound();
            var response = _Mapper.Map<TrailsDtos>(result);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateTrails(UpdeDtos updeDtos)
        {
            if (updeDtos == null)
                return BadRequest();

            if (_trailRepository.theTrailsExists(updeDtos.Name))
                return StatusCode(404, "The Name Already Taken");

            var dto = _Mapper.Map<Trails>(updeDtos);
            if (!_trailRepository.CreateTrail(dto))
                return BadRequest();

            return CreatedAtRoute("GetTrails", new { id = dto.Id }, dto);
        }
        [HttpPatch("{id}", Name = "UpdateTrail")]
        public IActionResult UpdateTrail(int id, UpdeDtos updeDtos)
        {
            if (updeDtos == null || id != updeDtos.Id)
                return BadRequest();
            if (_trailRepository.theTrailsExists(updeDtos.Name))
                return BadRequest("The Name Already taken");

            var dto = _Mapper.Map<Trails>(updeDtos);
            if (!_trailRepository.UpdateTrail(dto))
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteTrail")]
        public IActionResult DeleteTrail(int id)
        {
            if (!_trailRepository.theTrailsExists(id))
                return BadRequest("No Park Found");
            var trail = _trailRepository.GetTrail(id);

            if (!_trailRepository.DeleteTrail(trail))
                return BadRequest("Cant Response");

            return NoContent();
        }
    }
}