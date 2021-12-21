namespace CAR.Parques.Data.ObjetosTransaccion.Log
{
    using CAR.Parques.Common.Core.Utilidades;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Bitacora;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Log;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Log;
    using System;
    using System.ComponentModel.Composition;

    [Export(typeof(ITransaccionLogQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionLogQO : TransaccionBaseQO<LogTransaccion, LogSistemaDTO>, ITransaccionLogQO
    {
        public ResultadoEjecucion<bool> Insertar(LogTransaccion log)
        {
            try
            {
                var logSistema = ConfiguracionDataMapper.GetInstance.To<LogTransaccion,LogSistemaDTO>(log);
                using (context = new AppParquesContext())
                {
                    context.LogSistemaSet.Add(logSistema);
                    context.SaveChanges();
                    return new ResultadoEjecucion<bool> { Entidad = true };
                }
            }
            catch (Exception ex)
            {
                return ManejoResultado.MapearRespuestaExepcion(ex, false, 0);
            }
        }
    }
}
