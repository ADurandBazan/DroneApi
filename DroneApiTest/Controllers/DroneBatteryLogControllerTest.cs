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
    public class DroneBatteryLogControllerTest
    {
        private readonly IDroneBatteryLogService _droneBatteryLogService;

        public DroneBatteryLogControllerTest()
        {
            _droneBatteryLogService = A.Fake<IDroneBatteryLogService>();

        }

        [Fact]
        public void DroneBatteryLogController_GetAll_ReturnOK() 
        {
            //Arrange
            var logs = A.Fake<ICollection<DroneBatteryLogDto>>();
            var controller = new DroneBatteryLogController(_droneBatteryLogService);
          
            //Act
            var result = controller.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
      
        [Fact]
        public void DroneBatteryLogController_DeleteAll_ReturnOK()
        {
            //Arrange
            A.CallTo(() => _droneBatteryLogService.ClearDroneBatteryLogsAsync());
            var controller = new DroneBatteryLogController(_droneBatteryLogService);
            
            //Act
            var result = controller.DeleteAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
