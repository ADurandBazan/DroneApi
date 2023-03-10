using DroneApi.Common.Filters;
using DroneApi.Services.Maps;

namespace DroneApi.Services.IService
{
    public interface IDroneService
    {
        Task<IEnumerable<DroneDto>> FindAllDronesAsync(DroneRequestFilter? request = null);
        Task<DroneDto> InsertDroneAsync(DroneDto droneDto);
        Task<DroneDto> UpdateDroneAsync(DroneDto droneDto);
        Task DeleteDroneAsync(int id);
        Task<IEnumerable<MedicationDto>> GetMedicationsByIdAsync(int id);
        Task<string> GetBatteryCapacityByIdAsync(int id);
        Task LoadMedicationByIdAsync(int id, MedicationDto medication);
        Task LoadMedicationsByIdAsync(int id, IEnumerable<MedicationDto> medications);
        Task<IEnumerable<DroneBatteryLogDto>> GetBatteryLogsAsync(int id);

    }
}
