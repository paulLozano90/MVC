using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaAlmacen.Models;

namespace MvcPracticaAlmacen.Controllers
{
    public class ProductosAjaxController : Controller
    {
        Tienda19Entities db=new Tienda19Entities();

        // GET: ProductosAjax
        public ActionResult Index()
        {
            return View(db.Producto);
        }

        public ActionResult Buscar(String nombre)
        {
            var data = db.Producto.Where(o => o.nombre.Contains(nombre));

            return PartialView("_listadoProducto", data);
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model);
        }
    }
}