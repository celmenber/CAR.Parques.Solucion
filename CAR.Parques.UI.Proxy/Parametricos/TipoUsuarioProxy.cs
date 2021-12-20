namespace CAR.Parques.UI.Proxy.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITipoUsuarioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoUsuarioProxy : BaseProxy, ITipoUsuarioProxy
    {
        private string nombreApi;

        public TipoUsuarioProxy()
        {
            nombreApi = "WaTipoUsuario/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoUsuarioModel>>> ConsultarListadoTipoUsuario()
        {
            this.AsociarServicio($"{nombreApi}ConsultarTodos", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<TipoUsuarioModel>>>();
        }
    }
}
