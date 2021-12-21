namespace CAR.Parques.DataContract.InterfacesTrasaccion.Parque
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using Common.Entities.Entidades.Parques;
    using System.Collections.Generic;

    public interface ITransaccionParqueQO : ITransaccionBaseQO<ParqueEO, ParqueDTO>
    {
        ResultadoEjecucion<IEnumerable<ParqueEO>> ConsultarTodosParques();

        ResultadoEjecucion<IEnumerable<ParqueDetalleEO>> ConsultarTodosParquesDetalle();

        ResultadoEjecucion<ParqueDetalleEO> ConsultarParquesDetalleXId(int parqueId);

        ResultadoEjecucion<ParqueInformacionEO> ConsultarParquesInformacionXId(int parqueId);

        ResultadoEjecucion<IEnumerable<ParqueInformacionEO>> ConsultarTodosParquesInformacionDetalle();
    }
}
