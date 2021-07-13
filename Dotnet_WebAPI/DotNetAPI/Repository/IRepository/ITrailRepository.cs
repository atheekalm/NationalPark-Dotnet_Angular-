using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet_WebAPI.Models;
using Models;

namespace Dotnet_WebAPI.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trails> GetTrails();
        Trails GetTrailPark(int id);
        Trails GetTrail(int parkId);
        bool theTrailsExists(string name);
        bool theTrailsExists(int Id);
        bool CreateTrail(Trails Trails);
        bool UpdateTrail(Trails Trails);
        bool DeleteTrail(Trails Trails);
        bool Save();
        Task<ICollection<Trails>> GetTrailsByNationalParkId(int nationalparkid);
    }
}