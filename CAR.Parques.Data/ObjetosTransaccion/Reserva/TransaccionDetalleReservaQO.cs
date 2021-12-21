namespace CAR.Parques.Data.ObjetosTransaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Enums.Reservas;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionDetalleReservaQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionDetalleReservaQO : TransaccionBaseQO<DetalleReservaEO, DetalleReservaDTO>, ITransaccionDetalleReservaQO
    {
        public ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva)
        {
            var resultado = new ResultadoEjecucion<int>();
            try
            {
                using (context = new AppParquesContext())
                {                    
                    var servicio = context.ServicioParqueSet.FirstOrDefault(s => s.ServicioParqueId == detalleReserva.ServicioId);

                    List<DetalleReservaDTO> detallesReserva = (from r in context.ReservaSet
                                                               join de in context.DetalleReservaSet on r.ReservaId equals de.ReservaId                                                               
                                                               where de.ServicioId == detalleReserva.ServicioId
                                                               && (r.EstadoId != (int)EEstadoReserva.Rechazado && r.EstadoId != (int)EEstadoReserva.RechadoPorVencimiento)
                                                               && de.FechaInicio >= detalleReserva.FechaInicio && de.FechaFin <= detalleReserva.FechaFin
                                                               select de).ToList();

                    int cantidadReservada = detallesReserva.Sum(dr => dr.Cantidad);
                    resultado.Entidad = cantidadReservada;// (servicio.Cantidad >= (cantidadReservada + detalleReserva.Cantidad));
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Consulta Validaciones Preservas: {ex.Message}";
            }

            return resultado;
        }
    }
}
