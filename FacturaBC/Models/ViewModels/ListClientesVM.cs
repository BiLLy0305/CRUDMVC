using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaBC.Models.ViewModels
{
    public class ListClientesVM
    {
        public int codigo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}