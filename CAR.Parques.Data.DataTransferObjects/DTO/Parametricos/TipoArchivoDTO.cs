namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class TipoArchivoDTO
    {
        [Key]
        public int TipoArchivoId { get; set; }
        public string NombreTipoArchivo { get; set; }
        public string DescripcionTipoArchivo { get; set; }
        public string Extension { get; set; }
    }
}
