using System.Collections;
using System.Collections.Generic;
using Dotnet_WebAPI.Models;

namespace Dotnet_WebAPI.Repository.IRepository
{
    public interface INationalparkRepo
    {
        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int NationalParkId);
        bool NationalParkExists(string name);
        bool NationalParkExists(int Id);
        bool CreateNationalPark(NationalPark NationalPark);
        bool UpdateNationalPark(NationalPark NationalPark);
        bool DeleteNationalPark(NationalPark NationalPark);
        bool Save();
    }
}