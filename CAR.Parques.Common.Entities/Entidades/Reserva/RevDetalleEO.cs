using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR.Parques.Common.Entities.Entidades.Reserva
{
    public class RevDetalleEO
    {
        public ReservaEO Reserva { get; set; }
        public List<DetalleReservaEO> Detalle { get; set; }
    }
}
