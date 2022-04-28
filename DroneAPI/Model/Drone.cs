using System;
using System.Collections.Generic;
namespace DroneAPI.Model
{
    public class Drone
    {
        public String NumSeries { get; set; }
        public String Model { get; set; }
        public int WeightLimit { get; set; }
        public decimal Capacity { get; set; }
        public String State { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}