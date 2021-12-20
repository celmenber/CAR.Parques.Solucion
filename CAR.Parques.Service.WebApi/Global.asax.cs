namespace CAR.Parques.Service.WebApi
{
    using CAR.Parques.Business.Bootstrapper;
    using CAR.Parques.Service.WebApi.Core;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            this.LoadMefConfiguracion();
        }

        private void LoadMefConfiguracion()
        {
            var catalogo = new AggregateCatalog();
            catalogo.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var contenedor = MefLoader.Init(catalogo.Catalogs);
            GlobalConfiguration.Configuration.DependencyResolver = new MefAPIDependencyResolver(contenedor);
            this.Configurar(contenedor);
        }

        protected void Configurar(CompositionContainer contenedor)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.RegistrarRepositorios(GlobalConfiguration.Configuration, contenedor);
        }
    }
}
