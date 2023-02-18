using AutoMapper;
using DroneApi.Common.Filters;
using DroneApi.Entities;
using DroneApi.Repositories.IRepository;
using DroneApi.Services.Maps;
using DroneApi.Services.Service;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DroneApiTest.Services
{
    public class DroneServiceTest
    {
        private readonly IDroneRepository _droneRepository;
        private readonly IMapper _mapper;

        public DroneServiceTest()
        {
            _droneRepository = A.Fake<IDroneRepository>();
            _mapper = A.Fake<IMapper>();
        }

 
        [Fact]
        public async Task DroneServiceTest_FindAllDronesAsync_ReturnsListDroneDto()
        {
            //Arrange
            var drones = A.Fake<ICollection<Drone>>();
            var dronesDto = A.Fake<List<DroneDto>>();
            var filter = A.Fake<DroneRequestFilter>();
            A.CallTo(() => _mapper.Map<List<DroneDto>>(drones)).Returns(dronesDto);
            var service = new DroneService(_droneRepository, _mapper);
            
            //Act
            var result = await service.FindAllDronesAsync(filter);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<IEnumerable<DroneDto>>();
        }


        [Fact]
        public async Task DroneServiceTest_GetBatteryCapacityByIdAsync_ReturnsInteger()
        {
            //Arrange
            Drone drone = A.Fake<Drone>();
            int id = 1;
            A.CallTo(() => _droneRepository.GetDroneByIdAsync(id)).Returns(drone);
        
            var service = new DroneService(_droneRepository, _mapper);

            //Act
            var result = await service.GetBatteryCapacityByIdAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<int>();

        }
        [Fact]
        public async Task DroneServiceTest_InsertDroneAsync_ReturnsDroneDto()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            var droneDto = A.Fake<DroneDto>();
           
            A.CallTo(() => _mapper.Map<Drone>(droneDto)).Returns(drone);
            A.CallTo(() => _droneRepository.InsertDroneAsync(drone));

            var service = new DroneService(_droneRepository, _mapper);

            //Act
            var result = await service.InsertDroneAsync(droneDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<DroneDto>();

        }

        [Fact]
        public async Task DroneServiceTest_UpdateDroneAsync_ReturnsDroneDto()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            var droneDto = A.Fake<DroneDto>();
            A.CallTo(() => _droneRepository.GetDroneByIdAsync(droneDto.Id)).Returns(drone);
            A.CallTo(() => _mapper.Map<Drone>(droneDto)).Returns(drone);
            A.CallTo(() => _droneRepository.UpdateDroneAsync(drone));

            var service = new DroneService(_droneRepository, _mapper);

            //Act
            var result = await service.UpdateDroneAsync(droneDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<DroneDto>();

        }

        [Fact]
        public async Task DroneServiceTest_LoadMedicationByIdAsync_ReturnsDroneDto()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            var medicationDto = A.Fake<MedicationDto>();
            var droneDto = A.Fake<DroneDto>();
            var medication = A.Fake<Medication>();
            int id = 1;
            A.CallTo(() => _mapper.Map<Drone>(droneDto)).Returns(drone);
            A.CallTo(() => _droneRepository.GetDroneByIdAsync(id)).Returns(drone);
            A.CallTo(() => _mapper.Map<Medication>(medicationDto)).Returns(medication);
            A.CallTo(() => drone.AddMedication(medication));
            A.CallTo(() => _droneRepository.UpdateDroneAsync(drone));

            var service = new DroneService(_droneRepository, _mapper);

            //Act
            await service.LoadMedicationByIdAsync(id, medicationDto);

            //Assert
           
             drone.Medications.Should().Contain(medication);
          
        }
        [Fact]
        public async Task DroneServiceTest_LoadMedicationByIdsAsync_ReturnsDroneDto()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            var medicationsDto = A.Fake<List<MedicationDto>>();
            var droneDto = A.Fake<DroneDto>();
            var medications = A.Fake<List<Medication>>();
            int id = 1;
            
            A.CallTo(() => _droneRepository.GetDroneByIdAsync(id)).Returns(drone);
            A.CallTo(() => _mapper.Map<List<Medication>>(medicationsDto)).Returns(medications);
            A.CallTo(() => drone.AddMedications(medications));
            A.CallTo(() => _droneRepository.UpdateDroneAsync(drone));

            var service = new DroneService(_droneRepository, _mapper);

            //Act
            var result = await service.UpdateDroneAsync(droneDto);

            //Assert

            drone.Medications.Should().Contain(medications);

        }
        [Fact]
        public async Task DroneServiceTest_DeleteDroneAsync_RepoNotContainDrone()
        {
            //Arrange
            var drone = A.Fake<Drone>();
            int id = 1;
            var drones = A.Fake<ICollection<Drone>>();
            A.CallTo(() => _droneRepository.GetDroneByIdAsync(id)).Returns(drone);
            A.CallTo(() => _droneRepository.DeleteDroneAsync(drone));

            var service = new DroneService(_droneRepository, _mapper);

            //Act
            await service.DeleteDroneAsync(id);
            var result = await _droneRepository.FindAllDronesAsync();

            //Assert
            result.Should().NotContain(drone);
           

        }

    }
}
