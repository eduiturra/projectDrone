using System;
using System.Threading.Tasks;
using DroneAPI.Dtos;
using DroneAPI.Model;
namespace DroneAPI.Services
{
    public interface IMedicineServices
    {
        Task<DroneLoadMedicinesDTO> SaveMedicine(DroneLoadMedicinesDTO dto);
    }
}