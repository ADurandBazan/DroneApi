using DroneApi.Common.Filters;
using DroneApi.Entities;
using DroneApi.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DroneApi.Repositories.Repository
{
    public class DroneBatteryLogRepository : IDroneBatteryLogRepository
    {
        private DataContext _context;
        private readonly DbSet<DroneBatteryLog> _logs;
        public DroneBatteryLogRepository(
          DataContext context
        )
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
            _logs = context.Set<DroneBatteryLog>();


        }

        public async Task ClearDroneBatteryLogsAsync()
        {
            var logs = await _logs.AsQueryable().ToListAsync();
            _context.DroneBatteryLogs.RemoveRange(logs);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DroneBatteryLog>> FindAllDroneBatteryLogsAsync(DroneBatteryLogRequestFilter? filter = null)
        {
            var logs = await _logs.AsQueryable().Include(l => l.Drone).ToListAsync();
            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.SerialNumber))
                {

                    logs = logs.Where(l => l.Drone.SerialNumber.ToLower().Contains(filter.SerialNumber.ToLower())).ToList();

                }
            }
            return logs;
        }

        public async Task InsertDroneBatteryLogAsync(DroneBatteryLog log)
        {
           _logs.Add(log);
            await _context.SaveChangesAsync();

        }


    }
}

