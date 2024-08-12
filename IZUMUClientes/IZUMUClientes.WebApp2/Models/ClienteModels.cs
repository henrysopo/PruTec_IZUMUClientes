using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IZUMUClientes.WebApp2.Models
{
    public class ClienteModels
    {
        [Display(Name = "Tipo de documento")]
        public string tipoDoc { get; set; }

        [Display(Name = "Número de documento")]
        public string numeroDocumento { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Primer nombre")]
        public string primerNombre { get; set; }

        [Display(Name = "Segundo nombre")]
        public string segundoNombre { get; set; }

        [Display(Name = "Primer apellido")]
        public string primerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        public string segundoApellido { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Número de celular")]
        public string numeroCelular { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Id Plan")]
        public Int32 idPlan { get; set; }

        [Display(Name = "Nombre Plan")]
        public string nombrePlan { get; set; }

        [Display(Name = "Fecha de registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.DateTime)]
        public DateTime? fechaReg { get; set; }

    }
}