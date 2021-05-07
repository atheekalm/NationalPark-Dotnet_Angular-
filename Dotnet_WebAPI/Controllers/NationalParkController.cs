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
        private readonly INationalparkRepo _YalaRepo;
        private readonly IMapper _Mapper;
        public NationalParkController(INationalparkRepo YalaRepo, IMapper Mapper)
        {
            _Mapper = Mapper;
            _YalaRepo = YalaRepo;

        }
        ///<summary>
        /// Get List Of Parks
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var fromRepo = _YalaRepo.Getparks();
            // var results = new List<YalaDtos>();
            // foreach (var item in result)
            // {
            //     results.Add(_Mapper.Map<YalaDtos>(item));
            // }
            // return Ok(results);
            var toReturn = _Mapper.Map<IEnumerable<NationalParkDtos>>(fromRepo);
            //var objDto = new NationalParkDto()
            //{
            //    Created = obj.Created,
            //    Id = obj.Id,
            //    Name = obj.Name,
            //    State = obj.State,
            //};
            return Ok(toReturn);


        }
        [HttpGet("{id}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int id)
        {
            var result = _YalaRepo.Getpark(id);
            if (result == null)
                return NotFound();
            var response = _Mapper.Map<NationalParkDtos>(result);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreatePark(NationalParkDtos yalaDtos)
        {
            if (yalaDtos == null)
                return BadRequest();

            if (_YalaRepo.theParkExists(yalaDtos.Name))
                return StatusCode(404, "The Name Already Taken");

            var dto = _Mapper.Map<NationalPark>(yalaDtos);
            if (!_YalaRepo.CreatePark(dto))
                return BadRequest();

            return CreatedAtRoute("GetNationalPark", new { id = dto.Id }, dto);
        }
        [HttpPatch("{id}", Name = "UpdateNationalPark")]
        public IActionResult UpdatePark(int id, NationalParkDtos yalaDtos)
        {
            if(yalaDtos==null || id!=yalaDtos.Id)
                return BadRequest();
            if(_YalaRepo.theParkExists(yalaDtos.Name))
                return BadRequest("The Name Already taken");
            
             var dto = _Mapper.Map<NationalPark>(yalaDtos);
            if (!_YalaRepo.UpdatePark(dto))
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeletePark")]
        public IActionResult DeletePark(int id)
        {
            if(!_YalaRepo.theParkExists(id))
                return BadRequest("No Park Found");
            var park = _YalaRepo.Getpark(id);
            
            if (!_YalaRepo.DeletePark(park))
                return BadRequest("Cant Response");

            return NoContent();
        }
    }
}