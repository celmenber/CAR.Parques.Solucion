namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class EstadoReservaDTO
    {
        [Key]
        public int EstadoReservaId { get; set; }
        public string NombreEstadoReserva { get; set; }
        public string DescripcionEstadoReserva { get; set; }
    }
}
