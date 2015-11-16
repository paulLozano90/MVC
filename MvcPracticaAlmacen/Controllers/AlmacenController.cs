using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaAlmacen.Filtros;
using MvcPracticaAlmacen.Models;

namespace MvcPracticaAlmacen.Controllers
{
    public class AlmacenController : Controller
    {
        private Tienda19Entities db = new Tienda19Entities();
        
        // GET: Almacen

        public ActionResult IndexAlmacen()
        {
            var info = db.Etiquetas;

            ViewBag.etiquetas = info.ToList();
            ViewData["Titulo"] = "Listado de almacenes";

            var data = db.Almacen;
            return View(data);
        }
        [FiltroId]
        public ActionResult DetalleAlmacen(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        //Modificar:
        [FiltroId]
        public ActionResult ModificarAlmacen(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarAlmacen(Almacen model)
        {
            //Estado de como se encuentra el objeto
            if (ModelState.IsValid)
            {
                //Recuperamos el objeto, cambiamos los datos y guardamos
                db.Entry(model).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexAlmacen");
            }
            return View(model);
        }

        //Se puede borrar de dos maneras:

        //Borrarlo directamente
        [FiltroId]
        public ActionResult BorrarAlmacen(int id)
        {
            var data = db.Almacen.Find(id);
            //Si no esta vacio, tenemos que borrar antes los datos de ese almacen
            if (data.ProductoAlmacen.Any())
            {
                db.ProductoAlmacen.RemoveRange(data.ProductoAlmacen);
            }
            db.Almacen.Remove(data);
            db.SaveChanges();
            return RedirectToAction("IndexAlmacen");
        }

        //Preguntar antes de borrar
        //[HttpPost]
        //public ActionResult BorrarAlmacen(Almacen model)
        //{
        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var id = db.Almacen.Find(model.idAlmacen);
        //    db.Almacen.Remove(id);
        //    db.SaveChanges();
        //    return View(model);
        //}
    }
}