namespace CAR.Parques.Business.Contract.ManagerContracts.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;        

    public interface IDetalleReservaManager : IBaseAccionManager<DetalleReservaEO>
    {
        ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva);
    }
}
