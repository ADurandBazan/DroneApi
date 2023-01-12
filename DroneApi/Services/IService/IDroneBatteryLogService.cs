using DroneApi.Common.Filters;
using DroneApi.Services.Maps;

namespace DroneApi.Services.IService
{
    public interface IDroneBatteryLogService
    {
        Task<IEnumerable<DroneBatteryLogDto>> FindAllDroneBatteryLogsAsync(DroneBatteryLogRequestFilter? filter = null);
        Task ClearDroneBatteryLogsAsync();
    }
}
