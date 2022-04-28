using System;
using System.Threading.Tasks;
using DroneAPI.Dtos;
using DroneAPI.Model;
namespace DroneAPI.Services
{
    public interface IDroneServices
    {
        Task<Drone> SaveDrone(RegisterDroneDTO dto);
    }
}