namespace CAR.Parques.DataContract.InterfacesTrasaccion.Parque
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionServicioParqueQO : ITransaccionBaseQO<ServicioParqueEO, ServicioParqueDTO>
    {
        ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>> ConsultarServiciosParque(int parqueId);

        ResultadoEjecucion<ServicioParqueDetalleEO> ConsultarServicioParquesDetalleXId(int servicioParqueId);
    }
}
