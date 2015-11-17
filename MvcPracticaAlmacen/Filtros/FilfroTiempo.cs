using System;
using System.Data;
using System.Web.Mvc;

namespace MvcPracticaAlmacen.Filtros
{
    public class FilfroTiempo:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var hora = DateTime.Now;
            if (hora.Minute < 30 || hora.Minute > 40)
            {
                filterContext.Result = new HttpUnauthorizedResult
                                       ("Servicio no disponible temporalmente");

            }
            base.OnActionExecuting(filterContext);
        }
    }
}