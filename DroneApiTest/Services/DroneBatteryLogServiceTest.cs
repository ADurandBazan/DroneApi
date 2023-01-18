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
    public class DroneBatteryLogServiceTest
    {
        private readonly IDroneBatteryLogRepository _droneBatteryLogRepository;
        private readonly IMapper _mapper;

        public DroneBatteryLogServiceTest()
        {
            _droneBatteryLogRepository = A.Fake<IDroneBatteryLogRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public async Task DroneServiceTest_FindAllDroneBatteryLogsAsync_ReturnsListDroneBatteryLogDto()
        {
            //Arrange
            var logs = A.Fake<ICollection<DroneBatteryLog>>();
            var logsDto = A.Fake<List<DroneBatteryLogDto>>();
            var filter = A.Fake<DroneBatteryLogRequestFilter>();
            A.CallTo(() => _mapper.Map<List<DroneBatteryLogDto>>(logs)).Returns(logsDto);
            var service = new DroneBatteryLogService(_droneBatteryLogRepository, _mapper);

            //Act
            var result = await service.FindAllDroneBatteryLogsAsync(filter);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<IEnumerable<DroneBatteryLogDto>>();
        }

        

    }
}
