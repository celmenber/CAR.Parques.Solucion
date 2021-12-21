namespace CAR.Parques.Data.ObjetosTransaccion.Parametricos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;
    using CAR.Parques.Data.Adaptadores;

    [Export(typeof(ITransaccionMunicipioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionMunicipioQO : TransaccionBaseQO<MunicipioEO, MunicipioDTO>, ITransaccionMunicipioQO
    {
        public ResultadoEjecucion<IEnumerable<MunicipioEO>> ConsultarMunicipiosXDepartamento(int departamentoId)
        {
            ResultadoEjecucion<IEnumerable<MunicipioEO>> resultado = new ResultadoEjecucion<IEnumerable<MunicipioEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var consulta = (from m in context.MunicipioSet
                                    where m.DepartamentoId == departamentoId
                                    select m).ToList();
                    resultado.Entidad = 
                        ConfiguracionDataMapper.GetInstance.To<IEnumerable<MunicipioDTO>, IEnumerable<MunicipioEO>>(consulta);
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Errot Consulta Municipio Por Departamento. {ex.Message}";
            }

            return resultado;
        }
    }
}
