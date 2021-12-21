namespace CAR.Parques.Data.ObjetosTransaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using CAR.Parques.Data.Adaptadores;

    [Export(typeof(ITransaccionReservaQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionReservaQO : TransaccionBaseQO<ReservaEO, ReservaDTO>, ITransaccionReservaQO
    {
        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin)
        {
            ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> resultado = new ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>>();
            DateTime fechaInicial = (fechaIncio != "NA" ? DateTime.ParseExact(fechaIncio, "ddMMyyyy", CultureInfo.InvariantCulture) : DateTime.Now);
            DateTime fechaFinal = (fechaFin != "NA" ? DateTime.ParseExact(fechaFin, "ddMMyyyy", CultureInfo.InvariantCulture) : DateTime.Now);
            try
            {
                using (context = new AppParquesContext())
                {
                    var reservaDetalle = (from r in context.ReservaSet
                                          join u in context.UsuarioSet on r.UsuarioReservaId equals u.UsuarioId
                                          join e in context.EstadoReservaSet on r.EstadoId equals e.EstadoReservaId
                                          where r.EstadoId == (estadoId != 0 ? estadoId : r.EstadoId)
                                          select new ReservaDetalleServicioEO
                                          {
                                              CorreoUsuario = u.Email,
                                              EstadoId = r.EstadoId,
                                              FechaGeneracionReserva = r.FechaGeneracionReserva,
                                              NombreEstado = e.NombreEstadoReserva,
                                              ObservacionReserva = r.ObservacionReserva,
                                              PrecioTotalReserva = r.PrecioTotalReserva,
                                              UsuarioReserva = u.Nombre1 + " " + u.Apellido1,
                                              ReservaId = r.ReservaId,
                                              UsuarioReservaId = r.UsuarioReservaId,
                                              ListadoDetalleReserva = (from dr in context.DetalleReservaSet
                                                                       join s in context.ServicioParqueSet on dr.ServicioId equals s.ServicioParqueId
                                                                       join p in context.ParqueSet on s.ParqueId equals p.ParqueId
                                                                       join ts in context.TipoServicioSet on s.TipoServicioId equals ts.TipoServicioId
                                                                       where dr.ReservaId == r.ReservaId
                                                                       && s.ParqueId == (parqueId != 0 ? parqueId : s.ParqueId)
                                                                       select new DetalleServicioReservaEO
                                                                       {
                                                                           DetalleReservaId = dr.DetalleReservaId,
                                                                           ReservaId = dr.ReservaId,
                                                                           ServicioId = dr.ServicioId,
                                                                           Cantidad = dr.Cantidad,
                                                                           AdquirioServicio = dr.AdquirioServicio,
                                                                           FechaInicio = dr.FechaInicio,
                                                                           FechaFin = dr.FechaFin,
                                                                           PrecioTotalServicio = dr.PrecioTotalServicio,
                                                                           PrecioTotalDescuento = dr.PrecioTotalDescuento,
                                                                           NombreServicio = s.NombreServicioParque,
                                                                           NombreParque = p.NombreParque,
                                                                           TipoServicio = ts.NombreTipoServicio
                                                                       })//.ToList()
                                                                       .Where(x => (x.FechaInicio >= (fechaIncio != "NA" ? fechaInicial : x.FechaInicio)
                                                                       && (x.FechaFin <= (fechaIncio != "NA" ? fechaFinal : x.FechaFin))))
                                          }).ToList();
                    resultado.Entidad = reservaDetalle;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consultar reservas detalle servicios parque: {ex.Message}";
            }
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<DetalleReservaEO>> CrearDetalleReservas(int DetalleReservaId, int ReservaId,  int ServicioId,  string fechaIncio, string fechaFin, decimal PrecioTotalServicio, decimal PrecioTotalDescuento, bool AdquirioServicio, int cantidad)
        {
            ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> resultado = new ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>>();
            DateTime fechaInicial = (fechaIncio != "NA" ? DateTime.ParseExact(fechaIncio, "ddMMyyyy", CultureInfo.InvariantCulture) : DateTime.Now);
            DateTime fechaFinal = (fechaFin != "NA" ? DateTime.ParseExact(fechaFin, "ddMMyyyy", CultureInfo.InvariantCulture) : DateTime.Now);
            try
            {
                using (context = new AppParquesContext())
                {
                   
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error guardando el detalle reservas detalle servicios parque: {ex.Message}";
            }
            return null;
        }

        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId)
        {
            return ConsultarReservasUsuario(usuarioId, 0);            
        }

        public ResultadoEjecucion<ReservaDetalleServicioEO> ConsultarReservaUsuario(int reservaId) {
            var resultado = new ResultadoEjecucion<ReservaDetalleServicioEO>();

            try
            {
                using (context = new AppParquesContext())
                {
                    var reservaDetalle = (from r in context.ReservaSet
                                          join u in context.UsuarioSet on r.UsuarioReservaId equals u.UsuarioId                                          
                                          where r.ReservaId == reservaId
                                          select new ReservaDetalleServicioEO
                                          {
                                              CorreoUsuario = u.Email,
                                              EstadoId = r.EstadoId,
                                              FechaGeneracionReserva = r.FechaGeneracionReserva,                                              
                                              ObservacionReserva = r.ObservacionReserva,
                                              PrecioTotalReserva = r.PrecioTotalReserva,
                                              UsuarioReserva = u.Nombre1 + " " + u.Apellido1,
                                              ReservaId = r.ReservaId,
                                              UsuarioReservaId = r.UsuarioReservaId,                                              
                                          }).FirstOrDefault();
                    resultado.Entidad = reservaDetalle;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consultar reserva usuario: {ex.Message}";
            }
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId, int estadoId)
        {
            var resultado = new ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>>();

            try
            {
                using (context = new AppParquesContext())
                {
                    var reservaDetalle = (from r in context.ReservaSet
                                          join u in context.UsuarioSet on r.UsuarioReservaId equals u.UsuarioId
                                          join e in context.EstadoReservaSet on r.EstadoId equals e.EstadoReservaId
                                          where r.UsuarioReservaId == usuarioId && (r.EstadoId == (estadoId != 0 ? estadoId : r.EstadoId))
                                          select new ReservaDetalleServicioEO
                                          {
                                              CorreoUsuario = u.Email,
                                              EstadoId = r.EstadoId,
                                              FechaGeneracionReserva = r.FechaGeneracionReserva,
                                              NombreEstado = e.NombreEstadoReserva,
                                              ObservacionReserva = r.ObservacionReserva,
                                              PrecioTotalReserva = r.PrecioTotalReserva,
                                              UsuarioReserva = u.Nombre1 + " " + u.Apellido1,
                                              ReservaId = r.ReservaId,
                                              UsuarioReservaId = r.UsuarioReservaId,
                                              ListadoDetalleReserva = (from dr in context.DetalleReservaSet
                                                                       join s in context.ServicioParqueSet on dr.ServicioId equals s.ServicioParqueId
                                                                       join p in context.ParqueSet on s.ParqueId equals p.ParqueId
                                                                       join ts in context.TipoServicioSet on s.TipoServicioId equals ts.TipoServicioId
                                                                       where dr.ReservaId == r.ReservaId
                                                                       select new DetalleServicioReservaEO
                                                                       {
                                                                           DetalleReservaId = dr.DetalleReservaId,
                                                                           ReservaId = dr.ReservaId,
                                                                           ServicioId = dr.ServicioId,
                                                                           Cantidad = dr.Cantidad,
                                                                           AdquirioServicio = dr.AdquirioServicio,
                                                                           FechaInicio = dr.FechaInicio,
                                                                           FechaFin = dr.FechaFin,
                                                                           PrecioTotalServicio = dr.PrecioTotalServicio,
                                                                           PrecioTotalDescuento = dr.PrecioTotalDescuento,
                                                                           NombreServicio = s.NombreServicioParque,
                                                                           NombreParque = p.NombreParque,
                                                                           TipoServicio = ts.NombreTipoServicio
                                                                       }).ToList()
                                          }).ToList();
                    resultado.Entidad = reservaDetalle;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consultar reservas usuario: {ex.Message}";
            }
            return resultado;
        }
    }
}
