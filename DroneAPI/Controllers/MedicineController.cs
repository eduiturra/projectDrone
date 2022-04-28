using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DroneAPI.Dtos;

namespace DroneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {

        private readonly ILogger<MedicineController> _logger;

        public MedicineController(ILogger<MedicineController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public RegisterDroneDTO Post(DroneLoadMedicinesDTO medicineDTO)
        {
            return new RegisterDroneDTO();
        }
    }
}
