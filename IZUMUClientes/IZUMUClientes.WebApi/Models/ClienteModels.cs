using System.ComponentModel.DataAnnotations;

namespace IZUMUClientes.WebApi.Models
{
    public class ClienteModels
    {
        [Required]
        [Display(Name = "Tipo Documento")]
        public string? TipoDoc { get; set; }

        [Required]
        [Display(Name = "Numero Documento")]
        public string? NumeroDocumento { get; set; }

        [Required]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Primer Nombre")]
        public string? PrimerNombre { get; set; }

        [Required]
        [Display(Name = "Segundo Nombre")]
        public string? SegundoNombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string? PrimerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string? SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string? Direccion { get; set; }

        [Required]
        [Display(Name = "Numero Celular")]
        public string? NumeroCelular { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Id Plan")]
        public Int32? IdPlan { get; set; }

        [Display(Name = "Nombre Plan")]
        public string? NombrePlan { get; set; }

        [Display(Name = "Fecha Registro")]
        public DateTime? fechaReg { get; set; }
    }
}
