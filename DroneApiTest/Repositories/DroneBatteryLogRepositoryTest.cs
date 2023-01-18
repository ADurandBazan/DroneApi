using DroneApi.Entities;
using DroneApi.Repositories;
using DroneApi.Repositories.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DroneApiTest.Repositories
{
    public class DroneBatteryLogRepositoryTest
    {
        private readonly IConfiguration _configuration;
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new DataContext(_configuration);



            databaseContext.Database.EnsureCreated();
            if (await databaseContext.DroneBatteryLogs.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var drone = new Drone
                    {
                        BatteryCapacity = 100
                    };

                    databaseContext.Add(
                    new DroneBatteryLog
                    {
                        BatteryCapacity = 100,
                        Date = DateTime.Now,
                        Drone = drone

                    });

                }
                    await databaseContext.SaveChangesAsync();
                }
            
            return databaseContext;
        }
        [Fact]
        public async void DroneRepository_FindAllDroneBatteryLogsAsync_ReturnsDroneBatteryLogs()
        {
            //Arrange

            var dbContext = await GetDatabaseContext();
            var droneRepository = new DroneBatteryLogRepository(dbContext);

            //Act
            var result = await droneRepository.FindAllDroneBatteryLogsAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ICollection<DroneBatteryLog>>();
        }
    }
}
