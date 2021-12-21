namespace CAR.Parques.Data.ObjetosTransaccion.Parque
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parque;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionServicioParqueQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionServicioParqueQO : TransaccionBaseQO<ServicioParqueEO, ServicioParqueDTO>, ITransaccionServicioParqueQO
    {
        public ResultadoEjecucion<ServicioParqueDetalleEO> ConsultarServicioParquesDetalleXId(int servicioParqueId)
        {
            ResultadoEjecucion<ServicioParqueDetalleEO> resultado = new ResultadoEjecucion<ServicioParqueDetalleEO>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var parque = (from sp in context.ServicioParqueSet
                                  join e in context.EstadoServicioSet on sp.EstadoServicioId equals e.EstadoServicioId
                                  join ts in context.TipoServicioSet on sp.TipoServicioId equals ts.TipoServicioId
                                  join u in context.UsuarioSet on sp.CreadoPorUsuarioId equals u.UsuarioId
                                  where sp.ServicioParqueId == servicioParqueId
                                  select new ServicioParqueDetalleEO
                                  {
                                      CreadoPorUsuarioId = sp.CreadoPorUsuarioId,
                                      DescripcionServicioParque = sp.DescripcionServicioParque,
                                      EstadoServicio = e.NombreEstado,
                                      EstadoServicioId = sp.EstadoServicioId,
                                      FechaCreacion = sp.FechaCreacion,
                                      ImpuestoServicio = sp.ImpuestoServicio,
                                      ListadoDescuentos = (from dtu in context.DescuentoTipoUsuarioSet
                                                           where dtu.ServicioId == sp.ServicioParqueId
                                                           join tu in context.TipoUsuarioSet on dtu.TipoUsuarioId equals tu.TipoUsuarioId
                                                           select new DescuentoTipoUsuarioDetalleEO
                                                           {
                                                               DescuentoTipoUsuarioId = dtu.DescuentoTipoUsuarioId,
                                                               Descuento = dtu.Descuento,
                                                               ServicioId = dtu.ServicioId,
                                                               TipoUsuarioId = dtu.TipoUsuarioId,
                                                               TipoUsuario = tu.NombreTipoUsuario
                                                           }),
                                      NombreServicioParque = sp.NombreServicioParque,
                                      ParqueId = sp.ParqueId,
                                      PrecioServicio = sp.PrecioServicio,
                                      ServicioParqueId = sp.ServicioParqueId,
                                      TipoServicio = ts.NombreTipoServicio,
                                      TipoServicioId = sp.TipoServicioId,
                                      UsuarioCreacionNombre = u.Nombre1 + " " + u.Apellido1
                                  }).FirstOrDefault();
                    resultado.Entidad = parque;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Consulta Servicio Parque Detalle X Id: {ex.Message}";
            }

            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>> ConsultarServiciosParque(int parqueId)
        {
            ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>> resultado = new ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>>();
            try
            {
                using (context = new Context.AppParquesContext())
                {
                    var servicioParque = (from s in context.ServicioParqueSet
                                           join u in context.UsuarioSet on s.CreadoPorUsuarioId equals u.UsuarioId
                                           join es in context.EstadoServicioSet on s.EstadoServicioId equals es.EstadoServicioId
                                           join ts in context.TipoServicioSet on s.TipoServicioId equals ts.TipoServicioId
                                           where s.ParqueId == parqueId
                                          select new ServicioParqueDetalleEO
                                          {
                                              CreadoPorUsuarioId = s.CreadoPorUsuarioId,
                                              UsuarioCreacionNombre = u.Nombre1 + " " + u.Apellido1,
                                              DescripcionServicioParque = s.DescripcionServicioParque,
                                              EstadoServicio = es.NombreEstado,
                                              EstadoServicioId = s.EstadoServicioId,
                                              FechaCreacion = s.FechaCreacion,
                                              ImpuestoServicio = s.ImpuestoServicio,
                                              NombreServicioParque = s.NombreServicioParque,
                                              ParqueId = s.ParqueId,
                                              PrecioServicio = s.PrecioServicio,
                                              ServicioParqueId = s.ServicioParqueId,
                                              TipoServicioId = s.TipoServicioId,
                                              TipoServicio = ts.NombreTipoServicio,
                                              ListadoDescuentos = (from dtu in context.DescuentoTipoUsuarioSet
                                                                   where dtu.ServicioId == s.ServicioParqueId
                                                                   join tu in context.TipoUsuarioSet on dtu.TipoUsuarioId equals tu.TipoUsuarioId
                                                                   select new DescuentoTipoUsuarioDetalleEO
                                                                   {
                                                                       DescuentoTipoUsuarioId = dtu.DescuentoTipoUsuarioId,
                                                                       Descuento = dtu.Descuento,
                                                                       ServicioId = dtu.ServicioId,
                                                                       TipoUsuarioId = dtu.TipoUsuarioId,
                                                                       TipoUsuario = tu.NombreTipoUsuario
                                                                       /*TipoUsuarioEO = new TipoUsuarioEO
                                                                       {
                                                                           TipoUsuarioId = tu.TipoUsuarioId,
                                                                           NombreTipoUsuario = tu.NombreTipoUsuario,
                                                                           DescripcionTipoUsuario = tu.DescripcionTipoUsuario
                                                                       }*/
                                                                   })
                                          }).ToList();
                    resultado.Entidad = servicioParque;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consulta servicios parque: {ex.Message}";
            }

            return resultado;
        }
    }
}
