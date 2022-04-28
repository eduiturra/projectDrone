using System;
using System.Threading.Tasks;
using DroneAPI.Model;

namespace DroneAPI.Repositories
{
    public interface IMedicineRepository
    {
         Task<Medicine> Get(Guid numSeries);
    }
}