using AutoMapper;
using DroneApi.Common.Filters;
using DroneApi.Repositories.IRepository;
using DroneApi.Services.IService;
using DroneApi.Services.Maps;

namespace DroneApi.Services.Service
{
    public class DroneBatteryLogService : IDroneBatteryLogService
    {

        private readonly IMapper _mapper;
        private readonly IDroneBatteryLogRepository _droneBatteryLogRepository;

        public DroneBatteryLogService(
            IDroneBatteryLogRepository droneBatteryLogRepository,
            IMapper mapper)
        {
            _droneBatteryLogRepository = droneBatteryLogRepository;
            _mapper = mapper;
        }

        public async Task ClearDroneBatteryLogsAsync()
        {
            await _droneBatteryLogRepository.ClearDroneBatteryLogsAsync();
        }

        public async Task<IEnumerable<DroneBatteryLogDto>> FindAllDroneBatteryLogsAsync(DroneBatteryLogRequestFilter? filter = null)
        {
            var logs = await _droneBatteryLogRepository.FindAllDroneBatteryLogsAsync(filter);
            return _mapper.Map<List<DroneBatteryLogDto>>(logs);
        }
    }
}

