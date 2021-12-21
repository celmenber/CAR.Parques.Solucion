namespace CAR.Parques.Data.FluentApiMapping
{
    using CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido;
    using CAR.Parques.Data.DataTransferObjects.DTO.Log;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Utilitarios;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Runtime.Serialization;

    public class CarParquesSqlServerMapping
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<ExtensionDataObject>();
            MapArchivoParque(modelBuilder);
            MapArchivoReserva(modelBuilder);
            MapBitacoraReserva(modelBuilder);
            MapDepartamento(modelBuilder);
            MapDescuentoTipoUsuario(modelBuilder);
            MapDetalleReserva(modelBuilder);
            MapEstadoReserva(modelBuilder);
            MapEstadoServicio(modelBuilder);
            MapGestorContenido(modelBuilder);
            MapLogSistema(modelBuilder);
            MapMenu(modelBuilder);
            MapMenuPerfil(modelBuilder);
            MapMunicipio(modelBuilder);
            MapParque(modelBuilder);
            MapPerfil(modelBuilder);
            MapReserva(modelBuilder);
            MapServicioParque(modelBuilder);
            MapTipoArchivo(modelBuilder);
            MapTipoContenido(modelBuilder);
            MapTipoDocumento(modelBuilder);
            MapTipoServicio(modelBuilder);
            MapTipoUsuario(modelBuilder);
            MapUsuario(modelBuilder);
            MapLinksExternosParque(modelBuilder);
            MapInformacionParque(modelBuilder);
            MapPlantillaParque(modelBuilder);
            MapTokenRestablecimiento(modelBuilder);
        }

        public static void MapArchivoParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchivoParqueDTO>()
                .ToTable("ArchivoParque")
                .HasKey(p => p.ArchivoParqueId);
        }

        public static void MapArchivoReserva(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchivoReservaDTO>()
                .ToTable("ArchivoReserva")
                .HasKey(p => p.ArchivoReservaId);
        }

        public static void MapBitacoraReserva(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitacoraReservaDTO>()
                .ToTable("BitacoraReserva")
                .HasKey(p => p.BitacoraReservaId);
        }

        public static void MapDepartamento(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartamentoDTO>()
                .ToTable("Departamento")
                .HasKey(p => p.DepartamentoId);
        }

        public static void MapDescuentoTipoUsuario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DescuentoTipoUsuarioDTO>()
                .ToTable("DescuentoTipoUsuario")
                .HasKey(p => p.DescuentoTipoUsuarioId);
        }

        public static void MapDetalleReserva(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleReservaDTO>()
                .ToTable("DetalleReserva")
                .HasKey(p => p.DetalleReservaId);
        }

        public static void MapEstadoReserva(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoReservaDTO>()
                .ToTable("EstadoReserva")
                .HasKey(p => p.EstadoReservaId);
        }

        public static void MapEstadoServicio(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoServicioDTO>()
                .ToTable("EstadoServicio")
                .HasKey(p => p.EstadoServicioId);
        }

        public static void MapGestorContenido(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GestorContenidoDTO>()
                .ToTable("GestorContenido")
                .HasKey(p => p.ContenidoId);
        }

        public static void MapLogSistema(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogSistemaDTO>()
                .ToTable("LogSistema")
                .HasKey(p => p.LogSistemaId);
        }

        public static void MapMenu(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuDTO>()
                .ToTable("Menu")
                .HasKey(p => p.MenuId);
        }

        public static void MapMenuPerfil(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuPerfilDTO>()
                .ToTable("MenuPerfil")
                .HasKey(p => p.MenuPerfilId);
        }

        public static void MapMunicipio(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipioDTO>()
                .ToTable("Municipio")
                .HasKey(p => p.MunicipioId);
        }

        public static void MapParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParqueDTO>()
                .ToTable("Parque")
                .HasKey(p => p.ParqueId);
        }

        public static void MapPerfil(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilDTO>()
                .ToTable("Perfil")
                .HasKey(p => p.PerfilId);
        }

        public static void MapReserva(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservaDTO>()
                .ToTable("Reserva")
                .HasKey(p => p.ReservaId);
        }

        public static void MapServicioParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicioParqueDTO>()
                .ToTable("ServicioParque")
                .HasKey(p => p.ServicioParqueId);
        }

        public static void MapTipoArchivo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoArchivoDTO>()
                .ToTable("TipoArchivo")
                .HasKey(p => p.TipoArchivoId);
        }

        public static void MapTipoContenido(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoContenidoDTO>()
                .ToTable("TipoContenido")
                .HasKey(p => p.TipoContenidoId);
        }

        public static void MapTipoDocumento(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumentoDTO>()
                .ToTable("TipoDocumento")
                .HasKey(p => p.TipoDocumentoId);
        }

        public static void MapTipoModulo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoModuloDTO>()
                .ToTable("TipoModulo")
                .HasKey(p => p.TipoModuloId);
        }

        public static void MapTipoServicio(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoServicioDTO>()
                .ToTable("TipoServicio")
                .HasKey(p => p.TipoServicioId);
        }

        public static void MapTipoUsuario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuarioDTO>()
                .ToTable("TipoUsuario")
                .HasKey(p => p.TipoUsuarioId);
        }

        public static void MapUsuario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDTO>()
                .ToTable("Usuario")
                .HasKey(p => p.UsuarioId);
        }

        public static void MapLinksExternosParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinksExternosParqueDTO>()
                .ToTable("LinksExternosParque")
                .HasKey(p => p.LinkId);
        }

        public static void MapInformacionParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InformacionParqueDTO>()
                .ToTable("InformacionParque")
                .HasKey(p => p.InformacionId);
        }

        public static void MapPlantillaParque(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantillasCorreoDTO>()
                .ToTable("PlantillasCorreo")
                .HasKey(p => p.CorreoId);
        }

        public static void MapTokenRestablecimiento(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TokenRestablecimientoDTO>()
                .ToTable("TokenRestablecimiento")
                .HasKey(p => p.TokenId);
        }
    }
}
