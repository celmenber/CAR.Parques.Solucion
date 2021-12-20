namespace CAR.Parques.UI.Proxy.Bootstrapper
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;

    public static class MefLoaderProxy
    {
        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogParts)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(BaseProxy).Assembly));
            if (catalogParts != null)
            {
                foreach (var part in catalogParts)
                {
                    catalog.Catalogs.Add(part);
                }
            }

            var container = new CompositionContainer(catalog);
            return container;
        }
    }
}
