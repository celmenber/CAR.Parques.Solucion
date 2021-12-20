namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AdaptadorDataParametricos : Profile
    {
        public AdaptadorDataParametricos()
        {
            this.CrearMapParametricoDepartamento();
            this.CrearMapParametricoEstadoReserva();
            this.CrearMapParametricoEstadoServicio();
            this.CrearMapParametricoMunicipio();
            this.CrearMapParametricoTipoArchivo();
            this.CrearMapParametricoTipoContenido();
            this.CrearMapParametricoTipoDocumento();
            this.CrearMapParametricoTipoModulo();
            this.CrearMapParametricoTipoServicio();
            this.CrearMapParametricoTipoUsuario();
        }

        private void CrearMapParametricoDepartamento()
        {
            CreateMap<DepartamentoEO, DepartamentoDTO>().ReverseMap();
        }

        private void CrearMapParametricoEstadoReserva()
        {
            CreateMap<EstadoReservaEO, EstadoReservaDTO>().ReverseMap();
        }

        private void CrearMapParametricoEstadoServicio()
        {
            CreateMap<EstadoServicioEO, EstadoServicioDTO>().ReverseMap();
        }

        private void CrearMapParametricoMunicipio()
        {
            CreateMap<MunicipioEO, MunicipioDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoArchivo()
        {
            CreateMap<TipoArchivoEO, TipoArchivoDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoContenido()
        {
            CreateMap<TipoContenidoEO, TipoContenidoDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoDocumento()
        {
            CreateMap<TipoDocumentoEO, TipoDocumentoDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoModulo()
        {
            CreateMap<TipoModuloEO, TipoModuloDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoServicio()
        {
            CreateMap<TipoServicioEO, TipoServicioDTO>().ReverseMap();
        }

        private void CrearMapParametricoTipoUsuario()
        {
            CreateMap<TipoUsuarioEO, TipoUsuarioDTO>().ReverseMap();
        }
    }
}
