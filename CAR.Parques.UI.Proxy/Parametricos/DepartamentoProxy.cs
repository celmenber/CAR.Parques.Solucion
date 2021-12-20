using CAR.Parques.Common.Entities.Entidades.Base;
using CAR.Parques.Common.Models.Modelos.Parametricos;
using CAR.Parques.UI.Proxy.Contracts.Parametricos;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CAR.Parques.UI.Proxy.Parametricos
{
    [Export(typeof(IDepartamentoProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartamentoProxy : BaseProxy, IDepartamentoProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<DepartamentoModel>>> ConsultarListadoDepartamentos()
        {
            this.AsociarServicio("WaDepartamento/ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<DepartamentoModel>>>();
        }
    }
}
