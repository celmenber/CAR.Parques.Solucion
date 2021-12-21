namespace CAR.Parques.Service.WebApi.Adaptadores
{
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System.Collections.Generic;

    public class AdaptadorWaParque : AdaptadorBase
    {
        private static readonly AdaptadorWaParque _instanciaActual = new AdaptadorWaParque();

        public static AdaptadorWaParque Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadorWaParque() : base()
        {
            this.CrearMapeoModeloEntidadParques();
            this.CrearMapeoModeloEntidadArchivoParque();
            this.CrearMapeoModeloEntidadServicioParque();
            this.CrearMapeoModeloEntidadParquesDetalle();
            this.CrearMapeoModeloEntidadServicioParqueDetalle();
            this.CrearMapeoModeloEntidadInformacionParque();
            this.CrearMapeoModeloEntidadParquesInformacion();
        }

        public void CrearMapeoModeloEntidadParques()
        {
            this.CreateMap<ParqueEO, ParqueModel>().ReverseMap();
        }

        public void CrearMapeoModeloEntidadParquesDetalle()
        {
            this.CreateMap<ParqueDetalleEO, ParqueInformacionModel>().ReverseMap();
        }

        public void CrearMapeoModeloEntidadArchivoParque()
        {
            this.CreateMap<ArchivoParqueEO, ArchivoParqueModel>().ReverseMap();
        }

        public void CrearMapeoModeloEntidadServicioParque()
        {
            this.CreateMap<ServicioParqueEO, ServicioParqueModel>().ReverseMap();
        }

        public void CrearMapeoModeloEntidadServicioParqueDetalle()
        {
            this.CreateMap<ServicioParqueDetalleEO, ServicioParqueDetalleModel>()
                //.ForMember(dest=> dest.ListadoDescuentos, opt => opt.MapFrom(src => ConfiguracionApiMappers.GetInstance.To<IEnumerable<DescuentoTipoUsuarioDetalleEO>, IEnumerable<DescuentoTipoUsuarioDetalleModel>>(src.ListadoDescuentos)))
                .ReverseMap();
        }

        public void CrearMapeoModeloEntidadInformacionParque()
        {
            this.CreateMap<InformacionParqueEO, InformacionParqueModel>().ReverseMap();
        }

        public void CrearMapeoModeloEntidadParquesInformacion()
        {
            this.CreateMap<ParqueInformacionEO, ParqueInformacionModel>().ReverseMap();
        }
    }
}