using System;
using AutoMapper;
using System.Collections.Generic;
using DroneAPI.Dtos;
using DroneAPI.Model;
using System.Threading.Tasks;
using DroneAPI.Repositories;
using System.Linq;

namespace DroneAPI.Services
{
    public class DroneServices : IDroneServices
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public DroneServices(IMapper mapper, IDroneRepository droneRepository, IMedicineRepository medicineRepository) {
          _droneRepository = droneRepository;
          _mapper = mapper;
          _medicineRepository = medicineRepository;
        }

        public async Task<Drone> SaveDrone(RegisterDroneDTO dto){
            if(dto.State == "CARGANDO" && System.Math.Round(dto.Capacity) < 25) {
                throw new Exception("El dron de estado CARGANDO no puede tener una batería por debajo de 25%");
            }
            Drone model = _mapper.Map<Drone>(dto);
            await _droneRepository.Save(model);
            return model;
        }

         public async Task<List<Drone>> GetDronesLoad(){
            return await _droneRepository.GetByState("CARGADO");
        }

        public async Task<DroneBatteryDTO> GetDroneBattery(String serie){
            Drone drone = await _droneRepository.Get(serie);
            return _mapper.Map<DroneBatteryDTO>(drone);;
        }

        public async Task<DroneWeightMedicineDTO> GetDroneWeightMedicine(String serie){
            DroneWeightMedicineDTO dto = new DroneWeightMedicineDTO();
            Drone drone = await _droneRepository.Get(serie);
            if(drone != null){
                List<Medicine> medicines = await _medicineRepository.GetBySerie(serie);
                dto.NumSeries = drone.NumSeries;
                if(medicines.Any()) {
                    decimal weightTotal = 0;
                    foreach (var item in medicines)
                    {
                        weightTotal += item.Weight;
                    }
                    dto.weightTotal = weightTotal;
                } else {
                    dto.weightTotal = 0;
                }

            }
            return dto;
        }

    }
}