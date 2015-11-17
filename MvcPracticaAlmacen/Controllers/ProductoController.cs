using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPracticaAlmacen.Models;

namespace MvcPracticaAlmacen.Controllers
{
    public class ProductoController : Controller
    {
        Tienda19Entities db=new Tienda19Entities();

        // GET: Producto

        public ActionResult IndexProducto()
        {
            var data = db.Producto;
            return View(data);
        }

        public ActionResult DetalleProducto(String nombreProducto)
        {
            var nom = nombreProducto.Replace("_", " ");
            //Lo mejor no es remplazarlo, es hacer un campo en la 
            //base de datos que este el nombre sin espacios...
            var data = db.Producto.FirstOrDefault(o => o.nombre == nom);

            if (data == null)
            {
                return RedirectToAction("IndexProducto");
            }

            return View(data);
        }
    }
}