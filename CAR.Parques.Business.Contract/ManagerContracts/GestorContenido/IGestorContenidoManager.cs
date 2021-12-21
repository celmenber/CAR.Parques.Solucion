namespace CAR.Parques.Business.Contract.ManagerContracts.GestorContenido
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using System.Collections.Generic;

    public interface IGestorContenidoManager : IBaseAccionManager<GestorContenidoEO>
    {
        ResultadoEjecucion<IEnumerable<GestorContenidoEO>> ConsultarTodosVigentes();
    }
}
