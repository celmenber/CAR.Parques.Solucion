namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    public class ReservaModel
    {
        public int ReservaId { get; set; }
        public int EstadoId { get; set; }
        public decimal PrecioTotalReserva { get; set; }
        public string FechaGeneracionReserva { get; set; }
        public string ObservacionReserva { get; set; }
        public int UsuarioReservaId { get; set; }
    }
}
