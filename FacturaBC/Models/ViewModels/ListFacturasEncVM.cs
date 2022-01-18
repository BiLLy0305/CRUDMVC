using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaBC.Models.ViewModels
{
    public class ListFacturasEncVM
    {
        public int codigo { get; set; }
        public int codigoCliente { get; set; }
        public string nombreCliente { get; set; }
        public DateTime fecha { get; set; }
    }
}