using System;

namespace DroneAPI.Dtos
{
    public class GetDroneDTO
    {
        public int numSeries { get; set; }
        public String modelo { get; set; }
        public int weightLimit { get; set; }
        public int capacity { get; set; }
        public String state { get; set; }
    }
}