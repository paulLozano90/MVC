﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacionPractica.Utilidades;

namespace AutenticacionPractica.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            //var cifrado = SeguridadUtilidades.Cifrar("petterpaul.lozano@tajamar365.com", clave);
            //var data = Convert.FromBase64String(cifrado);
            //var descrifrado = SeguridadUtilidades.DesCifrar(data, clave);
            return View();
        }
    }
}