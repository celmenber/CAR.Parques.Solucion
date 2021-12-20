namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Core.BaseMapObjects;

    public class ConfiguracionDataMapper : BaseMap
    {
        public static readonly ConfiguracionDataMapper instanciaActual = new ConfiguracionDataMapper();

        public ConfiguracionDataMapper()
        {
            configuracion = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdaptadorDataParque>();
            });
        }

        public static ConfiguracionDataMapper GetInstance
        {
            get
            {
                return instanciaActual;
            }
        }
    }
}
