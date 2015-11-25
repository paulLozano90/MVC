using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacionVehiculos.Models;

namespace AutenticacionVehiculos.Controllers
{
    public class VehiculoController : Controller
    {
        AutenticacionVehiculosEntities db = new AutenticacionVehiculosEntities();

        // GET: Vehiculo
        public ActionResult IndexVehiculo(int idTipo)
        {
            ViewBag.idTipo = idTipo;

            var data = db.Vehiculo.Where(o => o.idTipo == idTipo);
            return View(data);
        }

        public ActionResult BuscarVehiculo(int idTipo, int campo, string contenido)
        {
            var data = db.Vehiculo.Where(o => o.idTipo == idTipo);
            if (campo == 1)
            {
                data = data.Where(o => o.matricula.Contains(contenido));
            }
            else
            {
                data = data.Where(o => o.marca.Contains(contenido));
            }
            return PartialView("_listadoVehiculos", data.ToList());
        }

        [HttpPost]
        public ActionResult AltaVehiculo(Vehiculo model)
        {
            db.Vehiculo.Add(model);
            db.SaveChanges();
            return Json(model);
            //Si nos piden la peticion por GET seria asi...
            //return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}