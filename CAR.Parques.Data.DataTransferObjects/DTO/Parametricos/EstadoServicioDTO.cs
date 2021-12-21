namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class EstadoServicioDTO
    {
        [Key]
        public int EstadoServicioId { get; set; }
        public string NombreEstado { get; set; }
        public string DescripcionEstado { get; set; }
    }
}
