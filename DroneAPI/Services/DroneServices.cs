using AutoMapper;
using DroneAPI.Dtos;
using DroneAPI.Model;
using System.Threading.Tasks;
using DroneAPI.Repositories;
namespace DroneAPI.Services
{
    public class DroneServices : IDroneServices
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public DroneServices(IMapper mapper, IDroneRepository droneRepository) {
          _droneRepository = droneRepository;
          _mapper = mapper;
        }

        public async Task<Drone> SaveDrone(RegisterDroneDTO dto){
            Drone model = _mapper.Map<Drone>(dto);
            await _droneRepository.Save(model);
            return model;
        }

    }
}