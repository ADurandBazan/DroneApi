using AutoMapper;
using DroneApi.Entities;

namespace DroneApi.Services.Maps
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // DroneDto -> Drone
            CreateMap<DroneDto, Drone>();
            // Drone -> DroneDto
            CreateMap<Drone, DroneDto>();

            // MedicationDto -> Medication
            CreateMap<MedicationDto, Medication>();
            // Medication -> MedicationDto
            CreateMap<Medication, MedicationDto>();

            // DroneBatteryLogDto -> DroneBatteryLog
            CreateMap<DroneBatteryLogDto, DroneBatteryLog>();
            // DroneBatteryLogDto -> DroneBatteryLogDto
            CreateMap<DroneBatteryLog, DroneBatteryLogDto>();

        }
    }
}
