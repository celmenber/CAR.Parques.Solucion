namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class TipoServicioDTO
    {
        [Key]
        public int TipoServicioId { get; set; }
        public string NombreTipoServicio { get; set; }
        public string DescripcionTipoServicio { get; set; }
    }
}
