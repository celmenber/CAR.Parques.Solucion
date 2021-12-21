namespace CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITransaccionMunicipioQO : ITransaccionBaseQO<MunicipioEO, MunicipioDTO>
    {
        ResultadoEjecucion<IEnumerable<MunicipioEO>> ConsultarMunicipiosXDepartamento(int departamentoId);
    }
}
