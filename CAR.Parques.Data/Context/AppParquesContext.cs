namespace CAR.Parques.Data.Context
{
    using CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido;
    using CAR.Parques.Data.DataTransferObjects.DTO.Log;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Utilitarios;
    using CAR.Parques.Data.FluentApiMapping;
    using System.Data.Entity;

    public class AppParquesContext : DbContext
    {
        public AppParquesContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<AppParquesContext>(null);
        }

        public DbSet<ArchivoParqueDTO> ArchivoParqueSet { get; set; }
        public DbSet<ArchivoReservaDTO> ArchivoReservaSet { get; set; }
        public DbSet<BitacoraReservaDTO> BitacoraReservaSet { get; set; }
        public DbSet<DepartamentoDTO> DepartamentoSet { get; set; }
        public DbSet<DescuentoTipoUsuarioDTO> DescuentoTipoUsuarioSet { get; set; }
        public DbSet<DetalleReservaDTO> DetalleReservaSet { get; set; }
        public DbSet<EstadoReservaDTO> EstadoReservaSet { get; set; }
        public DbSet<EstadoServicioDTO> EstadoServicioSet { get; set; }
        public DbSet<GestorContenidoDTO> GestorContenidoSet { get; set; }
        public DbSet<LogSistemaDTO> LogSistemaSet { get; set; }
        public DbSet<MenuDTO> MenuSet { get; set; }
        public DbSet<MenuPerfilDTO> MenuPerfilSet { get; set; }
        public DbSet<MunicipioDTO> MunicipioSet { get; set; }
        public DbSet<ParqueDTO> ParqueSet { get; set; }
        public DbSet<PerfilDTO> PerfilSet { get; set; }
        public DbSet<ReservaDTO> ReservaSet { get; set; }
        public DbSet<ServicioParqueDTO> ServicioParqueSet { get; set; }
        public DbSet<TipoArchivoDTO> TipoArchivoSet { get; set; }
        public DbSet<TipoContenidoDTO> TipoContenidoSet { get; set; }
        public DbSet<TipoDocumentoDTO> TipoDocumentoSet { get; set; }
        public DbSet<TipoModuloDTO> TipoModuloSet { get; set; }
        public DbSet<TipoServicioDTO> TipoServicioSet { get; set; }
        public DbSet<TipoUsuarioDTO> TipoUsuarioSet { get; set; }
        public DbSet<UsuarioDTO> UsuarioSet { get; set; }
        public DbSet<LinksExternosParqueDTO> LinksExternosParqueSet { get; set; }
        public DbSet<InformacionParqueDTO> InformacionParqueSet { get; set; }
        public DbSet<PlantillasCorreoDTO> PlantillaCorreoSet { get; set; }
        public DbSet<TokenRestablecimientoDTO> TokenRestablecimientoSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            CarParquesSqlServerMapping.Configure(modelBuilder);
        }
    }
}
