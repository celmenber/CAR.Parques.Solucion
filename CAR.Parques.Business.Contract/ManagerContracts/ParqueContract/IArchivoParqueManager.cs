namespace CAR.Parques.Business.Contract.ManagerContracts.ParqueContract
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using System.Collections.Generic;

    public interface IArchivoParqueManager : IBaseAccionManager<ArchivoParqueEO>
    {
        ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId);
        ResultadoEjecucion<IEnumerable<TipoArchivoEO>> ConsultarTiposArchivo();
    }
}
