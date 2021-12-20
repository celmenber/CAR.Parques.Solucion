namespace CAR.Parques.UI.Proxy.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export (typeof(ITipoDocumentoProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoDocumentoProxy : BaseProxy, ITipoDocumentoProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoDocumentoModel>>> ConsultarListadoTipoDocumento()
        {
            this.AsociarServicio("WaTipoDocumento/ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<TipoDocumentoModel>>>();
        }
    }
}
