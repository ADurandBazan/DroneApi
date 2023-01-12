using DroneApi.Common.Filters;
using DroneApi.Entities;

namespace DroneApi.Repositories.IRepository
{
    public interface IDroneRepository
    {
        Task<IEnumerable<Drone>> FindAllDronesAsync(DroneRequestFilter? filter = null);
        Task InsertDroneAsync(Drone drone);
        Task UpdateDroneAsync(Drone drone);
        Task<Drone> GetDroneByIdAsync(int id);
        Task DeleteDroneAsync(Drone drone);
    }
}
