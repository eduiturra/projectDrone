using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DroneAPI.Dtos;
using DroneAPI.Services;
using DroneAPI.Model;

namespace DroneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly IDroneServices _droneServices;
        private readonly ILogger<DroneController> _logger;

        public DroneController(ILogger<DroneController> logger, IDroneServices droneServices)
        {
            _logger = logger;
            _droneServices = droneServices;
        }

        [HttpPost]
        public async Task<ActionResult<Drone>> Post([FromBody] RegisterDroneDTO registerDTO)
        {
            return await _droneServices.SaveDrone(registerDTO);
        }

         [HttpGet("load")]
         public async Task<ActionResult<List<Drone>>> GetDronesLoad()
         {
            return await _droneServices.GetDronesLoad();
         }

         [HttpGet("battery/{serie}")]
         public async Task<ActionResult<DroneBatteryDTO>> GetDroneBattery(String serie)
         {
             return await _droneServices.GetDroneBattery(serie);
         }

         [HttpGet("medicine/{serie}")]
         public async Task<ActionResult<DroneWeightMedicineDTO>> GetDroneWeightMedicine(String serie)
         {
             return await _droneServices.GetDroneWeightMedicine(serie);
         }
    }
}
