namespace CAR.Parques.UI.Proxy.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IEstadoReservaProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EstadoReservaProxy : BaseProxy, IEstadoReservaProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<EstadoReservaModel>>> ConsultarListadoEstadoReservas()
        {
            this.AsociarServicio("WaEstadoReserva/ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<EstadoReservaModel>>>();
        }
    }
}
