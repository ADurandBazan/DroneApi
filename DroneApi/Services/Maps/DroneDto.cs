using DroneApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DroneApi.Services.Maps
{
    public class DroneDto
    {
        [JsonIgnore]
        public int Id { get; set; } = 0;

        [Required]
        [EnumDataType(typeof(DroneModel))]
        public string? Model { get; set; }

        [Required]
        [Range(0, 500)]
        public double WeightLimit { get; set; }

        [Required]
        public int BatteryCapacity { get; set; }

        [Required]
        [EnumDataType(typeof(DroneState))]
        public string? State { get; set; }

        [Required]
        [StringLength(100)]
        public string? SerialNumber { get; set; }

        [JsonIgnore]
        public List<MedicationDto>? Medications { get; set; }
    }
}