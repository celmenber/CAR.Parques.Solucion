using CAR.Parques.Common.Entities.Entidades.Base;
using CAR.Parques.Common.Models.Modelos.Parametricos;
using CAR.Parques.UI.Proxy.Contracts.Parametricos;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CAR.Parques.UI.Proxy.Parametricos
{
    [Export(typeof(IEstadoServicioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EstadoServicioProxy : BaseProxy, IEstadoServicioProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<EstadoServicioModel>>> ConsultarListadoEstadoServicio()
        {
            this.AsociarServicio("WaEstadoServicio/ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<EstadoServicioModel>>>();
        }
    }
}
