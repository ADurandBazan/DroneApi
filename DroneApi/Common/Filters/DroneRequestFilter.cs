using DroneApi.Entities;

namespace DroneApi.Common.Filters
{
    public class DroneRequestFilter
    {
        public bool? WithMedication { get; set; }
        public string? SerialNumber { get; set; }
        public DroneModel? Model { get; set; }
        public DroneState? State { get; set; }
    }
}
