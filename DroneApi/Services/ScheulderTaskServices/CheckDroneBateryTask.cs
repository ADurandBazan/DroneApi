using DroneApi.Entities;
using DroneApi.Repositories.IRepository;

namespace DroneApi.Services.ScheulderTaskServices
{
    public class CheckDroneBateryTask : BackgroundService
    {
        private ILogger<CheckDroneBateryTask> _logger;
        private readonly IServiceProvider _serviceProvider;
        public CheckDroneBateryTask(ILogger<CheckDroneBateryTask> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await CheckBatteryAsync();
                await Task.Delay(120000, stoppingToken);
            }
        }

        private async Task CheckBatteryAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var logRepository = scope.ServiceProvider.GetRequiredService<IDroneBatteryLogRepository>();
            var droneRepository = scope.ServiceProvider.GetRequiredService<IDroneRepository>();
            var drones = await droneRepository.FindAllDronesAsync();
            foreach (var drone in drones)
            {

                await logRepository.InsertDroneBatteryLogAsync(new DroneBatteryLog
                {
                    Date = DateTime.Now,
                    BatteryCapacity = drone.BatteryCapacity,
                    SerialNumber = drone.SerialNumber

                });
            }

        }
    }
}
