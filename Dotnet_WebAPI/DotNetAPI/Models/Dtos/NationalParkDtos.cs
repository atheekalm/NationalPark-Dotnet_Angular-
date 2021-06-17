using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_WebAPI.Models.Dtos
{
    public class NationalParkDtos
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public byte[] Pictures { get; set; } 
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
