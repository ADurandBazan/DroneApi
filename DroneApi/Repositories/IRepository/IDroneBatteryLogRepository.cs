using DroneApi.Common.Filters;
using DroneApi.Entities;

namespace DroneApi.Repositories.IRepository
{
    public interface IDroneBatteryLogRepository
    {
        Task<IEnumerable<DroneBatteryLog>> FindAllDroneBatteryLogsAsync(DroneBatteryLogRequestFilter? filter = null);
        Task InsertDroneBatteryLogAsync(DroneBatteryLog log);
        Task ClearDroneBatteryLogsAsync();
    }
}
