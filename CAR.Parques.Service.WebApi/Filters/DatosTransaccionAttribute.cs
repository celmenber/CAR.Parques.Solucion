namespace CAR.Parques.Service.WebApi.Filters
{
    using Business.Contract.ManagerContracts.Base;
    using Service.WebApi.Core;
    using System;
    using System.Net.Http.Headers;
    using System.Linq;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class DatosTransaccionInfoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var enumerable = actionContext.ControllerContext.Controller as ApiControllerBase;
            if (enumerable == null)
            {
                return;
            }

            foreach (var servicio in enumerable.Services)
            {
                this.AsignarHeader(servicio, actionContext.Request.Headers);
            }
        }

        public void AsignarHeader(IBaseServicioManager servicio, HttpRequestHeaders headers)
        {
            if (servicio == null || servicio.DatosTransaccion == null || headers == null)
            {
                throw new ArgumentException("La petición no cuenta con las cabeceras requeridas para la ejecución.");
            }

            servicio.DatosTransaccion.UsuarioId = Convert.ToInt32(ObtenerValorCabecera(headers, "UsuarioId"));
            servicio.DatosTransaccion.MenuId = Convert.ToInt32(ObtenerValorCabecera(headers, "MenuId"));
        }

        public static string ObtenerValorCabecera(HttpRequestHeaders headers, string nombreCabecera)
        {
            return headers.Contains(nombreCabecera) ? 
                headers.GetValues(nombreCabecera).FirstOrDefault() : string.Empty;
        }
    }
}