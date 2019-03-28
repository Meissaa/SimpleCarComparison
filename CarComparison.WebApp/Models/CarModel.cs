using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarComparison.WebApp.Models
{
    public class CarModel
    {
        [Display(Name="Nazwa")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Przebieg")]
        [Required(ErrorMessage = "Mileage is required")]
        public double Mileage { get; set; }

        [Display(Name = "Prędkość")]
        [Required(ErrorMessage = "Speed is required")]
        public double Speed { get; set; }

        [Display(Name = "Przyspieszenie")]
        [Required(ErrorMessage = "Acceleration is required")]
        public double Acceleration { get; set; }

        public int Points { get; set; }
    }
}