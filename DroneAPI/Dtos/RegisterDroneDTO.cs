using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DroneAPI.Dtos
{
    public class RegisterDroneDTO : IValidatableObject
    {
        [Required]
        public String NumSeries { get; set; }
        [Required]
        public String Model { get; set; }
        [Required]
        public int WeightLimit { get; set; }
        [Required]
        public decimal Capacity { get; set; }
        [Required]
        public String State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(NumSeries.Length > 100 ){
                yield return new ValidationResult(
                    $"Número de serie máximo 100 caracteres.");
            }
            
            List<String> modelList = new List<String>(){"peso ligero", "peso medio", "peso crucero", "peso pesado"};
            if(!modelList.Any(a => a == Model)){
                yield return new ValidationResult(
                    $"El modelo tiene que ser: " + modelList.ToString());
            }

            List<String> stateList = new List<String>(){"INACTIVO", "CARGANDO", "CARGADO", "ENTREGANDO CARGA", "CARGA ENTREGADA",
"REGRESANDO"};
            if(!stateList.Any(a => a == State)){
                yield return new ValidationResult(
                    $"El estado tiene que ser: " + stateList.ToString());
            }

            if(WeightLimit > 500){
                yield return new ValidationResult(
                    $"El modelo tiene que ser: peso ligero, peso medio, peso crucero, peso pesado");
            }

            if(Capacity > 500){
                yield return new ValidationResult(
                    $"El modelo tiene que ser: peso ligero, peso medio, peso crucero, peso pesado");
            }
        }
    }
}