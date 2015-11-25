using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutenticacionVehiculos.Models;

namespace AutenticacionVehiculos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
            //var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
            if (Membership.ValidateUser(model.login, model.password))
            {
                Session["horaLogin"] = DateTime.Now;
                HttpContext.Application["horaPrueba"] = DateTime.Now;
                TempData["horaTemporal"] = DateTime.Now;
                //Si lo pones a true, se te guardaria el inicio de sesion
                FormsAuthentication.RedirectFromLoginPage(model.login, false);
                return null;
            }
            return View(model);
        }

        public ActionResult LogoOff()
        {
            //Borra la sesion
            Session.Clear();
            //Limpia las sesiones
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}