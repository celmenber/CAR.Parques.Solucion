namespace CAR.Parques.Service.WebApi.Adaptadores.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System;

    public class AdaptadorWaReserva : AdaptadorBase
    {
        private static readonly AdaptadorWaReserva _instanciaActual = new AdaptadorWaReserva();

        public static AdaptadorWaReserva Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadorWaReserva(): base()
        {
            this.CrearMapeoEntidadModeloBitacoraReserva();
            this.CrearMapeoEntidadModeloDescuentoTipoUsuario();
            this.CrearMapeoEntidadModeloDetalleReserva();
            this.CrearMapeoEntidadModeloReserva();
            this.CrearMapeoEntidadModeloDescuentoTipoUsuarioDetalle();
            this.CrearMapeoReservaDetalleServicio();
            this.CrearMapeoEntidadModeloDetalleReservaFecha();
        }

        public void CrearMapeoEntidadModeloBitacoraReserva()
        {
            this.CreateMap<BitacoraReservaEO, BitacoraReservaModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloDescuentoTipoUsuario()
        {
            this.CreateMap<DescuentoTipoUsuarioEO, DescuentoTipoUsuarioModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloDescuentoTipoUsuarioDetalle()
        {
            this.CreateMap<DescuentoTipoUsuarioDetalleEO, DescuentoTipoUsuarioDetalleModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloDetalleReserva()
        {
            this.CreateMap<DetalleReservaEO, DetalleReservaModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloDetalleReservaFecha()
        {
            this.CreateMap<DetalleReservaModelFecha, DetalleReservaEO>().ForMember(x =>  x.FechaInicio.ToString(), y=> y.MapFrom(src => Convert.ToDateTime(src.FechaInicio)))
                .ForMember(x => x.FechaFin.ToString(), y => y.MapFrom(src => Convert.ToDateTime(src.FechaFin)))
                .ReverseMap();
        }

        public void CrearMapeoEntidadModeloReserva()
        {
            this.CreateMap<ReservaEO, ReservaModel>().ReverseMap();
        }

        public void CrearMapeoReservaDetalleServicio()
        {
            this.CreateMap<ReservaDetalleServicioEO, ReservaDetalleServicioModel>().ReverseMap();
        }
    }
}