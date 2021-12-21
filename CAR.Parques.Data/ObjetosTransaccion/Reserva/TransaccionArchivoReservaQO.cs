namespace CAR.Parques.Data.ObjetosTransaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionArchivoReservaQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionArchivoReservaQO : TransaccionBaseQO<ArchivoReservaEO, ArchivoReservaDTO>, ITransaccionArchivoReservaQO
    {
        public ResultadoEjecucion<ArchivoReservaEO> ConsultarArchivoReserva(int reservaId)
        {
            var resultado = new ResultadoEjecucion<ArchivoReservaEO>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var archivoReserva = context.ArchivoReservaSet.FirstOrDefault(a => a.ReservaId == reservaId);

                    resultado.Entidad = ConfiguracionDataMapper.GetInstance
                        .To<ArchivoReservaDTO, ArchivoReservaEO>(archivoReserva);
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consulta archivo reserva por reservaId: {ex.Message}";
            }
            return resultado;            
        }
    }
}
