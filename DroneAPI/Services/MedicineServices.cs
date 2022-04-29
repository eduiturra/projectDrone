using System;
using AutoMapper;
using DroneAPI.Dtos;
using DroneAPI.Model;
using System.Threading.Tasks;
using DroneAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
namespace DroneAPI.Services
{
    public class MedicineServices : IMedicineServices
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public MedicineServices(IMapper mapper, IMedicineRepository medicineRepository, IDroneRepository droneRepository) {
          _medicineRepository = medicineRepository;
          _droneRepository = droneRepository;
          _mapper = mapper;
        }

        public async Task<DroneLoadMedicinesDTO> SaveMedicine(DroneLoadMedicinesDTO dto){
            Drone drone = await _droneRepository.Get(dto.DroneId);
            if(drone != null && drone.Medicines.ToList().Count() != 0){
                decimal weightTotal = 0;
                foreach (var item in drone.Medicines.ToList())
                {
                    weightTotal += item.Weight;
                }
                weightTotal += dto.Weight;
                if(System.Math.Round(weightTotal) > System.Math.Round(drone.Capacity)) {
                    throw new Exception("El peso de los medicamentos sobrepasan la capacidad del dron");
                }
            }

            Medicine model = _mapper.Map<Medicine>(dto);
            await _medicineRepository.Save(model);
            return dto;
        }

    }
}