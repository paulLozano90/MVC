using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPracticaVehiculos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Modificar",
                url: "item/{nombreTipo}",
                defaults: new
                {
                    controller = "Tipo",
                    action = "ModificarTipo",
                    nombre = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "BuscarVehiculo",
                url: "Vehiculo/Buscar/{idTipo}/{campo}/{contenido}",
                defaults: new
                {
                    controller = "Vehiculo",
                    action = "BuscarVehiculo",
                    nombre = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Tipo",
                                action = "IndexTipo",
                                id = UrlParameter.Optional }
            );
        }
    }
}
