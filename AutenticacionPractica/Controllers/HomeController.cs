using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacionPractica.Utilidades;

namespace AutenticacionPractica.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var cifrado = SeguridadUtilidades.Cifrar("Hola Amigo", "AAA");
            var descrifrado = SeguridadUtilidades.DesCifrar(cifrado, "AAA");
            return View();
        }
    }
}