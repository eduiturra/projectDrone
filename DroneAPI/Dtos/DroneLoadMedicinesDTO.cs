using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DroneAPI.Dtos
{
    public class DroneLoadMedicinesDTO
    {
        public String Serie { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_-]+$",ErrorMessage="Permitido solo letras, números, ‘-‘, ‘_’")]
         public String Name { get; set; }
        public decimal Weight { get; set; }
        [RegularExpression(@"^[A-Z0-9_]+$",ErrorMessage="Permitido solo letra mayúscula, guión bajo y números")]
        public String Code { get; set; }
        public String Image { get; set; }

    }
}