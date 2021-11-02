using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_WebAPI.Data;
using Dotnet_WebAPI.Models;
using Dotnet_WebAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Dotnet_WebAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly DataContext _context;
        public TrailRepository(DataContext context)
        {
            _context = context;
        }

        public Trails GetTrail(int parkId)
        {
            return _context.Trails.Include(c => c.NationalPark).FirstOrDefault(id => id.Id == parkId);
        }

        public ICollection<Trails> GetTrails()
        {
            return _context.Trails.Include(c => c.NationalPark).OrderBy(o => o.Name).ToList();
        }
        public bool CreateTrail(Trails Trails)
        {
            _context.Trails.Add(Trails);
            return Save();
        }

        public bool DeleteTrail(Trails Trails)
        {
            _context.Trails.Remove(Trails);
            return Save();
        }


        public bool UpdateTrail(Trails Trails)
        {
            _context.Trails.Update(Trails);
            return Save();
        }


        public async Task<ICollection<Trails>> GetTrailsInNationalPark(int nationalparkid)
        {
            return await _context.Trails.Where(c => c.NationalParkId == nationalparkid).ToListAsync();
        }

        public bool TrailsExists(string name)
        {
            return _context.Trails.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool TrailsExists(int Id)
        {
            return _context.Trails.Any(id => id.Id == Id);
        }
        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}