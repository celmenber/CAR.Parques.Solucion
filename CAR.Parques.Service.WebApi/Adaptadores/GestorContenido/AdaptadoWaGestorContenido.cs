namespace CAR.Parques.Service.WebApi.Adaptadores.GestorContenido
{
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.Common.Models.Modelos.GestorContenido;

    public class AdaptadoWaGestorContenido : AdaptadorBase
    {
        private static readonly AdaptadoWaGestorContenido _instanciaActual = new AdaptadoWaGestorContenido();
        public static AdaptadoWaGestorContenido Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadoWaGestorContenido() : base()
        {
            this.CrearMapeoEntidadModeloGestorContenido();
        }

        public void CrearMapeoEntidadModeloGestorContenido()
        {
            this.CreateMap<GestorContenidoEO, GestorContenidoModel>().ReverseMap();
        }
    }
}