using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturaBC.Models.ViewModels
{
    public class FacturaEncVM
    {

        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

       
        public List<SelectListItem> Clientes { get; set; }
        
        [Display(Name = "Codigo Cliente")]
        public int codigoCliente { get; set; }
        
        public FacturaEncVM()
        {
            Clientes = new List<SelectListItem>();
        }
        
    }
}