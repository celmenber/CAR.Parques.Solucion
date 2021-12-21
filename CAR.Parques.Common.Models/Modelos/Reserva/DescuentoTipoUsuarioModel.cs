namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    public class DescuentoTipoUsuarioModel
    {
        public int DescuentoTipoUsuarioId { get; set; }
        public int ServicioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public decimal Descuento { get; set; }
    }
}
