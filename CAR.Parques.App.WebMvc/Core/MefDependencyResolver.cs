namespace CAR.Parques.App.WebMvc.Core
{
    using CAR.Parques.Common.Core.Extenciones;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Web.Http.Dependencies;

    public class MefDependencyResolver : IDependencyResolver
    {
        readonly CompositionContainer _Container;

        public MefDependencyResolver(CompositionContainer container)
        {
            _Container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            return _Container.GetExportedValueByType(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Container.GetExportedValuesByType(serviceType);
        }
    }
}