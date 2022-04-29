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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineServices _medicineServices;
        private readonly ILogger<MedicineController> _logger;

        public MedicineController(ILogger<MedicineController> logger, IMedicineServices medicineServices)
        {
            _logger = logger;
            _medicineServices = medicineServices;
        }

        [HttpPost]
        public async Task<ActionResult<DroneLoadMedicinesDTO>> Post(DroneLoadMedicinesDTO medicineDTO)
        {
            return await _medicineServices.SaveMedicine(medicineDTO);
        }
    }
}
