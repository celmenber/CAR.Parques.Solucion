namespace CAR.Parques.UI.Proxy.Usuario
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;

    [Export(typeof(IPerfilProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PerfilProxy : BaseProxy, IPerfilProxy
    {
        public ResultadoEjecucion<IEnumerable<PerfilModel>> ConsultarListadoPerfiles()
        {
            this.AsociarServicio("WaPerfil/ConsultarTodos", string.Empty);
            ResultadoEjecucion<IEnumerable<PerfilModel>> resultado = Get<ResultadoEjecucion<IEnumerable<PerfilModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<PerfilModel> ConsultarPerfilId(int perfilId)
        {
            this.AsociarServicio("WaPerfil/Consultar", string.Empty);
            ResultadoEjecucion<PerfilModel> resultado = Get<ResultadoEjecucion<PerfilModel>>(perfilId).Entidad;
            return resultado;
        }
    }
}
