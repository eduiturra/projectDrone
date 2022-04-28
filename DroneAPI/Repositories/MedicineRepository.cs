using System;
using System.Linq;
using System.Collections.Generic;
using DroneAPI.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DroneAPI.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly DroneDbContext _context;
        public MedicineRepository(DroneDbContext context) {
            _context = context;
        }

        public Task<Medicine> Get(Guid numSeries)
        {
            return _context.Medicines.FirstOrDefaultAsync(a => a.MedicineId == numSeries);
        }
    }
}