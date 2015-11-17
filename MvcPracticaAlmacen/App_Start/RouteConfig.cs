using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcPracticaAlmacen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //producto tiene que ir con la p minuscula
            //la url tiene que ser UNICO la primera parte ITEM/...
            routes.MapRoute(
                name: "Detalle",
                url: "item/{nombreProducto}",
                defaults: new
                {
                    controller = "Producto",
                    action = "DetalleProducto",
                    nombre = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto",
                                action = "IndexProducto",
                                id = UrlParameter.Optional
                }
            );
        }
    }
}
