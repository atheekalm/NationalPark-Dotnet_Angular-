using System.Collections.Generic;
using System.Threading.Tasks;
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
        public IActionResult GetTrails()
        {
            var fromRepo = _trailRepository.GetTrails();
            var toReturn = _Mapper.Map<IEnumerable<TrailsDtos>>(fromRepo);
            return Ok(toReturn);
        }
        // [HttpGet("{id}", Name = "GetTrails")]
        // public IActionResult GetTrails(int id)
        // {
        //     var result = _trailRepository.GetTrail(id);
        //     if (result == null)
        //         return NotFound();
        //     var response = _Mapper.Map<TrailsDtos>(result);
        //     return Ok(response);
        // }

        [HttpGet("{id}",Name ="TrailsByNationalPark")]
        public async Task<ActionResult<TrailsDtos>> GetTrailsInPark(int id)
        {
            var trailsResult = await _trailRepository.GetTrailsInNationalPark(id);
            return Ok(_Mapper.Map<IEnumerable<TrailsDtos>>(trailsResult));
        }

        [HttpPost]
        public IActionResult CreateTrails(UpdeDtos updeDtos)
        {
            if (updeDtos == null)
                return BadRequest();

            if (_trailRepository.TrailsExists(updeDtos.Name))
                return StatusCode(404, "The Name Already Taken");

            var dto = _Mapper.Map<Trails>(updeDtos);
            if (!_trailRepository.CreateTrail(dto))
                return BadRequest();

            return CreatedAtRoute("GetTrails", new { id = dto.Id }, updeDtos);
        }
        [HttpPatch("{id}", Name = "UpdateTrail")]
        public IActionResult UpdateTrail(int id, UpdeDtos updeDtos)
        {
            if (updeDtos == null || id != updeDtos.Id)
                return BadRequest();
            if (_trailRepository.TrailsExists(updeDtos.Name))
                return BadRequest("The Name Already taken");

            var dto = _Mapper.Map<Trails>(updeDtos);
            if (!_trailRepository.UpdateTrail(dto))
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteTrail")]
        public IActionResult DeleteTrail(int id)
        {
            if (!_trailRepository.TrailsExists(id))
                return BadRequest("No Park Found");
            var trail = _trailRepository.GetTrail(id);

            if (!_trailRepository.DeleteTrail(trail))
                return BadRequest("Cant Response");

            return NoContent();
        }
    }
}