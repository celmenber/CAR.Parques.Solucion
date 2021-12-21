namespace CAR.Parques.Common.Entities.Entidades.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using System.Collections.Generic;

    public class ServicioParqueDetalleEO : ServicioParqueEO
    {
        public string EstadoServicio { get; set; }
        public string TipoServicio { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public IEnumerable<DescuentoTipoUsuarioDetalleEO> ListadoDescuentos { get; set; }
    }
}
