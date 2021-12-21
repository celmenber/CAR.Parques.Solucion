namespace CAR.Parques.Common.Models.Modelos.Parques
{
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System.Collections.Generic;

    public class ServicioParqueDetalleModel : ServicioParqueModel
    {
        public string EstadoServicio { get; set; }
        public string TipoServicio { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public IEnumerable<DescuentoTipoUsuarioDetalleModel> ListadoDescuentos { get; set; }
    }
}
