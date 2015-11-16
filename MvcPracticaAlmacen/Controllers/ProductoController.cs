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

        public ActionResult Detalle(int id)
        {
            var data = db.Producto.Find(id);
            return View(data);
        }
        
    }
}