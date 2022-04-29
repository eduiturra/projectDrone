using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DroneAPI.Dtos;
using DroneAPI.Model;
namespace DroneAPI.Services
{
    public interface IDroneServices
    {
        Task<Drone> SaveDrone(RegisterDroneDTO dto);
        Task<List<Drone>> GetDronesLoad();
        Task<DroneBatteryDTO> GetDroneBattery(String serie);
        Task<DroneWeightMedicineDTO> GetDroneWeightMedicine(String serie);
    }
}