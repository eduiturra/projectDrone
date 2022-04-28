using System;

namespace DroneAPI.Model
{
    public class Medicine
    {
        public Guid MedicineId { get; set; }
        public String Serie { get; set; }
        public String Name { get; set; }
        public decimal Weight { get; set; }
        public String Code { get; set; }
        public String Image { get; set; }
        public int DroneId { get; set; }

        public Drone Drone { get; set; }
    }
}