using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaAlmacen.Filtros;
using MvcPracticaAlmacen.Models;

namespace MvcPracticaAlmacen.Controllers
{
    public class EtiquetaController : Controller
    {
        Tienda19Entities db = new Tienda19Entities();

        // GET: Etiqueta
        [FilfroTiempo]
        public ActionResult IndexEtiqueta()
        {
            var data = db.Etiquetas;
            ViewBag.Almacenes = db.Almacen;
            return View(data);
        }
    }
}