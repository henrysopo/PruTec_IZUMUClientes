using System.ComponentModel.DataAnnotations;

namespace IZUMUClientes.WebApi.Models
{
    public class PlanModels
    {
        [Required]
        [Display(Name = "Descripcion")]
        public int IdPlan { get; set; }

        [Required]
        [Display(Name = "Nombre Plan")]
        public string? NombrePlan { get; set; }
    }
}
