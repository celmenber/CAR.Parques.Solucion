namespace CAR.Parques.Common.Entities.Entidades.Reserva
{
    using System.Collections.Generic;

    public class ReservaDetalleServicioEO : ReservaEO
    {
        public string NombreEstado { get; set; }
        public string UsuarioReserva { get; set; }
        public string CorreoUsuario { get; set; }
        public IEnumerable<DetalleServicioReservaEO> ListadoDetalleReserva { get; set; }
    }
}
