namespace CAR.Parques.Data.ObjetosTransaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Export(typeof(ITransaccionDescuentoTipoUsuarioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionDescuentoTipoUsuarioQO : TransaccionBaseQO<DescuentoTipoUsuarioEO, DescuentoTipoUsuarioDTO>, ITransaccionDescuentoTipoUsuarioQO
    {
        public ResultadoEjecucion<IEnumerable<DescuentoTipoUsuarioEO>> ConsultarDescuentoTipoUsuarioxServicio(int serviciId)
        {
            ResultadoEjecucion<IEnumerable<DescuentoTipoUsuarioEO>> resultado = new ResultadoEjecucion<IEnumerable<DescuentoTipoUsuarioEO>>();
            try
            {
                using (context = new Context.AppParquesContext())
                {
                    var descuentoTipoUsuario = (from d in context.DescuentoTipoUsuarioSet
                                                where d.ServicioId == serviciId
                                                select new DescuentoTipoUsuarioEO
                                                {
                                                    Descuento = d.Descuento,
                                                    DescuentoTipoUsuarioId = d.DescuentoTipoUsuarioId,
                                                    ServicioId = d.ServicioId,
                                                    TipoUsuarioId = d.TipoUsuarioId
                                                }).ToList();
                    resultado.Entidad = descuentoTipoUsuario;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consulta descuento tipo usuario: {ex.Message}";
            }
            return resultado;
        }
    }
}
