using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DroneApi.Services.Maps
{
    public class MedicationDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]*$")]
        public string? Name { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9_]*$")]
        public string? Code { get; set; }

        [JsonIgnore]
        public string? Image { get; set; }
    }
}

