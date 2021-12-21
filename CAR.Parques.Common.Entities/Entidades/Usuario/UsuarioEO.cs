namespace CAR.Parques.Common.Entities.Entidades.Usuario
{
    public class UsuarioEO
    {
        public int UsuarioId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Documento { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public int PerfilId { get; set; }
        public string PasswordUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
