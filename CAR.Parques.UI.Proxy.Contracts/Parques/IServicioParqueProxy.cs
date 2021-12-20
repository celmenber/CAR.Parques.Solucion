namespace CAR.Parques.UI.Proxy.Contracts.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using System.Collections.Generic;

    public interface IServicioParqueProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ServicioParqueDetalleModel>>> ConsultarServiciosParque(int parqueId);

        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarServiciosParque(ServicioParqueDetalleModel servicioParque);

        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarServicioParque(int servicioParqueId);

        ResultadoEjecucion<ResultadoEjecucion<int>> CrearServicioParque(ServicioParqueModel servicioParque);

        ResultadoEjecucion<ResultadoEjecucion<ServicioParqueDetalleModel>> ConsultarDetalleServicioParqueXId(int servicioParqueId);
    }
}
