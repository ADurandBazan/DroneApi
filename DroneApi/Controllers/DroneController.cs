using DroneApi.Common.Filters;
using DroneApi.Services.IService;
using DroneApi.Services.Maps;
using Microsoft.AspNetCore.Mvc;

namespace DroneApi.Controllers
{
    [ApiController]
    [Route("api/drone")]
    public class DroneController : ControllerBase
    {
        private readonly IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DroneRequestFilter? request = null)
        {
            var drones = await _droneService.FindAllDronesAsync(request);
            return Ok(new
            {
                success = true,
                drones
            });
        }
       
       [HttpGet("batterycheck/{id}")]
        public async Task<IActionResult> GetBatteryCapacityById(int id)
        {
            var battery = await _droneService.GetBatteryCapacityByIdAsync(id);
            return Ok(new
            {
                success = true,
                battery
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrone(DroneDto droneDto)
        {
            var drone = await _droneService.InsertDroneAsync(droneDto);
            if (drone != null)
                return Ok(new
                {
                    success = true,
                    message = "Drone created",
                    drone
                });

            return StatusCode(500);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrone(DroneDto droneDto)
        {
            var drone = await _droneService.UpdateDroneAsync(droneDto);
            if (drone != null)
                return Ok(new
                {
                    success = true,
                    message = "Drone updated",
                    drone
                });

            return NotFound(new { success = false, message = "Drone not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrone(int id)
        {
            await _droneService.DeleteDroneAsync(id);

            return Ok(new { success = true, message = "Drone deleted" });
        }

        [HttpGet("getmedications/{id}")]
        public async Task<IActionResult> GetMedicationsById(int id)
        {
            var medications = await _droneService.GetMedicationsByIdAsync(id);
            return Ok(new
            {
                success = true,
                medications
            });
        }

        [HttpPost("loadmedication/{id}")]
        public async Task<IActionResult> LoadMedicationById(int id, MedicationDto medicationDto)
        {
            await _droneService.LoadMedicationById(id, medicationDto);
            return Ok();
        }
       
        [HttpPost("loadmedicationlist/{id}")]
        public async Task<IActionResult> LoadMedicationsById(int id, IEnumerable<MedicationDto> medications)
        {
            await _droneService.LoadMedicationsById(id, medications);
            return Ok();
        }
        [HttpPost("getbatterylogs/{id}")]
        public async Task<IActionResult> GetBatteryLogs(int id)
        {
          var logs =  await _droneService.GetBatteryLogsAsync(int id);
            return Ok(new { succes = true,
                            logs
            });
        }
    }
}

