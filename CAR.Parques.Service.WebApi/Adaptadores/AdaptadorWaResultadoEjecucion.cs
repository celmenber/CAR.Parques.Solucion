namespace CAR.Parques.Service.WebApi.Adaptadores
{
    using Common.Entities.Entidades.Base;
    using Common.Models.Modelos.Base;

    public class AdaptadorWaResultadoEjecucion : AdaptadorBase
    {
        private static readonly AdaptadorWaResultadoEjecucion _instanciaActual = new AdaptadorWaResultadoEjecucion();

        public static AdaptadorWaResultadoEjecucion Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadorWaResultadoEjecucion() : base()
        {
            this.CrearMapeoResultadoEjecucion();
        }

        public void CrearMapeoResultadoEjecucion()
        {
            this.CreateMap<ResultadoEjecucion, ResultadoEjecucionModel>().ReverseMap();
        }

    }
}