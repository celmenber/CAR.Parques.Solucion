namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido;

    public class AdaptadorDataGestorContenido : Profile
    {
        public AdaptadorDataGestorContenido()
        {
            this.CrearMapGestorContenido();
        }

        private void CrearMapGestorContenido()
        {
            CreateMap<GestorContenidoEO, GestorContenidoDTO>().ReverseMap();
        }
    }
}
