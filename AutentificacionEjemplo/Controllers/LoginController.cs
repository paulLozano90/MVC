using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutentificacionEjemplo.Models;

namespace AutentificacionEjemplo.Controllers
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
            if (model.Login == model.Password)
            {
                //Identidad del usuario. Solo recibe el nombre el usuario
                var iden = new GenericIdentity(model.Login);
                //Tiene que almacenar la identidad del usuario y la lista de roles
                //que tiene cada usuario, ya sea un admin o un usuario normal.
                var principal = new GenericPrincipal(iden, new []{"usuario"});
                //Contiene el usuario que se ha identificado
                HttpContext.User = principal;
                //Esta propiedad dice si esta o no esta autenticado
                //HttpContext.User.Identity.IsAuthenticated
                //Este metodo pregunta que tipo de rol tiene el usuario
                //HttpContext.User.IsInRole("usuario");
                Thread.CurrentPrincipal = principal;
                //Crea la cookie cuando se auntentica
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Error", "Autenticacion Incorrecta");
            return View(model);
        }
    }
}