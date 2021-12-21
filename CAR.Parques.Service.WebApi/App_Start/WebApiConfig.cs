namespace CAR.Parques.Service.WebApi
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Service.WebApi.Filters;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        //public static void RegistrarRepositorios(HttpConfiguration config, CompositionContainer container)
        //{
        //    //config.Filters.Add(
        //    //    new ControlExcepcionesAttribute(
        //    //        null
        //    //    //container.GetExportedValue<ILogManager>()
        //    //    ));
        //}
    }
}
