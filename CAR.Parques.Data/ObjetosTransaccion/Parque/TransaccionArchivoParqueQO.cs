namespace CAR.Parques.Data.ObjetosTransaccion.Parque
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parque;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionArchivoParqueQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionArchivoParqueQO : TransaccionBaseQO<ArchivoParqueEO, ArchivoParqueDTO>, ITransaccionArchivoParqueQO
    {
        public ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId)
        {
            ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> resultado = new ResultadoEjecucion<IEnumerable<ArchivoParqueEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var queryArchivoParqueList = (from a in context.ArchivoParqueSet
                                                  where a.ParqueId == parqueId                                                  
                                                  select a);

                    if (tipoArchivoId != 0) {
                        queryArchivoParqueList = queryArchivoParqueList.Where(a => a.TipoArchivoId == tipoArchivoId);
                    }

                    var archivoParqueList = queryArchivoParqueList.ToList();

                    resultado.Entidad = ConfiguracionDataMapper.GetInstance
                        .To<IEnumerable<ArchivoParqueDTO>, IEnumerable<ArchivoParqueEO>>(archivoParqueList).ToList();
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consulta archivo parque: {ex.Message}";
            }
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<TipoArchivoEO>> ConsultarTiposArchivo()
        {
            var resultado = new ResultadoEjecucion<IEnumerable<TipoArchivoEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var consultaTiposArchivo = (from ta in context.TipoArchivoSet
                                                select ta).ToList();

                    resultado.Entidad = ConfiguracionDataMapper.GetInstance
                        .To<IEnumerable<TipoArchivoDTO>, IEnumerable<TipoArchivoEO>>(consultaTiposArchivo).ToList();
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error consulta tipos archivo: {ex.Message}";
            }
            return resultado;            
        }
    }
}
