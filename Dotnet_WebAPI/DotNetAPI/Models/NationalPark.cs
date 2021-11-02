using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Dotnet_WebAPI.Models
{
    public class NationalPark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public byte[] Pictures { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
        public ICollection<Trails> Trails { get; set; }
    }
}