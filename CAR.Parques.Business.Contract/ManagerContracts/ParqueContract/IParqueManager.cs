namespace CAR.Parques.Business.Contract.ManagerContracts.ParqueContract
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using System.Collections.Generic;

    public interface IParqueManager : IBaseAccionManager<ParqueEO>
    {
        ResultadoEjecucion<IEnumerable<ParqueEO>> ConsultarTodosParques();
        ResultadoEjecucion<IEnumerable<ParqueDetalleEO>> ConsultarTodosParquesDetalle();
        ResultadoEjecucion<ParqueDetalleEO> ConsultarParquesDetalleXId(int parqueId);
        ResultadoEjecucion<IEnumerable<ParqueInformacionEO>> ConsultarTodosParquesInformacionDetalle();
        ResultadoEjecucion<ParqueInformacionEO> ConsultarParquesInformacionXId(int parqueId);
    }
}
