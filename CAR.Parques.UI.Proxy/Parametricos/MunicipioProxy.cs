using CAR.Parques.Common.Entities.Entidades.Base;
using CAR.Parques.Common.Models.Modelos.Parametricos;
using CAR.Parques.UI.Proxy.Contracts.Parametricos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAR.Parques.UI.Proxy.Parametricos
{
    [Export(typeof(IMunicipioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MunicipioProxy : BaseProxy, IMunicipioProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<MunicipioModel>>> ConsultarListadoMunicipiosXDepto(int departamentoId)
        {
            this.AsociarServicio("WaMunicipio/ConsultarTodosPorDepartamento", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<MunicipioModel>>>(departamentoId);
        }
    }
}
