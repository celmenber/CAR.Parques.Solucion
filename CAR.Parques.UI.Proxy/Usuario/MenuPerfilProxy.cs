namespace CAR.Parques.UI.Proxy.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IMenuPerfilProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuPerfilProxy : BaseProxy, IMenuPerfilProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<MenuModel>>> ConsultaMenuPorPerfil(int idPerfil)
        {
            this.AsociarServicio("WaMenuPerfil/ConsultarMenuPerfilPorId", string.Empty);
            return this.Get<ResultadoEjecucion<IEnumerable<MenuModel>>>(idPerfil);
        }
    }
}
