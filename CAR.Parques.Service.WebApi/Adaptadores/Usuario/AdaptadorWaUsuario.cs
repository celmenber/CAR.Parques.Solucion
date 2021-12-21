namespace CAR.Parques.Service.WebApi.Adaptadores.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AdaptadorWaUsuario : AdaptadorBase
    {
        private static readonly AdaptadorWaUsuario _instanciaActual = new AdaptadorWaUsuario();

        public static AdaptadorWaUsuario Instancia
        {
            get
            {
                return _instanciaActual;
            }
        }

        public AdaptadorWaUsuario() : base()
        {
            this.CrearMapeoEntidadModeloMenu();
            this.CrearMapeoEntidadModeloMenuPerfil();
            this.CrearMapeoEntidadModeloPerfil();
            this.CrearMapeoEntidadModeloUsuario();
            this.CrearMapeoEntidadModeloUsuarioDetalle();
        }

        public void CrearMapeoEntidadModeloMenu()
        {
            this.CreateMap<MenuEO, MenuModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloMenuPerfil()
        {
            this.CreateMap<MenuPerfilEO, MenuPerfilModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloPerfil()
        {
            this.CreateMap<PerfilEO, PerfilModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloUsuario()
        {
            this.CreateMap<UsuarioEO, UsuarioModel>().ReverseMap();
        }

        public void CrearMapeoEntidadModeloUsuarioDetalle()
        {
            this.CreateMap<UsuarioDetalleEO, UsuarioDetalleModel>().ReverseMap();
        }
    }
}