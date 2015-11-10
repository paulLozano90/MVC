using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public List<Saludo> lista = new List<Saludo>()
        {
            new Saludo() {Idioma = "Es", Texto = "Buenos dias"},
            new Saludo() {Idioma = "En", Texto = "Good morning"},
            new Saludo() {Idioma = "Fr", Texto = "Bon jour"},
            new Saludo() {Idioma = "De", Texto = "Guten morgen"}
        };

        // GET: Home
        public ActionResult Index(String id)
        {
            var data = lista.FirstOrDefault(o => o.Idioma == id);
            if (data == null)
                data = lista.First(o => o.Idioma == "Es");
            return View(data);
        }


    }
}