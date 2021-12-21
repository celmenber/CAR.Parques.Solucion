namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    public class BitacoraReservaModel
    {
        public int BitacoraReservaId { get; set; }
        public int ReservaId { get; set; }
        public string DetalleBitacora { get; set; }
        public string FechaBitacora { get; set; }
        public int UsuarioBitacoraId { get; set; }
    }
}
