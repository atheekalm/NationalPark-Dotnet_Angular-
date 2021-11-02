using System;
using System.ComponentModel.DataAnnotations;
using Dotnet_WebAPI.Models;

namespace Models
{
    public class Trails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        public enum DifficultyTypes
        {
            Easy,
            Modarate,
            Difficult,
            Expert
        }
        public DifficultyTypes Types { get; set; }
        public NationalPark NationalPark { get; set; }
        public int NationalParkId { get; set; }
        public DateTime Created { get; set; }
    }
}
