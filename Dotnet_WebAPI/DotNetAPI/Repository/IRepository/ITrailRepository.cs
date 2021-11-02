using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Dotnet_WebAPI.Repository.IRepository
{
    public interface ITrailRepository
    {
        ICollection<Trails> GetTrails();
        //Trails GetTrailPark(int id);
        Task<ICollection<Trails>> GetTrailsInNationalPark(int nationalparkid);
        Trails GetTrail(int parkId);
        bool TrailsExists(string name);
        bool TrailsExists(int Id);
        bool CreateTrail(Trails Trails);
        bool UpdateTrail(Trails Trails);
        bool DeleteTrail(Trails Trails);
        bool Save();
    }
}