namespace CAR.Parques.UI.Proxy.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITipoServicioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoServicioProxy : BaseProxy, ITipoServicioProxy
    {
        private string nombreApi;

        public TipoServicioProxy()
        {
            nombreApi = "WaTipoServicio/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoServicioModel>>> ConsultarListadoTipoServicio()
        {
            this.AsociarServicio($"{nombreApi}ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<TipoServicioModel>>>();
        }
    }
}
