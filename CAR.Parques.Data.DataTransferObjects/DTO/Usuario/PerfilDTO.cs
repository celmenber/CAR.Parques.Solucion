namespace CAR.Parques.Data.DataTransferObjects.DTO.Usuario
{
    using System.ComponentModel.DataAnnotations;

    public class PerfilDTO
    {
        [Key]
        public int PerfilId { get; set; }
        public string NombrePerfil { get; set; }
        public string DescripcionPerfil { get; set; }
    }
}
