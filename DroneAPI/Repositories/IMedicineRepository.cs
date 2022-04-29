using System;
using System.Threading.Tasks;
using DroneAPI.Model;
using System.Collections.Generic;

namespace DroneAPI.Repositories
{
    public interface IMedicineRepository
    {
         Task<Medicine> Save(Medicine model);
         Task<List<Medicine>> GetBySerie(String numSeries);
    }
}