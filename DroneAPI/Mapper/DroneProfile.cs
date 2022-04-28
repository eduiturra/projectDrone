using System;
using System.Collections.Generic;
using AutoMapper;
using DroneAPI.Dtos;
using DroneAPI.Model;
namespace DroneAPI.Mapper
{
    public class DroneProfile : Profile
    {
        public DroneProfile()
        {
             CreateMap<RegisterDroneDTO, Drone>();
        }
    }
}