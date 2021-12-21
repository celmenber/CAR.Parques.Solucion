namespace CAR.Parques.Business.Contract.ManagerContracts.LogContract
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Bitacora;

    public interface ILogManager
    {
        ResultadoEjecucion<bool> RegistrarLog(LogTransaccion log);
    }
}
