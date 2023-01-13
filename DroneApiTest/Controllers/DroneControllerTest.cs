using DroneApi.Controllers;
using DroneApi.Services.IService;
using DroneApi.Services.Maps;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace DroneApiTest.Controllers
{
    public class DroneControllerTest
    {
        private readonly IDroneService _droneService;

        public DroneControllerTest()
        {
            _droneService = A.Fake<IDroneService>();
          
        }

        [Fact]
        public void DroneController_GetAll_ReturnOK()
        {
            //Arrange
            var drones = A.Fake<ICollection<DroneDto>>();
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DroneController_CreateDrone_ReturnOK()
        {
            //Arrange
            var droneDto = A.Fake<DroneDto>();
            A.CallTo(() => _droneService.InsertDroneAsync(droneDto)).Returns(A.Fake<DroneDto>());
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.CreateDrone(droneDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void DroneController_UpdateDrone_ReturnOK()
        {
            //Arrange
            var droneDto = A.Fake<DroneDto>();
            A.CallTo(() => _droneService.UpdateDroneAsync(droneDto)).Returns(A.Fake<DroneDto>());
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.UpdateDrone(droneDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DroneController_DeleteDrone_ReturnOK()
        {
            //Arrange
            int id = 1;
            A.CallTo(() => _droneService.DeleteDroneAsync(id));
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.DeleteDrone(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DroneController_GetBatteryCapacityById_ReturnOK()
        {
            //Arrange
            int id = 1;
            A.CallTo(() => _droneService.GetBatteryCapacityByIdAsync(id)).Returns(A.Fake<string>());
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.GetBatteryCapacityById(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void DroneController_GetMedicationsById_ReturnOK()
        {
            //Arrange
            int id = 1;
            var medications = A.Fake<ICollection<MedicationDto>>();
            A.CallTo(() => _droneService.GetMedicationsByIdAsync(id)).Returns(medications);
            var controller = new DroneController(_droneService);

            //Act
            var result = controller.GetMedicationsById(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
