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
            _context = context;    }
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

        public Trails GetTrail(int parkId)
        {
            return _context.Trails.Include(c=>c.NationalPark).FirstOrDefault(id => id.Id == parkId);
        }

        public ICollection<Trails> GetTrailPark(int id)
        {
            return _context.Trails.Include(c => c.Yala).Where(c => c.YalaId == id).ToList();
        }

        public ICollection<Trails> GetTrails()
        {
            return _context.Trails.Include(c => c.Yala).OrderBy(o => o.Name).ToList();
        }

        public async Task<ICollection<Trails>> GetTrailsByNationalParkId(int id)
        {
            return await _context.Trails.Where(c => c.YalaId == id).ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool theTrailsExists(string name)
        {
            return _context.Trails.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool theTrailsExists(int Id)
        {
            return _context.Trails.Any(id => id.Id == Id);
        }

        public bool UpdateTrail(Trails Trails)
        {
            _context.Trails.Update(Trails);
            return Save();
        }
    }
}