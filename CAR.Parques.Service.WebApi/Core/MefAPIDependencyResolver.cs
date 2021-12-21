namespace CAR.Parques.Service.WebApi.Core
{
    using CAR.Parques.Common.Core.Extenciones;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Web.Http.Dependencies;

    public class MefAPIDependencyResolver : IDependencyResolver
    {
        private CompositionContainer _container;

        public MefAPIDependencyResolver(CompositionContainer container)
        {
            _container = container;
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
            return _container.GetExportedValueByType(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetExportedValuesByType(serviceType);
        }
    }
}