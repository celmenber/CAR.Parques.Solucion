namespace CAR.Parques.Business.Contract.ManagerContracts.ParqueContract
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using System.Collections.Generic;

    public interface IServicioParqueManager : IBaseAccionManager<ServicioParqueEO>
    {
        ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>> ConsultarServiciosParque(int parqueId);

        ResultadoEjecucion<ServicioParqueDetalleEO> ConsultarServiciosParqueDetalleXId(int servicioParqueId);
    }
}
