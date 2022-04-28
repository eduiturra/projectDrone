using System;
using System.Threading.Tasks;
using DroneAPI.Model;

namespace DroneAPI.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone> Save(Drone model);
        Task<Drone> Get(String numSeries);
    }
}