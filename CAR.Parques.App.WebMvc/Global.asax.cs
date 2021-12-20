namespace CAR.Parques.App.WebMvc
{
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using UI.Proxy.Bootstrapper;
    using WebMvc.Core;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            this.LoadMefConfiguration();            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void LoadMefConfiguration()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = MefLoaderProxy.Init(catalog.Catalogs);
            GlobalConfiguration.Configuration.DependencyResolver = new MefDependencyResolver(container);
            Configurar(container);
        }

        private static void Configurar(CompositionContainer container)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.RegistrarRepositorios(GlobalConfiguration.Configuration, container);
        }
    }
}
