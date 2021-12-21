namespace CAR.Parques.Common.Entities.Entidades.Reserva
{
    public class DescuentoTipoUsuarioEO
    {
        public int DescuentoTipoUsuarioId { get; set; }
        public int ServicioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public decimal Descuento { get; set; }
    }
}
