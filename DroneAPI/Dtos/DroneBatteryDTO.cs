using System;

namespace DroneAPI.Dtos
{
    public class DroneBatteryDTO
    {
        public String numSeries { get; set; }
        public String Model { get; set; }
        public decimal Capacity { get; set; }
    }
}