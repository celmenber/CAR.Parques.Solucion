namespace CAR.Parques.UI.Proxy.Contracts.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using System.Collections.Generic;

    public interface IMenuPerfilProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<MenuModel>>> ConsultaMenuPorPerfil(int idPerfil);
    }
}
