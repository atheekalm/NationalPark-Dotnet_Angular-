using System.Collections.Generic;
using AutoMapper;
using Dotnet_WebAPI.Models;
using Dotnet_WebAPI.Models.Dtos;
using Dotnet_WebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NationalParkController : ControllerBase
    {
        private readonly INationalparkRepo _NationalparkRepo;
        private readonly IMapper _Mapper;
        public NationalParkController(INationalparkRepo YalaRepo, IMapper Mapper)
        {
            _Mapper = Mapper;
            _NationalparkRepo = YalaRepo;

        }


        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var result = _NationalparkRepo.GetNationalParks();
            // var results = new List<YalaDtos>();
            // foreach (var item in result)
            // {
            //     results.Add(_Mapper.Map<YalaDtos>(item));
            // }
            // return Ok(results);
            var Returnresult = _Mapper.Map<IEnumerable<NationalParkDtos>>(result);
            //var objDto = new NationalParkDto()
            //{
            //    Created = obj.Created,
            //    Id = obj.Id,
            //    Name = obj.Name,
            //    State = obj.State,
            //};
            return Ok(Returnresult);


        }
        [HttpGet("{id}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int id)
        {
            var result = _NationalparkRepo.GetNationalPark(id);
            if (result == null)
                return NotFound();
            var response = _Mapper.Map<NationalParkDtos>(result);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreatePark(NationalParkDtos NationalParkDto)
        {
            if (NationalParkDto == null)
                return BadRequest();

            if (_NationalparkRepo.NationalParkExists(NationalParkDto.Name))
                return StatusCode(404, "The Name Already Taken");

            var dto = _Mapper.Map<NationalPark>(NationalParkDto);
            if (!_NationalparkRepo.CreateNationalPark(dto))
                return BadRequest();

            return CreatedAtRoute("GetNationalPark", new { id = dto.Id }, NationalParkDto);
        }
        [HttpPatch("{id}", Name = "UpdateNationalPark")]
        public IActionResult UpdatePark(int id, NationalParkDtos NationalParkDto)
        {
            if(NationalParkDto==null || id!=NationalParkDto.Id)
                return BadRequest();
            if(_NationalparkRepo.NationalParkExists(NationalParkDto.Name))
                return BadRequest("The Name Already taken");
            
             var dto = _Mapper.Map<NationalPark>(NationalParkDto);
            if (!_NationalparkRepo.UpdateNationalPark(dto))
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeletePark")]
        public IActionResult DeletePark(int id)
        {
            if(!_NationalparkRepo.NationalParkExists(id))
                return BadRequest("No Park Found");
            var park = _NationalparkRepo.GetNationalPark(id);
            
            if (!_NationalparkRepo.DeleteNationalPark(park))
                return BadRequest("Cant Response");

            return NoContent();
        }
    }
}