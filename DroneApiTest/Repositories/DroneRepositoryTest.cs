using DroneApi.Entities;
using DroneApi.Repositories;
using DroneApi.Repositories.Repository;
using FakeItEasy;
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
    public class DroneRepositoryTest
    {
        private readonly IConfiguration _configuration;
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
           
        var databaseContext = new DataContext(_configuration);
          


            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Drones.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Drones.Add(
                    new Drone()
                    {
                        SerialNumber = "D001",
                        BatteryCapacity = 100,
                        Model = DroneModel.Heavyweight,
                        State = DroneState.IDLE,
                        Medications = new List<Medication>()
                            {
                                new Medication { Name="Aspirina",Code = "0001", Weight = 3 },
                                new Medication { Name="Metronidazol",Code = "0002", Weight = 6 }
                                
                            }
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async void DroneRepository_FindAllDronesAsync_ReturnsDrones()
        {
            //Arrange
          
            var dbContext = await GetDatabaseContext();
            var droneRepository = new DroneRepository(dbContext);

            //Act
            var result = await droneRepository.FindAllDronesAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ICollection<Drone>>();
        }
        [Fact]
        public async void DroneRepository_GetDroneByIdDronesAsync_ReturnsDrone()
        {
            //Arrange
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var droneRepository = new DroneRepository(dbContext);

            //Act
            var result = await droneRepository.GetDroneByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Drone>();
        }
        [Fact]
        public async void DroneRepository_InsertDroneAsync_MustContainDrone()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            var dbContext = await GetDatabaseContext();
            var droneRepository = new DroneRepository(dbContext);

            //Act
            await droneRepository.InsertDroneAsync(drone);
            var result = await droneRepository.FindAllDronesAsync();

            //Assert
            result.Should().Contain(drone);
           
        }

    }
}
