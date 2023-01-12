using DroneApi.Common.Filters;
using DroneApi.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace DroneApi.Controllers
{
    public class DroneBatteryLogController : ControllerBase
    {
        private readonly IDroneBatteryLogService _droneBatteryLogService;

        public DroneBatteryLogController(IDroneBatteryLogService droneBatteryLogService)
        {
            _droneBatteryLogService = droneBatteryLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DroneBatteryLogRequestFilter? request = null)
        {
            var logs = await _droneBatteryLogService.FindAllDroneBatteryLogsAsync(request);
            return Ok(new
            {
                success = true,
                logs
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAll()
        {
            await _droneBatteryLogService.ClearDroneBatteryLogsAsync();

            return Ok(new { success = true, message = "Logs cleaned" });
        }

    }
}

