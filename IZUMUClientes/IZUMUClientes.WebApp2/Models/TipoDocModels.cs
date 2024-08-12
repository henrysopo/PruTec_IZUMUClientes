using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IZUMUClientes.WebApp2.Models
{
    public class TipoDocModels
    {
        [Required]
        [Display(Name = "Tipo Documento")]
        public string TipoDoc { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}