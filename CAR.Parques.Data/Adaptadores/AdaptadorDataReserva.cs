namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;

    public class AdaptadorDataReserva : Profile
    {
        public AdaptadorDataReserva()
        {
            this.CrearMapBitacoraReserva();
            this.CrearMapDescuentoTipoUsuario();
            this.CrearMapDetalleReserva();
            this.CrearMapReserva();
        }

        private void CrearMapBitacoraReserva()
        {
            CreateMap<BitacoraReservaEO, BitacoraReservaDTO>().ReverseMap();
        }

        private void CrearMapDescuentoTipoUsuario()
        {
            CreateMap<DescuentoTipoUsuarioEO, DescuentoTipoUsuarioDTO>().ReverseMap();
        }

        private void CrearMapDetalleReserva()
        {
            CreateMap<DetalleReservaEO, DetalleReservaDTO>().ReverseMap();
        }

        private void CrearMapReserva()
        {
            CreateMap<ReservaEO, ReservaDTO>().ReverseMap();
        }
    }
}
