using DroneApi.Common.Filters;
using DroneApi.Entities;
using DroneApi.Helpers;
using DroneApi.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DroneApi.Repositories.Repository
{
    public class DroneRepository : IDroneRepository
    {
        private DataContext _context;
        private readonly DbSet<Drone> _drones;
        public DroneRepository(
          DataContext context
        )
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _context = context;
            _drones = context.Set<Drone>();


        }

        public async Task DeleteDroneAsync(Drone drone)
        {
            _drones.Remove(drone);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Drone>> FindAllDronesAsync(DroneRequestFilter? filter = null)
        {
            var drones = await _drones.AsQueryable().Include(d => d.Medications).ToListAsync();
            if (filter != null)
            {
                if (filter.WithMedication.HasValue)
                {
                    if (filter.WithMedication.Value)
                        drones = drones.Where(d => d.Medications.Any()).ToList();
                    else
                        drones = drones.Where(d => !d.Medications.Any()).ToList();
                }
            }
             return drones;
        }

        public async Task<Drone> GetDroneByIdAsync(int id)
        {
            return await _drones.Include(d => d.Medications).FirstOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task InsertDroneAsync(Drone drone)
        {
            if (_drones.Count() == 10)
                throw new AppException("The fleet only admits 10 drones");

            else if (_drones.Any(x => x.SerialNumber.Equals(drone.SerialNumber)))
                throw new AppException("Drone with the serial number '" + drone.SerialNumber + "' already exists");

            _drones.Add(drone);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateDroneAsync(Drone drone)
        {
            _drones.Update(drone);
            await _context.SaveChangesAsync();

        }
    }
}
