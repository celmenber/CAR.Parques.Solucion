using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    public class RevDetalleModel
    {
        public ReservaModel Reserva { get; set; }
        public List<DetalleReservaModelFecha> Detalle { get; set; }
    }
}
