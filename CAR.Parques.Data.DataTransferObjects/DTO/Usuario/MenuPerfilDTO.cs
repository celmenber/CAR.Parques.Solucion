namespace CAR.Parques.Data.DataTransferObjects.DTO.Usuario
{
    using System.ComponentModel.DataAnnotations;

    public class MenuPerfilDTO
    {
        [Key]
        public int MenuPerfilId { get; set; }
        public int MenuId { get; set; }
        public int PerfilId { get; set; }
    }
}
