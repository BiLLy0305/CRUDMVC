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
    
    public partial class Proveedores
    {
        public Proveedores()
        {
            this.Productos = new HashSet<Productos>();
        }
    
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
    
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
