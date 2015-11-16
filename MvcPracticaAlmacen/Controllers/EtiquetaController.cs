using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaAlmacen.Models;

namespace MvcPracticaAlmacen.Controllers
{
    public class EtiquetaController : Controller
    {
        Tienda19Entities db = new Tienda19Entities();

        // GET: Etiqueta
        public ActionResult IndexEtiqueta()
        {
            var data = db.Etiquetas;
            return View(data);
        }
    }
}