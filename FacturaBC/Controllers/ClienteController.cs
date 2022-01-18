using FacturaBC.Models;
using FacturaBC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturaBC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ListClientesVM> lista;
            using (PopularEntities db = new PopularEntities())
            {
                lista = (from d in db.Clientes
                         select new ListClientesVM
                         {
                             codigo = d.codigo,
                             nombres = d.nombres,
                             apellidos = d.apellidos,
                             correo = d.correo,
                         }).ToList();
            }
            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PopularEntities db = new PopularEntities())
                    {
                        var nc = new Clientes();
                        nc.nombres = model.nombres;
                        nc.apellidos = model.apellidos;
                        nc.correo = model.correo;
                        nc.fechaNacimiento = model.fechaNacimiento;
                        db.Clientes.Add(nc);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            ClienteVM model = new ClienteVM();
            using (PopularEntities db = new PopularEntities())
            {
                var mC = db.Clientes.Find(id);
                model.nombres = mC.nombres;
                model.apellidos = mC.apellidos;
                model.correo = mC.correo;
                model.codigo = mC.codigo;
            }
            return View(model);
        }



        [HttpPost]
        public ActionResult Editar(ClienteVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PopularEntities db = new PopularEntities())
                    {
                        var mc = db.Clientes.Find(model.codigo);
                        mc.nombres = model.nombres;
                        mc.apellidos = model.apellidos;
                        mc.correo = model.correo;
                        // nc.fechaNacimiento = model.fechaNacimiento;

                        db.Entry(mc).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            ClienteVM model = new ClienteVM();
            using (PopularEntities db = new PopularEntities())
            {
                var obj = db.Clientes.Find(id);
                db.Clientes.Remove(obj);
                db.SaveChanges();
            }
            return Redirect("~/Cliente");
        }

    }
}