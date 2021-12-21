namespace CAR.Parques.Data.DataTransferObjects.DTO.Usuario
{
    using System.ComponentModel.DataAnnotations;

    public class MenuDTO
    {
        [Key]
        public int MenuId { get; set; }
        public string NombreMenu { get; set; }
        public int TipoModuloId { get; set; }
        public string RutaMenu { get; set; }
        public int OrdenMenu { get; set; }
        public string DescripcionMenu { get; set; }
        public int? MenuPadreId { get; set; }
    }
}
