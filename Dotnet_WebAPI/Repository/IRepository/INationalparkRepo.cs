using System.Collections;
using System.Collections.Generic;
using Dotnet_WebAPI.Models;

namespace Dotnet_WebAPI.Repository.IRepository
{
    public interface INationalparkRepo
    {
        ICollection<NationalPark> Getparks();
        NationalPark Getpark(int parkId);
        bool theParkExists(string name);
        bool theParkExists(int Id);
        bool CreatePark(NationalPark yala);
        bool UpdatePark(NationalPark yala);
        bool DeletePark(NationalPark yala);
        bool Save();
    }
}