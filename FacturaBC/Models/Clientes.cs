//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacturaBC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public Clientes()
        {
            this.FacturaEncabezado = new HashSet<FacturaEncabezado>();
        }
    
        public int codigo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
    
        public virtual ICollection<FacturaEncabezado> FacturaEncabezado { get; set; }
    }
}
