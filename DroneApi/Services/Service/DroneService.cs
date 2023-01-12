using AutoMapper;
using DroneApi.Common.Filters;
using DroneApi.Entities;
using DroneApi.Helpers;
using DroneApi.Repositories.IRepository;
using DroneApi.Services.IService;
using DroneApi.Services.Maps;

namespace DroneApi.Services.Service
{
    public class DroneService : IDroneService
    {

        private readonly IMapper _mapper;
        private readonly IDroneRepository _droneRepository;
       

        public DroneService(
            IDroneRepository droneRepository,
            IMapper mapper)
        {
            _droneRepository = droneRepository;
            _mapper = mapper;
        }
        public async Task DeleteDroneAsync(int id)
        {
            var drone = await _droneRepository.GetDroneByIdAsync(id);
            if (drone != null)
            {
                await _droneRepository.DeleteDroneAsync(drone);
            }
            else
                throw new AppException("Drone with the id '" + id + "' not found");
        }

        public async Task<IEnumerable<DroneDto>> FindAllDronesAsync(DroneRequestFilter? request = null)
        {
            var drones = await _droneRepository.FindAllDronesAsync(request);
            return _mapper.Map<List<DroneDto>>(drones);
        }

        public async Task<IEnumerable<MedicationDto>> GetMedicationsByIdAsync(int id)
        {
            var drone = await _droneRepository.GetDroneByIdAsync(id);
            if (drone != null)
            {
                var medications = drone.Medications;
                var medicationsDto = _mapper.Map<List<MedicationDto>>(medications);
                return medicationsDto;
            }
            else
                throw new AppException("Drone with the id '" + id + "' not found");

        }
        public async Task<string> GetBatteryCapacityByIdAsync(int id)
        {
            var drone = await _droneRepository.GetDroneByIdAsync(id);
            if (drone != null)
            {
                return drone.BatteryCapacity.ToString() + "%";
            }
            else
                throw new AppException("Drone with the id '" + id + "' not found");

        }

        public async Task<DroneDto> InsertDroneAsync(DroneDto droneDto)
        {
            var drone = _mapper.Map<Drone>(droneDto);
            drone.Id = 0;
            await _droneRepository.InsertDroneAsync(drone);
            return _mapper.Map<DroneDto>(drone);
        }

        public async Task<DroneDto> UpdateDroneAsync(DroneDto droneDto)
        {
            var drone = await _droneRepository.GetDroneByIdAsync(droneDto.Id);
            if (drone != null)
            {
                _mapper.Map(droneDto, drone);
                await _droneRepository.UpdateDroneAsync(drone);
                return _mapper.Map<DroneDto>(drone);
            }
            return null;
        }


    }
}

