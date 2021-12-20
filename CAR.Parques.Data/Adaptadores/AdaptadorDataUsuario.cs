namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;

    public class AdaptadorDataUsuario : Profile
    {
        public AdaptadorDataUsuario()
        {
            this.CrearMapMenu();
            this.CrearMapMenuPerfil();
            this.CrearMapPerfil();
            this.CrearMapUsuario();
            this.CrearTokenRestablecimiento();
        }

        private void CrearMapMenu()
        {
            CreateMap<MenuEO, MenuDTO>().ReverseMap();
        }

        private void CrearMapMenuPerfil()
        {
            CreateMap<MenuPerfilEO, MenuPerfilDTO>().ReverseMap();
        }

        private void CrearMapPerfil()
        {
            CreateMap<PerfilEO, PerfilDTO>().ReverseMap();
        }

        private void CrearMapUsuario()
        {
            CreateMap<UsuarioEO, UsuarioDTO>().ReverseMap();
        }

        private void CrearTokenRestablecimiento()
        {
            CreateMap<TokenRestablecimientoEO, TokenRestablecimientoDTO>().ReverseMap();
        }
    }
}
