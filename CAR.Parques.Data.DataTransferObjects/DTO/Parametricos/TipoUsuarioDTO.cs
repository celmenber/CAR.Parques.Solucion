namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class TipoUsuarioDTO
    {
        [Key]
        public int TipoUsuarioId { get; set; }
        public string NombreTipoUsuario { get; set; }
        public string DescripcionTipoUsuario { get; set;}
    }
}
