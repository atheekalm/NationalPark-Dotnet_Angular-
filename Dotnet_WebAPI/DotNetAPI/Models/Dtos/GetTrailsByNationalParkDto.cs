using static Models.Trails;
using System;

namespace Dotnet_WebAPI.Models.Dtos
{
    public class GetTrailsByNationalParkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public DifficultyTypes Types { get; set; }
        public NationalParkDtos Yala { get; set; }
        public int YalaId { get; set; }
        public DateTime Created { get; set; }
    }
}