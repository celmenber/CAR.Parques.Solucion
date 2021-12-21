namespace CAR.Parques.Common.Entities.Entidades.Usuario
{
    using System;

    public class TokenRestablecimientoEO
    {
        public int TokenId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public bool Utilizado { get; set; }
    }
}
