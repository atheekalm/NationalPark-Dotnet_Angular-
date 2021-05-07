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
        public bool CreatePark(NationalPark yala)
        {
            _context.Yala.Add(yala);
            return Save();
        }

        public bool DeletePark(NationalPark yala)
        {
            _context.Yala.Remove(yala);
            return Save();
        }

        public NationalPark Getpark(int parkId)
        {
            return _context.Yala.FirstOrDefault(id => id.Id == parkId);
        }

        public ICollection<NationalPark> Getparks()
        {
            return _context.Yala.OrderBy(o=>o.Name).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool theParkExists(string name)
        {
            return _context.Yala.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool theParkExists(int Id)
        {
            return _context.Yala.Any(id => id.Id == Id);
        }

        public bool UpdatePark(NationalPark yala)
        {
            _context.Yala.Update(yala);
            return Save();
        }
    }
}