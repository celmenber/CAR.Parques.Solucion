namespace CAR.Parques.Data.DataTransferObjects.DTO.Reserva
{
    using System.ComponentModel.DataAnnotations;

    public class ArchivoReservaDTO
    {
        [Key]
        public int ArchivoReservaId { get; set; }
        public int ReservaId { get; set; }
        public string TituloArchivoReserva { get; set; }
        public byte[] ByteArchivo { get; set; }
    }
}
