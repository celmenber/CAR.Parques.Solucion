namespace CAR.Parques.Data.DataTransferObjects.DTO.Reserva
{
    using System.ComponentModel.DataAnnotations;

    public class DescuentoTipoUsuarioDTO
    {
        [Key]
        public int DescuentoTipoUsuarioId { get; set; }
        public int ServicioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public decimal Descuento { get; set; }
    }
}
