namespace CAR.Parques.Business.Bootstrapper
{
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Core.Utilidades;
    using CAR.Parques.Data.ObjetosTransaccion.Parque;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    public static class MefLoader
    {
        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogoPartes)
        {
            var catalogo = new AggregateCatalog();
            //catalogo.Catalogs.Add(new AssemblyCatalog(typeof(SmtpEmail).Assembly));
            catalogo.Catalogs.Add(new AssemblyCatalog(typeof(TransaccionParqueQO).Assembly));
            catalogo.Catalogs.Add(new AssemblyCatalog(typeof(ManagerBase).Assembly));

            if (catalogoPartes != null)
            {
                foreach (var parte in catalogoPartes)
                {
                    catalogo.Catalogs.Add(parte);
                }
            }

            var contenedor = new CompositionContainer(catalogo);
            return contenedor;
        }
    }
}
