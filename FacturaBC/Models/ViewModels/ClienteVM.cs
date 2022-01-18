using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturaBC.Models.ViewModels
{
    public class ClienteVM
    {
        public int codigo { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Display(Name = "Correo")]
        [EmailAddress]
        public string correo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }
    }
}