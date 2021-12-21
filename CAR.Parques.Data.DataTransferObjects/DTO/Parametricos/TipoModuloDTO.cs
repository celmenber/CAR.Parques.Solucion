namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoModulo")]
    public class TipoModuloDTO
    {
        [Key]
        public int TipoModuloId { get; set; }
        public string NombreTipoModulo { get; set; }
        public string DescripcionTipoModulo { get; set; }
    }
}
