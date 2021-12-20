namespace CAR.Parques.UI.Proxy.Contracts.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using System.Collections.Generic;

    public interface IArchivoParqueProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearArchivoParque(ArchivoParqueModel archivoParque);

        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarArchivoParque(ArchivoParqueModel archivoParque);

        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarArchivo(int archivoParqueId);

        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ArchivoParqueEO>>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId);
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoArchivoEO>>> ConsultarTiposArchivo();
    }
}
