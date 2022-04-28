using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using DroneAPI.Controllers;
using DroneAPI.Dtos;
using System.Collections.Generic;
namespace project
{
    public class DroneControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("series123","peso ligero",200,100,"INACTIVO", true)]
        [TestCase("series123","peso ligero",200,100,"OTRACOSA", false)]
        [TestCase("series123","peso ligero",501,100,"INACTIVO", false)]
        public void RegisterDroneDTO_ModelValidation_Test(String numSeries, String model, int weightLimit, decimal capacity, String state, bool valid)
        {
            var sut = new RegisterDroneDTO();
            sut.NumSeries = numSeries;
            sut.Model = model;
            sut.WeightLimit = weightLimit;
            sut.Capacity = capacity;
            sut.State = state;
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);
             Assert.That(valid == isModelStateValid);
        }

        [TestCase("series123","a3_4ds-a",200,"A23D_","imagen.jpg", true)]
        [TestCase("series123","a3_@4ds-a",200,"A23D_","imagen.jpg", false)]
        [TestCase("series123","a3_4ds-a",200,"A2w_","imagen.jpg", false)]
        public void DroneLoadMedicinesDTO_ModelValidation_Test(String serie, String name,decimal weight, String code, String image, bool valid)
        {
            var sut = new DroneLoadMedicinesDTO();
            sut.Serie = serie;
            sut.Weight = weight;
            sut.Name = name;
            sut.Code = code;
            sut.Image = image;
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);
             Assert.That(valid == isModelStateValid);
        }
    }
}