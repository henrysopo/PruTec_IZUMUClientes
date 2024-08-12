using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IZUMUClientes.WebApp2.Models
{
    public class PlanModels
    {
        [Required]
        [Display(Name = "Id Plan")]
        public Int32 IdPlan { get; set; }

        [Required]
        [Display(Name = "Nombre Plan")]
        public string NombrePlan { get; set; }
    }
}