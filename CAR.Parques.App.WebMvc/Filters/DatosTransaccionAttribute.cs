namespace CAR.Parques.App.WebMvc.Filters
{
    using CAR.Parques.App.WebMvc.Controllers.Api;
    using CAR.Parques.UI.Proxy.Contracts;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class DatosTransaccionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var enumerable = actionContext.ControllerContext.Controller as BaseApiController;
            if (enumerable == null)
            {
                return;
            }

            foreach (var proxy in enumerable.Proxies)
            {
                this.AsignarHeaders(proxy, actionContext.Request.Headers);
            }
        }

        public void AsignarHeaders(IBaseProxy proxy, HttpRequestHeaders headers)
        {
            if (proxy == null || proxy.Headers == null || headers == null)
            {
                throw new ArgumentException();
            }

            proxy.Headers["UsuarioId"] = ObtenerValorCabecera(headers, "UsuarioId");
            proxy.Headers["MenuId"] = ObtenerValorCabecera(headers, "MenuId");
        }

        private static string ObtenerValorCabecera(HttpRequestHeaders headers, string claveCabecera)
        {
            return headers.Contains(claveCabecera) ? headers.GetValues(claveCabecera).FirstOrDefault() : string.Empty;
        }
    }
}