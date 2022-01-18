using FacturaBC.Models;
using FacturaBC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturaBC.Controllers
{
    public class FacturaEncController : Controller
    {
        // GET: FacturaEnc
        public ActionResult Index()
        {
            List<ListFacturasEncVM> lista;
            using (PopularEntities db = new PopularEntities())
            {
                lista = (from d in db.FacturaEncabezado
                         join c in db.Clientes on d.codigoCliente equals c.codigo
                         select new ListFacturasEncVM
                         {
                             codigo = d.codigo,
                             codigoCliente = d.codigoCliente,
                             nombreCliente = c.nombres,
                             fecha = (DateTime)d.fecha
                         }
                         }).ToList();
            }
            return View(lista);
        }

     
        private static List<SelectListItem> getClientes()
        {
            PopularEntities entities = new PopularEntities();

            List<SelectListItem> clienteList = (from p in entities.Clientes.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.nombres,
                                                     Value = p.codigo.ToString()
                                                 }).ToList();

            clienteList.Insert(0, new SelectListItem { Text = "--Select Customer--", Value = "" });
            return clienteList;
        }

        public ActionResult Nuevo()
        {
            var addFacturaEncVM = new FacturaEncVM();
            addFacturaEncVM.Clientes = getClientes();
            return View(addFacturaEncVM);
        }

        [HttpPost]
        public ActionResult Nuevo(FacturaEncVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int clienteSeleccionado = model.codigoCliente;
                    
                    using (PopularEntities db = new PopularEntities())
                    {
                        var ob = new FacturaEncabezado();

                        ob.codigo = clienteSeleccionado;
                        ob.fecha = model.fecha;

                        db.FacturaEncabezado.Add(ob);
                        db.SaveChanges();

                    }
                    return Redirect("~/FacturaEnc");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}