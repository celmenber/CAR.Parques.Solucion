namespace CAR.Parques.Service.WebApi.Adaptadores.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Common.Models.Modelos.Parametricos;

    public class AdaptadorWaParametrico : AdaptadorBase
    {
        private static readonly AdaptadorWaParametrico _instanciaActual = new AdaptadorWaParametrico();

        public static AdaptadorWaParametrico Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadorWaParametrico(): base()
        {
            this.CrearMapeoEntidadModeloDepartamento();
            this.CrearMapeoEntidadModeloEstadoReserva();
            this.CrearMapeoEntidadModeloEstadoServicio();
            this.CrearMapeoEntidadModeloMunicipio();
            this.CrearMapeoEntidadModeloTipoArchivo();
            this.CrearMapeoEntidadModeloTipoContenido();
            this.CrearMapeoEntidadModeloTipoDocumento();
            this.CrearMapeoEntidadModeloTipoModulo();
            this.CrearMapeoEntidadModeloTipoServicio();
            this.CrearMapeoEntidadModeloTipoUsuario();
        }

        public void CrearMapeoEntidadModeloDepartamento()
        {
            this.CreateMap<DepartamentoEO, DepartamentoModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloEstadoReserva()
        {
            this.CreateMap<EstadoReservaEO, EstadoReservaModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloEstadoServicio()
        {
            this.CreateMap<EstadoServicioEO, EstadoServicioModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloMunicipio()
        {
            this.CreateMap<MunicipioEO, MunicipioModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoArchivo()
        {
            this.CreateMap<TipoArchivoEO, TipoArchivoModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoContenido()
        {
            this.CreateMap<TipoContenidoEO, TipoContenidoModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoDocumento()
        {
            this.CreateMap<TipoDocumentoEO, TipoDocumentoModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoModulo()
        {
            this.CreateMap<TipoModuloEO, TipoModuloModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoServicio()
        {
            this.CreateMap<TipoServicioEO, TipoServicioModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloTipoUsuario()
        {
            this.CreateMap<TipoUsuarioEO, TipoUsuarioModel>().ReverseMap();
        }
    }
}