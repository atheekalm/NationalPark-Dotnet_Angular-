using System.ComponentModel.DataAnnotations;
using Dotnet_WebAPI.Models.Dtos;
using static Models.Trails;

namespace Models.Dtos
{
    public class TrailsDtos
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public DifficultyTypes Types { get; set; }
        public NationalParkDtos Yala { get; set; }
        public int YalaId { get; set; }
    }
}