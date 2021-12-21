namespace CAR.Parques.Data.ObjetosTransaccion.GestorContenido
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.GestorContenido;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Linq;

    [Export(typeof(ITransaccionGestorContenidoQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionGestorContenidoQO : TransaccionBaseQO<GestorContenidoEO, GestorContenidoDTO>, ITransaccionGestorContenidoQO
    {
        public ResultadoEjecucion<IEnumerable<GestorContenidoEO>> ConsultarTodosVigentes()
        {

            var resultado = new ResultadoEjecucion<IEnumerable<GestorContenidoEO>>();
            try
            {
                using (context = new AppParquesContext())
                {

                    var resultadoConsulta = context.GestorContenidoSet.Where(g => g.FechaFinVigencia >= DateTime.Now).ToList();

                    resultado.Entidad = ConfiguracionDataMapper.GetInstance
                        .To<IEnumerable<GestorContenidoDTO>, IEnumerable<GestorContenidoEO>>(resultadoConsulta);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                return resultado;
            }
        }
    }
}
