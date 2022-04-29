using System;
using System.Threading.Tasks;
using DroneAPI.Model;
using System.Collections.Generic;

namespace DroneAPI.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone> Save(Drone model);
        Task<Drone> Get(String numSeries);
        Task<List<Drone>> GetByState(String state);
    }
}