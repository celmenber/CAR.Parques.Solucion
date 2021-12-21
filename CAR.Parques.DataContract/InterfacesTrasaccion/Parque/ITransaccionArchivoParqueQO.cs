namespace CAR.Parques.DataContract.InterfacesTrasaccion.Parque
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionArchivoParqueQO : ITransaccionBaseQO<ArchivoParqueEO, ArchivoParqueDTO>
    {
        ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId);
        ResultadoEjecucion<IEnumerable<TipoArchivoEO>> ConsultarTiposArchivo();
    }
}
