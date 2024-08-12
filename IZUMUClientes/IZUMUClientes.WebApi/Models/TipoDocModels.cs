using System.ComponentModel.DataAnnotations;

namespace IZUMUClientes.WebApi.Models
{
    public class TipoDocModels
    {
        [Required]
        [Display(Name = "Tipo Documento")]
        public string? TipoDoc { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }
    }
}
