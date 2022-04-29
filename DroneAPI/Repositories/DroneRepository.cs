using System;
using System.Linq;
using System.Collections.Generic;
using DroneAPI.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DroneAPI.Repositories
{
    public class DroneRepository : IDroneRepository
    {
        private readonly DroneDbContext _context;
        public DroneRepository(DroneDbContext context) {
            _context = context;
        }

        public async Task<Drone> Save(Drone model)
        {
            await _context.Drones.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<Drone> Get(String numSeries)
        {
            return _context.Drones.Include(a=>a.Medicines).FirstOrDefaultAsync(a => a.NumSeries == numSeries);
        }

        public Task<List<Drone>> GetByState(String state)
        {
            return _context.Drones.Where(a => a.State == state).ToListAsync();
        }

    }
}