namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    using System.Collections.Generic;

    public class ReservaDetalleServicioModel : ReservaModel
    {
        public string NombreEstado { get; set; }
        public string UsuarioReserva { get; set; }
        public string CorreoUsuario { get; set; }
        public IEnumerable<DetalleServicioReservaModel> ListadoDetalleReserva { get; set; }
    }
}
