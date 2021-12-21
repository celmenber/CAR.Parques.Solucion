namespace CAR.Parques.Common.Models.Modelos.Parques
{
    public class ArchivoReservaModel
    {
        public int ArchivoReservaId { get; set; }
        public int ReservaId { get; set; }
        public string TituloArchivoReserva { get; set; }
        public byte[] ByteArchivo { get; set; }
    }
}
