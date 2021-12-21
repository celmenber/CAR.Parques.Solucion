namespace CAR.Parques.Business.Contract.ManagerContracts.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using System.Collections.Generic;

    public interface IMenuPerfilManager : IBaseAccionManager<MenuPerfilEO>
    {
        ResultadoEjecucion<IEnumerable<MenuEO>> ConsultaMenuPorPerfil(int idPerfil);
    }
}
