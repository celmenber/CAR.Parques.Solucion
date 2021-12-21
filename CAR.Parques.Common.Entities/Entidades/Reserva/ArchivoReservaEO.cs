namespace CAR.Parques.Common.Entities.Entidades.Reserva
{
    public class ArchivoReservaEO
    {
        public int ArchivoReservaId { get; set; }
        public int ReservaId { get; set; }
        public string TituloArchivoReserva { get; set; }
        public byte[] ByteArchivo { get; set; }
    }
}
