namespace CAR.Parques.Service.WebApi.Adaptadores
{
    using AutoMapper;
    using Common.Core.BaseMapObjects;

    public class ConfiguracionApiMappers : BaseMap
    {
        private static readonly ConfiguracionApiMappers instanciaActual = new ConfiguracionApiMappers();

        public ConfiguracionApiMappers()
        {
            configuracion = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdaptadorWaParque>();
            });
        }

        public static ConfiguracionApiMappers GetInstance
        {
            get
            {
                return instanciaActual;
            }
        }
    }
}