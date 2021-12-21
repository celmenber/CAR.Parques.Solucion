namespace CAR.Parques.Data.DataTransferObjects.DTO.Reserva
{
    using System.ComponentModel.DataAnnotations;

    public class BitacoraReservaDTO
    {
        [Key]
        public int BitacoraReservaId { get; set; }
        public int ReservaId { get; set; }
        public string DetalleBitacora { get; set; }
        public string FechaBitacora { get; set; }
        public int UsuarioBitacoraId { get; set; }
    }
}
