﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutentificacionEjemplo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        //Se pueden autorizar tanto roles como usuarios
        [Authorize (Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}