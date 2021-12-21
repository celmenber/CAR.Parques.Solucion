namespace CAR.Parques.Data.DataTransferObjects.DTO.Usuario
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TokenRestablecimientoDTO
    {
        [Key]
        public int TokenId { get; set; }
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public bool Utilizado { get; set; }
    }
}
