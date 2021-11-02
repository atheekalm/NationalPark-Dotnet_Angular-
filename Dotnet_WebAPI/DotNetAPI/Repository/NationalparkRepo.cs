using System.Collections.Generic;
using System.Linq;
using Dotnet_WebAPI.Data;
using Dotnet_WebAPI.Models;
using Dotnet_WebAPI.Repository.IRepository;

namespace Dotnet_WebAPI.Repository
{
    public class NationalparkRepo : INationalparkRepo
    {
        private readonly DataContext _context;
        public NationalparkRepo(DataContext context)
        {
            _context = context;
        }
        public bool CreateNationalPark(NationalPark NationalPark)
        {
            _context.NationalParks.Add(NationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark NationalPark)
        {
            _context.NationalParks.Remove(NationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int parkId)
        {
            return _context.NationalParks.FirstOrDefault(id => id.Id == parkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.OrderBy(o=>o.Name).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool NationalParkExists(string name)
        {
            return _context.NationalParks.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool NationalParkExists(int Id)
        {
            return _context.NationalParks.Any(id => id.Id == Id);
        }

        public bool UpdateNationalPark(NationalPark NationalPark)
        {
            _context.NationalParks.Update(NationalPark);
            return Save();
        }
        

       
    }
}