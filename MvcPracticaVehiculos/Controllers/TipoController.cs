using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaVehiculos.Models;

namespace MvcPracticaVehiculos.Controllers
{
    public class TipoController : Controller
    {
        Vehiculos19Entities db = new Vehiculos19Entities();

        // GET: Tipo
        public ActionResult IndexTipo()
        {
            var data = db.TipoVehiculo;
            return View(data);
        }

        public ActionResult AltaTipo()
        {
            return View(new TipoVehiculo());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AltaTipo(TipoVehiculo model)
        {
            if (ModelState.IsValid)
            {
                db.TipoVehiculo.Add(model);
                db.SaveChanges();
                return RedirectToAction("IndexTipo");
            }
            return View(model);
        }

        public ActionResult ModificarTipo(String nombreTipo)
        {
            var nom = nombreTipo.Replace("_", " ");
            var data = db.TipoVehiculo.FirstOrDefault(o => o.nombreTipo == nom);

            if (data == null)
            {
                return RedirectToAction("IndexTipo");
            }

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarTipo(TipoVehiculo model)
        {
            //Estado de como se encuentra el objeto
            if (ModelState.IsValid)
            {
                //Recuperamos el objeto, cambiamos los datos y guardamos
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexTipo");
            }
            return View(model);
        }

        public ActionResult BorrarTipo(string nombreTipo)
        {
            var nom = nombreTipo.Replace("_", " ");
            var data = db.TipoVehiculo.FirstOrDefault(o => o.nombreTipo == nom);
            //Si no esta vacio, tenemos que borrar antes los datos de ese almacen
            if (data.Vehiculo.Any())
            {
                db.Vehiculo.RemoveRange(data.Vehiculo);
            }
            db.TipoVehiculo.Remove(data);
            db.SaveChanges();
            return RedirectToAction("IndexTipo");
        }
    }
}