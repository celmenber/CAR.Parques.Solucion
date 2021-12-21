namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoDocumento")]
    public class TipoDocumentoDTO
    {
        [Key]
        public int TipoDocumentoId { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }
    }
}
