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

        public Task<List<Medicine>> GetBySerie(String numSeries)
        {
            return _context.Medicines.Where(a => a.DroneId == numSeries).ToListAsync();
        }

        public async Task<Medicine> Save(Medicine model)
        {
            await _context.Medicines.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        
    }
}