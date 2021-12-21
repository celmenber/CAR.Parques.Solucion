namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class TipoContenidoDTO
    {
        [Key]
        public int TipoContenidoId { get; set; }
        public string NombreTipoContenido { get; set; }
        public string DescripcionTipoContenido { get; set; }
    }
}
