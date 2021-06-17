using Dotnet_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dotnet_WebAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<NationalPark> Yala { get; set; }
        public DbSet<Trails> Trails { get; set; }
    }
}