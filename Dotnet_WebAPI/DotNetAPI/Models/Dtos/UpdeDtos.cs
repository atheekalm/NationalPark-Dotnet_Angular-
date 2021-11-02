using System.ComponentModel.DataAnnotations;
using static Models.Trails;

namespace Models.Dtos
{
    public class UpdeDtos
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public DifficultyTypes Types { get; set; }
        public int NationalParkId { get; set; }
    }
}