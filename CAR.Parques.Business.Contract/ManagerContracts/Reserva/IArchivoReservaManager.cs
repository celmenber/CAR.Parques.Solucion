namespace CAR.Parques.Business.Contract.ManagerContracts.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using System.Collections.Generic;

    public interface IArchivoReservaManager : IBaseAccionManager<ArchivoReservaEO>
    {
        ResultadoEjecucion<ArchivoReservaEO> ConsultarArchivoReserva(int reservaId);        
    }
}
